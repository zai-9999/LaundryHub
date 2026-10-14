using LaundryHub.App.Helpers;
using LaundryHub.Core.Enums;
using BCrypt.Net;

namespace LaundryHub.App.Forms.Auth;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;
        UIThemeHelper.StyleAuthForm(this, pnlCard, btnLogin, btnSwitchToCustomer);
        UIThemeHelper.LoadAuthLogo(picLogo);
        CenterCardContents();
        pnlCard.SizeChanged += (_, _) => CenterCardContents();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void FrmLogin_Load(object? sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            btnLogin_Click(btnLogin, EventArgs.Empty);
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
            picLogo, lblTitle, lblSubtitle,
            lblUser, txtUsername,
            lblPass, txtPassword,
            lblError, btnLogin,
            lnkForgotPassword, lblSeparator,
            btnSwitchToCustomer);
        lblError.TextAlign = ContentAlignment.MiddleCenter;
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        if (!Validate()) return;

        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;

        var user = AppServices.Users.GetByUsername(username);

        if (user == null || string.IsNullOrWhiteSpace(user.PasswordHash) || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
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

        if (user.Role == UserRole.Customer.ToString())
        {
            SessionManager.Logout();
            ShowError("This portal is for Staff & Admin only. Please use the Customer Portal.");
            txtPassword.Clear();
            return;
        }

        OpenDashboard();
    }

    private void btnSwitchToCustomer_Click(object? sender, EventArgs e)
    {
        var customerLogin = new FrmCustomerLogin();
        customerLogin.FormClosed += (_, _) => this.Show();
        customerLogin.Show();
        this.Hide();
    }

    private void lnkForgotPassword_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        MessageBox.Show("Please contact your administrator to reset your password.",
            "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void OpenDashboard()
    {
        Form dashboard = SessionManager.Role switch
        {
            UserRole.Admin => new Admin.FrmAdminDashboard(),
            UserRole.Staff => new Staff.FrmStaffDashboard(),
            _ => throw new InvalidOperationException("Unknown role")
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
        lblError.Text = msg;
        lblError.Visible = true;
    }

    private void ClearFields()
    {
        txtUsername.Clear();
        txtPassword.Clear();
        lblError.Visible = false;
    }
}
