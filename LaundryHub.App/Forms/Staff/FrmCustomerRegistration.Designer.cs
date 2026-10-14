namespace LaundryHub.App.Forms.Staff;

partial class FrmCustomerRegistration
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
        lblTitle = new Label();
        btnClose = new Button();
        pnlContainer = new Panel();
        pnlRight = new Panel();
        pnlGridContainer = new Panel();
        dgvCustomers = new DataGridView();
        pnlSearchBar = new Panel();
        txtSearch = new TextBox();
        lblSearchIcon = new Label();
        btnArchive = new Button();
        pnlLeftCard = new Panel();
        flpForm = new FlowLayoutPanel();
        lblFullName = new Label();
        txtFullName = new TextBox();
        lblPhone = new Label();
        txtPhone = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblAddress = new Label();
        txtAddress = new TextBox();
        lblError = new Label();
        flpButtons = new FlowLayoutPanel();
        btnSave = new Button();
        btnClear = new Button();
        btnSelect = new Button();
        lblFormTitle = new Label();
        pnlHeader.SuspendLayout();
        pnlContainer.SuspendLayout();
        pnlRight.SuspendLayout();
        pnlGridContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
        pnlSearchBar.SuspendLayout();
        pnlLeftCard.SuspendLayout();
        flpForm.SuspendLayout();
        flpButtons.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(btnClose);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 0, 24, 0);
        pnlHeader.Size = new Size(1000, 65);
        pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(96, 165, 250);
        lblTitle.Location = new Point(24, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(500, 65);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "👥 Customer Directory & Registration";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnClose
        // 
        btnClose.BackColor = Color.FromArgb(51, 65, 85);
        btnClose.Cursor = Cursors.Hand;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.ForeColor = Color.White;
        btnClose.Location = new Point(886, 16);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(90, 34);
        btnClose.TabIndex = 1;
        btnClose.Text = "✕ Close";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += btnClose_Click;
        // 
        // pnlContainer
        // 
        pnlContainer.Controls.Add(pnlRight);
        pnlContainer.Controls.Add(pnlLeftCard);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 65);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(20);
        pnlContainer.Size = new Size(1000, 575);
        pnlContainer.TabIndex = 1;
        // 
        // pnlRight
        // 
        pnlRight.Controls.Add(pnlGridContainer);
        pnlRight.Controls.Add(pnlSearchBar);
        pnlRight.Dock = DockStyle.Fill;
        pnlRight.Location = new Point(400, 20);
        pnlRight.Name = "pnlRight";
        pnlRight.Padding = new Padding(16, 0, 0, 0);
        pnlRight.Size = new Size(580, 535);
        pnlRight.TabIndex = 1;
        // 
        // pnlGridContainer
        // 
        pnlGridContainer.Controls.Add(dgvCustomers);
        pnlGridContainer.Dock = DockStyle.Fill;
        pnlGridContainer.Location = new Point(16, 48);
        pnlGridContainer.Name = "pnlGridContainer";
        pnlGridContainer.Padding = new Padding(0, 10, 0, 0);
        pnlGridContainer.Size = new Size(564, 487);
        pnlGridContainer.TabIndex = 1;
        // 
        // dgvCustomers
        // 
        dgvCustomers.AllowUserToAddRows = false;
        dgvCustomers.AllowUserToDeleteRows = false;
        dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCustomers.BackgroundColor = Color.FromArgb(30, 41, 59);
        dgvCustomers.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(148, 163, 184);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(37, 99, 235);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvCustomers.DefaultCellStyle = dataGridViewCellStyle2;
        dgvCustomers.Dock = DockStyle.Fill;
        dgvCustomers.EnableHeadersVisualStyles = false;
        dgvCustomers.GridColor = Color.FromArgb(51, 65, 85);
        dgvCustomers.Location = new Point(0, 10);
        dgvCustomers.Name = "dgvCustomers";
        dgvCustomers.ReadOnly = true;
        dgvCustomers.RowHeadersVisible = false;
        dgvCustomers.RowTemplate.Height = 36;
        dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCustomers.Size = new Size(564, 477);
        dgvCustomers.TabIndex = 0;
        dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;
        dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
        // 
        // pnlSearchBar
        // 
        pnlSearchBar.BackColor = Color.FromArgb(30, 41, 59);
        pnlSearchBar.Controls.Add(txtSearch);
        pnlSearchBar.Controls.Add(lblSearchIcon);
        pnlSearchBar.Controls.Add(btnArchive);
        pnlSearchBar.Dock = DockStyle.Top;
        pnlSearchBar.Location = new Point(16, 0);
        pnlSearchBar.Name = "pnlSearchBar";
        pnlSearchBar.Padding = new Padding(12, 8, 12, 8);
        pnlSearchBar.Size = new Size(564, 48);
        pnlSearchBar.TabIndex = 0;
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.FromArgb(15, 23, 42);
        txtSearch.BorderStyle = BorderStyle.FixedSingle;
        txtSearch.Dock = DockStyle.Fill;
        txtSearch.Font = new Font("Segoe UI", 10.5F);
        txtSearch.ForeColor = Color.White;
        txtSearch.Location = new Point(40, 8);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Search by name or phone number...";
        txtSearch.Size = new Size(417, 26);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // lblSearchIcon
        // 
        lblSearchIcon.Dock = DockStyle.Left;
        lblSearchIcon.Font = new Font("Segoe UI Emoji", 10F);
        lblSearchIcon.Location = new Point(12, 8);
        lblSearchIcon.Name = "lblSearchIcon";
        lblSearchIcon.Size = new Size(28, 32);
        lblSearchIcon.TabIndex = 0;
        lblSearchIcon.Text = "🔍";
        lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnArchive
        // 
        btnArchive.BackColor = Color.FromArgb(153, 27, 27);
        btnArchive.Cursor = Cursors.Hand;
        btnArchive.Dock = DockStyle.Right;
        btnArchive.FlatAppearance.BorderSize = 0;
        btnArchive.FlatStyle = FlatStyle.Flat;
        btnArchive.Font = new Font("Segoe UI", 8.5F);
        btnArchive.ForeColor = Color.White;
        btnArchive.Location = new Point(457, 8);
        btnArchive.Name = "btnArchive";
        btnArchive.Size = new Size(95, 32);
        btnArchive.TabIndex = 2;
        btnArchive.Text = "🗑 Archive";
        btnArchive.UseVisualStyleBackColor = false;
        btnArchive.Click += btnArchive_Click;
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
        pnlLeftCard.Size = new Size(380, 535);
        pnlLeftCard.TabIndex = 0;
        // 
        // flpForm
        // 
        flpForm.AutoScroll = true;
        flpForm.Controls.Add(lblFullName);
        flpForm.Controls.Add(txtFullName);
        flpForm.Controls.Add(lblPhone);
        flpForm.Controls.Add(txtPhone);
        flpForm.Controls.Add(lblEmail);
        flpForm.Controls.Add(txtEmail);
        flpForm.Controls.Add(lblAddress);
        flpForm.Controls.Add(txtAddress);
        flpForm.Controls.Add(lblError);
        flpForm.Controls.Add(flpButtons); 
        flpForm.Controls.Add(flpButtons);
        flpForm.Dock = DockStyle.Fill;
        flpForm.FlowDirection = FlowDirection.TopDown;
        flpForm.Location = new Point(20, 55);
        flpForm.Name = "flpForm";
        flpForm.Padding = new Padding(0, 10, 0, 0);
        flpForm.Size = new Size(340, 460);
        flpForm.TabIndex = 1;
        flpForm.WrapContents = false;
        // 
        // lblFullName
        // 
        lblFullName.Font = new Font("Segoe UI", 8.5F);
        lblFullName.ForeColor = Color.FromArgb(148, 163, 184);
        lblFullName.Location = new Point(0, 16);
        lblFullName.Margin = new Padding(0, 6, 0, 2);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(320, 18);
        lblFullName.TabIndex = 0;
        lblFullName.Text = "Full Name *";
        // 
        // txtFullName
        // 
        txtFullName.BackColor = Color.FromArgb(15, 23, 42);
        txtFullName.BorderStyle = BorderStyle.FixedSingle;
        txtFullName.Font = new Font("Segoe UI", 10F);
        txtFullName.ForeColor = Color.White;
        txtFullName.Location = new Point(0, 39);
        txtFullName.Margin = new Padding(0, 3, 0, 3);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(320, 25);
        txtFullName.TabIndex = 1;
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("Segoe UI", 8.5F);
        lblPhone.ForeColor = Color.FromArgb(148, 163, 184);
        lblPhone.Location = new Point(0, 73);
        lblPhone.Margin = new Padding(0, 6, 0, 2);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(320, 18);
        lblPhone.TabIndex = 2;
        lblPhone.Text = "Phone Number * (e.g. 09171234567)";
        // 
        // txtPhone
        // 
        txtPhone.BackColor = Color.FromArgb(15, 23, 42);
        txtPhone.BorderStyle = BorderStyle.FixedSingle;
        txtPhone.Font = new Font("Segoe UI", 10F);
        txtPhone.ForeColor = Color.White;
        txtPhone.Location = new Point(0, 96);
        txtPhone.Margin = new Padding(0, 3, 0, 3);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(320, 25);
        txtPhone.TabIndex = 3;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI", 8.5F);
        lblEmail.ForeColor = Color.FromArgb(148, 163, 184);
        lblEmail.Location = new Point(0, 130);
        lblEmail.Margin = new Padding(0, 6, 0, 2);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(320, 18);
        lblEmail.TabIndex = 4;
        lblEmail.Text = "Email Address (Optional)";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.FromArgb(15, 23, 42);
        txtEmail.BorderStyle = BorderStyle.FixedSingle;
        txtEmail.Font = new Font("Segoe UI", 10F);
        txtEmail.ForeColor = Color.White;
        txtEmail.Location = new Point(0, 153);
        txtEmail.Margin = new Padding(0, 3, 0, 3);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(320, 25);
        txtEmail.TabIndex = 5;
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("Segoe UI", 8.5F);
        lblAddress.ForeColor = Color.FromArgb(148, 163, 184);
        lblAddress.Location = new Point(0, 187);
        lblAddress.Margin = new Padding(0, 6, 0, 2);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(320, 18);
        lblAddress.TabIndex = 6;
        lblAddress.Text = "Complete Address (Optional)";
        // 
        // txtAddress
        // 
        txtAddress.BackColor = Color.FromArgb(15, 23, 42);
        txtAddress.BorderStyle = BorderStyle.FixedSingle;
        txtAddress.Font = new Font("Segoe UI", 10F);
        txtAddress.ForeColor = Color.White;
        txtAddress.Location = new Point(0, 210);
        txtAddress.Margin = new Padding(0, 3, 0, 3);
        txtAddress.Multiline = true;
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(320, 50);
        txtAddress.TabIndex = 7;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(248, 113, 113);
        lblError.Location = new Point(3, 263);
        lblError.Name = "lblError";
        lblError.Size = new Size(320, 30);
        lblError.TabIndex = 8;
        lblError.Visible = false;
        // 
        // flpButtons
        // 
        flpButtons.Controls.Add(btnSave);
        flpButtons.Controls.Add(btnClear);
        flpButtons.Controls.Add(btnSelect);
        flpButtons.Location = new Point(3, 296);
        flpButtons.Name = "flpButtons";
        flpButtons.Size = new Size(320, 120);
        flpButtons.TabIndex = 9;
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
        btnSave.Size = new Size(150, 38);
        btnSave.TabIndex = 0;
        btnSave.Text = "💾 Save Customer";
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
        btnClear.Location = new Point(159, 3);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(150, 38);
        btnClear.TabIndex = 1;
        btnClear.Text = "↺ Clear";
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += btnClear_Click;
        // 
        // btnSelect
        // 
        btnSelect.BackColor = Color.FromArgb(16, 185, 129);
        btnSelect.Cursor = Cursors.Hand;
        btnSelect.FlatAppearance.BorderSize = 0;
        btnSelect.FlatStyle = FlatStyle.Flat;
        btnSelect.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSelect.ForeColor = Color.White;
        btnSelect.Location = new Point(3, 52);
        btnSelect.Margin = new Padding(3, 8, 3, 3);
        btnSelect.Name = "btnSelect";
        btnSelect.Size = new Size(306, 38);
        btnSelect.TabIndex = 2;
        btnSelect.Text = "✔ Select for Current Order";
        btnSelect.UseVisualStyleBackColor = false;
        btnSelect.Visible = false;
        btnSelect.Click += btnSelect_Click;
        // 
        // lblFormTitle
        // 
        lblFormTitle.Dock = DockStyle.Top;
        lblFormTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblFormTitle.ForeColor = Color.White;
        lblFormTitle.Location = new Point(20, 20);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(340, 35);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "➕ New Customer";
        // 
        // FrmCustomerRegistration
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(1000, 640);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmCustomerRegistration";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Customer Management";
        pnlHeader.ResumeLayout(false);
        pnlContainer.ResumeLayout(false);
        pnlRight.ResumeLayout(false);
        pnlGridContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
        pnlSearchBar.ResumeLayout(false);
        pnlSearchBar.PerformLayout();
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
    private Label lblPhone;
    private TextBox txtPhone;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblAddress;
    private TextBox txtAddress;
    private Label lblError;
    private FlowLayoutPanel flpButtons;
    private Button btnSave;
    private Button btnClear;
    private Button btnSelect;
    private Panel pnlRight;
    private Panel pnlSearchBar;
    private Label lblSearchIcon;
    private TextBox txtSearch;
    private Button btnArchive;
    private Panel pnlGridContainer;
    private DataGridView dgvCustomers;
}
