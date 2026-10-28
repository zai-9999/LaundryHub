using LaundryHub.App.Helpers;
using LaundryHub.Core.Enums;
using LaundryHub.Core.Models;
using System.Text.RegularExpressions;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmManageStaff : Form
{
    private User? _selectedUser;
    private int _editingUserId = 0;
    private bool _showArchived = false;
    private bool _binding = false;
    private static readonly Font ArchiveFont = new("Segoe UI", 9.5F, FontStyle.Bold);

    public FrmManageStaff()
    {
        InitializeComponent();
        UIThemeHelper.ApplyTheme(this);
        UIThemeHelper.StyleDataGridView(dgvStaff);
        UIThemeHelper.EnableStatusPills(dgvStaff);
        pnlHeader.BackColor = UIThemeHelper.Navy;
        cmbRole.SelectedIndex = 0;

        InputValidator.RestrictToUsernameInput(txtUsername, 30);
        txtFullName.TextChanged += (_, _) => lblError.Visible = false;
        txtUsername.TextChanged += (_, _) => lblError.Visible = false;
        txtEmail.TextChanged += (_, _) => lblError.Visible = false;
        txtPassword.TextChanged += (_, _) => lblError.Visible = false;
        cmbRole.SelectedIndexChanged += (_, _) => lblError.Visible = false;

        // Wire up grid events
        dgvStaff.MultiSelect = false;
        dgvStaff.CellClick += dgvStaff_CellClick;
        dgvStaff.CellFormatting += dgvStaff_CellFormatting;
        dgvStaff.CellContentClick += dgvStaff_CellContentClick;
        dgvStaff.CellClick += dgvStaff_CellClick;

        // Replace Toggle button with Show Archived checkbox
        btnToggleStatus.Visible = false;
        chkShowArchived.Visible = true;
        chkShowArchived.Text = " Show Archived";
        chkShowArchived.CheckedChanged += (_, _) =>
        {
            _showArchived = chkShowArchived.Checked;
            LoadStaff();
        };

        LoadStaff();
    }

    private void btnClose_Click(object? sender, EventArgs e) => this.Close();
    private void btnClear_Click(object? sender, EventArgs e) => ResetForm();

    private void LoadStaff()
    {
        var staff = AppServices.Users.GetAllStaff(_showArchived).ToList();

        _binding = true;
        try
        {
            dgvStaff.DataSource = staff.Select(u => new
            {
                u.UserId,
                u.Username,
                Name = u.FullName,
                u.Email,
                u.Role,
                Status = u.IsArchived ? "Archived" : (u.IsActive ? "Active" : "Disabled"),
                Created = u.CreatedAt.ToString("MM/dd/yyyy"),
                u.IsArchived
            }).ToList();

            if (dgvStaff.Columns["UserId"] is { } col) col.Visible = false;
            if (dgvStaff.Columns["IsArchived"] is { } arcCol) arcCol.Visible = false;

            EnsureActionColumn();
            ApplyGridLayout();
            dgvStaff.ClearSelection();

            // Re-highlight if we were editing someone
            if (_editingUserId > 0)
            {
                foreach (DataGridViewRow r in dgvStaff.Rows)
                {
                    if (r.Cells["UserId"].Value is int rid && rid == _editingUserId)
                    {
                        r.Selected = true;
                        break;
                    }
                }
            }
        }
        finally { _binding = false; }
    }

    private void ApplyGridLayout()
    {
        void Weight(string name, float w)
        {
            if (dgvStaff.Columns[name] is { } c) c.FillWeight = w;
        }
        Weight("Username", 18);
        Weight("Name", 22);
        Weight("Email", 28);
        Weight("Role", 12);
        Weight("Status", 14);
        Weight("Created", 16);

        if (dgvStaff.Columns["colArchive"] is { } a)
        {
            a.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            a.Width = 100;
        }
    }

    private void EnsureActionColumn()
    {
        if (!dgvStaff.Columns.Contains("colArchive"))
        {
            dgvStaff.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colArchive",
                HeaderText = "Action",
                Text = "Archive",
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = UIThemeHelper.Danger,
                    ForeColor = Color.White,
                    SelectionBackColor = UIThemeHelper.Danger,
                    SelectionForeColor = Color.White,
                    Padding = new Padding(8, 5, 8, 5)
                }
            });
        }
        dgvStaff.Columns["colArchive"]!.DisplayIndex = dgvStaff.Columns.Count - 1;

        // Set per-row button text based on archived state
        foreach (DataGridViewRow row in dgvStaff.Rows)
        {
            bool isArchived = row.Cells["IsArchived"].Value is bool b && b;
            if (row.Cells["colArchive"] is DataGridViewButtonCell btn)
                btn.Value = isArchived ? "Restore" : "Archive";
        }
    }

    // Colour the Archive/Restore button cell per row
    private void dgvStaff_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || dgvStaff.Columns[e.ColumnIndex].Name != "colArchive") return;

        bool isArchived = dgvStaff.Rows[e.RowIndex].Cells["IsArchived"].Value is bool b && b;

        Color back = isArchived
            ? Color.FromArgb(220, 240, 225)   // soft green for Restore
            : Color.FromArgb(250, 232, 235);  // soft red for Archive

        Color fore = isArchived ? UIThemeHelper.Success : UIThemeHelper.Danger;

        e.CellStyle.BackColor = back;
        e.CellStyle.SelectionBackColor = back;
        e.CellStyle.ForeColor = fore;
        e.CellStyle.SelectionForeColor = fore;
        e.CellStyle.Font = ArchiveFont;
    }

    // Mouse-down — load row into form (skips the Action column)
    private void dgvStaff_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (_binding || e.RowIndex < 0) return;
        if (dgvStaff.Columns[e.ColumnIndex].Name == "colArchive") return;
        LoadStaffIntoForm(e.RowIndex);
    }

    // Click on the Archive/Restore button cell
    private void dgvStaff_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvStaff.Columns[e.ColumnIndex].Name != "colArchive") return;
        if (dgvStaff.Rows[e.RowIndex].Cells["UserId"].Value is not int id) return;

        bool isArchived = dgvStaff.Rows[e.RowIndex].Cells["IsArchived"].Value is bool b && b;
        if (isArchived)
            RestoreStaff(id);
        else
            ArchiveStaff(id);
    }

    private void LoadStaffIntoForm(int rowIndex)
    {
        try
        {
            if (rowIndex < 0 || rowIndex >= dgvStaff.Rows.Count) return;
            if (dgvStaff.Rows[rowIndex].Cells["UserId"].Value is not int id) return;

            var u = AppServices.Users.GetById(id);
            if (u == null) return;

            _selectedUser = u;
            _editingUserId = u.UserId;
            lblFormTitle.Text = $" Edit Staff #{u.UserId}";
            btnSave.Text = " Update Info";
            txtFullName.Text = u.FullName;
            txtUsername.Text = u.Username;
            txtUsername.Enabled = false;
            txtEmail.Text = u.Email;
            cmbRole.SelectedItem = u.Role;
            chkActive.Checked = u.IsActive;

            bool isSelf = u.UserId == SessionManager.CurrentUser?.UserId;
            chkActive.Enabled = !isSelf;
            txtPassword.Clear();
            lblError.Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Could not load staff member");
        }
    }

    private void ArchiveStaff(int userId)
    {
        var u = AppServices.Users.GetById(userId);
        if (u == null) return;

        if (u.UserId == SessionManager.CurrentUser?.UserId)
        {
            MessageBox.Show("You cannot archive your own account.", "Not Allowed",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Archive '{u.FullName}'? They will no longer be able to log in.",
            "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        try
        {
            AppServices.Users.Archive(userId);
            ResetForm();
            LoadStaff();
            MessageBox.Show("Staff member archived successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError($"Archive failed: {ex.Message}");
        }
    }

    private void RestoreStaff(int userId)
    {
        var u = AppServices.Users.GetById(userId);
        if (u == null) return;

        var confirm = MessageBox.Show(
            $"Restore '{u.FullName}'? Their account will be re-activated.",
            "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            AppServices.Users.Restore(userId);
            ResetForm();
            LoadStaff();
            MessageBox.Show("Staff member restored successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError($"Restore failed: {ex.Message}");
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        var name = txtFullName.Text.Trim();
        var email = txtEmail.Text.Trim();
        var role = cmbRole.SelectedItem?.ToString() ?? "Staff";
        var pwd = txtPassword.Text;

        try
        {
            if (_editingUserId > 0 && _selectedUser != null)
            {
                if (_selectedUser.UserId == SessionManager.CurrentUser?.UserId && !chkActive.Checked)
                {
                    ShowError("You cannot deactivate your own admin account.");
                    chkActive.Checked = true;
                    return;
                }

                _selectedUser.FullName = name;
                _selectedUser.Email = email;
                _selectedUser.Role = role;
                _selectedUser.IsActive = chkActive.Checked;

                if (!string.IsNullOrWhiteSpace(pwd))
                    _selectedUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(pwd);

                AppServices.Users.Update(_selectedUser);
                MessageBox.Show("Staff member updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var username = txtUsername.Text.Trim();
                var newUser = new User
                {
                    Username = username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(pwd),
                    FullName = name,
                    Email = email,
                    Role = role,
                    IsActive = chkActive.Checked
                };
                AppServices.Users.Add(newUser);
                MessageBox.Show($"New staff member '{username}' created!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadStaff();
            ResetForm();
        }
        catch (Exception ex)
        {
            ShowError($"Database error: {ex.Message}");
        }
    }

    private void ResetForm()
    {
        _editingUserId = 0;
        _selectedUser = null;
        lblFormTitle.Text = " New Staff Member";
        btnSave.Text = " Save Account";
        txtFullName.Clear();
        txtUsername.Clear();
        txtUsername.Enabled = true;
        txtEmail.Clear();
        txtPassword.Clear();
        cmbRole.SelectedIndex = 0;
        chkActive.Checked = true;
        lblError.Visible = false;
        dgvStaff.ClearSelection();
        try { dgvStaff.CurrentCell = null; } catch { }
    }

    private bool ValidateForm()
    {
        lblError.Visible = false;

        if (!InputValidator.IsValidFullName(txtFullName.Text, out var nameErr))
        {
            ShowError(nameErr);
            txtFullName.Focus();
            return false;
        }

        if (cmbRole.SelectedItem == null)
        {
            ShowError("Please select a valid role (Admin or Staff).");
            cmbRole.Focus();
            return false;
        }

        if (_editingUserId == 0)
        {
            if (!InputValidator.IsValidUsername(txtUsername.Text, out var userErr))
            {
                ShowError(userErr);
                txtUsername.Focus();
                return false;
            }
            if (AppServices.Users.UsernameExists(txtUsername.Text.Trim()))
            {
                ShowError("Username is already in use by another user.");
                txtUsername.Focus();
                return false;
            }
            if (!InputValidator.IsValidPassword(txtPassword.Text, out var pwdError))
            {
                ShowError(pwdError);
                txtPassword.Focus();
                return false;
            }
        }

        if (_editingUserId != 0 && !string.IsNullOrWhiteSpace(txtPassword.Text)
            && !InputValidator.IsValidPassword(txtPassword.Text, out var editPwdError))
        {
            ShowError(editPwdError);
            txtPassword.Focus();
            return false;
        }

        var email = txtEmail.Text.Trim();
        if (!InputValidator.IsValidEmail(email, out var emailErr))
        {
            ShowError(emailErr);
            txtEmail.Focus();
            return false;
        }

        if (AppServices.Users.EmailExists(email, _editingUserId))
        {
            ShowError("This email address is already in use by another account.");
            txtEmail.Focus();
            return false;
        }

        return true;
    }

    private void ShowError(string msg)
    {
        lblError.Text = $" {msg}";
        lblError.Visible = true;
    }
}
