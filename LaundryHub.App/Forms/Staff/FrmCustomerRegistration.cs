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

    public FrmCustomerRegistration() : this(false)
    {
    }

    public FrmCustomerRegistration(bool returnCustomer = false)
    {
        _returnCustomer = returnCustomer;
        InitializeComponent();

        InputValidator.RestrictToPhoneInput(txtPhone);

        this.Text = _returnCustomer ? "Select / Register Customer" : "Customer Management";
        lblTitle.Text = _returnCustomer ? "Select or Register Customer" : "👥 Customer Directory & Registration";
        btnSelect.Visible = _returnCustomer;

        LoadCustomers();
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

        if (!InputValidator.IsValidPhone(phone))
        {
            ShowError(InputValidator.PhoneError);
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
}
