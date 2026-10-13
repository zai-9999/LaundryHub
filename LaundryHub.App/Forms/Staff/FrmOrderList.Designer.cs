using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlTopBar = new Panel();
        btnViewDetail = new HopeButton();
        dtpFilter = new DateTimePicker();
        chkFilterDate = new CheckBox();
        txtSearch = new HopeTextBox();
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
        pnlTopBar.BackColor = Color.FromArgb(102, 163, 191);
        pnlTopBar.Controls.Add(btnViewDetail);
        pnlTopBar.Controls.Add(dtpFilter);
        pnlTopBar.Controls.Add(chkFilterDate);
        pnlTopBar.Controls.Add(txtSearch);
        pnlTopBar.Controls.Add(lblTitle);
        pnlTopBar.Dock = DockStyle.Top;
        pnlTopBar.Location = new Point(0, 0);
        pnlTopBar.Name = "pnlTopBar";
        pnlTopBar.Padding = new Padding(16, 12, 16, 12);
        pnlTopBar.Size = new Size(1050, 64);
        pnlTopBar.TabIndex = 0;
        // 
        // btnViewDetail
        // 
        btnViewDetail.ButtonType = HopeButtonType.Primary;
        btnViewDetail.PrimaryColor = Color.FromArgb(51, 104, 160);
        btnViewDetail.TextColor = Color.FromArgb(242, 239, 231);
        btnViewDetail.HoverTextColor = Color.White;
        btnViewDetail.Cursor = Cursors.Hand;
        btnViewDetail.Dock = DockStyle.Right;
        btnViewDetail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnViewDetail.Location = new Point(934, 12);
        btnViewDetail.Name = "btnViewDetail";
        btnViewDetail.Size = new Size(100, 40);
        btnViewDetail.TabIndex = 4;
        btnViewDetail.Text = "View Detail";
        btnViewDetail.Click += btnViewDetail_Click;
        // 
        // dtpFilter
        // 
        dtpFilter.Dock = DockStyle.Right;
        dtpFilter.Font = new Font("Segoe UI", 9F);
        dtpFilter.Format = DateTimePickerFormat.Short;
        dtpFilter.Location = new Point(814, 12);
        dtpFilter.Name = "dtpFilter";
        dtpFilter.Size = new Size(120, 23);
        dtpFilter.TabIndex = 3;
        dtpFilter.Value = new DateTime(2026, 10, 11, 0, 0, 0, 0);
        dtpFilter.Visible = false;
        dtpFilter.ValueChanged += dtpFilter_ValueChanged;
        // 
        // chkFilterDate
        // 
        chkFilterDate.Dock = DockStyle.Right;
        chkFilterDate.Font = new Font("Segoe UI", 8.5F);
        chkFilterDate.ForeColor = Color.FromArgb(242, 239, 231);
        chkFilterDate.Location = new Point(694, 12);
        chkFilterDate.Name = "chkFilterDate";
        chkFilterDate.Size = new Size(120, 40);
        chkFilterDate.TabIndex = 2;
        chkFilterDate.Text = "Filter by date:";
        chkFilterDate.TextAlign = ContentAlignment.MiddleRight;
        chkFilterDate.UseVisualStyleBackColor = true;
        chkFilterDate.CheckedChanged += chkFilterDate_CheckedChanged;
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.White;
        txtSearch.BaseColor = Color.White;
        txtSearch.BorderColorA = Color.FromArgb(51, 104, 160);
        txtSearch.BorderColorB = Color.FromArgb(200, 223, 219);
        txtSearch.Dock = DockStyle.Fill;
        txtSearch.Font = new Font("Segoe UI", 10F);
        txtSearch.ForeColor = Color.FromArgb(51, 104, 160);
        txtSearch.Hint = "Search by order # or customer name...";
        txtSearch.Location = new Point(196, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(498, 40);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(242, 239, 231);
        lblTitle.Location = new Point(16, 12);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(180, 40);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "All Orders";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlLegend
        // 
        pnlLegend.BackColor = Color.FromArgb(242, 239, 231);
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
        pnlLegend.Location = new Point(0, 64);
        pnlLegend.Name = "pnlLegend";
        pnlLegend.Padding = new Padding(16, 4, 0, 0);
        pnlLegend.Size = new Size(1050, 28);
        pnlLegend.TabIndex = 1;
        // 
        // lblDotCancelled
        // 
        lblDotCancelled.AutoSize = true;
        lblDotCancelled.Font = new Font("Segoe UI", 9F);
        lblDotCancelled.ForeColor = Color.FromArgb(220, 53, 69);
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
        lblCancelled.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblDotClaimed.ForeColor = Color.FromArgb(108, 117, 125);
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
        lblClaimed.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblDotReady.ForeColor = Color.FromArgb(40, 167, 69);
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
        lblReady.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblDotDrying.ForeColor = Color.FromArgb(102, 163, 191);
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
        lblDrying.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblDotWashing.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblWashing.ForeColor = Color.FromArgb(51, 104, 160);
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
        dgvOrders.BackgroundColor = Color.White;
        dgvOrders.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(200, 223, 219);
        dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(200, 223, 219);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvOrders.ColumnHeadersHeight = 34;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle2.Padding = new Padding(4);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(102, 163, 191);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.GridColor = Color.FromArgb(200, 223, 219);
        dgvOrders.Location = new Point(0, 92);
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.RowTemplate.Height = 32;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(1050, 548);
        dgvOrders.TabIndex = 2;
        dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
        dgvOrders.CellFormatting += DgvOrders_CellFormatting;
        // 
        // FrmOrderList
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(242, 239, 231);
        ClientSize = new Size(1050, 640);
        Controls.Add(dgvOrders);
        Controls.Add(pnlLegend);
        Controls.Add(pnlTopBar);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(51, 104, 160);
        MinimumSize = new Size(800, 500);
        Name = "FrmOrderList";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Order List";
        pnlTopBar.ResumeLayout(false);
        pnlLegend.ResumeLayout(false);
        pnlLegend.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTopBar;
    private Label lblTitle;
    private HopeTextBox txtSearch;
    private CheckBox chkFilterDate;
    private DateTimePicker dtpFilter;
    private HopeButton btnViewDetail;
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
