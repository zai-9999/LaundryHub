using System.Drawing.Printing;
using System.Text;
using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Customer;

/// <summary>
/// Customer-facing invoice dialog.
/// Uses <see cref="InvoicePreviewPanel"/> so the rendering is
/// pixel-identical to the staff-side invoice preview.
/// </summary>
public sealed class FrmCustomerInvoice : Form
{
    private readonly Order _order;
    private readonly CustomerModel? _customer;
    private readonly List<LoadPrice>? _prices;

    // LogicalWidth : LogicalHeight = 440 : ~480 – keep a nice aspect ratio
    // We display at 440 px wide inside the dialog.
    private const int PreviewW = 520;
    private const int PreviewH = 560;   // matches InvoicePreviewPanel.DesignH

    public FrmCustomerInvoice(Order order, CustomerModel? customer = null)
    {
        _order    = order;
        _customer = customer
                    ?? (order.CustomerId > 0
                        ? AppServices.Customers.GetById(order.CustomerId)
                        : null);
        _prices   = LoadPrices();

        Build();
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Form construction
    // ─────────────────────────────────────────────────────────────────────────

    private void Build()
    {
        // ── Window ─────────────────────────────────────────────────────────
        Text            = $"Invoice  {_order.OrderNumber}";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition   = FormStartPosition.CenterParent;
        MaximizeBox     = false;
        MinimizeBox     = false;
        BackColor       = Color.White;

        const int pad    = 16;          // horizontal padding either side
        const int barH   = 56;         // height of the bottom action bar
        int       formW  = PreviewW + pad * 2;
        int       formH  = PreviewH + barH + pad * 2;
        ClientSize = new Size(formW, formH);

        // ── Invoice preview (pixel-identical to staff view) ─────────────
        var preview = new InvoicePreviewPanel
        {
            Location  = new Point(pad, pad),
            Size      = new Size(PreviewW, PreviewH),
            BackColor = Color.White
        };
        preview.SetInvoice(_order, _customer, _prices);

        // ── Action bar ─────────────────────────────────────────────────
        var pnlBar = new Panel
        {
            Location  = new Point(0, pad + PreviewH + pad),
            Size      = new Size(formW, barH),
            BackColor = Color.White
        };
        pnlBar.Paint += (s, e) =>
        {
            using var pen = new Pen(UIThemeHelper.Border, 1f);
            e.Graphics.DrawLine(pen, 0, 0, pnlBar.Width, 0);
        };

        var btnPrint = MakeButton(" Print / Save PDF",
            UIThemeHelper.Indigo, Color.White, 12);
        btnPrint.Click += (_, _) => PrintInvoice();

        var btnCopy = MakeButton(" Copy Details",
            UIThemeHelper.Surface, UIThemeHelper.Navy, 0);
        btnCopy.FlatAppearance.BorderSize  = 1;
        btnCopy.FlatAppearance.BorderColor = UIThemeHelper.BorderSoft;
        btnCopy.Click += (_, _) =>
        {
            CopyToClipboard(BuildSummary());
            MessageBox.Show("Invoice details copied to clipboard!",
                "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        };

        var btnClose = MakeButton("Close",
            UIThemeHelper.Navy, Color.White, 0);
        btnClose.Click += (_, _) => Close();

        // Layout buttons right-to-left with fixed spacing
        const int btnH = 36;
        const int bPad = 12;
        int bY = (barH - btnH) / 2;

        btnClose.Size      = new Size(90, btnH);
        btnClose.Location  = new Point(formW - 90 - bPad, bY);

        btnCopy.Size       = new Size(120, btnH);
        btnCopy.Location   = new Point(btnClose.Left - 120 - 6, bY);

        btnPrint.Size      = new Size(150, btnH);
        btnPrint.Location  = new Point(bPad, bY);

        pnlBar.Controls.AddRange(new Control[] { btnPrint, btnCopy, btnClose });

        Controls.Add(preview);
        Controls.Add(pnlBar);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Helpers
    // ─────────────────────────────────────────────────────────────────────────

    private static Button MakeButton(string text, Color back, Color fore, int radius)
    {
        var b = new Button
        {
            Text      = text,
            BackColor = back,
            ForeColor = fore,
            FlatStyle = FlatStyle.Flat,
            Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
            Cursor    = Cursors.Hand
        };
        b.FlatAppearance.BorderSize = 0;
        if (radius > 0)
        {
            b.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var path = UIThemeHelper.CreateRoundedRectangle(
                    new Rectangle(0, 0, b.Width - 1, b.Height - 1), radius);
                using var brush = new SolidBrush(back);
                e.Graphics.FillPath(brush, path);
                var sf = new StringFormat
                {
                    Alignment     = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                using var fnt = new Font("Segoe UI", 9f, FontStyle.Bold);
                using var tb  = new SolidBrush(fore);
                e.Graphics.DrawString(b.Text, fnt, tb, b.ClientRectangle, sf);
            };
        }
        return b;
    }

    private static List<LoadPrice>? LoadPrices()
    {
        try   { return AppServices.LoadPricing.GetAll().ToList(); }
        catch { return null; }
    }

    private void PrintInvoice()
    {
        try
        {
            using var printDoc = new PrintDocument
                { DocumentName = $"Invoice {_order.OrderNumber}" };

            printDoc.PrintPage += (s, ev) =>
            {
                if (ev.Graphics == null) return;
                var area  = ev.MarginBounds;
                float sc  = Math.Min(area.Width  / InvoiceRenderer.LogicalWidth,
                                     area.Height / InvoiceRenderer.LogicalHeight);
                float w   = InvoiceRenderer.LogicalWidth * sc;
                float x   = area.Left + (area.Width - w) / 2f;

                InvoiceRenderer.Draw(ev.Graphics,
                    new RectangleF(x, area.Top, w, 0),
                    _order, _customer, AppServices.ShopName, _prices);

                ev.HasMorePages = false;
            };

            using var dlg = new PrintPreviewDialog
            {
                Document    = printDoc,
                Text        = $"Invoice  {_order.OrderNumber}",
                WindowState = FormWindowState.Maximized
            };
            dlg.ShowDialog(this);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Print error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string BuildSummary()
    {
        var sb = new StringBuilder();
        sb.AppendLine(AppServices.ShopName);
        sb.AppendLine("INVOICE");
        sb.AppendLine(new string('-', 36));
        sb.AppendLine($"Invoice No:    {_order.OrderNumber}");
        sb.AppendLine($"Date Issued:   {_order.CreatedAt:MMM dd, yyyy  hh:mm tt}");
        sb.AppendLine($"Customer:      {_customer?.FullName ?? _order.CustomerName}");
        sb.AppendLine($"Phone:         {_customer?.Phone   ?? _order.CustomerPhone}");
        sb.AppendLine($"Service:       {_order.ServiceName} · {_order.LaundryCategory}");
        sb.AppendLine($"Weight:        {_order.WeightKg:F2} kg");
        sb.AppendLine($"Status:        {_order.Status}");
        sb.AppendLine($"Pickup:        {_order.PickupDate?.ToString("MMMM dd, yyyy") ?? "—"}");
        sb.AppendLine(new string('-', 36));
        sb.AppendLine($"TOTAL DUE:     ₱{_order.TotalAmount:N2}");
        sb.AppendLine($"Payment:       {(_order.PaymentRecorded ? $"PAID (₱{_order.AmountPaid:N2})" : "UNPAID")}");
        if (!string.IsNullOrWhiteSpace(_order.CancelReason))
            sb.AppendLine($"Cancelled:     {_order.CancelReason}");
        return sb.ToString();
    }

    private static void CopyToClipboard(string text)
    {
        try   { Clipboard.SetText(text); }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not copy: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
