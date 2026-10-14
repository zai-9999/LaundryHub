using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using LaundryHub.Core.Enums;
using Customer = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmOrderList : Form
{
    public FrmOrderList()
    {
        InitializeComponent();
        UIThemeHelper.StyleStandardForm(this);
        DoubleBuffered = true;
        pnlTopBar.BackColor = Color.FromArgb(37, 78, 122);
        lblTitle.BackColor = Color.FromArgb(37, 78, 122);

        UIThemeHelper.StyleDataGridView(dgvOrders, 34);
        dtpFilter.Value = DateTime.Today;
        LoadOrders();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void LoadOrders(string searchTerm = "")
    {
        var orders = string.IsNullOrWhiteSpace(searchTerm)
            ? AppServices.Orders.GetAll().ToList()
            : AppServices.Orders.Search(searchTerm).ToList();

        dgvOrders.DataSource = orders.Select(o => new
        {
            o.OrderId,
            Order_No = o.OrderNumber,
            Customer = o.CustomerName,
            Service = o.ServiceName,
            Weight = $"{o.WeightKg} kg",
            Total = $"₱{o.TotalAmount:N2}",
            o.Status,
            Pickup = o.PickupDate?.ToString("MM/dd/yyyy") ?? "—",
            Date = o.CreatedAt.ToString("MM/dd hh:mm tt")
        }).ToList();

        if (dgvOrders.Columns["OrderId"] is { } col)
            col.Visible = false;
    }

    private void dgvOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        OpenOrderDetail();
    }

    private void btnViewDetail_Click(object? sender, EventArgs e) => OpenOrderDetail();

    private void OpenOrderDetail()
    {
        if (dgvOrders.SelectedRows.Count == 0) return;
        var row = dgvOrders.SelectedRows[0];
        if (row.Cells["OrderId"].Value is not int orderId) return;
        var order = AppServices.Orders.GetById(orderId);
        if (order == null) return;

        var f = new FrmOrderDetail(order);
        f.ShowDialog(this);
        LoadOrders(txtSearch.Text.Trim());
    }

    private void chkFilterDate_CheckedChanged(object? sender, EventArgs e)
    {
        dtpFilter.Visible = chkFilterDate.Checked;
        ApplyFilter();
    }

    private void dtpFilter_ValueChanged(object? sender, EventArgs e) => ApplyFilter();

    private void ApplyFilter()
    {
        if (chkFilterDate.Checked)
        {
            var orders = AppServices.Orders.GetByDate(dtpFilter.Value).ToList();
            dgvOrders.DataSource = orders.Select(o => new
            {
                o.OrderId,
                Order_No = o.OrderNumber,
                Customer = o.CustomerName,
                Service = o.ServiceName,
                Weight = $"{o.WeightKg} kg",
                Total = $"₱{o.TotalAmount:N2}",
                o.Status,
                Pickup = o.PickupDate?.ToString("MM/dd/yyyy") ?? "—",
                Date = o.CreatedAt.ToString("MM/dd hh:mm tt")
            }).ToList();
            if (dgvOrders.Columns["OrderId"] is { } col) col.Visible = false;
        }
        else
        {
            LoadOrders(txtSearch.Text.Trim());
        }
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        chkFilterDate.Checked = false;
        LoadOrders(txtSearch.Text.Trim());
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
        e.CellStyle.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
    }
}
