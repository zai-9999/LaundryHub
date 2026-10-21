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
        pnlLeftCard.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlLeftCard, UIThemeHelper.ContentCardRadius);
        pnlRightCard.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlRightCard, UIThemeHelper.ContentCardRadius);
        pnlHeader.BackColor = UIThemeHelper.Navy;
        lblOrderNumber.BackColor = UIThemeHelper.Navy;
        pnlContainer.BackColor = UIThemeHelper.Surface;
        pnlRightWrapper.BackColor = UIThemeHelper.Surface;
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
        lblOrderNumber.Text = $" {_order.OrderNumber}";
        lblCustomerInfo.Text = $"{_customer?.FullName ?? _order.CustomerName} ({_customer?.Phone ?? _order.CustomerPhone})";
        lblServiceInfo.Text = _order.ServiceName ?? "Standard Laundry";
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

        // QR Code
        try
        {
            var oldImg = picQrCode.Image;
            picQrCode.Image = QrCodeHelper.GenerateImage(_order.OrderNumber);
            oldImg?.Dispose();
        }
        catch { }

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
        btnCancelOrder.Visible = _order.Status != "Claimed" && _order.Status != "Cancelled";
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
                        UiMessages.Show(
                            "Order status moved to 'Ready for Pickup', but this customer has no email address registered.",
                            "Status Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else if (await EmailHelper.SendReadyForPickupAsync(_order, _customer))
                    {
                        UiMessages.Show(
                            $"Order status moved to 'Ready for Pickup'. A notification was sent to {_customer.Email}.",
                            "Status Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        UiMessages.Show(
                            "Order status moved to 'Ready for Pickup', but the email notification could not be sent.",
                            "Status Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    UiMessages.Show($"Order status moved to '{nextStatus}'.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                UiMessages.Show($"Failed to update order status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnEditWeight_Click(object? sender, EventArgs e)
    {
        var service = AppServices.ServiceTypes.GetById(_order.ServiceId);
        if (service == null)
        {
            UiMessages.Show("The service pricing could not be found.", "Unable to Update Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dlg = new Form
        {
            Text = $"Confirm Actual Weight  {_order.OrderNumber}",
            Size = new Size(410, 300),
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
            Location = new Point(30, 100),
            Size = new Size(340, 45),
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = Color.FromArgb(52, 211, 153)
        };
        var btnConfirm = new Button
        {
            Text = " Save Confirmed Weight",
            Location = new Point(30, 165),
            Size = new Size(340, 38),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };
        btnConfirm.FlatAppearance.BorderSize = 0;

        decimal? GetWeight()
        {
            return decimal.TryParse(txtWeight.Text, out var weight) && weight > 0 ? weight : null;
        }

        void UpdatePreview()
        {
            var weight = GetWeight();
            lblTotal.Text = weight.HasValue
                ? $"New total: {service.ComputePrice(weight.Value):N2} (minimum {service.MinimumWeight:N2} kg)"
                : "Enter a Valid Weight.";
            lblTotal.ForeColor = weight.HasValue ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
        }

        txtWeight.TextChanged += (_, _) => UpdatePreview();
        btnConfirm.Click += (_, _) =>
        {
            var weight = GetWeight();
            if (!weight.HasValue)
            {
                UiMessages.Show("Please enter a valid weight greater than zero.", "Invalid Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var total = service.ComputePrice(weight.Value);
            if (!AppServices.Orders.UpdateConfirmedWeight(_order.OrderId, weight.Value, total))
            {
                UiMessages.Show("The weight was not updated. The order may already be paid, claimed, or cancelled.",
                    "Unable to Update Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dlg.DialogResult = DialogResult.OK;
            dlg.Close();
        };

        dlg.Controls.AddRange(new Control[] { lblPrompt, txtWeight, lblTotal, btnConfirm });
        UpdatePreview();

        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            RefreshOrderData();
            UiMessages.Show("The confirmed weight and order total were updated.", "Weight Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                UiMessages.Show(priceErr, "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                UiMessages.Show($"Failed to record payment and claim order: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        dlg.Controls.AddRange(new Control[] { lblPrompt, txtAmount, lblChange, btnConfirm });
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            RefreshOrderData();
            UiMessages.Show("Order has been successfully marked as CLAIMED and payment recorded!", "Order Claimed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnCancelOrder_Click(object? sender, EventArgs e)
    {
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
                UiMessages.Show("Please provide a valid cancellation reason (at least 3 characters).", "Reason Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                UiMessages.Show($"Failed to cancel order: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        dlg.Controls.AddRange(new Control[] { lblPrompt, txtReason, btnConfirm });
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            RefreshOrderData();
            UiMessages.Show("Order cancelled.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnPrintQr_Click(object? sender, EventArgs e)
    {
        try
        {
            using var printDoc = new PrintDocument();
            printDoc.PrintPage += (s, ev) =>
            {
                using var fontTitle = new Font("Segoe UI", 16, FontStyle.Bold);
                using var fontSub = new Font("Segoe UI", 10);
                ev.Graphics?.DrawString(AppServices.ShopName, fontTitle, Brushes.Black, 60, 40);
                ev.Graphics?.DrawString($"Order E-Ticket: {_order.OrderNumber}", fontSub, Brushes.Black, 60, 75);
                ev.Graphics?.DrawString($"Customer: {_order.CustomerName}", fontSub, Brushes.Black, 60, 95);
                ev.Graphics?.DrawString($"Service: {_order.ServiceName} | {_order.WeightKg} kg", fontSub, Brushes.Black, 60, 115);
                ev.Graphics?.DrawString($"Amount Due: {_order.TotalAmount:N2}", fontSub, Brushes.Black, 60, 135);
                if (picQrCode.Image != null)
                {
                    ev.Graphics?.DrawImage(picQrCode.Image, 60, 165, 180, 180);
                }
            };

            using var preview = new PrintPreviewDialog { Document = printDoc };
            preview.ShowDialog(this);
        }
        catch (Exception ex)
        {
            UiMessages.Show($"Print failed: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnResendEmail_Click(object? sender, EventArgs e)
    {
        if (_customer == null || string.IsNullOrWhiteSpace(_customer.Email))
        {
            UiMessages.Show("This customer does not have an email address registered.", "No Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        EmailHelper.SendReceiptAsync(_order, _customer);
        UiMessages.Show($"A digital receipt has been sent to {_customer.Email}.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
