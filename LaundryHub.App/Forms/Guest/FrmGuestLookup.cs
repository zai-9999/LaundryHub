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

        if (string.IsNullOrWhiteSpace(orderNo))
        {
            ShowError("Please enter your Order Number.");
            txtOrderNumber.Focus();
            return;
        }

        if (phone4.Length != 4 || !phone4.All(c => c is >= '0' and <= '9'))
        {
            ShowError("Please enter exactly 4 digits of your phone number.");
            txtPhoneLast4.Focus();
            return;
        }

        isLoading = true;
        btnLookup.Enabled = false;
        btnLookup.Text = "Looking up...";

        try
        {
            var orderCacheKey = $"order_lookup_{orderNo}";
            var order = await DataCache.GetOrAddAsync(orderCacheKey,
                () => Task.Run(() => AppServices.Orders.GetByOrderNumber(orderNo)),
                TimeSpan.FromSeconds(30));

            if (order == null)
            {
                ShowError("Order not found. Please verify the order number on your ticket.");
                return;
            }

            var customerCacheKey = $"customer_{order.CustomerId}";
            var customer = await DataCache.GetOrAddAsync(customerCacheKey,
                () => Task.Run(() => AppServices.Customers.GetById(order.CustomerId)),
                TimeSpan.FromSeconds(30));

            if (customer == null || !customer.Phone.EndsWith(phone4))
            {
                ShowError("Order number and phone verification do not match our records.");
                return;
            }

            // Found & Verified! Populate result
            this.SafeInvoke(() =>
            {
                lblResultOrder.Text = order.OrderNumber;
                lblResultCustomer.Text = customer.FullName;
                lblResultService.Text = $"{order.ServiceName ?? "Standard Laundry"} ({order.WeightKg} kg)";
                lblResultTotal.Text = $"₱{order.TotalAmount:N2}";
                lblResultPayment.Text = order.PaymentRecorded ? "Paid" : "Unpaid";
                lblResultPayment.ForeColor = order.PaymentRecorded ? UIThemeHelper.Success : UIThemeHelper.Danger;
                lblResultPickup.Text = order.PickupDate?.ToString("MMMM dd, yyyy") ?? "Pending schedule";

                UpdateTimeline(order.Status);
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

    private void UpdateTimeline(string status)
    {
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
        lblError.Text = $"⚠ {msg}";
        lblError.Visible = true;
    }
}
