using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Threading.Tasks;

namespace LaundryHub.App.Forms.Guest;

public partial class FrmGuestLookup : Form
{
    private Panel[] progressSteps = new Panel[4];
    private Label[] progressLabels = new Label[4];
    private bool isLoading = false;

    public FrmGuestLookup()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;
        InitProgressArrays();
        UIThemeHelper.StyleAuthForm(this, pnlCard, btnLookup, btnBack);
        pnlCard.Paint += (_, e) => UIThemeHelper.PaintRoundedSolidCard(pnlCard, e, Color.White, UIThemeHelper.LoginCardRadius);

        InputValidator.RestrictToDigitsOnly(txtPhoneLast4, 4);
        txtOrderNumber.TextChanged += (_, _) => lblError.Visible = false;
        txtPhoneLast4.TextChanged += (_, _) => lblError.Visible = false;

        this.FormClosing += (_, _) => isLoading = false;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void InitProgressArrays()
    {
        progressSteps[0] = pnlStep0;
        progressSteps[1] = pnlStep1;
        progressSteps[2] = pnlStep2;
        progressSteps[3] = pnlStep3;

        progressLabels[0] = lblStep0;
        progressLabels[1] = lblStep1;
        progressLabels[2] = lblStep2;
        progressLabels[3] = lblStep3;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            btnLookup_Click(btnLookup, EventArgs.Empty);
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void lnkPricing_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        var pricing = new FrmGuestPricing();
        pricing.ShowDialog(this);
    }

    private async void btnLookup_Click(object? sender, EventArgs e)
    {
        if (isLoading) return;

        lblError.Visible = false;
        pnlResult.Visible = false;

        var orderNo = txtOrderNumber.Text.Trim();
        var phone4 = txtPhoneLast4.Text.Trim();

        if (string.IsNullOrWhiteSpace(orderNo) || orderNo.Length < 3)
        {
            ShowError("Please enter your Order Number (e.g. LH-20261021-001).");
            txtOrderNumber.Focus();
            return;
        }

        if (phone4.Length != 4 || !phone4.All(char.IsDigit))
        {
            ShowError("Please enter exactly 4 digits of your registered phone number.");
            txtPhoneLast4.Focus();
            return;
        }

        // Throttle guest lookup attempts per machine to reduce enumeration abuse
        var key = "guestlookup:machine";
        var limit = 8;
        var window = TimeSpan.FromMinutes(5);
        var lockout = TimeSpan.FromMinutes(10);

        if (!ThrottleService.IsAllowed(key, limit, window, lockout))
        {
            var rem = ThrottleService.GetRemainingLockout(key);
            ShowError($"Too many lookup attempts. Try again in {Math.Ceiling(rem.TotalMinutes)} minutes.");
            return;
        }

        isLoading = true;
        btnLookup.Enabled = false;
        btnLookup.Text = "Looking up...";

        try
        {
            var orderCacheKey = $"guest_order_{orderNo}";
            var order = await DataCache.GetOrAddAsync(orderCacheKey,
                () => Task.Run(() => AppServices.Orders.GetByOrderNumber(orderNo)),
                TimeSpan.FromSeconds(30));

            if (order == null)
            {
                ThrottleService.RegisterAttempt(key, limit, window, lockout);
                ShowError("Order not found. Please verify the order number on your ticket.");
                return;
            }

            var customerCacheKey = $"customer_by_id_{order.CustomerId}";
            var customer = await DataCache.GetOrAddAsync(customerCacheKey,
                () => Task.Run(() => AppServices.Customers.GetById(order.CustomerId)),
                TimeSpan.FromSeconds(30));

            if (customer == null || !customer.Phone.EndsWith(phone4))
            {
                ThrottleService.RegisterAttempt(key, limit, window, lockout);
                ShowError("Order number and phone verification do not match our records.");
                return;
            }

            // Successful verification - reset throttle
            ThrottleService.Reset(key);

            // Found & Verified! Populate result
            this.SafeInvoke(() =>
            {
                lblResultOrder.Text = order.OrderNumber;
                lblResultCustomer.Text = customer.FullName;
                lblResultService.Text = $"{order.ServiceName ?? "Standard Laundry"} ({order.WeightKg} kg)";
                lblResultTotal.Text = $"{order.TotalAmount:N2}";
                lblResultPayment.Text = order.PaymentRecorded ? "Paid" : "Unpaid";
                lblResultPayment.ForeColor = order.PaymentRecorded ? UIThemeHelper.Success : UIThemeHelper.Danger;
                lblResultPickup.Text = order.PickupDate?.ToString("MMMM dd, yyyy") ?? "Pending schedule";

                UpdateTimeline(order.Status, order.CancelReason);
                pnlResult.Visible = true;
            });
        }
        finally
        {
            isLoading = false;
            this.SafeInvoke(() =>
            {
                btnLookup.Enabled = true;
                btnLookup.Text = "Lookup Order";
            });
        }
    }

    private void UpdateTimeline(string status, string? cancelReason = null)
    {
        // Handle Cancelled status specially
        if (status == "Cancelled")
        {
            for (int i = 0; i < 4; i++)
            {
                progressSteps[i].BackColor = UIThemeHelper.Danger;
                progressLabels[i].ForeColor = Color.White;
            }
            lblStep0.Text = " Cancelled";
            lblStep1.Text = "";
            lblStep2.Text = "";
            lblStep3.Text = string.IsNullOrWhiteSpace(cancelReason) ? "" : $"Reason: {cancelReason}";
            lblStep3.ForeColor = Color.White;
            return;
        }

        // Reset labels for normal statuses
        lblStep1.Text = " Drying";
        lblStep2.Text = " Ready";
        lblStep3.Text = " Claimed";

        lblStep0.Text = " Washing";

        int activeIdx = status switch
        {
            "Washing"          => 0,
            "Drying"           => 1,
            "Ready for Pickup" => 2,
            "Claimed"          => 3,
            _                  => -1
        };

        for (int i = 0; i < 4; i++)
        {
            if (i == activeIdx)
            {
                // Current active stage
                progressSteps[i].BackColor = UIThemeHelper.Indigo;
                progressLabels[i].ForeColor = Color.White;
            }
            else if (i < activeIdx)
            {
                // Completed past stage
                progressSteps[i].BackColor = UIThemeHelper.Slate;
                progressLabels[i].ForeColor = Color.White;
            }
            else
            {
                // Upcoming stage
                progressSteps[i].BackColor = UIThemeHelper.Sand;
                progressLabels[i].ForeColor = UIThemeHelper.Indigo;
            }
        }
    }

    private void ShowError(string msg)
    {
        lblError.Text = $" {msg}";
        lblError.Visible = true;
    }
}
