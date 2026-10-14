using LaundryHub.App.Helpers;
using LaundryHub.Core.Enums;
using BCrypt.Net;

namespace LaundryHub.App.Forms.Auth;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
    }

    private void FrmLogin_Load(object? sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    private void pnlCard_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        using var pen = new Pen(Color.FromArgb(59, 130, 246), 1);
        g.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
    }

    // ─── Event Handlers ──────────────────────────────────────────────────────

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        if (!Validate()) return;

        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;

        var user = AppServices.Users.GetByUsername(username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            ShowError("Invalid username or password.");
            txtPassword.Clear();
            txtPassword.Focus();
            return;
        }

        if (!user.IsActive)
        {
            ShowError("Your account has been deactivated. Please contact the administrator.");
            return;
        }

        SessionManager.Login(user);
        OpenDashboard();
    }

    private void btnGuestLookup_Click(object? sender, EventArgs e)
    {
        var guestForm = new Guest.FrmGuestLookup();
        guestForm.FormClosed += (_, _) => this.Show();
        guestForm.Show();
        this.Hide();
    }

    private void btnCustomerRegister_Click(object? sender, EventArgs e)
    {
        var regForm = new Customer.FrmCustomerRegister();
        regForm.FormClosed += (_, _) => this.Show();
        regForm.Show();
        this.Hide();
    }

    private void lnkForgotPassword_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        MessageBox.Show("Please contact your administrator to reset your password.",
            "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ─── Navigation ───────────────────────────────────────────────────────────

    private void OpenDashboard()
    {
        Form dashboard = SessionManager.Role switch
        {
            UserRole.Admin   => new Admin.FrmAdminDashboard(),
            UserRole.Staff   => new Staff.FrmStaffDashboard(),
            UserRole.Customer => new Customer.FrmCustomerPortal(),
            _                => throw new InvalidOperationException("Unknown role")
        };

        dashboard.FormClosed += (_, _) =>
        {
            SessionManager.Logout();
            this.Show();
            ClearFields();
        };

        dashboard.Show();
        this.Hide();
    }

    // ─── Validation ───────────────────────────────────────────────────────────

    private new bool Validate()
    {
        lblError.Visible = false;
        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        { ShowError("Username is required."); txtUsername.Focus(); return false; }
        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        { ShowError("Password is required."); txtPassword.Focus(); return false; }
        return true;
    }

    private void ShowError(string msg)
    {
        lblError.Text    = msg;
        lblError.Visible = true;
    }

    private void ClearFields()
    {
        txtUsername.Clear();
        txtPassword.Clear();
        lblError.Visible = false;
    }
}
