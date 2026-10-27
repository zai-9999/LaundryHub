using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Helpers;

/// <summary>
/// Renders a formatted invoice to any GDI+ Graphics surface.
/// Used by both InvoicePreviewPanel (on-screen) and PrintDocument (print/preview).
/// </summary>
public static class InvoiceRenderer
{
    public const float LogicalWidth  = 440f;
    public const float LogicalHeight = 480f;

    // ── Colours ────────────────────────────────────────────────────────────────
    private static readonly Color HeaderBg   = Color.FromArgb(75, 86, 148);   // Indigo
    private static readonly Color AccentLine = Color.FromArgb(114, 136, 174); // Slate
    private static readonly Color TextDark   = Color.FromArgb(30, 41, 59);
    private static readonly Color TextMuted  = Color.FromArgb(100, 116, 139);
    private static readonly Color PaidGreen  = Color.FromArgb(22, 163, 74);
    private static readonly Color UnpaidRed  = Color.FromArgb(220, 38, 38);

    // ── Fonts (created fresh each call so callers need not dispose) ───────────
    private static Font F(float size, FontStyle style = FontStyle.Regular) =>
        new("Segoe UI", Math.Max(1f, size), style);

    /// <summary>
    /// Draws the invoice inside <paramref name="bounds"/>.
    /// Pass <c>bounds.Height == 0</c> to let the renderer use as much vertical
    /// space as it needs (for the print path).
    /// </summary>
    public static void Draw(
        Graphics g,
        RectangleF bounds,
        Order order,
        CustomerModel? customer,
        string shopName,
        IEnumerable<LoadPrice>? prices)
    {
        g.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        float x = bounds.X;
        float y = bounds.Y;
        float w = bounds.Width;
        float s = (w > 0 && LogicalWidth > 0) ? (w / LogicalWidth) : 1f;

        // ── Header band ───────────────────────────────────────────────────────
        float headerH = 52f * s;
        using (var headerBrush = new SolidBrush(HeaderBg))
            g.FillRectangle(headerBrush, x, y, w, headerH);

        using (var fShop = F(12f * s, FontStyle.Bold))
        using (var shopBrush = new SolidBrush(Color.White))
        {
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(shopName, fShop, shopBrush, new RectangleF(x, y, w, headerH), sf);
        }
        y += headerH + 8f * s;

        // ── Invoice label + number ─────────────────────────────────────────────
        using (var fLabel = F(8f * s))
        using (var fNum   = F(11f * s, FontStyle.Bold))
        using (var mutedB = new SolidBrush(TextMuted))
        using (var darkB  = new SolidBrush(TextDark))
        {
            g.DrawString("INVOICE", fLabel, mutedB, x + 6f * s, y);
            y += 14f * s;
            g.DrawString(order.OrderNumber, fNum, darkB, x + 6f * s, y);
            y += 20f * s;
        }

        DrawDivider(g, x, y, w, AccentLine, s); y += 8f * s;

        // ── Customer & service rows ────────────────────────────────────────────
        string custName  = customer?.FullName ?? order.CustomerName ?? "—";
        string custPhone = customer?.Phone    ?? order.CustomerPhone ?? "";
        string service   = $"{order.ServiceName ?? "Standard Laundry"} · {order.LaundryCategory}";

        y = DrawRow(g, x, y, w, "Customer", custName + (custPhone.Length > 0 ? $"\n{custPhone}" : ""), s);
        y = DrawRow(g, x, y, w, "Service",  service, s);
        y = DrawRow(g, x, y, w, "Weight",   $"{order.WeightKg:F2} kg", s);

        // Pricing breakdown
        string breakdown = "";
        if (prices != null)
        {
            try
            {
                var q = LoadPricingCalculator.Calculate(order.LaundryCategory, order.WeightKg, prices);
                breakdown = q.GetBreakdown();
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(breakdown))
            y = DrawRow(g, x, y, w, "Loads", breakdown, s);

        DrawDivider(g, x, y, w, AccentLine, s); y += 8f * s;

        // ── Total & payment ────────────────────────────────────────────────────
        using (var fTotalLbl = F(9f * s, FontStyle.Bold))
        using (var fTotalVal = F(14f * s, FontStyle.Bold))
        using (var darkB     = new SolidBrush(TextDark))
        using (var headerB   = new SolidBrush(HeaderBg))
        using (var mutedB    = new SolidBrush(TextMuted))
        {
            g.DrawString("TOTAL DUE", fTotalLbl, mutedB, x + 6f * s, y);
            y += 15f * s;
            g.DrawString($"₱ {order.TotalAmount:N2}", fTotalVal, headerB, x + 6f * s, y);
            y += 24f * s;
        }

        // Payment status pill
        bool paid = order.PaymentRecorded;
        string pillText = paid
            ? (order.AmountPaid.HasValue ? $"PAID  ₱{order.AmountPaid:N2}" : "PAID")
            : "UNPAID";
        Color pillBg = paid ? PaidGreen : UnpaidRed;

        using (var pillBrush = new SolidBrush(pillBg))
        using (var fPill = F(8.5f * s, FontStyle.Bold))
        {
            float pillW = Math.Min(w - 12f * s, 160f * s);
            var pillRect = new RectangleF(x + 6f * s, y, pillW, 20f * s);
            g.FillRectangle(pillBrush, pillRect);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(pillText, fPill, Brushes.White, pillRect, sf);
            y += 26f * s;
        }

        DrawDivider(g, x, y, w, AccentLine, s); y += 8f * s;

        // ── Pickup & date rows ─────────────────────────────────────────────────
        if (order.PickupDate.HasValue)
            y = DrawRow(g, x, y, w, "Pickup", order.PickupDate.Value.ToString("MMMM dd, yyyy"), s);
        y = DrawRow(g, x, y, w, "Ordered", order.CreatedAt.ToString("MMM dd, yyyy  hh:mm tt"), s);

        // Cancel reason
        if (!string.IsNullOrWhiteSpace(order.CancelReason))
        {
            DrawDivider(g, x, y, w, Color.FromArgb(220, 38, 38), s); y += 8f * s;
            y = DrawRow(g, x, y, w, "CANCELLED", order.CancelReason, s,
                labelColor: Color.FromArgb(220, 38, 38));
        }

        // ── Footer ────────────────────────────────────────────────────────────
        y += 6f * s;
        DrawDivider(g, x, y, w, AccentLine, s); y += 6f * s;
        using (var fFoot = F(7.5f * s))
        using (var mutedB = new SolidBrush(TextMuted))
        {
            var sf = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString("Thank you for choosing " + shopName + "!", fFoot, mutedB,
                new RectangleF(x, y, w, 16f * s), sf);
        }
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private static void DrawDivider(Graphics g, float x, float y, float w, Color c, float s)
    {
        using var pen = new Pen(c, Math.Max(0.75f, 0.75f * s));
        g.DrawLine(pen, x + 4f * s, y, x + w - 4f * s, y);
    }

    private static float DrawRow(
        Graphics g, float x, float y, float w,
        string label, string value, float s,
        Color? labelColor = null)
    {
        using var fLbl = F(7.5f * s, FontStyle.Bold);
        using var fVal = F(9f * s);
        using var lblB = new SolidBrush(labelColor ?? TextMuted);
        using var valB = new SolidBrush(TextDark);

        float labelW = 76f * s;
        float valueX = x + labelW + 4f * s;
        float valueW = w - labelW - 10f * s;

        // Measure value height for multi-line
        var sf = new StringFormat { Trimming = StringTrimming.Word };
        var measured = g.MeasureString(value, fVal, (int)Math.Max(1f, valueW), sf);
        float rowH = Math.Max(measured.Height, 14f * s);

        var lblRect = new RectangleF(x + 6f * s, y, labelW, rowH);
        var sfLbl = new StringFormat { LineAlignment = StringAlignment.Near };
        g.DrawString(label, fLbl, lblB, lblRect, sfLbl);
        g.DrawString(value, fVal, valB, new RectangleF(valueX, y, valueW, rowH), sf);

        return y + rowH + 4f * s;
    }
}
