using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Customer;

public partial class FrmCustomerPortal : Form
{
    private Core.Models.Customer? _customer;
    private readonly User _user;

    public FrmCustomerPortal()
    {
        _user = SessionManager.CurrentUser ?? throw new InvalidOperationException("Not logged in");
        _customer = AppServices.Customers.GetByUserId(_user.UserId);
        InitializeForm();
        LoadOrders();
    }

    private Label lblWelcome = null!;
    private Label lblActiveStat = null!;
    private Label lblReadyStat = null!;
    private Label lblTotalStat = null!;
    private DataGridView dgvOrders = null!;
    private CheckBox chkActiveOnly = null!;

    private void InitializeForm()
    {
        this.Text = "LaundryHub – Customer Portal";
        this.Size = new Size(1000, 680);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);

        // Header
        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24, 0, 24, 0)
        };

        lblWelcome = new Label
        {
            Text = $"🧺 Welcome, {_customer?.FullName ?? _user.FullName}!",
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            AutoSize = false,
            Dock = DockStyle.Left,
            Width = 550,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var btnProfile = new Button
        {
            Text = "👤 My Profile",
            Size = new Size(110, 34),
            Dock = DockStyle.Right,
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnProfile.FlatAppearance.BorderSize = 0;
        btnProfile.Click += (_, _) =>
        {
            if (_customer != null)
            {
                var f = new FrmUpdateProfile(_customer, _user);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    _customer = AppServices.Customers.GetByUserId(_user.UserId);
                    lblWelcome.Text = $"🧺 Welcome, {_customer?.FullName ?? _user.FullName}!";
                }
            }
        };

        var btnLogout = new Button
        {
            Text = "🚪 Logout",
            Size = new Size(95, 34),
            Dock = DockStyle.Right,
            BackColor = Color.FromArgb(153, 27, 27),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.Click += (_, _) => this.Close();

        header.Controls.Add(lblWelcome);
        header.Controls.Add(btnProfile);
        header.Controls.Add(btnLogout);
        this.Controls.Add(header);

        // Body
        var body = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(24)
        };
        this.Controls.Add(body);

        // Stats Cards Panel
        var statsPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 100,
            FlowDirection = FlowDirection.LeftToRight
        };

        statsPanel.Controls.Add(CreateStatCard("Active In-Process", "#3b82f6", out lblActiveStat));
        statsPanel.Controls.Add(CreateStatCard("Ready for Pickup", "#10b981", out lblReadyStat));
        statsPanel.Controls.Add(CreateStatCard("Total Orders", "#8b5cf6", out lblTotalStat));
        body.Controls.Add(statsPanel);

        // Filter / Controls bar
        var filterBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 45,
            Padding = new Padding(0, 8, 0, 0)
        };

        var lblOrdersTitle = new Label
        {
            Text = "My Laundry Orders",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Left,
            Width = 200,
            TextAlign = ContentAlignment.MiddleLeft
        };

        chkActiveOnly = new CheckBox
        {
            Text = "Show active only (Washing / Drying / Ready)",
            ForeColor = Color.FromArgb(148, 163, 184),
            Dock = DockStyle.Left,
            AutoSize = true,
            Padding = new Padding(10, 0, 0, 0)
        };
        chkActiveOnly.CheckedChanged += (_, _) => LoadOrders();

        var btnViewTicket = new Button
        {
            Text = "🎫 View E-Ticket / QR Code",
            Size = new Size(190, 32),
            Dock = DockStyle.Right,
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnViewTicket.FlatAppearance.BorderSize = 0;
        btnViewTicket.Click += btnViewTicket_Click;

        filterBar.Controls.Add(lblOrdersTitle);
        filterBar.Controls.Add(chkActiveOnly);
        filterBar.Controls.Add(btnViewTicket);
        body.Controls.Add(filterBar);

        // Grid
        dgvOrders = new DataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = Color.FromArgb(30, 41, 59),
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Font = new Font("Segoe UI", 9.5f),
            GridColor = Color.FromArgb(51, 65, 85),
            RowTemplate = { Height = 38 },
            DefaultCellStyle =
            {
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(37, 99, 235),
                SelectionForeColor = Color.White
            },
            ColumnHeadersDefaultCellStyle =
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.FromArgb(148, 163, 184),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(6)
            },
            EnableHeadersVisualStyles = false
        };
        dgvOrders.CellDoubleClick += (_, _) => btnViewTicket_Click(null, EventArgs.Empty);

        var gridWrap = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 10, 0, 0)
        };
        gridWrap.Controls.Add(dgvOrders);
        body.Controls.Add(gridWrap);
    }

    private static Panel CreateStatCard(string title, string hexColor, out Label valueLabel)
    {
        var panel = new Panel
        {
            Size = new Size(295, 80),
            BackColor = Color.FromArgb(30, 41, 59),
            Margin = new Padding(0, 0, 15, 0),
            Padding = new Padding(16, 12, 16, 12)
        };

        var strip = new Panel
        {
            Dock = DockStyle.Left,
            Width = 4,
            BackColor = ColorTranslator.FromHtml(hexColor)
        };

        var lblTitle = new Label
        {
            Text = title,
            ForeColor = Color.FromArgb(148, 163, 184),
            Font = new Font("Segoe UI", 8.5f),
            Dock = DockStyle.Top,
            Height = 18
        };

        valueLabel = new Label
        {
            Text = "0",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            Dock = DockStyle.Fill
        };

        panel.Controls.Add(valueLabel);
        panel.Controls.Add(lblTitle);
        panel.Controls.Add(strip);
        return panel;
    }

    private void LoadOrders()
    {
        if (_customer == null) return;

        var orders = AppServices.Orders.GetByCustomer(_customer.CustomerId).ToList();

        // Update stats
        lblActiveStat.Text = orders.Count(o => o.Status is "Washing" or "Drying").ToString();
        lblReadyStat.Text = orders.Count(o => o.Status == "Ready for Pickup").ToString();
        lblTotalStat.Text = orders.Count.ToString();

        if (chkActiveOnly.Checked)
        {
            orders = orders.Where(o => o.Status is "Washing" or "Drying" or "Ready for Pickup").ToList();
        }

        dgvOrders.DataSource = orders.Select(o => new
        {
            o.OrderId,
            Order_No = o.OrderNumber,
            Service = o.ServiceName ?? "Laundry",
            Weight = $"{o.WeightKg} kg",
            Total = $"₱{o.TotalAmount:N2}",
            Payment = o.PaymentRecorded ? "✔ Paid" : "⏳ Unpaid",
            o.Status,
            Pickup_Date = o.PickupDate?.ToString("MMM dd, yyyy") ?? "—",
            Date_Placed = o.CreatedAt.ToString("MMM dd, yyyy")
        }).ToList();

        if (dgvOrders.Columns["OrderId"] != null)
            dgvOrders.Columns["OrderId"].Visible = false;
    }

    private void btnViewTicket_Click(object? sender, EventArgs e)
    {
        if (dgvOrders.SelectedRows.Count == 0) return;
        var row = dgvOrders.SelectedRows[0];
        if (row.Cells["OrderId"].Value is int orderId)
        {
            var order = AppServices.Orders.GetById(orderId);
            if (order != null)
            {
                ShowTicketModal(order);
            }
        }
    }

    private void ShowTicketModal(Order order)
    {
        using var dlg = new Form
        {
            Text = $"E-Ticket – {order.OrderNumber}",
            Size = new Size(380, 480),
            StartPosition = FormStartPosition.CenterParent,
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var pic = new PictureBox
        {
            Size = new Size(200, 200),
            Location = new Point(85, 20),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Image = QrCodeHelper.GenerateImage(order.OrderNumber)
        };

        var lblNo = new Label
        {
            Text = order.OrderNumber,
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            Location = new Point(20, 230),
            Size = new Size(330, 25),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var lblStatus = new Label
        {
            Text = $"Status: {order.Status.ToUpper()}",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = Color.FromArgb(52, 211, 153),
            Location = new Point(20, 260),
            Size = new Size(330, 22),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var lblDetails = new Label
        {
            Text = $"Service: {order.ServiceName} ({order.WeightKg} kg)\nTotal Amount: ₱{order.TotalAmount:N2} ({(order.PaymentRecorded ? "Paid" : "Unpaid")})\nTarget Pickup: {order.PickupDate:MMMM dd, yyyy}",
            Font = new Font("Segoe UI", 9),
            ForeColor = Color.FromArgb(148, 163, 184),
            Location = new Point(20, 290),
            Size = new Size(330, 65),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var btnClose = new Button
        {
            Text = "Close Ticket",
            Location = new Point(100, 380),
            Size = new Size(170, 36),
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Click += (_, _) => dlg.Close();

        dlg.Controls.AddRange(new Control[] { pic, lblNo, lblStatus, lblDetails, btnClose });
        dlg.ShowDialog(this);
    }
}
