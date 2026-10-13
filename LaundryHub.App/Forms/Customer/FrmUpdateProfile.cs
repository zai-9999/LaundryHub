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

        UIThemeHelper.StyleStandardForm(this, pnlMain);
        pnlMain.Dock = DockStyle.None;
        pnlMain.BackColor = UIThemeHelper.CardWhite;
        this.ClientSize = new Size(520, 560);
        pnlMain.Bounds = new Rectangle(24, 24, this.ClientSize.Width - 48, this.ClientSize.Height - 48);
        UIThemeHelper.ApplyRoundedRegion(pnlMain, UIThemeHelper.LoginCardRadius);
        pnlMain.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlMain, UIThemeHelper.LoginCardRadius);
        UIThemeHelper.ApplyRoundedButtons(UIThemeHelper.LoginButtonRadius, btnSave, btnCancel);
        // Save button – navy
        btnSave.PrimaryColor = Color.FromArgb(37, 78, 122);
        btnSave.TextColor = Color.White;
        btnSave.HoverTextColor = Color.White;
        // Cancel button – solid gray, always clearly visible
        btnCancel.PrimaryColor = Color.FromArgb(108, 117, 125);
        btnCancel.BorderColor = Color.FromArgb(108, 117, 125);
        btnCancel.TextColor = Color.White;
        btnCancel.HoverTextColor = Color.White;

        if (customer != null)
        {
            txtFullName.Text = customer.FullName ?? "";
            txtPhone.Text = customer.Phone ?? "";
            txtEmail.Text = customer.Email ?? "";
            txtAddress.Text = customer.Address ?? "";
        }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            btnSave_Click(btnSave, EventArgs.Empty);
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
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

        if (string.IsNullOrWhiteSpace(phone) || phone.Length < 7)
        {
            ShowError("Please enter a valid phone number.");
            return;
        }

        if (AppServices.Customers.PhoneExists(phone, _customer.CustomerId))
        {
            ShowError("Phone number is already used by another customer.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            ShowError("Please enter a valid email format.");
            return;
        }

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
            if (newPwd.Length < 6)
            {
                ShowError("New password must be at least 6 characters.");
                return;
            }
            _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPwd);
        }
        AppServices.Users.Update(_user);

        MessageBox.Show("Profile successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void ShowError(string msg)
    {
        lblError.Text = $"⚠ {msg}";
        lblError.Visible = true;
    }
}
