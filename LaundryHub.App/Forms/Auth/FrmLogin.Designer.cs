namespace LaundryHub.App.Forms.Auth;

partial class FrmLogin
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        pnlCard = new Panel();
        btnCustomerRegister = new Button();
        btnGuestLookup = new Button();
        lblSeparator = new Label();
        lnkForgotPassword = new LinkLabel();
        btnLogin = new Button();
        lblError = new Label();
        txtPassword = new TextBox();
        lblPass = new Label();
        txtUsername = new TextBox();
        lblUser = new Label();
        lblSubtitle = new Label();
        lblTitle = new Label();
        lblLogo = new Label();
        pnlCard.SuspendLayout();
        SuspendLayout();
        // 
        // pnlCard
        // 
        pnlCard.BackColor = Color.FromArgb(30, 41, 59);
        pnlCard.Controls.Add(btnCustomerRegister);
        pnlCard.Controls.Add(btnGuestLookup);
        pnlCard.Controls.Add(lblSeparator);
        pnlCard.Controls.Add(lnkForgotPassword);
        pnlCard.Controls.Add(btnLogin);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(txtPassword);
        pnlCard.Controls.Add(lblPass);
        pnlCard.Controls.Add(txtUsername);
        pnlCard.Controls.Add(lblUser);
        pnlCard.Controls.Add(lblSubtitle);
        pnlCard.Controls.Add(lblTitle);
        pnlCard.Controls.Add(lblLogo);
        pnlCard.Location = new Point(50, 40);
        pnlCard.Name = "pnlCard";
        pnlCard.Size = new Size(380, 475);
        pnlCard.TabIndex = 0;
        pnlCard.Paint += pnlCard_Paint;
        // 
        // btnCustomerRegister
        // 
        btnCustomerRegister.Cursor = Cursors.Hand;
        btnCustomerRegister.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
        btnCustomerRegister.FlatStyle = FlatStyle.Flat;
        btnCustomerRegister.Font = new Font("Segoe UI", 8.5F);
        btnCustomerRegister.ForeColor = Color.FromArgb(96, 165, 250);
        btnCustomerRegister.Location = new Point(40, 432);
        btnCustomerRegister.Name = "btnCustomerRegister";
        btnCustomerRegister.Size = new Size(300, 28);
        btnCustomerRegister.TabIndex = 12;
        btnCustomerRegister.Text = "📝  Register as Customer";
        btnCustomerRegister.UseVisualStyleBackColor = false;
        btnCustomerRegister.Click += btnCustomerRegister_Click;
        // 
        // btnGuestLookup
        // 
        btnGuestLookup.Cursor = Cursors.Hand;
        btnGuestLookup.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
        btnGuestLookup.FlatStyle = FlatStyle.Flat;
        btnGuestLookup.Font = new Font("Segoe UI", 8.5F);
        btnGuestLookup.ForeColor = Color.FromArgb(96, 165, 250);
        btnGuestLookup.Location = new Point(40, 398);
        btnGuestLookup.Name = "btnGuestLookup";
        btnGuestLookup.Size = new Size(300, 28);
        btnGuestLookup.TabIndex = 11;
        btnGuestLookup.Text = "🔍  Check Order Status (Guest)";
        btnGuestLookup.UseVisualStyleBackColor = false;
        btnGuestLookup.Click += btnGuestLookup_Click;
        // 
        // lblSeparator
        // 
        lblSeparator.Font = new Font("Segoe UI", 8F);
        lblSeparator.ForeColor = Color.FromArgb(71, 85, 105);
        lblSeparator.Location = new Point(40, 374);
        lblSeparator.Name = "lblSeparator";
        lblSeparator.Size = new Size(300, 18);
        lblSeparator.TabIndex = 10;
        lblSeparator.Text = "──── or ────";
        lblSeparator.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lnkForgotPassword
        // 
        lnkForgotPassword.Font = new Font("Segoe UI", 8.5F);
        lnkForgotPassword.LinkColor = Color.FromArgb(96, 165, 250);
        lnkForgotPassword.Location = new Point(120, 348);
        lnkForgotPassword.Name = "lnkForgotPassword";
        lnkForgotPassword.Size = new Size(140, 20);
        lnkForgotPassword.TabIndex = 9;
        lnkForgotPassword.TabStop = true;
        lnkForgotPassword.Text = "Forgot password?";
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
        lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = Color.FromArgb(37, 99, 235);
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        btnLogin.ForeColor = Color.White;
        btnLogin.Location = new Point(40, 305);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(300, 38);
        btnLogin.TabIndex = 8;
        btnLogin.Text = "Sign In";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += btnLogin_Click;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(248, 113, 113);
        lblError.Location = new Point(40, 282);
        lblError.Name = "lblError";
        lblError.Size = new Size(300, 18);
        lblError.TabIndex = 7;
        lblError.TextAlign = ContentAlignment.MiddleLeft;
        lblError.Visible = false;
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.FromArgb(15, 23, 42);
        txtPassword.BorderStyle = BorderStyle.FixedSingle;
        txtPassword.Font = new Font("Segoe UI", 11F);
        txtPassword.ForeColor = Color.White;
        txtPassword.Location = new Point(40, 240);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new Size(300, 27);
        txtPassword.TabIndex = 6;
        // 
        // lblPass
        // 
        lblPass.AutoSize = true;
        lblPass.Font = new Font("Segoe UI", 8.5F);
        lblPass.ForeColor = Color.FromArgb(148, 163, 184);
        lblPass.Location = new Point(40, 218);
        lblPass.Name = "lblPass";
        lblPass.Size = new Size(57, 15);
        lblPass.TabIndex = 5;
        lblPass.Text = "Password";
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.FromArgb(15, 23, 42);
        txtUsername.BorderStyle = BorderStyle.FixedSingle;
        txtUsername.Font = new Font("Segoe UI", 11F);
        txtUsername.ForeColor = Color.White;
        txtUsername.Location = new Point(40, 170);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(300, 27);
        txtUsername.TabIndex = 4;
        // 
        // lblUser
        // 
        lblUser.AutoSize = true;
        lblUser.Font = new Font("Segoe UI", 8.5F);
        lblUser.ForeColor = Color.FromArgb(148, 163, 184);
        lblUser.Location = new Point(40, 148);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(60, 15);
        lblUser.TabIndex = 3;
        lblUser.Text = "Username";
        // 
        // lblSubtitle
        // 
        lblSubtitle.Font = new Font("Segoe UI", 9F);
        lblSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblSubtitle.Location = new Point(0, 112);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(380, 20);
        lblSubtitle.TabIndex = 2;
        lblSubtitle.Text = "Laundry Order & Tracking System";
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(96, 165, 250);
        lblTitle.Location = new Point(0, 74);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(380, 36);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "LaundryHub";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblLogo
        // 
        lblLogo.Font = new Font("Segoe UI Emoji", 32F);
        lblLogo.ForeColor = Color.White;
        lblLogo.Location = new Point(0, 15);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(380, 55);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "🧺";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FrmLogin
        // 
        AcceptButton = btnLogin;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(480, 560);
        Controls.Add(pnlCard);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Login";
        Load += FrmLogin_Load;
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlCard;
    private Label lblLogo;
    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblUser;
    private TextBox txtUsername;
    private Label lblPass;
    private TextBox txtPassword;
    private Label lblError;
    private Button btnLogin;
    private LinkLabel lnkForgotPassword;
    private Label lblSeparator;
    private Button btnGuestLookup;
    private Button btnCustomerRegister;
}
