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
        btnLogout = new Button();
        lblWelcome = new Label();
        lblLogo = new Label();
        pnlSidebar = new Panel();
        flpNav = new FlowLayoutPanel();
        btnManageStaff = new Button();
        btnServicePricing = new Button();
        btnExportReport = new Button();
        btnStaffDashboard = new Button();
        btnCustomerRegistration = new Button();
        btnNewOrder = new Button();
        btnRefresh = new Button();
        lblNavTitle = new Label();
        pnlMain = new Panel();
        pnlGridWrap = new Panel();
        dgvTodayOrders = new DataGridView();
        pnlTableBar = new Panel();
        txtSearch = new TextBox();
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
        pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
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
        lblClock.Dock = DockStyle.Right;
        lblClock.Font = new Font("Segoe UI", 9.5F);
        lblClock.ForeColor = Color.FromArgb(148, 163, 184);
        lblClock.Location = new Point(841, 0);
        lblClock.Name = "lblClock";
        lblClock.Size = new Size(220, 70);
        lblClock.TabIndex = 3;
        lblClock.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnLogout
        // 
        btnLogout.BackColor = Color.FromArgb(153, 27, 27);
        btnLogout.Cursor = Cursors.Hand;
        btnLogout.Dock = DockStyle.Right;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.ForeColor = Color.White;
        btnLogout.Location = new Point(1061, 0);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(95, 70);
        btnLogout.TabIndex = 2;
        btnLogout.Text = "🚪 Logout";
        btnLogout.UseVisualStyleBackColor = false;
        btnLogout.Click += btnLogout_Click;
        // 
        // lblWelcome
        // 
        lblWelcome.Dock = DockStyle.Left;
        lblWelcome.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblWelcome.ForeColor = Color.FromArgb(96, 165, 250);
        lblWelcome.Location = new Point(64, 0);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(500, 70);
        lblWelcome.TabIndex = 1;
        lblWelcome.Text = "LaundryHub Admin";
        lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblLogo
        // 
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
        pnlSidebar.BackColor = Color.FromArgb(20, 29, 47);
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
        flpNav.Controls.Add(btnManageStaff);
        flpNav.Controls.Add(btnServicePricing);
        flpNav.Controls.Add(btnExportReport);
        flpNav.Controls.Add(btnStaffDashboard);
        flpNav.Controls.Add(btnCustomerRegistration);
        flpNav.Controls.Add(btnNewOrder);
        flpNav.Controls.Add(btnRefresh);
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
        btnManageStaff.BackColor = Color.FromArgb(30, 41, 59);
        btnManageStaff.Cursor = Cursors.Hand;
        btnManageStaff.FlatAppearance.BorderSize = 0;
        btnManageStaff.FlatStyle = FlatStyle.Flat;
        btnManageStaff.Font = new Font("Segoe UI", 9.5F);
        btnManageStaff.ForeColor = Color.White;
        btnManageStaff.Location = new Point(0, 10);
        btnManageStaff.Margin = new Padding(0, 0, 0, 8);
        btnManageStaff.Name = "btnManageStaff";
        btnManageStaff.Padding = new Padding(12, 0, 0, 0);
        btnManageStaff.Size = new Size(215, 42);
        btnManageStaff.TabIndex = 0;
        btnManageStaff.Text = "👥 Manage Staff";
        btnManageStaff.TextAlign = ContentAlignment.MiddleLeft;
        btnManageStaff.UseVisualStyleBackColor = false;
        btnManageStaff.Click += btnManageStaff_Click;
        // 
        // btnServicePricing
        // 
        btnServicePricing.BackColor = Color.FromArgb(30, 41, 59);
        btnServicePricing.Cursor = Cursors.Hand;
        btnServicePricing.FlatAppearance.BorderSize = 0;
        btnServicePricing.FlatStyle = FlatStyle.Flat;
        btnServicePricing.Font = new Font("Segoe UI", 9.5F);
        btnServicePricing.ForeColor = Color.White;
        btnServicePricing.Location = new Point(0, 60);
        btnServicePricing.Margin = new Padding(0, 0, 0, 8);
        btnServicePricing.Name = "btnServicePricing";
        btnServicePricing.Padding = new Padding(12, 0, 0, 0);
        btnServicePricing.Size = new Size(215, 42);
        btnServicePricing.TabIndex = 1;
        btnServicePricing.Text = "🏷 Load Pricing";
        btnServicePricing.TextAlign = ContentAlignment.MiddleLeft;
        btnServicePricing.UseVisualStyleBackColor = false;
        btnServicePricing.Click += btnServicePricing_Click;
        // 
        // btnExportReport
        // 
        btnExportReport.BackColor = Color.FromArgb(30, 41, 59);
        btnExportReport.Cursor = Cursors.Hand;
        btnExportReport.FlatAppearance.BorderSize = 0;
        btnExportReport.FlatStyle = FlatStyle.Flat;
        btnExportReport.Font = new Font("Segoe UI", 9.5F);
        btnExportReport.ForeColor = Color.White;
        btnExportReport.Location = new Point(0, 110);
        btnExportReport.Margin = new Padding(0, 0, 0, 8);
        btnExportReport.Name = "btnExportReport";
        btnExportReport.Padding = new Padding(12, 0, 0, 0);
        btnExportReport.Size = new Size(215, 42);
        btnExportReport.TabIndex = 2;
        btnExportReport.Text = "📊 Daily Reports & Excel";
        btnExportReport.TextAlign = ContentAlignment.MiddleLeft;
        btnExportReport.UseVisualStyleBackColor = false;
        btnExportReport.Click += btnExportReport_Click;
        // 
        // btnStaffDashboard
        // 
        btnStaffDashboard.BackColor = Color.FromArgb(30, 41, 59);
        btnStaffDashboard.Cursor = Cursors.Hand;
        btnStaffDashboard.FlatAppearance.BorderSize = 0;
        btnStaffDashboard.FlatStyle = FlatStyle.Flat;
        btnStaffDashboard.Font = new Font("Segoe UI", 9.5F);
        btnStaffDashboard.ForeColor = Color.White;
        btnStaffDashboard.Location = new Point(0, 160);
        btnStaffDashboard.Margin = new Padding(0, 0, 0, 8);
        btnStaffDashboard.Name = "btnStaffDashboard";
        btnStaffDashboard.Padding = new Padding(12, 0, 0, 0);
        btnStaffDashboard.Size = new Size(215, 42);
        btnStaffDashboard.TabIndex = 3;
        btnStaffDashboard.Text = "🧺 Staff Operations View";
        btnStaffDashboard.TextAlign = ContentAlignment.MiddleLeft;
        btnStaffDashboard.UseVisualStyleBackColor = false;
        btnStaffDashboard.Click += btnStaffDashboard_Click;
        // 
        // btnCustomerRegistration
        // 
        btnCustomerRegistration.BackColor = Color.FromArgb(30, 41, 59);
        btnCustomerRegistration.Cursor = Cursors.Hand;
        btnCustomerRegistration.FlatAppearance.BorderSize = 0;
        btnCustomerRegistration.FlatStyle = FlatStyle.Flat;
        btnCustomerRegistration.Font = new Font("Segoe UI", 9.5F);
        btnCustomerRegistration.ForeColor = Color.White;
        btnCustomerRegistration.Location = new Point(0, 210);
        btnCustomerRegistration.Margin = new Padding(0, 0, 0, 8);
        btnCustomerRegistration.Name = "btnCustomerRegistration";
        btnCustomerRegistration.Padding = new Padding(12, 0, 0, 0);
        btnCustomerRegistration.Size = new Size(215, 42);
        btnCustomerRegistration.TabIndex = 4;
        btnCustomerRegistration.Text = "👤 Customer Management";
        btnCustomerRegistration.TextAlign = ContentAlignment.MiddleLeft;
        btnCustomerRegistration.UseVisualStyleBackColor = false;
        btnCustomerRegistration.Click += btnCustomerRegistration_Click;
        // 
        // btnNewOrder
        // 
        btnNewOrder.BackColor = Color.FromArgb(30, 41, 59);
        btnNewOrder.Cursor = Cursors.Hand;
        btnNewOrder.FlatAppearance.BorderSize = 0;
        btnNewOrder.FlatStyle = FlatStyle.Flat;
        btnNewOrder.Font = new Font("Segoe UI", 9.5F);
        btnNewOrder.ForeColor = Color.White;
        btnNewOrder.Location = new Point(0, 260);
        btnNewOrder.Margin = new Padding(0, 0, 0, 8);
        btnNewOrder.Name = "btnNewOrder";
        btnNewOrder.Padding = new Padding(12, 0, 0, 0);
        btnNewOrder.Size = new Size(215, 42);
        btnNewOrder.TabIndex = 5;
        btnNewOrder.Text = "➕ New Laundry Order";
        btnNewOrder.TextAlign = ContentAlignment.MiddleLeft;
        btnNewOrder.UseVisualStyleBackColor = false;
        btnNewOrder.Click += btnNewOrder_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.BackColor = Color.FromArgb(30, 41, 59);
        btnRefresh.Cursor = Cursors.Hand;
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Segoe UI", 9.5F);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.Location = new Point(0, 310);
        btnRefresh.Margin = new Padding(0, 0, 0, 8);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Padding = new Padding(12, 0, 0, 0);
        btnRefresh.Size = new Size(215, 42);
        btnRefresh.TabIndex = 6;
        btnRefresh.Text = "🔄 Refresh Dashboard";
        btnRefresh.TextAlign = ContentAlignment.MiddleLeft;
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // lblNavTitle
        // 
        lblNavTitle.Dock = DockStyle.Top;
        lblNavTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblNavTitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblNavTitle.Location = new Point(12, 12);
        lblNavTitle.Name = "lblNavTitle";
        lblNavTitle.Size = new Size(216, 30);
        lblNavTitle.TabIndex = 0;
        lblNavTitle.Text = "ADMIN CONTROLS";
        lblNavTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlMain
        // 
        pnlMain.Controls.Add(pnlGridWrap);
        pnlMain.Controls.Add(pnlTableBar);
        pnlMain.Controls.Add(flpStats);
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(240, 70);
        pnlMain.Name = "pnlMain";
        pnlMain.Padding = new Padding(24);
        pnlMain.Size = new Size(940, 670);
        pnlMain.TabIndex = 2;
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
        dgvTodayOrders.BackgroundColor = Color.FromArgb(30, 41, 59);
        dgvTodayOrders.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(148, 163, 184);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvTodayOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvTodayOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(37, 99, 235);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvTodayOrders.DefaultCellStyle = dataGridViewCellStyle2;
        dgvTodayOrders.Dock = DockStyle.Fill;
        dgvTodayOrders.EnableHeadersVisualStyles = false;
        dgvTodayOrders.GridColor = Color.FromArgb(51, 65, 85);
        dgvTodayOrders.Location = new Point(0, 10);
        dgvTodayOrders.Name = "dgvTodayOrders";
        dgvTodayOrders.ReadOnly = true;
        dgvTodayOrders.RowHeadersVisible = false;
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
        pnlTableBar.Padding = new Padding(0, 10, 0, 0);
        pnlTableBar.Size = new Size(892, 48);
        pnlTableBar.TabIndex = 1;
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.FromArgb(30, 41, 59);
        txtSearch.BorderStyle = BorderStyle.FixedSingle;
        txtSearch.Dock = DockStyle.Right;
        txtSearch.Font = new Font("Segoe UI", 10F);
        txtSearch.ForeColor = Color.White;
        txtSearch.Location = new Point(612, 10);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "🔍 Search order #, customer, status...";
        txtSearch.Size = new Size(280, 25);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // lblTableTitle
        // 
        lblTableTitle.Dock = DockStyle.Left;
        lblTableTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTableTitle.ForeColor = Color.White;
        lblTableTitle.Location = new Point(0, 10);
        lblTableTitle.Name = "lblTableTitle";
        lblTableTitle.Size = new Size(250, 38);
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
        pnlStatOrders.BackColor = Color.FromArgb(30, 41, 59);
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
        lblTotalToday.ForeColor = Color.White;
        lblTotalToday.Location = new Point(18, 28);
        lblTotalToday.Name = "lblTotalToday";
        lblTotalToday.Size = new Size(173, 47);
        lblTotalToday.TabIndex = 2;
        lblTotalToday.Text = "0";
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.Dock = DockStyle.Top;
        lblOrdersTitle.Font = new Font("Segoe UI", 8.5F);
        lblOrdersTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblOrdersTitle.Location = new Point(18, 10);
        lblOrdersTitle.Name = "lblOrdersTitle";
        lblOrdersTitle.Size = new Size(173, 18);
        lblOrdersTitle.TabIndex = 1;
        lblOrdersTitle.Text = "Today's Total Orders";
        // 
        // pnlStripOrders
        // 
        pnlStripOrders.BackColor = Color.FromArgb(59, 130, 246);
        pnlStripOrders.Dock = DockStyle.Left;
        pnlStripOrders.Location = new Point(14, 10);
        pnlStripOrders.Name = "pnlStripOrders";
        pnlStripOrders.Size = new Size(4, 65);
        pnlStripOrders.TabIndex = 0;
        // 
        // pnlStatRevenue
        // 
        pnlStatRevenue.BackColor = Color.FromArgb(30, 41, 59);
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
        lblSalesToday.ForeColor = Color.White;
        lblSalesToday.Location = new Point(18, 28);
        lblSalesToday.Name = "lblSalesToday";
        lblSalesToday.Size = new Size(173, 47);
        lblSalesToday.TabIndex = 2;
        lblSalesToday.Text = "₱0.00";
        // 
        // lblRevenueTitle
        // 
        lblRevenueTitle.Dock = DockStyle.Top;
        lblRevenueTitle.Font = new Font("Segoe UI", 8.5F);
        lblRevenueTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblRevenueTitle.Location = new Point(18, 10);
        lblRevenueTitle.Name = "lblRevenueTitle";
        lblRevenueTitle.Size = new Size(173, 18);
        lblRevenueTitle.TabIndex = 1;
        lblRevenueTitle.Text = "Today's Revenue";
        // 
        // pnlStripRevenue
        // 
        pnlStripRevenue.BackColor = Color.FromArgb(16, 185, 129);
        pnlStripRevenue.Dock = DockStyle.Left;
        pnlStripRevenue.Location = new Point(14, 10);
        pnlStripRevenue.Name = "pnlStripRevenue";
        pnlStripRevenue.Size = new Size(4, 65);
        pnlStripRevenue.TabIndex = 0;
        // 
        // pnlStatPending
        // 
        pnlStatPending.BackColor = Color.FromArgb(30, 41, 59);
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
        lblPending.ForeColor = Color.White;
        lblPending.Location = new Point(18, 28);
        lblPending.Name = "lblPending";
        lblPending.Size = new Size(173, 47);
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
        lblPendingTitle.Size = new Size(173, 18);
        lblPendingTitle.TabIndex = 1;
        lblPendingTitle.Text = "Pending in Progress";
        // 
        // pnlStripPending
        // 
        pnlStripPending.BackColor = Color.FromArgb(245, 158, 11);
        pnlStripPending.Dock = DockStyle.Left;
        pnlStripPending.Location = new Point(14, 10);
        pnlStripPending.Name = "pnlStripPending";
        pnlStripPending.Size = new Size(4, 65);
        pnlStripPending.TabIndex = 0;
        // 
        // pnlStatClaimed
        // 
        pnlStatClaimed.BackColor = Color.FromArgb(30, 41, 59);
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
        lblClaimed.ForeColor = Color.White;
        lblClaimed.Location = new Point(18, 28);
        lblClaimed.Name = "lblClaimed";
        lblClaimed.Size = new Size(173, 47);
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
        lblClaimedTitle.Size = new Size(173, 18);
        lblClaimedTitle.TabIndex = 1;
        lblClaimedTitle.Text = "Claimed Today";
        // 
        // pnlStripClaimed
        // 
        pnlStripClaimed.BackColor = Color.FromArgb(139, 92, 246);
        pnlStripClaimed.Dock = DockStyle.Left;
        pnlStripClaimed.Location = new Point(14, 10);
        pnlStripClaimed.Name = "pnlStripClaimed";
        pnlStripClaimed.Size = new Size(4, 65);
        pnlStripClaimed.TabIndex = 0;
        // 
        // FrmAdminDashboard
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(1180, 740);
        Controls.Add(pnlMain);
        Controls.Add(pnlSidebar);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
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
        pnlTableBar.PerformLayout();
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
    private Button btnLogout;
    private Label lblClock;
    private Panel pnlSidebar;
    private Label lblNavTitle;
    private FlowLayoutPanel flpNav;
    private Button btnManageStaff;
    private Button btnServicePricing;
    private Button btnExportReport;
    private Button btnStaffDashboard;
    private Button btnCustomerRegistration;
    private Button btnNewOrder;
    private Button btnRefresh;
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
    private TextBox txtSearch;
    private Panel pnlGridWrap;
    private DataGridView dgvTodayOrders;
}
