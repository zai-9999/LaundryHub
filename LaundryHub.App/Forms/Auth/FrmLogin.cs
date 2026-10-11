using LaundryHub.App.Helpers;
using LaundryHub.Core.Enums;
using BCrypt.Net;

namespace LaundryHub.App.Forms.Auth;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
        ApplyStyling();
    }

    // ─── Event Handlers ──────────────────────────────────────────────────────

    private void btnLogin_Click(object sender, EventArgs e)
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

    private void btnGuestLookup_Click(object sender, EventArgs e)
    {
        var guestForm = new Guest.FrmGuestLookup();
        guestForm.Show();
        this.Hide();
    }

    private void btnCustomerRegister_Click(object sender, EventArgs e)
    {
        var regForm = new Customer.FrmCustomerRegister();
        regForm.Show();
        this.Hide();
    }

    private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

    // ─── Styling (code-behind, no designer needed) ────────────────────────────

    private TextBox txtUsername  = null!;
    private TextBox txtPassword  = null!;
    private Button  btnLogin     = null!;
    private Button  btnGuestLookup = null!;
    private Button  btnCustomerRegister = null!;
    private Label   lblError     = null!;
    private LinkLabel lnkForgotPassword = null!;

    private void InitializeComponent()
    {
        this.Text            = "LaundryHub – Login";
        this.Size            = new Size(480, 580);
        this.StartPosition   = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox     = false;
        this.BackColor       = Color.FromArgb(15, 23, 42);   // slate-900
    }

    private void ApplyStyling()
    {
        // ── Panel card ─────────────────────────────────────────
        var card = new Panel
        {
            Size      = new Size(380, 460),
            Location  = new Point(50, 60),
            BackColor = Color.FromArgb(30, 41, 59),           // slate-800
        };
        card.Paint += (s, e) =>
        {
            var g = e.Graphics;
            using var pen = new Pen(Color.FromArgb(59, 130, 246), 1);
            g.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        };

        // ── Logo / Title ───────────────────────────────────────
        var lblLogo = new Label
        {
            Text      = "🧺",
            Font      = new Font("Segoe UI Emoji", 32),
            ForeColor = Color.White,
            AutoSize  = false,
            Size      = new Size(380, 60),
            Location  = new Point(0, 20),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var lblTitle = new Label
        {
            Text      = "LaundryHub",
            Font      = new Font("Segoe UI", 22, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),   // blue-400
            AutoSize  = false,
            Size      = new Size(380, 36),
            Location  = new Point(0, 78),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var lblSub = new Label
        {
            Text      = "Laundry Order & Tracking System",
            Font      = new Font("Segoe UI", 9),
            ForeColor = Color.FromArgb(148, 163, 184),  // slate-400
            AutoSize  = false,
            Size      = new Size(380, 20),
            Location  = new Point(0, 112),
            TextAlign = ContentAlignment.MiddleCenter
        };

        // ── Fields ─────────────────────────────────────────────
        var lblUser = MakeLabel("Username", 148);
        txtUsername  = MakeTextBox(170, false);

        var lblPass  = MakeLabel("Password", 218);
        txtPassword  = MakeTextBox(240, true);

        lblError = new Label
        {
            Text      = "",
            ForeColor = Color.FromArgb(248, 113, 113),  // red-400
            Font      = new Font("Segoe UI", 8.5f),
            AutoSize  = false,
            Size      = new Size(300, 18),
            Location  = new Point(40, 285),
            Visible   = false
        };

        // ── Buttons ────────────────────────────────────────────
        btnLogin = MakeButton("Sign In", 308, Color.FromArgb(37, 99, 235));
        btnLogin.Click += btnLogin_Click;

        lnkForgotPassword = new LinkLabel
        {
            Text      = "Forgot password?",
            Location  = new Point(120, 352),
            Size      = new Size(140, 20),
            Font      = new Font("Segoe UI", 8.5f),
            LinkColor = Color.FromArgb(96, 165, 250),
            TextAlign = ContentAlignment.MiddleCenter
        };
        lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;

        // ── Bottom links ───────────────────────────────────────
        var sep = new Label
        {
            Text      = "──── or ────",
            Font      = new Font("Segoe UI", 8),
            ForeColor = Color.FromArgb(71, 85, 105),
            AutoSize  = false,
            Size      = new Size(300, 18),
            Location  = new Point(40, 378),
            TextAlign = ContentAlignment.MiddleCenter
        };

        btnGuestLookup = MakeOutlineButton("🔍  Check Order Status (Guest)", 400);
        btnGuestLookup.Click += btnGuestLookup_Click;

        btnCustomerRegister = MakeOutlineButton("📝  Register as Customer", 432);
        btnCustomerRegister.Click += btnCustomerRegister_Click;

        // ── Assemble ───────────────────────────────────────────
        card.Controls.AddRange(new Control[]
        {
            lblLogo, lblTitle, lblSub,
            lblUser, txtUsername,
            lblPass, txtPassword,
            lblError, btnLogin, lnkForgotPassword,
            sep, btnGuestLookup, btnCustomerRegister
        });

        this.Controls.Add(card);

        // Enter key triggers login
        this.AcceptButton = btnLogin;

        // Focus username on load
        this.Load += (_, _) => txtUsername.Focus();
    }

    // ─── Style factories ─────────────────────────────────────────────────────

    private static Label MakeLabel(string text, int top) => new Label
    {
        Text      = text,
        ForeColor = Color.FromArgb(148, 163, 184),
        Font      = new Font("Segoe UI", 8.5f),
        Location  = new Point(40, top),
        AutoSize  = true
    };

    private static TextBox MakeTextBox(int top, bool isPassword)
    {
        var tb = new TextBox
        {
            Location        = new Point(40, top),
            Size            = new Size(300, 34),
            Font            = new Font("Segoe UI", 11),
            BackColor       = Color.FromArgb(15, 23, 42),
            ForeColor       = Color.White,
            BorderStyle     = BorderStyle.FixedSingle,
        };
        if (isPassword) tb.PasswordChar = '●';
        return tb;
    }

    private static Button MakeButton(string text, int top, Color bg)
    {
        var btn = new Button
        {
            Text      = text,
            Location  = new Point(40, top),
            Size      = new Size(300, 38),
            Font      = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
            BackColor = bg,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor    = Cursors.Hand
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }

    private static Button MakeOutlineButton(string text, int top)
    {
        var btn = new Button
        {
            Text      = text,
            Location  = new Point(40, top),
            Size      = new Size(300, 28),
            Font      = new Font("Segoe UI", 8.5f),
            BackColor = Color.Transparent,
            ForeColor = Color.FromArgb(96, 165, 250),
            FlatStyle = FlatStyle.Flat,
            Cursor    = Cursors.Hand
        };
        btn.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
        btn.FlatAppearance.BorderSize  = 1;
        return btn;
    }
}
