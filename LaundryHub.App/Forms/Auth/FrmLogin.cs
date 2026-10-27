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
        EyeToggle.Attach(btnTogglePassword, () => !txtPassword.UseSystemPasswordChar);
        UIThemeHelper.LoadAuthLogo(picLogo);
        CenterCardContents();
        pnlCard.SizeChanged += (_, _) => CenterCardContents();
        txtUsername.TextChanged += (_, _) => lblError.Visible = false;
        txtPassword.TextChanged += (_, _) => lblError.Visible = false;
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

    private void CenterCardContents() => AuthLayout.Arrange(pnlCard);

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        if (!Validate()) return;

        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;

        // Throttle login attempts per username to mitigate brute force
        var key = $"login:{username}";
        var limit = 5;
        var window = TimeSpan.FromMinutes(15);
        var lockout = TimeSpan.FromMinutes(15);

        if (!ThrottleService.IsAllowed(key, limit, window, lockout))
        {
            var rem = ThrottleService.GetRemainingLockout(key);
            ShowError($"Too many login attempts. Try again in {Math.Ceiling(rem.TotalMinutes)} minutes.");
            return;
        }

        try
        {
            var user = AppServices.Users.GetByUsername(username);

            if (user == null || string.IsNullOrWhiteSpace(user.PasswordHash) || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ThrottleService.RegisterAttempt(key, limit, window, lockout);
                ShowError("Invalid username or password.");
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Successful login - reset throttle counter
            ThrottleService.Reset(key);

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
        catch (Exception ex)
        {
            ShowError($"Login error: {ex.Message}");
        }
    }

    private void btnSwitchToCustomer_Click(object? sender, EventArgs e)
    {
        var customerLogin = new FrmCustomerLogin();
        customerLogin.FormClosing += (_, _) => this.WindowState = customerLogin.WindowState;
        customerLogin.FormClosed += (_, _) => this.Show();
        customerLogin.WindowState = this.WindowState;
        customerLogin.Show();
        this.Hide();
    }

    private void lnkForgotPassword_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        using var frm = new FrmPasswordReset();
        frm.ShowDialog(this);
    }

    private void btnTogglePassword_Click(object? sender, EventArgs e)
    {
        bool hide = !txtPassword.UseSystemPasswordChar;
        txtPassword.UseSystemPasswordChar = hide;
        txtPassword.PasswordChar = '\0';
        btnTogglePassword.Invalidate();
    }

    private void OpenDashboard()
    {
        Form dashboard = SessionManager.Role switch
        {
            UserRole.Admin => new Admin.FrmAdminDashboard(),
            UserRole.Staff => new Staff.FrmStaffDashboard(),
            _ => throw new InvalidOperationException("Unknown role")
        };

        dashboard.FormClosing += (_, _) => this.WindowState = dashboard.WindowState;
        dashboard.FormClosed += (_, _) =>
        {
            SessionManager.Logout();
            this.Show();
            ClearFields();
        };

        dashboard.WindowState = this.WindowState;
        dashboard.Show();
        this.Hide();
    }

    private new bool Validate()
    {
        lblError.Visible = false;
        var username = txtUsername.Text.Trim();
        if (string.IsNullOrWhiteSpace(username))
        {
            ShowError("Please enter your username.");
            txtUsername.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            ShowError("Please enter your password.");
            txtPassword.Focus();
            return false;
        }

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
