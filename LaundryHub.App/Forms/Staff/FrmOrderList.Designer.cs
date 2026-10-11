namespace LaundryHub.App.Forms.Staff;

partial class FrmOrderList
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
        pnlTopBar = new Panel();
        txtSearch = new TextBox();
        chkFilterDate = new CheckBox();
        dtpFilter = new DateTimePicker();
        btnViewDetail = new Button();
        lblTitle = new Label();
        pnlLegend = new Panel();
        lblDotCancelled = new Label();
        lblCancelled = new Label();
        lblDotClaimed = new Label();
        lblClaimed = new Label();
        lblDotReady = new Label();
        lblReady = new Label();
        lblDotDrying = new Label();
        lblDrying = new Label();
        lblDotWashing = new Label();
        lblWashing = new Label();
        dgvOrders = new DataGridView();
        pnlTopBar.SuspendLayout();
        pnlLegend.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        SuspendLayout();
        // 
        // pnlTopBar
        // 
        pnlTopBar.BackColor = Color.FromArgb(30, 41, 59);
        pnlTopBar.Controls.Add(txtSearch);
        pnlTopBar.Controls.Add(chkFilterDate);
        pnlTopBar.Controls.Add(dtpFilter);
        pnlTopBar.Controls.Add(btnViewDetail);
        pnlTopBar.Controls.Add(lblTitle);
        pnlTopBar.Dock = DockStyle.Top;
        pnlTopBar.Location = new Point(0, 0);
        pnlTopBar.Name = "pnlTopBar";
        pnlTopBar.Padding = new Padding(16, 10, 16, 0);
        pnlTopBar.Size = new Size(1050, 60);
        pnlTopBar.TabIndex = 0;
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.FromArgb(15, 23, 42);
        txtSearch.BorderStyle = BorderStyle.FixedSingle;
        txtSearch.Dock = DockStyle.Fill;
        txtSearch.Font = new Font("Segoe UI", 10F);
        txtSearch.ForeColor = Color.White;
        txtSearch.Location = new Point(216, 10);
        txtSearch.Margin = new Padding(8, 0, 0, 0);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "🔍  Search by order # or customer name...";
        txtSearch.Size = new Size(504, 25);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // chkFilterDate
        // 
        chkFilterDate.Dock = DockStyle.Right;
        chkFilterDate.Font = new Font("Segoe UI", 8.5F);
        chkFilterDate.ForeColor = Color.FromArgb(148, 163, 184);
        chkFilterDate.Location = new Point(720, 10);
        chkFilterDate.Name = "chkFilterDate";
        chkFilterDate.Size = new Size(120, 50);
        chkFilterDate.TabIndex = 2;
        chkFilterDate.Text = "Filter by date:";
        chkFilterDate.TextAlign = ContentAlignment.MiddleRight;
        chkFilterDate.UseVisualStyleBackColor = true;
        chkFilterDate.CheckedChanged += chkFilterDate_CheckedChanged;
        // 
        // dtpFilter
        // 
        dtpFilter.Dock = DockStyle.Right;
        dtpFilter.Font = new Font("Segoe UI", 9F);
        dtpFilter.Format = DateTimePickerFormat.Short;
        dtpFilter.Location = new Point(840, 10);
        dtpFilter.Name = "dtpFilter";
        dtpFilter.Size = new Size(110, 23);
        dtpFilter.TabIndex = 3;
        dtpFilter.Value = new DateTime(2026, 10, 11, 0, 0, 0, 0);
        dtpFilter.Visible = false;
        dtpFilter.ValueChanged += dtpFilter_ValueChanged;
        // 
        // btnViewDetail
        // 
        btnViewDetail.BackColor = Color.FromArgb(37, 99, 235);
        btnViewDetail.Cursor = Cursors.Hand;
        btnViewDetail.Dock = DockStyle.Right;
        btnViewDetail.FlatAppearance.BorderSize = 0;
        btnViewDetail.FlatStyle = FlatStyle.Flat;
        btnViewDetail.Font = new Font("Segoe UI", 9F);
        btnViewDetail.ForeColor = Color.White;
        btnViewDetail.Location = new Point(950, 10);
        btnViewDetail.Margin = new Padding(4, 0, 0, 0);
        btnViewDetail.Name = "btnViewDetail";
        btnViewDetail.Size = new Size(84, 50);
        btnViewDetail.TabIndex = 4;
        btnViewDetail.Text = "View Detail";
        btnViewDetail.UseVisualStyleBackColor = false;
        btnViewDetail.Click += btnViewDetail_Click;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(16, 10);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(200, 50);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "📋  All Orders";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlLegend
        // 
        pnlLegend.BackColor = Color.FromArgb(15, 23, 42);
        pnlLegend.Controls.Add(lblDotCancelled);
        pnlLegend.Controls.Add(lblCancelled);
        pnlLegend.Controls.Add(lblDotClaimed);
        pnlLegend.Controls.Add(lblClaimed);
        pnlLegend.Controls.Add(lblDotReady);
        pnlLegend.Controls.Add(lblReady);
        pnlLegend.Controls.Add(lblDotDrying);
        pnlLegend.Controls.Add(lblDrying);
        pnlLegend.Controls.Add(lblDotWashing);
        pnlLegend.Controls.Add(lblWashing);
        pnlLegend.Dock = DockStyle.Top;
        pnlLegend.Location = new Point(0, 60);
        pnlLegend.Name = "pnlLegend";
        pnlLegend.Padding = new Padding(16, 4, 0, 0);
        pnlLegend.Size = new Size(1050, 28);
        pnlLegend.TabIndex = 1;
        // 
        // lblDotCancelled
        // 
        lblDotCancelled.AutoSize = true;
        lblDotCancelled.Font = new Font("Segoe UI", 9F);
        lblDotCancelled.ForeColor = Color.FromArgb(248, 113, 113);
        lblDotCancelled.Location = new Point(496, 4);
        lblDotCancelled.Name = "lblDotCancelled";
        lblDotCancelled.Size = new Size(15, 15);
        lblDotCancelled.TabIndex = 8;
        lblDotCancelled.Text = "●";
        // 
        // lblCancelled
        // 
        lblCancelled.AutoSize = true;
        lblCancelled.Font = new Font("Segoe UI", 8.5F);
        lblCancelled.ForeColor = Color.FromArgb(148, 163, 184);
        lblCancelled.Location = new Point(514, 4);
        lblCancelled.Name = "lblCancelled";
        lblCancelled.Size = new Size(59, 15);
        lblCancelled.TabIndex = 9;
        lblCancelled.Text = "Cancelled";
        // 
        // lblDotClaimed
        // 
        lblDotClaimed.AutoSize = true;
        lblDotClaimed.Font = new Font("Segoe UI", 9F);
        lblDotClaimed.ForeColor = Color.FromArgb(134, 239, 172);
        lblDotClaimed.Location = new Point(376, 4);
        lblDotClaimed.Name = "lblDotClaimed";
        lblDotClaimed.Size = new Size(15, 15);
        lblDotClaimed.TabIndex = 6;
        lblDotClaimed.Text = "●";
        // 
        // lblClaimed
        // 
        lblClaimed.AutoSize = true;
        lblClaimed.Font = new Font("Segoe UI", 8.5F);
        lblClaimed.ForeColor = Color.FromArgb(148, 163, 184);
        lblClaimed.Location = new Point(394, 4);
        lblClaimed.Name = "lblClaimed";
        lblClaimed.Size = new Size(51, 15);
        lblClaimed.TabIndex = 7;
        lblClaimed.Text = "Claimed";
        // 
        // lblDotReady
        // 
        lblDotReady.AutoSize = true;
        lblDotReady.Font = new Font("Segoe UI", 9F);
        lblDotReady.ForeColor = Color.FromArgb(52, 211, 153);
        lblDotReady.Location = new Point(256, 4);
        lblDotReady.Name = "lblDotReady";
        lblDotReady.Size = new Size(15, 15);
        lblDotReady.TabIndex = 4;
        lblDotReady.Text = "●";
        // 
        // lblReady
        // 
        lblReady.AutoSize = true;
        lblReady.Font = new Font("Segoe UI", 8.5F);
        lblReady.ForeColor = Color.FromArgb(148, 163, 184);
        lblReady.Location = new Point(274, 4);
        lblReady.Name = "lblReady";
        lblReady.Size = new Size(96, 15);
        lblReady.TabIndex = 5;
        lblReady.Text = "Ready for Pickup";
        // 
        // lblDotDrying
        // 
        lblDotDrying.AutoSize = true;
        lblDotDrying.Font = new Font("Segoe UI", 9F);
        lblDotDrying.ForeColor = Color.FromArgb(96, 165, 250);
        lblDotDrying.Location = new Point(136, 4);
        lblDotDrying.Name = "lblDotDrying";
        lblDotDrying.Size = new Size(15, 15);
        lblDotDrying.TabIndex = 2;
        lblDotDrying.Text = "●";
        // 
        // lblDrying
        // 
        lblDrying.AutoSize = true;
        lblDrying.Font = new Font("Segoe UI", 8.5F);
        lblDrying.ForeColor = Color.FromArgb(148, 163, 184);
        lblDrying.Location = new Point(154, 4);
        lblDrying.Name = "lblDrying";
        lblDrying.Size = new Size(42, 15);
        lblDrying.TabIndex = 3;
        lblDrying.Text = "Drying";
        // 
        // lblDotWashing
        // 
        lblDotWashing.AutoSize = true;
        lblDotWashing.Font = new Font("Segoe UI", 9F);
        lblDotWashing.ForeColor = Color.FromArgb(251, 191, 36);
        lblDotWashing.Location = new Point(16, 4);
        lblDotWashing.Name = "lblDotWashing";
        lblDotWashing.Size = new Size(15, 15);
        lblDotWashing.TabIndex = 0;
        lblDotWashing.Text = "●";
        // 
        // lblWashing
        // 
        lblWashing.AutoSize = true;
        lblWashing.Font = new Font("Segoe UI", 8.5F);
        lblWashing.ForeColor = Color.FromArgb(148, 163, 184);
        lblWashing.Location = new Point(34, 4);
        lblWashing.Name = "lblWashing";
        lblWashing.Size = new Size(54, 15);
        lblWashing.TabIndex = 1;
        lblWashing.Text = "Washing";
        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor = Color.FromArgb(30, 41, 59);
        dgvOrders.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(96, 165, 250);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvOrders.ColumnHeadersHeight = 34;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.Padding = new Padding(4);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(37, 99, 235);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.GridColor = Color.FromArgb(51, 65, 85);
        dgvOrders.Location = new Point(0, 88);
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.RowTemplate.Height = 30;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(1050, 552);
        dgvOrders.TabIndex = 2;
        dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
        dgvOrders.CellFormatting += DgvOrders_CellFormatting;
        // 
        // FrmOrderList
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(1050, 640);
        Controls.Add(dgvOrders);
        Controls.Add(pnlLegend);
        Controls.Add(pnlTopBar);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        MinimumSize = new Size(800, 500);
        Name = "FrmOrderList";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Order List";
        pnlTopBar.ResumeLayout(false);
        pnlTopBar.PerformLayout();
        pnlLegend.ResumeLayout(false);
        pnlLegend.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTopBar;
    private Label lblTitle;
    private TextBox txtSearch;
    private CheckBox chkFilterDate;
    private DateTimePicker dtpFilter;
    private Button btnViewDetail;
    private Panel pnlLegend;
    private Label lblDotWashing;
    private Label lblWashing;
    private Label lblDotDrying;
    private Label lblDrying;
    private Label lblDotReady;
    private Label lblReady;
    private Label lblDotClaimed;
    private Label lblClaimed;
    private Label lblDotCancelled;
    private Label lblCancelled;
    private DataGridView dgvOrders;
}
