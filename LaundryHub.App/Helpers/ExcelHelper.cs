using System.Drawing;
using LaundryHub.Core.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace LaundryHub.App.Helpers;

public static class ExcelHelper
{
    static ExcelHelper()
    {
        // Set EPPlus 8+ non-commercial license
        ExcelPackage.License.SetNonCommercialOrganization(AppServices.ShopName);
    }

    /// <summary>
    /// Exports a DailyReport to an Excel file using EPPlus.
    /// Returns the saved file path, or null if the user cancelled the dialog.
    /// </summary>
    public static string? ExportDailyReport(DailyReport report, IWin32Window owner)
    {
        using var dlg = new SaveFileDialog
        {
            Title      = "Save Daily Report to Excel",
            FileName   = $"LaundryHub_Report_{report.ReportDate:yyyy-MM-dd}.xlsx",
            Filter     = "Excel Workbook (*.xlsx)|*.xlsx",
            DefaultExt = "xlsx"
        };

        if (dlg.ShowDialog(owner) != DialogResult.OK) return null;

        ExportDailyReportToFile(report, dlg.FileName);
        return dlg.FileName;
    }

    /// <summary>
    /// Exports a DailyReport to the specified file path using EPPlus.
    /// </summary>
    public static void ExportDailyReportToFile(DailyReport report, string filePath)
    {
        using var package = new ExcelPackage();
        var ws = package.Workbook.Worksheets.Add("Daily Report");

        // Base styling
        ws.Cells.Style.Font.Name = "Segoe UI";
        ws.Cells.Style.Font.Size = 10;

        // ── Header ──────────────────────────────────────────────
        ws.Cells[1, 1].Value = AppServices.ShopName;
        ws.Cells[1, 1, 1, 8].Merge = true;
        ws.Cells[1, 1].Style.Font.Bold = true;
        ws.Cells[1, 1].Style.Font.Size = 16;
        ws.Cells[1, 1].Style.Font.Color.SetColor(Color.FromArgb(17, 24, 68)); // #111844
        ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        ws.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        ws.Row(1).Height = 30;

        ws.Cells[2, 1].Value = $"Daily Report – {report.ReportDate:MMMM dd, yyyy}";
        ws.Cells[2, 1, 2, 8].Merge = true;
        ws.Cells[2, 1].Style.Font.Italic = true;
        ws.Cells[2, 1].Style.Font.Size = 11;
        ws.Cells[2, 1].Style.Font.Color.SetColor(Color.FromArgb(100, 116, 139));
        ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        ws.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        ws.Row(2).Height = 22;

        // ── Summary KPI Section ──────────────────────────────────
        int row = 4;
        WriteSummaryRow(ws, ref row, "Total Orders", report.TotalOrders);
        WriteSummaryRow(ws, ref row, "Pending Orders", report.PendingOrders);
        WriteSummaryRow(ws, ref row, "Claimed Orders", report.ClaimedOrders);
        WriteSummaryRow(ws, ref row, "Cancelled Orders", report.CancelledOrders);
        WriteSummaryRow(ws, ref row, "Total Sales", report.TotalSales, isCurrency: true);
        row++;

        // ── Table Header ─────────────────────────────────────────
        var headers = new[] { "Order #", "Customer", "Phone", "Service", "Weight (kg)", "Total (₱)", "Status", "Date / Time" };
        for (int c = 0; c < headers.Length; c++)
        {
            var cell = ws.Cells[row, c + 1];
            cell.Value = headers[c];
            cell.Style.Font.Bold = true;
            cell.Style.Font.Size = 10;
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(17, 24, 68)); // #111844
            cell.Style.Font.Color.SetColor(Color.White);
            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }
        ws.Row(row).Height = 26;
        row++;

        // ── Table Rows ───────────────────────────────────────────
        int startRow = row;
        if (report.Orders.Count == 0)
        {
            ws.Cells[row, 1].Value = "No orders recorded for this date.";
            ws.Cells[row, 1, row, 8].Merge = true;
            ws.Cells[row, 1].Style.Font.Italic = true;
            ws.Cells[row, 1].Style.Font.Color.SetColor(Color.Gray);
            ws.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            row++;
        }
        else
        {
            foreach (var o in report.Orders)
            {
                ws.Cells[row, 1].Value = o.OrderNumber ?? "";
                ws.Cells[row, 2].Value = o.CustomerName ?? "";
                ws.Cells[row, 3].Value = o.CustomerPhone ?? "";
                ws.Cells[row, 4].Value = o.ServiceName ?? "";

                var cellWeight = ws.Cells[row, 5];
                cellWeight.Value = (double)o.WeightKg;
                cellWeight.Style.Numberformat.Format = "#,##0.00";
                cellWeight.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                var cellTotal = ws.Cells[row, 6];
                cellTotal.Value = (double)o.TotalAmount;
                cellTotal.Style.Numberformat.Format = "\"₱\"#,##0.00";
                cellTotal.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                var cellStatus = ws.Cells[row, 7];
                cellStatus.Value = o.Status ?? "";
                cellStatus.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var cellTime = ws.Cells[row, 8];
                cellTime.Value = o.CreatedAt.ToString("MM/dd/yyyy hh:mm tt");
                cellTime.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Subtle alternating row color
                if ((row - startRow) % 2 == 1)
                {
                    using var rng = ws.Cells[row, 1, row, 8];
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(246, 242, 234));
                }

                // Light border bottom
                using var rowRng = ws.Cells[row, 1, row, 8];
                rowRng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rowRng.Style.Border.Bottom.Color.SetColor(Color.FromArgb(226, 232, 240));

                row++;
            }
        }

        ws.Cells[1, 1, row, 8].AutoFitColumns();

        // Ensure minimum column widths
        for (int col = 1; col <= 8; col++)
        {
            if (ws.Column(col).Width < 14)
                ws.Column(col).Width = 14;
        }

        var fileInfo = new FileInfo(filePath);
        package.SaveAs(fileInfo);
    }

    private static void WriteSummaryRow(ExcelWorksheet ws, ref int row, string label, object value, bool isCurrency = false)
    {
        ws.Cells[row, 1].Value = label;
        ws.Cells[row, 1].Style.Font.Bold = true;
        ws.Cells[row, 1].Style.Font.Color.SetColor(Color.FromArgb(51, 65, 85));

        var valCell = ws.Cells[row, 2];
        if (isCurrency && value is decimal d)
        {
            valCell.Value = (double)d;
            valCell.Style.Numberformat.Format = "\"₱\"#,##0.00";
            valCell.Style.Font.Bold = true;
            valCell.Style.Font.Color.SetColor(Color.FromArgb(17, 24, 68));
        }
        else
        {
            valCell.Value = value;
        }
        row++;
    }
}
