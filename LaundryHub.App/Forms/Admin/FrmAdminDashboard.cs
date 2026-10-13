using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Drawing.Drawing2D;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmAdminDashboard : Form
{
    private System.Windows.Forms.Timer? clockTimer;

    public FrmAdminDashboard()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;
        pnlHeader.BackColor = Color.FromArgb(37, 78, 122);
        lblWelcome.BackColor = Color.FromArgb(37, 78, 122);
        lblLogo.BackColor = Color.FromArgb(37, 78, 122);
        lblClock.BackColor = Color.FromArgb(37, 78, 122);
        UIThemeHelper.StyleDataGridView(dgvTodayOrders);
        UIThemeHelper.ApplyRoundedRegion(pnlMain, UIThemeHelper.ContentCardRadius);
        pnlMain.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlMain, UIThemeHelper.ContentCardRadius);
        UIThemeHelper.ApplyRoundedRegion(pnlStatOrders, 10);
        UIThemeHelper.ApplyRoundedRegion(pnlStatRevenue, 10);
        UIThemeHelper.ApplyRoundedRegion(pnlStatPending, 10);
        UIThemeHelper.ApplyRoundedRegion(pnlStatClaimed, 10);

        pnlSidebar.Paint += pnlSidebar_Paint;
        ApplyNavButtonStyles();

        if (SessionManager.CurrentUser != null)
        {
            lblWelcome.Text = $"LaundryHub Admin  •  {SessionManager.CurrentUser.FullName}";
            LoadDashboardData();
        }

        clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
        clockTimer.Tick += (_, _) => lblClock.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  hh:mm:ss tt");
        clockTimer.Start();
        lblClock.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  hh:mm:ss tt");
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void pnlMain_Paint(object sender, PaintEventArgs e)
    {
        UIThemeHelper.PaintRoundedSolidCard(pnlMain, e, Color.White, UIThemeHelper.ContentCardRadius);
    }

    private void pnlSidebar_Paint(object? sender, PaintEventArgs e)
    {
        UIThemeHelper.PaintGradientBackground(pnlSidebar, e);
    }

    private void ApplyNavButtonStyles()
    {
        foreach (var btn in new[] { btnManageStaff, btnServicePricing, btnExportReport, btnStaffDashboard, btnCustomerRegistration, btnRefresh })
        {
            btn.ButtonType = HopeButtonType.Primary;
            btn.PrimaryColor = Color.FromArgb(37, 78, 122);
            btn.TextColor = Color.White;
            btn.HoverTextColor = Color.White;
        }

        // Primary action button — HopeButton pill highlight.
        btnNewOrder.ButtonType = HopeButtonType.Primary;
        btnNewOrder.PrimaryColor = Color.FromArgb(102, 163, 191);
        btnNewOrder.TextColor = Color.White;
        btnNewOrder.HoverTextColor = Color.White;

        btnLogout.ButtonType = HopeButtonType.Primary;
        btnLogout.PrimaryColor = Color.FromArgb(190, 60, 60);
        btnLogout.TextColor = Color.White;
        btnLogout.HoverTextColor = Color.White;

        btnLogoutNav.ButtonType = HopeButtonType.Primary;
        btnLogoutNav.PrimaryColor = Color.FromArgb(190, 60, 60);
        btnLogoutNav.TextColor = Color.White;
        btnLogoutNav.HoverTextColor = Color.White;
    }

    private void btnLogout_Click(object? sender, EventArgs e) => this.Close();

    private void btnManageStaff_Click(object? sender, EventArgs e) => new FrmManageStaff().ShowDialog(this);
    private void btnServicePricing_Click(object? sender, EventArgs e) => new FrmServicePricing().ShowDialog(this);
    private void btnExportReport_Click(object? sender, EventArgs e) => new FrmExportReport().ShowDialog(this);
    private void btnStaffDashboard_Click(object? sender, EventArgs e) => new Staff.FrmStaffDashboard().ShowDialog(this);
    private void btnCustomerRegistration_Click(object? sender, EventArgs e) => new Staff.FrmCustomerRegistration().ShowDialog(this);

    private void btnNewOrder_Click(object? sender, EventArgs e)
    {
        var f = new Staff.FrmNewOrder();
        if (f.ShowDialog(this) == DialogResult.OK) LoadDashboardData();
    }

    private void btnRefresh_Click(object? sender, EventArgs e) => LoadDashboardData();

    private void txtSearch_TextChanged(object? sender, EventArgs e) => FilterOrders(txtSearch.Text.Trim());

    private void dgvTodayOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e) => OpenSelectedOrderDetail();

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
            Payment = o.PaymentRecorded ? "Paid" : "Unpaid",
            o.Status,
            Time = o.CreatedAt.ToString("hh:mm tt")
        }).ToList();

        if (dgvTodayOrders.Columns["OrderId"] is { } col)
            col.Visible = false;
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
