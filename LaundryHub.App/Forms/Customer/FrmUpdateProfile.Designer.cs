namespace LaundryHub.App.Forms.Customer;

partial class FrmUpdateProfile
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
        pnlMain = new Panel();
        btnCancel = new Button();
        btnSave = new Button();
        lblError = new Label();
        txtNewPassword = new TextBox();
        lblNewPassword = new Label();
        txtAddress = new TextBox();
        lblAddress = new Label();
        txtEmail = new TextBox();
        lblEmail = new Label();
        txtPhone = new TextBox();
        lblPhone = new Label();
        txtFullName = new TextBox();
        lblFullName = new Label();
        lblTitle = new Label();
        pnlMain.SuspendLayout();
        SuspendLayout();
        // 
        // pnlMain
        // 
        pnlMain.BackColor = Color.FromArgb(30, 41, 59);
        pnlMain.Controls.Add(btnCancel);
        pnlMain.Controls.Add(btnSave);
        pnlMain.Controls.Add(lblError);
        pnlMain.Controls.Add(txtNewPassword);
        pnlMain.Controls.Add(lblNewPassword);
        pnlMain.Controls.Add(txtAddress);
        pnlMain.Controls.Add(lblAddress);
        pnlMain.Controls.Add(txtEmail);
        pnlMain.Controls.Add(lblEmail);
        pnlMain.Controls.Add(txtPhone);
        pnlMain.Controls.Add(lblPhone);
        pnlMain.Controls.Add(txtFullName);
        pnlMain.Controls.Add(lblFullName);
        pnlMain.Controls.Add(lblTitle);
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(0, 0);
        pnlMain.Name = "pnlMain";
        pnlMain.Padding = new Padding(24);
        pnlMain.Size = new Size(460, 520);
        pnlMain.TabIndex = 0;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = Color.FromArgb(51, 65, 85);
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.ForeColor = Color.White;
        btnCancel.Location = new Point(224, 445);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(190, 38);
        btnCancel.TabIndex = 14;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.Cursor = Cursors.Hand;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(24, 445);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(190, 38);
        btnSave.TabIndex = 13;
        btnSave.Text = "💾 Save Changes";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(248, 113, 113);
        lblError.Location = new Point(24, 410);
        lblError.Name = "lblError";
        lblError.Size = new Size(390, 26);
        lblError.TabIndex = 12;
        lblError.Visible = false;
        // 
        // txtNewPassword
        // 
        txtNewPassword.BackColor = Color.FromArgb(15, 23, 42);
        txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
        txtNewPassword.Font = new Font("Segoe UI", 10F);
        txtNewPassword.ForeColor = Color.White;
        txtNewPassword.Location = new Point(24, 370);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.PasswordChar = '●';
        txtNewPassword.Size = new Size(390, 25);
        txtNewPassword.TabIndex = 11;
        // 
        // lblNewPassword
        // 
        lblNewPassword.Font = new Font("Segoe UI", 8.5F);
        lblNewPassword.ForeColor = Color.FromArgb(148, 163, 184);
        lblNewPassword.Location = new Point(24, 350);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Size = new Size(390, 18);
        lblNewPassword.TabIndex = 10;
        lblNewPassword.Text = "Change Password (leave blank to keep current)";
        // 
        // txtAddress
        // 
        txtAddress.BackColor = Color.FromArgb(15, 23, 42);
        txtAddress.BorderStyle = BorderStyle.FixedSingle;
        txtAddress.Font = new Font("Segoe UI", 10F);
        txtAddress.ForeColor = Color.White;
        txtAddress.Location = new Point(24, 310);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(390, 25);
        txtAddress.TabIndex = 9;
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("Segoe UI", 8.5F);
        lblAddress.ForeColor = Color.FromArgb(148, 163, 184);
        lblAddress.Location = new Point(24, 290);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(390, 18);
        lblAddress.TabIndex = 8;
        lblAddress.Text = "Home / Delivery Address";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.FromArgb(15, 23, 42);
        txtEmail.BorderStyle = BorderStyle.FixedSingle;
        txtEmail.Font = new Font("Segoe UI", 10F);
        txtEmail.ForeColor = Color.White;
        txtEmail.Location = new Point(24, 250);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(390, 25);
        txtEmail.TabIndex = 7;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI", 8.5F);
        lblEmail.ForeColor = Color.FromArgb(148, 163, 184);
        lblEmail.Location = new Point(24, 230);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(390, 18);
        lblEmail.TabIndex = 6;
        lblEmail.Text = "Email Address";
        // 
        // txtPhone
        // 
        txtPhone.BackColor = Color.FromArgb(15, 23, 42);
        txtPhone.BorderStyle = BorderStyle.FixedSingle;
        txtPhone.Font = new Font("Segoe UI", 10F);
        txtPhone.ForeColor = Color.White;
        txtPhone.Location = new Point(24, 190);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(390, 25);
        txtPhone.TabIndex = 5;
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("Segoe UI", 8.5F);
        lblPhone.ForeColor = Color.FromArgb(148, 163, 184);
        lblPhone.Location = new Point(24, 170);
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
        txtFullName.Location = new Point(24, 130);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(390, 25);
        txtFullName.TabIndex = 3;
        // 
        // lblFullName
        // 
        lblFullName.Font = new Font("Segoe UI", 8.5F);
        lblFullName.ForeColor = Color.FromArgb(148, 163, 184);
        lblFullName.Location = new Point(24, 110);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(390, 18);
        lblFullName.TabIndex = 2;
        lblFullName.Text = "Full Name *";
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(96, 165, 250);
        lblTitle.Location = new Point(24, 24);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(412, 35);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "👤 My Profile Details";
        // 
        // FrmUpdateProfile
        // 
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(460, 520);
        Controls.Add(pnlMain);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmUpdateProfile";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub – Edit Profile";
        pnlMain.ResumeLayout(false);
        pnlMain.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlMain;
    private Label lblTitle;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblPhone;
    private TextBox txtPhone;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblAddress;
    private TextBox txtAddress;
    private Label lblNewPassword;
    private TextBox txtNewPassword;
    private Label lblError;
    private Button btnSave;
    private Button btnCancel;
}
