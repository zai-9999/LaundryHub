using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Staff;

/// <summary>
/// Pop-up for staff to review a customer's cancellation request and decide whether
/// the reason is good enough. DialogResult.OK means the request was approved or declined
/// (the caller should refresh); Cancel means the staff closed it without deciding.
/// </summary>
public sealed class FrmCancelRequest : Form
{
    private readonly Order _order;

    public FrmCancelRequest(Order order)
    {
        _order = order;

        Text = "Cancellation Request";
        ClientSize = new Size(480, 470);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        BackColor = UIThemeHelper.SandLight;
        ForeColor = UIThemeHelper.Navy;
        Font = new Font("Segoe UI", 9.5F);

        BuildLayout();
    }

    private void BuildLayout()
    {
        // ── Header band ──
        var header = new Panel { Dock = DockStyle.Top, Height = 72, BackColor = UIThemeHelper.Navy };
        header.Paint += (_, e) =>
            CancelRequestIcon.Draw(e.Graphics, new Rectangle(20, 18, 36, 36), UIThemeHelper.Sand, 2f);
        var lblTitle = new Label
        {
            Text = "Cancellation Request",
            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
            ForeColor = UIThemeHelper.SandLight,
            AutoSize = false,
            Location = new Point(68, 14),
            Size = new Size(390, 26),
            BackColor = Color.Transparent
        };
        var lblOrderNo = new Label
        {
            Text = $"Order {_order.OrderNumber}",
            Font = new Font("Segoe UI", 9F),
            ForeColor = UIThemeHelper.Tint,
            AutoSize = false,
            Location = new Point(69, 40),
            Size = new Size(390, 20),
            BackColor = Color.Transparent
        };
        header.Controls.Add(lblTitle);
        header.Controls.Add(lblOrderNo);

        // ── Footer with actions ──
        var footer = new Panel { Dock = DockStyle.Bottom, Height = 70, BackColor = UIThemeHelper.SandLight, Padding = new Padding(20, 15, 20, 15) };

        var btnApprove = MakeButton("Approve & Cancel Order", UIThemeHelper.Danger, Color.White, null);
        btnApprove.Dock = DockStyle.Right;
        btnApprove.Width = 220;
        btnApprove.Click += BtnApprove_Click;

        var spacer = new Panel { Dock = DockStyle.Right, Width = 10, BackColor = Color.Transparent };

        var btnDecline = MakeButton("Decline Request", UIThemeHelper.CardWhite, UIThemeHelper.Indigo, UIThemeHelper.BorderSoft);
        btnDecline.Dock = DockStyle.Fill;
        btnDecline.Click += BtnDecline_Click;

        // Dock order: Fill added first so Right-docked controls claim space first.
        footer.Controls.Add(btnDecline);
        footer.Controls.Add(spacer);
        footer.Controls.Add(btnApprove);

        // ── Body ──
        var body = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20, 16, 20, 4), BackColor = UIThemeHelper.SandLight };

        var details = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 2,
            BackColor = Color.Transparent
        };
        details.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
        details.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        AddRow(details, "Customer", _order.CustomerName ?? "—");
        AddRow(details, "Service", $"{_order.ServiceName} — {_order.LaundryCategory}");
        AddRow(details, "Weight / Total", $"{_order.WeightKg} kg  •  ₱{_order.TotalAmount:N2}");
        AddRow(details, "Order status", _order.Status);
        AddRow(details, "Requested", _order.CancelRequestedAt?.ToString("MMM dd, yyyy  hh:mm tt") ?? "—");

        var lblReasonCaption = new Label
        {
            Text = "Customer's reason",
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Indigo,
            Dock = DockStyle.Top,
            Height = 28,
            TextAlign = ContentAlignment.BottomLeft
        };

        var txtReason = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.White,
            ForeColor = UIThemeHelper.Navy,
            Font = new Font("Segoe UI", 10F),
            TabStop = false,
            Text = string.IsNullOrWhiteSpace(_order.CancelRequestReason)
                ? "(No reason provided)"
                : _order.CancelRequestReason
        };

        var reasonHost = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 4, 0, 6) };
        reasonHost.Controls.Add(txtReason);

        var lblHint = new Label
        {
            Text = "Approving cancels the order. Declining keeps it active and the customer is told the request was declined.",
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = UIThemeHelper.TextMuted,
            Dock = DockStyle.Bottom,
            Height = 36,
            TextAlign = ContentAlignment.MiddleLeft
        };

        // Add Fill first, then edge-docked controls (WinForms docks the last-added first).
        body.Controls.Add(reasonHost);
        body.Controls.Add(lblHint);
        body.Controls.Add(lblReasonCaption);
        body.Controls.Add(details);

        Controls.Add(body);
        Controls.Add(footer);
        Controls.Add(header);

        AcceptButton = null;
        CancelButton = null;
    }

    private static void AddRow(TableLayoutPanel table, string caption, string value)
    {
        int row = table.RowCount++;
        table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
        table.Controls.Add(new Label
        {
            Text = caption,
            Font = new Font("Segoe UI", 9F),
            ForeColor = UIThemeHelper.TextMuted,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        }, 0, row);
        table.Controls.Add(new Label
        {
            Text = value,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Dock = DockStyle.Fill,
            AutoEllipsis = true,
            TextAlign = ContentAlignment.MiddleLeft
        }, 1, row);
    }

    private static Button MakeButton(string text, Color back, Color fore, Color? border)
    {
        var b = new Button
        {
            Text = text,
            BackColor = back,
            ForeColor = fore,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            Cursor = Cursors.Hand,
            UseVisualStyleBackColor = false
        };
        b.FlatAppearance.BorderSize = border.HasValue ? 1 : 0;
        if (border.HasValue) b.FlatAppearance.BorderColor = border.Value;
        return b;
    }

    private void BtnApprove_Click(object? sender, EventArgs e)
    {
        var confirm = MessageBox.Show(this,
            $"Approve the request and cancel order {_order.OrderNumber}?\n\nThis cannot be undone.",
            "Approve Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (confirm != DialogResult.Yes) return;

        try
        {
            if (!AppServices.Orders.ApproveCancellationRequest(_order.OrderId, SessionManager.CurrentUser?.UserId))
            {
                MessageBox.Show(this,
                    "This request can no longer be approved. It may have already been handled, or the order is already claimed or cancelled.",
                    "Cannot Approve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; // state changed; let the list refresh
                return;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Failed to approve the request: {ex.Message}", "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
    }

    private void BtnDecline_Click(object? sender, EventArgs e)
    {
        var confirm = MessageBox.Show(this,
            $"Decline the cancellation request for order {_order.OrderNumber}?\n\nThe order stays active.",
            "Decline Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (confirm != DialogResult.Yes) return;

        try
        {
            if (!AppServices.Orders.RejectCancellationRequest(_order.OrderId, SessionManager.CurrentUser?.UserId))
            {
                MessageBox.Show(this, "This request was already handled.", "Cannot Decline",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Failed to decline the request: {ex.Message}", "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
    }
}
