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

    private CheckBox? chkShowArchived;
    private Button? btnRestore;
    public CustomerModel? CreatedCustomer { get; private set; }

    public FrmCustomerRegistration() : this(false)
    {
    }

    public FrmCustomerRegistration(bool returnCustomer = false)
    {
        _returnCustomer = returnCustomer;
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;
        UIThemeHelper.StyleStandardForm(this, pnlLeftCard);
        pnlLeftCard.SizeChanged += (s, e) => UIThemeHelper.ApplyRoundedRegion(pnlLeftCard, UIThemeHelper.ContentCardRadius);
        pnlHeader.BackColor = UIThemeHelper.Navy;
        lblTitle.BackColor = UIThemeHelper.Navy;
        pnlContainer.BackColor = UIThemeHelper.Surface;
        pnlRight.BackColor = UIThemeHelper.Surface;
        pnlSearchBar.BackColor = UIThemeHelper.Surface;
        flpForm.BackColor = Color.White;
        UIThemeHelper.StyleDataGridView(dgvCustomers);

        InputValidator.RestrictToPhoneInput(txtPhone);

        this.Text = _returnCustomer ? "Select / Register Customer" : "Customer Management";
        lblTitle.Text = _returnCustomer ? "Select or Register Customer" : "Customer Directory & Registration";
        btnSelect.Visible = _returnCustomer;

        chkShowArchived = new CheckBox { Text = "Show archived", AutoSize = true, Margin = new Padding(3, 10, 3, 3) };
        btnRestore = new Button
        {
            Text = "Restore",
            Size = new Size(150, 38),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(22, 101, 52),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            Cursor = Cursors.Hand,
            Visible = false
        };
        btnRestore.FlatAppearance.BorderSize = 0;
        btnRestore.Click += btnRestore_Click;
        chkShowArchived.CheckedChanged += (_, _) =>
        {
            btnRestore.Visible = chkShowArchived.Checked;
            btnArchive.Visible = !chkShowArchived.Checked;
            LoadCustomers(txtSearch.Text.Trim());
        };
        flpButtons.Controls.Add(chkShowArchived);
        flpButtons.Controls.Add(btnRestore);

        LoadCustomers();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        UIThemeHelper.PaintGradientBackground(this, e);
    }

    private void btnClose_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        LoadCustomers(txtSearch.Text.Trim());
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        ResetForm();
    }

    private void LoadCustomers(string filter = "")
    {
        IEnumerable<CustomerModel> customers;
        if (chkShowArchived != null && chkShowArchived.Checked)
        {
            customers = AppServices.Customers.GetAll(includeArchived: true)
                .Where(c => c.IsArchived &&
                    (string.IsNullOrWhiteSpace(filter) ||
                     c.FullName.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                     c.Phone.Contains(filter)));
        }
        else if (string.IsNullOrWhiteSpace(filter))
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
        if (dgvCustomers.Columns["CustomerId"] is { } col)
            col.Visible = false;
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
                lblFormTitle.Text = $"Edit Customer #{_selectedCustomer.CustomerId}";
                btnSave.Text = "Update Info";
                txtFullName.Text = _selectedCustomer.FullName;
                txtPhone.Text = _selectedCustomer.Phone;
                txtEmail.Text = _selectedCustomer.Email ?? "";
                txtAddress.Text = _selectedCustomer.Address ?? "";
                lblError.Visible = false;
            }
        }
    }

    private void dgvCustomers_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (_returnCustomer && _selectedCustomer != null)
        {
            CreatedCustomer = _selectedCustomer;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        var name = txtFullName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
        var address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();

        try
        {
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
        catch (Exception ex)
        {
            ShowError($"Database error: {ex.Message}");
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
            try
            {
                AppServices.Customers.Archive(_selectedCustomer.CustomerId);
                ResetForm();
                LoadCustomers();
                MessageBox.Show("Customer archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Cannot Archive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void btnRestore_Click(object? sender, EventArgs e)
    {
        if (_selectedCustomer == null || !_selectedCustomer.IsArchived)
        {
            MessageBox.Show("Select an archived customer from the list first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        AppServices.Customers.Restore(_selectedCustomer.CustomerId);
        ResetForm();
        LoadCustomers(txtSearch.Text.Trim());
        MessageBox.Show("Customer restored.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    private void ResetForm()
    {
        _editingCustomerId = 0;
        _selectedCustomer = null;
        lblFormTitle.Text = "New Customer";
        btnSave.Text = "Save Customer";
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

        if (!InputValidator.IsValidPhone(phone))
        {
            ShowError(InputValidator.PhoneError);
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

            int excludeUserId = _selectedCustomer?.UserId ?? 0;
            if (AppServices.Users.EmailExists(email, excludeUserId))
            {
                ShowError("This email address is already in use by another account.");
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
}
