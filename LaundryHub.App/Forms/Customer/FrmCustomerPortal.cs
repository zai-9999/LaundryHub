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
        // The E-Ticket / Receipt button is no longer used
        btnViewTicket.Visible = false;

        DoubleBuffered = true;
        ResizeRedraw = true;

        UIThemeHelper.StyleDataGridView(dgvOrders);
        UIThemeHelper.EnableStatusPills(dgvOrders);

        // Sidebar Branding & Navigation
        pnlSidebar.BrandLabel.Text = " LaundryHub";
        pnlSidebar.BrandSubtitle.Text = "CUSTOMER PORTAL";

        pnlSidebar.AddSection("GENERAL");
        var btnNavOrders = pnlSidebar.AddNavButton("", "My Laundry Orders");
        btnNavOrders.IsActive = true;

        pnlSidebar.AddSection("SERVICES");

        pnlSidebar.AddNavButton("", "My Profile & Info", btnProfile_Click);
        pnlSidebar.AddNavButton("", "Request Cancellation", BtnRequestCancel_Click);

        pnlSidebar.AddSection("SYSTEM");
        pnlSidebar.AddNavButton("", "Refresh Status", async (s, e) =>
        {
            if (_customer != null)
            {
                DataCache.Invalidate($"portal_customer_orders_{_customer.CustomerId}");
                await LoadOrdersAsync();
            }
        });
        pnlSidebar.AddLogoutButton(btnLogout_Click);

        // Header Setup
        pnlHeader.Title = "My Laundry Portal";
        pnlHeader.Subtitle = "TRACK LAUNDRY PROGRESS & PICKUP STATUS";
        txtSearch.Hint = "Search order number, service, or status...";
        txtSearch.TextChanged += (s, e) => FilterOrders();
        pnlHeader.SearchBox.Visible = false;   // search lives in the toolbar above the table

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
                DataCache.Invalidate($"customer_by_user_{_user.UserId}");
                await LoadCustomerDataAsync();
            }
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
            var cacheKey = $"customer_by_user_{_user.UserId}";
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
            lblActiveStat.Text = orders.Count(o => o.Status is "Booked" or "Washing" or "Drying").ToString();
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
            filtered = filtered.Where(o => o.Status is "Booked" or "Washing" or "Drying" or "Ready for Pickup");
        }

        var query = txtSearch.Text.Trim();
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
            Service = $"{o.ServiceName ?? "Laundry"} — {o.LaundryCategory}",
            Weight = $"{o.WeightKg} kg",
            Total = $"{o.TotalAmount:N2}",
            Payment = o.PaymentRecorded ? "Paid" : "Unpaid",
            o.Status,
            Cancel_Request = o.CancelRequestStatus == "Pending" ? "Cancel requested"
               : o.CancelRequestStatus == "Rejected" ? "Cancel declined" : "",
            Pickup_Date = o.PickupDate?.ToString("MMM dd, yyyy") ?? "",
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

    private async void BtnRequestCancel_Click(object? sender, EventArgs e)
    {
        if (_customer == null) return;

        if (dgvOrders.SelectedRows.Count == 0 ||
            dgvOrders.SelectedRows[0].Cells["OrderId"].Value is not int orderId)
        {
            MessageBox.Show("Please select an order from the list first.", "No Order Selected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var order = AppServices.Orders.GetById(orderId);
        if (order == null || order.CustomerId != _customer.CustomerId) return;

        if (order.Status is not ("Booked" or "Washing"))
        {
            MessageBox.Show("Only orders that are Booked or Washing can be cancelled. Please contact the shop.",
                "Cannot Request Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (order.CancelRequestStatus == "Pending")
        {
            MessageBox.Show("You already sent a cancellation request for this order. Please wait for the shop's reply.",
                "Request Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dlg = new Form
        {
            Text = $"Request Cancellation  {order.OrderNumber}",
            Size = new Size(420, 280),
            StartPosition = FormStartPosition.CenterParent,
            BackColor = Color.White,
            ForeColor = UIThemeHelper.Navy,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblPrompt = new Label
        {
            Text = "Reason for cancelling (the shop will review it) *:",
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Location = new Point(24, 18),
            Size = new Size(360, 24)
        };
        var txtReason = new TextBox
        {
            Location = new Point(24, 48),
            Size = new Size(360, 80),
            Multiline = true,
            MaxLength = 250,
            Font = new Font("Segoe UI", 9.5f),
            BorderStyle = BorderStyle.FixedSingle
        };
        var btnSend = new Button
        {
            Text = "Send Request",
            Location = new Point(24, 148),
            Size = new Size(360, 38),
            BackColor = UIThemeHelper.Danger,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnSend.FlatAppearance.BorderSize = 0;
        btnSend.Click += (_, _) =>
        {
            var reason = txtReason.Text.Trim();
            if (reason.Length < 5)
            {
                MessageBox.Show("Please explain your reason (at least 5 characters).", "Reason Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return;
            }

            try
            {
                if (!AppServices.Orders.RequestCancellation(order.OrderId, _customer.CustomerId, reason))
                {
                    MessageBox.Show("The request could not be sent. The order may have moved to the next stage. Please contact the shop.",
                        "Request Not Sent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dlg.DialogResult = DialogResult.OK;
                dlg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send request: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        dlg.Controls.AddRange(new Control[] { lblPrompt, txtReason, btnSend });
        UIThemeHelper.ApplyTheme(dlg);
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            DataCache.Invalidate($"portal_customer_orders_{_customer.CustomerId}");
            await LoadOrdersAsync();
            MessageBox.Show("Your cancellation request was sent. The shop will review it.",
                "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    private void BtnViewTicket_Click(object? sender, EventArgs e)
    {
        if (dgvOrders.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select an order from the list first to view its invoice.", "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        var row = dgvOrders.SelectedRows[0];
        if (row.Cells["OrderId"].Value is int orderId)
        {
            var order = AppServices.Orders.GetById(orderId);
            if (order != null)
            {
                ShowInvoiceModal(order);
            }
        }
    }

    private void ShowInvoiceModal(Order order)
    {
        using var dlg = new FrmCustomerInvoice(order, _customer);
        dlg.ShowDialog(this);
    }
}
