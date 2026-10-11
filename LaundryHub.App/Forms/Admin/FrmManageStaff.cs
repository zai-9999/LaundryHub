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
        cmbRole.SelectedIndex = 0;
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
}
