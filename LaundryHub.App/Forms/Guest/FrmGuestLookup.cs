using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Guest;

public partial class FrmGuestLookup : Form
{
    private Panel[] progressSteps = new Panel[4];
    private Label[] progressLabels = new Label[4];

    public FrmGuestLookup()
    {
        InitializeComponent();
        InitProgressArrays();
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

    private void pnlCard_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(59, 130, 246), 1);
        e.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
    }

    private void pnlResult_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(71, 85, 105), 1);
        e.Graphics.DrawRectangle(pen, 0, 0, pnlResult.Width - 1, pnlResult.Height - 1);
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        new Auth.FrmLogin().Show();
        this.Close();
    }

    private void btnLookup_Click(object? sender, EventArgs e)
    {
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

        if (string.IsNullOrWhiteSpace(phone4) || phone4.Length != 4)
        {
            ShowError("Please enter exactly 4 digits of your phone number.");
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

        var order = AppServices.Orders.GetByOrderNumber(orderNo);
        if (order == null)
        {
            ThrottleService.RegisterAttempt(key, limit, window, lockout);
            ShowError("Order not found. Please verify the order number on your ticket.");
            return;
        }

        var customer = AppServices.Customers.GetById(order.CustomerId);
        if (customer == null || !customer.Phone.EndsWith(phone4))
        {
            ShowError("Order number and phone verification do not match our records.");
            return;
        }

        // Found & Verified! Populate result
        lblResultOrder.Text = order.OrderNumber;
        lblResultCustomer.Text = customer.FullName;
        lblResultService.Text = $"{order.ServiceName ?? "Standard Laundry"} ({order.WeightKg} kg)";
        lblResultTotal.Text = $"₱{order.TotalAmount:N2}";
        lblResultPayment.Text = order.PaymentRecorded ? "✔ Paid" : "⏳ Unpaid";
        lblResultPayment.ForeColor = order.PaymentRecorded ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
        lblResultPickup.Text = order.PickupDate?.ToString("MMMM dd, yyyy") ?? "Pending schedule";
        lblTimelineHeader.Text = $"Order Progress Timeline — Status: {order.Status}";

        UpdateTimeline(order.Status);
        pnlResult.Visible = true;
    }

    private void UpdateTimeline(string status)
    {
        lblStep0.Text = status == "Booked" ? "📅 Booked" : "🧺 Washing";

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
            if (i <= activeIdx)
            {
                progressSteps[i].BackColor = i == activeIdx ? Color.FromArgb(37, 99, 235) : Color.FromArgb(16, 185, 129);
                progressLabels[i].ForeColor = Color.White;
            }
            else
            {
                progressSteps[i].BackColor = Color.FromArgb(30, 41, 59);
                progressLabels[i].ForeColor = Color.FromArgb(100, 116, 139);
            }
        }
    }

    private void ShowError(string msg)
    {
        lblError.Text = $"⚠ {msg}";
        lblError.Visible = true;
    }
}
