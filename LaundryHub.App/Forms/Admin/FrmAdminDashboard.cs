using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Drawing.Drawing2D;
using ReaLTaiizor.Util;
using System.Threading.Tasks;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmAdminDashboard : Form
{
    private System.Windows.Forms.Timer? searchDebounceTimer;
    private bool isLoading = false;
    private List<Order>? cachedOrders;
    private readonly List<MonthOption> monthOptions = new();
    private Label? lblMonthlyOrders;
    private Label? lblMonthlyRevenue;
    private Label? lblMonthlyInProgress;
    private Label? lblMonthlyClaimed;
    private Label? lblChartRevenue;
    private MonthlyRevenueChart? revenueChart;

    public FrmAdminDashboard()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;

        UIThemeHelper.StyleDataGridView(dgvTodayOrders);
        UIThemeHelper.EnableStatusPills(dgvTodayOrders);

        // Sidebar Branding & Navigation
        pnlSidebar.BrandLabel.Text = " LaundryHub";
        pnlSidebar.BrandSubtitle.Text = "ADMIN & OPERATIONS";

        pnlSidebar.AddSection("GENERAL");
        var btnNavDash = pnlSidebar.AddNavButton("", "Overview & Analytics");
        btnNavDash.IsActive = true;

        pnlSidebar.AddSection("OPERATIONS");
        pnlSidebar.AddNavButton("", "New Laundry Order", btnNewOrder_Click);
        pnlSidebar.AddNavButton("", "Customer Management", btnCustomerRegistration_Click);

        pnlSidebar.AddSection("ADMINISTRATION");
        pnlSidebar.AddNavButton("", "Manage Staff", btnManageStaff_Click);
        pnlSidebar.AddNavButton("", "Services & Rates", btnServicePricing_Click);
        pnlSidebar.AddNavButton("", "Daily Reports & Excel", btnExportReport_Click);

        pnlSidebar.AddSection("SYSTEM");
        pnlSidebar.AddNavButton("", "Refresh Dashboard", btnRefresh_Click);
        pnlSidebar.AddNavButton("", "Logout", btnLogout_Click);

        // Header Bar Setup
        pnlHeader.Title = "Platform Overview & Analytics";
        pnlHeader.Subtitle = "ALL ORDERS  ·  REAL-TIME WORKFLOW, PERFORMANCE & REVENUE MONITORING";
        pnlHeader.SearchBox.Hint = "Search order #, customer, status...";
        pnlHeader.SearchBox.TextChanged += txtSearch_TextChanged;
        pnlHeader.ActionButton.Text = " Logout";
        pnlHeader.ActionButton.Click += btnLogout_Click;

        if (SessionManager.CurrentUser != null)
        {
            pnlHeader.UserName = SessionManager.CurrentUser.FullName;
            pnlHeader.UserRole = SessionManager.CurrentUser.Role;
        }

        BuildMonthlyAnalytics();
        cardOrders.BringToFront();
        dgvTodayOrders.BringToFront();

        this.Shown += async (_, _) =>
        {
            await LoadDashboardDataAsync();
        };

        searchDebounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
        searchDebounceTimer.Tick += SearchDebounceTimer_Tick;

        this.FormClosing += (_, _) =>
        {
            searchDebounceTimer?.Stop();
            searchDebounceTimer?.Dispose();
        };
    }

    private void btnLogout_Click(object? sender, EventArgs e) => this.Close();

    private void btnManageStaff_Click(object? sender, EventArgs e)
    {
        using var f = new FrmManageStaff();
        f.ShowDialog(this);
    }

    private void btnServicePricing_Click(object? sender, EventArgs e)
    {
        using var f = new FrmServicePricing();
        f.ShowDialog(this);
    }

    private void btnExportReport_Click(object? sender, EventArgs e)
    {
        using var f = new FrmExportReport();
        f.ShowDialog(this);
    }

    private void btnCustomerRegistration_Click(object? sender, EventArgs e)
    {
        using var f = new Staff.FrmCustomerRegistration();
        f.ShowDialog(this);
    }

    private async void btnNewOrder_Click(object? sender, EventArgs e)
    {
        DataCache.Invalidate("admin_all_orders");
        var f = new Staff.FrmNewOrder();
        if (f.ShowDialog(this) == DialogResult.OK) await LoadDashboardDataAsync();
    }

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        DataCache.Invalidate("admin_all_orders");
        await LoadDashboardDataAsync();
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        searchDebounceTimer?.Stop();
        searchDebounceTimer?.Start();
    }

    private void SearchDebounceTimer_Tick(object? sender, EventArgs e)
    {
        searchDebounceTimer?.Stop();
        var query = pnlHeader.SearchBox.Text.Trim();
        if (cachedOrders != null)
        {
            this.SafeInvoke(() => FilterOrders(query));
        }
    }

    private void dgvTodayOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e) => OpenSelectedOrderDetail();

    private async Task LoadDashboardDataAsync()
    {
        if (isLoading) return;
        isLoading = true;

        try
        {
            var orders = await DataCache.GetOrAddAsync("admin_all_orders",
                () => Task.Run(() => AppServices.Orders.GetAll().ToList()),
                TimeSpan.FromSeconds(30));

            cachedOrders = orders;

            this.SafeInvoke(() =>
            {
                var todayCount = orders.Count(o => o.CreatedAt.Date == DateTime.Today);
                lblLiveBadge.Text = $" {todayCount} Total Today";
                PopulateGrid(orders);
                UpdateMonthlyAnalytics();
            });
        }
        finally
        {
            isLoading = false;
        }
    }

    private void BuildMonthlyAnalytics()
    {
        pnlMain.Controls.Remove(flpStats);
        flpStats.Dispose();

        var section = new Panel
        {
            Dock = DockStyle.Top,
            Height = 244,
            BackColor = Color.Transparent,
            Padding = Padding.Empty,
            Name = "pnlMonthlyAnalytics"
        };

        var selector = new ComboBox
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = new Font("Segoe UI", 9F),
            ForeColor = UIThemeHelper.Navy,
            BackColor = Color.White,
            Width = 150,
            Height = 30,
            Location = new Point(section.ClientSize.Width - 150, 2),
            Name = "cboAnalyticsMonth"
        };
        selector.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        for (int monthOffset = 0; monthOffset < 12; monthOffset++)
        {
            var month = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-monthOffset);
            var option = new MonthOption(month, monthOffset == 0 ? "Current" : month.ToString("MMMM yyyy"));
            monthOptions.Add(option);
            selector.Items.Add(option);
        }
        selector.SelectedIndex = 0;
        selector.SelectedIndexChanged += (_, _) => UpdateMonthlyAnalytics();

        var sectionTitle = new Label
        {
            Text = "Monthly Overview",
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Dock = DockStyle.Left,
            Width = 220,
            TextAlign = ContentAlignment.MiddleLeft
        };
        var sectionHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 38,
            BackColor = Color.Transparent
        };
        sectionHeader.Controls.Add(selector);
        sectionHeader.Controls.Add(sectionTitle);

        var summaryCard = new RoundedCard
        {
            Dock = DockStyle.Fill,
            FillColor = Color.White,
            BorderColor = UIThemeHelper.Border,
            Radius = 14,
            Shadow = true,
            Padding = new Padding(12),
            Margin = new Padding(0, 3, 10, 7),
            Name = "cardMonthlySummary"
        };
        var summaryGrid = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = UIThemeHelper.Border,
            ColumnCount = 2,
            RowCount = 2,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
            Margin = Padding.Empty,
            Padding = new Padding(1)
        };
        summaryGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        summaryGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        summaryGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        summaryGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

        (lblMonthlyOrders, var ordersCell) = CreateMetricCell("Total Orders", UIThemeHelper.Indigo);
        (lblMonthlyRevenue, var revenueCell) = CreateMetricCell("Total Revenue", UIThemeHelper.Success);
        (lblMonthlyInProgress, var progressCell) = CreateMetricCell("In Progress", UIThemeHelper.Warning);
        (lblMonthlyClaimed, var claimedCell) = CreateMetricCell("Claimed", UIThemeHelper.Slate);
        summaryGrid.Controls.Add(ordersCell, 0, 0);
        summaryGrid.Controls.Add(revenueCell, 1, 0);
        summaryGrid.Controls.Add(progressCell, 0, 1);
        summaryGrid.Controls.Add(claimedCell, 1, 1);
        summaryCard.Controls.Add(summaryGrid);

        var chartCard = new RoundedCard
        {
            Dock = DockStyle.Fill,
            FillColor = Color.White,
            BorderColor = UIThemeHelper.Border,
            Radius = 14,
            Shadow = true,
            Padding = new Padding(15, 11, 15, 12),
            Margin = new Padding(0, 3, 0, 7),
            Name = "cardMonthlyRevenue"
        };
        var chartHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 43,
            BackColor = Color.White
        };
        var chartTitle = new Label
        {
            Text = "Monthly Revenue",
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Dock = DockStyle.Top,
            Height = 21,
            TextAlign = ContentAlignment.MiddleLeft
        };
        lblChartRevenue = new Label
        {
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = UIThemeHelper.TextMuted,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };
        chartHeader.Controls.Add(lblChartRevenue);
        chartHeader.Controls.Add(chartTitle);
        revenueChart = new MonthlyRevenueChart
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White
        };
        chartCard.Controls.Add(revenueChart);
        chartCard.Controls.Add(chartHeader);

        var content = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = Color.Transparent,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        content.Controls.Add(summaryCard, 0, 0);
        content.Controls.Add(chartCard, 1, 0);

        section.Controls.Add(content);
        section.Controls.Add(sectionHeader);
        pnlMain.Controls.Add(section);
        cardOrders.BringToFront();
    }

    private static (Label Value, Panel Cell) CreateMetricCell(string caption, Color accent)
    {
        var value = new Label
        {
            Text = "0",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            TextAlign = ContentAlignment.MiddleLeft,
            AutoEllipsis = true
        };
        var title = new Label
        {
            Text = caption,
            Dock = DockStyle.Top,
            Height = 21,
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = UIThemeHelper.TextMuted,
            TextAlign = ContentAlignment.MiddleLeft,
            AutoEllipsis = true
        };
        var accentLine = new Panel
        {
            Dock = DockStyle.Left,
            Width = 3,
            BackColor = accent,
            Margin = new Padding(0, 1, 9, 1)
        };
        var textPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(8, 4, 5, 3),
            BackColor = Color.White
        };
        textPanel.Controls.Add(value);
        textPanel.Controls.Add(title);
        var cell = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(4),
            BackColor = Color.White
        };
        cell.Controls.Add(textPanel);
        cell.Controls.Add(accentLine);
        return (value, cell);
    }

    private void UpdateMonthlyAnalytics()
    {
        if (cachedOrders == null || lblMonthlyOrders == null || lblMonthlyRevenue == null ||
            lblMonthlyInProgress == null || lblMonthlyClaimed == null || revenueChart == null ||
            lblChartRevenue == null || monthOptions.Count == 0)
            return;

        var selector = Controls.Find("cboAnalyticsMonth", true).FirstOrDefault() as ComboBox;
        var selectedOption = selector?.SelectedItem as MonthOption ?? monthOptions[0];
        var monthStart = selectedOption.Month;
        var nextMonth = monthStart.AddMonths(1);
        var monthOrders = cachedOrders
            .Where(o => o.CreatedAt >= monthStart && o.CreatedAt < nextMonth)
            .ToList();
        var revenueOrders = cachedOrders
            .Where(o => o.Status == "Claimed" && o.PaymentRecorded &&
                        o.ClaimedAt.HasValue && o.ClaimedAt.Value >= monthStart &&
                        o.ClaimedAt.Value < nextMonth)
            .ToList();
        var dailyRevenue = revenueOrders
            .GroupBy(o => o.ClaimedAt!.Value.Day)
            .ToDictionary(day => day.Key, day => day.Sum(o => o.TotalAmount));

        lblMonthlyOrders.Text = monthOrders.Count.ToString();
        lblMonthlyRevenue.Text = revenueOrders.Sum(o => o.TotalAmount).ToString("N2");
        lblMonthlyInProgress.Text = monthOrders.Count(o =>
            o.Status is "Washing" or "Drying" or "Ready for Pickup").ToString();
        lblMonthlyClaimed.Text = monthOrders.Count(o => o.Status == "Claimed").ToString();
        lblChartRevenue.Text = $"{selectedOption.Label} · {revenueOrders.Sum(o => o.TotalAmount):N2} collected";
        revenueChart.SetData(DateTime.DaysInMonth(monthStart.Year, monthStart.Month), dailyRevenue);
    }

    private sealed record MonthOption(DateTime Month, string Label)
    {
        public override string ToString() => Label;
    }

    private sealed class MonthlyRevenueChart : Control
    {
        private int _daysInMonth;
        private IReadOnlyDictionary<int, decimal> _dailyRevenue = new Dictionary<int, decimal>();

        public MonthlyRevenueChart()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        public void SetData(int daysInMonth, IReadOnlyDictionary<int, decimal> dailyRevenue)
        {
            _daysInMonth = daysInMonth;
            _dailyRevenue = dailyRevenue;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graph = new Rectangle(42, 8, Width - 53, Height - 34);
            if (graph.Width <= 0 || graph.Height <= 0) return;

            var maxRevenue = _dailyRevenue.Count == 0 ? 0 : _dailyRevenue.Values.Max();
            if (maxRevenue <= 0)
            {
                TextRenderer.DrawText(e.Graphics, "No collected revenue for this month",
                    Font, graph, UIThemeHelper.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var plot = new Rectangle(graph.X, graph.Y, graph.Width, graph.Height - 16);
            var scaleMax = maxRevenue * 1.15m;
            using var gridPen = new Pen(UIThemeHelper.Border, 1);
            using var axisFont = new Font("Segoe UI", 7F);
            using var barBrush = new SolidBrush(UIThemeHelper.Indigo);

            for (int line = 0; line <= 2; line++)
            {
                var y = plot.Bottom - (int)(plot.Height * line / 2f);
                e.Graphics.DrawLine(gridPen, plot.Left, y, plot.Right, y);
                var amount = scaleMax * line / 2m;
                var label = amount.ToString("N0");
                TextRenderer.DrawText(e.Graphics, label, axisFont,
                    new Rectangle(0, y - 8, plot.Left - 6, 16), UIThemeHelper.TextMuted,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }

            var slotWidth = (float)plot.Width / _daysInMonth;
            var barWidth = Math.Max(2, slotWidth * 0.62f);
            for (int day = 1; day <= _daysInMonth; day++)
            {
                if (!_dailyRevenue.TryGetValue(day, out var amount) || amount <= 0) continue;
                var barHeight = (float)(amount / scaleMax * plot.Height);
                var x = plot.Left + (day - 1) * slotWidth + (slotWidth - barWidth) / 2;
                var y = plot.Bottom - barHeight;
                e.Graphics.FillRectangle(barBrush, x, y, barWidth, barHeight);
            }

            for (int day = 1; day <= _daysInMonth; day += 5)
            {
                var x = plot.Left + (day - 0.5f) * slotWidth;
                TextRenderer.DrawText(e.Graphics, day.ToString(), axisFont,
                    new Rectangle((int)x - 10, plot.Bottom + 2, 20, 14), UIThemeHelper.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.NoPadding);
            }
        }
    }

    private void FilterOrders(string query)
    {
        if (cachedOrders == null) return;

        if (string.IsNullOrWhiteSpace(query))
        {
            PopulateGrid(cachedOrders);
        }
        else
        {
            var q = query.ToLower();
            var filtered = cachedOrders.Where(o =>
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
            Service = $"{o.ServiceName} — {o.LaundryCategory}",
            Weight = $"{o.WeightKg} kg",
            Total = $"{o.TotalAmount:N2}",
            Payment = o.PaymentRecorded ? "Paid" : "Unpaid",
            o.Status,
            Time = o.CreatedAt.ToString("MMM dd, yyyy  hh:mm tt")
        }).ToList();

        if (dgvTodayOrders.Columns["OrderId"] is { } col)
            col.Visible = false;
    }

    private async void OpenSelectedOrderDetail()
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
                DataCache.Invalidate("admin_all_orders");
                await LoadDashboardDataAsync();
            }
        }
    }
}
