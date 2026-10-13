using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

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
        btnCancel = new HopeButton();
        btnSave = new HopeButton();
        lblError = new Label();
        txtNewPassword = new HopeTextBox();
        lblNewPassword = new Label();
        txtAddress = new HopeTextBox();
        lblAddress = new Label();
        txtEmail = new HopeTextBox();
        lblEmail = new Label();
        txtPhone = new HopeTextBox();
        lblPhone = new Label();
        txtFullName = new HopeTextBox();
        lblFullName = new Label();
        lblTitle = new Label();
        pnlMain.SuspendLayout();
        SuspendLayout();
        // 
        // pnlMain
        // 
        pnlMain.BackColor = Color.FromArgb(242, 239, 231);
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
        pnlMain.Size = new Size(472, 500);
        pnlMain.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(37, 78, 122);
        lblTitle.Location = new Point(24, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(424, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "👤 My Profile Details";
        // 
        // lblFullName
        // 
        lblFullName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblFullName.ForeColor = Color.FromArgb(51, 104, 160);
        lblFullName.Location = new Point(24, 62);
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
        txtFullName.Location = new Point(24, 80);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(390, 32);
        txtFullName.TabIndex = 3;
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPhone.ForeColor = Color.FromArgb(51, 104, 160);
        lblPhone.Location = new Point(24, 118);
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
        txtPhone.Location = new Point(24, 136);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(390, 32);
        txtPhone.TabIndex = 5;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblEmail.ForeColor = Color.FromArgb(51, 104, 160);
        lblEmail.Location = new Point(24, 174);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(390, 16);
        lblEmail.TabIndex = 6;
        lblEmail.Text = "Email Address";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.White;
        txtEmail.BaseColor = Color.FromArgb(242, 239, 231);
        txtEmail.BorderColorA = Color.FromArgb(102, 163, 191);
        txtEmail.BorderColorB = Color.FromArgb(200, 223, 219);
        txtEmail.Font = new Font("Segoe UI", 9.5F);
        txtEmail.ForeColor = Color.FromArgb(51, 104, 160);
        txtEmail.Location = new Point(24, 192);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(390, 32);
        txtEmail.TabIndex = 7;
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblAddress.ForeColor = Color.FromArgb(51, 104, 160);
        lblAddress.Location = new Point(24, 230);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(390, 16);
        lblAddress.TabIndex = 8;
        lblAddress.Text = "Home / Delivery Address";
        // 
        // txtAddress
        // 
        txtAddress.BackColor = Color.White;
        txtAddress.BaseColor = Color.FromArgb(242, 239, 231);
        txtAddress.BorderColorA = Color.FromArgb(102, 163, 191);
        txtAddress.BorderColorB = Color.FromArgb(200, 223, 219);
        txtAddress.Font = new Font("Segoe UI", 9.5F);
        txtAddress.ForeColor = Color.FromArgb(51, 104, 160);
        txtAddress.Location = new Point(24, 248);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(390, 32);
        txtAddress.TabIndex = 9;
        // 
        // lblNewPassword
        // 
        lblNewPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblNewPassword.ForeColor = Color.FromArgb(51, 104, 160);
        lblNewPassword.Location = new Point(24, 286);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Size = new Size(390, 16);
        lblNewPassword.TabIndex = 10;
        lblNewPassword.Text = "Change Password (leave blank to keep current)";
        // 
        // txtNewPassword
        // 
        txtNewPassword.BackColor = Color.White;
        txtNewPassword.BaseColor = Color.FromArgb(242, 239, 231);
        txtNewPassword.BorderColorA = Color.FromArgb(102, 163, 191);
        txtNewPassword.BorderColorB = Color.FromArgb(200, 223, 219);
        txtNewPassword.Font = new Font("Segoe UI", 9.5F);
        txtNewPassword.ForeColor = Color.FromArgb(51, 104, 160);
        txtNewPassword.Location = new Point(24, 304);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.PasswordChar = '●';
        txtNewPassword.UseSystemPasswordChar = true;
        txtNewPassword.Size = new Size(390, 32);
        txtNewPassword.TabIndex = 11;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(220, 53, 69);
        lblError.Location = new Point(24, 344);
        lblError.Name = "lblError";
        lblError.Size = new Size(390, 26);
        lblError.TabIndex = 12;
        lblError.Visible = false;
        // 
        // btnSave
        // 
        btnSave.ButtonType = HopeButtonType.Primary;
        btnSave.PrimaryColor = Color.FromArgb(37, 78, 122);
        btnSave.TextColor = Color.White;
        btnSave.HoverTextColor = Color.White;
        btnSave.Cursor = Cursors.Hand;
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.Location = new Point(24, 368);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(196, 42);
        btnSave.TabIndex = 13;
        btnSave.Text = "Save Changes";
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.ButtonType = HopeButtonType.Primary;
        btnCancel.PrimaryColor = Color.FromArgb(108, 117, 125);
        btnCancel.BorderColor = Color.FromArgb(108, 117, 125);
        btnCancel.TextColor = Color.White;
        btnCancel.HoverTextColor = Color.White;
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.Font = new Font("Segoe UI", 9.5F);
        btnCancel.Location = new Point(228, 368);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(196, 42);
        btnCancel.TabIndex = 14;
        btnCancel.Text = "Cancel";
        btnCancel.Click += btnCancel_Click;
        // 
        // FrmUpdateProfile
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(37, 78, 122);
        ClientSize = new Size(520, 560);
        Controls.Add(pnlMain);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(51, 104, 160);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmUpdateProfile";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub – Edit Profile";
        pnlMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlMain;
    private Label lblTitle;
    private Label lblFullName;
    private HopeTextBox txtFullName;
    private Label lblPhone;
    private HopeTextBox txtPhone;
    private Label lblEmail;
    private HopeTextBox txtEmail;
    private Label lblAddress;
    private HopeTextBox txtAddress;
    private Label lblNewPassword;
    private HopeTextBox txtNewPassword;
    private Label lblError;
    private HopeButton btnSave;
    private HopeButton btnCancel;
}

