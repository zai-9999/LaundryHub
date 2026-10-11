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
        InitializeForm();
    }

    private TextBox txtUsername = null!;
    private TextBox txtPassword = null!;
    private TextBox txtConfirmPassword = null!;
    private TextBox txtFullName = null!;
    private TextBox txtPhone = null!;
    private TextBox txtEmail = null!;
    private TextBox txtAddress = null!;
    private Button btnRegister = null!;
    private Button btnBack = null!;
    private Label lblError = null!;

    private void InitializeForm()
    {
        this.Text = "LaundryHub – Create Customer Account";
        this.Size = new Size(520, 750);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        var card = new Panel
        {
            Size = new Size(440, 660),
            Location = new Point(40, 25),
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24)
        };
        card.Paint += (s, e) =>
        {
            using var pen = new Pen(Color.FromArgb(59, 130, 246), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        };

        var lblTitle = new Label
        {
            Text = "Create Customer Account",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            Size = new Size(390, 32),
            Location = new Point(24, 15),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var lblSub = new Label
        {
            Text = "Track your laundry orders anytime from home",
            Font = new Font("Segoe UI", 8.5f),
            ForeColor = Color.FromArgb(148, 163, 184),
            Size = new Size(390, 20),
            Location = new Point(24, 48),
            TextAlign = ContentAlignment.MiddleCenter
        };

        card.Controls.AddRange(new Control[] { lblTitle, lblSub });

        int top = 80;
        int step = 60;

        AddField(card, "Full Name *", ref txtFullName, ref top, step);
        AddField(card, "Phone Number *", ref txtPhone, ref top, step);
        AddField(card, "Username *", ref txtUsername, ref top, step);
        AddField(card, "Password *", ref txtPassword, ref top, step, isPassword: true);
        AddField(card, "Confirm Password *", ref txtConfirmPassword, ref top, step, isPassword: true);
        AddField(card, "Email Address (Optional)", ref txtEmail, ref top, step);
        AddField(card, "Home / Delivery Address (Optional)", ref txtAddress, ref top, step);

        lblError = new Label
        {
            ForeColor = Color.FromArgb(248, 113, 113),
            Location = new Point(24, top + 6),
            Size = new Size(390, 34),
            Visible = false,
            Font = new Font("Segoe UI", 8.5f)
        };
        card.Controls.Add(lblError);

        btnRegister = new Button
        {
            Text = "✨ Create Account",
            Location = new Point(24, top + 45),
            Size = new Size(390, 38),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.Click += btnRegister_Click;

        btnBack = new Button
        {
            Text = "← Back to Login",
            Location = new Point(24, top + 90),
            Size = new Size(390, 32),
            BackColor = Color.Transparent,
            ForeColor = Color.FromArgb(148, 163, 184),
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnBack.FlatAppearance.BorderSize = 0;
        btnBack.Click += (_, _) =>
        {
            new Auth.FrmLogin().Show();
            this.Close();
        };

        card.Controls.AddRange(new Control[] { btnRegister, btnBack });
        this.Controls.Add(card);
        this.AcceptButton = btnRegister;
    }

    private static void AddField(Panel card, string labelText, ref TextBox tb, ref int top, int step, bool isPassword = false)
    {
        var lbl = new Label
        {
            Text = labelText,
            ForeColor = Color.FromArgb(148, 163, 184),
            Location = new Point(24, top),
            Size = new Size(390, 18),
            Font = new Font("Segoe UI", 8.5f)
        };
        tb = new TextBox
        {
            Location = new Point(24, top + 20),
            Size = new Size(390, 30),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };
        if (isPassword) tb.PasswordChar = '●';
        card.Controls.AddRange(new Control[] { lbl, tb });
        top += step;
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
