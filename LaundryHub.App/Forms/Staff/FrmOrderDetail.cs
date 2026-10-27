using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Drawing.Printing;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmOrderDetail : Form
{
    private Order _order;
    private CustomerModel? _customer;

    public FrmOrderDetail() : this(new Order { OrderNumber = "LH-DEMO-001", Status = "Booked", TotalAmount = 260.00m, WeightKg = 4.0m })
    {
    }

    public FrmOrderDetail(Order order)
    {
        _order = order;
        InitializeComponent();
        RefreshOrderData();
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
        lblServiceInfo.Text = $"{_order.ServiceName ?? "Standard Laundry"} — {_order.LaundryCategory}";
        lblWeightInfo.Text = $"{_order.WeightKg:F2} kg";
        lblTotalAmount.Text = $"₱{_order.TotalAmount:N2}";

        if (_order.PaymentRecorded)
        {
            lblPaymentStatus.Text = $"✔ Paid (₱{_order.AmountPaid:N2})";
            lblPaymentStatus.ForeColor = Color.FromArgb(52, 211, 153);
        }
        else
        {
            lblPaymentStatus.Text = "⏳ Unpaid";
            lblPaymentStatus.ForeColor = Color.FromArgb(248, 113, 113);
        }

        lblPickupDate.Text = _order.PickupDate?.ToString("MMMM dd, yyyy") ?? "—";
        lblCreatedDate.Text = _order.CreatedAt.ToString("MMM dd, yyyy hh:mm tt");
        lblCancelReason.Text = string.IsNullOrWhiteSpace(_order.CancelReason) ? "—" : _order.CancelReason;

        // Status badge styling
        UpdateStatusBadge();

        // QR Code
        try
        {
            picQrCode.Image = QrCodeHelper.GenerateImage(_order.OrderNumber);
        }
        catch { }

        // Update button states
        btnAdvanceStatus.Visible = _order.Status is "Booked" or "Washing" or "Drying";
        if (_order.Status == "Booked")
        {
            btnAdvanceStatus.Text = "🧺 Start Washing";
            btnAdvanceStatus.BackColor = Color.FromArgb(14, 165, 233);
        }
        else if (_order.Status == "Washing")
        {
            btnAdvanceStatus.Text = "🌀 Mark as Drying";
            btnAdvanceStatus.BackColor = Color.FromArgb(14, 165, 233);
        }
        else if (_order.Status == "Drying")
        {
            btnAdvanceStatus.Text = "✨ Ready for Pickup";
            btnAdvanceStatus.BackColor = Color.FromArgb(59, 130, 246);
        }

        btnClaimOrder.Visible = _order.Status == "Ready for Pickup" || (_order.Status is "Washing" or "Drying" && !_order.PaymentRecorded);
        btnCancelOrder.Visible = _order.Status != "Claimed" && _order.Status != "Cancelled";
        btnEditWeight.Visible = _order.Status is "Washing" or "Drying" or "Ready for Pickup" && !_order.PaymentRecorded;
    }

    private void UpdateStatusBadge()
    {
        lblStatusBadge.Text = _order.Status.ToUpper();
        switch (_order.Status)
        {
            case "Booked":
                lblStatusBadge.BackColor = Color.FromArgb(30, 41, 59);
                lblStatusBadge.ForeColor = Color.FromArgb(203, 213, 225);
                break;
            case "Washing":
                lblStatusBadge.BackColor = Color.FromArgb(30, 58, 138);
                lblStatusBadge.ForeColor = Color.FromArgb(147, 197, 253);
                break;
            case "Drying":
                lblStatusBadge.BackColor = Color.FromArgb(12, 74, 96);
                lblStatusBadge.ForeColor = Color.FromArgb(125, 211, 252);
                break;
            case "Ready for Pickup":
                lblStatusBadge.BackColor = Color.FromArgb(120, 53, 15);
                lblStatusBadge.ForeColor = Color.FromArgb(253, 224, 71);
                break;
            case "Claimed":
                lblStatusBadge.BackColor = Color.FromArgb(6, 78, 59);
                lblStatusBadge.ForeColor = Color.FromArgb(110, 231, 183);
                break;
            case "Cancelled":
                lblStatusBadge.BackColor = Color.FromArgb(127, 29, 29);
                lblStatusBadge.ForeColor = Color.FromArgb(252, 165, 165);
                break;
        }
    }

    private async void btnAdvanceStatus_Click(object? sender, EventArgs e)
    {
        if (_order.Status == "Booked")
        {
            if (AppServices.Orders.ConfirmDropOff(_order.OrderId))
            {
                RefreshOrderData();
                MessageBox.Show("Customer drop-off confirmed. Order status is now 'Washing'.", "Drop-off Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return;
        }

        string nextStatus = _order.Status switch
        {
            "Washing" => "Drying",
            "Drying"  => "Ready for Pickup",
            _ => _order.Status
        };

        if (nextStatus != _order.Status)
        {
            AppServices.Orders.UpdateStatus(_order.OrderId, nextStatus);
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
    }

    private void btnEditWeight_Click(object? sender, EventArgs e)
    {
        var loadPrices = AppServices.LoadPricing.GetAll().ToList();

        using var dlg = new Form
        {
            Text = $"Confirm Actual Weight – {_order.OrderNumber}",
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
            Text = "✔ Save Confirmed Weight",
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
                ? $"New total: ₱{quote.Total:N2}\n{quote.GetBreakdown()}"
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
            Text = $"Claim Order – {_order.OrderNumber}",
            Size = new Size(380, 280),
            StartPosition = FormStartPosition.CenterParent,
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblPrompt = new Label
        {
            Text = $"Total Due: ₱{_order.TotalAmount:N2}\nEnter Amount Tendered / Paid:",
            Location = new Point(30, 20),
            Size = new Size(310, 40),
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };
        var txtAmount = new TextBox
        {
            Text = _order.TotalAmount.ToString("F2"),
            Location = new Point(30, 70),
            Size = new Size(300, 32),
            Font = new Font("Segoe UI", 12),
            BackColor = Color.FromArgb(30, 41, 59),
            ForeColor = Color.White
        };
        var lblChange = new Label
        {
            Text = "Change: ₱0.00",
            Location = new Point(30, 115),
            Size = new Size(300, 25),
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = Color.FromArgb(52, 211, 153)
        };

        void UpdateChange()
        {
            if (decimal.TryParse(txtAmount.Text, out var paid))
            {
                var change = paid - _order.TotalAmount;
                lblChange.Text = change >= 0 ? $"Change: ₱{change:N2}" : $"Short by: ₱{Math.Abs(change):N2}";
                lblChange.ForeColor = change >= 0 ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
            }
            else
            {
                lblChange.Text = "Enter a valid payment amount";
                lblChange.ForeColor = Color.FromArgb(148, 163, 184);
            }
        }

        txtAmount.TextChanged += (_, _) => UpdateChange();
        UpdateChange();

        var btnConfirm = new Button
        {
            Text = "✔ Confirm Payment & Claim",
            Location = new Point(30, 160),
            Size = new Size(300, 38),
            BackColor = Color.FromArgb(16, 185, 129),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };
        btnConfirm.FlatAppearance.BorderSize = 0;
        btnConfirm.Click += (_, _) =>
        {
            if (decimal.TryParse(txtAmount.Text, out var paid) && paid >= _order.TotalAmount)
            {
                AppServices.Orders.RecordPayment(_order.OrderId, paid);
                AppServices.Orders.UpdateStatus(_order.OrderId, "Claimed");
                dlg.DialogResult = DialogResult.OK;
                dlg.Close();
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
            Size = new Size(400, 230),
            StartPosition = FormStartPosition.CenterParent,
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblPrompt = new Label
        {
            Text = "Reason for cancellation *:",
            Location = new Point(30, 20),
            Size = new Size(330, 25),
            Font = new Font("Segoe UI", 9.5f)
        };
        var txtReason = new TextBox
        {
            Location = new Point(30, 50),
            Size = new Size(330, 50),
            Multiline = true,
            Font = new Font("Segoe UI", 9.5f),
            BackColor = Color.FromArgb(30, 41, 59),
            ForeColor = Color.White
        };
        var btnConfirm = new Button
        {
            Text = "Confirm Cancel",
            Location = new Point(30, 120),
            Size = new Size(330, 36),
            BackColor = Color.FromArgb(220, 38, 38),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnConfirm.FlatAppearance.BorderSize = 0;
        btnConfirm.Click += (_, _) =>
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please provide a reason for cancellation.", "Reason Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AppServices.Orders.UpdateStatus(_order.OrderId, "Cancelled", txtReason.Text.Trim());
            dlg.DialogResult = DialogResult.OK;
            dlg.Close();
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
                ev.Graphics?.DrawString($"Service: {_order.ServiceName} — {_order.LaundryCategory} | {_order.WeightKg} kg", fontSub, Brushes.Black, 60, 115);
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
