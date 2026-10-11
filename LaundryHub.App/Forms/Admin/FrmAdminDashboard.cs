using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmAdminDashboard : Form
{
    public FrmAdminDashboard()
    {
        InitializeForm();
        LoadDashboardData();
    }

    private Label lblWelcome = null!;
    private Label lblClock = null!;
    private Label lblTotalToday = null!;
    private Label lblSalesToday = null!;
    private Label lblPending = null!;
    private Label lblClaimed = null!;
    private TextBox txtSearch = null!;
    private DataGridView dgvTodayOrders = null!;
    private System.Windows.Forms.Timer clockTimer = null!;

    private void InitializeForm()
    {
        this.Text = "LaundryHub – Owner & Administrator Dashboard";
        this.Size = new Size(1180, 740);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);

        // Header
        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24, 0, 24, 0)
        };

        var lblLogo = new Label
        {
            Text = "👑",
            Font = new Font("Segoe UI Emoji", 20),
            Size = new Size(40, 70),
            Dock = DockStyle.Left,
            TextAlign = ContentAlignment.MiddleCenter
        };

        lblWelcome = new Label
        {
            Text = $"LaundryHub Admin  •  {SessionManager.CurrentUser?.FullName ?? "Administrator"}",
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            AutoSize = false,
            Dock = DockStyle.Left,
            Width = 500,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var btnLogout = new Button
        {
            Text = "🚪 Logout",
            Size = new Size(95, 34),
            Dock = DockStyle.Right,
            BackColor = Color.FromArgb(153, 27, 27),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.Click += (_, _) => this.Close();

        lblClock = new Label
        {
            Font = new Font("Segoe UI", 9.5f),
            ForeColor = Color.FromArgb(148, 163, 184),
            Dock = DockStyle.Right,
            Width = 220,
            TextAlign = ContentAlignment.MiddleRight
        };

        header.Controls.AddRange(new Control[] { lblLogo, lblWelcome, btnLogout, lblClock });
        this.Controls.Add(header);

        // Left Navigation Sidebar
        var sidebar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 240,
            BackColor = Color.FromArgb(20, 29, 47),
            Padding = new Padding(12)
        };

        var navTitle = new Label
        {
            Text = "ADMIN CONTROLS",
            Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
            ForeColor = Color.FromArgb(100, 116, 139),
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleLeft
        };
        sidebar.Controls.Add(navTitle);

        var navLayout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(0, 10, 0, 0)
        };

        navLayout.Controls.Add(CreateNavButton("👥 Manage Staff", () => new FrmManageStaff().ShowDialog(this)));
        navLayout.Controls.Add(CreateNavButton("🏷 Service & Rates", () => new FrmServicePricing().ShowDialog(this)));
        navLayout.Controls.Add(CreateNavButton("📊 Daily Reports & Excel", () => new FrmExportReport().ShowDialog(this)));
        navLayout.Controls.Add(CreateNavButton("🧺 Staff Operations View", () => new Staff.FrmStaffDashboard().ShowDialog(this)));
        navLayout.Controls.Add(CreateNavButton("👤 Customer Management", () => new Staff.FrmCustomerRegistration().ShowDialog(this)));
        navLayout.Controls.Add(CreateNavButton("➕ New Laundry Order", () =>
        {
            var f = new Staff.FrmNewOrder();
            if (f.ShowDialog(this) == DialogResult.OK) LoadDashboardData();
        }));
        navLayout.Controls.Add(CreateNavButton("🔄 Refresh Dashboard", LoadDashboardData));

        sidebar.Controls.Add(navLayout);
        this.Controls.Add(sidebar);

        // Main Body Area
        var main = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(24)
        };
        this.Controls.Add(main);

        // Stat Cards Flow
        var statsFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 100,
            FlowDirection = FlowDirection.LeftToRight
        };

        statsFlow.Controls.Add(CreateStatCard("Today's Total Orders", "#3b82f6", out lblTotalToday));
        statsFlow.Controls.Add(CreateStatCard("Today's Revenue", "#10b981", out lblSalesToday));
        statsFlow.Controls.Add(CreateStatCard("Pending in Progress", "#f59e0b", out lblPending));
        statsFlow.Controls.Add(CreateStatCard("Claimed Today", "#8b5cf6", out lblClaimed));

        main.Controls.Add(statsFlow);

        // Table Header & Search
        var tableBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 48,
            Padding = new Padding(0, 10, 0, 0)
        };

        var lblTableTitle = new Label
        {
            Text = "Today's Orders Feed",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Left,
            Width = 250,
            TextAlign = ContentAlignment.MiddleLeft
        };

        txtSearch = new TextBox
        {
            Dock = DockStyle.Right,
            Width = 280,
            BackColor = Color.FromArgb(30, 41, 59),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("Segoe UI", 10),
            PlaceholderText = "🔍 Search order #, customer, status..."
        };
        txtSearch.TextChanged += (_, _) => FilterOrders(txtSearch.Text.Trim());

        tableBar.Controls.AddRange(new Control[] { lblTableTitle, txtSearch });
        main.Controls.Add(tableBar);

        // DataGridView
        dgvTodayOrders = new DataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = Color.FromArgb(30, 41, 59),
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Font = new Font("Segoe UI", 9.5f),
            GridColor = Color.FromArgb(51, 65, 85),
            RowTemplate = { Height = 38 },
            DefaultCellStyle =
            {
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(37, 99, 235),
                SelectionForeColor = Color.White
            },
            ColumnHeadersDefaultCellStyle =
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.FromArgb(148, 163, 184),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(6)
            },
            EnableHeadersVisualStyles = false
        };
        dgvTodayOrders.CellDoubleClick += (_, _) => OpenSelectedOrderDetail();

        var gridWrap = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 10, 0, 0)
        };
        gridWrap.Controls.Add(dgvTodayOrders);
        main.Controls.Add(gridWrap);

        // Timer for clock
        clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
        clockTimer.Tick += (_, _) => lblClock.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  hh:mm:ss tt");
        clockTimer.Start();
        lblClock.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  hh:mm:ss tt");
    }

    private Button CreateNavButton(string text, Action onClick)
    {
        var btn = new Button
        {
            Text = text,
            Size = new Size(215, 42),
            BackColor = Color.FromArgb(30, 41, 59),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5f),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(12, 0, 0, 0),
            Cursor = Cursors.Hand,
            Margin = new Padding(0, 0, 0, 8)
        };
        btn.FlatAppearance.BorderSize = 0;
        btn.Click += (_, _) => onClick();
        return btn;
    }

    private static Panel CreateStatCard(string title, string hexColor, out Label valueLabel)
    {
        var panel = new Panel
        {
            Size = new Size(205, 85),
            BackColor = Color.FromArgb(30, 41, 59),
            Margin = new Padding(0, 0, 14, 0),
            Padding = new Padding(14, 10, 14, 10)
        };

        var strip = new Panel
        {
            Dock = DockStyle.Left,
            Width = 4,
            BackColor = ColorTranslator.FromHtml(hexColor)
        };

        var lblTitle = new Label
        {
            Text = title,
            ForeColor = Color.FromArgb(148, 163, 184),
            Font = new Font("Segoe UI", 8.5f),
            Dock = DockStyle.Top,
            Height = 18
        };

        valueLabel = new Label
        {
            Text = "0",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            Dock = DockStyle.Fill
        };

        panel.Controls.Add(valueLabel);
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(strip);
        return panel;
    }

    private void LoadDashboardData()
    {
        var report = AppServices.Orders.GetDailyReport(DateTime.Today);

        lblTotalToday.Text = report.TotalOrders.ToString();
        lblSalesToday.Text = $"₱{report.TotalSales:N2}";
        lblPending.Text = report.PendingOrders.ToString();
        lblClaimed.Text = report.ClaimedOrders.ToString();

        PopulateGrid(report.Orders);
    }

    private void FilterOrders(string query)
    {
        var report = AppServices.Orders.GetDailyReport(DateTime.Today);
        if (string.IsNullOrWhiteSpace(query))
        {
            PopulateGrid(report.Orders);
        }
        else
        {
            var q = query.ToLower();
            var filtered = report.Orders.Where(o =>
                o.OrderNumber.ToLower().Contains(q) ||
                (o.CustomerName?.ToLower().Contains(q) ?? false) ||
                o.Status.ToLower().Contains(q)).ToList();
            PopulateGrid(filtered);
        }
    }

    private void PopulateGrid(IEnumerable<Order> orders)
    {
        dgvTodayOrders.DataSource = orders.Select(o => new
        {
            o.OrderId,
            Order_No = o.OrderNumber,
            Customer = o.CustomerName,
            Service = o.ServiceName,
            Weight = $"{o.WeightKg} kg",
            Total = $"₱{o.TotalAmount:N2}",
            Payment = o.PaymentRecorded ? "✔ Paid" : "⏳ Unpaid",
            o.Status,
            Time = o.CreatedAt.ToString("hh:mm tt")
        }).ToList();

        if (dgvTodayOrders.Columns["OrderId"] != null)
            dgvTodayOrders.Columns["OrderId"].Visible = false;
    }

    private void OpenSelectedOrderDetail()
    {
        if (dgvTodayOrders.SelectedRows.Count == 0) return;
        var row = dgvTodayOrders.SelectedRows[0];
        if (row.Cells["OrderId"].Value is int id)
        {
            var order = AppServices.Orders.GetById(id);
            if (order != null)
            {
                var f = new Staff.FrmOrderDetail(order);
                f.ShowDialog(this);
                LoadDashboardData();
            }
        }
    }
}
