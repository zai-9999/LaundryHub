using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace LaundryHub.App.Forms.Customer;

public partial class FrmCustomerPortal : Form
{
    private Core.Models.Customer? _customer;
    private readonly User _user;
    private bool isLoading = false;
    private List<Order>? _cachedOrders;

    public FrmCustomerPortal()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;

        UIThemeHelper.StyleDataGridView(dgvOrders);
        UIThemeHelper.EnableStatusPills(dgvOrders);

        // Sidebar Branding & Navigation
        pnlSidebar.BrandLabel.Text = "🧺 LaundryHub";
        pnlSidebar.BrandSubtitle.Text = "CUSTOMER PORTAL";

        pnlSidebar.AddSection("GENERAL");
        var btnNavOrders = pnlSidebar.AddNavButton("📋", "My Laundry Orders");
        btnNavOrders.IsActive = true;

        pnlSidebar.AddSection("SERVICES");
        pnlSidebar.AddNavButton("➕", "Book New Laundry", btnBookOrder_Click);
        pnlSidebar.AddNavButton("👤", "My Profile & Info", btnProfile_Click);
        pnlSidebar.AddNavButton("🧾", "View E-Ticket", BtnViewTicket_Click);

        pnlSidebar.AddSection("SYSTEM");
        pnlSidebar.AddNavButton("🔄", "Refresh Status", async (s, e) =>
        {
            if (_customer != null)
            {
                DataCache.Invalidate($"portal_customer_orders_{_customer.CustomerId}");
                await LoadOrdersAsync();
            }
        });
        pnlSidebar.AddNavButton("🚪", "Sign Out", btnLogout_Click);

        // Header Setup
        pnlHeader.Title = "My Laundry Portal";
        pnlHeader.Subtitle = "TRACK LAUNDRY PROGRESS, PICKUP STATUS & BOOK ONLINE";
        pnlHeader.SearchBox.Hint = "Search order number...";
        pnlHeader.SearchBox.TextChanged += (s, e) => FilterOrders();
        pnlHeader.ActionButton.Text = "➕ Book";
        pnlHeader.ActionButton.PrimaryColor = UIThemeHelper.Indigo;
        pnlHeader.ActionButton.Click += btnBookOrder_Click;

        if (SessionManager.CurrentUser != null)
        {
            _user = SessionManager.CurrentUser;
            pnlHeader.UserName = _user.FullName;
            pnlHeader.UserRole = "Valued Customer";
            this.Shown += async (_, _) => await LoadCustomerDataAsync();
        }
        else
        {
            _user = new User { FullName = "Customer" };
        }

