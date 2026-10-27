using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using LaundryHub.Core.Enums;
using Customer = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmOrderList : Form
{
    private readonly System.Windows.Forms.Timer _searchTimer = new() { Interval = 300 };

    public FrmOrderList()
    {
        InitializeComponent();
        UIThemeHelper.StyleStandardForm(this);
        DoubleBuffered = true;
        pnlTopBar.BackColor = UIThemeHelper.Navy;
        lblTitle.BackColor = UIThemeHelper.Navy;

        UIThemeHelper.StyleDataGridView(dgvOrders, 34);
        UIThemeHelper.EnableStatusPills(dgvOrders);
        dtpFilter.Value = DateTime.Today;
        InitSearch();
        LoadOrders();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void InitSearch()
    {
        _searchTimer.Tick += (_, _) =>
        {
            _searchTimer.Stop();
            LoadOrders(txtSearch.Text.Trim());
        };
        FormClosed += (_, _) => _searchTimer.Dispose();

        var menu = new ContextMenuStrip();
        menu.Items.Add("Manage order...", null, (_, _) => OpenOrderDetail());
        menu.Items.Add("Refresh", null, (_, _) => RefreshCurrentView());
        dgvOrders.ContextMenuStrip = menu;
        dgvOrders.CellMouseDown += (_, e) =>
        {
            // Right-click selects the row under the cursor so the menu acts on it.
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvOrders.ClearSelection();
                dgvOrders.Rows[e.RowIndex].Selected = true;
            }
        };
    }

    private void LoadOrders(string searchTerm = "")
    {
        var orders = string.IsNullOrWhiteSpace(searchTerm)
            ? AppServices.Orders.GetAll().ToList()
            : AppServices.Orders.Search(searchTerm).ToList();
        BindOrders(orders);
    }

    private void BindOrders(List<Order> orders)
    {
        int? selectedId = null;
        if (dgvOrders.SelectedRows.Count > 0 && dgvOrders.SelectedRows[0].Cells["OrderId"].Value is int id)
            selectedId = id;

        dgvOrders.SuspendLayout();
        try
        {
            dgvOrders.DataSource = orders.Select(o => new
            {
                o.OrderId,
                Order_No = o.OrderNumber,
                Customer = o.CustomerName,
                Service = $"{o.ServiceName} — {o.LaundryCategory}",
                Weight = $"{o.WeightKg} kg",
                Total = $"{o.TotalAmount:N2}",
                o.Status,
                Pickup = o.PickupDate?.ToString("MM/dd/yyyy") ?? "",
                Date = o.CreatedAt.ToString("MM/dd hh:mm tt")
            }).ToList();

            if (dgvOrders.Columns["OrderId"] is { } col)
                col.Visible = false;

            dgvOrders.ClearSelection();
            foreach (DataGridViewRow r in dgvOrders.Rows)
            {
                if (selectedId.HasValue && r.Cells["OrderId"].Value is int rid && rid == selectedId)
                {
                    r.Selected = true;
                    dgvOrders.CurrentCell = r.Cells[1];
                    break;
                }
            }
            if (dgvOrders.SelectedRows.Count == 0 && dgvOrders.Rows.Count > 0)
                dgvOrders.Rows[0].Selected = true;
        }
        finally { dgvOrders.ResumeLayout(); }
    }

    private void dgvOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        OpenOrderDetail();
    }

    private void btnViewDetail_Click(object? sender, EventArgs e) => OpenOrderDetail();

    private void OpenOrderDetail()
    {
        if (dgvOrders.SelectedRows.Count == 0)
        {
            MessageBox.Show("Select an order first, then click Manage Order.", "Manage Order",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        var row = dgvOrders.SelectedRows[0];
        if (row.Cells["OrderId"].Value is not int orderId) return;
        var order = AppServices.Orders.GetById(orderId);
        if (order == null) return;

        var f = new FrmOrderDetail(order);
        f.ShowDialog(this);
        RefreshCurrentView();
    }

    private void RefreshCurrentView()
    {
        if (chkFilterDate.Checked) ApplyFilter();
        else LoadOrders(txtSearch.Text.Trim());
    }

    private void chkFilterDate_CheckedChanged(object? sender, EventArgs e)
    {
        dtpFilter.Visible = chkFilterDate.Checked;
        ApplyFilter();
    }

    private void dtpFilter_ValueChanged(object? sender, EventArgs e)
    {
        if (chkFilterDate.Checked) ApplyFilter();
    }

    private void ApplyFilter()
    {
        if (chkFilterDate.Checked)
            BindOrders(AppServices.Orders.GetByDate(dtpFilter.Value).ToList());
        else
            LoadOrders(txtSearch.Text.Trim());
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        // Typing a search overrides the date filter; unchecking reloads once by itself.
        if (chkFilterDate.Checked)
        {
            _searchTimer.Stop();
            chkFilterDate.Checked = false;
            return;
        }
        // Debounce: wait until typing pauses instead of querying on every keystroke.
        _searchTimer.Stop();
        _searchTimer.Start();
    }

    private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvOrders.Columns[e.ColumnIndex].Name != "Status") return;
        e.CellStyle.ForeColor = e.Value?.ToString() switch
        {
            "Booked"           => UIThemeHelper.Slate,
            "Washing"          => UIThemeHelper.Indigo,
            "Drying"           => UIThemeHelper.Slate,
            "Ready for Pickup" => UIThemeHelper.Success,
            "Claimed"          => UIThemeHelper.Neutral,
            "Cancelled"        => UIThemeHelper.Danger,
            _                  => UIThemeHelper.Indigo
        };
        e.CellStyle.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
    }
}
