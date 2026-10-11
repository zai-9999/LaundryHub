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
        btnClose = new Button();
        lblTitle = new Label();
        pnlContainer = new Panel();
        pnlRight = new Panel();
        pnlGridWrap = new Panel();
        dgvStaff = new DataGridView();
        pnlToolBar = new Panel();
        btnToggleStatus = new Button();
        lblGridTitle = new Label();
        pnlLeftCard = new Panel();
        flpForm = new FlowLayoutPanel();
        lblFullName = new Label();
        txtFullName = new TextBox();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblRole = new Label();
        cmbRole = new ComboBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        chkActive = new CheckBox();
        lblError = new Label();
        flpButtons = new FlowLayoutPanel();
        btnSave = new Button();
        btnClear = new Button();
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
        pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
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
        btnClose.BackColor = Color.FromArgb(51, 65, 85);
        btnClose.Cursor = Cursors.Hand;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.ForeColor = Color.White;
        btnClose.Location = new Point(836, 16);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(90, 34);
        btnClose.TabIndex = 1;
        btnClose.Text = "✕ Close";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += btnClose_Click;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(96, 165, 250);
        lblTitle.Location = new Point(24, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(400, 65);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "👥 Manage Staff Accounts";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlContainer
        // 
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
        dgvStaff.BackgroundColor = Color.FromArgb(30, 41, 59);
        dgvStaff.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(148, 163, 184);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(37, 99, 235);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvStaff.DefaultCellStyle = dataGridViewCellStyle2;
        dgvStaff.Dock = DockStyle.Fill;
        dgvStaff.EnableHeadersVisualStyles = false;
        dgvStaff.GridColor = Color.FromArgb(51, 65, 85);
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
        pnlToolBar.BackColor = Color.FromArgb(30, 41, 59);
        pnlToolBar.Controls.Add(btnToggleStatus);
        pnlToolBar.Controls.Add(lblGridTitle);
        pnlToolBar.Dock = DockStyle.Top;
        pnlToolBar.Location = new Point(16, 0);
        pnlToolBar.Name = "pnlToolBar";
        pnlToolBar.Padding = new Padding(12, 6, 12, 6);
        pnlToolBar.Size = new Size(534, 44);
        pnlToolBar.TabIndex = 0;
        // 
        // btnToggleStatus
        // 
        btnToggleStatus.BackColor = Color.FromArgb(51, 65, 85);
        btnToggleStatus.Cursor = Cursors.Hand;
        btnToggleStatus.Dock = DockStyle.Right;
        btnToggleStatus.FlatAppearance.BorderSize = 0;
        btnToggleStatus.FlatStyle = FlatStyle.Flat;
        btnToggleStatus.ForeColor = Color.White;
        btnToggleStatus.Location = new Point(342, 6);
        btnToggleStatus.Name = "btnToggleStatus";
        btnToggleStatus.Size = new Size(180, 32);
        btnToggleStatus.TabIndex = 1;
        btnToggleStatus.Text = "🔄 Toggle Active/Inactive";
        btnToggleStatus.UseVisualStyleBackColor = false;
        btnToggleStatus.Click += btnToggleStatus_Click;
        // 
        // lblGridTitle
        // 
        lblGridTitle.Dock = DockStyle.Left;
        lblGridTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblGridTitle.ForeColor = Color.White;
        lblGridTitle.Location = new Point(12, 6);
        lblGridTitle.Name = "lblGridTitle";
        lblGridTitle.Size = new Size(200, 32);
        lblGridTitle.TabIndex = 0;
        lblGridTitle.Text = "Active Staff Accounts";
        lblGridTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlLeftCard
        // 
        pnlLeftCard.BackColor = Color.FromArgb(30, 41, 59);
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
        lblFullName.Font = new Font("Segoe UI", 8.5F);
        lblFullName.ForeColor = Color.FromArgb(148, 163, 184);
        lblFullName.Location = new Point(0, 5);
        lblFullName.Margin = new Padding(0, 5, 0, 2);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(310, 18);
        lblFullName.TabIndex = 0;
        lblFullName.Text = "Full Name *";
        // 
        // txtFullName
        // 
        txtFullName.BackColor = Color.FromArgb(15, 23, 42);
        txtFullName.BorderStyle = BorderStyle.FixedSingle;
        txtFullName.Font = new Font("Segoe UI", 10F);
        txtFullName.ForeColor = Color.White;
        txtFullName.Location = new Point(0, 28);
        txtFullName.Margin = new Padding(0, 3, 0, 3);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(310, 25);
        txtFullName.TabIndex = 1;
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("Segoe UI", 8.5F);
        lblUsername.ForeColor = Color.FromArgb(148, 163, 184);
        lblUsername.Location = new Point(0, 61);
        lblUsername.Margin = new Padding(0, 5, 0, 2);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(310, 18);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "Username *";
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.FromArgb(15, 23, 42);
        txtUsername.BorderStyle = BorderStyle.FixedSingle;
        txtUsername.Font = new Font("Segoe UI", 10F);
        txtUsername.ForeColor = Color.White;
        txtUsername.Location = new Point(0, 84);
        txtUsername.Margin = new Padding(0, 3, 0, 3);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(310, 25);
        txtUsername.TabIndex = 3;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI", 8.5F);
        lblEmail.ForeColor = Color.FromArgb(148, 163, 184);
        lblEmail.Location = new Point(0, 117);
        lblEmail.Margin = new Padding(0, 5, 0, 2);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(310, 18);
        lblEmail.TabIndex = 4;
        lblEmail.Text = "Email *";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.FromArgb(15, 23, 42);
        txtEmail.BorderStyle = BorderStyle.FixedSingle;
        txtEmail.Font = new Font("Segoe UI", 10F);
        txtEmail.ForeColor = Color.White;
        txtEmail.Location = new Point(0, 140);
        txtEmail.Margin = new Padding(0, 3, 0, 3);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(310, 25);
        txtEmail.TabIndex = 5;
        // 
        // lblRole
        // 
        lblRole.Font = new Font("Segoe UI", 8.5F);
        lblRole.ForeColor = Color.FromArgb(148, 163, 184);
        lblRole.Location = new Point(0, 173);
        lblRole.Margin = new Padding(0, 5, 0, 2);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(310, 18);
        lblRole.TabIndex = 6;
        lblRole.Text = "Role *";
        // 
        // cmbRole
        // 
        cmbRole.BackColor = Color.FromArgb(15, 23, 42);
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbRole.FlatStyle = FlatStyle.Flat;
        cmbRole.Font = new Font("Segoe UI", 10F);
        cmbRole.ForeColor = Color.White;
        cmbRole.FormattingEnabled = true;
        cmbRole.Items.AddRange(new object[] { "Staff", "Admin" });
        cmbRole.Location = new Point(0, 196);
        cmbRole.Margin = new Padding(0, 3, 0, 3);
        cmbRole.Name = "cmbRole";
        cmbRole.Size = new Size(310, 25);
        cmbRole.TabIndex = 7;
        // 
        // lblPassword
        // 
        lblPassword.Font = new Font("Segoe UI", 8.5F);
        lblPassword.ForeColor = Color.FromArgb(148, 163, 184);
        lblPassword.Location = new Point(0, 229);
        lblPassword.Margin = new Padding(0, 5, 0, 2);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(310, 18);
        lblPassword.TabIndex = 8;
        lblPassword.Text = "Password * (or new password to reset)";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.FromArgb(15, 23, 42);
        txtPassword.BorderStyle = BorderStyle.FixedSingle;
        txtPassword.Font = new Font("Segoe UI", 10F);
        txtPassword.ForeColor = Color.White;
        txtPassword.Location = new Point(0, 252);
        txtPassword.Margin = new Padding(0, 3, 0, 3);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new Size(310, 25);
        txtPassword.TabIndex = 9;
        // 
        // chkActive
        // 
        chkActive.Checked = true;
        chkActive.CheckState = CheckState.Checked;
        chkActive.ForeColor = Color.White;
        chkActive.Location = new Point(0, 283);
        chkActive.Name = "chkActive";
        chkActive.Padding = new Padding(0, 6, 0, 6);
        chkActive.Size = new Size(310, 30);
        chkActive.TabIndex = 10;
        chkActive.Text = "Active account";
        chkActive.UseVisualStyleBackColor = true;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(248, 113, 113);
        lblError.Location = new Point(0, 316);
        lblError.Name = "lblError";
        lblError.Size = new Size(310, 30);
        lblError.TabIndex = 11;
        lblError.Visible = false;
        // 
        // flpButtons
        // 
        flpButtons.Controls.Add(btnSave);
        flpButtons.Controls.Add(btnClear);
        flpButtons.Location = new Point(0, 349);
        flpButtons.Name = "flpButtons";
        flpButtons.Size = new Size(310, 70);
        flpButtons.TabIndex = 12;
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.Cursor = Cursors.Hand;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(3, 3);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(145, 38);
        btnSave.TabIndex = 0;
        btnSave.Text = "💾 Save Account";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // btnClear
        // 
        btnClear.BackColor = Color.FromArgb(51, 65, 85);
        btnClear.Cursor = Cursors.Hand;
        btnClear.FlatAppearance.BorderSize = 0;
        btnClear.FlatStyle = FlatStyle.Flat;
        btnClear.ForeColor = Color.White;
        btnClear.Location = new Point(154, 3);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(145, 38);
        btnClear.TabIndex = 1;
        btnClear.Text = "↺ Clear";
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += btnClear_Click;
        // 
        // lblFormTitle
        // 
        lblFormTitle.Dock = DockStyle.Top;
        lblFormTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblFormTitle.ForeColor = Color.White;
        lblFormTitle.Location = new Point(20, 20);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(320, 35);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "➕ New Staff Member";
        // 
        // FrmManageStaff
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(950, 620);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
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
    private Button btnClose;
    private Panel pnlContainer;
    private Panel pnlLeftCard;
    private Label lblFormTitle;
    private FlowLayoutPanel flpForm;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblRole;
    private ComboBox cmbRole;
    private Label lblPassword;
    private TextBox txtPassword;
    private CheckBox chkActive;
    private Label lblError;
    private FlowLayoutPanel flpButtons;
    private Button btnSave;
    private Button btnClear;
    private Panel pnlRight;
    private Panel pnlToolBar;
    private Label lblGridTitle;
    private Button btnToggleStatus;
    private Panel pnlGridWrap;
    private DataGridView dgvStaff;
}
