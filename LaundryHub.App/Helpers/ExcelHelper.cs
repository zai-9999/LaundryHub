using ClosedXML.Excel;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Helpers;

public static class ExcelHelper
{
    /// <summary>
    /// Exports a DailyReport to an Excel file.
    /// Returns the saved file path, or null if the user cancelled the dialog.
    /// </summary>
    public static string? ExportDailyReport(DailyReport report, IWin32Window owner)
    {
        using var dlg = new SaveFileDialog
        {
            Title      = "Save Daily Report",
            FileName   = $"LaundryHub_Report_{report.ReportDate:yyyy-MM-dd}.xlsx",
            Filter     = "Excel Workbook (*.xlsx)|*.xlsx",
            DefaultExt = "xlsx"
        };

        if (dlg.ShowDialog(owner) != DialogResult.OK) return null;

        using var workbook  = new XLWorkbook();
        var ws              = workbook.Worksheets.Add("Daily Report");

        //  Header 
        ws.Cell(1, 1).Value = AppServices.ShopName;
        ws.Range(1, 1, 1, 8).Merge().Style
            .Font.SetBold(true)
            .Font.SetFontSize(16)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        ws.Cell(2, 1).Value = $"Daily Report  {report.ReportDate:MMMM dd, yyyy}";
        ws.Range(2, 1, 2, 8).Merge().Style
            .Font.SetItalic(true)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //  Summary 
        int row = 4;
        WriteSummaryRow(ws, ref row, "Total Orders",     report.TotalOrders);
        WriteSummaryRow(ws, ref row, "Pending",          report.PendingOrders);
        WriteSummaryRow(ws, ref row, "Claimed",          report.ClaimedOrders);
        WriteSummaryRow(ws, ref row, "Cancelled",        report.CancelledOrders);
        WriteSummaryRow(ws, ref row, "Total Sales",      $"{report.TotalSales:N2}");
        row++;

        //  Table Header 
        var headers = new[] { "Order #", "Customer", "Phone", "Service", "Weight (kg)", "Total ()", "Status", "Date" };
        for (int c = 0; c < headers.Length; c++)
        {
            var cell = ws.Cell(row, c + 1);
            cell.Value = headers[c];
            cell.Style.Font.SetBold(true)
                      .Fill.SetBackgroundColor(XLColor.FromHtml("#111844"))
                      .Font.SetFontColor(XLColor.White);
        }
        row++;

        //  Table Rows 
        foreach (var o in report.Orders)
        {
            ws.Cell(row, 1).Value = o.OrderNumber ?? "";
            ws.Cell(row, 2).Value = o.CustomerName ?? "";
            ws.Cell(row, 3).Value = o.CustomerPhone ?? "";
            ws.Cell(row, 4).Value = $"{o.ServiceName ?? "Laundry"} — {o.LaundryCategory}";
            ws.Cell(row, 5).Value = (double)o.WeightKg;
            ws.Cell(row, 6).Value = (double)o.TotalAmount;
            ws.Cell(row, 7).Value = o.Status ?? "";
            ws.Cell(row, 8).Value = o.CreatedAt.ToString("hh:mm tt");
            if (row % 2 == 0)
                ws.Range(row, 1, row, 8).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#F6F2EA"));
            row++;
        }

        ws.Columns().AdjustToContents();
        workbook.SaveAs(dlg.FileName);
        return dlg.FileName;
    }

    private static void WriteSummaryRow(IXLWorksheet ws, ref int row, string label, object value)
    {
        ws.Cell(row, 1).Value = label;
        ws.Cell(row, 1).Style.Font.SetBold(true);
        ws.Cell(row, 2).Value = value.ToString();
        row++;
    }
}
