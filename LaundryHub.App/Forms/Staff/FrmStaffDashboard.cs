using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmStaffDashboard : Form
{
    private bool isLoading = false;

    public FrmStaffDashboard()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;

        UIThemeHelper.StyleDataGridView(dgvOrders);
        UIThemeHelper.EnableStatusPills(dgvOrders);

        // Sidebar Setup
        pnlSidebar.BrandLabel.Text = "🧺 LaundryHub";
        pnlSidebar.BrandSubtitle.Text = "STAFF OPERATIONS";

        pnlSidebar.AddSection("GENERAL");
        var btnNavDash = pnlSidebar.AddNavButton("📊", "Operations Dashboard");
        btnNavDash.IsActive = true;

        pnlSidebar.AddSection("LAUNDRY WORKFLOW");
        pnlSidebar.AddNavButton("➕", "New Laundry Order", btnNewOrder_Click);
        pnlSidebar.AddNavButton("📋", "Order Management", btnOrders_Click);
        pnlSidebar.AddNavButton("👥", "Customer Directory", btnCustomers_Click);

        pnlSidebar.AddSection("SYSTEM");
        pnlSidebar.AddNavButton("🔄", "Refresh Queue", btnRefresh_Click);
        pnlSidebar.AddNavButton("🚪", "Logout", btnLogout_Click);

        // Header Setup
        pnlHeader.Title = "Laundry Operations & Order Hub";
        pnlHeader.Subtitle = "REAL-TIME SERVICE QUEUE, ORDERS & CUSTOMER INTAKE";
        pnlHeader.SearchBox.Hint = "Quick search orders...";
        pnlHeader.ActionButton.Text = "🚪 Logout";
        pnlHeader.ActionButton.Click += btnLogout_Click;

        if (SessionManager.CurrentUser != null)
        {
            pnlHeader.UserName = SessionManager.CurrentUser.FullName;
            pnlHeader.UserRole = SessionManager.CurrentUser.Role;
            this.Text = $"LaundryHub – Staff Dashboard ({SessionManager.CurrentUser.FullName})";
        }

        var stats = StatRow.Replace(flpCards,
            ("Pending",       UIThemeHelper.Slate),
            ("Total Today",   UIThemeHelper.Indigo),
            ("Claimed",       UIThemeHelper.Success),
            ("Today's Sales", UIThemeHelper.Warning));
        lblPending = stats[0].ValueLabel;
        lblTotal   = stats[1].ValueLabel;
        lblClaimed = stats[2].ValueLabel;
        lblSales   = stats[3].ValueLabel;
        lblSales.Font = new Font("Segoe UI", 17F, FontStyle.Bold);

        lblPending.Text = "—";
        lblTotal.Text = "—";
        lblClaimed.Text = "—";
        lblSales.Text = "—";

        dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;

        this.Shown += async (_, _) => await LoadSummaryAsync();
        this.FormClosing += (_, _) => isLoading = false;
    }

    private async Task LoadSummaryAsync()
    {
        if (isLoading) return;
        isLoading = true;

        try
        {
            var cacheKey = $"daily_report_{DateTime.Today:yyyyMMdd}";
            var report = await DataCache.GetOrAddAsync(cacheKey,
                () => Task.Run(() => AppServices.Orders.GetDailyReport(DateTime.Today)),
                TimeSpan.FromSeconds(30));

            var ordersCacheKey = $"recent_orders_10";
            var orders = await DataCache.GetOrAddAsync(ordersCacheKey,
                () => Task.Run(() => AppServices.Orders.GetAll().Take(15).ToList()),
                TimeSpan.FromSeconds(30));

            this.SafeInvoke(() =>
            {
                lblPending.Text = report.PendingOrders.ToString();
                lblTotal.Text = report.TotalOrders.ToString();
                lblClaimed.Text = report.ClaimedOrders.ToString();
                lblSales.Text = $"₱{report.TotalSales:N2}";

                lblLiveBadge.Text = $"● {orders.Count} In Queue";

                dgvOrders.DataSource = orders.Select(o => new
                {
                    o.OrderId,
                    Order_No = o.OrderNumber,
                    Customer = o.CustomerName,
                    Service = o.ServiceName,
                    Weight = $"{o.WeightKg} kg",
                    Total = $"₱{o.TotalAmount:N2}",
                    Status = o.Status,
                    Payment = o.PaymentRecorded ? "Paid" : "Unpaid",
                    Date = o.CreatedAt.ToString("MM/dd hh:mm tt")
                }).ToList();

                if (dgvOrders.Columns["OrderId"] is { } col)
                    col.Visible = false;
            });
        }
        finally
        {
            isLoading = false;
        }
    }

    private async void DgvOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (dgvOrders.SelectedRows.Count == 0) return;
        var row = dgvOrders.SelectedRows[0];
        if (row.Cells["OrderId"]?.Value is int id)
        {
            var order = AppServices.Orders.GetById(id);
            if (order != null)
            {
                var f = new FrmOrderDetail(order);
                f.ShowDialog(this);
                await LoadSummaryAsync();
            }
        }
    }

    private async void btnNewOrder_Click(object? sender, EventArgs e)
    {
        DataCache.InvalidatePrefix("daily_report");
        DataCache.InvalidatePrefix("recent_orders");
        var f = new FrmNewOrder();
        f.ShowDialog(this);
        await LoadSummaryAsync();
    }

    private async void btnOrders_Click(object? sender, EventArgs e)
    {
        DataCache.InvalidatePrefix("daily_report");
        DataCache.InvalidatePrefix("recent_orders");
        var f = new FrmOrderList();
        f.ShowDialog(this);
        await LoadSummaryAsync();
    }

    private void btnCustomers_Click(object? sender, EventArgs e)
    {
        var f = new FrmCustomerRegistration();
        f.ShowDialog(this);
    }

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        DataCache.InvalidatePrefix("daily_report");
        DataCache.InvalidatePrefix("recent_orders");
        await LoadSummaryAsync();
    }

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to log out of Staff Operations?", "Confirm Logout", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            this.Close();
    }

    private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        // Status pills handled by UIThemeHelper.EnableStatusPills
    }
}
