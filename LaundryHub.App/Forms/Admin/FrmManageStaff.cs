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
        InitializeForm();
        LoadStaff();
    }

    private TextBox txtFullName = null!;
    private TextBox txtUsername = null!;
    private TextBox txtEmail = null!;
    private TextBox txtPassword = null!;
    private ComboBox cmbRole = null!;
    private CheckBox chkActive = null!;
    private Label lblError = null!;
    private Label lblFormTitle = null!;
    private Button btnSave = null!;
    private Button btnClear = null!;
    private Button btnToggleStatus = null!;
    private DataGridView dgvStaff = null!;

    private void InitializeForm()
    {
        this.Text = "LaundryHub – Staff & User Management";
        this.Size = new Size(950, 620);
        this.StartPosition = FormStartPosition.CenterParent;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Header
        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24, 0, 24, 0)
        };
        var lblTitle = new Label
        {
            Text = "👥 Manage Staff Accounts",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            AutoSize = false,
            Dock = DockStyle.Left,
            Width = 400,
            TextAlign = ContentAlignment.MiddleLeft
        };
        var btnClose = new Button
        {
            Text = "✕ Close",
            Size = new Size(90, 34),
            Dock = DockStyle.Right,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            Cursor = Cursors.Hand
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Click += (_, _) => this.Close();
        header.Controls.AddRange(new Control[] { lblTitle, btnClose });
        this.Controls.Add(header);

        // Body
        var container = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };
        this.Controls.Add(container);

        // Left Card (Form)
        var leftCard = new Panel
        {
            Dock = DockStyle.Left,
            Width = 360,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(20)
        };

        lblFormTitle = new Label
        {
            Text = "➕ New Staff Member",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Top,
            Height = 35
        };
        leftCard.Controls.Add(lblFormTitle);

        var formLayout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true
        };

        formLayout.Controls.Add(CreateFieldLabel("Full Name *"));
        txtFullName = CreateTextBox();
        formLayout.Controls.Add(txtFullName);

        formLayout.Controls.Add(CreateFieldLabel("Username *"));
        txtUsername = CreateTextBox();
        formLayout.Controls.Add(txtUsername);

        formLayout.Controls.Add(CreateFieldLabel("Email *"));
        txtEmail = CreateTextBox();
        formLayout.Controls.Add(txtEmail);

        formLayout.Controls.Add(CreateFieldLabel("Role *"));
        cmbRole = new ComboBox
        {
            Size = new Size(320, 32),
            DropDownStyle = ComboBoxStyle.DropDownList,
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10)
        };
        cmbRole.Items.AddRange(new object[] { "Staff", "Admin" });
        cmbRole.SelectedIndex = 0;
        formLayout.Controls.Add(cmbRole);

        formLayout.Controls.Add(CreateFieldLabel("Password * (or new password to reset)"));
        txtPassword = CreateTextBox(isPassword: true);
        formLayout.Controls.Add(txtPassword);

        chkActive = new CheckBox
        {
            Text = "Active account",
            Checked = true,
            ForeColor = Color.White,
            Padding = new Padding(0, 8, 0, 8)
        };
        formLayout.Controls.Add(chkActive);

        lblError = new Label
        {
            ForeColor = Color.FromArgb(248, 113, 113),
            Font = new Font("Segoe UI", 8.5f),
            Size = new Size(320, 36),
            Visible = false
        };
        formLayout.Controls.Add(lblError);

        var btnPanel = new FlowLayoutPanel
        {
            Size = new Size(320, 80),
            FlowDirection = FlowDirection.LeftToRight
        };

        btnSave = new Button
        {
            Text = "💾 Save Account",
            Size = new Size(155, 38),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Click += btnSave_Click;

        btnClear = new Button
        {
            Text = "↺ Clear",
            Size = new Size(155, 38),
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnClear.FlatAppearance.BorderSize = 0;
        btnClear.Click += (_, _) => ResetForm();

        btnPanel.Controls.AddRange(new Control[] { btnSave, btnClear });
        formLayout.Controls.Add(btnPanel);

        leftCard.Controls.Add(formLayout);
        container.Controls.Add(leftCard);

        // Right Card (Grid)
        var rightPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16, 0, 0, 0)
        };

        var toolBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 44,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(12, 6, 12, 6)
        };

        var lblGridTitle = new Label
        {
            Text = "Active Staff Accounts",
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Left,
            Width = 200,
            TextAlign = ContentAlignment.MiddleLeft
        };

        btnToggleStatus = new Button
        {
            Text = "🔄 Toggle Active/Inactive",
            Size = new Size(180, 32),
            Dock = DockStyle.Right,
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnToggleStatus.FlatAppearance.BorderSize = 0;
        btnToggleStatus.Click += btnToggleStatus_Click;

        toolBar.Controls.AddRange(new Control[] { lblGridTitle, btnToggleStatus });
        rightPanel.Controls.Add(toolBar);

        dgvStaff = new DataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = Color.FromArgb(30, 41, 59),
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Font = new Font("Segoe UI", 9.5f),
            GridColor = Color.FromArgb(51, 65, 85),
            RowTemplate = { Height = 36 },
            DefaultCellStyle =
            {
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(37, 99, 235),
                SelectionForeColor = Color.White
            },
            ColumnHeadersDefaultCellStyle =
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.FromArgb(148, 163, 184),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(6)
            },
            EnableHeadersVisualStyles = false
        };
        dgvStaff.SelectionChanged += dgvStaff_SelectionChanged;

        var gridWrap = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 10, 0, 0)
        };
        gridWrap.Controls.Add(dgvStaff);
        rightPanel.Controls.Add(gridWrap);

        container.Controls.Add(rightPanel);
    }

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

        if (dgvStaff.Columns["UserId"] != null)
            dgvStaff.Columns["UserId"].Visible = false;
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
                lblFormTitle.Text = $"✏ Edit Staff Member #{_selectedUser.UserId}";
                btnSave.Text = "✔ Update Info";
                txtFullName.Text = _selectedUser.FullName;
                txtUsername.Text = _selectedUser.Username;
                txtUsername.Enabled = false; // keep username immutable
                txtEmail.Text = _selectedUser.Email;
                cmbRole.SelectedItem = _selectedUser.Role;
                chkActive.Checked = _selectedUser.IsActive;
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

        if (_editingUserId > 0 && _selectedUser != null)
        {
            _selectedUser.FullName = name;
            _selectedUser.Email = email;
            _selectedUser.Role = role;
            _selectedUser.IsActive = chkActive.Checked;

            if (!string.IsNullOrWhiteSpace(pwd))
            {
                _selectedUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(pwd);
            }

            AppServices.Users.Update(_selectedUser);
            MessageBox.Show("Staff member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show($"New staff member '{username}' created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        LoadStaff();
        ResetForm();
    }

    private void btnToggleStatus_Click(object? sender, EventArgs e)
    {
        if (_selectedUser == null)
        {
            MessageBox.Show("Please select a staff member first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        bool newStatus = !_selectedUser.IsActive;
        AppServices.Users.SetActive(_selectedUser.UserId, newStatus);
        LoadStaff();
        MessageBox.Show($"User {_selectedUser.Username} is now {(newStatus ? "Active" : "Disabled")}.", "Status Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ResetForm()
    {
        _editingUserId = 0;
        _selectedUser = null;
        lblFormTitle.Text = "➕ New Staff Member";
        btnSave.Text = "💾 Save Account";
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

        if (string.IsNullOrWhiteSpace(txtFullName.Text))
        {
            ShowError("Please enter staff member's full name.");
            txtFullName.Focus();
            return false;
        }

        if (_editingUserId == 0)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Trim().Length < 3)
            {
                ShowError("Username must be at least 3 characters.");
                txtUsername.Focus();
                return false;
            }
            if (AppServices.Users.UsernameExists(txtUsername.Text.Trim()))
            {
                ShowError("Username is already in use.");
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                ShowError("Password must be at least 6 characters.");
                txtPassword.Focus();
                return false;
            }
        }

        if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            ShowError("Please enter a valid email address.");
            txtEmail.Focus();
            return false;
        }

        return true;
    }

    private void ShowError(string msg)
    {
        lblError.Text = $"⚠ {msg}";
        lblError.Visible = true;
    }

    private static Label CreateFieldLabel(string text) => new Label
    {
        Text = text,
        ForeColor = Color.FromArgb(148, 163, 184),
        Font = new Font("Segoe UI", 8.5f),
        Size = new Size(320, 18),
        Margin = new Padding(0, 5, 0, 2)
    };

    private static TextBox CreateTextBox(bool isPassword = false)
    {
        var tb = new TextBox
        {
            Size = new Size(320, 30),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };
        if (isPassword) tb.PasswordChar = '●';
        return tb;
    }
}
