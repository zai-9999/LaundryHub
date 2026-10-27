using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmStaffDashboard : Form
{
    private bool isLoading = false;
    private List<Order>? _cachedOrders;
    private ContextMenuStrip? _statusMenu;
    private int _selectedOrderId = -1;
    private string _selectedOrderStatus = "";

    public FrmStaffDashboard()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;

        UIThemeHelper.StyleDataGridView(dgvOrders);
        UIThemeHelper.EnableStatusPills(dgvOrders);

        // Sidebar Setup
        pnlSidebar.BrandLabel.Text = " LaundryHub";
        pnlSidebar.BrandSubtitle.Text = "STAFF OPERATIONS";

        pnlSidebar.AddSection("GENERAL");
        var btnNavDash = pnlSidebar.AddNavButton("", "Operations Dashboard");
        btnNavDash.IsActive = true;

        pnlSidebar.AddSection("LAUNDRY WORKFLOW");
        pnlSidebar.AddNavButton("", "New Laundry Order", btnNewOrder_Click);
        pnlSidebar.AddNavButton("", "Order Management", btnOrders_Click);
        pnlSidebar.AddNavButton("", "Customer Directory", btnCustomers_Click);

        pnlSidebar.AddSection("SYSTEM");
        pnlSidebar.AddNavButton("", "Refresh Queue", btnRefresh_Click);
        pnlSidebar.AddNavButton("", "Logout", btnLogout_Click);

        // Header Setup
        pnlHeader.Title = "Laundry Operations & Order Hub";
        pnlHeader.Subtitle = "REAL-TIME SERVICE QUEUE, ORDERS & CUSTOMER INTAKE";
        pnlHeader.SearchBox.Hint = "Quick search orders...";
        pnlHeader.SearchBox.TextChanged += (s, e) => FilterOrders();
        pnlHeader.ActionButton.Text = " Logout";
        pnlHeader.ActionButton.Click += btnLogout_Click;

        if (SessionManager.CurrentUser != null)
        {
            pnlHeader.UserName = SessionManager.CurrentUser.FullName;
            pnlHeader.UserRole = SessionManager.CurrentUser.Role;
            this.Text = $"LaundryHub  Staff Dashboard ({SessionManager.CurrentUser.FullName})";
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

        lblPending.Text = "";
        lblTotal.Text = "";
        lblClaimed.Text = "";
        lblSales.Text = "";

        dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;

        // Status quick-actions menu on the grid (right-click a row)
        _statusMenu = new ContextMenuStrip();
        _statusMenu.Opening += StatusMenu_Opening;
        _statusMenu.ItemClicked += StatusMenu_ItemClicked;
        dgvOrders.ContextMenuStrip = _statusMenu;

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

            _cachedOrders = orders;

            this.SafeInvoke(() =>
            {
                lblPending.Text = report.PendingOrders.ToString();
                lblTotal.Text = report.TotalOrders.ToString();
                lblClaimed.Text = report.ClaimedOrders.ToString();
                lblSales.Text = $"{report.TotalSales:N2}";

                lblLiveBadge.Text = $" {orders.Count} In Queue";

                FilterOrders();
            });
        }
        finally
        {
            isLoading = false;
        }
    }

    private void FilterOrders()
    {
        if (_cachedOrders == null) return;

        var query = pnlHeader.SearchBox.Text.Trim();
        var list = _cachedOrders.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(query))
        {
            var q = query.ToLower();
            list = list.Where(o =>
                o.OrderNumber.ToLower().Contains(q) ||
                (o.CustomerName?.ToLower().Contains(q) ?? false) ||
                (o.ServiceName?.ToLower().Contains(q) ?? false) ||
                o.Status.ToLower().Contains(q));
        }

        dgvOrders.DataSource = list.Select(o => new
        {
            o.OrderId,
            Order_No = o.OrderNumber,
            Customer = o.CustomerName,
            Service = $"{o.ServiceName} — {o.LaundryCategory}",
            Weight = $"{o.WeightKg} kg",
            Total = $"{o.TotalAmount:N2}",
            Status = o.Status,
            Payment = o.PaymentRecorded ? "Paid" : "Unpaid",
            Date = o.CreatedAt.ToString("MM/dd hh:mm tt")
        }).ToList();

        if (dgvOrders.Columns["OrderId"] is { } col)
            col.Visible = false;
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

    private void StatusMenu_Opening(object? sender, CancelEventArgs e)
    {
        _statusMenu!.Items.Clear();
        if (dgvOrders.SelectedRows.Count == 0)
        {
            e.Cancel = true;
            return;
        }

        var row = dgvOrders.SelectedRows[0];
        if (row.Cells["OrderId"]?.Value is not int id)
        {
            e.Cancel = true;
            return;
        }
        _selectedOrderId = id;
        _selectedOrderStatus = row.Cells["Status"]?.Value?.ToString() ?? "";

        void Add(string text, string nextStatus)
        {
            var item = new ToolStripMenuItem(text) { Tag = nextStatus };
            _statusMenu!.Items.Add(item);
        }

        switch (_selectedOrderStatus)
        {
            case "Booked":
                Add("Mark as Washing", "Washing");
                break;
            case "Washing":
                Add("Mark as Drying", "Drying");
                break;
            case "Drying":
                Add("Mark as Ready for Pickup", "Ready for Pickup");
                break;
            case "Ready for Pickup":
                // claiming requires payment entry via Order Detail
                break;
            case "Claimed":
            case "Cancelled":
                e.Cancel = true;
                return;
            default:
                Add("Update Status", "Washing");
                break;
        }

        if (_selectedOrderStatus == "Ready for Pickup")
        {
            if (_statusMenu.Items.Count == 0) e.Cancel = true;
            return;
        }

        if (_statusMenu.Items.Count > 0)
        {
            _statusMenu.Items.Add(new ToolStripSeparator());
        }
        _statusMenu.Items.Add(new ToolStripMenuItem("Cancel Order") { Tag = "Cancelled" });
    }

    private async void StatusMenu_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
    {
        if (_selectedOrderId < 0 || e.ClickedItem?.Tag is not string nextStatus) return;

        try
        {
            AppServices.Orders.UpdateStatus(_selectedOrderId, nextStatus,
                changedBy: SessionManager.CurrentUser?.UserId);
            await LoadSummaryAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to update order status: {ex.Message}", "Status Update",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _selectedOrderId = -1;
            _selectedOrderStatus = "";
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

    private void pnlStatPending_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(245, 158, 11), 2);
        e.Graphics.DrawLine(pen, 0, 0, 0, pnlStatPending.Height);
    }

    private void pnlStatTotal_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(59, 130, 246), 2);
        e.Graphics.DrawLine(pen, 0, 0, 0, pnlStatTotal.Height);
    }

    private void pnlStatClaimed_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(16, 185, 129), 2);
        e.Graphics.DrawLine(pen, 0, 0, 0, pnlStatClaimed.Height);
    }

    private void pnlStatSales_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(139, 92, 246), 2);
        e.Graphics.DrawLine(pen, 0, 0, 0, pnlStatSales.Height);
    }
}
