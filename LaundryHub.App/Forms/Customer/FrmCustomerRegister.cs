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
        DoubleBuffered = true;
        ResizeRedraw = true;
        AddLogo();
        UIThemeHelper.StyleAuthForm(this, pnlCard, btnRegister, btnBack);
        CenterCardContents();
        InputValidator.RestrictToPhoneInput(txtPhone);
        InputValidator.RestrictToUsernameInput(txtUsername, 30);

        txtFullName.TextChanged += (_, _) => lblError.Visible = false;
        txtPhone.TextChanged += (_, _) => lblError.Visible = false;
        txtUsername.TextChanged += (_, _) => lblError.Visible = false;
        txtPassword.TextChanged += (_, _) => lblError.Visible = false;
        txtConfirmPassword.TextChanged += (_, _) => lblError.Visible = false;
        txtEmail.TextChanged += (_, _) => lblError.Visible = false;
        txtAddress.TextChanged += (_, _) => lblError.Visible = false;
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
            btnRegister_Click(btnRegister, EventArgs.Empty);
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void pnlCard_Paint(object? sender, PaintEventArgs e)
    {
        UIThemeHelper.PaintRoundedSolidCard(pnlCard, e, Color.White, UIThemeHelper.LoginCardRadius);
    }

    private void CenterCardContents()
    {
        UIThemeHelper.CenterLoginFields(
            pnlCard,
            lblTitle, lblSub,
            lblFullName, txtFullName,
            lblPhone, txtPhone,
            lblUsername, txtUsername,
            lblPassword, txtPassword,
            lblConfirmPassword, txtConfirmPassword,
            lblEmail, txtEmail,
            lblAddress, txtAddress,
            lblError, btnRegister, btnBack);
        lblError.TextAlign = ContentAlignment.MiddleCenter;
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;
        var fullName = txtFullName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var email = txtEmail.Text.Trim();

        try
        {
            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                FullName = fullName,
                Email = email,
                Role = UserRole.Customer.ToString(),
                IsActive = true
            };

            var customer = new CustomerModel
            {
                FullName = fullName,
                Phone = phone,
                Email = email,
                Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim()
            };

            AppServices.Customers.RegisterCustomerWithUser(user, customer);

            MessageBox.Show(
                "Account successfully created! You may now log in to view your orders.",
                "Registration Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            ShowError($"Registration error: {ex.Message}");
        }
    }

    private bool ValidateInputs()
    {
        lblError.Visible = false;

        if (!InputValidator.IsValidFullName(txtFullName.Text, out var nameErr))
        {
            ShowError(nameErr);
            txtFullName.Focus();
            return false;
        }

        if (!InputValidator.IsValidPhone(txtPhone.Text))
        {
            ShowError(InputValidator.PhoneError);
            txtPhone.Focus();
            return false;
        }

        var existingCustomer = AppServices.Customers.GetByPhone(txtPhone.Text.Trim());
        if (existingCustomer != null && existingCustomer.UserId != null)
        {
            ShowError("This phone number is already registered to an account.");
            txtPhone.Focus();
            return false;
        }

        if (!InputValidator.IsValidUsername(txtUsername.Text, out var userErr))
        {
            ShowError(userErr);
            txtUsername.Focus();
            return false;
        }

        if (AppServices.Users.UsernameExists(txtUsername.Text.Trim()))
        {
            ShowError("This username is already taken. Please choose another.");
            txtUsername.Focus();
            return false;
        }

        if (!InputValidator.IsValidPassword(txtPassword.Text, out var pwdError))
        {
            ShowError(pwdError);
            txtPassword.Focus();
            return false;
        }

        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            ShowError("Passwords do not match.");
            txtConfirmPassword.Focus();
            return false;
        }

        var emailText = txtEmail.Text.Trim();
        if (string.IsNullOrWhiteSpace(emailText))
        {
            ShowError("Email is required.");
            txtEmail.Focus();
            return false;
        }

        if (!InputValidator.IsValidEmail(emailText, out var emailErr))
        {
            ShowError(emailErr);
            txtEmail.Focus();
            return false;
        }

        if (AppServices.Users.EmailExists(emailText))
        {
            ShowError("This email address is already in use by another account.");
            txtEmail.Focus();
            return false;
        }

        if (!string.IsNullOrWhiteSpace(txtAddress.Text) && txtAddress.Text.Trim().Length > 255)
        {
            ShowError("Address cannot exceed 255 characters.");
            txtAddress.Focus();
            return false;
        }

        return true;
    }

    private void ShowError(string msg)
    {
        lblError.Text = msg;
        lblError.Visible = true;
    }

    /// <summary>Adds the logo at the top of the card and pushes everything else down.</summary>
    private void AddLogo()
    {
        const int shift = 64;
        foreach (Control c in pnlCard.Controls) c.Top += shift;
        pnlCard.Height += shift;

        var pic = new PictureBox
        {
            Name = "picLogo",
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.White,
            Bounds = new Rectangle(0, 18, pnlCard.Width, 56)
        };
        UIThemeHelper.LoadAuthLogo(pic);
        pnlCard.Controls.Add(pic);
    }
}
