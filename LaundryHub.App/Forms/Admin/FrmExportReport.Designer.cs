namespace LaundryHub.App.Forms.Admin;

partial class FrmExportReport
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
        pnlGridWrap = new Panel();
        dgvPreview = new DataGridView();
        lblGridLabel = new Label();
        flpStats = new FlowLayoutPanel();
        pnlStatOrders = new Panel();
        lblTotalOrders = new Label();
        lblOrdersTitle = new Label();
        pnlStripOrders = new Panel();
        pnlStatPending = new Panel();
        lblPending = new Label();
        lblPendingTitle = new Label();
        pnlStripPending = new Panel();
        pnlStatClaimed = new Panel();
        lblClaimed = new Label();
        lblClaimedTitle = new Label();
        pnlStripClaimed = new Panel();
        pnlStatSales = new Panel();
        lblSales = new Label();
        lblSalesTitle = new Label();
        pnlStripSales = new Panel();
        pnlFilterBar = new Panel();
        btnExportExcel = new Button();
        btnLoad = new Button();
        dtpDate = new DateTimePicker();
        lblSelectDate = new Label();
        pnlHeader.SuspendLayout();
        pnlContainer.SuspendLayout();
        pnlGridWrap.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
        flpStats.SuspendLayout();
        pnlStatOrders.SuspendLayout();
        pnlStatPending.SuspendLayout();
        pnlStatClaimed.SuspendLayout();
        pnlStatSales.SuspendLayout();
        pnlFilterBar.SuspendLayout();
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
        lblTitle.Size = new Size(450, 65);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "📊 Daily Laundry Business Report";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlContainer
        // 
        pnlContainer.Controls.Add(pnlGridWrap);
        pnlContainer.Controls.Add(lblGridLabel);
        pnlContainer.Controls.Add(flpStats);
        pnlContainer.Controls.Add(pnlFilterBar);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 65);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(24);
        pnlContainer.Size = new Size(950, 575);
        pnlContainer.TabIndex = 1;
        // 
        // pnlGridWrap
        // 
        pnlGridWrap.Controls.Add(dgvPreview);
        pnlGridWrap.Dock = DockStyle.Fill;
        pnlGridWrap.Location = new Point(24, 201);
        pnlGridWrap.Name = "pnlGridWrap";
        pnlGridWrap.Padding = new Padding(0, 6, 0, 0);
        pnlGridWrap.Size = new Size(902, 350);
        pnlGridWrap.TabIndex = 3;
        // 
        // dgvPreview
        // 
        dgvPreview.AllowUserToAddRows = false;
        dgvPreview.AllowUserToDeleteRows = false;
        dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPreview.BackgroundColor = Color.FromArgb(30, 41, 59);
        dgvPreview.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(148, 163, 184);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(37, 99, 235);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvPreview.DefaultCellStyle = dataGridViewCellStyle2;
        dgvPreview.Dock = DockStyle.Fill;
        dgvPreview.EnableHeadersVisualStyles = false;
        dgvPreview.GridColor = Color.FromArgb(51, 65, 85);
        dgvPreview.Location = new Point(0, 6);
        dgvPreview.Name = "dgvPreview";
        dgvPreview.ReadOnly = true;
        dgvPreview.RowHeadersVisible = false;
        dgvPreview.RowTemplate.Height = 36;
        dgvPreview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPreview.Size = new Size(902, 344);
        dgvPreview.TabIndex = 0;
        // 
        // lblGridLabel
        // 
        lblGridLabel.Dock = DockStyle.Top;
        lblGridLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblGridLabel.ForeColor = Color.White;
        lblGridLabel.Location = new Point(24, 169);
        lblGridLabel.Name = "lblGridLabel";
        lblGridLabel.Size = new Size(902, 32);
        lblGridLabel.TabIndex = 2;
        lblGridLabel.Text = "Report Orders Breakdown Preview";
        lblGridLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // flpStats
        // 
        flpStats.Controls.Add(pnlStatOrders);
        flpStats.Controls.Add(pnlStatPending);
        flpStats.Controls.Add(pnlStatClaimed);
        flpStats.Controls.Add(pnlStatSales);
        flpStats.Dock = DockStyle.Top;
        flpStats.Location = new Point(24, 74);
        flpStats.Name = "flpStats";
        flpStats.Padding = new Padding(0, 10, 0, 5);
        flpStats.Size = new Size(902, 95);
        flpStats.TabIndex = 1;
        // 
        // pnlStatOrders
        // 
        pnlStatOrders.BackColor = Color.FromArgb(30, 41, 59);
        pnlStatOrders.Controls.Add(lblTotalOrders);
        pnlStatOrders.Controls.Add(lblOrdersTitle);
        pnlStatOrders.Controls.Add(pnlStripOrders);
        pnlStatOrders.Location = new Point(0, 10);
        pnlStatOrders.Margin = new Padding(0, 0, 12, 0);
        pnlStatOrders.Name = "pnlStatOrders";
        pnlStatOrders.Padding = new Padding(14, 10, 14, 10);
        pnlStatOrders.Size = new Size(210, 80);
        pnlStatOrders.TabIndex = 0;
        // 
        // lblTotalOrders
        // 
        lblTotalOrders.Dock = DockStyle.Fill;
        lblTotalOrders.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTotalOrders.ForeColor = Color.White;
        lblTotalOrders.Location = new Point(18, 28);
        lblTotalOrders.Name = "lblTotalOrders";
        lblTotalOrders.Size = new Size(178, 42);
        lblTotalOrders.TabIndex = 2;
        lblTotalOrders.Text = "0";
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.Dock = DockStyle.Top;
        lblOrdersTitle.Font = new Font("Segoe UI", 8.5F);
        lblOrdersTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblOrdersTitle.Location = new Point(18, 10);
        lblOrdersTitle.Name = "lblOrdersTitle";
        lblOrdersTitle.Size = new Size(178, 18);
        lblOrdersTitle.TabIndex = 1;
        lblOrdersTitle.Text = "Total Orders";
        // 
        // pnlStripOrders
        // 
        pnlStripOrders.BackColor = Color.FromArgb(59, 130, 246);
        pnlStripOrders.Dock = DockStyle.Left;
        pnlStripOrders.Location = new Point(14, 10);
        pnlStripOrders.Name = "pnlStripOrders";
        pnlStripOrders.Size = new Size(4, 60);
        pnlStripOrders.TabIndex = 0;
        // 
        // pnlStatPending
        // 
        pnlStatPending.BackColor = Color.FromArgb(30, 41, 59);
        pnlStatPending.Controls.Add(lblPending);
        pnlStatPending.Controls.Add(lblPendingTitle);
        pnlStatPending.Controls.Add(pnlStripPending);
        pnlStatPending.Location = new Point(222, 10);
        pnlStatPending.Margin = new Padding(0, 0, 12, 0);
        pnlStatPending.Name = "pnlStatPending";
        pnlStatPending.Padding = new Padding(14, 10, 14, 10);
        pnlStatPending.Size = new Size(210, 80);
        pnlStatPending.TabIndex = 1;
        // 
        // lblPending
        // 
        lblPending.Dock = DockStyle.Fill;
        lblPending.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblPending.ForeColor = Color.White;
        lblPending.Location = new Point(18, 28);
        lblPending.Name = "lblPending";
        lblPending.Size = new Size(178, 42);
        lblPending.TabIndex = 2;
        lblPending.Text = "0";
        // 
        // lblPendingTitle
        // 
        lblPendingTitle.Dock = DockStyle.Top;
        lblPendingTitle.Font = new Font("Segoe UI", 8.5F);
        lblPendingTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblPendingTitle.Location = new Point(18, 10);
        lblPendingTitle.Name = "lblPendingTitle";
        lblPendingTitle.Size = new Size(178, 18);
        lblPendingTitle.TabIndex = 1;
        lblPendingTitle.Text = "Pending / In-Process";
        // 
        // pnlStripPending
        // 
        pnlStripPending.BackColor = Color.FromArgb(245, 158, 11);
        pnlStripPending.Dock = DockStyle.Left;
        pnlStripPending.Location = new Point(14, 10);
        pnlStripPending.Name = "pnlStripPending";
        pnlStripPending.Size = new Size(4, 60);
        pnlStripPending.TabIndex = 0;
        // 
        // pnlStatClaimed
        // 
        pnlStatClaimed.BackColor = Color.FromArgb(30, 41, 59);
        pnlStatClaimed.Controls.Add(lblClaimed);
        pnlStatClaimed.Controls.Add(lblClaimedTitle);
        pnlStatClaimed.Controls.Add(pnlStripClaimed);
        pnlStatClaimed.Location = new Point(444, 10);
        pnlStatClaimed.Margin = new Padding(0, 0, 12, 0);
        pnlStatClaimed.Name = "pnlStatClaimed";
        pnlStatClaimed.Padding = new Padding(14, 10, 14, 10);
        pnlStatClaimed.Size = new Size(210, 80);
        pnlStatClaimed.TabIndex = 2;
        // 
        // lblClaimed
        // 
        lblClaimed.Dock = DockStyle.Fill;
        lblClaimed.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblClaimed.ForeColor = Color.White;
        lblClaimed.Location = new Point(18, 28);
        lblClaimed.Name = "lblClaimed";
        lblClaimed.Size = new Size(178, 42);
        lblClaimed.TabIndex = 2;
        lblClaimed.Text = "0";
        // 
        // lblClaimedTitle
        // 
        lblClaimedTitle.Dock = DockStyle.Top;
        lblClaimedTitle.Font = new Font("Segoe UI", 8.5F);
        lblClaimedTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblClaimedTitle.Location = new Point(18, 10);
        lblClaimedTitle.Name = "lblClaimedTitle";
        lblClaimedTitle.Size = new Size(178, 18);
        lblClaimedTitle.TabIndex = 1;
        lblClaimedTitle.Text = "Claimed Orders";
        // 
        // pnlStripClaimed
        // 
        pnlStripClaimed.BackColor = Color.FromArgb(16, 185, 129);
        pnlStripClaimed.Dock = DockStyle.Left;
        pnlStripClaimed.Location = new Point(14, 10);
        pnlStripClaimed.Name = "pnlStripClaimed";
        pnlStripClaimed.Size = new Size(4, 60);
        pnlStripClaimed.TabIndex = 0;
        // 
        // pnlStatSales
        // 
        pnlStatSales.BackColor = Color.FromArgb(30, 41, 59);
        pnlStatSales.Controls.Add(lblSales);
        pnlStatSales.Controls.Add(lblSalesTitle);
        pnlStatSales.Controls.Add(pnlStripSales);
        pnlStatSales.Location = new Point(666, 10);
        pnlStatSales.Margin = new Padding(0, 0, 12, 0);
        pnlStatSales.Name = "pnlStatSales";
        pnlStatSales.Padding = new Padding(14, 10, 14, 10);
        pnlStatSales.Size = new Size(210, 80);
        pnlStatSales.TabIndex = 3;
        // 
        // lblSales
        // 
        lblSales.Dock = DockStyle.Fill;
        lblSales.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblSales.ForeColor = Color.White;
        lblSales.Location = new Point(18, 28);
        lblSales.Name = "lblSales";
        lblSales.Size = new Size(178, 42);
        lblSales.TabIndex = 2;
        lblSales.Text = "₱0.00";
        // 
        // lblSalesTitle
        // 
        lblSalesTitle.Dock = DockStyle.Top;
        lblSalesTitle.Font = new Font("Segoe UI", 8.5F);
        lblSalesTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblSalesTitle.Location = new Point(18, 10);
        lblSalesTitle.Name = "lblSalesTitle";
        lblSalesTitle.Size = new Size(178, 18);
        lblSalesTitle.TabIndex = 1;
        lblSalesTitle.Text = "Day's Total Sales";
        // 
        // pnlStripSales
        // 
        pnlStripSales.BackColor = Color.FromArgb(139, 92, 246);
        pnlStripSales.Dock = DockStyle.Left;
        pnlStripSales.Location = new Point(14, 10);
        pnlStripSales.Name = "pnlStripSales";
        pnlStripSales.Size = new Size(4, 60);
        pnlStripSales.TabIndex = 0;
        // 
        // pnlFilterBar
        // 
        pnlFilterBar.BackColor = Color.FromArgb(30, 41, 59);
        pnlFilterBar.Controls.Add(btnExportExcel);
        pnlFilterBar.Controls.Add(btnLoad);
        pnlFilterBar.Controls.Add(dtpDate);
        pnlFilterBar.Controls.Add(lblSelectDate);
        pnlFilterBar.Dock = DockStyle.Top;
        pnlFilterBar.Location = new Point(24, 24);
        pnlFilterBar.Name = "pnlFilterBar";
        pnlFilterBar.Padding = new Padding(16, 8, 16, 8);
        pnlFilterBar.Size = new Size(902, 50);
        pnlFilterBar.TabIndex = 0;
        // 
        // btnExportExcel
        // 
        btnExportExcel.BackColor = Color.FromArgb(16, 185, 129);
        btnExportExcel.Cursor = Cursors.Hand;
        btnExportExcel.Dock = DockStyle.Right;
        btnExportExcel.FlatAppearance.BorderSize = 0;
        btnExportExcel.FlatStyle = FlatStyle.Flat;
        btnExportExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnExportExcel.ForeColor = Color.White;
        btnExportExcel.Location = new Point(686, 8);
        btnExportExcel.Name = "btnExportExcel";
        btnExportExcel.Size = new Size(200, 34);
        btnExportExcel.TabIndex = 3;
        btnExportExcel.Text = "📥 Export to Excel (.xlsx)";
        btnExportExcel.UseVisualStyleBackColor = false;
        btnExportExcel.Click += btnExportExcel_Click;
        // 
        // btnLoad
        // 
        btnLoad.BackColor = Color.FromArgb(51, 65, 85);
        btnLoad.Cursor = Cursors.Hand;
        btnLoad.Dock = DockStyle.Left;
        btnLoad.FlatAppearance.BorderSize = 0;
        btnLoad.FlatStyle = FlatStyle.Flat;
        btnLoad.ForeColor = Color.White;
        btnLoad.Location = new Point(230, 8);
        btnLoad.Margin = new Padding(12, 0, 0, 0);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(130, 34);
        btnLoad.TabIndex = 2;
        btnLoad.Text = "🔄 Refresh Date";
        btnLoad.UseVisualStyleBackColor = false;
        btnLoad.Click += btnLoad_Click;
        // 
        // dtpDate
        // 
        dtpDate.Dock = DockStyle.Left;
        dtpDate.Font = new Font("Segoe UI", 10F);
        dtpDate.Format = DateTimePickerFormat.Short;
        dtpDate.Location = new Point(90, 8);
        dtpDate.Name = "dtpDate";
        dtpDate.Size = new Size(140, 25);
        dtpDate.TabIndex = 1;
        // 
        // lblSelectDate
        // 
        lblSelectDate.Dock = DockStyle.Left;
        lblSelectDate.ForeColor = Color.FromArgb(148, 163, 184);
        lblSelectDate.Location = new Point(16, 8);
        lblSelectDate.Name = "lblSelectDate";
        lblSelectDate.Size = new Size(74, 34);
        lblSelectDate.TabIndex = 0;
        lblSelectDate.Text = "Report Date:";
        lblSelectDate.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // FrmExportReport
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(950, 640);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmExportReport";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub – Daily Reports & Excel Export";
        pnlHeader.ResumeLayout(false);
        pnlContainer.ResumeLayout(false);
        pnlGridWrap.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
        flpStats.ResumeLayout(false);
        pnlStatOrders.ResumeLayout(false);
        pnlStatPending.ResumeLayout(false);
        pnlStatClaimed.ResumeLayout(false);
        pnlStatSales.ResumeLayout(false);
        pnlFilterBar.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblTitle;
    private Button btnClose;
    private Panel pnlContainer;
    private Panel pnlFilterBar;
    private Label lblSelectDate;
    private DateTimePicker dtpDate;
    private Button btnLoad;
    private Button btnExportExcel;
    private FlowLayoutPanel flpStats;
    private Panel pnlStatOrders;
    private Panel pnlStripOrders;
    private Label lblOrdersTitle;
    private Label lblTotalOrders;
    private Panel pnlStatPending;
    private Panel pnlStripPending;
    private Label lblPendingTitle;
    private Label lblPending;
    private Panel pnlStatClaimed;
    private Panel pnlStripClaimed;
    private Label lblClaimedTitle;
    private Label lblClaimed;
    private Panel pnlStatSales;
    private Panel pnlStripSales;
    private Label lblSalesTitle;
    private Label lblSales;
    private Label lblGridLabel;
    private Panel pnlGridWrap;
    private DataGridView dgvPreview;
}
