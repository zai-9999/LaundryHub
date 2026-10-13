using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using Button = System.Windows.Forms.Button;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Admin;

partial class FrmAdminDashboard
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
        lblClock = new Label();
        btnLogout = new HopeButton();
        lblWelcome = new Label();
        lblLogo = new Label();
        pnlSidebar = new Panel();
        flpNav = new FlowLayoutPanel();
        btnManageStaff = new HopeButton();
        btnServicePricing = new HopeButton();
        btnExportReport = new HopeButton();
        btnStaffDashboard = new HopeButton();
        btnCustomerRegistration = new HopeButton();
        btnNewOrder = new HopeButton();
        btnRefresh = new HopeButton();
        btnLogoutNav = new HopeButton();
        lblNavTitle = new Label();
        pnlMain = new Panel();
        pnlGridWrap = new Panel();
        dgvTodayOrders = new DataGridView();
        pnlTableBar = new Panel();
        txtSearch = new HopeTextBox();
        lblTableTitle = new Label();
        flpStats = new FlowLayoutPanel();
        pnlStatOrders = new Panel();
        lblTotalToday = new Label();
        lblOrdersTitle = new Label();
        pnlStripOrders = new Panel();
        pnlStatRevenue = new Panel();
        lblSalesToday = new Label();
        lblRevenueTitle = new Label();
        pnlStripRevenue = new Panel();
        pnlStatPending = new Panel();
        lblPending = new Label();
        lblPendingTitle = new Label();
        pnlStripPending = new Panel();
        pnlStatClaimed = new Panel();
        lblClaimed = new Label();
        lblClaimedTitle = new Label();
        pnlStripClaimed = new Panel();
        pnlHeader.SuspendLayout();
        pnlSidebar.SuspendLayout();
        flpNav.SuspendLayout();
        pnlMain.SuspendLayout();
        pnlGridWrap.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTodayOrders).BeginInit();
        pnlTableBar.SuspendLayout();
        flpStats.SuspendLayout();
        pnlStatOrders.SuspendLayout();
        pnlStatRevenue.SuspendLayout();
        pnlStatPending.SuspendLayout();
        pnlStatClaimed.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(51, 104, 160);
        pnlHeader.Controls.Add(lblClock);
        pnlHeader.Controls.Add(btnLogout);
        pnlHeader.Controls.Add(lblWelcome);
        pnlHeader.Controls.Add(lblLogo);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 0, 24, 0);
        pnlHeader.Size = new Size(1180, 70);
        pnlHeader.TabIndex = 0;
        // 
        // lblClock
        // 
        lblClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblClock.BackColor = Color.Transparent;
        lblClock.Font = new Font("Segoe UI", 9.5F);
        lblClock.ForeColor = Color.FromArgb(200, 223, 219);
        lblClock.Location = new Point(780, 0);
        lblClock.Name = "lblClock";
        lblClock.Size = new Size(260, 70);
        lblClock.TabIndex = 3;
        lblClock.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnLogout
        // 
        btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLogout.ButtonType = HopeButtonType.Primary;
        btnLogout.PrimaryColor = Color.FromArgb(190, 60, 60);
        btnLogout.BorderColor = Color.FromArgb(190, 60, 60);
        btnLogout.TextColor = Color.White;
        btnLogout.HoverTextColor = Color.White;
        btnLogout.Cursor = Cursors.Hand;
        btnLogout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnLogout.Location = new Point(1060, 16);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(96, 38);
        btnLogout.TabIndex = 2;
        btnLogout.Text = "🚪 Logout";
        btnLogout.Click += btnLogout_Click;
        // 
        // lblWelcome
        // 
        lblWelcome.BackColor = Color.Transparent;
        lblWelcome.Dock = DockStyle.Left;
        lblWelcome.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblWelcome.ForeColor = Color.FromArgb(242, 239, 231);
        lblWelcome.Location = new Point(64, 0);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(500, 70);
        lblWelcome.TabIndex = 1;
        lblWelcome.Text = "LaundryHub Admin";
        lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblLogo
        // 
        lblLogo.BackColor = Color.Transparent;
        lblLogo.Dock = DockStyle.Left;
        lblLogo.Font = new Font("Segoe UI Emoji", 20F);
        lblLogo.Location = new Point(24, 0);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(40, 70);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "👑";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(51, 104, 160);
        pnlSidebar.Controls.Add(flpNav);
        pnlSidebar.Controls.Add(lblNavTitle);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 70);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Padding = new Padding(12);
        pnlSidebar.Size = new Size(240, 670);
        pnlSidebar.TabIndex = 1;
        // 
        // flpNav
        // 
        flpNav.BackColor = Color.Transparent;
        flpNav.Controls.Add(btnManageStaff);
        flpNav.Controls.Add(btnServicePricing);
        flpNav.Controls.Add(btnExportReport);
        flpNav.Controls.Add(btnStaffDashboard);
        flpNav.Controls.Add(btnCustomerRegistration);
        flpNav.Controls.Add(btnNewOrder);
        flpNav.Controls.Add(btnRefresh);
        flpNav.Controls.Add(btnLogoutNav);
        flpNav.Dock = DockStyle.Fill;
        flpNav.FlowDirection = FlowDirection.TopDown;
        flpNav.Location = new Point(12, 42);
        flpNav.Name = "flpNav";
        flpNav.Padding = new Padding(0, 10, 0, 0);
        flpNav.Size = new Size(216, 616);
        flpNav.TabIndex = 1;
        flpNav.WrapContents = false;
        // 
        // btnManageStaff
        // 
        btnManageStaff.ButtonType = HopeButtonType.Primary;
        btnManageStaff.PrimaryColor = Color.FromArgb(37, 78, 122);
        btnManageStaff.BorderColor = Color.FromArgb(51, 104, 160);
        btnManageStaff.TextColor = Color.White;
        btnManageStaff.HoverTextColor = Color.White;
        btnManageStaff.Cursor = Cursors.Hand;
        btnManageStaff.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnManageStaff.Location = new Point(0, 10);
        btnManageStaff.Margin = new Padding(0, 0, 0, 8);
        btnManageStaff.Name = "btnManageStaff";
        btnManageStaff.Size = new Size(215, 42);
        btnManageStaff.TabIndex = 0;
        btnManageStaff.Text = "Manage Staff";
        btnManageStaff.Click += btnManageStaff_Click;
        // 
        // btnServicePricing
        // 
        btnServicePricing.ButtonType = HopeButtonType.Primary;
        btnServicePricing.PrimaryColor = Color.FromArgb(37, 78, 122);
        btnServicePricing.BorderColor = Color.FromArgb(51, 104, 160);
        btnServicePricing.TextColor = Color.White;
        btnServicePricing.HoverTextColor = Color.White;
        btnServicePricing.Cursor = Cursors.Hand;
        btnServicePricing.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnServicePricing.Location = new Point(0, 60);
        btnServicePricing.Margin = new Padding(0, 0, 0, 8);
        btnServicePricing.Name = "btnServicePricing";
        btnServicePricing.Size = new Size(215, 42);
        btnServicePricing.TabIndex = 1;
        btnServicePricing.Text = "Services & Rates";
        btnServicePricing.Click += btnServicePricing_Click;
        // 
        // btnExportReport
        // 
        btnExportReport.ButtonType = HopeButtonType.Primary;
        btnExportReport.PrimaryColor = Color.FromArgb(37, 78, 122);
        btnExportReport.BorderColor = Color.FromArgb(51, 104, 160);
        btnExportReport.TextColor = Color.White;
        btnExportReport.HoverTextColor = Color.White;
        btnExportReport.Cursor = Cursors.Hand;
        btnExportReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnExportReport.Location = new Point(0, 110);
        btnExportReport.Margin = new Padding(0, 0, 0, 8);
        btnExportReport.Name = "btnExportReport";
        btnExportReport.Size = new Size(215, 42);
        btnExportReport.TabIndex = 2;
        btnExportReport.Text = "Daily Reports & Excel";
        btnExportReport.Click += btnExportReport_Click;
        // 
        // btnStaffDashboard
        // 
        btnStaffDashboard.ButtonType = HopeButtonType.Primary;
        btnStaffDashboard.PrimaryColor = Color.FromArgb(37, 78, 122);
        btnStaffDashboard.BorderColor = Color.FromArgb(51, 104, 160);
        btnStaffDashboard.TextColor = Color.White;
        btnStaffDashboard.HoverTextColor = Color.White;
        btnStaffDashboard.Cursor = Cursors.Hand;
        btnStaffDashboard.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnStaffDashboard.Location = new Point(0, 160);
        btnStaffDashboard.Margin = new Padding(0, 0, 0, 8);
        btnStaffDashboard.Name = "btnStaffDashboard";
        btnStaffDashboard.Size = new Size(215, 42);
        btnStaffDashboard.TabIndex = 3;
        btnStaffDashboard.Text = "Staff Operations View";
        btnStaffDashboard.Click += btnStaffDashboard_Click;
        // 
        // btnCustomerRegistration
        // 
        btnCustomerRegistration.ButtonType = HopeButtonType.Primary;
        btnCustomerRegistration.PrimaryColor = Color.FromArgb(37, 78, 122);
        btnCustomerRegistration.BorderColor = Color.FromArgb(51, 104, 160);
        btnCustomerRegistration.TextColor = Color.White;
        btnCustomerRegistration.HoverTextColor = Color.White;
        btnCustomerRegistration.Cursor = Cursors.Hand;
        btnCustomerRegistration.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnCustomerRegistration.Location = new Point(0, 210);
        btnCustomerRegistration.Margin = new Padding(0, 0, 0, 8);
        btnCustomerRegistration.Name = "btnCustomerRegistration";
        btnCustomerRegistration.Size = new Size(215, 42);
        btnCustomerRegistration.TabIndex = 4;
        btnCustomerRegistration.Text = "👤 Customer Management";
        btnCustomerRegistration.Click += btnCustomerRegistration_Click;
        // 
        // btnNewOrder
        // 
        btnNewOrder.ButtonType = HopeButtonType.Primary;
        btnNewOrder.PrimaryColor = Color.FromArgb(102, 163, 191);
        btnNewOrder.BorderColor = Color.FromArgb(102, 163, 191);
        btnNewOrder.TextColor = Color.White;
        btnNewOrder.HoverTextColor = Color.White;
        btnNewOrder.Cursor = Cursors.Hand;
        btnNewOrder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnNewOrder.Location = new Point(0, 260);
        btnNewOrder.Margin = new Padding(0, 0, 0, 8);
        btnNewOrder.Name = "btnNewOrder";
        btnNewOrder.Size = new Size(215, 42);
        btnNewOrder.TabIndex = 5;
        btnNewOrder.Text = "New Laundry Order";
        btnNewOrder.Click += btnNewOrder_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.ButtonType = HopeButtonType.Primary;
        btnRefresh.PrimaryColor = Color.FromArgb(37, 78, 122);
        btnRefresh.BorderColor = Color.FromArgb(51, 104, 160);
        btnRefresh.TextColor = Color.White;
        btnRefresh.HoverTextColor = Color.White;
        btnRefresh.Cursor = Cursors.Hand;
        btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnRefresh.Location = new Point(0, 310);
        btnRefresh.Margin = new Padding(0, 0, 0, 8);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(215, 42);
        btnRefresh.TabIndex = 6;
        btnRefresh.Text = "Refresh Dashboard";
        btnRefresh.Click += btnRefresh_Click;
        // 
        // btnLogoutNav
        // 
        btnLogoutNav.ButtonType = HopeButtonType.Primary;
        btnLogoutNav.PrimaryColor = Color.FromArgb(190, 60, 60);
        btnLogoutNav.BorderColor = Color.FromArgb(190, 60, 60);
        btnLogoutNav.TextColor = Color.White;
        btnLogoutNav.HoverTextColor = Color.White;
        btnLogoutNav.Cursor = Cursors.Hand;
        btnLogoutNav.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnLogoutNav.Location = new Point(0, 360);
        btnLogoutNav.Margin = new Padding(0, 8, 0, 8);
        btnLogoutNav.Name = "btnLogoutNav";
        btnLogoutNav.Size = new Size(215, 42);
        btnLogoutNav.TabIndex = 7;
        btnLogoutNav.Text = "🚪 Logout";
        btnLogoutNav.Click += btnLogout_Click;
        // 
        // lblNavTitle
        // 
        lblNavTitle.Dock = DockStyle.Top;
        lblNavTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblNavTitle.ForeColor = Color.FromArgb(200, 223, 219);
        lblNavTitle.Location = new Point(12, 12);
        lblNavTitle.Name = "lblNavTitle";
        lblNavTitle.Size = new Size(216, 30);
        lblNavTitle.TabIndex = 0;
        lblNavTitle.Text = "ADMIN CONTROLS";
        lblNavTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlMain
        // 
        pnlMain.BackColor = Color.White;
        pnlMain.Controls.Add(pnlGridWrap);
        pnlMain.Controls.Add(pnlTableBar);
        pnlMain.Controls.Add(flpStats);
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(240, 70);
        pnlMain.Name = "pnlMain";
        pnlMain.Padding = new Padding(24);
        pnlMain.Size = new Size(940, 670);
        pnlMain.TabIndex = 2;
        pnlMain.Paint += pnlMain_Paint;
        // 
        // pnlGridWrap
        // 
        pnlGridWrap.Controls.Add(dgvTodayOrders);
        pnlGridWrap.Dock = DockStyle.Fill;
        pnlGridWrap.Location = new Point(24, 172);
        pnlGridWrap.Name = "pnlGridWrap";
        pnlGridWrap.Padding = new Padding(0, 10, 0, 0);
        pnlGridWrap.Size = new Size(892, 474);
        pnlGridWrap.TabIndex = 2;
        // 
        // dgvTodayOrders
        // 
        dgvTodayOrders.AllowUserToAddRows = false;
        dgvTodayOrders.AllowUserToDeleteRows = false;
        dgvTodayOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTodayOrders.BackgroundColor = Color.White;
        dgvTodayOrders.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(242, 239, 231);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(242, 239, 231);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvTodayOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvTodayOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(200, 223, 219);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvTodayOrders.DefaultCellStyle = dataGridViewCellStyle2;
        dgvTodayOrders.Dock = DockStyle.Fill;
        dgvTodayOrders.EnableHeadersVisualStyles = false;
        dgvTodayOrders.GridColor = Color.FromArgb(200, 223, 219);
        dgvTodayOrders.Location = new Point(0, 10);
        dgvTodayOrders.Name = "dgvTodayOrders";
        dgvTodayOrders.ReadOnly = true;
        dgvTodayOrders.RowHeadersVisible = false;
        dgvTodayOrders.RowHeadersWidth = 51;
        dgvTodayOrders.RowTemplate.Height = 38;
        dgvTodayOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTodayOrders.Size = new Size(892, 464);
        dgvTodayOrders.TabIndex = 0;
        dgvTodayOrders.CellDoubleClick += dgvTodayOrders_CellDoubleClick;
        // 
        // pnlTableBar
        // 
        pnlTableBar.Controls.Add(txtSearch);
        pnlTableBar.Controls.Add(lblTableTitle);
        pnlTableBar.Dock = DockStyle.Top;
        pnlTableBar.Location = new Point(24, 124);
        pnlTableBar.Name = "pnlTableBar";
        pnlTableBar.Padding = new Padding(0, 8, 0, 4);
        pnlTableBar.Size = new Size(892, 48);
        pnlTableBar.TabIndex = 1;
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.White;
        txtSearch.BaseColor = Color.White;
        txtSearch.BorderColorA = Color.FromArgb(102, 163, 191);
        txtSearch.BorderColorB = Color.FromArgb(200, 223, 219);
        txtSearch.Dock = DockStyle.Right;
        txtSearch.Font = new Font("Segoe UI", 9.5F);
        txtSearch.ForeColor = Color.FromArgb(51, 104, 160);
        txtSearch.Hint = "Search order #, customer, status...";
        txtSearch.Location = new Point(592, 8);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(300, 36);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // lblTableTitle
        // 
        lblTableTitle.Dock = DockStyle.Left;
        lblTableTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTableTitle.ForeColor = Color.FromArgb(51, 104, 160);
        lblTableTitle.Location = new Point(0, 8);
        lblTableTitle.Name = "lblTableTitle";
        lblTableTitle.Size = new Size(250, 36);
        lblTableTitle.TabIndex = 0;
        lblTableTitle.Text = "Today's Orders Feed";
        lblTableTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // flpStats
        // 
        flpStats.Controls.Add(pnlStatOrders);
        flpStats.Controls.Add(pnlStatRevenue);
        flpStats.Controls.Add(pnlStatPending);
        flpStats.Controls.Add(pnlStatClaimed);
        flpStats.Dock = DockStyle.Top;
        flpStats.Location = new Point(24, 24);
        flpStats.Name = "flpStats";
        flpStats.Size = new Size(892, 100);
        flpStats.TabIndex = 0;
        // 
        // pnlStatOrders
        // 
        pnlStatOrders.BackColor = Color.FromArgb(245, 248, 252);
        pnlStatOrders.Controls.Add(lblTotalToday);
        pnlStatOrders.Controls.Add(lblOrdersTitle);
        pnlStatOrders.Controls.Add(pnlStripOrders);
        pnlStatOrders.Location = new Point(0, 0);
        pnlStatOrders.Margin = new Padding(0, 0, 14, 0);
        pnlStatOrders.Name = "pnlStatOrders";
        pnlStatOrders.Padding = new Padding(14, 10, 14, 10);
        pnlStatOrders.Size = new Size(205, 85);
        pnlStatOrders.TabIndex = 0;
        // 
        // lblTotalToday
        // 
        lblTotalToday.Dock = DockStyle.Fill;
        lblTotalToday.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTotalToday.ForeColor = Color.FromArgb(51, 104, 160);
        lblTotalToday.Location = new Point(18, 28);
        lblTotalToday.Name = "lblTotalToday";
        lblTotalToday.Size = new Size(173, 47);
        lblTotalToday.TabIndex = 2;
        lblTotalToday.Text = "0";
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.Dock = DockStyle.Top;
        lblOrdersTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblOrdersTitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblOrdersTitle.Location = new Point(18, 10);
        lblOrdersTitle.Name = "lblOrdersTitle";
        lblOrdersTitle.Size = new Size(173, 18);
        lblOrdersTitle.TabIndex = 1;
        lblOrdersTitle.Text = "Today's Total Orders";
        // 
        // pnlStripOrders
        // 
        pnlStripOrders.BackColor = Color.FromArgb(51, 104, 160);
        pnlStripOrders.Dock = DockStyle.Left;
        pnlStripOrders.Location = new Point(14, 10);
        pnlStripOrders.Name = "pnlStripOrders";
        pnlStripOrders.Size = new Size(4, 65);
        pnlStripOrders.TabIndex = 0;
        // 
        // pnlStatRevenue
        // 
        pnlStatRevenue.BackColor = Color.FromArgb(245, 248, 252);
        pnlStatRevenue.Controls.Add(lblSalesToday);
        pnlStatRevenue.Controls.Add(lblRevenueTitle);
        pnlStatRevenue.Controls.Add(pnlStripRevenue);
        pnlStatRevenue.Location = new Point(219, 0);
        pnlStatRevenue.Margin = new Padding(0, 0, 14, 0);
        pnlStatRevenue.Name = "pnlStatRevenue";
        pnlStatRevenue.Padding = new Padding(14, 10, 14, 10);
        pnlStatRevenue.Size = new Size(205, 85);
        pnlStatRevenue.TabIndex = 1;
        // 
        // lblSalesToday
        // 
        lblSalesToday.Dock = DockStyle.Fill;
        lblSalesToday.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblSalesToday.ForeColor = Color.FromArgb(51, 104, 160);
        lblSalesToday.Location = new Point(18, 28);
        lblSalesToday.Name = "lblSalesToday";
        lblSalesToday.Size = new Size(173, 47);
        lblSalesToday.TabIndex = 2;
        lblSalesToday.Text = "₱0.00";
        // 
        // lblRevenueTitle
        // 
        lblRevenueTitle.Dock = DockStyle.Top;
        lblRevenueTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblRevenueTitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblRevenueTitle.Location = new Point(18, 10);
        lblRevenueTitle.Name = "lblRevenueTitle";
        lblRevenueTitle.Size = new Size(173, 18);
        lblRevenueTitle.TabIndex = 1;
        lblRevenueTitle.Text = "Today's Revenue";
        // 
        // pnlStripRevenue
        // 
        pnlStripRevenue.BackColor = Color.FromArgb(102, 163, 191);
        pnlStripRevenue.Dock = DockStyle.Left;
        pnlStripRevenue.Location = new Point(14, 10);
        pnlStripRevenue.Name = "pnlStripRevenue";
        pnlStripRevenue.Size = new Size(4, 65);
        pnlStripRevenue.TabIndex = 0;
        // 
        // pnlStatPending
        // 
        pnlStatPending.BackColor = Color.FromArgb(245, 248, 252);
        pnlStatPending.Controls.Add(lblPending);
        pnlStatPending.Controls.Add(lblPendingTitle);
        pnlStatPending.Controls.Add(pnlStripPending);
        pnlStatPending.Location = new Point(438, 0);
        pnlStatPending.Margin = new Padding(0, 0, 14, 0);
        pnlStatPending.Name = "pnlStatPending";
        pnlStatPending.Padding = new Padding(14, 10, 14, 10);
        pnlStatPending.Size = new Size(205, 85);
        pnlStatPending.TabIndex = 2;
        // 
        // lblPending
        // 
        lblPending.Dock = DockStyle.Fill;
        lblPending.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblPending.ForeColor = Color.FromArgb(51, 104, 160);
        lblPending.Location = new Point(18, 28);
        lblPending.Name = "lblPending";
        lblPending.Size = new Size(173, 47);
        lblPending.TabIndex = 2;
        lblPending.Text = "0";
        // 
        // lblPendingTitle
        // 
        lblPendingTitle.Dock = DockStyle.Top;
        lblPendingTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPendingTitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblPendingTitle.Location = new Point(18, 10);
        lblPendingTitle.Name = "lblPendingTitle";
        lblPendingTitle.Size = new Size(173, 18);
        lblPendingTitle.TabIndex = 1;
        lblPendingTitle.Text = "Pending in Progress";
        // 
        // pnlStripPending
        // 
        pnlStripPending.BackColor = Color.FromArgb(200, 223, 219);
        pnlStripPending.Dock = DockStyle.Left;
        pnlStripPending.Location = new Point(14, 10);
        pnlStripPending.Name = "pnlStripPending";
        pnlStripPending.Size = new Size(4, 65);
        pnlStripPending.TabIndex = 0;
        // 
        // pnlStatClaimed
        // 
        pnlStatClaimed.BackColor = Color.FromArgb(245, 248, 252);
        pnlStatClaimed.Controls.Add(lblClaimed);
        pnlStatClaimed.Controls.Add(lblClaimedTitle);
        pnlStatClaimed.Controls.Add(pnlStripClaimed);
        pnlStatClaimed.Location = new Point(657, 0);
        pnlStatClaimed.Margin = new Padding(0, 0, 14, 0);
        pnlStatClaimed.Name = "pnlStatClaimed";
        pnlStatClaimed.Padding = new Padding(14, 10, 14, 10);
        pnlStatClaimed.Size = new Size(205, 85);
        pnlStatClaimed.TabIndex = 3;
        // 
        // lblClaimed
        // 
        lblClaimed.Dock = DockStyle.Fill;
        lblClaimed.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblClaimed.ForeColor = Color.FromArgb(51, 104, 160);
        lblClaimed.Location = new Point(18, 28);
        lblClaimed.Name = "lblClaimed";
        lblClaimed.Size = new Size(173, 47);
        lblClaimed.TabIndex = 2;
        lblClaimed.Text = "0";
        // 
        // lblClaimedTitle
        // 
        lblClaimedTitle.Dock = DockStyle.Top;
        lblClaimedTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblClaimedTitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblClaimedTitle.Location = new Point(18, 10);
        lblClaimedTitle.Name = "lblClaimedTitle";
        lblClaimedTitle.Size = new Size(173, 18);
        lblClaimedTitle.TabIndex = 1;
        lblClaimedTitle.Text = "Claimed Today";
        // 
        // pnlStripClaimed
        // 
        pnlStripClaimed.BackColor = Color.FromArgb(102, 163, 191);
        pnlStripClaimed.Dock = DockStyle.Left;
        pnlStripClaimed.Location = new Point(14, 10);
        pnlStripClaimed.Name = "pnlStripClaimed";
        pnlStripClaimed.Size = new Size(4, 65);
        pnlStripClaimed.TabIndex = 0;
        // 
        // FrmAdminDashboard
        // 
        AutoScaleDimensions = new SizeF(9F, 21F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(102, 163, 191);
        ClientSize = new Size(1180, 740);
        Controls.Add(pnlMain);
        Controls.Add(pnlSidebar);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(51, 104, 160);
        Name = "FrmAdminDashboard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Owner & Administrator Dashboard";
        pnlHeader.ResumeLayout(false);
        pnlSidebar.ResumeLayout(false);
        flpNav.ResumeLayout(false);
        pnlMain.ResumeLayout(false);
        pnlGridWrap.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvTodayOrders).EndInit();
        pnlTableBar.ResumeLayout(false);
        flpStats.ResumeLayout(false);
        pnlStatOrders.ResumeLayout(false);
        pnlStatRevenue.ResumeLayout(false);
        pnlStatPending.ResumeLayout(false);
        pnlStatClaimed.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblLogo;
    private Label lblWelcome;
    private HopeButton btnLogout;
    private Label lblClock;
    private Panel pnlSidebar;
    private Label lblNavTitle;
    private FlowLayoutPanel flpNav;
    private HopeButton btnManageStaff;
    private HopeButton btnServicePricing;
    private HopeButton btnExportReport;
    private HopeButton btnStaffDashboard;
    private HopeButton btnCustomerRegistration;
    private HopeButton btnNewOrder;
    private HopeButton btnRefresh;
    private HopeButton btnLogoutNav;
    private Panel pnlMain;
    private FlowLayoutPanel flpStats;
    private Panel pnlStatOrders;
    private Panel pnlStripOrders;
    private Label lblOrdersTitle;
    private Label lblTotalToday;
    private Panel pnlStatRevenue;
    private Panel pnlStripRevenue;
    private Label lblRevenueTitle;
    private Label lblSalesToday;
    private Panel pnlStatPending;
    private Panel pnlStripPending;
    private Label lblPendingTitle;
    private Label lblPending;
    private Panel pnlStatClaimed;
    private Panel pnlStripClaimed;
    private Label lblClaimedTitle;
    private Label lblClaimed;
    private Panel pnlTableBar;
    private Label lblTableTitle;
    private HopeTextBox txtSearch;
    private Panel pnlGridWrap;
    private DataGridView dgvTodayOrders;
}
