using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text;
using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Customer;

public partial class FrmCustomerInvoice : Form
{
    private readonly Order _order;
    private readonly CustomerModel? _customer;
    private readonly List<LoadPrice>? _prices;

    public FrmCustomerInvoice(Order order, CustomerModel? customer = null)
    {
        _order = order;
        _customer = customer ?? (order.CustomerId > 0 ? AppServices.Customers.GetById(order.CustomerId) : null);
        _prices = LoadPrices();

        InitializeComponent();
        PopulateData();
    }

    private static List<LoadPrice>? LoadPrices()
    {
        try { return AppServices.LoadPricing.GetAll().ToList(); }
        catch { return null; }
    }

    private void InitializeComponent()
    {
        Text = $"Invoice — {_order.OrderNumber}";
        ClientSize = new Size(500, 710);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = UIThemeHelper.Surface;
        Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

        // ── 1. Branded Header Band ──────────────────────────────────────────
        var pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 76,
            Padding = new Padding(24, 14, 24, 12)
        };
        pnlHeader.Paint += (s, e) =>
        {
            using var brush = new LinearGradientBrush(
                pnlHeader.ClientRectangle,
                UIThemeHelper.Navy,
                UIThemeHelper.Indigo,
                LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
        };

        var lblShopName = new Label
        {
            Text = AppServices.ShopName,
            Font = new Font("Segoe UI", 13.5f, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            AutoSize = true,
            Location = new Point(22, 14)
        };

        var lblSub = new Label
        {
            Text = "OFFICIAL CUSTOMER INVOICE & RECEIPT",
            Font = new Font("Segoe UI", 8f, FontStyle.Bold),
            ForeColor = UIThemeHelper.Sand,
            BackColor = Color.Transparent,
            AutoSize = true,
            Location = new Point(24, 42)
        };
        pnlHeader.Controls.AddRange(new Control[] { lblShopName, lblSub });

        // ── 2. Invoice Meta & Status Bar ────────────────────────────────────
        var pnlMeta = new Panel
        {
            Dock = DockStyle.Top,
            Height = 56,
            BackColor = Color.White,
            Padding = new Padding(20, 0, 20, 0)
        };
        pnlMeta.Paint += (s, e) =>
        {
            using var pen = new Pen(UIThemeHelper.Border, 1f);
            e.Graphics.DrawLine(pen, 0, pnlMeta.Height - 1, pnlMeta.Width, pnlMeta.Height - 1);
        };

        var lblOrderNo = new Label
        {
            Text = _order.OrderNumber,
            Font = new Font("Segoe UI", 12f, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            AutoSize = true,
            Location = new Point(20, 16)
        };

        var btnCopyNo = new Button
        {
            Text = "Copy",
            Size = new Size(54, 26),
            Location = new Point(lblOrderNo.Right + 8, 15),
            Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
            BackColor = UIThemeHelper.Surface,
            ForeColor = UIThemeHelper.Indigo,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnCopyNo.FlatAppearance.BorderColor = UIThemeHelper.BorderSoft;
        btnCopyNo.FlatAppearance.BorderSize = 1;
        btnCopyNo.Click += (_, _) =>
        {
            CopyToClipboard(_order.OrderNumber);
            btnCopyNo.Text = "Copied!";
            var timer = new System.Windows.Forms.Timer { Interval = 1500 };
            timer.Tick += (ts, te) =>
            {
                btnCopyNo.Text = "Copy";
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        };

        // Status pills on the right
        var pillStatus = CreateStatusPill(_order.Status);
        pillStatus.Location = new Point(pnlMeta.Width - pillStatus.Width - 20, 14);
        pillStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        var pillPayment = CreatePaymentPill(_order.PaymentRecorded);
        pillPayment.Location = new Point(pillStatus.Left - pillPayment.Width - 8, 14);
        pillPayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        pnlMeta.Controls.AddRange(new Control[] { lblOrderNo, btnCopyNo, pillPayment, pillStatus });

        // ── 3. Bottom Action Bar ───────────────────────────────────────────
        var pnlFooter = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 62,
            BackColor = Color.White,
            Padding = new Padding(20, 12, 20, 12)
        };
        pnlFooter.Paint += (s, e) =>
        {
            using var pen = new Pen(UIThemeHelper.Border, 1f);
            e.Graphics.DrawLine(pen, 0, 0, pnlFooter.Width, 0);
        };

        var btnPrint = new Button
        {
            Text = " Print / Save PDF",
            Size = new Size(150, 38),
            Location = new Point(20, 12),
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            BackColor = UIThemeHelper.Indigo,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnPrint.FlatAppearance.BorderSize = 0;
        btnPrint.Click += (_, _) => PrintInvoice();

        var btnCopyAll = new Button
        {
            Text = " Copy Details",
            Size = new Size(130, 38),
            Location = new Point(178, 12),
            Font = new Font("Segoe UI", 9f),
            BackColor = UIThemeHelper.Surface,
            ForeColor = UIThemeHelper.Navy,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnCopyAll.FlatAppearance.BorderColor = UIThemeHelper.BorderSoft;
        btnCopyAll.FlatAppearance.BorderSize = 1;
        btnCopyAll.Click += (_, _) =>
        {
            CopyToClipboard(BuildInvoiceSummary());
            MessageBox.Show("Invoice summary copied to clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        };

        var btnClose = new Button
        {
            Text = "Close",
            Size = new Size(100, 38),
            Location = new Point(pnlFooter.Width - 120, 12),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            BackColor = UIThemeHelper.Navy,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Click += (_, _) => Close();

        pnlFooter.Controls.AddRange(new Control[] { btnPrint, btnCopyAll, btnClose });

        // ── 4. Scrollable Body Content ─────────────────────────────────────
        var pnlBody = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            BackColor = UIThemeHelper.Surface,
            Padding = new Padding(16, 12, 16, 12)
        };

        int cardW = 450;
        int y = 10;

        // Card A: Details Table
        var pnlDetails = BuildDetailsCard(cardW);
        pnlDetails.Location = new Point(16, y);
        pnlBody.Controls.Add(pnlDetails);
        y += pnlDetails.Height + 10;

        // Card B: Pickup QR Code Card
        var pnlQr = BuildQrCard(cardW);
        pnlQr.Location = new Point(16, y);
        pnlBody.Controls.Add(pnlQr);
        y += pnlQr.Height + 10;

        // Card C: Total & Payment Summary
        var pnlTotal = BuildTotalCard(cardW);
        pnlTotal.Location = new Point(16, y);
        pnlBody.Controls.Add(pnlTotal);
        y += pnlTotal.Height + 16;

        // Add panels to Form in reverse dock order
        Controls.Add(pnlBody);
        Controls.Add(pnlFooter);
        Controls.Add(pnlMeta);
        Controls.Add(pnlHeader);
    }

    private Panel BuildDetailsCard(int width)
    {
        var card = new Panel
        {
            Width = width,
            BackColor = Color.White
        };

        var rows = new List<(string Label, string Value)>();

        var custName = _customer?.FullName ?? _order.CustomerName ?? "—";
        var custPhone = _customer?.Phone ?? _order.CustomerPhone ?? "";
        rows.Add(("Customer", string.IsNullOrEmpty(custPhone) ? custName : $"{custName}  ({custPhone})"));

        var service = _order.ServiceName ?? "Standard Laundry";
        if (!string.IsNullOrEmpty(_order.LaundryCategory))
            service += $" — {_order.LaundryCategory}";
        rows.Add(("Service", service));

        // Weight & load breakdown
        string weightVal = $"{_order.WeightKg:N2} kg";
        string breakdown = GetLoadBreakdown();
        if (!string.IsNullOrEmpty(breakdown))
            weightVal += $"  ({breakdown})";
        rows.Add(("Weight / Load", weightVal));

        rows.Add(("Date Issued", _order.CreatedAt.ToString("MMM dd, yyyy  hh:mm tt")));
        rows.Add(("Target Pickup", _order.PickupDate?.ToString("MMMM dd, yyyy") ?? "—"));

        int y = 14;
        foreach (var (lbl, val) in rows)
        {
            var lLabel = new Label
            {
                Text = lbl,
                Font = new Font("Segoe UI", 9f, FontStyle.Regular),
                ForeColor = UIThemeHelper.TextMuted,
                Location = new Point(18, y + 1),
                Size = new Size(110, 22)
            };
            var lVal = new Label
            {
                Text = val,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = UIThemeHelper.Navy,
                Location = new Point(136, y),
                Size = new Size(width - 152, 22),
                AutoEllipsis = true
            };
            card.Controls.AddRange(new Control[] { lLabel, lVal });
            y += 26;
        }

        // Cancelled banner if order was cancelled
        if (!string.IsNullOrWhiteSpace(_order.CancelReason))
        {
            y += 4;
            var pnlCancel = new Panel
            {
                Location = new Point(16, y),
                Size = new Size(width - 32, 42),
                BackColor = Color.FromArgb(254, 242, 242)
            };
            pnlCancel.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(239, 68, 68), 1f);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlCancel.Width - 1, pnlCancel.Height - 1);
            };
            var lblCancel = new Label
            {
                Text = $"Cancelled: {_order.CancelReason}",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(185, 28, 28),
                Location = new Point(10, 10),
                Size = new Size(pnlCancel.Width - 20, 24),
                AutoEllipsis = true
            };
            pnlCancel.Controls.Add(lblCancel);
            card.Controls.Add(pnlCancel);
            y += 48;
        }

        card.Height = y + 10;
        card.Paint += (s, e) =>
        {
            using var pen = new Pen(UIThemeHelper.Border, 1f);
            using var path = UIThemeHelper.CreateRoundedRectangle(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 8);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, path);
        };

        return card;
    }

    private Panel BuildQrCard(int width)
    {
        var card = new Panel
        {
            Width = width,
            Height = 175,
            BackColor = Color.White
        };

        var pbQr = new PictureBox
        {
            Size = new Size(116, 116),
            Location = new Point((width - 116) / 2, 12),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.White
        };

        try
        {
            pbQr.Image = QrCodeHelper.GenerateQrCode(_order.OrderNumber);
        }
        catch { }

        var lblCaption = new Label
        {
            Text = "Present this QR code or order number at the counter for pickup.",
            Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
            ForeColor = UIThemeHelper.TextMuted,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(16, 136),
            Size = new Size(width - 32, 26)
        };

        card.Controls.AddRange(new Control[] { pbQr, lblCaption });
        card.Paint += (s, e) =>
        {
            using var pen = new Pen(UIThemeHelper.Border, 1f);
            using var path = UIThemeHelper.CreateRoundedRectangle(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 8);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, path);
        };

        return card;
    }

    private Panel BuildTotalCard(int width)
    {
        var card = new Panel
        {
            Width = width,
            Height = _order.PaymentRecorded ? 82 : 68,
            BackColor = Color.FromArgb(240, 243, 252)
        };

        var lblTotalTitle = new Label
        {
            Text = "TOTAL AMOUNT DUE",
            Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
            ForeColor = UIThemeHelper.Indigo,
            Location = new Point(18, 14),
            AutoSize = true
        };

        var lblTotalVal = new Label
        {
            Text = $"₱{_order.TotalAmount:N2}",
            Font = new Font("Segoe UI", 16f, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Location = new Point(18, 32),
            AutoSize = true
        };

        card.Controls.AddRange(new Control[] { lblTotalTitle, lblTotalVal });

        if (_order.PaymentRecorded && _order.AmountPaid.HasValue)
        {
            decimal paid = _order.AmountPaid.Value;
            decimal change = Math.Max(0, paid - _order.TotalAmount);
            var lblPaidInfo = new Label
            {
                Text = $"Paid: ₱{paid:N2}  |  Change: ₱{change:N2}",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = UIThemeHelper.Success,
                Location = new Point(18, 58),
                AutoSize = true
            };
            card.Controls.Add(lblPaidInfo);
        }

        card.Paint += (s, e) =>
        {
            using var pen = new Pen(UIThemeHelper.BorderSoft, 1f);
            using var path = UIThemeHelper.CreateRoundedRectangle(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 8);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, path);
        };

        return card;
    }

    private string GetLoadBreakdown()
    {
        if (_prices == null) return "";
        try
        {
            var quote = LoadPricingCalculator.Calculate(_order.LaundryCategory, _order.WeightKg, _prices);
            return quote.GetBreakdown();
        }
        catch
        {
            return "";
        }
    }

    private static Control CreateStatusPill(string status)
    {
        var (bg, fg, border) = status switch
        {
            "Ready for Pickup" => (Color.FromArgb(221, 239, 230), Color.FromArgb(47, 107, 79), Color.FromArgb(167, 219, 194)),
            "Washing"          => (Color.FromArgb(226, 230, 242), Color.FromArgb(75, 86, 148), Color.FromArgb(190, 198, 225)),
            "Drying"           => (Color.FromArgb(224, 232, 244), Color.FromArgb(62, 86, 130), Color.FromArgb(185, 202, 228)),
            "Claimed"          => (Color.FromArgb(236, 237, 243), Color.FromArgb(92, 99, 137), Color.FromArgb(205, 208, 222)),
            "Cancelled"        => (Color.FromArgb(254, 226, 226), Color.FromArgb(185, 28, 28), Color.FromArgb(248, 180, 180)),
            _                  => (Color.FromArgb(236, 237, 243), Color.FromArgb(92, 99, 137), Color.FromArgb(205, 208, 222))
        };

        return new PillBadge
        {
            BadgeText = status,
            FillColor = bg,
            TextColor = fg,
            BorderColor = border,
            Size = new Size(Math.Max(84, TextRenderer.MeasureText(status, new Font("Segoe UI", 8.5f, FontStyle.Bold)).Width + 18), 28)
        };
    }

    private static Control CreatePaymentPill(bool paid)
    {
        string text = paid ? "PAID" : "UNPAID";
        var (bg, fg, border) = paid
            ? (Color.FromArgb(221, 239, 230), Color.FromArgb(47, 107, 79), Color.FromArgb(167, 219, 194))
            : (Color.FromArgb(254, 226, 226), Color.FromArgb(185, 28, 28), Color.FromArgb(248, 180, 180));

        return new PillBadge
        {
            BadgeText = text,
            FillColor = bg,
            TextColor = fg,
            BorderColor = border,
            Size = new Size(68, 28)
        };
    }

    private void PrintInvoice()
    {
        try
        {
            using var printDoc = new PrintDocument { DocumentName = $"Invoice {_order.OrderNumber}" };
            printDoc.PrintPage += (s, ev) =>
            {
                if (ev.Graphics == null) return;
                var area = ev.MarginBounds;
                float scale = Math.Min(area.Width / InvoiceRenderer.LogicalWidth,
                                       area.Height / InvoiceRenderer.LogicalHeight);
                float width = InvoiceRenderer.LogicalWidth * scale;
                float x = area.Left + (area.Width - width) / 2f;

                InvoiceRenderer.Draw(ev.Graphics, new RectangleF(x, area.Top, width, 0),
                    _order, _customer, AppServices.ShopName, _prices);
                ev.HasMorePages = false;
            };

            using var preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Text = $"Invoice  {_order.OrderNumber}",
                WindowState = FormWindowState.Maximized
            };
            preview.ShowDialog(this);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not open print preview: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string BuildInvoiceSummary()
    {
        var sb = new StringBuilder();
        sb.AppendLine(AppServices.ShopName);
        sb.AppendLine("OFFICIAL CUSTOMER INVOICE");
        sb.AppendLine(new string('-', 40));
        sb.AppendLine($"Invoice No:    {_order.OrderNumber}");
        sb.AppendLine($"Date Issued:   {_order.CreatedAt:MMM dd, yyyy  hh:mm tt}");
        sb.AppendLine($"Customer:      {_customer?.FullName ?? _order.CustomerName}");
        sb.AppendLine($"Phone:         {_customer?.Phone ?? _order.CustomerPhone}");
        sb.AppendLine($"Service:       {_order.ServiceName ?? "Standard Laundry"} ({_order.LaundryCategory})");
        sb.AppendLine($"Weight:        {_order.WeightKg:N2} kg");
        sb.AppendLine($"Status:        {_order.Status}");
        sb.AppendLine($"Target Pickup: {_order.PickupDate?.ToString("MMMM dd, yyyy") ?? "—"}");
        sb.AppendLine(new string('-', 40));
        sb.AppendLine($"TOTAL AMOUNT:  ₱{_order.TotalAmount:N2}");
        sb.AppendLine($"Payment:       {(_order.PaymentRecorded ? $"PAID (₱{_order.AmountPaid:N2})" : "UNPAID")}");
        if (!string.IsNullOrWhiteSpace(_order.CancelReason))
            sb.AppendLine($"Cancel Reason: {_order.CancelReason}");
        return sb.ToString();
    }

    private static void CopyToClipboard(string text)
    {
        try
        {
            Clipboard.SetText(text);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not copy: {ex.Message}", "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void PopulateData()
    {
        // Any dynamic data updates after initialization if needed
    }

    private sealed class PillBadge : Control
    {
        public PillBadge()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        public string BadgeText { get; set; } = "";
        public Color FillColor { get; set; } = Color.LightGray;
        public Color TextColor { get; set; } = Color.Black;
        public Color BorderColor { get; set; } = Color.Transparent;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            if (Width <= 0 || Height <= 0) return;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            int radius = Height / 2;
            using var path = UIThemeHelper.CreateRoundedRectangle(rect, radius);
            using var brush = new SolidBrush(FillColor);
            e.Graphics.FillPath(brush, path);

            if (BorderColor != Color.Transparent)
            {
                using var pen = new Pen(BorderColor, 1f);
                e.Graphics.DrawPath(pen, path);
            }

            using var font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            using var textBrush = new SolidBrush(TextColor);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(BadgeText, font, textBrush, rect, sf);
        }
    }
}
