using Panel = System.Windows.Forms.Panel;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Customer;

partial class FrmCustomerRegister
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
        pnlCard = new Panel();
        lblTitle = new Label();
        lblSub = new Label();
        lblFullName = new Label();
        txtFullName = new HopeTextBox();
        lblPhone = new Label();
        txtPhone = new HopeTextBox();
        lblUsername = new Label();
        txtUsername = new HopeTextBox();
        lblPassword = new Label();
        txtPassword = new HopeTextBox();
        lblConfirmPassword = new Label();
        txtConfirmPassword = new HopeTextBox();
        lblEmail = new Label();
        txtEmail = new HopeTextBox();
        lblAddress = new Label();
        txtAddress = new HopeTextBox();
        lblError = new Label();
        btnRegister = new HopeButton();
        btnBack = new HopeButton();
        pnlCard.SuspendLayout();
        SuspendLayout();
        // 
        // pnlCard
        // 
        pnlCard.BackColor = Color.White;
        pnlCard.Controls.Add(lblTitle);
        pnlCard.Controls.Add(lblSub);
        pnlCard.Controls.Add(lblFullName);
        pnlCard.Controls.Add(txtFullName);
        pnlCard.Controls.Add(lblPhone);
        pnlCard.Controls.Add(txtPhone);
        pnlCard.Controls.Add(lblUsername);
        pnlCard.Controls.Add(txtUsername);
        pnlCard.Controls.Add(lblPassword);
        pnlCard.Controls.Add(txtPassword);
        pnlCard.Controls.Add(lblConfirmPassword);
        pnlCard.Controls.Add(txtConfirmPassword);
        pnlCard.Controls.Add(lblEmail);
        pnlCard.Controls.Add(txtEmail);
        pnlCard.Controls.Add(lblAddress);
        pnlCard.Controls.Add(txtAddress);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(btnRegister);
        pnlCard.Controls.Add(btnBack);
        pnlCard.Location = new Point(327, 42);
        pnlCard.Name = "pnlCard";
        pnlCard.Size = new Size(445, 715);
        pnlCard.TabIndex = 0;
        pnlCard.Paint += pnlCard_Paint;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(75, 86, 148);
        lblTitle.Location = new Point(0, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(445, 40);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "LaundryHub";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSub
        // 
        lblSub.Font = new Font("Segoe UI", 9F);
        lblSub.ForeColor = Color.FromArgb(114, 136, 174);
        lblSub.Location = new Point(0, 60);
        lblSub.Name = "lblSub";
        lblSub.Size = new Size(445, 22);
        lblSub.TabIndex = 2;
        lblSub.Text = "Create Customer Account";
        lblSub.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblFullName
        // 
        lblFullName.AutoSize = true;
        lblFullName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblFullName.ForeColor = Color.FromArgb(75, 86, 148);
        lblFullName.Location = new Point(62, 90);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(80, 20);
        lblFullName.TabIndex = 3;
        lblFullName.Text = "Full Name";
        // 
        // txtFullName
        // 
        txtFullName.BackColor = Color.White;
        txtFullName.BaseColor = Color.White;
        txtFullName.BorderColorA = Color.FromArgb(75, 86, 148);
        txtFullName.BorderColorB = Color.FromArgb(190, 196, 220);
        txtFullName.Font = new Font("Segoe UI", 10F);
        txtFullName.ForeColor = Color.FromArgb(75, 86, 148);
        txtFullName.Hint = "Enter full name";
        txtFullName.Location = new Point(62, 110);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(320, 36);
        txtFullName.TabIndex = 1;
        // 
        // lblPhone
        // 
        lblPhone.AutoSize = true;
        lblPhone.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPhone.ForeColor = Color.FromArgb(75, 86, 148);
        lblPhone.Location = new Point(62, 150);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(50, 20);
        lblPhone.TabIndex = 4;
        lblPhone.Text = "Phone";
        // 
        // txtPhone
        // 
        txtPhone.BackColor = Color.White;
        txtPhone.BaseColor = Color.White;
        txtPhone.BorderColorA = Color.FromArgb(75, 86, 148);
        txtPhone.BorderColorB = Color.FromArgb(190, 196, 220);
        txtPhone.Font = new Font("Segoe UI", 10F);
        txtPhone.ForeColor = Color.FromArgb(75, 86, 148);
        txtPhone.Hint = "09171234567";
        txtPhone.Location = new Point(62, 170);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(320, 36);
        txtPhone.TabIndex = 2;
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblUsername.ForeColor = Color.FromArgb(75, 86, 148);
        lblUsername.Location = new Point(62, 210);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(80, 20);
        lblUsername.TabIndex = 5;
        lblUsername.Text = "Username";
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.White;
        txtUsername.BaseColor = Color.White;
        txtUsername.BorderColorA = Color.FromArgb(75, 86, 148);
        txtUsername.BorderColorB = Color.FromArgb(190, 196, 220);
        txtUsername.Font = new Font("Segoe UI", 10F);
        txtUsername.ForeColor = Color.FromArgb(75, 86, 148);
        txtUsername.Hint = "Choose a username";
        txtUsername.Location = new Point(62, 230);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(320, 36);
        txtUsername.TabIndex = 3;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPassword.ForeColor = Color.FromArgb(75, 86, 148);
        lblPassword.Location = new Point(62, 270);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(76, 20);
        lblPassword.TabIndex = 6;
        lblPassword.Text = "Password";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.White;
        txtPassword.BaseColor = Color.White;
        txtPassword.BorderColorA = Color.FromArgb(75, 86, 148);
        txtPassword.BorderColorB = Color.FromArgb(190, 196, 220);
        txtPassword.Font = new Font("Segoe UI", 10F);
        txtPassword.ForeColor = Color.FromArgb(75, 86, 148);
        txtPassword.Hint = "Min 6 characters";
        txtPassword.Location = new Point(62, 290);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '\0';
        txtPassword.Size = new Size(320, 36);
        txtPassword.TabIndex = 4;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.AutoSize = true;
        lblConfirmPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblConfirmPassword.ForeColor = Color.FromArgb(75, 86, 148);
        lblConfirmPassword.Location = new Point(62, 330);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(140, 20);
        lblConfirmPassword.TabIndex = 7;
        lblConfirmPassword.Text = "Confirm Password";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.BackColor = Color.White;
        txtConfirmPassword.BaseColor = Color.White;
        txtConfirmPassword.BorderColorA = Color.FromArgb(75, 86, 148);
        txtConfirmPassword.BorderColorB = Color.FromArgb(190, 196, 220);
        txtConfirmPassword.Font = new Font("Segoe UI", 10F);
        txtConfirmPassword.ForeColor = Color.FromArgb(75, 86, 148);
        txtConfirmPassword.Hint = "Re-enter password";
        txtConfirmPassword.Location = new Point(62, 350);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.PasswordChar = '\0';
        txtConfirmPassword.Size = new Size(320, 36);
        txtConfirmPassword.TabIndex = 5;
        txtConfirmPassword.UseSystemPasswordChar = true;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblEmail.ForeColor = Color.FromArgb(75, 86, 148);
        lblEmail.Location = new Point(62, 390);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(160, 20);
        lblEmail.TabIndex = 8;
        lblEmail.Text = "Email (optional)";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.White;
        txtEmail.BaseColor = Color.White;
        txtEmail.BorderColorA = Color.FromArgb(75, 86, 148);
        txtEmail.BorderColorB = Color.FromArgb(190, 196, 220);
        txtEmail.Font = new Font("Segoe UI", 10F);
        txtEmail.ForeColor = Color.FromArgb(75, 86, 148);
        txtEmail.Hint = "user@example.com";
        txtEmail.Location = new Point(62, 410);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(320, 36);
        txtEmail.TabIndex = 6;
        // 
        // lblAddress
        // 
        lblAddress.AutoSize = true;
        lblAddress.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAddress.ForeColor = Color.FromArgb(75, 86, 148);
        lblAddress.Location = new Point(62, 450);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(180, 20);
        lblAddress.TabIndex = 9;
        lblAddress.Text = "Address (optional)";
        // 
        // txtAddress
        // 
        txtAddress.BackColor = Color.White;
        txtAddress.BaseColor = Color.White;
        txtAddress.BorderColorA = Color.FromArgb(75, 86, 148);
        txtAddress.BorderColorB = Color.FromArgb(190, 196, 220);
        txtAddress.Font = new Font("Segoe UI", 10F);
        txtAddress.ForeColor = Color.FromArgb(75, 86, 148);
        txtAddress.Hint = "House No., Street, City";
        txtAddress.Location = new Point(62, 470);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(320, 36);
        txtAddress.TabIndex = 7;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(184, 72, 88);
        lblError.Location = new Point(62, 508);
        lblError.Name = "lblError";
        lblError.Size = new Size(320, 22);
        lblError.TabIndex = 10;
        lblError.TextAlign = ContentAlignment.MiddleCenter;
        lblError.Visible = false;
        // 
        // btnRegister
        // 
        btnRegister.BorderColor = Color.FromArgb(114, 136, 174);
        btnRegister.ButtonType = HopeButtonType.Primary;
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRegister.HoverTextColor = Color.White;
        btnRegister.Location = new Point(62, 534);
        btnRegister.Name = "btnRegister";
        btnRegister.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnRegister.Size = new Size(320, 53);
        btnRegister.TabIndex = 8;
        btnRegister.Text = "Create Account";
        btnRegister.TextColor = Color.White;
        btnRegister.Click += btnRegister_Click;
        // 
        // btnBack
        // 
        btnBack.BorderColor = Color.FromArgb(114, 136, 174);
        btnBack.ButtonType = HopeButtonType.Default;
        btnBack.Cursor = Cursors.Hand;
        btnBack.DefaultColor = Color.FromArgb(234, 224, 207);
        btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnBack.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnBack.Location = new Point(62, 594);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(320, 53);
        btnBack.TabIndex = 9;
        btnBack.Text = "Back to Login";
        btnBack.TextColor = Color.FromArgb(75, 86, 148);
        btnBack.Click += btnBack_Click;
        // 
        // FrmCustomerRegister
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(114, 136, 174);
        ClientSize = new Size(1100, 800);
        Controls.Add(pnlCard);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        Name = "FrmCustomerRegister";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub  Create Customer Account";
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlCard;
    private Label lblTitle;
    private Label lblSub;
    private Label lblFullName;
    private HopeTextBox txtFullName;
    private Label lblPhone;
    private HopeTextBox txtPhone;
    private Label lblUsername;
    private HopeTextBox txtUsername;
    private Label lblPassword;
    private HopeTextBox txtPassword;
    private Label lblConfirmPassword;
    private HopeTextBox txtConfirmPassword;
    private Label lblEmail;
    private HopeTextBox txtEmail;
    private Label lblAddress;
    private HopeTextBox txtAddress;
    private Label lblError;
    private HopeButton btnRegister;
    private HopeButton btnBack;
}
