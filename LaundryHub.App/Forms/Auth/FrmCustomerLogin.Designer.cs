using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;
using System.IO;

namespace LaundryHub.App.Forms.Auth;

partial class FrmCustomerLogin
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        pnlCard = new System.Windows.Forms.Panel();
        picLogo = new PictureBox();
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblUser = new Label();
        txtUsername = new HopeTextBox();
        lblPass = new Label();
        txtPassword = new HopeTextBox();
        lblError = new Label();
        btnLogin = new HopeButton();
        lblSeparator = new Label();
        btnRegister = new HopeButton();
        btnPricing = new HopeButton();
        btnGuestLookup = new HopeButton();
        btnSwitchToStaff = new HopeButton();
        pnlCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
        SuspendLayout();
        // 
        // pnlCard
        // 
        pnlCard.BackColor = Color.White;
        pnlCard.Controls.Add(picLogo);
        pnlCard.Controls.Add(lblTitle);
        pnlCard.Controls.Add(lblSubtitle);
        pnlCard.Controls.Add(lblUser);
        pnlCard.Controls.Add(txtUsername);
        pnlCard.Controls.Add(lblPass);
        pnlCard.Controls.Add(txtPassword);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(btnLogin);
        pnlCard.Controls.Add(lblSeparator);
        pnlCard.Controls.Add(btnRegister);
        pnlCard.Controls.Add(btnPricing);
        pnlCard.Controls.Add(btnGuestLookup);
        pnlCard.Controls.Add(btnSwitchToStaff);
        pnlCard.Location = new Point(301, 34);
        pnlCard.Margin = new Padding(3, 4, 3, 4);
        pnlCard.Name = "pnlCard";
        pnlCard.Size = new Size(445, 715);
        pnlCard.TabIndex = 0;
        pnlCard.Paint += pnlCard_Paint;
        // 
        // picLogo
        // 
        picLogo.BackgroundImageLayout = ImageLayout.Center;
        picLogo.Location = new Point(0, 24);
        picLogo.Name = "picLogo";
        picLogo.Size = new Size(445, 69);
        picLogo.SizeMode = PictureBoxSizeMode.Zoom;
        picLogo.TabIndex = 0;
        picLogo.TabStop = false;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(51, 104, 160);
        lblTitle.Location = new Point(0, 96);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(445, 48);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "LaundryHub";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitle
        // 
        lblSubtitle.Font = new Font("Segoe UI", 9F);
        lblSubtitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblSubtitle.Location = new Point(0, 147);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(445, 27);
        lblSubtitle.TabIndex = 2;
        lblSubtitle.Text = "Customer Portal";
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblUser
        // 
        lblUser.AutoSize = true;
        lblUser.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblUser.ForeColor = Color.FromArgb(51, 104, 160);
        lblUser.Location = new Point(62, 195);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(80, 20);
        lblUser.TabIndex = 3;
        lblUser.Text = "Username";
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.White;
        txtUsername.BaseColor = Color.White;
        txtUsername.BorderColorA = Color.FromArgb(102, 163, 191);
        txtUsername.BorderColorB = Color.FromArgb(200, 223, 219);
        txtUsername.Font = new Font("Segoe UI", 10F);
        txtUsername.ForeColor = Color.FromArgb(51, 104, 160);
        txtUsername.Hint = "Enter username";
        txtUsername.Location = new Point(62, 221);
        txtUsername.Margin = new Padding(3, 4, 3, 4);
        txtUsername.MaxLength = 32767;
        txtUsername.Multiline = false;
        txtUsername.Name = "txtUsername";
        txtUsername.PasswordChar = '\0';
        txtUsername.ScrollBars = ScrollBars.None;
        txtUsername.SelectedText = "";
        txtUsername.SelectionLength = 0;
        txtUsername.SelectionStart = 0;
        txtUsername.Size = new Size(320, 39);
        txtUsername.TabIndex = 1;
        txtUsername.TabStop = false;
        txtUsername.UseSystemPasswordChar = false;
        // 
        // lblPass
        // 
        lblPass.AutoSize = true;
        lblPass.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPass.ForeColor = Color.FromArgb(51, 104, 160);
        lblPass.Location = new Point(62, 283);
        lblPass.Name = "lblPass";
        lblPass.Size = new Size(76, 20);
        lblPass.TabIndex = 4;
        lblPass.Text = "Password";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.White;
        txtPassword.BaseColor = Color.White;
        txtPassword.BorderColorA = Color.FromArgb(102, 163, 191);
        txtPassword.BorderColorB = Color.FromArgb(200, 223, 219);
        txtPassword.Font = new Font("Segoe UI", 10F);
        txtPassword.ForeColor = Color.FromArgb(51, 104, 160);
        txtPassword.Hint = "Enter password";
        txtPassword.Location = new Point(62, 309);
        txtPassword.Margin = new Padding(3, 4, 3, 4);
        txtPassword.MaxLength = 32767;
        txtPassword.Multiline = false;
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.ScrollBars = ScrollBars.None;
        txtPassword.SelectedText = "";
        txtPassword.SelectionLength = 0;
        txtPassword.SelectionStart = 0;
        txtPassword.Size = new Size(320, 39);
        txtPassword.TabIndex = 2;
        txtPassword.TabStop = false;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(220, 53, 69);
        lblError.Location = new Point(62, 355);
        lblError.Name = "lblError";
        lblError.Size = new Size(320, 24);
        lblError.TabIndex = 5;
        lblError.TextAlign = ContentAlignment.MiddleCenter;
        lblError.Visible = false;
        // 
        // btnLogin
        // 
        btnLogin.BorderColor = Color.FromArgb(220, 223, 230);
        btnLogin.ButtonType = HopeButtonType.Primary;
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.DangerColor = Color.FromArgb(245, 108, 108);
        btnLogin.DefaultColor = Color.FromArgb(255, 255, 255);
        btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLogin.HoverTextColor = Color.White;
        btnLogin.InfoColor = Color.FromArgb(144, 147, 153);
        btnLogin.Location = new Point(62, 387);
        btnLogin.Margin = new Padding(3, 4, 3, 4);
        btnLogin.Name = "btnLogin";
        btnLogin.PrimaryColor = Color.FromArgb(51, 104, 160);
        btnLogin.Size = new Size(320, 53);
        btnLogin.SuccessColor = Color.FromArgb(103, 194, 58);
        btnLogin.TabIndex = 3;
        btnLogin.Text = "Sign In";
        btnLogin.TextColor = Color.White;
        btnLogin.WarningColor = Color.FromArgb(230, 162, 60);
        btnLogin.Click += btnLogin_Click;
        // 
        // lblSeparator
        // 
        lblSeparator.Font = new Font("Segoe UI", 8F);
        lblSeparator.ForeColor = Color.FromArgb(51, 104, 160);
        lblSeparator.Location = new Point(0, 450);
        lblSeparator.Name = "lblSeparator";
        lblSeparator.Size = new Size(445, 24);
        lblSeparator.TabIndex = 6;
        lblSeparator.Text = "──── or ────";
        lblSeparator.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnRegister
        // 
        btnRegister.BorderColor = Color.FromArgb(102, 163, 191);
        btnRegister.ButtonType = HopeButtonType.Default;
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.DangerColor = Color.FromArgb(245, 108, 108);
        btnRegister.DefaultColor = Color.FromArgb(200, 223, 219);
        btnRegister.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnRegister.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnRegister.InfoColor = Color.FromArgb(144, 147, 153);
        btnRegister.Location = new Point(62, 475);
        btnRegister.Margin = new Padding(3, 4, 3, 4);
        btnRegister.Name = "btnRegister";
        btnRegister.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnRegister.Size = new Size(320, 48);
        btnRegister.SuccessColor = Color.FromArgb(103, 194, 58);
        btnRegister.TabIndex = 4;
        btnRegister.Text = "Register as Customer";
        btnRegister.TextColor = Color.FromArgb(51, 104, 160);
        btnRegister.WarningColor = Color.FromArgb(230, 162, 60);
        btnRegister.Click += btnRegister_Click;
        // 
        // btnPricing
        // 
        btnPricing.BorderColor = Color.FromArgb(102, 163, 191);
        btnPricing.ButtonType = HopeButtonType.Default;
        btnPricing.Cursor = Cursors.Hand;
        btnPricing.DangerColor = Color.FromArgb(245, 108, 108);
        btnPricing.DefaultColor = Color.FromArgb(242, 239, 231);
        btnPricing.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnPricing.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnPricing.InfoColor = Color.FromArgb(144, 147, 153);
        btnPricing.Location = new Point(62, 530);
        btnPricing.Margin = new Padding(3, 4, 3, 4);
        btnPricing.Name = "btnPricing";
        btnPricing.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnPricing.Size = new Size(320, 48);
        btnPricing.SuccessColor = Color.FromArgb(103, 194, 58);
        btnPricing.TabIndex = 5;
        btnPricing.Text = "View Services & Pricing";
        btnPricing.TextColor = Color.FromArgb(51, 104, 160);
        btnPricing.WarningColor = Color.FromArgb(230, 162, 60);
        btnPricing.Click += btnPricing_Click;
        // 
        // btnGuestLookup
        // 
        btnGuestLookup.BorderColor = Color.FromArgb(102, 163, 191);
        btnGuestLookup.ButtonType = HopeButtonType.Default;
        btnGuestLookup.Cursor = Cursors.Hand;
        btnGuestLookup.DangerColor = Color.FromArgb(245, 108, 108);
        btnGuestLookup.DefaultColor = Color.FromArgb(200, 223, 219);
        btnGuestLookup.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnGuestLookup.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnGuestLookup.InfoColor = Color.FromArgb(144, 147, 153);
        btnGuestLookup.Location = new Point(62, 585);
        btnGuestLookup.Margin = new Padding(3, 4, 3, 4);
        btnGuestLookup.Name = "btnGuestLookup";
        btnGuestLookup.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnGuestLookup.Size = new Size(320, 48);
        btnGuestLookup.SuccessColor = Color.FromArgb(103, 194, 58);
        btnGuestLookup.TabIndex = 6;
        btnGuestLookup.Text = "Check Order Status (No Account)";
        btnGuestLookup.TextColor = Color.FromArgb(51, 104, 160);
        btnGuestLookup.WarningColor = Color.FromArgb(230, 162, 60);
        btnGuestLookup.Click += btnGuestLookup_Click;
        // 
        // btnSwitchToStaff
        // 
        btnSwitchToStaff.BorderColor = Color.FromArgb(102, 163, 191);
        btnSwitchToStaff.ButtonType = HopeButtonType.Default;
        btnSwitchToStaff.Cursor = Cursors.Hand;
        btnSwitchToStaff.DangerColor = Color.FromArgb(245, 108, 108);
        btnSwitchToStaff.DefaultColor = Color.FromArgb(200, 223, 219);
        btnSwitchToStaff.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSwitchToStaff.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnSwitchToStaff.InfoColor = Color.FromArgb(144, 147, 153);
        btnSwitchToStaff.Location = new Point(62, 640);
        btnSwitchToStaff.Margin = new Padding(3, 4, 3, 4);
        btnSwitchToStaff.Name = "btnSwitchToStaff";
        btnSwitchToStaff.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnSwitchToStaff.Size = new Size(320, 48);
        btnSwitchToStaff.SuccessColor = Color.FromArgb(103, 194, 58);
        btnSwitchToStaff.TabIndex = 7;
        btnSwitchToStaff.Text = "Switch to Staff / Admin Portal";
        btnSwitchToStaff.TextColor = Color.FromArgb(51, 104, 160);
        btnSwitchToStaff.WarningColor = Color.FromArgb(230, 162, 60);
        btnSwitchToStaff.Click += btnSwitchToStaff_Click;
        // 
        // FrmCustomerLogin
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(102, 163, 191);
        ClientSize = new Size(1100, 800);
        Controls.Add(pnlCard);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        Name = "FrmCustomerLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Customer Portal";
        Load += FrmCustomerLogin_Load;
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel  pnlCard;
    private PictureBox    picLogo;
    private HopeTextBox   txtUsername;
    private HopeTextBox   txtPassword;
    private HopeButton    btnLogin;
    private HopeButton    btnRegister;
    private HopeButton    btnPricing;
    private HopeButton    btnGuestLookup;
    private HopeButton    btnSwitchToStaff;
    private Label         lblTitle;
    private Label         lblSubtitle;
    private Label         lblUser;
    private Label         lblPass;
    private Label         lblError;
    private Label         lblSeparator;
}
