using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmAdminDashboard : Form
{
    private System.Windows.Forms.Timer? clockTimer;

    public FrmAdminDashboard()
    {
        InitializeComponent();

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
            Service = $"{o.ServiceName} — {o.LaundryCategory}",
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
