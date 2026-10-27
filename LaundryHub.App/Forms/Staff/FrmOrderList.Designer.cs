using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using FlowLayoutPanel = System.Windows.Forms.FlowLayoutPanel;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

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
        pnlTopBar = new Panel();
        pnlSearch = new Panel();
        txtSearch = new HopeTextBox();
        flpActions = new FlowLayoutPanel();
        chkFilterDate = new CheckBox();
        dtpFilter = new DateTimePicker();
        btnViewDetail = new HopeButton();
        lblTitle = new Label();
        flpLegend = new FlowLayoutPanel();
        lblLegendTitle = new Label();
        lblDotWashing = new Label();
        lblWashing = new Label();
        lblDotDrying = new Label();
        lblDrying = new Label();
        lblDotReady = new Label();
        lblReady = new Label();
        lblDotClaimed = new Label();
        lblClaimed = new Label();
        lblDotCancelled = new Label();
        lblCancelled = new Label();
        dgvOrders = new DataGridView();
        pnlTopBar.SuspendLayout();
        pnlSearch.SuspendLayout();
        flpActions.SuspendLayout();
        flpLegend.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        SuspendLayout();
        // 
        // pnlTopBar
        // 
        pnlTopBar.BackColor = Color.FromArgb(17, 24, 68);
        pnlTopBar.Controls.Add(pnlSearch);
        pnlTopBar.Controls.Add(flpActions);
        pnlTopBar.Controls.Add(lblTitle);
        pnlTopBar.Dock = DockStyle.Top;
        pnlTopBar.Location = new Point(0, 0);
        pnlTopBar.Name = "pnlTopBar";
        pnlTopBar.Padding = new Padding(20, 14, 20, 14);
        pnlTopBar.Size = new Size(1100, 68);
        pnlTopBar.TabIndex = 0;
        // 
        // pnlSearch
        // 
        pnlSearch.Controls.Add(txtSearch);
        pnlSearch.Dock = DockStyle.Fill;
        pnlSearch.Location = new Point(200, 14);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Padding = new Padding(16, 1, 16, 1);
        pnlSearch.Size = new Size(490, 40);
        pnlSearch.TabIndex = 1;
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.White;
        txtSearch.BaseColor = Color.White;
        txtSearch.BorderColorA = Color.FromArgb(75, 86, 148);
        txtSearch.BorderColorB = Color.FromArgb(203, 213, 225);
        txtSearch.Dock = DockStyle.Fill;
        txtSearch.Font = new Font("Segoe UI", 9.5F);
        txtSearch.ForeColor = Color.FromArgb(17, 24, 68);
        txtSearch.Hint = "Search by order #, customer, service...";
        txtSearch.Location = new Point(16, 1);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(458, 38);
        txtSearch.TabIndex = 0;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // flpActions
        // 
        flpActions.AutoSize = true;
        flpActions.Controls.Add(chkFilterDate);
        flpActions.Controls.Add(dtpFilter);
        flpActions.Controls.Add(btnViewDetail);
        flpActions.Dock = DockStyle.Right;
        flpActions.FlowDirection = FlowDirection.LeftToRight;
        flpActions.Location = new Point(690, 14);
        flpActions.Name = "flpActions";
        flpActions.Size = new Size(390, 40);
        flpActions.TabIndex = 2;
        flpActions.WrapContents = false;
        // 
        // chkFilterDate
        // 
        chkFilterDate.AutoSize = true;
        chkFilterDate.Cursor = Cursors.Hand;
        chkFilterDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        chkFilterDate.ForeColor = Color.FromArgb(226, 232, 240);
        chkFilterDate.Location = new Point(0, 9);
        chkFilterDate.Margin = new Padding(0, 9, 8, 0);
        chkFilterDate.Name = "chkFilterDate";
        chkFilterDate.Size = new Size(111, 24);
        chkFilterDate.TabIndex = 0;
        chkFilterDate.Text = "Filter date:";
        chkFilterDate.UseVisualStyleBackColor = true;
        chkFilterDate.CheckedChanged += chkFilterDate_CheckedChanged;
        // 
        // dtpFilter
        // 
        dtpFilter.Font = new Font("Segoe UI", 9F);
        dtpFilter.Format = DateTimePickerFormat.Short;
        dtpFilter.Location = new Point(122, 6);
        dtpFilter.Margin = new Padding(3, 6, 12, 0);
        dtpFilter.Name = "dtpFilter";
        dtpFilter.Size = new Size(115, 27);
        dtpFilter.TabIndex = 1;
        dtpFilter.Visible = false;
        dtpFilter.ValueChanged += dtpFilter_ValueChanged;
        // 
        // btnViewDetail
        // 
        btnViewDetail.ButtonType = HopeButtonType.Primary;
        btnViewDetail.Cursor = Cursors.Hand;
        btnViewDetail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnViewDetail.HoverTextColor = Color.White;
        btnViewDetail.Location = new Point(252, 1);
        btnViewDetail.Margin = new Padding(3, 1, 0, 0);
        btnViewDetail.Name = "btnViewDetail";
        btnViewDetail.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnViewDetail.Size = new Size(135, 38);
        btnViewDetail.TabIndex = 2;
        btnViewDetail.Text = "Manage Order";
        btnViewDetail.TextColor = Color.White;
        btnViewDetail.Click += btnViewDetail_Click;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(20, 14);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(180, 40);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "All Orders";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // flpLegend
        // 
        flpLegend.BackColor = Color.FromArgb(24, 32, 78);
        flpLegend.Controls.Add(lblLegendTitle);
        flpLegend.Controls.Add(lblDotWashing);
        flpLegend.Controls.Add(lblWashing);
        flpLegend.Controls.Add(lblDotDrying);
        flpLegend.Controls.Add(lblDrying);
        flpLegend.Controls.Add(lblDotReady);
        flpLegend.Controls.Add(lblReady);
        flpLegend.Controls.Add(lblDotClaimed);
        flpLegend.Controls.Add(lblClaimed);
        flpLegend.Controls.Add(lblDotCancelled);
        flpLegend.Controls.Add(lblCancelled);
        flpLegend.Dock = DockStyle.Top;
        flpLegend.FlowDirection = FlowDirection.LeftToRight;
        flpLegend.Location = new Point(0, 68);
        flpLegend.Name = "flpLegend";
        flpLegend.Padding = new Padding(20, 8, 20, 8);
        flpLegend.Size = new Size(1100, 36);
        flpLegend.TabIndex = 1;
        flpLegend.WrapContents = false;
        // 
        // lblLegendTitle
        // 
        lblLegendTitle.AutoSize = true;
        lblLegendTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblLegendTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblLegendTitle.Location = new Point(20, 8);
        lblLegendTitle.Margin = new Padding(0, 0, 16, 0);
        lblLegendTitle.Name = "lblLegendTitle";
        lblLegendTitle.Size = new Size(67, 20);
        lblLegendTitle.TabIndex = 0;
        lblLegendTitle.Text = "STATUS:";
        // 
        // lblDotWashing
        // 
        lblDotWashing.AutoSize = true;
        lblDotWashing.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblDotWashing.ForeColor = Color.FromArgb(129, 140, 248);
        lblDotWashing.Location = new Point(103, 8);
        lblDotWashing.Margin = new Padding(0, 0, 4, 0);
        lblDotWashing.Name = "lblDotWashing";
        lblDotWashing.Size = new Size(20, 20);
        lblDotWashing.TabIndex = 1;
        lblDotWashing.Text = "●";
        // 
        // lblWashing
        // 
        lblWashing.AutoSize = true;
        lblWashing.Font = new Font("Segoe UI", 8.5F);
        lblWashing.ForeColor = Color.FromArgb(226, 232, 240);
        lblWashing.Location = new Point(127, 8);
        lblWashing.Margin = new Padding(0, 0, 20, 0);
        lblWashing.Name = "lblWashing";
        lblWashing.Size = new Size(66, 20);
        lblWashing.TabIndex = 2;
        lblWashing.Text = "Washing";
        // 
        // lblDotDrying
        // 
        lblDotDrying.AutoSize = true;
        lblDotDrying.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblDotDrying.ForeColor = Color.FromArgb(148, 163, 184);
        lblDotDrying.Location = new Point(213, 8);
        lblDotDrying.Margin = new Padding(0, 0, 4, 0);
        lblDotDrying.Name = "lblDotDrying";
        lblDotDrying.Size = new Size(20, 20);
        lblDotDrying.TabIndex = 3;
        lblDotDrying.Text = "●";
        // 
        // lblDrying
        // 
        lblDrying.AutoSize = true;
        lblDrying.Font = new Font("Segoe UI", 8.5F);
        lblDrying.ForeColor = Color.FromArgb(226, 232, 240);
        lblDrying.Location = new Point(237, 8);
        lblDrying.Margin = new Padding(0, 0, 20, 0);
        lblDrying.Name = "lblDrying";
        lblDrying.Size = new Size(53, 20);
        lblDrying.TabIndex = 4;
        lblDrying.Text = "Drying";
        // 
        // lblDotReady
        // 
        lblDotReady.AutoSize = true;
        lblDotReady.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblDotReady.ForeColor = Color.FromArgb(74, 222, 128);
        lblDotReady.Location = new Point(310, 8);
        lblDotReady.Margin = new Padding(0, 0, 4, 0);
        lblDotReady.Name = "lblDotReady";
        lblDotReady.Size = new Size(20, 20);
        lblDotReady.TabIndex = 5;
        lblDotReady.Text = "●";
        // 
        // lblReady
        // 
        lblReady.AutoSize = true;
        lblReady.Font = new Font("Segoe UI", 8.5F);
        lblReady.ForeColor = Color.FromArgb(226, 232, 240);
        lblReady.Location = new Point(334, 8);
        lblReady.Margin = new Padding(0, 0, 20, 0);
        lblReady.Name = "lblReady";
        lblReady.Size = new Size(120, 20);
        lblReady.TabIndex = 6;
        lblReady.Text = "Ready for Pickup";
        // 
        // lblDotClaimed
        // 
        lblDotClaimed.AutoSize = true;
        lblDotClaimed.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblDotClaimed.ForeColor = Color.FromArgb(148, 163, 184);
        lblDotClaimed.Location = new Point(474, 8);
        lblDotClaimed.Margin = new Padding(0, 0, 4, 0);
        lblDotClaimed.Name = "lblDotClaimed";
        lblDotClaimed.Size = new Size(20, 20);
        lblDotClaimed.TabIndex = 7;
        lblDotClaimed.Text = "●";
        // 
        // lblClaimed
        // 
        lblClaimed.AutoSize = true;
        lblClaimed.Font = new Font("Segoe UI", 8.5F);
        lblClaimed.ForeColor = Color.FromArgb(226, 232, 240);
        lblClaimed.Location = new Point(498, 8);
        lblClaimed.Margin = new Padding(0, 0, 20, 0);
        lblClaimed.Name = "lblClaimed";
        lblClaimed.Size = new Size(64, 20);
        lblClaimed.TabIndex = 8;
        lblClaimed.Text = "Claimed";
        // 
        // lblDotCancelled
        // 
        lblDotCancelled.AutoSize = true;
        lblDotCancelled.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblDotCancelled.ForeColor = Color.FromArgb(248, 113, 113);
        lblDotCancelled.Location = new Point(582, 8);
        lblDotCancelled.Margin = new Padding(0, 0, 4, 0);
        lblDotCancelled.Name = "lblDotCancelled";
        lblDotCancelled.Size = new Size(20, 20);
        lblDotCancelled.TabIndex = 9;
        lblDotCancelled.Text = "●";
        // 
        // lblCancelled
        // 
        lblCancelled.AutoSize = true;
        lblCancelled.Font = new Font("Segoe UI", 8.5F);
        lblCancelled.ForeColor = Color.FromArgb(226, 232, 240);
        lblCancelled.Location = new Point(606, 8);
        lblCancelled.Margin = new Padding(0);
        lblCancelled.Name = "lblCancelled";
        lblCancelled.Size = new Size(74, 20);
        lblCancelled.TabIndex = 10;
        lblCancelled.Text = "Cancelled";
        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor = Color.White;
        dgvOrders.BorderStyle = BorderStyle.None;
        dgvOrders.ColumnHeadersHeight = 42;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.GridColor = Color.FromArgb(234, 224, 207);
        dgvOrders.Location = new Point(0, 104);
        dgvOrders.MultiSelect = false;
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.RowTemplate.Height = 40;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(1100, 576);
        dgvOrders.TabIndex = 2;
        dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
        dgvOrders.CellFormatting += DgvOrders_CellFormatting;
        // 
        // FrmOrderList
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1100, 680);
        Controls.Add(dgvOrders);
        Controls.Add(flpLegend);
        Controls.Add(pnlTopBar);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(75, 86, 148);
        MinimumSize = new Size(950, 550);
        Name = "FrmOrderList";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Order List";
        pnlTopBar.ResumeLayout(false);
        pnlTopBar.PerformLayout();
        pnlSearch.ResumeLayout(false);
        flpActions.ResumeLayout(false);
        flpActions.PerformLayout();
        flpLegend.ResumeLayout(false);
        flpLegend.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTopBar;
    private Label lblTitle;
    private Panel pnlSearch;
    private HopeTextBox txtSearch;
    private FlowLayoutPanel flpActions;
    private CheckBox chkFilterDate;
    private DateTimePicker dtpFilter;
    private HopeButton btnViewDetail;
    private FlowLayoutPanel flpLegend;
    private Label lblLegendTitle;
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
