namespace LaundryHub.App.Forms.Admin;

partial class FrmServicePricing
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
        dgvServices = new DataGridView();
        pnlToolBar = new Panel();
        btnToggleActive = new Button();
        lblGridTitle = new Label();
        pnlLeftCard = new Panel();
        flpForm = new FlowLayoutPanel();
        lblServiceName = new Label();
        txtServiceName = new TextBox();
        lblPricePerKilo = new Label();
        txtPricePerKilo = new TextBox();
        lblMinWeight = new Label();
        txtMinWeight = new TextBox();
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
        ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
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
        pnlHeader.Size = new Size(880, 65);
        pnlHeader.TabIndex = 0;
        // 
        // btnClose
        // 
        btnClose.BackColor = Color.FromArgb(51, 65, 85);
        btnClose.Cursor = Cursors.Hand;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.ForeColor = Color.White;
        btnClose.Location = new Point(766, 16);
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
        lblTitle.Size = new Size(420, 65);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "🏷 Service Types & Price Rates";
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
        pnlContainer.Size = new Size(880, 495);
        pnlContainer.TabIndex = 1;
        // 
        // pnlRight
        // 
        pnlRight.Controls.Add(pnlGridWrap);
        pnlRight.Controls.Add(pnlToolBar);
        pnlRight.Dock = DockStyle.Fill;
        pnlRight.Location = new Point(360, 20);
        pnlRight.Name = "pnlRight";
        pnlRight.Padding = new Padding(16, 0, 0, 0);
        pnlRight.Size = new Size(500, 455);
        pnlRight.TabIndex = 1;
        // 
        // pnlGridWrap
        // 
        pnlGridWrap.Controls.Add(dgvServices);
        pnlGridWrap.Dock = DockStyle.Fill;
        pnlGridWrap.Location = new Point(16, 44);
        pnlGridWrap.Name = "pnlGridWrap";
        pnlGridWrap.Padding = new Padding(0, 10, 0, 0);
        pnlGridWrap.Size = new Size(484, 411);
        pnlGridWrap.TabIndex = 1;
        // 
        // dgvServices
        // 
        dgvServices.AllowUserToAddRows = false;
        dgvServices.AllowUserToDeleteRows = false;
        dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvServices.BackgroundColor = Color.FromArgb(30, 41, 59);
        dgvServices.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(148, 163, 184);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(37, 99, 235);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvServices.DefaultCellStyle = dataGridViewCellStyle2;
        dgvServices.Dock = DockStyle.Fill;
        dgvServices.EnableHeadersVisualStyles = false;
        dgvServices.GridColor = Color.FromArgb(51, 65, 85);
        dgvServices.Location = new Point(0, 10);
        dgvServices.Name = "dgvServices";
        dgvServices.ReadOnly = true;
        dgvServices.RowHeadersVisible = false;
        dgvServices.RowTemplate.Height = 36;
        dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvServices.Size = new Size(484, 401);
        dgvServices.TabIndex = 0;
        dgvServices.SelectionChanged += dgvServices_SelectionChanged;
        // 
        // pnlToolBar
        // 
        pnlToolBar.BackColor = Color.FromArgb(30, 41, 59);
        pnlToolBar.Controls.Add(btnToggleActive);
        pnlToolBar.Controls.Add(lblGridTitle);
        pnlToolBar.Dock = DockStyle.Top;
        pnlToolBar.Location = new Point(16, 0);
        pnlToolBar.Name = "pnlToolBar";
        pnlToolBar.Padding = new Padding(12, 6, 12, 6);
        pnlToolBar.Size = new Size(484, 44);
        pnlToolBar.TabIndex = 0;
        // 
        // btnToggleActive
        // 
        btnToggleActive.BackColor = Color.FromArgb(51, 65, 85);
        btnToggleActive.Cursor = Cursors.Hand;
        btnToggleActive.Dock = DockStyle.Right;
        btnToggleActive.FlatAppearance.BorderSize = 0;
        btnToggleActive.FlatStyle = FlatStyle.Flat;
        btnToggleActive.ForeColor = Color.White;
        btnToggleActive.Location = new Point(292, 6);
        btnToggleActive.Name = "btnToggleActive";
        btnToggleActive.Size = new Size(180, 32);
        btnToggleActive.TabIndex = 1;
        btnToggleActive.Text = "🔄 Toggle Active/Disabled";
        btnToggleActive.UseVisualStyleBackColor = false;
        btnToggleActive.Click += btnToggleActive_Click;
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
        lblGridTitle.Text = "Available Services List";
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
        pnlLeftCard.Size = new Size(340, 455);
        pnlLeftCard.TabIndex = 0;
        // 
        // flpForm
        // 
        flpForm.AutoScroll = true;
        flpForm.Controls.Add(lblServiceName);
        flpForm.Controls.Add(txtServiceName);
        flpForm.Controls.Add(lblPricePerKilo);
        flpForm.Controls.Add(txtPricePerKilo);
        flpForm.Controls.Add(lblMinWeight);
        flpForm.Controls.Add(txtMinWeight);
        flpForm.Controls.Add(chkActive);
        flpForm.Controls.Add(lblError);
        flpForm.Controls.Add(flpButtons);
        flpForm.Dock = DockStyle.Fill;
        flpForm.FlowDirection = FlowDirection.TopDown;
        flpForm.Location = new Point(20, 55);
        flpForm.Name = "flpForm";
        flpForm.Size = new Size(300, 380);
        flpForm.TabIndex = 1;
        flpForm.WrapContents = false;
        // 
        // lblServiceName
        // 
        lblServiceName.Font = new Font("Segoe UI", 8.5F);
        lblServiceName.ForeColor = Color.FromArgb(148, 163, 184);
        lblServiceName.Location = new Point(0, 5);
        lblServiceName.Margin = new Padding(0, 5, 0, 2);
        lblServiceName.Name = "lblServiceName";
        lblServiceName.Size = new Size(290, 18);
        lblServiceName.TabIndex = 0;
        lblServiceName.Text = "Service Name * (e.g. Wash & Dry)";
        // 
        // txtServiceName
        // 
        txtServiceName.BackColor = Color.FromArgb(15, 23, 42);
        txtServiceName.BorderStyle = BorderStyle.FixedSingle;
        txtServiceName.Font = new Font("Segoe UI", 10F);
        txtServiceName.ForeColor = Color.White;
        txtServiceName.Location = new Point(0, 28);
        txtServiceName.Margin = new Padding(0, 3, 0, 3);
        txtServiceName.Name = "txtServiceName";
        txtServiceName.Size = new Size(290, 25);
        txtServiceName.TabIndex = 1;
        // 
        // lblPricePerKilo
        // 
        lblPricePerKilo.Font = new Font("Segoe UI", 8.5F);
        lblPricePerKilo.ForeColor = Color.FromArgb(148, 163, 184);
        lblPricePerKilo.Location = new Point(0, 61);
        lblPricePerKilo.Margin = new Padding(0, 5, 0, 2);
        lblPricePerKilo.Name = "lblPricePerKilo";
        lblPricePerKilo.Size = new Size(290, 18);
        lblPricePerKilo.TabIndex = 2;
        lblPricePerKilo.Text = "Price Per Kilo (₱) *";
        // 
        // txtPricePerKilo
        // 
        txtPricePerKilo.BackColor = Color.FromArgb(15, 23, 42);
        txtPricePerKilo.BorderStyle = BorderStyle.FixedSingle;
        txtPricePerKilo.Font = new Font("Segoe UI", 10F);
        txtPricePerKilo.ForeColor = Color.White;
        txtPricePerKilo.Location = new Point(0, 84);
        txtPricePerKilo.Margin = new Padding(0, 3, 0, 3);
        txtPricePerKilo.Name = "txtPricePerKilo";
        txtPricePerKilo.Size = new Size(290, 25);
        txtPricePerKilo.TabIndex = 3;
        // 
        // lblMinWeight
        // 
        lblMinWeight.Font = new Font("Segoe UI", 8.5F);
        lblMinWeight.ForeColor = Color.FromArgb(148, 163, 184);
        lblMinWeight.Location = new Point(0, 117);
        lblMinWeight.Margin = new Padding(0, 5, 0, 2);
        lblMinWeight.Name = "lblMinWeight";
        lblMinWeight.Size = new Size(290, 18);
        lblMinWeight.TabIndex = 4;
        lblMinWeight.Text = "Minimum Weight (kg) *";
        // 
        // txtMinWeight
        // 
        txtMinWeight.BackColor = Color.FromArgb(15, 23, 42);
        txtMinWeight.BorderStyle = BorderStyle.FixedSingle;
        txtMinWeight.Font = new Font("Segoe UI", 10F);
        txtMinWeight.ForeColor = Color.White;
        txtMinWeight.Location = new Point(0, 140);
        txtMinWeight.Margin = new Padding(0, 3, 0, 3);
        txtMinWeight.Name = "txtMinWeight";
        txtMinWeight.Size = new Size(290, 25);
        txtMinWeight.TabIndex = 5;
        // 
        // chkActive
        // 
        chkActive.Checked = true;
        chkActive.CheckState = CheckState.Checked;
        chkActive.ForeColor = Color.White;
        chkActive.Location = new Point(0, 171);
        chkActive.Name = "chkActive";
        chkActive.Padding = new Padding(0, 6, 0, 6);
        chkActive.Size = new Size(290, 30);
        chkActive.TabIndex = 6;
        chkActive.Text = "Active Service";
        chkActive.UseVisualStyleBackColor = true;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(248, 113, 113);
        lblError.Location = new Point(0, 204);
        lblError.Name = "lblError";
        lblError.Size = new Size(290, 30);
        lblError.TabIndex = 7;
        lblError.Visible = false;
        // 
        // flpButtons
        // 
        flpButtons.Controls.Add(btnSave);
        flpButtons.Controls.Add(btnClear);
        flpButtons.Location = new Point(0, 237);
        flpButtons.Name = "flpButtons";
        flpButtons.Size = new Size(290, 60);
        flpButtons.TabIndex = 8;
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
        btnSave.Size = new Size(135, 38);
        btnSave.TabIndex = 0;
        btnSave.Text = "💾 Save Service";
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
        btnClear.Location = new Point(144, 3);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(135, 38);
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
        lblFormTitle.Size = new Size(300, 35);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "➕ New Service Type";
        // 
        // FrmServicePricing
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(880, 560);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmServicePricing";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub – Service Types & Pricing Management";
        pnlHeader.ResumeLayout(false);
        pnlContainer.ResumeLayout(false);
        pnlRight.ResumeLayout(false);
        pnlGridWrap.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
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
    private Label lblServiceName;
    private TextBox txtServiceName;
    private Label lblPricePerKilo;
    private TextBox txtPricePerKilo;
    private Label lblMinWeight;
    private TextBox txtMinWeight;
    private CheckBox chkActive;
    private Label lblError;
    private FlowLayoutPanel flpButtons;
    private Button btnSave;
    private Button btnClear;
    private Panel pnlRight;
    private Panel pnlToolBar;
    private Label lblGridTitle;
    private Button btnToggleActive;
    private Panel pnlGridWrap;
    private DataGridView dgvServices;
}
