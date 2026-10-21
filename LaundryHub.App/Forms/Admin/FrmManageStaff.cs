using LaundryHub.App.Helpers;
using LaundryHub.Core.Enums;
using LaundryHub.Core.Models;
using System.Text.RegularExpressions;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmManageStaff : Form
{
    private User? _selectedUser;
    private int _editingUserId = 0;

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

        LoadStaff();
    }

    private void btnClose_Click(object? sender, EventArgs e) => this.Close();

    private void btnClear_Click(object? sender, EventArgs e) => ResetForm();

    private void LoadStaff()
    {
        var staff = AppServices.Users.GetAllStaff().ToList();
        dgvStaff.DataSource = staff.Select(u => new
        {
            u.UserId,
            u.Username,
            Name = u.FullName,
            u.Email,
            u.Role,
            Status = u.IsActive ? "Active" : "Disabled",
            Created = u.CreatedAt.ToString("MM/dd/yyyy")
        }).ToList();

        if (dgvStaff.Columns["UserId"] is { } col)
            col.Visible = false;
    }

    private void dgvStaff_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvStaff.SelectedRows.Count == 0) return;
        var row = dgvStaff.SelectedRows[0];
        if (row.Cells["UserId"].Value is int id)
        {
                _selectedUser = AppServices.Users.GetById(id);
            if (_selectedUser != null)
            {
                _editingUserId = _selectedUser.UserId;
                lblFormTitle.Text = $" Edit Staff Member #{_selectedUser.UserId}";
                btnSave.Text = " Update Info";
                txtFullName.Text = _selectedUser.FullName;
                txtUsername.Text = _selectedUser.Username;
                txtUsername.Enabled = false; // keep username immutable
                txtEmail.Text = _selectedUser.Email;
                cmbRole.SelectedItem = _selectedUser.Role;
                chkActive.Checked = _selectedUser.IsActive;
                bool isSelf = _selectedUser.UserId == SessionManager.CurrentUser?.UserId;
                chkActive.Enabled = !isSelf;
                btnToggleStatus.Enabled = !isSelf;
                txtPassword.Clear();
                lblError.Visible = false;
            }
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
                {
                    _selectedUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(pwd);
                }

                AppServices.Users.Update(_selectedUser);
                UiMessages.Show("Staff member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                UiMessages.Show($"New staff member '{username}' created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadStaff();
            ResetForm();
        }
        catch (Exception ex)
        {
            ShowError($"Database error: {ex.Message}");
        }
    }

    private void btnToggleStatus_Click(object? sender, EventArgs e)
    {
        if (_selectedUser == null)
        {
            ShowError("Please select a staff member first.");
            return;
        }

        if (_selectedUser.UserId == SessionManager.CurrentUser?.UserId)
        {
            ShowError("You cannot disable your own admin account.");
            return;
        }

        try
        {
            bool newStatus = !_selectedUser.IsActive;
            AppServices.Users.SetActive(_selectedUser.UserId, newStatus);
            _selectedUser.IsActive = newStatus;
            chkActive.Checked = newStatus;

            int currentSelectedId = _selectedUser.UserId;
            LoadStaff();

            // Re-select the same staff member in the grid
            foreach (DataGridViewRow row in dgvStaff.Rows)
            {
                if (row.Cells["UserId"].Value is int id && id == currentSelectedId)
                {
                    row.Selected = true;
                    break;
                }
            }

            lblError.ForeColor = newStatus ? UIThemeHelper.Success : UIThemeHelper.Warning;
            lblError.Text = $" {_selectedUser.Username} is now {(newStatus ? "Active" : "Disabled")}.";
            lblError.Visible = true;
        }
        catch (Exception ex)
        {
            ShowError($"Failed to update status: {ex.Message}");
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
