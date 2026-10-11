using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmExportReport : Form
{
    private DailyReport? _currentReport;

    public FrmExportReport()
    {
        InitializeForm();
        LoadReportForDate(DateTime.Today);
    }

    private DateTimePicker dtpDate = null!;
    private Button btnLoad = null!;
    private Button btnExportExcel = null!;
    private Label lblTotalOrders = null!;
    private Label lblPending = null!;
    private Label lblClaimed = null!;
    private Label lblSales = null!;
    private DataGridView dgvPreview = null!;

    private void InitializeForm()
    {
        this.Text = "LaundryHub – Daily Reports & Excel Export";
        this.Size = new Size(950, 640);
        this.StartPosition = FormStartPosition.CenterParent;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Header
        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24, 0, 24, 0)
        };
        var lblTitle = new Label
        {
            Text = "📊 Daily Laundry Business Report",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            AutoSize = false,
            Dock = DockStyle.Left,
            Width = 450,
            TextAlign = ContentAlignment.MiddleLeft
        };
        var btnClose = new Button
        {
            Text = "✕ Close",
            Size = new Size(90, 34),
            Dock = DockStyle.Right,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            Cursor = Cursors.Hand
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Click += (_, _) => this.Close();
        header.Controls.AddRange(new Control[] { lblTitle, btnClose });
        this.Controls.Add(header);

        // Body
        var container = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(24)
        };
        this.Controls.Add(container);

        // Top Filter Bar
        var filterBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(16, 8, 16, 8)
        };

        var lblSelectDate = new Label
        {
            Text = "Report Date:",
            ForeColor = Color.FromArgb(148, 163, 184),
            Dock = DockStyle.Left,
            Width = 90,
            TextAlign = ContentAlignment.MiddleLeft
        };

        dtpDate = new DateTimePicker
        {
            Format = DateTimePickerFormat.Short,
            Value = DateTime.Today,
            Width = 140,
            Dock = DockStyle.Left,
            Font = new Font("Segoe UI", 10)
        };

        btnLoad = new Button
        {
            Text = "🔄 Refresh Date",
            Size = new Size(130, 34),
            Dock = DockStyle.Left,
            Margin = new Padding(12, 0, 0, 0),
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnLoad.FlatAppearance.BorderSize = 0;
        btnLoad.Click += (_, _) => LoadReportForDate(dtpDate.Value);

        btnExportExcel = new Button
        {
            Text = "📥 Export to Excel (.xlsx)",
            Size = new Size(200, 34),
            Dock = DockStyle.Right,
            BackColor = Color.FromArgb(16, 185, 129),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnExportExcel.FlatAppearance.BorderSize = 0;
        btnExportExcel.Click += btnExportExcel_Click;

        filterBar.Controls.AddRange(new Control[] { lblSelectDate, dtpDate, btnLoad, btnExportExcel });
        container.Controls.Add(filterBar);

        // Stat Summary Cards
        var statsPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 95,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(0, 10, 0, 5)
        };

        statsPanel.Controls.Add(CreateStatCard("Total Orders", "#3b82f6", out lblTotalOrders));
        statsPanel.Controls.Add(CreateStatCard("Pending / In-Process", "#f59e0b", out lblPending));
        statsPanel.Controls.Add(CreateStatCard("Claimed Orders", "#10b981", out lblClaimed));
        statsPanel.Controls.Add(CreateStatCard("Day's Total Sales", "#8b5cf6", out lblSales));

        container.Controls.Add(statsPanel);

        // Preview Table
        var gridLabel = new Label
        {
            Text = "Report Orders Breakdown Preview",
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Top,
            Height = 32,
            TextAlign = ContentAlignment.BottomLeft
        };
        container.Controls.Add(gridLabel);

        dgvPreview = new DataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = Color.FromArgb(30, 41, 59),
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Font = new Font("Segoe UI", 9.5f),
            GridColor = Color.FromArgb(51, 65, 85),
            RowTemplate = { Height = 36 },
            DefaultCellStyle =
            {
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(37, 99, 235),
                SelectionForeColor = Color.White
            },
            ColumnHeadersDefaultCellStyle =
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.FromArgb(148, 163, 184),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(6)
            },
            EnableHeadersVisualStyles = false
        };

        var gridWrap = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 6, 0, 0)
        };
        gridWrap.Controls.Add(dgvPreview);
        container.Controls.Add(gridWrap);
    }

    private static Panel CreateStatCard(string title, string hexColor, out Label valueLabel)
    {
        var panel = new Panel
        {
            Size = new Size(215, 80),
            BackColor = Color.FromArgb(30, 41, 59),
            Margin = new Padding(0, 0, 12, 0),
            Padding = new Padding(14, 10, 14, 10)
        };

        var strip = new Panel
        {
            Dock = DockStyle.Left,
            Width = 4,
            BackColor = ColorTranslator.FromHtml(hexColor)
        };

        var lblTitle = new Label
        {
            Text = title,
            ForeColor = Color.FromArgb(148, 163, 184),
            Font = new Font("Segoe UI", 8.5f),
            Dock = DockStyle.Top,
            Height = 18
        };

        valueLabel = new Label
        {
            Text = "0",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            Dock = DockStyle.Fill
        };

        panel.Controls.Add(valueLabel);
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(strip);
        return panel;
    }

    private void LoadReportForDate(DateTime date)
    {
        _currentReport = AppServices.Orders.GetDailyReport(date);

        lblTotalOrders.Text = _currentReport.TotalOrders.ToString();
        lblPending.Text = _currentReport.PendingOrders.ToString();
        lblClaimed.Text = _currentReport.ClaimedOrders.ToString();
        lblSales.Text = $"₱{_currentReport.TotalSales:N2}";

        dgvPreview.DataSource = _currentReport.Orders.Select(o => new
        {
            Order_No = o.OrderNumber,
            Customer = o.CustomerName,
            Phone = o.CustomerPhone,
            Service = o.ServiceName,
            Weight = $"{o.WeightKg} kg",
            Total = $"₱{o.TotalAmount:N2}",
            o.Status,
            Payment = o.PaymentRecorded ? "Paid" : "Unpaid",
            Date = o.CreatedAt.ToString("MM/dd/yyyy hh:mm tt")
        }).ToList();
    }

    private void btnExportExcel_Click(object? sender, EventArgs e)
    {
        if (_currentReport == null) return;

        var path = ExcelHelper.ExportDailyReport(_currentReport, this);
        if (!string.IsNullOrEmpty(path))
        {
            MessageBox.Show($"Report successfully exported to:\n{path}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
