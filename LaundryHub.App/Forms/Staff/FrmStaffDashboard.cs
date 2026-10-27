using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmStaffDashboard : Form
{
    public FrmStaffDashboard()
    {
        InitializeComponent();

        if (SessionManager.CurrentUser != null)
        {
            this.Text = $"LaundryHub – Staff Dashboard ({SessionManager.CurrentUser.FullName})";
            lblUser.Text = $"👤 {SessionManager.CurrentUser.FullName}\n   {SessionManager.CurrentUser.Role}";
            lblDashboard.Text = $"Dashboard — {DateTime.Today:MMMM dd, yyyy}";
            LoadSummary();
        }
    }

    private void LoadSummary()
    {
        var report = AppServices.Orders.GetDailyReport(DateTime.Today);

        lblPending.Text = report.PendingOrders.ToString();
        lblTotal.Text = report.TotalOrders.ToString();
        lblClaimed.Text = report.ClaimedOrders.ToString();
        lblSales.Text = $"₱{report.TotalSales:N2}";

        // Recent orders (last 10)
        var orders = AppServices.Orders.GetAll().Take(10).ToList();
        dgvOrders.DataSource = orders.Select(o => new
        {
            Order_No = o.OrderNumber,
            Customer = o.CustomerName,
            Service = $"{o.ServiceName} — {o.LaundryCategory}",
            Weight = $"{o.WeightKg} kg",
            Total = $"₱{o.TotalAmount:N2}",
            Status = o.Status,
            Date = o.CreatedAt.ToString("MM/dd hh:mm tt")
        }).ToList();
    }

    private void btnNewOrder_Click(object? sender, EventArgs e)
    {
        var f = new FrmNewOrder();
        f.ShowDialog(this);
        LoadSummary();
    }

    private void btnOrders_Click(object? sender, EventArgs e)
    {
        var f = new FrmOrderList();
        f.ShowDialog(this);
        LoadSummary();
    }

    private void btnCustomers_Click(object? sender, EventArgs e)
    {
        var f = new FrmCustomerRegistration();
        f.ShowDialog(this);
    }

    private void btnRefresh_Click(object? sender, EventArgs e) => LoadSummary();

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show("Log out?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            this.Close();
    }

    private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvOrders.Columns[e.ColumnIndex].Name != "Status") return;
        e.CellStyle.ForeColor = e.Value?.ToString() switch
        {
            "Booked" => Color.FromArgb(203, 213, 225),
            "Washing" => Color.FromArgb(251, 191, 36),
            "Drying" => Color.FromArgb(96, 165, 250),
            "Ready for Pickup" => Color.FromArgb(52, 211, 153),
            "Claimed" => Color.FromArgb(134, 239, 172),
            "Cancelled" => Color.FromArgb(248, 113, 113),
            _ => Color.White
        };
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
