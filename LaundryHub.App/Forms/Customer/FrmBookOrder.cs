using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Customer;

public partial class FrmBookOrder : Form
{
    private readonly CustomerModel _customer;
    private readonly User _user;
    private List<ServiceType> _services = new();

    public Order? CreatedOrder { get; private set; }

    public FrmBookOrder(CustomerModel customer, User user)
    {
        _customer = customer;
        _user = user;
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;

        UIThemeHelper.StyleStandardForm(this, pnlMainCard);
        pnlMainCard.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlMainCard, UIThemeHelper.ContentCardRadius);
        pnlHeader.Paint += (s, e) => UIThemeHelper.PaintGradientHeaderBar(pnlHeader, e);

        dtpPickup.MinDate = DateTime.Today;
        dtpPickup.Value = DateTime.Today.AddDays(1);

        InputValidator.RestrictToDecimalInput(txtWeight);
        txtWeight.TextChanged += (_, _) => lblError.Visible = false;
        cmbServices.SelectedIndexChanged += (_, _) => lblError.Visible = false;
        dtpPickup.ValueChanged += (_, _) => lblError.Visible = false;

        PopulateCustomerInfo();
        LoadServices();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void PopulateCustomerInfo()
    {
        lblCustName.Text = $" {_customer.FullName}";
        lblCustPhone.Text = $" Phone: {_customer.Phone}";
        lblCustAddress.Text = string.IsNullOrWhiteSpace(_customer.Address)
            ? " Address: Shop Drop-Off"
            : $" Address: {_customer.Address}";
    }

    private void LoadServices()
    {
        _services = AppServices.ServiceTypes.GetAll(activeOnly: true).ToList();
        cmbServices.DataSource = _services;
        cmbServices.DisplayMember = "ServiceName";
        cmbServices.ValueMember = "ServiceId";

        if (_services.Count > 0)
        {
            cmbServices.SelectedIndex = 0;
            ComputePrice();
        }
    }

    private void ComputePrice()
    {
        if (cmbServices.SelectedItem is not ServiceType svc) return;

        lblServiceRateBadge.Text = $"Rate: {svc.PricePerKilo:N2} / kg  (Min. {svc.MinimumWeight:F1} kg)";
        lblPriceRate.Text = $"Rate: {svc.PricePerKilo:N2} per kilo";

        if (!InputValidator.IsValidWeight(txtWeight.Text, out decimal kg, out _, min: 0.1m, max: 200m))
        {
            lblBillableWeight.Text = "Billed weight: 0.0 kg";
            lblTotalAmount.Text = "0.00";
            return;
        }

        decimal billable = Math.Max(kg, Math.Round(svc.MinimumWeight, 2, MidpointRounding.AwayFromZero));
        decimal total = svc.ComputePrice(kg);

        lblBillableWeight.Text = $"Billed weight: {billable:F1} kg {(kg < svc.MinimumWeight ? "(minimum load applied)" : "")}";
        lblTotalAmount.Text = $"{total:N2}";
    }

    private void cmbServices_SelectedIndexChanged(object? sender, EventArgs e) => ComputePrice();

    private void txtWeight_TextChanged(object? sender, EventArgs e) => ComputePrice();

    private void btnQuickWeight_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            var weightStr = btn.Text.Replace(" kg", "").Trim();
            txtWeight.Text = weightStr;
        }
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void btnBookNow_Click(object? sender, EventArgs e)
    {
        lblError.Visible = false;

        if (cmbServices.SelectedItem is not ServiceType svc)
        {
            ShowError("Please select a laundry service.");
            cmbServices.Focus();
            return;
        }

        if (!InputValidator.IsValidWeight(txtWeight.Text, out decimal kg, out string weightErr, min: 0.1m, max: 200m))
        {
            ShowError(weightErr);
            txtWeight.Focus();
            return;
        }

        if (dtpPickup.Value.Date < DateTime.Today)
        {
            ShowError("Target pickup date cannot be in the past.");
            dtpPickup.Focus();
            return;
        }

        if (dtpPickup.Value.Date > DateTime.Today.AddYears(1))
        {
            ShowError("Target pickup date cannot be more than 1 year in advance.");
            dtpPickup.Focus();
            return;
        }

        if (!string.IsNullOrWhiteSpace(txtNotes.Text) && txtNotes.Text.Trim().Length > 500)
        {
            ShowError("Notes cannot exceed 500 characters.");
            txtNotes.Focus();
            return;
        }

        decimal total = svc.ComputePrice(kg);
        string orderNo = AppServices.Orders.GenerateOrderNumber();
        var notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? "Online booking via Customer Portal" : txtNotes.Text.Trim();

        var order = new Order
        {
            OrderNumber = orderNo,
            CustomerId = _customer.CustomerId,
            ServiceId = svc.ServiceId,
            WeightKg = kg,
            TotalAmount = total,
            Status = "Washing",
            CreatedBy = _user.UserId,
            PickupDate = dtpPickup.Value.Date,
            ServiceName = svc.ServiceName,
            CustomerName = _customer.FullName,
            CustomerPhone = _customer.Phone
        };

        try
        {
            int orderId = AppServices.Orders.Add(order);
            order.OrderId = orderId;
            CreatedOrder = order;

            // Send confirmation email receipt asynchronously
            EmailHelper.SendReceiptAsync(order, _customer);

            UiMessages.Show(
                $"Your laundry order has been successfully booked!\n\nOrder Number: {order.OrderNumber}\nTotal Due: {order.TotalAmount:N2}\nPickup Target: {order.PickupDate:MMMM dd, yyyy}\n\nPresent your digital QR E-Ticket upon claiming.",
                "Order Confirmed!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            ShowError($"Failed to submit order: {ex.Message}");
        }
    }

    private void ShowError(string message)
    {
        lblError.Text = $" {message}";
        lblError.Visible = true;
    }
}
