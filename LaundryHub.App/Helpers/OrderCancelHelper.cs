using System;
using System.Drawing;
using System.Windows.Forms;
using LaundryHub.App.Helpers;

namespace LaundryHub.App.Helpers;

/// <summary>One cancellation dialog (with a required reason) used by staff and admin screens.</summary>
public static class OrderCancelHelper
{
    /// <summary>Asks for a reason and cancels the order. Returns true if the order was cancelled.</summary>
    public static bool Prompt(IWin32Window owner, int orderId, string orderNumber, string status)
    {
        if (status is "Claimed" or "Cancelled")
        {
            MessageBox.Show($"Order {orderNumber} is already {status.ToLower()} and can't be cancelled.",
                "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        using var dlg = new Form
        {
            Text = "Cancel Order",
            ClientSize = new Size(408, 340),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            ShowInTaskbar = false,
            BackColor = Color.White,
            ForeColor = UIThemeHelper.Navy
        };

        var flow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(24, 20, 24, 12),
            BackColor = Color.White
        };

        var lblTitle = new Label
        {
            Text = $"Cancel order {orderNumber}?",
            AutoSize = true,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Margin = new Padding(0, 0, 0, 10)
        };
        var lblPrompt = new Label
        {
            Text = "Reason for cancellation *",
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Indigo,
            Margin = new Padding(0, 0, 0, 4)
        };
        var txtReason = new TextBox
        {
            Multiline = true,
            MaxLength = 250,
            Size = new Size(360, 84),
            Font = new Font("Segoe UI", 10F),
            BackColor = UIThemeHelper.Surface,
            ForeColor = UIThemeHelper.Navy,
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(0, 0, 0, 4)
        };
        var lblError = new Label
        {
            Size = new Size(360, 36),
            ForeColor = UIThemeHelper.Danger,
            Font = new Font("Segoe UI", 9F),
            Margin = new Padding(0, 0, 0, 4),
            Visible = false
        };
        var btnConfirm = new Button
        {
            Text = "Confirm Cancellation",
            Size = new Size(360, 40),
            BackColor = UIThemeHelper.Danger,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            Cursor = Cursors.Hand,
            Margin = new Padding(0, 0, 0, 8)
        };
        btnConfirm.FlatAppearance.BorderSize = 0;
        var btnKeep = new Button
        {
            Text = "Keep Order",
            Size = new Size(360, 36),
            BackColor = Color.FromArgb(234, 224, 207),
            ForeColor = UIThemeHelper.Indigo,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F),
            Cursor = Cursors.Hand,
            DialogResult = DialogResult.Cancel,
            Margin = new Padding(0)
        };
        btnKeep.FlatAppearance.BorderColor = UIThemeHelper.Slate;
        dlg.CancelButton = btnKeep;

        bool cancelled = false;
        btnConfirm.Click += (_, _) =>
        {
            var reason = txtReason.Text.Trim();
            if (reason.Length < 3)
            {
                lblError.Text = "Please enter a reason (at least 3 characters).";
                lblError.Visible = true;
                txtReason.Focus();
                return;
            }

            try
            {
                AppServices.Orders.UpdateStatus(orderId, "Cancelled", reason,
                    changedBy: SessionManager.CurrentUser?.UserId);
                cancelled = true;
                dlg.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                lblError.Text = $"Failed to cancel: {ex.Message}";
                lblError.Visible = true;
            }
        };

        flow.Controls.AddRange(new Control[] { lblTitle, lblPrompt, txtReason, lblError, btnConfirm, btnKeep });
        dlg.Controls.Add(flow);
        UIThemeHelper.ApplyTheme(dlg);
        dlg.ShowDialog(owner);

        if (cancelled)
            MessageBox.Show($"Order {orderNumber} has been cancelled.", "Order Cancelled",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        return cancelled;
    }
}
