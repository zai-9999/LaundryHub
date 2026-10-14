using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;
using System.IO;

namespace LaundryHub.App.Forms.Auth;

partial class FrmLogin
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
        lnkForgotPassword = new LinkLabel();
        lblSeparator = new Label();
        btnSwitchToCustomer = new HopeButton();
        pnlCard.SuspendLayout();
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
        pnlCard.Controls.Add(lnkForgotPassword);
        pnlCard.Controls.Add(lblSeparator);
        pnlCard.Controls.Add(btnSwitchToCustomer);
        pnlCard.Location = new Point(399, 43);
        pnlCard.Margin = new Padding(3, 4, 3, 4);
        pnlCard.Name = "pnlCard";
        pnlCard.Size = new Size(445, 667);
        pnlCard.TabIndex = 0;
        pnlCard.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 445, 667, 40));
        pnlCard.Paint += pnlCard_Paint;
        // 
        // picLogo
        // 
        picLogo.BackgroundImageLayout = ImageLayout.Center;
        picLogo.Location = new Point(0, 30);
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
        lblTitle.Location = new Point(0, 99);
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
        lblSubtitle.Text = "Staff & Admin Portal";
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        lblSubtitle.Click += lblSubtitle_Click;
        // 
        // lblUser
        // 
        lblUser.AutoSize = true;
        lblUser.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblUser.ForeColor = Color.FromArgb(51, 104, 160);
        lblUser.Location = new Point(62, 212);
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
        txtUsername.Location = new Point(62, 236);
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
        lblPass.Location = new Point(62, 308);
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
        txtPassword.Location = new Point(62, 332);
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
        lblError.Location = new Point(62, 365);
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
        btnLogin.Location = new Point(62, 407);
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
        // lnkForgotPassword
        // 
        lnkForgotPassword.Font = new Font("Segoe UI", 8.5F);
        lnkForgotPassword.LinkColor = Color.FromArgb(102, 163, 191);
        lnkForgotPassword.Location = new Point(62, 464);
        lnkForgotPassword.Name = "lnkForgotPassword";
        lnkForgotPassword.Size = new Size(320, 27);
        lnkForgotPassword.TabIndex = 6;
        lnkForgotPassword.TabStop = true;
        lnkForgotPassword.Text = "Forgot password?";
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
        lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
        // 
        // lblSeparator
        // 
        lblSeparator.Font = new Font("Segoe UI", 8F);
        lblSeparator.ForeColor = Color.FromArgb(51, 104, 160);
        lblSeparator.Location = new Point(0, 508);
        lblSeparator.Name = "lblSeparator";
        lblSeparator.Size = new Size(445, 24);
        lblSeparator.TabIndex = 7;
        lblSeparator.Text = "──── Customer Access ────";
        lblSeparator.TextAlign = ContentAlignment.MiddleCenter;
        lblSeparator.Click += lblSeparator_Click;
        // 
        // btnSwitchToCustomer
        // 
        btnSwitchToCustomer.BorderColor = Color.FromArgb(102, 163, 191);
        btnSwitchToCustomer.ButtonType = HopeButtonType.Default;
        btnSwitchToCustomer.Cursor = Cursors.Hand;
        btnSwitchToCustomer.DangerColor = Color.FromArgb(245, 108, 108);
        btnSwitchToCustomer.DefaultColor = Color.FromArgb(200, 223, 219);
        btnSwitchToCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSwitchToCustomer.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnSwitchToCustomer.InfoColor = Color.FromArgb(144, 147, 153);
        btnSwitchToCustomer.Location = new Point(62, 536);
        btnSwitchToCustomer.Margin = new Padding(3, 4, 3, 4);
        btnSwitchToCustomer.Name = "btnSwitchToCustomer";
        btnSwitchToCustomer.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnSwitchToCustomer.Size = new Size(320, 53);
        btnSwitchToCustomer.SuccessColor = Color.FromArgb(103, 194, 58);
        btnSwitchToCustomer.TabIndex = 4;
        btnSwitchToCustomer.Text = "Switch to Customer Portal";
        btnSwitchToCustomer.TextColor = Color.FromArgb(51, 104, 160);
        btnSwitchToCustomer.WarningColor = Color.FromArgb(230, 162, 60);
        btnSwitchToCustomer.Click += btnSwitchToCustomer_Click;
        // 
        // FrmLogin
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(102, 163, 191);
        ClientSize = new Size(1100, 800);
        Controls.Add(pnlCard);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Staff & Admin Login";
        Load += FrmLogin_Load;
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel  pnlCard;
    private PictureBox    picLogo;
    private HopeTextBox   txtUsername;
    private HopeTextBox   txtPassword;
    private HopeButton    btnLogin;
    private HopeButton    btnSwitchToCustomer;
    private Label         lblTitle;
    private Label         lblSubtitle;
    private Label         lblUser;
    private Label         lblPass;
    private Label         lblError;
    private Label         lblSeparator;
    private LinkLabel     lnkForgotPassword;
}
