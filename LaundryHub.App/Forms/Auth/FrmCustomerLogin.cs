using LaundryHub.App.Helpers;
using LaundryHub.Core.Enums;
using BCrypt.Net;
using System.IO;

namespace LaundryHub.App.Forms.Auth;

public partial class FrmCustomerLogin : Form
{
    public FrmCustomerLogin()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;
        UIThemeHelper.StyleAuthForm(this, pnlCard, btnLogin, btnRegister, btnPricing, btnGuestLookup, btnSwitchToStaff);
        LoadLogo();
        CenterCardContents();
        pnlCard.SizeChanged += (_, _) => CenterCardContents();
    }

    private void LoadLogo()
    {
        try
        {
            var logoPath = Path.Combine(Application.StartupPath, "Resources", "logo.png");
            if (File.Exists(logoPath))
            {
                picLogo.Image = Image.FromFile(logoPath);
            }
        }
        catch
        {
            // If logo fails to load, continue without it
        }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void FrmCustomerLogin_Load(object? sender, EventArgs e)
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

    // ─── Event Handlers ──────────────────────────────────────────────────────

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
            ShowError("Your account has been deactivated. Please contact the shop.");
            return;
        }

        // Block Staff/Admin from using the Customer Portal
        if (user.Role != UserRole.Customer.ToString())
        {
            ShowError("This portal is for Customers only. Staff & Admin please use the main portal.");
            txtPassword.Clear();
            return;
        }

        SessionManager.Login(user);
        OpenCustomerPortal();
    }

    private void btnGuestLookup_Click(object? sender, EventArgs e)
    {
        var guestForm = new Guest.FrmGuestLookup();
        guestForm.FormClosed += (_, _) => this.Show();
        guestForm.Show();
        this.Hide();
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        var regForm = new Customer.FrmCustomerRegister();
        regForm.FormClosed += (_, _) => this.Show();
        regForm.Show();
        this.Hide();
    }

    private void btnPricing_Click(object? sender, EventArgs e)
    {
        var pricing = new Guest.FrmGuestPricing();
        pricing.ShowDialog(this);
    }

    private void btnSwitchToStaff_Click(object? sender, EventArgs e)
    {
        this.Close(); // Returns to the Staff/Admin login (which re-shows via FormClosed)
    }

    // ─── Navigation ───────────────────────────────────────────────────────────

    private void OpenCustomerPortal()
    {
        var portal = new Customer.FrmCustomerPortal();

        portal.FormClosed += (_, _) =>
        {
            SessionManager.Logout();
            this.Show();
            ClearFields();
        };

        portal.Show();
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
        lblError.Text = msg;
        lblError.Visible = true;
    }

    private void ClearFields()
    {
        txtUsername.Clear();
        txtPassword.Clear();
        lblError.Visible = false;
    }

    private void pnlCard_Paint(object sender, PaintEventArgs e)
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
            lblSeparator, btnRegister,
            btnPricing, btnGuestLookup, btnSwitchToStaff);
        lblError.TextAlign = ContentAlignment.MiddleCenter;
    }
}
