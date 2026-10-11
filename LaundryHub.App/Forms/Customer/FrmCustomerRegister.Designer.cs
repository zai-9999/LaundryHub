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
        btnBack = new Button();
        btnRegister = new Button();
        lblError = new Label();
        txtAddress = new TextBox();
        lblAddress = new Label();
        txtEmail = new TextBox();
        lblEmail = new Label();
        txtConfirmPassword = new TextBox();
        lblConfirmPassword = new Label();
        txtPassword = new TextBox();
        lblPassword = new Label();
        txtUsername = new TextBox();
        lblUsername = new Label();
        txtPhone = new TextBox();
        lblPhone = new Label();
        txtFullName = new TextBox();
        lblFullName = new Label();
        lblSub = new Label();
        lblTitle = new Label();
        pnlCard.SuspendLayout();
        SuspendLayout();
        // 
        // pnlCard
        // 
        pnlCard.BackColor = Color.FromArgb(30, 41, 59);
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
        pnlCard.Location = new Point(40, 25);
        pnlCard.Name = "pnlCard";
        pnlCard.Padding = new Padding(24);
        pnlCard.Size = new Size(440, 660);
        pnlCard.TabIndex = 0;
        pnlCard.Paint += pnlCard_Paint;
        // 
        // btnBack
        // 
        btnBack.BackColor = Color.Transparent;
        btnBack.Cursor = Cursors.Hand;
        btnBack.FlatAppearance.BorderSize = 0;
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.ForeColor = Color.FromArgb(148, 163, 184);
        btnBack.Location = new Point(24, 606);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(390, 32);
        btnBack.TabIndex = 18;
        btnBack.Text = "← Back to Login";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        // 
        // btnRegister
        // 
        btnRegister.BackColor = Color.FromArgb(37, 99, 235);
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.FlatStyle = FlatStyle.Flat;
        btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnRegister.ForeColor = Color.White;
        btnRegister.Location = new Point(24, 560);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(390, 38);
        btnRegister.TabIndex = 17;
        btnRegister.Text = "✨ Create Account";
        btnRegister.UseVisualStyleBackColor = false;
        btnRegister.Click += btnRegister_Click;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(248, 113, 113);
        lblError.Location = new Point(24, 520);
        lblError.Name = "lblError";
        lblError.Size = new Size(390, 34);
        lblError.TabIndex = 16;
        lblError.Visible = false;
        // 
        // txtAddress
        // 
        txtAddress.BackColor = Color.FromArgb(15, 23, 42);
        txtAddress.BorderStyle = BorderStyle.FixedSingle;
        txtAddress.Font = new Font("Segoe UI", 10F);
        txtAddress.ForeColor = Color.White;
        txtAddress.Location = new Point(24, 460);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(390, 25);
        txtAddress.TabIndex = 15;
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("Segoe UI", 8.5F);
        lblAddress.ForeColor = Color.FromArgb(148, 163, 184);
        lblAddress.Location = new Point(24, 440);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(390, 18);
        lblAddress.TabIndex = 14;
        lblAddress.Text = "Home / Delivery Address (Optional)";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.FromArgb(15, 23, 42);
        txtEmail.BorderStyle = BorderStyle.FixedSingle;
        txtEmail.Font = new Font("Segoe UI", 10F);
        txtEmail.ForeColor = Color.White;
        txtEmail.Location = new Point(24, 400);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(390, 25);
        txtEmail.TabIndex = 13;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI", 8.5F);
        lblEmail.ForeColor = Color.FromArgb(148, 163, 184);
        lblEmail.Location = new Point(24, 380);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(390, 18);
        lblEmail.TabIndex = 12;
        lblEmail.Text = "Email Address (Optional)";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.BackColor = Color.FromArgb(15, 23, 42);
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
        txtConfirmPassword.Font = new Font("Segoe UI", 10F);
        txtConfirmPassword.ForeColor = Color.White;
        txtConfirmPassword.Location = new Point(24, 340);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.PasswordChar = '●';
        txtConfirmPassword.Size = new Size(390, 25);
        txtConfirmPassword.TabIndex = 11;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.Font = new Font("Segoe UI", 8.5F);
        lblConfirmPassword.ForeColor = Color.FromArgb(148, 163, 184);
        lblConfirmPassword.Location = new Point(24, 320);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(390, 18);
        lblConfirmPassword.TabIndex = 10;
        lblConfirmPassword.Text = "Confirm Password *";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.FromArgb(15, 23, 42);
        txtPassword.BorderStyle = BorderStyle.FixedSingle;
        txtPassword.Font = new Font("Segoe UI", 10F);
        txtPassword.ForeColor = Color.White;
        txtPassword.Location = new Point(24, 280);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new Size(390, 25);
        txtPassword.TabIndex = 9;
        // 
        // lblPassword
        // 
        lblPassword.Font = new Font("Segoe UI", 8.5F);
        lblPassword.ForeColor = Color.FromArgb(148, 163, 184);
        lblPassword.Location = new Point(24, 260);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(390, 18);
        lblPassword.TabIndex = 8;
        lblPassword.Text = "Password *";
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.FromArgb(15, 23, 42);
        txtUsername.BorderStyle = BorderStyle.FixedSingle;
        txtUsername.Font = new Font("Segoe UI", 10F);
        txtUsername.ForeColor = Color.White;
        txtUsername.Location = new Point(24, 220);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(390, 25);
        txtUsername.TabIndex = 7;
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("Segoe UI", 8.5F);
        lblUsername.ForeColor = Color.FromArgb(148, 163, 184);
        lblUsername.Location = new Point(24, 200);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(390, 18);
        lblUsername.TabIndex = 6;
        lblUsername.Text = "Username *";
        // 
        // txtPhone
        // 
        txtPhone.BackColor = Color.FromArgb(15, 23, 42);
        txtPhone.BorderStyle = BorderStyle.FixedSingle;
        txtPhone.Font = new Font("Segoe UI", 10F);
        txtPhone.ForeColor = Color.White;
        txtPhone.Location = new Point(24, 160);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(390, 25);
        txtPhone.TabIndex = 5;
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("Segoe UI", 8.5F);
        lblPhone.ForeColor = Color.FromArgb(148, 163, 184);
        lblPhone.Location = new Point(24, 140);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(390, 18);
        lblPhone.TabIndex = 4;
        lblPhone.Text = "Phone Number *";
        // 
        // txtFullName
        // 
        txtFullName.BackColor = Color.FromArgb(15, 23, 42);
        txtFullName.BorderStyle = BorderStyle.FixedSingle;
        txtFullName.Font = new Font("Segoe UI", 10F);
        txtFullName.ForeColor = Color.White;
        txtFullName.Location = new Point(24, 100);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(390, 25);
        txtFullName.TabIndex = 3;
        // 
        // lblFullName
        // 
        lblFullName.Font = new Font("Segoe UI", 8.5F);
        lblFullName.ForeColor = Color.FromArgb(148, 163, 184);
        lblFullName.Location = new Point(24, 80);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(390, 18);
        lblFullName.TabIndex = 2;
        lblFullName.Text = "Full Name *";
        // 
        // lblSub
        // 
        lblSub.Font = new Font("Segoe UI", 8.5F);
        lblSub.ForeColor = Color.FromArgb(148, 163, 184);
        lblSub.Location = new Point(24, 48);
        lblSub.Name = "lblSub";
        lblSub.Size = new Size(390, 20);
        lblSub.TabIndex = 1;
        lblSub.Text = "Track your laundry orders anytime from home";
        lblSub.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(96, 165, 250);
        lblTitle.Location = new Point(24, 15);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(390, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Create Customer Account";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FrmCustomerRegister
        // 
        AcceptButton = btnRegister;
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(520, 720);
        Controls.Add(pnlCard);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FrmCustomerRegister";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Create Customer Account";
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlCard;
    private Label lblTitle;
    private Label lblSub;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblPhone;
    private TextBox txtPhone;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private Label lblConfirmPassword;
    private TextBox txtConfirmPassword;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblAddress;
    private TextBox txtAddress;
    private Label lblError;
    private Button btnRegister;
    private Button btnBack;
}
