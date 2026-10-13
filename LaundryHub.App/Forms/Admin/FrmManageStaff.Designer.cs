using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using Button = System.Windows.Forms.Button;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Admin;

partial class FrmManageStaff
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlHeader = new Panel();
        btnClose = new HopeButton();
        lblTitle = new Label();
        pnlContainer = new Panel();
        pnlRight = new Panel();
        pnlGridWrap = new Panel();
        dgvStaff = new DataGridView();
        pnlToolBar = new Panel();
        btnToggleStatus = new HopeButton();
        lblGridTitle = new Label();
        pnlLeftCard = new Panel();
        flpForm = new FlowLayoutPanel();
        lblFullName = new Label();
        txtFullName = new HopeTextBox();
        lblUsername = new Label();
        txtUsername = new HopeTextBox();
        lblEmail = new Label();
        txtEmail = new HopeTextBox();
        lblRole = new Label();
        cmbRole = new ComboBox();
        lblPassword = new Label();
        txtPassword = new HopeTextBox();
        chkActive = new CheckBox();
        lblError = new Label();
        flpButtons = new FlowLayoutPanel();
        btnSave = new HopeButton();
        btnClear = new HopeButton();
        lblFormTitle = new Label();
        pnlHeader.SuspendLayout();
        pnlContainer.SuspendLayout();
        pnlRight.SuspendLayout();
        pnlGridWrap.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
        pnlToolBar.SuspendLayout();
        pnlLeftCard.SuspendLayout();
        flpForm.SuspendLayout();
        flpButtons.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(51, 104, 160);
        pnlHeader.Controls.Add(btnClose);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 0, 24, 0);
        pnlHeader.Size = new Size(950, 65);
        pnlHeader.TabIndex = 0;
        // 
        // btnClose
        // 
        btnClose.ButtonType = HopeButtonType.Default;
        btnClose.DefaultColor = Color.FromArgb(102, 163, 191);
        btnClose.BorderColor = Color.FromArgb(200, 223, 219);
        btnClose.TextColor = Color.FromArgb(242, 239, 231);
        btnClose.HoverTextColor = Color.White;
        btnClose.Cursor = Cursors.Hand;
        btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnClose.Location = new Point(836, 16);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(90, 34);
        btnClose.TabIndex = 1;
        btnClose.Text = "✕ Close";
        btnClose.Click += btnClose_Click;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(242, 239, 231);
        lblTitle.Location = new Point(24, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(400, 65);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Manage Staff Accounts";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlContainer
        // 
        pnlContainer.BackColor = Color.FromArgb(242, 239, 231);
        pnlContainer.Controls.Add(pnlRight);
        pnlContainer.Controls.Add(pnlLeftCard);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 65);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(20);
        pnlContainer.Size = new Size(950, 555);
        pnlContainer.TabIndex = 1;
        // 
        // pnlRight
        // 
        pnlRight.BackColor = Color.Transparent;
        pnlRight.Controls.Add(pnlGridWrap);
        pnlRight.Controls.Add(pnlToolBar);
        pnlRight.Dock = DockStyle.Fill;
        pnlRight.Location = new Point(380, 20);
        pnlRight.Name = "pnlRight";
        pnlRight.Padding = new Padding(16, 0, 0, 0);
        pnlRight.Size = new Size(550, 515);
        pnlRight.TabIndex = 1;
        // 
        // pnlGridWrap
        // 
        pnlGridWrap.Controls.Add(dgvStaff);
        pnlGridWrap.Dock = DockStyle.Fill;
        pnlGridWrap.Location = new Point(16, 44);
        pnlGridWrap.Name = "pnlGridWrap";
        pnlGridWrap.Padding = new Padding(0, 10, 0, 0);
        pnlGridWrap.Size = new Size(534, 471);
        pnlGridWrap.TabIndex = 1;
        // 
        // dgvStaff
        // 
        dgvStaff.AllowUserToAddRows = false;
        dgvStaff.AllowUserToDeleteRows = false;
        dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStaff.BackgroundColor = Color.White;
        dgvStaff.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(242, 239, 231);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(242, 239, 231);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(200, 223, 219);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvStaff.DefaultCellStyle = dataGridViewCellStyle2;
        dgvStaff.Dock = DockStyle.Fill;
        dgvStaff.EnableHeadersVisualStyles = false;
        dgvStaff.GridColor = Color.FromArgb(200, 223, 219);
        dgvStaff.Location = new Point(0, 10);
        dgvStaff.Name = "dgvStaff";
        dgvStaff.ReadOnly = true;
        dgvStaff.RowHeadersVisible = false;
        dgvStaff.RowTemplate.Height = 36;
        dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStaff.Size = new Size(534, 461);
        dgvStaff.TabIndex = 0;
        dgvStaff.SelectionChanged += dgvStaff_SelectionChanged;
        // 
        // pnlToolBar
        // 
        pnlToolBar.BackColor = Color.Transparent;
        pnlToolBar.Controls.Add(btnToggleStatus);
        pnlToolBar.Controls.Add(lblGridTitle);
        pnlToolBar.Dock = DockStyle.Top;
        pnlToolBar.Location = new Point(16, 0);
        pnlToolBar.Name = "pnlToolBar";
        pnlToolBar.Padding = new Padding(0, 4, 0, 4);
        pnlToolBar.Size = new Size(534, 44);
        pnlToolBar.TabIndex = 0;
        // 
        // btnToggleStatus
        // 
        btnToggleStatus.ButtonType = HopeButtonType.Default;
        btnToggleStatus.DefaultColor = Color.FromArgb(200, 223, 219);
        btnToggleStatus.BorderColor = Color.FromArgb(102, 163, 191);
        btnToggleStatus.TextColor = Color.FromArgb(51, 104, 160);
        btnToggleStatus.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnToggleStatus.Cursor = Cursors.Hand;
        btnToggleStatus.Dock = DockStyle.Right;
        btnToggleStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnToggleStatus.Location = new Point(340, 4);
        btnToggleStatus.Name = "btnToggleStatus";
        btnToggleStatus.Size = new Size(194, 36);
        btnToggleStatus.TabIndex = 1;
        btnToggleStatus.Text = "Toggle Active/Disabled";
        btnToggleStatus.Click += btnToggleStatus_Click;
        // 
        // lblGridTitle
        // 
        lblGridTitle.Dock = DockStyle.Left;
        lblGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblGridTitle.ForeColor = Color.FromArgb(51, 104, 160);
        lblGridTitle.Location = new Point(0, 4);
        lblGridTitle.Name = "lblGridTitle";
        lblGridTitle.Size = new Size(200, 36);
        lblGridTitle.TabIndex = 0;
        lblGridTitle.Text = "Staff Accounts";
        lblGridTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlLeftCard
        // 
        pnlLeftCard.BackColor = Color.White;
        pnlLeftCard.Controls.Add(flpForm);
        pnlLeftCard.Controls.Add(lblFormTitle);
        pnlLeftCard.Dock = DockStyle.Left;
        pnlLeftCard.Location = new Point(20, 20);
        pnlLeftCard.Name = "pnlLeftCard";
        pnlLeftCard.Padding = new Padding(20);
        pnlLeftCard.Size = new Size(360, 515);
        pnlLeftCard.TabIndex = 0;
        // 
        // flpForm
        // 
        flpForm.AutoScroll = true;
        flpForm.BackColor = Color.Transparent;
        flpForm.Controls.Add(lblFullName);
        flpForm.Controls.Add(txtFullName);
        flpForm.Controls.Add(lblUsername);
        flpForm.Controls.Add(txtUsername);
        flpForm.Controls.Add(lblEmail);
        flpForm.Controls.Add(txtEmail);
        flpForm.Controls.Add(lblRole);
        flpForm.Controls.Add(cmbRole);
        flpForm.Controls.Add(lblPassword);
        flpForm.Controls.Add(txtPassword);
        flpForm.Controls.Add(chkActive);
        flpForm.Controls.Add(lblError);
        flpForm.Controls.Add(flpButtons);
        flpForm.Dock = DockStyle.Fill;
        flpForm.FlowDirection = FlowDirection.TopDown;
        flpForm.Location = new Point(20, 55);
        flpForm.Name = "flpForm";
        flpForm.Size = new Size(320, 440);
        flpForm.TabIndex = 1;
        flpForm.WrapContents = false;
        // 
        // lblFullName
        // 
        lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFullName.ForeColor = Color.FromArgb(51, 104, 160);
        lblFullName.Location = new Point(0, 4);
        lblFullName.Margin = new Padding(0, 4, 0, 2);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(310, 18);
        lblFullName.TabIndex = 0;
        lblFullName.Text = "Full Name *";
        // 
        // txtFullName
        // 
        txtFullName.BackColor = Color.White;
        txtFullName.BaseColor = Color.White;
        txtFullName.BorderColorA = Color.FromArgb(102, 163, 191);
        txtFullName.BorderColorB = Color.FromArgb(200, 223, 219);
        txtFullName.Font = new Font("Segoe UI", 9.5F);
        txtFullName.ForeColor = Color.FromArgb(51, 104, 160);
        txtFullName.Hint = "Enter full name";
        txtFullName.Location = new Point(0, 26);
        txtFullName.Margin = new Padding(0, 2, 0, 4);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(310, 34);
        txtFullName.TabIndex = 1;
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblUsername.ForeColor = Color.FromArgb(51, 104, 160);
        lblUsername.Location = new Point(0, 66);
        lblUsername.Margin = new Padding(0, 4, 0, 2);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(310, 18);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "Username *";
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.White;
        txtUsername.BaseColor = Color.White;
        txtUsername.BorderColorA = Color.FromArgb(102, 163, 191);
        txtUsername.BorderColorB = Color.FromArgb(200, 223, 219);
        txtUsername.Font = new Font("Segoe UI", 9.5F);
        txtUsername.ForeColor = Color.FromArgb(51, 104, 160);
        txtUsername.Hint = "Enter username";
        txtUsername.Location = new Point(0, 88);
        txtUsername.Margin = new Padding(0, 2, 0, 4);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(310, 34);
        txtUsername.TabIndex = 3;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEmail.ForeColor = Color.FromArgb(51, 104, 160);
        lblEmail.Location = new Point(0, 128);
        lblEmail.Margin = new Padding(0, 4, 0, 2);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(310, 18);
        lblEmail.TabIndex = 4;
        lblEmail.Text = "Email Address *";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.White;
        txtEmail.BaseColor = Color.White;
        txtEmail.BorderColorA = Color.FromArgb(102, 163, 191);
        txtEmail.BorderColorB = Color.FromArgb(200, 223, 219);
        txtEmail.Font = new Font("Segoe UI", 9.5F);
        txtEmail.ForeColor = Color.FromArgb(51, 104, 160);
        txtEmail.Hint = "staff@example.com";
        txtEmail.Location = new Point(0, 150);
        txtEmail.Margin = new Padding(0, 2, 0, 4);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(310, 34);
        txtEmail.TabIndex = 5;
        // 
        // lblRole
        // 
        lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRole.ForeColor = Color.FromArgb(51, 104, 160);
        lblRole.Location = new Point(0, 190);
        lblRole.Margin = new Padding(0, 4, 0, 2);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(310, 18);
        lblRole.TabIndex = 6;
        lblRole.Text = "Role *";
        // 
        // cmbRole
        // 
        cmbRole.BackColor = Color.White;
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbRole.FlatStyle = FlatStyle.Flat;
        cmbRole.Font = new Font("Segoe UI", 9.5F);
        cmbRole.ForeColor = Color.FromArgb(51, 104, 160);
        cmbRole.FormattingEnabled = true;
        cmbRole.Items.AddRange(new object[] { "Staff", "Admin" });
        cmbRole.Location = new Point(0, 212);
        cmbRole.Margin = new Padding(0, 2, 0, 4);
        cmbRole.Name = "cmbRole";
        cmbRole.Size = new Size(310, 29);
        cmbRole.TabIndex = 7;
        // 
        // lblPassword
        // 
        lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPassword.ForeColor = Color.FromArgb(51, 104, 160);
        lblPassword.Location = new Point(0, 247);
        lblPassword.Margin = new Padding(0, 4, 0, 2);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(310, 18);
        lblPassword.TabIndex = 8;
        lblPassword.Text = "Password * (or new password to reset)";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.White;
        txtPassword.BaseColor = Color.White;
        txtPassword.BorderColorA = Color.FromArgb(102, 163, 191);
        txtPassword.BorderColorB = Color.FromArgb(200, 223, 219);
        txtPassword.Font = new Font("Segoe UI", 9.5F);
        txtPassword.ForeColor = Color.FromArgb(51, 104, 160);
        txtPassword.Hint = "Enter password";
        txtPassword.Location = new Point(0, 269);
        txtPassword.Margin = new Padding(0, 2, 0, 4);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new Size(310, 34);
        txtPassword.TabIndex = 9;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // chkActive
        // 
        chkActive.Checked = true;
        chkActive.CheckState = CheckState.Checked;
        chkActive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        chkActive.ForeColor = Color.FromArgb(51, 104, 160);
        chkActive.Location = new Point(0, 309);
        chkActive.Name = "chkActive";
        chkActive.Padding = new Padding(0, 4, 0, 4);
        chkActive.Size = new Size(310, 30);
        chkActive.TabIndex = 10;
        chkActive.Text = "Active account";
        chkActive.UseVisualStyleBackColor = true;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 9F);
        lblError.ForeColor = Color.FromArgb(200, 50, 50);
        lblError.Location = new Point(0, 344);
        lblError.Name = "lblError";
        lblError.Size = new Size(310, 28);
        lblError.TabIndex = 11;
        lblError.Visible = false;
        // 
        // flpButtons
        // 
        flpButtons.Controls.Add(btnSave);
        flpButtons.Controls.Add(btnClear);
        flpButtons.Location = new Point(0, 374);
        flpButtons.Name = "flpButtons";
        flpButtons.Size = new Size(310, 55);
        flpButtons.TabIndex = 12;
        // 
        // btnSave
        // 
        btnSave.ButtonType = HopeButtonType.Primary;
        btnSave.PrimaryColor = Color.FromArgb(51, 104, 160);
        btnSave.TextColor = Color.FromArgb(242, 239, 231);
        btnSave.HoverTextColor = Color.White;
        btnSave.Cursor = Cursors.Hand;
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.Location = new Point(3, 3);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(145, 40);
        btnSave.TabIndex = 0;
        btnSave.Text = "Save Account";
        btnSave.Click += btnSave_Click;
        // 
        // btnClear
        // 
        btnClear.ButtonType = HopeButtonType.Default;
        btnClear.DefaultColor = Color.FromArgb(200, 223, 219);
        btnClear.BorderColor = Color.FromArgb(102, 163, 191);
        btnClear.TextColor = Color.FromArgb(51, 104, 160);
        btnClear.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnClear.Cursor = Cursors.Hand;
        btnClear.Font = new Font("Segoe UI", 9.5F);
        btnClear.Location = new Point(154, 3);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(145, 40);
        btnClear.TabIndex = 1;
        btnClear.Text = "↺ Clear";
        btnClear.Click += btnClear_Click;
        // 
        // lblFormTitle
        // 
        lblFormTitle.Dock = DockStyle.Top;
        lblFormTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblFormTitle.ForeColor = Color.FromArgb(51, 104, 160);
        lblFormTitle.Location = new Point(20, 20);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(320, 35);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "New Staff Member";
        // 
        // FrmManageStaff
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(242, 239, 231);
        ClientSize = new Size(950, 620);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(51, 104, 160);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmManageStaff";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub – Staff & User Management";
        pnlHeader.ResumeLayout(false);
        pnlContainer.ResumeLayout(false);
        pnlRight.ResumeLayout(false);
        pnlGridWrap.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
        pnlToolBar.ResumeLayout(false);
        pnlLeftCard.ResumeLayout(false);
        flpForm.ResumeLayout(false);
        flpForm.PerformLayout();
        flpButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblTitle;
    private HopeButton btnClose;
    private Panel pnlContainer;
    private Panel pnlLeftCard;
    private Label lblFormTitle;
    private FlowLayoutPanel flpForm;
    private Label lblFullName;
    private HopeTextBox txtFullName;
    private Label lblUsername;
    private HopeTextBox txtUsername;
    private Label lblEmail;
    private HopeTextBox txtEmail;
    private Label lblRole;
    private ComboBox cmbRole;
    private Label lblPassword;
    private HopeTextBox txtPassword;
    private CheckBox chkActive;
    private Label lblError;
    private FlowLayoutPanel flpButtons;
    private HopeButton btnSave;
    private HopeButton btnClear;
    private Panel pnlRight;
    private Panel pnlToolBar;
    private Label lblGridTitle;
    private HopeButton btnToggleStatus;
    private Panel pnlGridWrap;
    private DataGridView dgvStaff;
}
