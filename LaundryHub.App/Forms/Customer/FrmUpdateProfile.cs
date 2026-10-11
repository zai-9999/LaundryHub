using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Text.RegularExpressions;

namespace LaundryHub.App.Forms.Customer;

public partial class FrmUpdateProfile : Form
{
    private readonly Core.Models.Customer _customer;
    private readonly User _user;

    public FrmUpdateProfile(Core.Models.Customer customer, User user)
    {
        _customer = customer;
        _user = user;
        InitializeForm();
    }

    private TextBox txtFullName = null!;
    private TextBox txtPhone = null!;
    private TextBox txtEmail = null!;
    private TextBox txtAddress = null!;
    private TextBox txtNewPassword = null!;
    private Label lblError = null!;
    private Button btnSave = null!;
    private Button btnCancel = null!;

    private void InitializeForm()
    {
        this.Text = "LaundryHub – Edit Profile";
        this.Size = new Size(460, 560);
        this.StartPosition = FormStartPosition.CenterParent;
        this.BackColor = Color.FromArgb(15, 23, 42);
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24)
        };

        var lblTitle = new Label
        {
            Text = "👤 My Profile Details",
            Font = new Font("Segoe UI", 14, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            Dock = DockStyle.Top,
            Height = 35
        };
        panel.Controls.Add(lblTitle);

        int top = 50;
        int step = 60;

        AddField(panel, "Full Name *", ref txtFullName, ref top, step, _customer.FullName);
        AddField(panel, "Phone Number *", ref txtPhone, ref top, step, _customer.Phone);
        AddField(panel, "Email Address", ref txtEmail, ref top, step, _customer.Email ?? "");
        AddField(panel, "Home / Delivery Address", ref txtAddress, ref top, step, _customer.Address ?? "");
        AddField(panel, "Change Password (leave blank to keep current)", ref txtNewPassword, ref top, step, "", isPassword: true);

        lblError = new Label
        {
            ForeColor = Color.FromArgb(248, 113, 113),
            Location = new Point(24, top + 5),
            Size = new Size(390, 26),
            Visible = false,
            Font = new Font("Segoe UI", 8.5f)
        };
        panel.Controls.Add(lblError);

        btnSave = new Button
        {
            Text = "💾 Save Changes",
            Location = new Point(24, top + 35),
            Size = new Size(190, 38),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Click += btnSave_Click;

        btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(224, top + 35),
            Size = new Size(190, 38),
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.Click += (_, _) => this.Close();

        panel.Controls.AddRange(new Control[] { btnSave, btnCancel });
        this.Controls.Add(panel);
    }

    private static void AddField(Panel panel, string labelText, ref TextBox tb, ref int top, int step, string initialValue, bool isPassword = false)
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
            Text = initialValue,
            Location = new Point(24, top + 20),
            Size = new Size(390, 30),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };
        if (isPassword) tb.PasswordChar = '●';
        panel.Controls.AddRange(new Control[] { lbl, tb });
        top += step;
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
