using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Text.RegularExpressions;

namespace LaundryHub.App.Forms.Customer;

public partial class FrmUpdateProfile : Form
{
    private readonly Core.Models.Customer _customer;
    private readonly User _user;

    public FrmUpdateProfile() : this(new Core.Models.Customer(), new User())
    {
    }

    public FrmUpdateProfile(Core.Models.Customer customer, User user)
    {
        _customer = customer;
        _user = user;
        InitializeComponent();
        UIThemeHelper.ApplyTheme(this);

        InputValidator.RestrictToPhoneInput(txtPhone);

        if (customer != null)
        {
            txtFullName.Text = customer.FullName ?? "";
            txtPhone.Text = customer.Phone ?? "";
            txtEmail.Text = customer.Email ?? "";
            txtAddress.Text = customer.Address ?? "";
        }
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        lblError.Visible = false;
        var name = txtFullName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var email = txtEmail.Text.Trim();
        var address = txtAddress.Text.Trim();
        var newPwd = txtNewPassword.Text;

        if (string.IsNullOrWhiteSpace(name))
        {
            ShowError("Full Name cannot be empty.");
            return;
        }

        if (!InputValidator.IsValidPhone(phone))
        {
            ShowError(InputValidator.PhoneError);
            return;
        }

        if (AppServices.Customers.PhoneExists(phone, _customer.CustomerId))
        {
            ShowError("Phone number is already used by another customer.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowError("Please enter a valid email format.");
                return;
            }

            if (AppServices.Users.EmailExists(email, _user.UserId))
            {
                ShowError("Email address is already used by another account.");
                return;
            }
        }

        if (!string.IsNullOrWhiteSpace(newPwd) && !InputValidator.IsValidPassword(newPwd, out var pwdError))
        {
            ShowError(pwdError);
            return;
        }

        try
        {
            // Update customer
            _customer.FullName = name;
            _customer.Phone = phone;
            _customer.Email = string.IsNullOrWhiteSpace(email) ? null : email;
            _customer.Address = string.IsNullOrWhiteSpace(address) ? null : address;
            AppServices.Customers.Update(_customer);

            // Update user
            _user.FullName = name;
            if (!string.IsNullOrWhiteSpace(email)) _user.Email = email;
            if (!string.IsNullOrWhiteSpace(newPwd))
            {
                _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPwd);
            }
            AppServices.Users.Update(_user);

            MessageBox.Show("Profile successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            ShowError($"Database error: {ex.Message}");
        }
    }

    private void ShowError(string msg)
    {
        lblError.Text = $"⚠ {msg}";
        lblError.Visible = true;
    }
}
