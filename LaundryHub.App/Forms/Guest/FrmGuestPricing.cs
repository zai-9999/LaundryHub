using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Guest;

public partial class FrmGuestPricing : Form
{
    private List<ServiceType> _services = new();

    public FrmGuestPricing()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;
        UIThemeHelper.StyleStandardForm(this, pnlBody);
        pnlBody.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlBody, UIThemeHelper.ContentCardRadius);
        pnlHeader.Paint += (s, e) => UIThemeHelper.PaintGradientHeaderBar(pnlHeader, e);
        UIThemeHelper.StyleDataGridView(dgvPricing);
        LoadServices();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void LoadServices()
    {
        _services = AppServices.ServiceTypes.GetAll(activeOnly: true).ToList();

        dgvPricing.DataSource = _services.Select(s => new
        {
            Service = s.ServiceName,
            Rate = $"{s.PricePerKilo:N2} / kg",
            Min_Weight = $"{s.MinimumWeight:F1} kg",
            Minimum_Charge = $"{(s.MinimumWeight * s.PricePerKilo):N2}"
        }).ToList();

        cmbService.DataSource = _services;
        cmbService.DisplayMember = "ServiceName";
        cmbService.ValueMember = "ServiceId";
        if (_services.Count > 0)
        {
            cmbService.SelectedIndex = 0;
            ComputeEstimate();
        }
    }

    private void ComputeEstimate()
    {
        if (cmbService.SelectedItem is not ServiceType svc) return;
        if (!decimal.TryParse(txtWeight.Text.Trim(), out var kg) || kg <= 0)
        {
            lblEstimateValue.Text = "0.00";
            return;
        }

        var total = svc.ComputePrice(kg);
        lblEstimateValue.Text = $"{total:N2}";
    }

    private void cmbService_SelectedIndexChanged(object? sender, EventArgs e) => ComputeEstimate();

    private void txtWeight_TextChanged(object? sender, EventArgs e) => ComputeEstimate();

    private void btnClose_Click(object? sender, EventArgs e) => this.Close();

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        this.Close();
        var regForm = new Customer.FrmCustomerRegister();
        regForm.ShowDialog();
    }
}