        this.FormClosing += (_, _) => isLoading = false;
    }

    private async void btnProfile_Click(object? sender, EventArgs e)
    {
        if (_customer != null)
        {
            var f = new FrmUpdateProfile(_customer, _user);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                DataCache.Invalidate($"portal_customer_{_user.UserId}");
                await LoadCustomerDataAsync();
            }
        }
    }

    private async void btnBookOrder_Click(object? sender, EventArgs e)
    {
        if (_customer == null)
        {
            MessageBox.Show("Please complete your profile before booking an order.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var bookForm = new FrmBookOrder(_customer, _user);
        if (bookForm.ShowDialog(this) == DialogResult.OK && bookForm.CreatedOrder != null)
        {
            DataCache.Invalidate($"portal_customer_orders_{_customer.CustomerId}");
            await LoadOrdersAsync();
            ShowTicketModal(bookForm.CreatedOrder);
        }
    }

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private async void chkActiveOnly_CheckedChanged(object? sender, EventArgs e)
    {
        if (_customer != null)
        {
            await LoadOrdersAsync();
        }
    }

    private void dgvOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        BtnViewTicket_Click(null, EventArgs.Empty);
    }

    private async Task LoadCustomerDataAsync()
    {
        if (isLoading) return;
        isLoading = true;

        try
        {
            var cacheKey = $"portal_customer_{_user.UserId}";
            _customer = await DataCache.GetOrAddAsync(cacheKey,
                () => Task.Run(() => AppServices.Customers.GetByUserId(_user.UserId)),
                TimeSpan.FromSeconds(30));

            this.SafeInvoke(() =>
            {
                pnlHeader.UserName = _customer?.FullName ?? _user.FullName;
            });

            await LoadOrdersAsync();
        }
        finally
        {
            isLoading = false;
        }
    }

    private async Task LoadOrdersAsync()
    {
        if (_customer == null) return;

        var cacheKey = $"portal_customer_orders_{_customer.CustomerId}";
        var orders = await DataCache.GetOrAddAsync(cacheKey,
            () => Task.Run(() => AppServices.Orders.GetByCustomer(_customer.CustomerId).ToList()),
            TimeSpan.FromSeconds(30));

        _cachedOrders = orders;

        this.SafeInvoke(() =>
        {
            lblActiveStat.Text = orders.Count(o => o.Status is "Washing" or "Drying").ToString();
            lblReadyStat.Text = orders.Count(o => o.Status == "Ready for Pickup").ToString();
            lblTotalStat.Text = orders.Count.ToString();

            FilterOrders();
        });
    }

    private void FilterOrders()
    {
        if (_cachedOrders == null) return;

        var filtered = _cachedOrders.AsEnumerable();

        if (chkActiveOnly.Checked)
        {
            filtered = filtered.Where(o => o.Status is "Washing" or "Drying" or "Ready for Pickup");
        }

        var query = pnlHeader.SearchBox.Text.Trim();
        if (!string.IsNullOrWhiteSpace(query))
        {
            var q = query.ToLower();
            filtered = filtered.Where(o =>
                o.OrderNumber.ToLower().Contains(q) ||
                (o.ServiceName?.ToLower().Contains(q) ?? false) ||
                o.Status.ToLower().Contains(q));
        }

        var list = filtered.ToList();
        dgvOrders.DataSource = list.Select(o => new
        {
            o.OrderId,
            Order_No = o.OrderNumber,
            Service = o.ServiceName ?? "Laundry",
            Weight = $"{o.WeightKg} kg",
            Total = $"₱{o.TotalAmount:N2}",
            Payment = o.PaymentRecorded ? "Paid" : "Unpaid",
            o.Status,
            Pickup_Date = o.PickupDate?.ToString("MMM dd, yyyy") ?? "—",
            Date_Placed = o.CreatedAt.ToString("MMM dd, yyyy")
        }).ToList();

        if (dgvOrders.Columns["OrderId"] is { } col)
            col.Visible = false;

        void SetWeight(string name, float weight)
        {
            if (dgvOrders.Columns[name] is { } c) c.FillWeight = weight;
        }
        SetWeight("Order_No", 160);
        SetWeight("Service", 110);
        SetWeight("Weight", 80);
        SetWeight("Total", 90);
        SetWeight("Payment", 90);
        SetWeight("Status", 120);
        SetWeight("Pickup_Date", 105);
        SetWeight("Date_Placed", 105);
    }

    private void BtnViewTicket_Click(object? sender, EventArgs e)
    {
        if (dgvOrders.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select an order from the list first to view its e-ticket.", "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
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
            BackColor = Color.White,
            ForeColor = UIThemeHelper.Navy,
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
        dlg.FormClosed += (_, _) => pic.Image?.Dispose();

        var lblNo = new Label
        {
            Text = order.OrderNumber,
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Location = new Point(20, 230),
            Size = new Size(330, 25),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var lblStatus = new Label
        {
            Text = $"Status: {order.Status.ToUpper()}",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = UIThemeHelper.Indigo,
            Location = new Point(20, 260),
            Size = new Size(330, 22),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var lblDetails = new Label
        {
            Text = $"Service: {order.ServiceName} ({order.WeightKg} kg)\nTotal Amount: ₱{order.TotalAmount:N2} ({(order.PaymentRecorded ? "Paid" : "Unpaid")})\nTarget Pickup: {order.PickupDate:MMMM dd, yyyy}",
            Font = new Font("Segoe UI", 9),
            ForeColor = UIThemeHelper.Indigo,
            Location = new Point(20, 290),
            Size = new Size(330, 65),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var btnClose = new Button
        {
            Text = "Close Ticket",
            Location = new Point(100, 380),
            Size = new Size(170, 36),
            BackColor = UIThemeHelper.Navy,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Click += (_, _) => dlg.Close();

        dlg.Controls.AddRange(new Control[] { pic, lblNo, lblStatus, lblDetails, btnClose });
        dlg.ShowDialog(this);
    }
}
