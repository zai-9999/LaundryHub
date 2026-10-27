using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmServicePricing : Form
{
    private List<LoadPrice> _prices = new();

    public FrmServicePricing()
    {
        InitializeComponent();

        if (!SessionManager.IsAdmin)
        {
            Enabled = false;
            Shown += (_, _) =>
            {
                MessageBox.Show("Only an administrator can edit load prices.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            };
            return;
        }

        pnlLeftCard.Visible = false;
        pnlRight.Dock = DockStyle.Fill;
        Text = "LaundryHub – Load Pricing Management";
        lblTitle.Text = "🏷 Laundry Load Pricing";
        lblGridTitle.Text = "Edit the price for each maximum load size";
        btnToggleActive.Text = "Save Prices";
        btnToggleActive.Click -= btnToggleActive_Click;
        btnToggleActive.Click += btnSavePrices_Click;

        dgvServices.ReadOnly = false;
        dgvServices.AllowUserToAddRows = false;
        dgvServices.AllowUserToDeleteRows = false;
        LoadPrices();
    }

    private void btnClose_Click(object? sender, EventArgs e) => Close();

    private void LoadPrices()
    {
        _prices = AppServices.LoadPricing.GetAll().ToList();
        dgvServices.DataSource = _prices;

        foreach (var column in dgvServices.Columns.Cast<DataGridViewColumn>())
            column.ReadOnly = column.Name != nameof(LoadPrice.Price);

        var categoryColumn = dgvServices.Columns[nameof(LoadPrice.Category)]
            ?? throw new InvalidOperationException("The category column is missing.");
        var sizeColumn = dgvServices.Columns[nameof(LoadPrice.LoadSize)]
            ?? throw new InvalidOperationException("The load size column is missing.");
        var weightColumn = dgvServices.Columns[nameof(LoadPrice.MaxWeightKg)]
            ?? throw new InvalidOperationException("The maximum weight column is missing.");
        var priceColumn = dgvServices.Columns[nameof(LoadPrice.Price)]
            ?? throw new InvalidOperationException("The price column is missing.");
        categoryColumn.HeaderText = "Laundry Category";
        sizeColumn.HeaderText = "Load Size";
        weightColumn.HeaderText = "Maximum Weight (kg)";
        priceColumn.HeaderText = "Price (₱)";
        priceColumn.DefaultCellStyle.Format = "N2";
        weightColumn.DefaultCellStyle.Format = "0.##";
    }

    private void btnSavePrices_Click(object? sender, EventArgs e)
    {
        if (!SessionManager.IsAdmin)
        {
            MessageBox.Show("Only an administrator can edit load prices.", "Access Denied",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        dgvServices.EndEdit();
        if (_prices.Any(price => price.Price <= 0))
        {
            MessageBox.Show("Every load price must be greater than zero.", "Invalid Price",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            AppServices.LoadPricing.UpdatePrices(_prices);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Load prices could not be saved:\n{ex.Message}", "Save Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        MessageBox.Show("Load prices updated successfully.", "Pricing Saved",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        LoadPrices();
    }

    private void btnClear_Click(object? sender, EventArgs e) => LoadPrices();
    private void btnSave_Click(object? sender, EventArgs e) => btnSavePrices_Click(sender, e);
    private void dgvServices_SelectionChanged(object? sender, EventArgs e) { }
    private void btnToggleActive_Click(object? sender, EventArgs e) => btnSavePrices_Click(sender, e);
}
