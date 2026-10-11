using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using Customer = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmStaffDashboard : Form
{
    public FrmStaffDashboard()
    {
        BuildUI();
        LoadSummary();
    }

    // ─── Data ─────────────────────────────────────────────────────────────────

    private void LoadSummary()
    {
        var report = AppServices.Orders.GetDailyReport(DateTime.Today);

        lblPending.Text  = report.PendingOrders.ToString();
        lblTotal.Text    = report.TotalOrders.ToString();
        lblClaimed.Text  = report.ClaimedOrders.ToString();
        lblSales.Text    = $"₱{report.TotalSales:N2}";

        // Recent orders (last 10)
        var orders = AppServices.Orders.GetAll().Take(10).ToList();
        dgvOrders.DataSource = orders.Select(o => new
        {
            Order_No   = o.OrderNumber,
            Customer   = o.CustomerName,
            Service    = o.ServiceName,
            Weight     = $"{o.WeightKg} kg",
            Total      = $"₱{o.TotalAmount:N2}",
            Status     = o.Status,
            Date       = o.CreatedAt.ToString("MM/dd hh:mm tt")
        }).ToList();
    }

    // ─── Navigation button handlers ──────────────────────────────────────────

    private void btnNewOrder_Click(object sender, EventArgs e)
    {
        var f = new FrmNewOrder();
        f.ShowDialog(this);
        LoadSummary();
    }

    private void btnOrders_Click(object sender, EventArgs e)
    {
        var f = new FrmOrderList();
        f.ShowDialog(this);
        LoadSummary();
    }

    private void btnCustomers_Click(object sender, EventArgs e)
    {
        var f = new FrmCustomerRegistration();
        f.ShowDialog(this);
    }

    private void btnRefresh_Click(object sender, EventArgs e) => LoadSummary();

    private void btnLogout_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Log out?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            this.Close();
    }

    // ─── UI Build ─────────────────────────────────────────────────────────────

    private Label lblPending = null!, lblTotal = null!,
                  lblClaimed = null!, lblSales = null!;
    private DataGridView dgvOrders = null!;

    private void BuildUI()
    {
        this.Text            = $"LaundryHub – Staff Dashboard ({SessionManager.CurrentUser?.FullName})";
        this.Size            = new Size(1100, 680);
        this.StartPosition   = FormStartPosition.CenterScreen;
        this.BackColor       = Color.FromArgb(15, 23, 42);
        this.MinimumSize     = new Size(900, 580);

        // ── Sidebar ───────────────────────────────────────────
        var sidebar = new Panel
        {
            Dock      = DockStyle.Left,
            Width     = 220,
            BackColor = Color.FromArgb(30, 41, 59)
        };

        var lblAppName = new Label
        {
            Text      = "🧺 LaundryHub",
            Font      = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            Dock      = DockStyle.Top,
            Height    = 60,
            TextAlign = ContentAlignment.MiddleCenter,
            Padding   = new Padding(0, 10, 0, 0)
        };

        var lblUser = new Label
        {
            Text      = $"👤 {SessionManager.CurrentUser?.FullName}\n   {SessionManager.CurrentUser?.Role}",
            Font      = new Font("Segoe UI", 8.5f),
            ForeColor = Color.FromArgb(148, 163, 184),
            Dock      = DockStyle.Top,
            Height    = 50,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var btnNewOrder  = MakeSidebarButton("➕  New Order",       Color.FromArgb(37, 99, 235));
        var btnOrders    = MakeSidebarButton("📋  View Orders",      Color.Transparent);
        var btnCustomers = MakeSidebarButton("👥  Customers",        Color.Transparent);
        var btnRefresh   = MakeSidebarButton("🔄  Refresh",          Color.Transparent);
        var btnLogout    = MakeSidebarButton("🚪  Logout",           Color.FromArgb(127, 29, 29));

        btnNewOrder.Click  += btnNewOrder_Click;
        btnOrders.Click    += btnOrders_Click;
        btnCustomers.Click += btnCustomers_Click;
        btnRefresh.Click   += btnRefresh_Click;
        btnLogout.Click    += btnLogout_Click;

        sidebar.Controls.AddRange(new Control[]
        { lblAppName, lblUser, btnNewOrder, btnOrders, btnCustomers, btnRefresh, btnLogout });

        // ── Content area ──────────────────────────────────────
        var content = new Panel
        {
            Dock      = DockStyle.Fill,
            Padding   = new Padding(20),
            BackColor = Color.FromArgb(15, 23, 42)
        };

        var lblDashboard = new Label
        {
            Text      = $"Dashboard — {DateTime.Today:MMMM dd, yyyy}",
            Font      = new Font("Segoe UI", 14, FontStyle.Bold),
            ForeColor = Color.White,
            Dock      = DockStyle.Top,
            Height    = 40
        };

        // ── Stat cards ────────────────────────────────────────
        var cardsPanel = new FlowLayoutPanel
        {
            Dock        = DockStyle.Top,
            Height      = 110,
            FlowDirection = FlowDirection.LeftToRight,
            BackColor   = Color.Transparent,
            Padding     = new Padding(0, 8, 0, 8)
        };

        cardsPanel.Controls.Add(MakeStatCard("Pending",       "#f59e0b", out lblPending));
        cardsPanel.Controls.Add(MakeStatCard("Total Today",   "#3b82f6", out lblTotal));
        cardsPanel.Controls.Add(MakeStatCard("Claimed",       "#10b981", out lblClaimed));
        cardsPanel.Controls.Add(MakeStatCard("Today's Sales", "#8b5cf6", out lblSales));

        // ── Recent Orders grid ────────────────────────────────
        var lblRecent = new Label
        {
            Text      = "Recent Orders",
            Font      = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.FromArgb(148, 163, 184),
            Dock      = DockStyle.Top,
            Height    = 30
        };

        dgvOrders = new DataGridView
        {
            Dock                  = DockStyle.Fill,
            BackgroundColor       = Color.FromArgb(30, 41, 59),
            BorderStyle           = BorderStyle.None,
            RowHeadersVisible     = false,
            AllowUserToAddRows    = false,
            AllowUserToDeleteRows = false,
            ReadOnly              = true,
            SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill,
            Font                  = new Font("Segoe UI", 9),
            GridColor             = Color.FromArgb(51, 65, 85),
            DefaultCellStyle =
            {
                BackColor         = Color.FromArgb(30, 41, 59),
                ForeColor         = Color.White,
                SelectionBackColor = Color.FromArgb(37, 99, 235),
                SelectionForeColor = Color.White
            },
            ColumnHeadersDefaultCellStyle =
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.FromArgb(96, 165, 250),
                Font      = new Font("Segoe UI Semibold", 9, FontStyle.Bold)
            },
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            ColumnHeadersHeight         = 32
        };
        dgvOrders.CellFormatting += DgvOrders_CellFormatting;

        content.Controls.AddRange(new Control[]
        { lblDashboard, cardsPanel, lblRecent, dgvOrders });

        this.Controls.AddRange(new Control[] { content, sidebar });
    }

    // Color-code the Status column
    private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvOrders.Columns[e.ColumnIndex].Name != "Status") return;
        e.CellStyle.ForeColor = e.Value?.ToString() switch
        {
            "Washing"          => Color.FromArgb(251, 191, 36),
            "Drying"           => Color.FromArgb(96, 165, 250),
            "Ready for Pickup" => Color.FromArgb(52, 211, 153),
            "Claimed"          => Color.FromArgb(134, 239, 172),
            "Cancelled"        => Color.FromArgb(248, 113, 113),
            _                  => Color.White
        };
    }

    private static Panel MakeStatCard(string title, string hexColor, out Label valueLabel)
    {
        var card = new Panel
        {
            Size      = new Size(185, 90),
            Margin    = new Padding(0, 0, 12, 0),
            BackColor = Color.FromArgb(30, 41, 59)
        };
        card.Paint += (s, e) =>
        {
            using var pen = new Pen(ColorTranslator.FromHtml(hexColor), 2);
            e.Graphics.DrawLine(pen, 0, 0, 0, card.Height);
        };

        var lbl = new Label
        {
            Text      = title,
            Font      = new Font("Segoe UI", 8.5f),
            ForeColor = Color.FromArgb(148, 163, 184),
            Location  = new Point(12, 10),
            AutoSize  = true
        };
        valueLabel = new Label
        {
            Text      = "—",
            Font      = new Font("Segoe UI", 20, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(hexColor),
            Location  = new Point(12, 30),
            AutoSize  = true
        };
        card.Controls.AddRange(new Control[] { lbl, valueLabel });
        return card;
    }

    private static Button MakeSidebarButton(string text, Color bg)
    {
        var btn = new Button
        {
            Text      = text,
            Dock      = DockStyle.Top,
            Height    = 44,
            Font      = new Font("Segoe UI", 9.5f),
            ForeColor = Color.White,
            BackColor = bg,
            FlatStyle = FlatStyle.Flat,
            TextAlign = ContentAlignment.MiddleLeft,
            Padding   = new Padding(16, 0, 0, 0),
            Cursor    = Cursors.Hand
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }
}
