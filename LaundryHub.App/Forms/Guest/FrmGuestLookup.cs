using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Guest;

public partial class FrmGuestLookup : Form
{
    public FrmGuestLookup()
    {
        InitializeForm();
    }

    private TextBox txtOrderNumber = null!;
    private TextBox txtPhoneLast4 = null!;
    private Button btnLookup = null!;
    private Button btnBack = null!;
    private Label lblError = null!;
    private Panel resultPanel = null!;

    // Result labels
    private Label lblResultOrder = null!;
    private Label lblResultCustomer = null!;
    private Label lblResultService = null!;
    private Label lblResultTotal = null!;
    private Label lblResultPickup = null!;
    private Label lblResultPayment = null!;
    private Panel[] progressSteps = new Panel[4];
    private Label[] progressLabels = new Label[4];

    private void InitializeForm()
    {
        this.Text = "LaundryHub – Guest Order Tracking";
        this.Size = new Size(680, 720);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        // Container Card
        var card = new Panel
        {
            Size = new Size(580, 620),
            Location = new Point(45, 30),
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(30)
        };
        card.Paint += (s, e) =>
        {
            using var pen = new Pen(Color.FromArgb(59, 130, 246), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        };

        // Header Title
        var lblIcon = new Label
        {
            Text = "🔍",
            Font = new Font("Segoe UI Emoji", 28),
            Size = new Size(520, 45),
            Location = new Point(30, 20),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var lblTitle = new Label
        {
            Text = "Track Your Laundry Order",
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            Size = new Size(520, 32),
            Location = new Point(30, 70),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var lblSub = new Label
        {
            Text = "Enter your Order Number and the last 4 digits of your phone number",
            Font = new Font("Segoe UI", 8.5f),
            ForeColor = Color.FromArgb(148, 163, 184),
            Size = new Size(520, 20),
            Location = new Point(30, 102),
            TextAlign = ContentAlignment.MiddleCenter
        };

        card.Controls.AddRange(new Control[] { lblIcon, lblTitle, lblSub });

        // Input Fields
        var lblOrder = new Label
        {
            Text = "Order Number (e.g. LH-20261011-001):",
            ForeColor = Color.FromArgb(148, 163, 184),
            Location = new Point(50, 135),
            Size = new Size(420, 20)
        };
        txtOrderNumber = new TextBox
        {
            Location = new Point(50, 158),
            Size = new Size(420, 32),
            Font = new Font("Segoe UI", 11),
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            PlaceholderText = "LH-YYYYMMDD-XXX"
        };

        var lblPhone = new Label
        {
            Text = "Last 4 Digits of Phone Number:",
            ForeColor = Color.FromArgb(148, 163, 184),
            Location = new Point(50, 200),
            Size = new Size(420, 20)
        };
        txtPhoneLast4 = new TextBox
        {
            Location = new Point(50, 223),
            Size = new Size(420, 32),
            Font = new Font("Segoe UI", 11),
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            MaxLength = 4,
            PlaceholderText = "e.g. 4567"
        };

        lblError = new Label
        {
            ForeColor = Color.FromArgb(248, 113, 113),
            Location = new Point(50, 260),
            Size = new Size(420, 22),
            Visible = false,
            Font = new Font("Segoe UI", 8.5f)
        };

        btnLookup = new Button
        {
            Text = "🚀 Check Status",
            Location = new Point(50, 285),
            Size = new Size(205, 38),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnLookup.FlatAppearance.BorderSize = 0;
        btnLookup.Click += btnLookup_Click;

        btnBack = new Button
        {
            Text = "← Back to Login",
            Location = new Point(265, 285),
            Size = new Size(205, 38),
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnBack.FlatAppearance.BorderSize = 0;
        btnBack.Click += (_, _) =>
        {
            new Auth.FrmLogin().Show();
            this.Close();
        };

        card.Controls.AddRange(new Control[] { lblOrder, txtOrderNumber, lblPhone, txtPhoneLast4, lblError, btnLookup, btnBack });

        // Result Container
        resultPanel = new Panel
        {
            Location = new Point(30, 340),
            Size = new Size(520, 255),
            BackColor = Color.FromArgb(15, 23, 42),
            Visible = false,
            Padding = new Padding(15)
        };
        resultPanel.Paint += (s, e) =>
        {
            using var pen = new Pen(Color.FromArgb(71, 85, 105), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, resultPanel.Width - 1, resultPanel.Height - 1);
        };

        // Timeline Progress
        var timelineHeader = new Label
        {
            Text = "Order Progress Timeline",
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            ForeColor = Color.FromArgb(148, 163, 184),
            Location = new Point(15, 10),
            Size = new Size(490, 20)
        };
        resultPanel.Controls.Add(timelineHeader);

        string[] stepTitles = { "🧺 Washing", "🌀 Drying", "✨ Ready", "📦 Claimed" };
        for (int i = 0; i < 4; i++)
        {
            var p = new Panel
            {
                Location = new Point(15 + (i * 123), 35),
                Size = new Size(118, 36),
                BackColor = Color.FromArgb(30, 41, 59)
            };
            var l = new Label
            {
                Text = stepTitles[i],
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(148, 163, 184)
            };
            p.Controls.Add(l);
            progressSteps[i] = p;
            progressLabels[i] = l;
            resultPanel.Controls.Add(p);
        }

        // Detail grid in result panel
        var grid = new TableLayoutPanel
        {
            Location = new Point(15, 80),
            Size = new Size(490, 160),
            ColumnCount = 2,
            RowCount = 6
        };
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        AddResultRow(grid, 0, "Order #:", out lblResultOrder);
        AddResultRow(grid, 1, "Customer:", out lblResultCustomer);
        AddResultRow(grid, 2, "Service:", out lblResultService);
        AddResultRow(grid, 3, "Amount:", out lblResultTotal);
        AddResultRow(grid, 4, "Payment:", out lblResultPayment);
        AddResultRow(grid, 5, "Pickup Date:", out lblResultPickup);

        resultPanel.Controls.Add(grid);
        card.Controls.Add(resultPanel);
        this.Controls.Add(card);

        this.AcceptButton = btnLookup;
    }

    private static void AddResultRow(TableLayoutPanel grid, int row, string header, out Label value)
    {
        var h = new Label
        {
            Text = header,
            ForeColor = Color.FromArgb(148, 163, 184),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 9)
        };
        value = new Label
        {
            ForeColor = Color.White,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold)
        };
        grid.Controls.Add(h, 0, row);
        grid.Controls.Add(value, 1, row);
    }

    private void btnLookup_Click(object? sender, EventArgs e)
    {
        lblError.Visible = false;
        resultPanel.Visible = false;

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

        var order = AppServices.Orders.GetByOrderNumber(orderNo);
        if (order == null)
        {
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

        UpdateTimeline(order.Status);
        resultPanel.Visible = true;
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
