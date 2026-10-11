using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmExportReport : Form
{
    private DailyReport? _currentReport;

    public FrmExportReport()
    {
        InitializeComponent();
        dtpDate.Value = DateTime.Today;
        LoadReportForDate(DateTime.Today);
    }

    private void btnClose_Click(object? sender, EventArgs e) => this.Close();

    private void btnLoad_Click(object? sender, EventArgs e) => LoadReportForDate(dtpDate.Value);

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
