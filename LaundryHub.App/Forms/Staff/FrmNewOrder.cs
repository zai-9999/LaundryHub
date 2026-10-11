using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmNewOrder : Form
{
    private CustomerModel? _selectedCustomer;
    private List<ServiceType> _services = new();

    public FrmNewOrder()
    {
        BuildUI();
        LoadServices();
    }

    // ─── Data Load ────────────────────────────────────────────────────────────

    private void LoadServices()
    {
        _services = AppServices.ServiceTypes.GetAll(activeOnly: true).ToList();
        cmbService.DataSource    = _services;
        cmbService.DisplayMember = "ServiceName";
        cmbService.ValueMember   = "ServiceId";
        cmbService.SelectedIndex = -1;
    }

    // ─── Customer Search ─────────────────────────────────────────────────────

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        var term = txtSearch.Text.Trim();
        if (term.Length < 2) { lstCustomers.DataSource = null; return; }

        var results = AppServices.Customers.Search(term).ToList();
        lstCustomers.DataSource    = results;
        lstCustomers.DisplayMember = "FullName";
        lstCustomers.ValueMember   = "CustomerId";
        lstCustomers.Visible       = results.Count > 0;
    }

    private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstCustomers.SelectedItem is CustomerModel c)
        {
            _selectedCustomer         = c;
            txtSearch.Text            = c.FullName;
            lblSelectedCustomer.Text  = $"✔  {c.FullName}  |  {c.Phone}";
            lblSelectedCustomer.ForeColor = Color.FromArgb(52, 211, 153);
            lstCustomers.Visible      = false;
        }
    }

    private void btnNewCustomer_Click(object sender, EventArgs e)
    {
        var f = new FrmCustomerRegistration(returnCustomer: true);
        if (f.ShowDialog(this) == DialogResult.OK && f.CreatedCustomer != null)
        {
            _selectedCustomer = f.CreatedCustomer;
            txtSearch.Text = _selectedCustomer.FullName;
            lblSelectedCustomer.Text = $"✔  {_selectedCustomer.FullName}  |  {_selectedCustomer.Phone}";
            lblSelectedCustomer.ForeColor = Color.FromArgb(52, 211, 153);
        }
    }

    // ─── Auto-Price Computation ───────────────────────────────────────────────

    private void ComputePrice()
    {
        if (cmbService.SelectedItem is not ServiceType svc) return;
        if (!decimal.TryParse(txtWeight.Text, out decimal kg) || kg <= 0) return;

        decimal total       = svc.ComputePrice(kg);
        lblPrice.Text       = $"₱{total:N2}";
        lblPriceBreakdown.Text =
            $"Rate: ₱{svc.PricePerKilo}/kg  |  Min: {svc.MinimumWeight} kg  " +
            $"|  Billed: {Math.Max(kg, svc.MinimumWeight)} kg";
    }

    private void cmbService_SelectedIndexChanged(object sender, EventArgs e) => ComputePrice();
    private void txtWeight_TextChanged(object sender, EventArgs e)            => ComputePrice();

    // ─── Save Order ───────────────────────────────────────────────────────────

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateOrder()) return;

        var svc   = (ServiceType)cmbService.SelectedItem!;
        var kg    = decimal.Parse(txtWeight.Text);
        var total = svc.ComputePrice(kg);

        var order = new Order
        {
            OrderNumber = AppServices.Orders.GenerateOrderNumber(),
            CustomerId  = _selectedCustomer!.CustomerId,
            ServiceId   = svc.ServiceId,
            WeightKg    = kg,
            TotalAmount = total,
            Status      = "Washing",
            CreatedBy   = SessionManager.CurrentUser!.UserId,
            PickupDate  = dtpPickup.Value.Date,
            // Navigation for email display
            ServiceName  = svc.ServiceName,
            CustomerName = _selectedCustomer.FullName
        };

        int orderId = AppServices.Orders.Add(order);
        order.OrderId = orderId;

        // Show QR ticket
        ShowQrTicket(order);

        // Send email receipt in background
        EmailHelper.SendReceiptAsync(order, _selectedCustomer);

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void ShowQrTicket(Order order)
    {
        var bmp = Helpers.QrCodeHelper.GenerateQrCode(order.OrderNumber);

        using var ticketForm = new Form
        {
            Text            = $"QR Ticket – {order.OrderNumber}",
            Size            = new Size(380, 480),
            StartPosition   = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox     = false,
            BackColor       = Color.FromArgb(30, 41, 59)
        };

        var pb = new PictureBox
        {
            Image    = bmp,
            SizeMode = PictureBoxSizeMode.Zoom,
            Size     = new Size(220, 220),
            Location = new Point(80, 20),
            BackColor = Color.White
        };
        var info = new Label
        {
            Text      = $"{order.OrderNumber}\n{_selectedCustomer!.FullName}\n{order.ServiceName}  |  {order.WeightKg} kg\n₱{order.TotalAmount:N2}  |  {order.PickupDate:MMM dd, yyyy}",
            ForeColor = Color.White,
            Font      = new Font("Segoe UI", 9.5f),
            Location  = new Point(20, 255),
            Size      = new Size(330, 100),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var btnPrint = new Button
        {
            Text      = "🖨  Print Ticket",
            Location  = new Point(50, 365),
            Size      = new Size(260, 38),
            Font      = new Font("Segoe UI", 10, FontStyle.Bold),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor    = Cursors.Hand
        };
        btnPrint.FlatAppearance.BorderSize = 0;
        btnPrint.Click += (_, _) =>
        {
            var path = Helpers.QrCodeHelper.SaveToTempFile(order.OrderNumber);
            var pd   = new PrintDialog();
            // Simple approach: open the image in the default viewer for printing
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true });
        };

        ticketForm.Controls.AddRange(new Control[] { pb, info, btnPrint });
        ticketForm.ShowDialog(this);
    }

    // ─── Validation ───────────────────────────────────────────────────────────

    private bool ValidateOrder()
    {
        lblError.Visible = false;

        if (_selectedCustomer == null)
        { ShowErr("Please select or register a customer."); return false; }

        if (cmbService.SelectedItem == null)
        { ShowErr("Please select a service type."); return false; }

        if (!decimal.TryParse(txtWeight.Text, out decimal kg) || kg <= 0)
        { ShowErr("Please enter a valid weight (kg)."); return false; }

        if (kg > 100)
        { ShowErr("Weight seems too high. Please verify."); return false; }

        if (dtpPickup.Value.Date < DateTime.Today)
        { ShowErr("Pickup date cannot be in the past."); return false; }

        return true;
    }

    private void ShowErr(string msg) { lblError.Text = msg; lblError.Visible = true; }

    // ─── UI Build ─────────────────────────────────────────────────────────────

    private TextBox      txtSearch     = null!;
    private ListBox      lstCustomers  = null!;
    private Label        lblSelectedCustomer = null!;
    private ComboBox     cmbService    = null!;
    private TextBox      txtWeight     = null!;
    private Label        lblPrice      = null!;
    private Label        lblPriceBreakdown = null!;
    private DateTimePicker dtpPickup   = null!;
    private Label        lblError      = null!;

    private void BuildUI()
    {
        this.Text            = "New Laundry Order";
        this.Size            = new Size(520, 620);
        this.StartPosition   = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox     = false;
        this.BackColor       = Color.FromArgb(15, 23, 42);

        int x = 30, w = 440;

        void AddHeader(string text, int top)
        {
            this.Controls.Add(new Label
            {
                Text      = text,
                ForeColor = Color.FromArgb(96, 165, 250),
                Font      = new Font("Segoe UI Semibold", 9, FontStyle.Bold),
                Location  = new Point(x, top),
                AutoSize  = true
            });
        }

        void AddLabel(string text, int top)
        {
            this.Controls.Add(new Label
            {
                Text      = text,
                ForeColor = Color.FromArgb(148, 163, 184),
                Font      = new Font("Segoe UI", 8.5f),
                Location  = new Point(x, top),
                AutoSize  = true
            });
        }

        // ── Title ─────────────────────────────────────────────
        this.Controls.Add(new Label
        {
            Text      = "New Order",
            Font      = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = Color.White,
            Location  = new Point(x, 18),
            AutoSize  = true
        });

        // ── Customer Search ───────────────────────────────────
        AddHeader("── Customer", 58);
        AddLabel("Search by name or phone:", 80);

        txtSearch = new TextBox
        {
            Location    = new Point(x, 98),
            Size        = new Size(340, 30),
            Font        = new Font("Segoe UI", 10),
            BackColor   = Color.FromArgb(30, 41, 59),
            ForeColor   = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };
        txtSearch.TextChanged += txtSearch_TextChanged;

        var btnNewCustomer = new Button
        {
            Text      = "+ New",
            Location  = new Point(378, 98),
            Size      = new Size(60, 30),
            BackColor = Color.FromArgb(15, 118, 110),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font      = new Font("Segoe UI", 8.5f),
            Cursor    = Cursors.Hand
        };
        btnNewCustomer.FlatAppearance.BorderSize = 0;
        btnNewCustomer.Click += btnNewCustomer_Click;

        lstCustomers = new ListBox
        {
            Location    = new Point(x, 130),
            Size        = new Size(w, 90),
            BackColor   = Color.FromArgb(30, 41, 59),
            ForeColor   = Color.White,
            Font        = new Font("Segoe UI", 9),
            Visible     = false
        };
        lstCustomers.SelectedIndexChanged += lstCustomers_SelectedIndexChanged;

        lblSelectedCustomer = new Label
        {
            Text      = "No customer selected",
            ForeColor = Color.FromArgb(100, 116, 139),
            Font      = new Font("Segoe UI", 8.5f, FontStyle.Italic),
            Location  = new Point(x, 132),
            Size      = new Size(w, 20)
        };

        // ── Service ───────────────────────────────────────────
        AddHeader("── Service & Weight", 165);
        AddLabel("Service Type:", 187);
        cmbService = new ComboBox
        {
            Location         = new Point(x, 205),
            Size             = new Size(w, 30),
            Font             = new Font("Segoe UI", 10),
            BackColor        = Color.FromArgb(30, 41, 59),
            ForeColor        = Color.White,
            DropDownStyle    = ComboBoxStyle.DropDownList
        };
        cmbService.SelectedIndexChanged += cmbService_SelectedIndexChanged;

        AddLabel("Weight (kg):", 245);
        txtWeight = new TextBox
        {
            Location    = new Point(x, 263),
            Size        = new Size(w, 30),
            Font        = new Font("Segoe UI", 10),
            BackColor   = Color.FromArgb(30, 41, 59),
            ForeColor   = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };
        txtWeight.TextChanged += txtWeight_TextChanged;

        // ── Price display ─────────────────────────────────────
        var priceBox = new Panel
        {
            Location  = new Point(x, 303),
            Size      = new Size(w, 70),
            BackColor = Color.FromArgb(30, 41, 59)
        };
        lblPrice = new Label
        {
            Text      = "₱0.00",
            Font      = new Font("Segoe UI", 24, FontStyle.Bold),
            ForeColor = Color.FromArgb(52, 211, 153),
            Location  = new Point(12, 8),
            AutoSize  = true
        };
        lblPriceBreakdown = new Label
        {
            Text      = "Select a service and enter weight to compute.",
            ForeColor = Color.FromArgb(100, 116, 139),
            Font      = new Font("Segoe UI", 8),
            Location  = new Point(12, 42),
            Size      = new Size(w - 20, 20)
        };
        priceBox.Controls.AddRange(new Control[] { lblPrice, lblPriceBreakdown });

        // ── Pickup Date ───────────────────────────────────────
        AddHeader("── Pickup Date", 382);
        AddLabel("Expected pickup date:", 404);
        dtpPickup = new DateTimePicker
        {
            Location    = new Point(x, 422),
            Size        = new Size(w, 30),
            Font        = new Font("Segoe UI", 10),
            Format      = DateTimePickerFormat.Long,
            MinDate     = DateTime.Today,
            Value       = DateTime.Today.AddDays(1),
            CalendarMonthBackground = Color.FromArgb(30, 41, 59)
        };

        // ── Error ─────────────────────────────────────────────
        lblError = new Label
        {
            Text      = "",
            ForeColor = Color.FromArgb(248, 113, 113),
            Font      = new Font("Segoe UI", 8.5f),
            Location  = new Point(x, 462),
            Size      = new Size(w, 18),
            Visible   = false
        };

        // ── Action buttons ────────────────────────────────────
        var btnSave = new Button
        {
            Text      = "💾  Save Order & Generate QR Ticket",
            Location  = new Point(x, 488),
            Size      = new Size(w, 44),
            Font      = new Font("Segoe UI", 10, FontStyle.Bold),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor    = Cursors.Hand
        };
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Click += btnSave_Click;

        var btnCancel = new Button
        {
            Text      = "Cancel",
            Location  = new Point(x, 540),
            Size      = new Size(w, 32),
            Font      = new Font("Segoe UI", 9),
            BackColor = Color.Transparent,
            ForeColor = Color.FromArgb(100, 116, 139),
            FlatStyle = FlatStyle.Flat,
            Cursor    = Cursors.Hand
        };
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.Click += (_, _) => this.Close();

        this.Controls.AddRange(new Control[]
        {
            txtSearch, btnNewCustomer, lstCustomers, lblSelectedCustomer,
            cmbService, txtWeight, priceBox, dtpPickup,
            lblError, btnSave, btnCancel
        });
    }
}
