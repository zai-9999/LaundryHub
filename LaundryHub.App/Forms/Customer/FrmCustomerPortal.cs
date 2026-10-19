using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Customer;

public partial class FrmCustomerPortal : Form
{
    private Core.Models.Customer? _customer;
    private readonly User _user;

    public FrmCustomerPortal()
    {
        InitializeComponent();

        if (SessionManager.CurrentUser != null)
        {
            _user = SessionManager.CurrentUser;
            _customer = AppServices.Customers.GetByUserId(_user.UserId);
            lblWelcome.Text = $"🧺 Welcome, {_customer?.FullName ?? _user.FullName}!";
            LoadOrders();
        }
        else
        {
            _user = new User { FullName = "Customer" };
        }
    }

    private void btnProfile_Click(object? sender, EventArgs e)
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
    }

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void chkActiveOnly_CheckedChanged(object? sender, EventArgs e)
    {
        LoadOrders();
    }

    private void dgvOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        btnViewTicket_Click(null, EventArgs.Empty);
    }

    private void LoadOrders()
    {
        if (_customer == null) return;

        var orders = AppServices.Orders.GetByCustomer(_customer.CustomerId).ToList();

        // Update stats
        lblActiveStat.Text = orders.Count(o => o.Status is "Booked" or "Washing" or "Drying").ToString();
        lblReadyStat.Text = orders.Count(o => o.Status == "Ready for Pickup").ToString();
        lblTotalStat.Text = orders.Count.ToString();

        if (chkActiveOnly.Checked)
        {
            orders = orders.Where(o => o.Status is "Booked" or "Washing" or "Drying" or "Ready for Pickup").ToList();
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
