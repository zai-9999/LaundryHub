using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Drawing.Printing;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmOrderDetail : Form
{
    private Order _order;
    private CustomerModel? _customer;

    public FrmOrderDetail(Order order)
    {
        _order = order;
        _customer = AppServices.Customers.GetById(order.CustomerId);
        InitializeForm();
        RefreshOrderData();
    }

    // ─── UI Controls ─────────────────────────────────────────────────────────

    private Label lblOrderNumber = null!;
    private Label lblStatusBadge = null!;
    private Label lblCustomerInfo = null!;
    private Label lblServiceInfo = null!;
    private Label lblWeightInfo = null!;
    private Label lblTotalAmount = null!;
    private Label lblPaymentStatus = null!;
    private Label lblPickupDate = null!;
    private Label lblCreatedDate = null!;
    private Label lblCancelReason = null!;
    private PictureBox picQrCode = null!;
    private Button btnAdvanceStatus = null!;
    private Button btnClaimOrder = null!;
    private Button btnCancelOrder = null!;
    private Button btnResendEmail = null!;
    private Button btnPrintQr = null!;

    private void InitializeForm()
    {
        this.Text = $"Order Details – {_order.OrderNumber}";
        this.Size = new Size(820, 620);
        this.StartPosition = FormStartPosition.CenterParent;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Top Header
        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24, 0, 24, 0)
        };

        lblOrderNumber = new Label
        {
            Text = $"🧾 {_order.OrderNumber}",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            AutoSize = true,
            Location = new Point(24, 18)
        };

        lblStatusBadge = new Label
        {
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            AutoSize = false,
            Size = new Size(160, 32),
            Location = new Point(480, 19),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var btnClose = new Button
        {
            Text = "✕ Close",
            Size = new Size(80, 32),
            Location = new Point(690, 19),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            Cursor = Cursors.Hand
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Click += (_, _) => this.Close();

        header.Controls.AddRange(new Control[] { lblOrderNumber, lblStatusBadge, btnClose });
        this.Controls.Add(header);

        // Main Container
        var container = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };
        this.Controls.Add(container);

        // Left Details Card
        var leftCard = new Panel
        {
            Dock = DockStyle.Left,
            Width = 470,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(20)
        };

        var lblDetailsTitle = new Label
        {
            Text = "Order & Customer Details",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Top,
            Height = 30
        };
        leftCard.Controls.Add(lblDetailsTitle);

        var detailsTable = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 8,
            Padding = new Padding(0, 10, 0, 0)
        };
        detailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
        detailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        AddDetailRow(detailsTable, 0, "Customer:", out lblCustomerInfo);
        AddDetailRow(detailsTable, 1, "Service Type:", out lblServiceInfo);
        AddDetailRow(detailsTable, 2, "Weight:", out lblWeightInfo);
        AddDetailRow(detailsTable, 3, "Total Amount:", out lblTotalAmount);
        AddDetailRow(detailsTable, 4, "Payment:", out lblPaymentStatus);
        AddDetailRow(detailsTable, 5, "Target Pickup:", out lblPickupDate);
        AddDetailRow(detailsTable, 6, "Order Date:", out lblCreatedDate);
        AddDetailRow(detailsTable, 7, "Notes/Reason:", out lblCancelReason);

        leftCard.Controls.Add(detailsTable);

        // Bottom Actions in Left Card
        var actionPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 90,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(0, 10, 0, 0)
        };

        btnAdvanceStatus = new Button
        {
            Size = new Size(135, 36),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnAdvanceStatus.FlatAppearance.BorderSize = 0;
        btnAdvanceStatus.Click += btnAdvanceStatus_Click;

        btnClaimOrder = new Button
        {
            Text = "💰 Claim / Pay",
            Size = new Size(135, 36),
            BackColor = Color.FromArgb(16, 185, 129),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnClaimOrder.FlatAppearance.BorderSize = 0;
        btnClaimOrder.Click += btnClaimOrder_Click;

        btnCancelOrder = new Button
        {
            Text = "✕ Cancel Order",
            Size = new Size(135, 36),
            BackColor = Color.FromArgb(220, 38, 38),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9),
            Cursor = Cursors.Hand
        };
        btnCancelOrder.FlatAppearance.BorderSize = 0;
        btnCancelOrder.Click += btnCancelOrder_Click;

        actionPanel.Controls.AddRange(new Control[] { btnAdvanceStatus, btnClaimOrder, btnCancelOrder });
        leftCard.Controls.Add(actionPanel);
        container.Controls.Add(leftCard);

        // Right Card (QR & Communication)
        var rightCard = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(30, 41, 59),
            Margin = new Padding(16, 0, 0, 0),
            Padding = new Padding(20)
        };
        var rightWrapper = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16, 0, 0, 0)
        };
        rightWrapper.Controls.Add(rightCard);

        var lblQrTitle = new Label
        {
            Text = "QR Code E-Ticket",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter
        };
        rightCard.Controls.Add(lblQrTitle);

        picQrCode = new PictureBox
        {
            Size = new Size(190, 190),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Location = new Point(45, 60)
        };
        rightCard.Controls.Add(picQrCode);

        btnPrintQr = new Button
        {
            Text = "🖨 Print QR Ticket",
            Size = new Size(220, 36),
            Location = new Point(30, 270),
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnPrintQr.FlatAppearance.BorderSize = 0;
        btnPrintQr.Click += btnPrintQr_Click;
        rightCard.Controls.Add(btnPrintQr);

        btnResendEmail = new Button
        {
            Text = "✉ Resend Email Receipt",
            Size = new Size(220, 36),
            Location = new Point(30, 320),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnResendEmail.FlatAppearance.BorderSize = 0;
        btnResendEmail.Click += btnResendEmail_Click;
        rightCard.Controls.Add(btnResendEmail);

        container.Controls.Add(rightWrapper);
    }

    private static void AddDetailRow(TableLayoutPanel table, int row, string header, out Label valueLabel)
    {
        var lblHeader = new Label
        {
            Text = header,
            ForeColor = Color.FromArgb(148, 163, 184),
            Font = new Font("Segoe UI", 9),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };
        valueLabel = new Label
        {
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };
        table.Controls.Add(lblHeader, 0, row);
        table.Controls.Add(valueLabel, 1, row);
    }

    // ─── Data Binding & Status Updates ───────────────────────────────────────

    private void RefreshOrderData()
    {
        var updated = AppServices.Orders.GetById(_order.OrderId);
        if (updated != null) _order = updated;
        _customer = AppServices.Customers.GetById(_order.CustomerId);

        lblCustomerInfo.Text = $"{_customer?.FullName ?? _order.CustomerName} ({_customer?.Phone ?? _order.CustomerPhone})";
        lblServiceInfo.Text = _order.ServiceName ?? "Standard Laundry";
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
        btnAdvanceStatus.Visible = _order.Status is "Washing" or "Drying";
        if (_order.Status == "Washing")
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
    }

    private void UpdateStatusBadge()
    {
        lblStatusBadge.Text = _order.Status.ToUpper();
        switch (_order.Status)
        {
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

    private void btnAdvanceStatus_Click(object? sender, EventArgs e)
    {
        string nextStatus = _order.Status switch
        {
            "Washing" => "Drying",
            "Drying"  => "Ready for Pickup",
            _         => _order.Status
        };

        if (nextStatus != _order.Status)
        {
            AppServices.Orders.UpdateStatus(_order.OrderId, nextStatus);
            RefreshOrderData();
            MessageBox.Show($"Order status moved to '{nextStatus}'.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        txtAmount.TextChanged += (_, _) =>
        {
            if (decimal.TryParse(txtAmount.Text, out var paid))
            {
                var change = paid - _order.TotalAmount;
                lblChange.Text = change >= 0 ? $"Change: ₱{change:N2}" : $"Short by: ₱{Math.Abs(change):N2}";
                lblChange.ForeColor = change >= 0 ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
            }
        };

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
