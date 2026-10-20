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

        this.Text = $"Order Details – {_order.OrderNumber}";
        lblOrderNumber.Text = $"🧾 {_order.OrderNumber}";
        lblCustomerInfo.Text = $"{_customer?.FullName ?? _order.CustomerName} ({_customer?.Phone ?? _order.CustomerPhone})";
        lblServiceInfo.Text = _order.ServiceName ?? "Standard Laundry";
        lblWeightInfo.Text = $"{_order.WeightKg:F2} kg";
        lblTotalAmount.Text = $"₱{_order.TotalAmount:N2}";

        if (_order.PaymentRecorded)
        {
            lblPaymentStatus.Text = $"Paid (₱{_order.AmountPaid:N2})";
            lblPaymentStatus.ForeColor = UIThemeHelper.Sand;
        }
        else
        {
            lblPaymentStatus.Text = "Unpaid";
            lblPaymentStatus.ForeColor = UIThemeHelper.Indigo;
        }

        lblPickupDate.Text = _order.PickupDate?.ToString("MMMM dd, yyyy") ?? "—";
        lblCreatedDate.Text = _order.CreatedAt.ToString("MMM dd, yyyy hh:mm tt");
        lblCancelReason.Text = string.IsNullOrWhiteSpace(_order.CancelReason) ? "—" : _order.CancelReason;

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
            btnAdvanceStatus.Text = "🌀 Mark as Drying";
            btnAdvanceStatus.BackColor = UIThemeHelper.Slate;
        }
        else if (_order.Status == "Drying")
        {
            btnAdvanceStatus.Text = "✨ Ready for Pickup";
            btnAdvanceStatus.BackColor = UIThemeHelper.Slate;
        }

        btnClaimOrder.Visible = _order.Status == "Ready for Pickup" || (_order.Status is "Washing" or "Drying" && !_order.PaymentRecorded);
        btnCancelOrder.Visible = _order.Status != "Claimed" && _order.Status != "Cancelled";
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

    private void btnAdvanceStatus_Click(object? sender, EventArgs e)
    {
        string nextStatus = _order.Status switch
        {
            "Washing" => "Drying",
            "Drying" => "Ready for Pickup",
            _ => _order.Status
        };

        if (nextStatus != _order.Status)
        {
            try
            {
                AppServices.Orders.UpdateStatus(_order.OrderId, nextStatus, changedBy: SessionManager.CurrentUser?.UserId);
                RefreshOrderData();
                MessageBox.Show($"Order status moved to '{nextStatus}'.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update order status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnClaimOrder_Click(object? sender, EventArgs e)
    {
        using var dlg = new Form
        {
            Text = $"Claim Order – {_order.OrderNumber}",
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
            Text = $"Total Due: ₱{_order.TotalAmount:N2}\nEnter Amount Tendered / Paid:",
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
            Text = "Change: ₱0.00",
            Location = new Point(30, 115),
            Size = new Size(300, 25),
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = UIThemeHelper.Success
        };

        txtAmount.TextChanged += (_, _) =>
        {
            if (decimal.TryParse(txtAmount.Text, out var paid))
            {
                var change = paid - _order.TotalAmount;
                lblChange.Text = change >= 0 ? $"Change: ₱{change:N2}" : $"Short by: ₱{Math.Abs(change):N2}";
                lblChange.ForeColor = change >= 0 ? UIThemeHelper.Success : UIThemeHelper.Danger;
            }
        };

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
            if (decimal.TryParse(txtAmount.Text, out var paid) && paid >= _order.TotalAmount)
            {
                try
                {
                    AppServices.Orders.ClaimOrderWithPayment(_order.OrderId, paid, changedBy: SessionManager.CurrentUser?.UserId, notes: $"Paid: ₱{paid:N2}");
                    dlg.DialogResult = DialogResult.OK;
                    dlg.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to record payment and claim order: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Payment amount must be greater than or equal to total amount.", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        };

        dlg.Controls.AddRange(new Control[] { lblPrompt, txtAmount, lblChange, btnConfirm });
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            RefreshOrderData();
            MessageBox.Show("Order has been successfully marked as CLAIMED and payment recorded!", "Order Claimed", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please provide a reason for cancellation.", "Reason Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            using var printDoc = new PrintDocument();
            printDoc.PrintPage += (s, ev) =>
            {
                using var fontTitle = new Font("Segoe UI", 16, FontStyle.Bold);
                using var fontSub = new Font("Segoe UI", 10);
                ev.Graphics?.DrawString(AppServices.ShopName, fontTitle, Brushes.Black, 60, 40);
                ev.Graphics?.DrawString($"Order E-Ticket: {_order.OrderNumber}", fontSub, Brushes.Black, 60, 75);
                ev.Graphics?.DrawString($"Customer: {_order.CustomerName}", fontSub, Brushes.Black, 60, 95);
                ev.Graphics?.DrawString($"Service: {_order.ServiceName} | {_order.WeightKg} kg", fontSub, Brushes.Black, 60, 115);
                ev.Graphics?.DrawString($"Amount Due: ₱{_order.TotalAmount:N2}", fontSub, Brushes.Black, 60, 135);
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
}
