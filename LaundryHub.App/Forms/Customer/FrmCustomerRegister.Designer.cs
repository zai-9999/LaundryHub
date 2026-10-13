using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
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
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        pnlCard = new Panel();
        btnBack = new HopeButton();
        btnRegister = new HopeButton();
        lblError = new Label();
        txtAddress = new HopeTextBox();
        lblAddress = new Label();
        txtEmail = new HopeTextBox();
        lblEmail = new Label();
        txtConfirmPassword = new HopeTextBox();
        lblConfirmPassword = new Label();
        txtPassword = new HopeTextBox();
        lblPassword = new Label();
        txtUsername = new HopeTextBox();
        lblUsername = new Label();
        txtPhone = new HopeTextBox();
        lblPhone = new Label();
        txtFullName = new HopeTextBox();
        lblFullName = new Label();
        lblSub = new Label();
        lblTitle = new Label();
        pnlCard.SuspendLayout();
        SuspendLayout();
        // 
        // pnlCard
        // 
        pnlCard.BackColor = Color.White;
        pnlCard.Controls.Add(btnBack);
        pnlCard.Controls.Add(btnRegister);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(txtAddress);
        pnlCard.Controls.Add(lblAddress);
        pnlCard.Controls.Add(txtEmail);
        pnlCard.Controls.Add(lblEmail);
        pnlCard.Controls.Add(txtConfirmPassword);
        pnlCard.Controls.Add(lblConfirmPassword);
        pnlCard.Controls.Add(txtPassword);
        pnlCard.Controls.Add(lblPassword);
        pnlCard.Controls.Add(txtUsername);
        pnlCard.Controls.Add(lblUsername);
        pnlCard.Controls.Add(txtPhone);
        pnlCard.Controls.Add(lblPhone);
        pnlCard.Controls.Add(txtFullName);
        pnlCard.Controls.Add(lblFullName);
        pnlCard.Controls.Add(lblSub);
        pnlCard.Controls.Add(lblTitle);
        pnlCard.Location = new Point(40, 20);
        pnlCard.Name = "pnlCard";
        pnlCard.Padding = new Padding(24);
        pnlCard.Size = new Size(440, 680);
        pnlCard.TabIndex = 0;
        pnlCard.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 440, 680, 40));
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(51, 104, 160);
        lblTitle.Location = new Point(24, 12);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(390, 30);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Create Customer Account";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSub
        // 
        lblSub.Font = new Font("Segoe UI", 8.5F);
        lblSub.ForeColor = Color.FromArgb(102, 163, 191);
        lblSub.Location = new Point(24, 42);
        lblSub.Name = "lblSub";
        lblSub.Size = new Size(390, 20);
        lblSub.TabIndex = 1;
        lblSub.Text = "Track your laundry orders anytime from home";
        lblSub.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblFullName
        // 
        lblFullName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblFullName.ForeColor = Color.FromArgb(51, 104, 160);
        lblFullName.Location = new Point(24, 68);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(390, 16);
        lblFullName.TabIndex = 2;
        lblFullName.Text = "Full Name *";
        // 
        // txtFullName
        // 
        txtFullName.BackColor = Color.White;
        txtFullName.BaseColor = Color.FromArgb(242, 239, 231);
        txtFullName.BorderColorA = Color.FromArgb(102, 163, 191);
        txtFullName.BorderColorB = Color.FromArgb(200, 223, 219);
        txtFullName.Font = new Font("Segoe UI", 9.5F);
        txtFullName.ForeColor = Color.FromArgb(51, 104, 160);
        txtFullName.Hint = "Juan Dela Cruz";
        txtFullName.Location = new Point(24, 86);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(390, 32);
        txtFullName.TabIndex = 3;
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPhone.ForeColor = Color.FromArgb(51, 104, 160);
        lblPhone.Location = new Point(24, 122);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(390, 16);
        lblPhone.TabIndex = 4;
        lblPhone.Text = "Phone Number *";
        // 
        // txtPhone
        // 
        txtPhone.BackColor = Color.White;
        txtPhone.BaseColor = Color.FromArgb(242, 239, 231);
        txtPhone.BorderColorA = Color.FromArgb(102, 163, 191);
        txtPhone.BorderColorB = Color.FromArgb(200, 223, 219);
        txtPhone.Font = new Font("Segoe UI", 9.5F);
        txtPhone.ForeColor = Color.FromArgb(51, 104, 160);
        txtPhone.Hint = "09171234567";
        txtPhone.Location = new Point(24, 140);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(390, 32);
        txtPhone.TabIndex = 5;
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblUsername.ForeColor = Color.FromArgb(51, 104, 160);
        lblUsername.Location = new Point(24, 176);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(390, 16);
        lblUsername.TabIndex = 6;
        lblUsername.Text = "Username *";
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.White;
        txtUsername.BaseColor = Color.FromArgb(242, 239, 231);
        txtUsername.BorderColorA = Color.FromArgb(102, 163, 191);
        txtUsername.BorderColorB = Color.FromArgb(200, 223, 219);
        txtUsername.Font = new Font("Segoe UI", 9.5F);
        txtUsername.ForeColor = Color.FromArgb(51, 104, 160);
        txtUsername.Hint = "Choose a username";
        txtUsername.Location = new Point(24, 194);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(390, 32);
        txtUsername.TabIndex = 7;
        // 
        // lblPassword
        // 
        lblPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPassword.ForeColor = Color.FromArgb(51, 104, 160);
        lblPassword.Location = new Point(24, 230);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(390, 16);
        lblPassword.TabIndex = 8;
        lblPassword.Text = "Password *";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.White;
        txtPassword.BaseColor = Color.FromArgb(242, 239, 231);
        txtPassword.BorderColorA = Color.FromArgb(102, 163, 191);
        txtPassword.BorderColorB = Color.FromArgb(200, 223, 219);
        txtPassword.Font = new Font("Segoe UI", 9.5F);
        txtPassword.ForeColor = Color.FromArgb(51, 104, 160);
        txtPassword.Hint = "Min 6 characters";
        txtPassword.Location = new Point(24, 248);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.UseSystemPasswordChar = true;
        txtPassword.Size = new Size(390, 32);
        txtPassword.TabIndex = 9;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblConfirmPassword.ForeColor = Color.FromArgb(51, 104, 160);
        lblConfirmPassword.Location = new Point(24, 284);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(390, 16);
        lblConfirmPassword.TabIndex = 10;
        lblConfirmPassword.Text = "Confirm Password *";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.BackColor = Color.White;
        txtConfirmPassword.BaseColor = Color.FromArgb(242, 239, 231);
        txtConfirmPassword.BorderColorA = Color.FromArgb(102, 163, 191);
        txtConfirmPassword.BorderColorB = Color.FromArgb(200, 223, 219);
        txtConfirmPassword.Font = new Font("Segoe UI", 9.5F);
        txtConfirmPassword.ForeColor = Color.FromArgb(51, 104, 160);
        txtConfirmPassword.Hint = "Re-enter password";
        txtConfirmPassword.Location = new Point(24, 302);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.PasswordChar = '●';
        txtConfirmPassword.UseSystemPasswordChar = true;
        txtConfirmPassword.Size = new Size(390, 32);
        txtConfirmPassword.TabIndex = 11;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblEmail.ForeColor = Color.FromArgb(51, 104, 160);
        lblEmail.Location = new Point(24, 338);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(390, 16);
        lblEmail.TabIndex = 12;
        lblEmail.Text = "Email Address (Optional)";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.White;
        txtEmail.BaseColor = Color.FromArgb(242, 239, 231);
        txtEmail.BorderColorA = Color.FromArgb(102, 163, 191);
        txtEmail.BorderColorB = Color.FromArgb(200, 223, 219);
        txtEmail.Font = new Font("Segoe UI", 9.5F);
        txtEmail.ForeColor = Color.FromArgb(51, 104, 160);
        txtEmail.Hint = "user@example.com";
        txtEmail.Location = new Point(24, 356);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(390, 32);
        txtEmail.TabIndex = 13;
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAddress.ForeColor = Color.FromArgb(51, 104, 160);
        lblAddress.Location = new Point(24, 392);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(390, 16);
        lblAddress.TabIndex = 14;
        lblAddress.Text = "Home / Delivery Address (Optional)";
        // 
        // txtAddress
        // 
        txtAddress.BackColor = Color.White;
        txtAddress.BaseColor = Color.FromArgb(242, 239, 231);
        txtAddress.BorderColorA = Color.FromArgb(102, 163, 191);
        txtAddress.BorderColorB = Color.FromArgb(200, 223, 219);
        txtAddress.Font = new Font("Segoe UI", 9.5F);
        txtAddress.ForeColor = Color.FromArgb(51, 104, 160);
        txtAddress.Hint = "House No., Street, Barangay, City";
        txtAddress.Location = new Point(24, 410);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(390, 32);
        txtAddress.TabIndex = 15;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(220, 53, 69);
        lblError.Location = new Point(24, 448);
        lblError.Name = "lblError";
        lblError.Size = new Size(390, 28);
        lblError.TabIndex = 16;
        lblError.Visible = false;
        // 
        // btnRegister
        // 
        btnRegister.ButtonType = HopeButtonType.Primary;
        btnRegister.PrimaryColor = Color.FromArgb(51, 104, 160);
        btnRegister.TextColor = Color.FromArgb(242, 239, 231);
        btnRegister.HoverTextColor = Color.White;
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRegister.Location = new Point(24, 482);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(390, 40);
        btnRegister.TabIndex = 17;
        btnRegister.Text = "Create Account";
        btnRegister.Click += btnRegister_Click;
        // 
        // btnBack
        // 
        btnBack.ButtonType = HopeButtonType.Default;
        btnBack.DefaultColor = Color.FromArgb(200, 223, 219);
        btnBack.BorderColor = Color.FromArgb(102, 163, 191);
        btnBack.TextColor = Color.FromArgb(51, 104, 160);
        btnBack.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnBack.Cursor = Cursors.Hand;
        btnBack.Font = new Font("Segoe UI", 9F);
        btnBack.Location = new Point(24, 530);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(390, 36);
        btnBack.TabIndex = 18;
        btnBack.Text = "Back to Login";
        btnBack.Click += btnBack_Click;
        // 
        // FrmCustomerRegister
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(102, 163, 191);
        ClientSize = new Size(1100, 800);
        Controls.Add(pnlCard);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(51, 104, 160);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FrmCustomerRegister";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Create Customer Account";
        pnlCard.ResumeLayout(false);
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

