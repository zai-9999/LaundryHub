using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmNewOrder : Form
{
    private CustomerModel? _selectedCustomer;
    private List<ServiceType> _services = new();
    private Panel? pnlCard;
    private List<LoadPrice> _loadPrices = new();

    public FrmNewOrder()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;

        // Wrap the form contents in a white card so it matches the login surface,
        // then grow the window so the card sits on the gradient with a margin.
        const int pad = 30, margin = 24;
        int minX = int.MaxValue, minY = int.MaxValue, maxX = 0, maxY = 0;
        foreach (Control c in Controls)
        {
            minX = Math.Min(minX, c.Left);
            minY = Math.Min(minY, c.Top);
            maxX = Math.Max(maxX, c.Right);
            maxY = Math.Max(maxY, c.Bottom);
        }

        pnlCard = new Panel { BackColor = Color.White };
        while (Controls.Count > 0)
            Controls[0].Parent = pnlCard;

        int shiftX = pad - minX, shiftY = pad - minY;
        foreach (Control c in pnlCard.Controls)
        {
            c.Left += shiftX;
            c.Top += shiftY;
        }

        pnlCard.Bounds = new Rectangle(margin, margin, (maxX - minX) + pad * 2, (maxY - minY) + pad * 2);
        Controls.Add(pnlCard);

        UIThemeHelper.StyleStandardForm(this);
        this.ClientSize = new Size(pnlCard.Right + margin, pnlCard.Bottom + margin);
        UIThemeHelper.ApplyRoundedRegion(pnlCard, UIThemeHelper.LoginCardRadius);
        pnlCard.SizeChanged += (s, e) =>
        {
            if (this.WindowState == FormWindowState.Maximized)
                pnlCard.Region = null;
            else
                UIThemeHelper.ApplyRoundedRegion(pnlCard, UIThemeHelper.LoginCardRadius);
        };

        pnlPriceBox.BackColor = UIThemeHelper.SandLight;
        btnSave.PrimaryColor = UIThemeHelper.Indigo;
        btnSave.TextColor = UIThemeHelper.CardCream;
        btnSave.HoverTextColor = Color.White;
        dtpPickup.MinDate = DateTime.Today;
        dtpPickup.Value = DateTime.Today.AddDays(1);
        InputValidator.RestrictToDecimalInput(txtWeight);
        txtWeight.TextChanged += (_, _) => lblError.Visible = false;
        cmbService.SelectedIndexChanged += (_, _) => lblError.Visible = false;
        dtpPickup.ValueChanged += (_, _) => lblError.Visible = false;
        LoadServices();
        LoadLoadPrices();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
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
            lblSelectedCustomer.Text = $"{c.FullName}  |  {c.Phone}";
            lblSelectedCustomer.ForeColor = UIThemeHelper.Navy;
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
            lblSelectedCustomer.Text = $"{_selectedCustomer.FullName}  |  {_selectedCustomer.Phone}";
            lblSelectedCustomer.ForeColor = UIThemeHelper.Navy;
        }
    }

    private void ComputePrice()
    {
        if (cmbService.SelectedItem is not ServiceType ||
            cmbCategory.SelectedItem is not string category ||
            !decimal.TryParse(txtWeight.Text, out decimal kg) || kg <= 0)
        {
            lblPrice.Text = "0.00";
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
        lblPrice.Text = $"{quote.Total:N2}";
        lblPriceBreakdown.Text = $"{quote.GetBreakdown()}  |  {kg:N2} kg";
    }

    private void cmbCategory_SelectedIndexChanged(object? sender, EventArgs e) => ComputePrice();
    private void cmbService_SelectedIndexChanged(object? sender, EventArgs e) => ComputePrice();
    private void txtWeight_TextChanged(object? sender, EventArgs e) => ComputePrice();

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateOrder()) return;

        try
        {
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
        catch (Exception ex)
        {
            ShowErr($"Failed to create order: {ex.Message}");
        }
    }

    private void ShowQrTicket(Order order)
    {
        using var bmp = Helpers.QrCodeHelper.GenerateQrCode(order.OrderNumber);

        using var ticketForm = new Form
        {
            Text = $"QR Ticket  {order.OrderNumber}",
            Size = new Size(380, 480),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            BackColor = UIThemeHelper.Slate
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
            Text = $"{order.OrderNumber}\n{_selectedCustomer!.FullName}\n{order.ServiceName} — {order.LaundryCategory}  |  {order.WeightKg} kg\n{order.TotalAmount:N2}  |  {order.PickupDate:MMM dd, yyyy}",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9.5f),
            Location = new Point(20, 255),
            Size = new Size(330, 100),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var btnPrint = new Button
        {
            Text = "  Print Ticket",
            Location = new Point(50, 365),
            Size = new Size(260, 38),
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            BackColor = UIThemeHelper.Navy,
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
        UIThemeHelper.ApplyTheme(ticketForm);
        ticketForm.ShowDialog(this);
    }

    private bool ValidateOrder()
    {
        lblError.Visible = false;

        if (_selectedCustomer == null)
        {
            ShowErr("Please select or register a customer.");
            txtSearch.Focus();
            return false;
        }

        if (cmbService.SelectedItem is not ServiceType)
        {
            ShowErr("Please select a service type.");
            cmbService.Focus();
            return false;
        }

        if (cmbCategory.SelectedItem is not string)
        {
            ShowErr("Please select a laundry category.");
            cmbCategory.Focus();
            return false;
        }

        if (!decimal.TryParse(txtWeight.Text, out decimal kg) || kg <= 0 || decimal.Round(kg, 2) != kg)
        {
            ShowErr("Enter a valid weight up to two decimal places.");
            txtWeight.Focus();
            return false;
        }

        if (kg > 100)
        {
            ShowErr("Weight seems too high. Please verify (max 100 kg).");
            txtWeight.Focus();
            return false;
        }

        if (dtpPickup.Value.Date < DateTime.Today)
        {
            ShowErr("Pickup date cannot be in the past.");
            dtpPickup.Focus();
            return false;
        }

        if (dtpPickup.Value.Date > DateTime.Today.AddYears(1))
        {
            ShowErr("Pickup date cannot be more than 1 year in advance.");
            dtpPickup.Focus();
            return false;
        }

        return true;
    }

    private void ShowErr(string msg) { lblError.Text = msg; lblError.Visible = true; }
}
