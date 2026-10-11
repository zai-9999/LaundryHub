using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using System.Text.RegularExpressions;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Forms.Staff;

public partial class FrmCustomerRegistration : Form
{
    private readonly bool _returnCustomer;
    private CustomerModel? _selectedCustomer;
    private int _editingCustomerId = 0;

    public CustomerModel? CreatedCustomer { get; private set; }

    public FrmCustomerRegistration(bool returnCustomer = false)
    {
        _returnCustomer = returnCustomer;
        InitializeForm();
        LoadCustomers();
    }

    // ─── UI Controls ─────────────────────────────────────────────────────────

    private TextBox txtFullName = null!;
    private TextBox txtPhone = null!;
    private TextBox txtEmail = null!;
    private TextBox txtAddress = null!;
    private TextBox txtSearch = null!;
    private Label lblError = null!;
    private Label lblFormTitle = null!;
    private Button btnSave = null!;
    private Button btnClear = null!;
    private Button btnSelect = null!;
    private Button btnArchive = null!;
    private DataGridView dgvCustomers = null!;

    private void InitializeForm()
    {
        this.Text = _returnCustomer ? "Select / Register Customer" : "Customer Management";
        this.Size = new Size(1000, 640);
        this.StartPosition = FormStartPosition.CenterParent;
        this.BackColor = Color.FromArgb(15, 23, 42); // slate-900
        this.ForeColor = Color.White;
        this.Font = new Font("Segoe UI", 9.5f);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Top Header
        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(24, 0, 24, 0)
        };
        var lblTitle = new Label
        {
            Text = _returnCustomer ? "Select or Register Customer" : "👥 Customer Directory & Registration",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = Color.FromArgb(96, 165, 250),
            AutoSize = false,
            Dock = DockStyle.Left,
            Width = 500,
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
        header.Controls.Add(lblTitle);
        header.Controls.Add(btnClose);
        this.Controls.Add(header);

        // Main Container
        var container = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };
        this.Controls.Add(container);

        // Left Panel (Registration/Edit Card)
        var leftCard = new Panel
        {
            Dock = DockStyle.Left,
            Width = 380,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(20)
        };

        lblFormTitle = new Label
        {
            Text = "➕ New Customer",
            Font = new Font("Segoe UI", 13, FontStyle.Bold),
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
            AutoScroll = true,
            Padding = new Padding(0, 10, 0, 0)
        };

        // Form Fields
        formLayout.Controls.Add(CreateFieldLabel("Full Name *"));
        txtFullName = CreateTextBox();
        formLayout.Controls.Add(txtFullName);

        formLayout.Controls.Add(CreateFieldLabel("Phone Number * (e.g. 09171234567)"));
        txtPhone = CreateTextBox();
        formLayout.Controls.Add(txtPhone);

        formLayout.Controls.Add(CreateFieldLabel("Email Address (Optional)"));
        txtEmail = CreateTextBox();
        formLayout.Controls.Add(txtEmail);

        formLayout.Controls.Add(CreateFieldLabel("Complete Address (Optional)"));
        txtAddress = CreateTextBox(multiline: true);
        formLayout.Controls.Add(txtAddress);

        lblError = new Label
        {
            ForeColor = Color.FromArgb(248, 113, 113),
            Font = new Font("Segoe UI", 8.5f),
            AutoSize = false,
            Size = new Size(340, 36),
            Visible = false
        };
        formLayout.Controls.Add(lblError);

        // Action Buttons in Left Card
        var btnPanel = new FlowLayoutPanel
        {
            Size = new Size(340, 90),
            FlowDirection = FlowDirection.LeftToRight
        };

