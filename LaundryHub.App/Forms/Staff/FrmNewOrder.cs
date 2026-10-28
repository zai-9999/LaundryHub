using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmNewOrder : Form
{
    private CustomerModel? _selectedCustomer;
    private List<ServiceType> _services = new();
    private List<LoadPrice> _loadPrices = new();

    // Current selections (driven by the chip / card buttons)
    private string _category = LoadPricingCalculator.ClothesCategory;
    private ServiceType? _selectedService;
    private LoadPrice? _selectedTier;

    public FrmNewOrder()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;

        UIThemeHelper.StyleStandardForm(this);

        btnSave.PrimaryColor = UIThemeHelper.Indigo;
        btnSave.TextColor = UIThemeHelper.CardCream;
        btnSave.HoverTextColor = Color.White;
        pnlPriceBox.BackColor = UIThemeHelper.SandLight;
        dtpPickup.MinDate = DateTime.Today;
        dtpPickup.Value = DateTime.Today.AddDays(1);
        dtpPickup.ValueChanged += (_, _) => lblError.Visible = false;
        nudLoads.ValueChanged += (_, _) => lblError.Visible = false;

        // Whenever the stacked content changes height (theme font bump, error label,
        // extra chip rows), resize the card and window to match.
        flowMain.SizeChanged += (_, _) => FitToContent();
        pnlCard.SizeChanged += (_, _) =>
        {
            if (WindowState == FormWindowState.Maximized)
                pnlCard.Region = null;
            else
                UIThemeHelper.ApplyRoundedRegion(pnlCard, UIThemeHelper.LoginCardRadius);
        };

        BuildCategoryChips();
        LoadServices();
        LoadLoadPrices();
        FitToContent();
    }

    private void FitToContent()
    {
        pnlCard.Size = new Size(flowMain.Right + 30, flowMain.Bottom + 28);
        ClientSize = new Size(pnlCard.Right + 24, pnlCard.Bottom + 24);
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

    // ---------- Selectable chips / cards ----------

    private static RadioButton MakeChip(string text, object tag, bool card)
    {
        var rb = new RadioButton
        {
            Appearance = Appearance.Button,
            FlatStyle = FlatStyle.Flat,
            Text = text,
            Tag = tag,
            Cursor = Cursors.Hand,
            TextAlign = ContentAlignment.MiddleCenter,
            UseVisualStyleBackColor = false,
            Font = new Font("Segoe UI", 10F, card ? FontStyle.Regular : FontStyle.Bold)
        };

        if (card)
        {
            rb.Size = new Size(135, 88);   // 3 cards + margins must fit in 440 px
            rb.Margin = new Padding(0, 0, 10, 0);
        }
        else
        {
            rb.AutoSize = true;
            rb.MinimumSize = new Size(0, 36);
            rb.Padding = new Padding(8, 2, 8, 2);
            rb.Margin = new Padding(0, 0, 8, 8);
        }

        rb.FlatAppearance.BorderSize = 1;
        rb.CheckedChanged += (_, _) => StyleChip(rb);
        StyleChip(rb);
        return rb;
    }

    private static void StyleChip(RadioButton rb)
    {
        var back = rb.Checked ? UIThemeHelper.Indigo : UIThemeHelper.SandLight;
        rb.BackColor = back;
        rb.ForeColor = rb.Checked ? Color.White : UIThemeHelper.Navy;
        rb.FlatAppearance.BorderColor = rb.Checked ? UIThemeHelper.Indigo : UIThemeHelper.BorderSoft;
        rb.FlatAppearance.CheckedBackColor = UIThemeHelper.Indigo;
        rb.FlatAppearance.MouseOverBackColor = rb.Checked ? UIThemeHelper.Indigo : UIThemeHelper.Tint;
        rb.FlatAppearance.MouseDownBackColor = UIThemeHelper.Indigo;
    }

    private static void ClearFlow(FlowLayoutPanel flow)
    {
        foreach (var c in flow.Controls.Cast<Control>().ToList())
            c.Dispose();
    }

    private void BuildCategoryChips()
    {
        ClearFlow(flowCategory);
        foreach (var name in new[]
                 {
                     LoadPricingCalculator.ClothesCategory,
                     LoadPricingCalculator.HouseholdTextilesCategory
                 })
        {
            var chip = MakeChip(name, name, card: false);
            chip.CheckedChanged += (_, _) =>
            {
                if (!chip.Checked) return;
                _category = name;
                lblError.Visible = false;
                nudLoads.Value = 1;
                BuildSizeCards();
                ComputePrice();
            };
            flowCategory.Controls.Add(chip);
        }
    }

    private void LoadServices()
    {
        _services = AppServices.ServiceTypes.GetAll(activeOnly: true).ToList();
        ClearFlow(flowService);
        _selectedService = null;

        foreach (var svc in _services)
        {
            var chip = MakeChip(svc.ServiceName, svc, card: false);
            chip.CheckedChanged += (_, _) =>
            {
                if (!chip.Checked) return;
                _selectedService = svc;
                lblError.Visible = false;
                ComputePrice();
            };
            flowService.Controls.Add(chip);
        }
    }

    private void LoadLoadPrices()
    {
        _loadPrices = AppServices.LoadPricing.GetAll().ToList();

        // Default to the first category (Clothes), which also builds the size cards.
        if (flowCategory.Controls.Count > 0)
            ((RadioButton)flowCategory.Controls[0]).Checked = true;
    }

    private static string Title(string s) =>
        s.Length == 0 ? s : char.ToUpper(s[0]) + s[1..].ToLower();

    private void BuildSizeCards()
    {
        flowSize.SuspendLayout();
        ClearFlow(flowSize);
        _selectedTier = null;

        foreach (var tier in _loadPrices.Where(p => p.Category == _category).OrderBy(p => p.MaxWeightKg))
        {
            var text = $"{Title(tier.LoadSize)} Bag\n(max {tier.MaxWeightKg:0.##} kg)\n\u20B1{tier.Price:N2}";
            var card = MakeChip(text, tier, card: true);
            card.CheckedChanged += (_, _) =>
            {
                if (!card.Checked) return;
                _selectedTier = tier;
                lblError.Visible = false;
                ComputePrice();
            };
            flowSize.Controls.Add(card);
        }

        flowSize.ResumeLayout(true);

        // Default to the smallest load
        if (flowSize.Controls.Count > 0)
            ((RadioButton)flowSize.Controls[0]).Checked = true;
    }

    // ---------- Customer search ----------

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        var term = txtSearch.Text.Trim();
        if (term.Length < 2) { lstCustomers.DataSource = null; lstCustomers.Visible = false; return; }

        var results = AppServices.Customers.Search(term).ToList();
        lstCustomers.DataSource = results;
        lstCustomers.DisplayMember = "FullName";
        lstCustomers.ValueMember = "CustomerId";

        // Float the results list right under the search box.
        lstCustomers.Location = pnlCard.PointToClient(
            pnlSearchRow.PointToScreen(new Point(txtSearch.Left, txtSearch.Bottom + 2)));
        lstCustomers.Width = pnlSearchRow.Width;
        lstCustomers.BringToFront();
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

    // ---------- Pricing ----------

    // Weight and price come from the selected load size x number of loads.
    private bool TryGetLoad(out LoadPrice tier, out int loads, out decimal weightKg, out decimal total)
    {
        tier = null!;
        loads = (int)nudLoads.Value;
        weightKg = 0;
        total = 0;
        if (_selectedTier == null) return false;

        tier = _selectedTier;
        weightKg = tier.MaxWeightKg * loads;
        total = tier.Price * loads;
        return true;
    }

    private void ComputePrice()
    {
        if (_selectedService == null || !TryGetLoad(out var tier, out var loads, out var kg, out var total))
        {
            lblPrice.Text = "\u20B10.00";
            lblPriceBreakdown.Text = "Select a service and load size to compute.";
            return;
        }

        lblPrice.Text = $"\u20B1{total:N2}";
        lblPriceBreakdown.Text = $"{loads} x {tier.LoadSize.ToLower()} load  |  {kg:0.##} kg (auto)";
    }

    private void nudLoads_ValueChanged(object? sender, EventArgs e) => ComputePrice();

    // ---------- Save ----------

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateOrder()) return;

        try
        {
            var svc = _selectedService!;
            TryGetLoad(out _, out _, out var kg, out var total);

            var order = new Order
            {
                OrderNumber = AppServices.Orders.GenerateOrderNumber(),
                CustomerId = _selectedCustomer!.CustomerId,
                ServiceId = svc.ServiceId,
                LaundryCategory = _category,
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

            // Show invoice after order creation
            ShowOrderInvoice(order);

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

    private void ShowOrderInvoice(Order order)
    {
        var customer = AppServices.Customers.GetById(order.CustomerId);
        using var dlg = new Customer.FrmCustomerInvoice(order, customer);
        dlg.ShowDialog(this);
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

        if (_selectedService == null)
        {
            ShowErr("Please select a service type.");
            return false;
        }

        if (!TryGetLoad(out _, out _, out _, out _))
        {
            ShowErr("Please select a load size.");
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
