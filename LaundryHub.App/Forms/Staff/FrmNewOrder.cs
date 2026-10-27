using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmNewOrder : Form
{
    private CustomerModel? _selectedCustomer;
    private List<ServiceType> _services = new();
    private List<LoadPrice> _loadPrices = new();

    public FrmNewOrder()
    {
        InitializeComponent();
        dtpPickup.MinDate = DateTime.Today;
        dtpPickup.Value = DateTime.Today.AddDays(1);
        LoadServices();
        LoadLoadPrices();
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void LoadServices()
    {
        _services = AppServices.ServiceTypes.GetAll(activeOnly: true).ToList();
        cmbService.DataSource = _services;
        cmbService.DisplayMember = "ServiceName";
        cmbService.ValueMember = "ServiceId";
        cmbService.SelectedIndex = -1;
    }

    private void LoadLoadPrices()
    {
        _loadPrices = AppServices.LoadPricing.GetAll().ToList();
        cmbCategory.DataSource = new[]
        {
            LoadPricingCalculator.ClothesCategory,
            LoadPricingCalculator.HouseholdTextilesCategory
        };
        cmbCategory.SelectedIndex = -1;
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        var term = txtSearch.Text.Trim();
        if (term.Length < 2) { lstCustomers.DataSource = null; lstCustomers.Visible = false; return; }

        var results = AppServices.Customers.Search(term).ToList();
        lstCustomers.DataSource = results;
        lstCustomers.DisplayMember = "FullName";
        lstCustomers.ValueMember = "CustomerId";
        lstCustomers.Visible = results.Count > 0;
    }

    private void lstCustomers_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (lstCustomers.SelectedItem is CustomerModel c)
        {
            _selectedCustomer = c;
            txtSearch.Text = c.FullName;
            lblSelectedCustomer.Text = $"✔  {c.FullName}  |  {c.Phone}";
            lblSelectedCustomer.ForeColor = Color.FromArgb(52, 211, 153);
            lstCustomers.Visible = false;
        }
    }

    private void btnNewCustomer_Click(object? sender, EventArgs e)
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

    private void ComputePrice()
    {
        if (cmbService.SelectedItem is not ServiceType ||
            cmbCategory.SelectedItem is not string category ||
            !decimal.TryParse(txtWeight.Text, out decimal kg) || kg <= 0)
        {
            lblPrice.Text = "₱0.00";
            lblPriceBreakdown.Text = "Select a category, service, and weight to compute.";
            return;
        }

        if (kg > 100)
        {
            lblPrice.Text = "—";
            lblPriceBreakdown.Text = "Weight seems too high. Please verify.";
            return;
        }

        var quote = LoadPricingCalculator.Calculate(category, kg, _loadPrices);
        lblPrice.Text = $"₱{quote.Total:N2}";
        lblPriceBreakdown.Text = $"{quote.GetBreakdown()}  |  {kg:N2} kg";
    }

    private void cmbCategory_SelectedIndexChanged(object? sender, EventArgs e) => ComputePrice();
    private void cmbService_SelectedIndexChanged(object? sender, EventArgs e) => ComputePrice();
    private void txtWeight_TextChanged(object? sender, EventArgs e) => ComputePrice();

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateOrder()) return;

        var svc = (ServiceType)cmbService.SelectedItem!;
        var category = (string)cmbCategory.SelectedItem!;
        var kg = decimal.Parse(txtWeight.Text);
        var total = LoadPricingCalculator.Calculate(category, kg, _loadPrices).Total;

        var order = new Order
        {
            OrderNumber = AppServices.Orders.GenerateOrderNumber(),
            CustomerId = _selectedCustomer!.CustomerId,
            ServiceId = svc.ServiceId,
            LaundryCategory = category,
            WeightKg = kg,
            TotalAmount = total,
            Status = "Booked",
            CreatedBy = SessionManager.CurrentUser?.UserId,
            PickupDate = dtpPickup.Value.Date,
            ServiceName = svc.ServiceName,
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
            Text = $"QR Ticket – {order.OrderNumber}",
            Size = new Size(380, 480),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            BackColor = Color.FromArgb(30, 41, 59)
        };

        var pb = new PictureBox
        {
            Image = bmp,
            SizeMode = PictureBoxSizeMode.Zoom,
            Size = new Size(220, 220),
            Location = new Point(80, 20),
            BackColor = Color.White
        };
        var info = new Label
        {
            Text = $"{order.OrderNumber}\n{_selectedCustomer!.FullName}\n{order.ServiceName} — {order.LaundryCategory}  |  {order.WeightKg} kg\n₱{order.TotalAmount:N2}  |  {order.PickupDate:MMM dd, yyyy}",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9.5f),
            Location = new Point(20, 255),
            Size = new Size(330, 100),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var btnPrint = new Button
        {
            Text = "🖨  Print Ticket",
            Location = new Point(50, 365),
            Size = new Size(260, 38),
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnPrint.FlatAppearance.BorderSize = 0;
        btnPrint.Click += (_, _) =>
        {
            var path = Helpers.QrCodeHelper.SaveToTempFile(order.OrderNumber);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true });
        };

        ticketForm.Controls.AddRange(new Control[] { pb, info, btnPrint });
        ticketForm.ShowDialog(this);
    }

    private bool ValidateOrder()
    {
        lblError.Visible = false;

        if (_selectedCustomer == null)
        { ShowErr("Please select or register a customer."); return false; }

        if (cmbService.SelectedItem == null)
        { ShowErr("Please select a service type."); return false; }

        if (cmbCategory.SelectedItem is not string)
        { ShowErr("Please select a laundry category."); return false; }

        if (!decimal.TryParse(txtWeight.Text, out decimal kg) || kg <= 0 || decimal.Round(kg, 2) != kg)
        { ShowErr("Enter a valid weight up to two decimal places."); return false; }

        if (kg > 100)
        { ShowErr("Weight seems too high. Please verify."); return false; }

        if (dtpPickup.Value.Date < DateTime.Today)
        { ShowErr("Pickup date cannot be in the past."); return false; }

        return true;
    }

    private void ShowErr(string msg) { lblError.Text = msg; lblError.Visible = true; }
}
