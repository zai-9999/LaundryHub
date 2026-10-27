using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Drawing.Printing;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmOrderDetail : Form
{
    private Order _order;
    private CustomerModel? _customer;

    public FrmOrderDetail() : this(new Order { OrderNumber = "LH-DEMO-001", Status = "Washing", TotalAmount = 260.00m, WeightKg = 4.0m })
    {
    }

    public FrmOrderDetail(Order order)
    {
        InitializeComponent();
        _order = order;
        DoubleBuffered = true;
        ResizeRedraw = true;
        UIThemeHelper.StyleStandardForm(this, pnlLeftCard, pnlRightCard);
        pnlLeftCard.SizeChanged += (s, e) =>
        {
            if (this.WindowState == FormWindowState.Maximized)
                pnlLeftCard.Region = null;
            else
                UIThemeHelper.ApplyRoundedRegion(pnlLeftCard, UIThemeHelper.ContentCardRadius);
        };
        pnlRightCard.SizeChanged += (s, e) =>
        {
            if (this.WindowState == FormWindowState.Maximized)
                pnlRightCard.Region = null;
            else
                UIThemeHelper.ApplyRoundedRegion(pnlRightCard, UIThemeHelper.ContentCardRadius);
        };
        pnlHeader.BackColor = UIThemeHelper.Navy;
        lblOrderNumber.BackColor = UIThemeHelper.Navy;
        pnlContainer.BackColor = UIThemeHelper.Surface;
        pnlRightWrapper.BackColor = UIThemeHelper.Surface;
        BuildExtras();
        RefreshOrderData();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void btnClose_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void RefreshOrderData()
    {
        if (_order.OrderId > 0)
        {
            var updated = AppServices.Orders.GetById(_order.OrderId);
            if (updated != null) _order = updated;
            _customer = AppServices.Customers.GetById(_order.CustomerId);
        }

        this.Text = $"Order Details  {_order.OrderNumber}";
        lblOrderNumber.Text = _order.OrderNumber;
        lblCustomerInfo.Text = $"{_customer?.FullName ?? _order.CustomerName} ({_customer?.Phone ?? _order.CustomerPhone})";
        lblServiceInfo.Text = $"{_order.ServiceName ?? "Standard Laundry"} — {_order.LaundryCategory}";
        lblWeightInfo.Text = $"{_order.WeightKg:F2} kg";
        lblTotalAmount.Text = $"{_order.TotalAmount:N2}";

        if (_order.PaymentRecorded)
        {
            lblPaymentStatus.Text = $"Paid ({_order.AmountPaid:N2})";
            lblPaymentStatus.ForeColor = UIThemeHelper.Sand;
        }
        else
        {
            lblPaymentStatus.Text = "Unpaid";
            lblPaymentStatus.ForeColor = UIThemeHelper.Indigo;
        }

        lblPickupDate.Text = _order.PickupDate?.ToString("MMMM dd, yyyy") ?? "";
        lblCreatedDate.Text = _order.CreatedAt.ToString("MMM dd, yyyy hh:mm tt");
        lblCancelReason.Text = string.IsNullOrWhiteSpace(_order.CancelReason) ? "" : _order.CancelReason;

        // Status badge styling
        UpdateStatusBadge();

        picQrCode.SetInvoice(_order, _customer, LoadPrices());

        // Update button states
        btnAdvanceStatus.Visible = _order.Status is "Washing" or "Drying";
        if (_order.Status == "Washing")
        {
            btnAdvanceStatus.Text = " Mark as Drying";
            btnAdvanceStatus.BackColor = UIThemeHelper.Slate;
        }
        else if (_order.Status == "Drying")
        {
            btnAdvanceStatus.Text = " Ready for Pickup";
            btnAdvanceStatus.BackColor = UIThemeHelper.Slate;
        }

        btnClaimOrder.Visible = _order.Status == "Ready for Pickup";
        btnCancelOrder.Visible = _order.Status is not ("Ready for Pickup" or "Claimed" or "Cancelled");
        btnEditWeight.Visible = _order.Status is "Washing" or "Drying" or "Ready for Pickup" && !_order.PaymentRecorded;
    }

    private void UpdateStatusBadge()
    {
        lblStatusBadge.Text = _order.Status.ToUpper();
        switch (_order.Status)
        {
            case "Washing":
                lblStatusBadge.BackColor = UIThemeHelper.Indigo;
                lblStatusBadge.ForeColor = Color.White;
                break;
            case "Drying":
                lblStatusBadge.BackColor = UIThemeHelper.Slate;
                lblStatusBadge.ForeColor = Color.White;
                break;
            case "Ready for Pickup":
                lblStatusBadge.BackColor = UIThemeHelper.Success;
                lblStatusBadge.ForeColor = Color.White;
                break;
            case "Claimed":
                lblStatusBadge.BackColor = UIThemeHelper.Neutral;
                lblStatusBadge.ForeColor = Color.White;
                break;
            case "Cancelled":
                lblStatusBadge.BackColor = UIThemeHelper.Danger;
                lblStatusBadge.ForeColor = Color.White;
                break;
            default:
                lblStatusBadge.BackColor = UIThemeHelper.Indigo;
                lblStatusBadge.ForeColor = Color.White;
                break;
        }
    }

    private async void btnAdvanceStatus_Click(object? sender, EventArgs e)
    {
        string nextStatus = _order.Status switch
        {
            "Washing" => "Drying",
            "Drying"  => "Ready for Pickup",
            _ => _order.Status
        };

        if (nextStatus != _order.Status)
        {
            try
            {
                AppServices.Orders.UpdateStatus(_order.OrderId, nextStatus, changedBy: SessionManager.CurrentUser?.UserId);
                RefreshOrderData();

                if (nextStatus == "Ready for Pickup")
                {
                    if (_customer == null || string.IsNullOrWhiteSpace(_customer.Email))
                    {
                        MessageBox.Show(
                            "Order status moved to 'Ready for Pickup', but this customer has no email address registered.",
                            "Status Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else if (await EmailHelper.SendReadyForPickupAsync(_order, _customer))
                    {
                        MessageBox.Show(
                            $"Order status moved to 'Ready for Pickup'. A notification was sent to {_customer.Email}.",
                            "Status Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Order status moved to 'Ready for Pickup', but the email notification could not be sent.",
                            "Status Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Order status moved to '{nextStatus}'.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update order status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnEditWeight_Click(object? sender, EventArgs e)
    {
        var loadPrices = AppServices.LoadPricing.GetAll().ToList();

        using var dlg = new Form
        {
            Text = $"Confirm Actual Weight - {_order.OrderNumber}",
            Size = new Size(410, 340),
            StartPosition = FormStartPosition.CenterParent,
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblPrompt = new Label
        {
            Text = "Enter the Weight Confirmed at Drop-off (kg):",
            Location = new Point(30, 20),
            Size = new Size(340, 25),
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };
        var txtWeight = new TextBox
        {
            Text = _order.WeightKg.ToString("F2"),
            Location = new Point(30, 55),
            Size = new Size(340, 32),
            Font = new Font("Segoe UI", 12),
            BackColor = Color.FromArgb(30, 41, 59),
            ForeColor = Color.White
        };
        var lblTotal = new Label
        {
            Location = new Point(30, 95),
            Size = new Size(340, 65),
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = Color.FromArgb(52, 211, 153)
        };
        var btnConfirm = new Button
        {
            Text = "Save Confirmed Weight",
            Location = new Point(30, 180),
            Size = new Size(340, 38),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };
        btnConfirm.FlatAppearance.BorderSize = 0;

        decimal? GetWeight()
        {
            return decimal.TryParse(txtWeight.Text, out var weight) &&
                   weight > 0 && weight <= 100 && decimal.Round(weight, 2) == weight
                ? weight
                : null;
        }

        void UpdatePreview()
        {
            var weight = GetWeight();
            var quote = weight.HasValue
                ? LoadPricingCalculator.Calculate(_order.LaundryCategory, weight.Value, loadPrices)
                : null;
            lblTotal.Text = quote != null
                ? $"New total: {quote.Total:N2}\n{quote.GetBreakdown()}"
                : "Enter a Valid Weight.";
            lblTotal.ForeColor = weight.HasValue ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
        }

        txtWeight.TextChanged += (_, _) => UpdatePreview();
        btnConfirm.Click += (_, _) =>
        {
            var weight = GetWeight();
            if (!weight.HasValue)
            {
                MessageBox.Show("Please enter a weight from 0.01 to 100 kg, using up to two decimal places.",
                    "Invalid Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var total = LoadPricingCalculator.Calculate(_order.LaundryCategory, weight.Value, loadPrices).Total;
            if (!AppServices.Orders.UpdateConfirmedWeight(_order.OrderId, weight.Value, total))
            {
                MessageBox.Show("The weight was not updated. The order may already be paid, claimed, or cancelled.",
                    "Unable to Update Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dlg.DialogResult = DialogResult.OK;
            dlg.Close();
        };

        dlg.Controls.AddRange(new Control[] { lblPrompt, txtWeight, lblTotal, btnConfirm });
        UpdatePreview();
        UIThemeHelper.ApplyTheme(dlg);

        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            RefreshOrderData();
            MessageBox.Show("The confirmed weight and order total were updated.", "Weight Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnClaimOrder_Click(object? sender, EventArgs e)
    {
        using var dlg = new Form
        {
            Text = $"Claim Order  {_order.OrderNumber}",
            Size = new Size(380, 280),
            StartPosition = FormStartPosition.CenterParent,
            BackColor = Color.White,
            ForeColor = UIThemeHelper.Navy,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblPrompt = new Label
        {
            Text = $"Total Due: {_order.TotalAmount:N2}\nEnter Amount Tendered / Paid:",
            Location = new Point(30, 20),
            Size = new Size(310, 40),
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy
        };
        var txtAmount = new TextBox
        {
            Text = _order.TotalAmount.ToString("F2"),
            Location = new Point(30, 70),
            Size = new Size(300, 32),
            Font = new Font("Segoe UI", 12),
            BackColor = UIThemeHelper.Surface,
            ForeColor = UIThemeHelper.Navy,
            BorderStyle = BorderStyle.FixedSingle
        };
        var lblChange = new Label
        {
            Text = "Change: 0.00",
            Location = new Point(30, 115),
            Size = new Size(300, 25),
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = UIThemeHelper.Success
        };

        InputValidator.RestrictToDecimalInput(txtAmount);

        void UpdateChange()
        {
            if (decimal.TryParse(txtAmount.Text.Trim().Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out var paid))
            {
                var change = paid - _order.TotalAmount;
                lblChange.Text = change >= 0 ? $"Change: {change:N2}" : $"Short by: {Math.Abs(change):N2}";
                lblChange.ForeColor = change >= 0 ? UIThemeHelper.Success : UIThemeHelper.Danger;
            }
            else
            {
                lblChange.Text = "Enter a valid payment amount.";
                lblChange.ForeColor = UIThemeHelper.Warning;
            }
        }

        txtAmount.TextChanged += (_, _) => UpdateChange();
        UpdateChange();

        var btnConfirm = new Button
        {
            Text = "Confirm Payment & Claim",
            Location = new Point(30, 160),
            Size = new Size(300, 38),
            BackColor = UIThemeHelper.Indigo,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnConfirm.FlatAppearance.BorderSize = 0;
        btnConfirm.Click += (_, _) =>
        {
            if (!InputValidator.IsValidPrice(txtAmount.Text, out var paid, out var priceErr, fieldName: "Payment amount", min: _order.TotalAmount, max: 1000000m))
            {
                MessageBox.Show(priceErr, "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            try
            {
                AppServices.Orders.ClaimOrderWithPayment(_order.OrderId, paid, changedBy: SessionManager.CurrentUser?.UserId, notes: $"Paid: {paid:N2}");
                dlg.DialogResult = DialogResult.OK;
                dlg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to record payment and claim order: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        dlg.Controls.AddRange(new Control[] { lblPrompt, txtAmount, lblChange, btnConfirm });
        UIThemeHelper.ApplyTheme(dlg);
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            RefreshOrderData();
            MessageBox.Show("Order has been successfully marked as CLAIMED and payment recorded!", "Order Claimed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnCancelOrder_Click(object? sender, EventArgs e)
    {
        RefreshOrderData();
        if (_order.Status is "Ready for Pickup" or "Claimed" or "Cancelled")
        {
            MessageBox.Show($"This order is '{_order.Status}' and can no longer be cancelled.",
                "Cannot Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dlg = new Form
        {
            Text = "Cancel Order",
            Size = new Size(400, 240),
            StartPosition = FormStartPosition.CenterParent,
            BackColor = Color.White,
            ForeColor = UIThemeHelper.Navy,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblPrompt = new Label
        {
            Text = "Reason for cancellation *:",
            Location = new Point(30, 20),
            Size = new Size(330, 25),
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy
        };
        var txtReason = new TextBox
        {
            Location = new Point(30, 50),
            Size = new Size(330, 55),
            Multiline = true,
            MaxLength = 250,
            Font = new Font("Segoe UI", 9.5f),
            BackColor = UIThemeHelper.Surface,
            ForeColor = UIThemeHelper.Navy,
            BorderStyle = BorderStyle.FixedSingle
        };
        var btnConfirm = new Button
        {
            Text = "Confirm Cancel",
            Location = new Point(30, 125),
            Size = new Size(330, 36),
            BackColor = UIThemeHelper.Danger,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnConfirm.FlatAppearance.BorderSize = 0;
        btnConfirm.Click += (_, _) =>
        {
            var reason = txtReason.Text.Trim();
            if (string.IsNullOrWhiteSpace(reason) || reason.Length < 3)
            {
                MessageBox.Show("Please provide a valid cancellation reason (at least 3 characters).", "Reason Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return;
            }

            try
            {
                AppServices.Orders.UpdateStatus(_order.OrderId, "Cancelled", txtReason.Text.Trim(), changedBy: SessionManager.CurrentUser?.UserId);
                dlg.DialogResult = DialogResult.OK;
                dlg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to cancel order: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        dlg.Controls.AddRange(new Control[] { lblPrompt, txtReason, btnConfirm });
        UIThemeHelper.ApplyTheme(dlg);
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            RefreshOrderData();
            MessageBox.Show("Order cancelled.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnPrintQr_Click(object? sender, EventArgs e)
    {
        try
        {
            RefreshOrderData();
            var prices = LoadPrices();

            using var printDoc = new PrintDocument { DocumentName = $"Invoice {_order.OrderNumber}" };
            printDoc.PrintPage += (s, ev) =>
            {
                if (ev.Graphics == null) return;

                // Scale the invoice to fill the printable area (page units are 1/100 inch)
                var area = ev.MarginBounds;
                float scale = Math.Min(area.Width  / InvoiceRenderer.LogicalWidth,
                                       area.Height / InvoiceRenderer.LogicalHeight);
                float width = InvoiceRenderer.LogicalWidth * scale;
                float x = area.Left + (area.Width - width) / 2f;   // centre horizontally

                InvoiceRenderer.Draw(ev.Graphics, new RectangleF(x, area.Top, width, 0),
                    _order, _customer, AppServices.ShopName, prices);
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
            MessageBox.Show($"Print failed: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnResendEmail_Click(object? sender, EventArgs e)
    {
        if (_customer == null || string.IsNullOrWhiteSpace(_customer.Email))
        {
            MessageBox.Show("This customer does not have an email address registered.", "No Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        EmailHelper.SendReceiptAsync(_order, _customer);
        MessageBox.Show($"A digital receipt has been sent to {_customer.Email}.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BuildExtras()
    {
        // Right-click the invoice to copy
        var menu = new ContextMenuStrip();
        menu.Items.Add("Copy invoice number", null, (_, _) => CopyText(_order.OrderNumber));
        menu.Items.Add("Copy invoice details", null, (_, _) => CopyText(BuildInvoiceText()));
        picQrCode.ContextMenuStrip = menu;

        var tip = new ToolTip();
        tip.SetToolTip(lblOrderNumber, "Double-click to copy the invoice number");
        foreach (Control ctl in lblOrderNumber.Controls)
            tip.SetToolTip(ctl, "Double-click to copy the invoice number");
        lblOrderNumber.DoubleClick += (_, _) => CopyText(_order.OrderNumber);
    }

    private string BuildInvoiceText() => string.Join(Environment.NewLine,
        AppServices.ShopName,
        $"Invoice No: {_order.OrderNumber}",
        $"Customer: {lblCustomerInfo.Text}",
        $"Service: {lblServiceInfo.Text}",
        $"Weight: {lblWeightInfo.Text}",
        $"Total: {lblTotalAmount.Text}",
        $"Payment: {lblPaymentStatus.Text}",
        $"Pickup: {lblPickupDate.Text}",
        $"Order Date: {lblCreatedDate.Text}");

    private static void CopyText(string text)
    {
        try { Clipboard.SetText(text); }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not copy: {ex.Message}", "Copy Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private static List<LoadPrice>? LoadPrices()
    {
        try { return AppServices.LoadPricing.GetAll().ToList(); }
        catch { return null; }
    }
}
