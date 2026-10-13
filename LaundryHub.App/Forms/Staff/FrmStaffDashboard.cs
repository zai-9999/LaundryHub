using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Drawing.Drawing2D;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmStaffDashboard : Form
{
    public FrmStaffDashboard()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;
        UIThemeHelper.StyleStandardForm(this);
        pnlSidebar.Paint += pnlSidebar_Paint;
        UIThemeHelper.StyleDataGridView(dgvOrders);
        UIThemeHelper.ApplyRoundedRegion(pnlContent, UIThemeHelper.ContentCardRadius);
        pnlContent.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlContent, UIThemeHelper.ContentCardRadius);
        ApplyNavButtonStyles();

        if (SessionManager.CurrentUser != null)
        {
            this.Text = $"LaundryHub – Staff Dashboard ({SessionManager.CurrentUser.FullName})";
            lblUser.Text = $"{SessionManager.CurrentUser.FullName}\n   {SessionManager.CurrentUser.Role}";
            lblDashboard.Text = $"Dashboard — {DateTime.Today:MMMM dd, yyyy}";
            LoadSummary();
        }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void pnlContent_Paint(object sender, PaintEventArgs e)
    {
        UIThemeHelper.PaintRoundedSolidCard(pnlContent, e, Color.White, UIThemeHelper.ContentCardRadius);
    }

    private void pnlSidebar_Paint(object? sender, PaintEventArgs e)
    {
        UIThemeHelper.PaintGradientBackground(pnlSidebar, e);
    }

    private void ApplyNavButtonStyles()
    {
        // Nav button colors are now fully set in the Designer (FlatStyle.Flat + sidebar blue).
        // Only override the HopeButton pill here.
        btnNewOrder.PrimaryColor = Color.FromArgb(102, 163, 191);
        btnNewOrder.TextColor = Color.White;
        btnNewOrder.HoverTextColor = Color.White;

        // Add a coloured left-accent strip and subtle border to each stat card for visual polish
        ApplyCardAccent(pnlStatPending,  Color.FromArgb(102, 163, 191));
        ApplyCardAccent(pnlStatTotal,    Color.FromArgb(51, 104, 160));
        ApplyCardAccent(pnlStatClaimed,  Color.FromArgb(40, 167, 69));
        ApplyCardAccent(pnlStatSales,    Color.FromArgb(0, 150, 136));
    }

    private static void ApplyCardAccent(Panel card, Color accentColor)
    {
        card.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.FromArgb(215, 228, 238), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            using var brush = new SolidBrush(accentColor);
            e.Graphics.FillRectangle(brush, 0, 0, 5, card.Height);
        };
        card.Padding = new Padding(14, 8, 8, 8);
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
            Service = o.ServiceName,
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
            "Washing"          => Color.FromArgb(51, 104, 160),
            "Drying"           => Color.FromArgb(102, 163, 191),
            "Ready for Pickup" => Color.FromArgb(40, 167, 69),
            "Claimed"          => Color.FromArgb(108, 117, 125),
            "Cancelled"        => Color.FromArgb(220, 53, 69),
            _                  => Color.FromArgb(51, 104, 160)
        };
    }
}
