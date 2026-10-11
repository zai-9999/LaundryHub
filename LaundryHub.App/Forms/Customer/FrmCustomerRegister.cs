using LaundryHub.App.Helpers;
using LaundryHub.Core.Enums;
using LaundryHub.Core.Models;
using System.Text.RegularExpressions;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Customer;

public partial class FrmCustomerRegister : Form
{
    public FrmCustomerRegister()
    {
        InitializeComponent();
    }

    private void pnlCard_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(59, 130, 246), 1);
        e.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        new Auth.FrmLogin().Show();
        this.Close();
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;
        var fullName = txtFullName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var email = string.IsNullOrWhiteSpace(txtEmail.Text) ? $"{username}@laundryhub.local" : txtEmail.Text.Trim();

        try
        {
            // 1. Create User
            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                FullName = fullName,
                Email = email,
                Role = UserRole.Customer.ToString(),
                IsActive = true
            };
            AppServices.Users.Add(user);

            var createdUser = AppServices.Users.GetByUsername(username);
            int? userId = createdUser?.UserId;

            // 2. Create Customer Profile
            var customer = new CustomerModel
            {
                UserId = userId,
                FullName = fullName,
                Phone = phone,
                Email = email,
                Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim()
            };
            AppServices.Customers.Add(customer);

            MessageBox.Show("Account successfully created! You may now log in to view your orders.", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            new Auth.FrmLogin().Show();
            this.Close();
        }
        catch (Exception ex)
        {
            ShowError($"Registration error: {ex.Message}");
        }
    }

    private bool ValidateInputs()
    {
        lblError.Visible = false;

        if (string.IsNullOrWhiteSpace(txtFullName.Text) || txtFullName.Text.Trim().Length < 2)
        {
            ShowError("Please enter your full name.");
            txtFullName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text.Trim().Length < 7)
        {
            ShowError("Please enter a valid phone number (min 7 digits).");
            txtPhone.Focus();
            return false;
        }

        if (AppServices.Customers.PhoneExists(txtPhone.Text.Trim()))
        {
            ShowError("This phone number is already registered.");
            txtPhone.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Trim().Length < 3)
        {
            ShowError("Username must be at least 3 characters.");
            txtUsername.Focus();
            return false;
        }

        if (AppServices.Users.UsernameExists(txtUsername.Text.Trim()))
        {
            ShowError("This username is already taken. Please choose another.");
            txtUsername.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
        {
            ShowError("Password must be at least 6 characters.");
            txtPassword.Focus();
            return false;
        }

        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            ShowError("Passwords do not match.");
            txtConfirmPassword.Focus();
            return false;
        }

        if (!string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowError("Please enter a valid email address.");
                txtEmail.Focus();
                return false;
            }
        }

        return true;
    }

    private void ShowError(string msg)
    {
        lblError.Text = $"⚠ {msg}";
        lblError.Visible = true;
    }
}
