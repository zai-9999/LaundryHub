using LaundryHub.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace LaundryHub.App.Helpers;

public static class PdfReportHelper
{
    static PdfReportHelper()
    {
        // Set QuestPDF community license
        QuestPDF.Settings.License = LicenseType.Community;
    }

    /// <summary>
    /// Exports a DailyReport to a beautifully formatted PDF document using QuestPDF.
    /// Returns the saved file path, or null if the user cancelled the dialog.
    /// </summary>
    public static string? ExportDailyReport(DailyReport report, IWin32Window owner)
    {
        using var dlg = new SaveFileDialog
        {
            Title      = "Save Daily Report as PDF",
            FileName   = $"LaundryHub_Report_{report.ReportDate:yyyy-MM-dd}.pdf",
            Filter     = "PDF Document (*.pdf)|*.pdf",
            DefaultExt = "pdf"
        };

        if (dlg.ShowDialog(owner) != DialogResult.OK) return null;

        ExportDailyReportToFile(report, dlg.FileName);
        return dlg.FileName;
    }

    /// <summary>
    /// Exports a DailyReport to the specified file path using QuestPDF.
    /// </summary>
    public static void ExportDailyReportToFile(DailyReport report, string filePath)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(28);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Segoe UI"));

                page.Header().Element(c => ComposeHeader(c, report));
                page.Content().Element(c => ComposeContent(c, report));
                page.Footer().Element(ComposeFooter);
            });
        });

        document.GeneratePdf(filePath);
    }

    private static void ComposeHeader(IContainer container, DailyReport report)
    {
        container.PaddingBottom(16).Column(column =>
        {
            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(AppServices.ShopName)
                        .FontSize(18)
                        .Bold()
                        .FontColor("#111844");

                    col.Item().Text("DAILY OPERATIONS & SALES REPORT")
                        .FontSize(10)
                        .SemiBold()
                        .FontColor("#4B5694");
                });

                row.RelativeItem().AlignRight().Column(col =>
                {
                    col.Item().Text($"Report Date: {report.ReportDate:MMMM dd, yyyy}")
                        .FontSize(10)
                        .Bold()
                        .FontColor("#111844");

                    col.Item().Text($"Generated: {DateTime.Now:MMM dd, yyyy hh:mm tt}")
                        .FontSize(8.5f)
                        .FontColor(Colors.Grey.Medium);
                });
            });

            column.Item().PaddingTop(8).LineHorizontal(1.5f).LineColor("#111844");
        });
    }

    private static void ComposeContent(IContainer container, DailyReport report)
    {
        container.Column(column =>
        {
            // ── KPI Summary Cards ─────────────────────────────────────
            column.Item().PaddingBottom(16).Row(row =>
            {
                row.RelativeItem().Element(c => ComposeKpiCard(c, "Total Orders", report.TotalOrders.ToString(), "#1E293B"));
                row.ConstantItem(8);
                row.RelativeItem().Element(c => ComposeKpiCard(c, "Pending", report.PendingOrders.ToString(), "#D97706"));
                row.ConstantItem(8);
                row.RelativeItem().Element(c => ComposeKpiCard(c, "Claimed", report.ClaimedOrders.ToString(), "#059669"));
                row.ConstantItem(8);
                row.RelativeItem().Element(c => ComposeKpiCard(c, "Cancelled", report.CancelledOrders.ToString(), "#DC2626"));
                row.ConstantItem(8);
                row.RelativeItem(1.3f).Element(c => ComposeKpiCard(c, "Total Sales", $"₱{report.TotalSales:N2}", "#111844"));
            });

            // ── Table Title ───────────────────────────────────────────
            column.Item().PaddingBottom(6).Row(row =>
            {
                row.RelativeItem().Text("Order Activity Log").FontSize(11).Bold().FontColor("#111844");
                row.RelativeItem().AlignRight().Text($"{report.Orders.Count} total record(s)").FontSize(9).FontColor(Colors.Grey.Medium);
            });

            // ── Table of Orders ───────────────────────────────────────
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(75); // Order #
                    columns.RelativeColumn(2.6f); // Customer
                    columns.RelativeColumn(2.0f); // Phone
                    columns.RelativeColumn(2.4f); // Service
                    columns.RelativeColumn(1.6f); // Weight
                    columns.RelativeColumn(1.8f); // Total
                    columns.RelativeColumn(1.8f); // Status
                    columns.RelativeColumn(1.8f); // Time
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderCellStyle).Text("Order #");
                    header.Cell().Element(HeaderCellStyle).Text("Customer");
                    header.Cell().Element(HeaderCellStyle).Text("Phone");
                    header.Cell().Element(HeaderCellStyle).Text("Service");
                    header.Cell().Element(HeaderCellStyle).AlignRight().Text("Weight");
                    header.Cell().Element(HeaderCellStyle).AlignRight().Text("Total");
                    header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Status");
                    header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Time");

                    static IContainer HeaderCellStyle(IContainer c) =>
                        c.Background("#111844")
                         .PaddingVertical(6)
                         .PaddingHorizontal(4)
                         .DefaultTextStyle(x => x.Bold().FontColor(Colors.White).FontSize(8.5f));
                });

                if (report.Orders.Count == 0)
                {
                    table.Cell().ColumnSpan(8).PaddingVertical(24).AlignCenter()
                        .Text("No orders recorded for this date.")
                        .Italic()
                        .FontColor(Colors.Grey.Medium);
                }
                else
                {
                    for (int i = 0; i < report.Orders.Count; i++)
                    {
                        var o = report.Orders[i];
                        string bg = (i % 2 == 1) ? "#F8FAFC" : "#FFFFFF";

                        table.Cell().Element(c => CellStyle(c, bg)).Text(o.OrderNumber ?? "").Bold();
                        table.Cell().Element(c => CellStyle(c, bg)).Text(o.CustomerName ?? "");
                        table.Cell().Element(c => CellStyle(c, bg)).Text(o.CustomerPhone ?? "");
                        table.Cell().Element(c => CellStyle(c, bg)).Text(o.ServiceName ?? "");
                        table.Cell().Element(c => CellStyle(c, bg)).AlignRight().Text($"{o.WeightKg:N1} kg");
                        table.Cell().Element(c => CellStyle(c, bg)).AlignRight().Text($"₱{o.TotalAmount:N2}").Bold();

                        // Status colored badge
                        table.Cell().Element(c => CellStyle(c, bg)).AlignCenter().Text(o.Status ?? "")
                            .FontColor(GetStatusColor(o.Status))
                            .SemiBold();

                        table.Cell().Element(c => CellStyle(c, bg)).AlignCenter().Text(o.CreatedAt.ToString("hh:mm tt"));
                    }

                    static IContainer CellStyle(IContainer c, string bg) =>
                        c.Background(bg)
                         .BorderBottom(1)
                         .BorderColor("#E2E8F0")
                         .PaddingVertical(5)
                         .PaddingHorizontal(4)
                         .DefaultTextStyle(x => x.FontSize(8));
                }
            });
        });
    }

    private static void ComposeKpiCard(IContainer container, string title, string value, string accentColor)
    {
        container
            .Border(1)
            .BorderColor("#E2E8F0")
            .Background("#F8FAFC")
            .Padding(8)
            .Column(col =>
            {
                col.Item().Text(title.ToUpperInvariant())
                    .FontSize(7.5f)
                    .SemiBold()
                    .FontColor(Colors.Grey.Darken1);

                col.Item().PaddingTop(2).Text(value)
                    .FontSize(13)
                    .Bold()
                    .FontColor(accentColor);
            });
    }

    private static void ComposeFooter(IContainer container)
    {
        container.PaddingTop(12).Row(row =>
        {
            row.RelativeItem().Text("LaundryHub Management System • Official Confidential Report")
                .FontSize(8)
                .FontColor(Colors.Grey.Medium);

            row.RelativeItem().AlignRight().Text(text =>
            {
                text.DefaultTextStyle(x => x.FontSize(8).FontColor(Colors.Grey.Medium));
                text.Span("Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
        });
    }

    private static string GetStatusColor(string? status) => status?.Trim().ToLowerInvariant() switch
    {
        "claimed"   => "#059669", // green
        "cancelled" => "#DC2626", // red
        "ready"     => "#2563EB", // blue
        "washing"   => "#0284C7", // light blue
        "received"  => "#D97706", // amber
        _           => "#4B5563"  // gray
    };
}
