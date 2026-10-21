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
        pnlHeader.Subtitle = "REAL-TIME LAUNDRY WORKFLOW, PERFORMANCE & REVENUE MONITORING";
        pnlHeader.SearchBox.Hint = "Search order #, customer, status...";
        pnlHeader.SearchBox.TextChanged += txtSearch_TextChanged;
        pnlHeader.ActionButton.Text = " Logout";
        pnlHeader.ActionButton.Click += btnLogout_Click;

        if (SessionManager.CurrentUser != null)
        {
            pnlHeader.UserName = SessionManager.CurrentUser.FullName;
            pnlHeader.UserRole = SessionManager.CurrentUser.Role;
        }

        var stats = StatRow.Replace(flpStats,
            ("Today's Total Orders", UIThemeHelper.Indigo),
            ("Today's Revenue",      UIThemeHelper.Success),
            ("Pending in Progress",  UIThemeHelper.Warning),
            ("Claimed Today",        UIThemeHelper.Slate));
        lblTotalToday = stats[0].ValueLabel;
        lblSalesToday = stats[1].ValueLabel;
        lblPending    = stats[2].ValueLabel;
        lblClaimed    = stats[3].ValueLabel;
        lblSalesToday.Font = new Font("Segoe UI", 17F, FontStyle.Bold);

        lblTotalToday.Text = "";
        lblSalesToday.Text = "";
        lblPending.Text = "";
        lblClaimed.Text = "";

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
        DataCache.InvalidatePrefix("daily_report");
        var f = new Staff.FrmNewOrder();
        if (f.ShowDialog(this) == DialogResult.OK) await LoadDashboardDataAsync();
    }

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        DataCache.InvalidatePrefix("daily_report");
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
            var cacheKey = $"daily_report_{DateTime.Today:yyyyMMdd}";
            var report = await DataCache.GetOrAddAsync(cacheKey,
                () => Task.Run(() => AppServices.Orders.GetDailyReport(DateTime.Today)),
                TimeSpan.FromSeconds(30));

            cachedOrders = report.Orders.ToList();

            this.SafeInvoke(() =>
            {
                lblTotalToday.Text = report.TotalOrders.ToString();
                lblSalesToday.Text = $"{report.TotalSales:N2}";
                lblPending.Text = report.PendingOrders.ToString();
                lblClaimed.Text = report.ClaimedOrders.ToString();

                lblLiveBadge.Text = $" {report.TotalOrders} Live";

                PopulateGrid(report.Orders);
            });
        }
        finally
        {
            isLoading = false;
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
            Service = o.ServiceName,
            Weight = $"{o.WeightKg} kg",
            Total = $"{o.TotalAmount:N2}",
            Payment = o.PaymentRecorded ? "Paid" : "Unpaid",
            o.Status,
            Time = o.CreatedAt.ToString("hh:mm tt")
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
                await LoadDashboardDataAsync();
            }
        }
    }
}
