using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using LaundryHub.Core.Enums;
using Customer = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmOrderList : Form
{
    public FrmOrderList()
    {
        BuildUI();
        LoadOrders();
    }

    // ─── Data ─────────────────────────────────────────────────────────────────

    private void LoadOrders(string searchTerm = "")
    {
        var orders = string.IsNullOrWhiteSpace(searchTerm)
            ? AppServices.Orders.GetAll().ToList()
            : AppServices.Orders.Search(searchTerm).ToList();

        dgvOrders.DataSource = orders.Select(o => new
        {
            o.OrderId,
            Order_No  = o.OrderNumber,
            Customer  = o.CustomerName,
            Service   = o.ServiceName,
            Weight    = $"{o.WeightKg} kg",
            Total     = $"₱{o.TotalAmount:N2}",
            o.Status,
            Pickup    = o.PickupDate?.ToString("MM/dd/yyyy") ?? "—",
            Date      = o.CreatedAt.ToString("MM/dd hh:mm tt")
        }).ToList();

        // Hide the raw OrderId column
        if (dgvOrders.Columns["OrderId"] is { } col)
            col.Visible = false;
    }

    // ─── Double-click to view/update status ───────────────────────────────────

    private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        OpenOrderDetail();
    }

    private void btnViewDetail_Click(object sender, EventArgs e) => OpenOrderDetail();

    private void OpenOrderDetail()
    {
        if (dgvOrders.SelectedRows.Count == 0) return;
        var row     = dgvOrders.SelectedRows[0];
        var orderId = (int)row.Cells["OrderId"].Value;
        var order   = AppServices.Orders.GetById(orderId);
        if (order == null) return;

        var f = new FrmOrderDetail(order);
        f.ShowDialog(this);
        LoadOrders(txtSearch.Text.Trim());
    }

    // ─── Filter by date ───────────────────────────────────────────────────────

    private void chkFilterDate_CheckedChanged(object sender, EventArgs e)
    {
        dtpFilter.Visible = chkFilterDate.Checked;
        ApplyFilter();
    }

    private void dtpFilter_ValueChanged(object sender, EventArgs e) => ApplyFilter();

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
                Service  = o.ServiceName,
                Weight   = $"{o.WeightKg} kg",
                Total    = $"₱{o.TotalAmount:N2}",
                o.Status,
                Pickup   = o.PickupDate?.ToString("MM/dd/yyyy") ?? "—",
                Date     = o.CreatedAt.ToString("MM/dd hh:mm tt")
            }).ToList();
            if (dgvOrders.Columns["OrderId"] is { } col) col.Visible = false;
        }
        else
        {
            LoadOrders(txtSearch.Text.Trim());
        }
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        chkFilterDate.Checked = false;
        LoadOrders(txtSearch.Text.Trim());
    }

    // ─── UI Build ─────────────────────────────────────────────────────────────

    private TextBox      txtSearch     = null!;
    private DataGridView dgvOrders     = null!;
    private CheckBox     chkFilterDate = null!;
    private DateTimePicker dtpFilter   = null!;

    private void BuildUI()
    {
        this.Text            = "Order List";
        this.Size            = new Size(1050, 640);
        this.StartPosition   = FormStartPosition.CenterParent;
        this.BackColor       = Color.FromArgb(15, 23, 42);
        this.MinimumSize     = new Size(800, 500);

        // ── Top bar ───────────────────────────────────────────
        var topBar = new Panel
        {
            Dock      = DockStyle.Top,
            Height    = 60,
            Padding   = new Padding(16, 10, 16, 0),
            BackColor = Color.FromArgb(30, 41, 59)
        };

        var lblTitle = new Label
        {
            Text      = "📋  All Orders",
            Font      = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.White,
            Dock      = DockStyle.Left,
            Width     = 200,
            TextAlign = ContentAlignment.MiddleLeft
        };

        txtSearch = new TextBox
        {
            PlaceholderText = "🔍  Search by order # or customer name...",
            Font            = new Font("Segoe UI", 10),
            BackColor       = Color.FromArgb(15, 23, 42),
            ForeColor       = Color.White,
            BorderStyle     = BorderStyle.FixedSingle,
            Dock            = DockStyle.Fill,
            Margin          = new Padding(8, 0, 0, 0)
        };
        txtSearch.TextChanged += txtSearch_TextChanged;

        chkFilterDate = new CheckBox
        {
            Text      = "Filter by date:",
            ForeColor = Color.FromArgb(148, 163, 184),
            Font      = new Font("Segoe UI", 8.5f),
            Dock      = DockStyle.Right,
            Width     = 120,
            TextAlign = ContentAlignment.MiddleRight
        };
        chkFilterDate.CheckedChanged += chkFilterDate_CheckedChanged;

        dtpFilter = new DateTimePicker
        {
            Format   = DateTimePickerFormat.Short,
            Value    = DateTime.Today,
            Dock     = DockStyle.Right,
            Width    = 110,
            Font     = new Font("Segoe UI", 9),
            Visible  = false
        };
        dtpFilter.ValueChanged += dtpFilter_ValueChanged;

        var btnDetail = new Button
        {
            Text      = "View Detail",
            Dock      = DockStyle.Right,
            Width     = 100,
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font      = new Font("Segoe UI", 9),
            Cursor    = Cursors.Hand,
            Margin    = new Padding(4, 0, 0, 0)
        };
        btnDetail.FlatAppearance.BorderSize = 0;
        btnDetail.Click += btnViewDetail_Click;

        topBar.Controls.AddRange(new Control[] { lblTitle, txtSearch, chkFilterDate, dtpFilter, btnDetail });

        // ── Legend ─────────────────────────────────────────────
        var legend = new Panel
        {
            Dock      = DockStyle.Top,
            Height    = 28,
            BackColor = Color.FromArgb(15, 23, 42),
            Padding   = new Padding(16, 4, 0, 0)
        };

        string[] statuses = { "Washing", "Drying", "Ready for Pickup", "Claimed", "Cancelled" };
        Color[]  colors   = {
            Color.FromArgb(251,191,36), Color.FromArgb(96,165,250),
            Color.FromArgb(52,211,153), Color.FromArgb(134,239,172),
            Color.FromArgb(248,113,113)
        };

        int lx = 16;
        for (int i = 0; i < statuses.Length; i++)
        {
            var dot = new Label { Text = "●", ForeColor = colors[i], Location = new Point(lx, 4), AutoSize = true, Font = new Font("Segoe UI", 9) };
            var lbl = new Label { Text = statuses[i], ForeColor = Color.FromArgb(148,163,184), Location = new Point(lx + 18, 4), AutoSize = true, Font = new Font("Segoe UI", 8.5f) };
            legend.Controls.AddRange(new Control[] { dot, lbl });
            lx += 120;
        }

        // ── Grid ──────────────────────────────────────────────
        dgvOrders = new DataGridView
        {
            Dock                  = DockStyle.Fill,
            BackgroundColor       = Color.FromArgb(30, 41, 59),
            BorderStyle           = BorderStyle.None,
            RowHeadersVisible     = false,
            AllowUserToAddRows    = false,
            AllowUserToDeleteRows = false,
            ReadOnly              = true,
            SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill,
            Font                  = new Font("Segoe UI", 9),
            GridColor             = Color.FromArgb(51, 65, 85),
            DefaultCellStyle =
            {
                BackColor          = Color.FromArgb(30, 41, 59),
                ForeColor          = Color.White,
                SelectionBackColor = Color.FromArgb(37, 99, 235),
                SelectionForeColor = Color.White,
                Padding            = new Padding(4)
            },
            ColumnHeadersDefaultCellStyle =
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.FromArgb(96, 165, 250),
                Font      = new Font("Segoe UI Semibold", 9, FontStyle.Bold)
            },
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            ColumnHeadersHeight         = 34,
            RowTemplate                 = { Height = 30 }
        };
        dgvOrders.CellFormatting     += DgvOrders_CellFormatting;
        dgvOrders.CellDoubleClick    += dgvOrders_CellDoubleClick;

        this.Controls.AddRange(new Control[] { dgvOrders, legend, topBar });
    }

    private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvOrders.Columns[e.ColumnIndex].Name != "Status") return;
        e.CellStyle.ForeColor = e.Value?.ToString() switch
        {
            "Washing"          => Color.FromArgb(251, 191, 36),
            "Drying"           => Color.FromArgb(96, 165, 250),
            "Ready for Pickup" => Color.FromArgb(52, 211, 153),
            "Claimed"          => Color.FromArgb(134, 239, 172),
            "Cancelled"        => Color.FromArgb(248, 113, 113),
            _                  => Color.White
        };
        e.CellStyle.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
    }
}
