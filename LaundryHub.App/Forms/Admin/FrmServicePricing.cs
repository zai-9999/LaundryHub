using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Admin;

public partial class FrmServicePricing : Form
{
    private ServiceType? _selectedService;
    private int _editingServiceId = 0;

    public FrmServicePricing()
    {
        InitializeForm();
        LoadServices();
    }

    private TextBox txtServiceName = null!;
    private TextBox txtPricePerKilo = null!;
    private TextBox txtMinWeight = null!;
    private CheckBox chkActive = null!;
    private Label lblError = null!;
    private Label lblFormTitle = null!;
    private Button btnSave = null!;
    private Button btnClear = null!;
    private Button btnToggleActive = null!;
    private DataGridView dgvServices = null!;

    private void InitializeForm()
    {
        this.Text = "LaundryHub – Service Types & Pricing Management";
        this.Size = new Size(880, 560);
        this.StartPosition = FormStartPosition.CenterParent;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Header
        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24, 0, 24, 0)
        };
        var lblTitle = new Label
        {
            Text = "🏷 Service Types & Price Rates",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            AutoSize = false,
            Dock = DockStyle.Left,
            Width = 420,
            TextAlign = ContentAlignment.MiddleLeft
        };
        var btnClose = new Button
        {
            Text = "✕ Close",
            Size = new Size(90, 34),
            Dock = DockStyle.Right,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            Cursor = Cursors.Hand
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Click += (_, _) => this.Close();
        header.Controls.AddRange(new Control[] { lblTitle, btnClose });
        this.Controls.Add(header);

        // Body
        var container = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };
        this.Controls.Add(container);

        // Left Form Card
        var leftCard = new Panel
        {
            Dock = DockStyle.Left,
            Width = 340,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(20)
        };

        lblFormTitle = new Label
        {
            Text = "➕ New Service Type",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Top,
            Height = 35
        };
        leftCard.Controls.Add(lblFormTitle);

        var formLayout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true
        };

        formLayout.Controls.Add(CreateFieldLabel("Service Name * (e.g. Wash & Dry)"));
        txtServiceName = CreateTextBox();
        formLayout.Controls.Add(txtServiceName);

        formLayout.Controls.Add(CreateFieldLabel("Price Per Kilo (₱) *"));
        txtPricePerKilo = CreateTextBox();
        formLayout.Controls.Add(txtPricePerKilo);

        formLayout.Controls.Add(CreateFieldLabel("Minimum Weight (kg) *"));
        txtMinWeight = CreateTextBox();
        formLayout.Controls.Add(txtMinWeight);

        chkActive = new CheckBox
        {
            Text = "Active Service",
            Checked = true,
            ForeColor = Color.White,
            Padding = new Padding(0, 8, 0, 8)
        };
        formLayout.Controls.Add(chkActive);

        lblError = new Label
        {
            ForeColor = Color.FromArgb(248, 113, 113),
            Font = new Font("Segoe UI", 8.5f),
            Size = new Size(300, 36),
            Visible = false
        };
        formLayout.Controls.Add(lblError);

        var btnPanel = new FlowLayoutPanel
        {
            Size = new Size(300, 70),
            FlowDirection = FlowDirection.LeftToRight
        };

        btnSave = new Button
        {
            Text = "💾 Save Service",
            Size = new Size(145, 38),
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Click += btnSave_Click;

        btnClear = new Button
        {
            Text = "↺ Clear",
            Size = new Size(145, 38),
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnClear.FlatAppearance.BorderSize = 0;
        btnClear.Click += (_, _) => ResetForm();

        btnPanel.Controls.AddRange(new Control[] { btnSave, btnClear });
        formLayout.Controls.Add(btnPanel);
        leftCard.Controls.Add(formLayout);
        container.Controls.Add(leftCard);

        // Right Table Card
        var rightPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16, 0, 0, 0)
        };

        var toolBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 44,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(12, 6, 12, 6)
        };

        var lblGridTitle = new Label
        {
            Text = "Available Services List",
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = Color.White,
            Dock = DockStyle.Left,
            Width = 200,
            TextAlign = ContentAlignment.MiddleLeft
        };

        btnToggleActive = new Button
        {
            Text = "🔄 Toggle Active/Disabled",
            Size = new Size(180, 32),
            Dock = DockStyle.Right,
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnToggleActive.FlatAppearance.BorderSize = 0;
        btnToggleActive.Click += btnToggleActive_Click;

        toolBar.Controls.AddRange(new Control[] { lblGridTitle, btnToggleActive });
        rightPanel.Controls.Add(toolBar);

        dgvServices = new DataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = Color.FromArgb(30, 41, 59),
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Font = new Font("Segoe UI", 9.5f),
            GridColor = Color.FromArgb(51, 65, 85),
            RowTemplate = { Height = 36 },
            DefaultCellStyle =
            {
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(37, 99, 235),
                SelectionForeColor = Color.White
            },
            ColumnHeadersDefaultCellStyle =
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.FromArgb(148, 163, 184),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(6)
            },
            EnableHeadersVisualStyles = false
        };
        dgvServices.SelectionChanged += dgvServices_SelectionChanged;

        var gridWrap = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 10, 0, 0)
        };
        gridWrap.Controls.Add(dgvServices);
        rightPanel.Controls.Add(gridWrap);

        container.Controls.Add(rightPanel);
    }

    private void LoadServices()
    {
        var services = AppServices.ServiceTypes.GetAll(activeOnly: false).ToList();
        dgvServices.DataSource = services.Select(s => new
        {
            s.ServiceId,
            Service = s.ServiceName,
            Rate = $"₱{s.PricePerKilo:N2} / kg",
            Min_Weight = $"{s.MinimumWeight:F1} kg",
            Status = s.IsActive ? "Active" : "Disabled"
        }).ToList();

        if (dgvServices.Columns["ServiceId"] != null)
            dgvServices.Columns["ServiceId"].Visible = false;
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
                lblFormTitle.Text = $"✏ Edit Service #{_selectedService.ServiceId}";
                btnSave.Text = "✔ Update Rate";
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

        var name = txtServiceName.Text.Trim();
        var price = decimal.Parse(txtPricePerKilo.Text.Trim());
        var minWeight = decimal.Parse(txtMinWeight.Text.Trim());

        if (_editingServiceId > 0 && _selectedService != null)
        {
            _selectedService.ServiceName = name;
            _selectedService.PricePerKilo = price;
            _selectedService.MinimumWeight = minWeight;
            _selectedService.IsActive = chkActive.Checked;

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
                IsActive = chkActive.Checked
            };
            AppServices.ServiceTypes.Add(newService);
            MessageBox.Show($"New service '{name}' created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        LoadServices();
        ResetForm();
    }

    private void btnToggleActive_Click(object? sender, EventArgs e)
    {
        if (_selectedService == null)
        {
            MessageBox.Show("Please select a service type first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        bool newStatus = !_selectedService.IsActive;
        AppServices.ServiceTypes.SetActive(_selectedService.ServiceId, newStatus);
        LoadServices();
        MessageBox.Show($"Service '{_selectedService.ServiceName}' is now {(newStatus ? "Active" : "Disabled")}.", "Status Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ResetForm()
    {
        _editingServiceId = 0;
        _selectedService = null;
        lblFormTitle.Text = "➕ New Service Type";
        btnSave.Text = "💾 Save Service";
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

        if (string.IsNullOrWhiteSpace(txtServiceName.Text))
        {
            ShowError("Please enter a service name.");
            txtServiceName.Focus();
            return false;
        }

        if (!decimal.TryParse(txtPricePerKilo.Text.Trim(), out var p) || p <= 0)
        {
            ShowError("Price per kilo must be a positive number.");
            txtPricePerKilo.Focus();
            return false;
        }

        if (!decimal.TryParse(txtMinWeight.Text.Trim(), out var w) || w <= 0)
        {
            ShowError("Minimum weight must be a positive number.");
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

    private static Label CreateFieldLabel(string text) => new Label
    {
        Text = text,
        ForeColor = Color.FromArgb(148, 163, 184),
        Font = new Font("Segoe UI", 8.5f),
        Size = new Size(300, 18),
        Margin = new Padding(0, 5, 0, 2)
    };

    private static TextBox CreateTextBox() => new TextBox
    {
        Size = new Size(300, 30),
        Font = new Font("Segoe UI", 10),
        BackColor = Color.FromArgb(15, 23, 42),
        ForeColor = Color.White,
        BorderStyle = BorderStyle.FixedSingle
    };
}
