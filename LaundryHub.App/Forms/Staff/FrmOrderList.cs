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

        UIThemeHelper.StyleDataGridView(dgvOrders, 40);
        UIThemeHelper.EnableStatusPills(dgvOrders);
        dtpFilter.Value = DateTime.Today;
        InitSearch();
        InitCancelRequestIcon();
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
        menu.Items.Add("Cancel order...", null, (_, _) => CancelSelectedOrder());
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

    private bool IsPendingCancelCell(int rowIndex, int columnIndex) =>
        rowIndex >= 0 && columnIndex >= 0
        && dgvOrders.Columns[columnIndex].Name == "Cancel"
        && (dgvOrders.Rows[rowIndex].Cells[columnIndex].Value as string) == "Pending";

    private void InitCancelRequestIcon()
    {
        var tip = new ToolTip();
        FormClosed += (_, _) => tip.Dispose();

        dgvOrders.CellPainting += (_, e) =>
        {
            if (e.Graphics == null || !IsPendingCancelCell(e.RowIndex, e.ColumnIndex)) return;

            e.Handled = true;
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

            // Selected rows use a light tint in this grid, so the icon stays red on every row.
            var icon = new Rectangle(
                e.CellBounds.X + (e.CellBounds.Width - 22) / 2,
                e.CellBounds.Y + (e.CellBounds.Height - 22) / 2, 22, 22);
            CancelRequestIcon.Draw(e.Graphics, icon, UIThemeHelper.Danger);
        };

        dgvOrders.CellMouseEnter += (_, e) =>
        {
            if (IsPendingCancelCell(e.RowIndex, e.ColumnIndex))
            {
                dgvOrders.Cursor = Cursors.Hand;
                var bounds = dgvOrders.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                tip.Show("Cancellation request — click to review", dgvOrders, bounds.Left, bounds.Bottom, 2500);
            }
        };
        dgvOrders.CellMouseLeave += (_, _) =>
        {
            dgvOrders.Cursor = Cursors.Default;
            tip.Hide(dgvOrders);
        };

        dgvOrders.CellClick += (_, e) =>
        {
            if (!IsPendingCancelCell(e.RowIndex, e.ColumnIndex)) return;
            if (dgvOrders.Rows[e.RowIndex].Cells["OrderId"].Value is not int orderId) return;
            OpenCancelRequest(orderId);
        };
    }

    private void OpenCancelRequest(int orderId)
    {
        var order = AppServices.Orders.GetById(orderId);
        if (order == null) return;

        // Someone else may have handled it since the list loaded.
        if (order.CancelRequestStatus != "Pending")
        {
            MessageBox.Show(this, "This cancellation request has already been handled.", "Cancellation Request",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshCurrentView();
            return;
        }

        using var dlg = new FrmCancelRequest(order);
        dlg.ShowDialog(this);
        RefreshCurrentView();
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
                Date = o.CreatedAt.ToString("MM/dd hh:mm tt"),
                Cancel = o.CancelRequestStatus == "Pending" ? "Pending" : ""
            }).ToList();

            if (dgvOrders.Columns["OrderId"] is { } col)
                col.Visible = false;

            // Far-right column that shows the calendar-X icon only when a cancel request is pending.
            if (dgvOrders.Columns["Cancel"] is { } cancelCol)
            {
                cancelCol.HeaderText = "Cancel";
                cancelCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                cancelCol.Width = 80;
                cancelCol.MinimumWidth = 80;
                cancelCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                cancelCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cancelCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            void SetWeight(string name, float weight)
            {
                if (dgvOrders.Columns[name] is { } c) c.FillWeight = weight;
            }
            if (dgvOrders.Columns["Order_No"] is { } cOrder) cOrder.HeaderText = "Order No";
            if (dgvOrders.Columns["Pickup"] is { } cPick) cPick.HeaderText = "Target Pickup";
            if (dgvOrders.Columns["Date"] is { } cDate) cDate.HeaderText = "Date Placed";

            SetWeight("Order_No", 140);
            SetWeight("Customer", 150);
            SetWeight("Service", 160);
            SetWeight("Weight", 80);
            SetWeight("Total", 85);
            SetWeight("Status", 125);
            SetWeight("Pickup", 100);
            SetWeight("Date", 115);

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
        if (IsPendingCancelCell(e.RowIndex, e.ColumnIndex)) return;
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

    private void CancelSelectedOrder()
    {
        if (dgvOrders.SelectedRows.Count == 0 ||
            dgvOrders.SelectedRows[0].Cells["OrderId"].Value is not int orderId)
        {
            MessageBox.Show("Select an order first.", "Cancel Order",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var order = AppServices.Orders.GetById(orderId);
        if (order == null) return;

        if (OrderCancelHelper.Prompt(this, order.OrderId, order.OrderNumber, order.Status))
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
            "Booked" => UIThemeHelper.Slate,
            "Washing" => UIThemeHelper.Indigo,
            "Drying" => UIThemeHelper.Slate,
            "Ready for Pickup" => UIThemeHelper.Success,
            "Claimed" => UIThemeHelper.Neutral,
            "Cancelled" => UIThemeHelper.Danger,
            _ => UIThemeHelper.Indigo
        };
        e.CellStyle.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
    }
}