        btnSave = new Button
        {
            Text = "💾 Save Customer",
            Size = new Size(165, 38),
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
            Size = new Size(165, 38),
            BackColor = Color.FromArgb(51, 65, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        btnClear.FlatAppearance.BorderSize = 0;
        btnClear.Click += (_, _) => ResetForm();

        btnPanel.Controls.Add(btnSave);
        btnPanel.Controls.Add(btnClear);

        if (_returnCustomer)
        {
            btnSelect = new Button
            {
                Text = "✔ Select for Current Order",
                Size = new Size(335, 38),
                BackColor = Color.FromArgb(16, 185, 129),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 8, 0, 0)
            };
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.Click += btnSelect_Click;
            btnPanel.Controls.Add(btnSelect);
            btnPanel.Height = 130;
        }

        formLayout.Controls.Add(btnPanel);
        leftCard.Controls.Add(formLayout);
        container.Controls.Add(leftCard);

        // Right Panel (Table & Search)
        var rightPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16, 0, 0, 0)
        };

        // Top Search Bar
        var searchBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 48,
            BackColor = Color.FromArgb(30, 41, 59),
            Padding = new Padding(12, 8, 12, 8)
        };

        var lblSearchIcon = new Label
        {
            Text = "🔍",
            Size = new Size(28, 30),
            Dock = DockStyle.Left,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI Emoji", 10)
        };
        txtSearch = new TextBox
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("Segoe UI", 10.5f),
            PlaceholderText = "Search by name or phone number..."
        };
        txtSearch.TextChanged += (_, _) => LoadCustomers(txtSearch.Text.Trim());

        btnArchive = new Button
        {
            Text = "🗑 Archive",
            Size = new Size(95, 30),
            Dock = DockStyle.Right,
            BackColor = Color.FromArgb(153, 27, 27),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 8.5f),
            Cursor = Cursors.Hand
        };
        btnArchive.FlatAppearance.BorderSize = 0;
        btnArchive.Click += btnArchive_Click;

        searchBar.Controls.Add(txtSearch);
        searchBar.Controls.Add(lblSearchIcon);
        searchBar.Controls.Add(btnArchive);
        rightPanel.Controls.Add(searchBar);

        // Customer DataGridView
        dgvCustomers = new DataGridView
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
        dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
        dgvCustomers.CellDoubleClick += (_, _) =>
        {
            if (_returnCustomer && _selectedCustomer != null)
            {
                CreatedCustomer = _selectedCustomer;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        };

        var gridContainer = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 10, 0, 0)
        };
        gridContainer.Controls.Add(dgvCustomers);
        rightPanel.Controls.Add(gridContainer);

        container.Controls.Add(rightPanel);
    }

    // ─── Data Logic ──────────────────────────────────────────────────────────

    private void LoadCustomers(string filter = "")
    {
        IEnumerable<CustomerModel> customers;
        if (string.IsNullOrWhiteSpace(filter))
            customers = AppServices.Customers.GetAll();
        else
            customers = AppServices.Customers.Search(filter);

        var list = customers.Select(c => new
        {
            c.CustomerId,
            Name = c.FullName,
            Phone = c.Phone,
            Email = string.IsNullOrWhiteSpace(c.Email) ? "—" : c.Email,
            Address = string.IsNullOrWhiteSpace(c.Address) ? "—" : c.Address,
            Joined = c.CreatedAt.ToString("MM/dd/yyyy")
        }).ToList();

        dgvCustomers.DataSource = list;
        if (dgvCustomers.Columns["CustomerId"] != null)
            dgvCustomers.Columns["CustomerId"].Visible = false;
    }

    private void dgvCustomers_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvCustomers.SelectedRows.Count == 0) return;
        var row = dgvCustomers.SelectedRows[0];
        if (row.Cells["CustomerId"].Value is int id)
        {
            _selectedCustomer = AppServices.Customers.GetById(id);
            if (_selectedCustomer != null)
            {
                _editingCustomerId = _selectedCustomer.CustomerId;
                lblFormTitle.Text = $"✏ Edit Customer #{_selectedCustomer.CustomerId}";
                btnSave.Text = "✔ Update Info";
                txtFullName.Text = _selectedCustomer.FullName;
                txtPhone.Text = _selectedCustomer.Phone;
                txtEmail.Text = _selectedCustomer.Email ?? "";
                txtAddress.Text = _selectedCustomer.Address ?? "";
                lblError.Visible = false;
            }
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        var name = txtFullName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
        var address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();

        if (_editingCustomerId > 0 && _selectedCustomer != null)
        {
            // Update
            _selectedCustomer.FullName = name;
            _selectedCustomer.Phone = phone;
            _selectedCustomer.Email = email;
            _selectedCustomer.Address = address;

            AppServices.Customers.Update(_selectedCustomer);
            CreatedCustomer = _selectedCustomer;
            MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            // Insert
            var customer = new CustomerModel
            {
                FullName = name,
                Phone = phone,
                Email = email,
                Address = address
            };

            int newId = AppServices.Customers.Add(customer);
            customer.CustomerId = newId;
            CreatedCustomer = customer;
            MessageBox.Show($"Customer {customer.FullName} registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        LoadCustomers();

        if (_returnCustomer && CreatedCustomer != null)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            ResetForm();
        }
    }

    private void btnSelect_Click(object? sender, EventArgs e)
    {
        if (_selectedCustomer == null)
        {
            MessageBox.Show("Please choose a customer from the table first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        CreatedCustomer = _selectedCustomer;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnArchive_Click(object? sender, EventArgs e)
    {
        if (_selectedCustomer == null)
        {
            MessageBox.Show("Please select a customer to archive.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirm = MessageBox.Show($"Are you sure you want to archive customer '{_selectedCustomer.FullName}'?",
            "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (confirm == DialogResult.Yes)
        {
            AppServices.Customers.Archive(_selectedCustomer.CustomerId);
            ResetForm();
            LoadCustomers();
        }
    }

    private void ResetForm()
    {
        _editingCustomerId = 0;
        _selectedCustomer = null;
        lblFormTitle.Text = "➕ New Customer";
        btnSave.Text = "💾 Save Customer";
        txtFullName.Clear();
        txtPhone.Clear();
        txtEmail.Clear();
        txtAddress.Clear();
        lblError.Visible = false;
        dgvCustomers.ClearSelection();
    }

    private bool ValidateForm()
    {
        lblError.Visible = false;
        var name = txtFullName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var email = txtEmail.Text.Trim();

        if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
        {
            ShowError("Please enter a valid customer full name.");
            txtFullName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(phone) || phone.Length < 7)
        {
            ShowError("Please enter a valid phone number (min 7 digits).");
            txtPhone.Focus();
            return false;
        }

        if (AppServices.Customers.PhoneExists(phone, _editingCustomerId))
        {
            ShowError("This phone number is already registered to another customer.");
            txtPhone.Focus();
            return false;
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowError("Please enter a valid email address.");
                txtEmail.Focus();
                return false;
            }
        }

        return true;
    }

    private void ShowError(string msg)
    {
        lblError.Text = $"⚠ {msg}";
        lblError.Visible = true;
    }

    // ─── Helpers ─────────────────────────────────────────────────────────────

    private static Label CreateFieldLabel(string text) => new Label
    {
        Text = text,
        ForeColor = Color.FromArgb(148, 163, 184),
        Font = new Font("Segoe UI", 8.5f),
        Size = new Size(340, 18),
        Margin = new Padding(0, 6, 0, 2)
    };

    private static TextBox CreateTextBox(bool multiline = false)
    {
        var tb = new TextBox
        {
            Size = new Size(340, multiline ? 60 : 32),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(15, 23, 42),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Multiline = multiline
        };
        return tb;
    }
}
