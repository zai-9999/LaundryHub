using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmServicePricing : Form
{
    private ServiceType? _selectedService;
    private int _editingServiceId = 0;

    public FrmServicePricing()
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;
        UIThemeHelper.StyleStandardForm(this, pnlLeftCard);
        pnlLeftCard.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlLeftCard, UIThemeHelper.ContentCardRadius);
        pnlHeader.BackColor = UIThemeHelper.Navy;
        lblTitle.BackColor = UIThemeHelper.Navy;
        pnlContainer.BackColor = UIThemeHelper.Surface;
        pnlRight.BackColor = UIThemeHelper.Surface;
        flpForm.BackColor = Color.White;
        UIThemeHelper.StyleDataGridView(dgvServices);
        UIThemeHelper.EnableStatusPills(dgvServices);

        InputValidator.RestrictToDecimalInput(txtPricePerKilo);
        InputValidator.RestrictToDecimalInput(txtMinWeight);
        txtServiceName.TextChanged += (_, _) => lblError.Visible = false;
        txtPricePerKilo.TextChanged += (_, _) => lblError.Visible = false;
        txtMinWeight.TextChanged += (_, _) => lblError.Visible = false;

        // Ensure all service pricing entries are active
        try
        {
            using var conn = AppServices.DbContext.CreateConnection();
            Dapper.SqlMapper.Execute(conn, "UPDATE service_types SET is_active = TRUE WHERE is_active = FALSE");
        }
        catch { }

        LoadServices();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void btnClose_Click(object? sender, EventArgs e) => this.Close();

    private void btnClear_Click(object? sender, EventArgs e) => ResetForm();

    private void LoadServices()
    {
        var services = AppServices.ServiceTypes.GetAll(activeOnly: false).ToList();
        dgvServices.DataSource = services.Select(s => new
        {
            s.ServiceId,
            Service = s.ServiceName,
            Rate = $"₱{s.PricePerKilo:N2} / kg",
            Min_Weight = $"{s.MinimumWeight:F1} kg"
        }).ToList();

        if (dgvServices.Columns["ServiceId"] is { } col)
            col.Visible = false;
    }

    private void dgvServices_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvServices.SelectedRows.Count == 0) return;
        var row = dgvServices.SelectedRows[0];
        if (row.Cells["ServiceId"].Value is int id)
        {
            _selectedService = AppServices.ServiceTypes.GetById(id);
            if (_selectedService != null)
            {
                _editingServiceId = _selectedService.ServiceId;
                lblFormTitle.Text = $"Edit Service #{_selectedService.ServiceId}";
                btnSave.Text = "Update Rate";
                txtServiceName.Text = _selectedService.ServiceName;
                txtPricePerKilo.Text = _selectedService.PricePerKilo.ToString("F2");
                txtMinWeight.Text = _selectedService.MinimumWeight.ToString("F1");
                chkActive.Checked = _selectedService.IsActive;
                lblError.Visible = false;
            }
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        try
        {
            var name = txtServiceName.Text.Trim();
            InputValidator.IsValidPrice(txtPricePerKilo.Text, out var price, out _, fieldName: "Price per kilo", min: 1.00m, max: 10000m);
            InputValidator.IsValidWeight(txtMinWeight.Text, out var minWeight, out _, min: 0.5m, max: 50m);

            if (_editingServiceId > 0 && _selectedService != null)
            {
                _selectedService.ServiceName = name;
                _selectedService.PricePerKilo = price;
                _selectedService.MinimumWeight = minWeight;
                _selectedService.IsActive = true;

                AppServices.ServiceTypes.Update(_selectedService);
                MessageBox.Show("Service type updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var newService = new ServiceType
                {
                    ServiceName = name,
                    PricePerKilo = price,
                    MinimumWeight = minWeight,
                    IsActive = true
                };
                AppServices.ServiceTypes.Add(newService);
                MessageBox.Show($"New service '{name}' created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadServices();
            ResetForm();
        }
        catch (Exception ex)
        {
            ShowError($"Database error: {ex.Message}");
        }
    }

    private void btnToggleActive_Click(object? sender, EventArgs e)
    {
    }

    private void ResetForm()
    {
        _editingServiceId = 0;
        _selectedService = null;
        lblFormTitle.Text = "New Service Type";
        btnSave.Text = "Save Service";
        txtServiceName.Clear();
        txtPricePerKilo.Clear();
        txtMinWeight.Clear();
        chkActive.Checked = true;
        lblError.Visible = false;
        dgvServices.ClearSelection();
    }

    private bool ValidateForm()
    {
        lblError.Visible = false;
        var name = txtServiceName.Text.Trim();

        if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
        {
            ShowError("Please enter a valid service name (at least 2 characters).");
            txtServiceName.Focus();
            return false;
        }

        if (name.Length > 60)
        {
            ShowError("Service name cannot exceed 60 characters.");
            txtServiceName.Focus();
            return false;
        }

        if (AppServices.ServiceTypes.NameExists(name, _editingServiceId))
        {
            ShowError("A service with this name already exists.");
            txtServiceName.Focus();
            return false;
        }

        if (!InputValidator.IsValidPrice(txtPricePerKilo.Text, out _, out var priceErr, fieldName: "Price per kilo", min: 1.00m, max: 10000m))
        {
            ShowError(priceErr);
            txtPricePerKilo.Focus();
            return false;
        }

        if (!InputValidator.IsValidWeight(txtMinWeight.Text, out _, out var weightErr, min: 0.5m, max: 50m))
        {
            ShowError($"Minimum weight: {weightErr}");
            txtMinWeight.Focus();
            return false;
        }

        return true;
    }

    private void ShowError(string msg)
    {
        lblError.Text = $"⚠ {msg}";
        lblError.Visible = true;
    }
}
