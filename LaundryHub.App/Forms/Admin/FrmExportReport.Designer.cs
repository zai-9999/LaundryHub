using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using Button = System.Windows.Forms.Button;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

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
        btnClose = new HopeButton();
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
        btnExportExcel = new HopeButton();
        btnLoad = new HopeButton();
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
        pnlHeader.BackColor = Color.FromArgb(75, 86, 148);
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
        btnClose.BorderColor = Color.FromArgb(234, 224, 207);
        btnClose.ButtonType = HopeButtonType.Default;
        btnClose.Cursor = Cursors.Hand;
        btnClose.DangerColor = Color.FromArgb(245, 108, 108);
        btnClose.DefaultColor = Color.FromArgb(114, 136, 174);
        btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnClose.HoverTextColor = Color.White;
        btnClose.InfoColor = Color.FromArgb(144, 147, 153);
        btnClose.Location = new Point(836, 16);
        btnClose.Name = "btnClose";
        btnClose.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnClose.Size = new Size(90, 34);
        btnClose.SuccessColor = Color.FromArgb(103, 194, 58);
        btnClose.TabIndex = 1;
        btnClose.Text = " Close";
        btnClose.TextColor = Color.FromArgb(246, 242, 234);
        btnClose.WarningColor = Color.FromArgb(230, 162, 60);
        btnClose.Click += btnClose_Click;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(246, 242, 234);
        lblTitle.Location = new Point(24, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(450, 65);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Daily Laundry Business Report";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlContainer
        // 
        pnlContainer.BackColor = Color.FromArgb(246, 242, 234);
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
        pnlGridWrap.Location = new Point(24, 206);
        pnlGridWrap.Name = "pnlGridWrap";
        pnlGridWrap.Padding = new Padding(0, 6, 0, 0);
        pnlGridWrap.Size = new Size(902, 345);
        pnlGridWrap.TabIndex = 3;
        // 
        // dgvPreview
        // 
        dgvPreview.AllowUserToAddRows = false;
        dgvPreview.AllowUserToDeleteRows = false;
        dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPreview.BackgroundColor = Color.White;
        dgvPreview.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(75, 86, 148);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(246, 242, 234);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(75, 86, 148);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(246, 242, 234);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(75, 86, 148);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(234, 224, 207);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(75, 86, 148);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvPreview.DefaultCellStyle = dataGridViewCellStyle2;
        dgvPreview.Dock = DockStyle.Fill;
        dgvPreview.EnableHeadersVisualStyles = false;
        dgvPreview.GridColor = Color.FromArgb(234, 224, 207);
        dgvPreview.Location = new Point(0, 6);
        dgvPreview.Name = "dgvPreview";
        dgvPreview.ReadOnly = true;
        dgvPreview.RowHeadersVisible = false;
        dgvPreview.RowHeadersWidth = 51;
        dgvPreview.RowTemplate.Height = 36;
        dgvPreview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPreview.Size = new Size(902, 339);
        dgvPreview.TabIndex = 0;
        // 
        // lblGridLabel
        // 
        lblGridLabel.Dock = DockStyle.Top;
        lblGridLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblGridLabel.ForeColor = Color.FromArgb(75, 86, 148);
        lblGridLabel.Location = new Point(24, 174);
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
        flpStats.Location = new Point(24, 76);
        flpStats.Name = "flpStats";
        flpStats.Padding = new Padding(0, 8, 0, 4);
        flpStats.Size = new Size(902, 98);
        flpStats.TabIndex = 1;
        // 
        // pnlStatOrders
        // 
        pnlStatOrders.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatOrders.Controls.Add(lblTotalOrders);
        pnlStatOrders.Controls.Add(lblOrdersTitle);
        pnlStatOrders.Controls.Add(pnlStripOrders);
        pnlStatOrders.Location = new Point(0, 8);
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
        lblTotalOrders.ForeColor = Color.FromArgb(75, 86, 148);
        lblTotalOrders.Location = new Point(18, 28);
        lblTotalOrders.Name = "lblTotalOrders";
        lblTotalOrders.Size = new Size(178, 42);
        lblTotalOrders.TabIndex = 2;
        lblTotalOrders.Text = "0";
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.Dock = DockStyle.Top;
        lblOrdersTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblOrdersTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblOrdersTitle.Location = new Point(18, 10);
        lblOrdersTitle.Name = "lblOrdersTitle";
        lblOrdersTitle.Size = new Size(178, 18);
        lblOrdersTitle.TabIndex = 1;
        lblOrdersTitle.Text = "Total Orders";
        // 
        // pnlStripOrders
        // 
        pnlStripOrders.BackColor = Color.FromArgb(75, 86, 148);
        pnlStripOrders.Dock = DockStyle.Left;
        pnlStripOrders.Location = new Point(14, 10);
        pnlStripOrders.Name = "pnlStripOrders";
        pnlStripOrders.Size = new Size(4, 60);
        pnlStripOrders.TabIndex = 0;
        // 
        // pnlStatPending
        // 
        pnlStatPending.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatPending.Controls.Add(lblPending);
        pnlStatPending.Controls.Add(lblPendingTitle);
        pnlStatPending.Controls.Add(pnlStripPending);
        pnlStatPending.Location = new Point(222, 8);
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
        lblPending.ForeColor = Color.FromArgb(75, 86, 148);
        lblPending.Location = new Point(18, 28);
        lblPending.Name = "lblPending";
        lblPending.Size = new Size(178, 42);
        lblPending.TabIndex = 2;
        lblPending.Text = "0";
        // 
        // lblPendingTitle
        // 
        lblPendingTitle.Dock = DockStyle.Top;
        lblPendingTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPendingTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblPendingTitle.Location = new Point(18, 10);
        lblPendingTitle.Name = "lblPendingTitle";
        lblPendingTitle.Size = new Size(178, 18);
        lblPendingTitle.TabIndex = 1;
        lblPendingTitle.Text = "Pending / In-Process";
        // 
        // pnlStripPending
        // 
        pnlStripPending.BackColor = Color.FromArgb(114, 136, 174);
        pnlStripPending.Dock = DockStyle.Left;
        pnlStripPending.Location = new Point(14, 10);
        pnlStripPending.Name = "pnlStripPending";
        pnlStripPending.Size = new Size(4, 60);
        pnlStripPending.TabIndex = 0;
        // 
        // pnlStatClaimed
        // 
        pnlStatClaimed.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatClaimed.Controls.Add(lblClaimed);
        pnlStatClaimed.Controls.Add(lblClaimedTitle);
        pnlStatClaimed.Controls.Add(pnlStripClaimed);
        pnlStatClaimed.Location = new Point(444, 8);
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
        lblClaimed.ForeColor = Color.FromArgb(75, 86, 148);
        lblClaimed.Location = new Point(18, 28);
        lblClaimed.Name = "lblClaimed";
        lblClaimed.Size = new Size(178, 42);
        lblClaimed.TabIndex = 2;
        lblClaimed.Text = "0";
        // 
        // lblClaimedTitle
        // 
        lblClaimedTitle.Dock = DockStyle.Top;
        lblClaimedTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblClaimedTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblClaimedTitle.Location = new Point(18, 10);
        lblClaimedTitle.Name = "lblClaimedTitle";
        lblClaimedTitle.Size = new Size(178, 18);
        lblClaimedTitle.TabIndex = 1;
        lblClaimedTitle.Text = "Claimed Orders";
        // 
        // pnlStripClaimed
        // 
        pnlStripClaimed.BackColor = Color.FromArgb(234, 224, 207);
        pnlStripClaimed.Dock = DockStyle.Left;
        pnlStripClaimed.Location = new Point(14, 10);
        pnlStripClaimed.Name = "pnlStripClaimed";
        pnlStripClaimed.Size = new Size(4, 60);
        pnlStripClaimed.TabIndex = 0;
        // 
        // pnlStatSales
        // 
        pnlStatSales.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatSales.Controls.Add(lblSales);
        pnlStatSales.Controls.Add(lblSalesTitle);
        pnlStatSales.Controls.Add(pnlStripSales);
        pnlStatSales.Location = new Point(666, 8);
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
        lblSales.ForeColor = Color.FromArgb(75, 86, 148);
        lblSales.Location = new Point(18, 28);
        lblSales.Name = "lblSales";
        lblSales.Size = new Size(178, 42);
        lblSales.TabIndex = 2;
        lblSales.Text = "0.00";
        // 
        // lblSalesTitle
        // 
        lblSalesTitle.Dock = DockStyle.Top;
        lblSalesTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblSalesTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblSalesTitle.Location = new Point(18, 10);
        lblSalesTitle.Name = "lblSalesTitle";
        lblSalesTitle.Size = new Size(178, 18);
        lblSalesTitle.TabIndex = 1;
        lblSalesTitle.Text = "Day's Total Sales";
        // 
        // pnlStripSales
        // 
        pnlStripSales.BackColor = Color.FromArgb(75, 86, 148);
        pnlStripSales.Dock = DockStyle.Left;
        pnlStripSales.Location = new Point(14, 10);
        pnlStripSales.Name = "pnlStripSales";
        pnlStripSales.Size = new Size(4, 60);
        pnlStripSales.TabIndex = 0;
        // 
        // pnlFilterBar
        // 
        pnlFilterBar.BackColor = Color.White;
        pnlFilterBar.Controls.Add(btnExportExcel);
        pnlFilterBar.Controls.Add(btnLoad);
        pnlFilterBar.Controls.Add(dtpDate);
        pnlFilterBar.Controls.Add(lblSelectDate);
        pnlFilterBar.Dock = DockStyle.Top;
        pnlFilterBar.Location = new Point(24, 24);
        pnlFilterBar.Name = "pnlFilterBar";
        pnlFilterBar.Padding = new Padding(16, 8, 16, 8);
        pnlFilterBar.Size = new Size(902, 52);
        pnlFilterBar.TabIndex = 0;
        // 
        // btnExportExcel
        // 
        btnExportExcel.BorderColor = Color.FromArgb(220, 223, 230);
        btnExportExcel.ButtonType = HopeButtonType.Primary;
        btnExportExcel.Cursor = Cursors.Hand;
        btnExportExcel.DangerColor = Color.FromArgb(245, 108, 108);
        btnExportExcel.DefaultColor = Color.FromArgb(255, 255, 255);
        btnExportExcel.Dock = DockStyle.Right;
        btnExportExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnExportExcel.HoverTextColor = Color.White;
        btnExportExcel.InfoColor = Color.FromArgb(144, 147, 153);
        btnExportExcel.Location = new Point(686, 8);
        btnExportExcel.Name = "btnExportExcel";
        btnExportExcel.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnExportExcel.Size = new Size(200, 36);
        btnExportExcel.SuccessColor = Color.FromArgb(103, 194, 58);
        btnExportExcel.TabIndex = 3;
        btnExportExcel.Text = " Export to Excel (.xlsx)";
        btnExportExcel.TextColor = Color.FromArgb(246, 242, 234);
        btnExportExcel.WarningColor = Color.FromArgb(230, 162, 60);
        btnExportExcel.Click += btnExportExcel_Click;
        // 
        // btnLoad
        // 
        btnLoad.BorderColor = Color.FromArgb(114, 136, 174);
        btnLoad.ButtonType = HopeButtonType.Default;
        btnLoad.Cursor = Cursors.Hand;
        btnLoad.DangerColor = Color.FromArgb(245, 108, 108);
        btnLoad.DefaultColor = Color.FromArgb(234, 224, 207);
        btnLoad.Dock = DockStyle.Left;
        btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnLoad.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnLoad.InfoColor = Color.FromArgb(144, 147, 153);
        btnLoad.Location = new Point(250, 8);
        btnLoad.Margin = new Padding(12, 0, 0, 0);
        btnLoad.Name = "btnLoad";
        btnLoad.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnLoad.Size = new Size(130, 36);
        btnLoad.SuccessColor = Color.FromArgb(103, 194, 58);
        btnLoad.TabIndex = 2;
        btnLoad.Text = "Refresh Date";
        btnLoad.TextColor = Color.FromArgb(75, 86, 148);
        btnLoad.WarningColor = Color.FromArgb(230, 162, 60);
        btnLoad.Click += btnLoad_Click;
        // 
        // dtpDate
        // 
        dtpDate.Dock = DockStyle.Left;
        dtpDate.Font = new Font("Segoe UI", 10F);
        dtpDate.Format = DateTimePickerFormat.Short;
        dtpDate.Location = new Point(105, 8);
        dtpDate.Name = "dtpDate";
        dtpDate.Size = new Size(145, 30);
        dtpDate.TabIndex = 1;
        // 
        // lblSelectDate
        // 
        lblSelectDate.Dock = DockStyle.Left;
        lblSelectDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblSelectDate.ForeColor = Color.FromArgb(75, 86, 148);
        lblSelectDate.Location = new Point(16, 8);
        lblSelectDate.Name = "lblSelectDate";
        lblSelectDate.Size = new Size(89, 36);
        lblSelectDate.TabIndex = 0;
        lblSelectDate.Text = "Report Date:";
        lblSelectDate.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // FrmExportReport
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(246, 242, 234);
        ClientSize = new Size(950, 640);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(75, 86, 148);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmExportReport";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub  Daily Reports & Excel Export";
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
    private HopeButton btnClose;
    private Panel pnlContainer;
    private Panel pnlFilterBar;
    private Label lblSelectDate;
    private DateTimePicker dtpDate;
    private HopeButton btnLoad;
    private HopeButton btnExportExcel;
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
