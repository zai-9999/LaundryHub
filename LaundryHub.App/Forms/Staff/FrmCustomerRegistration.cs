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

        // This form was designed for a dark card; restyle it for the light card.
        foreach (var t in new[] { txtFullName, txtPhone, txtEmail, txtAddress })
        {
            t.BackColor = Color.White;
            t.BaseColor = Color.White;
            t.ForeColor = UIThemeHelper.Navy;
            t.BorderColorA = UIThemeHelper.Indigo;
            t.BorderColorB = UIThemeHelper.BorderSoft;
        }

        foreach (var l in new[] { lblFullName, lblPhone, lblEmail, lblAddress })
            l.ForeColor = UIThemeHelper.Indigo;

        lblFormTitle.ForeColor = UIThemeHelper.Navy;
        lblTitle.UseMnemonic = false;   // shows "&" instead of underlining the next letter

        InputValidator.RestrictToPhoneInput(txtPhone);

        txtFullName.TextChanged += (_, _) => lblError.Visible = false;
        txtPhone.TextChanged += (_, _) => lblError.Visible = false;
        txtEmail.TextChanged += (_, _) => lblError.Visible = false;
        txtAddress.TextChanged += (_, _) => lblError.Visible = false;

        this.Text = _returnCustomer ? "Select / Register Customer" : "Customer Management";
        lblTitle.Text = _returnCustomer ? "Select or Register Customer" : "Customer Directory & Registration";
        btnSelect.Visible = _returnCustomer;

        // Window / grid / button polish
        ClientSize = new Size(1240, 720);   // wider and taller so nothing is cut off
        flpForm.AutoScroll = false;         // no scrollbar, no ghost buttons
        flpButtons.AutoSize = true;
        flpButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        // Keep the Close button pinned to the right edge of the header
        void PlaceClose() =>
            btnClose.Location = new Point(pnlHeader.ClientSize.Width - btnClose.Width - 24,
                                          (pnlHeader.Height - btnClose.Height) / 2);
        btnClose.TextColor = Color.White;
        btnClose.BorderColor = UIThemeHelper.Slate;
        btnClose.Visible = true;
        pnlHeader.SizeChanged += (_, _) => PlaceClose();
        PlaceClose();
        btnClose.BringToFront();

        dgvCustomers.MultiSelect = false;
        dgvCustomers.CellClick += dgvCustomers_CellClick;
        dgvCustomers.CellMouseDown += dgvCustomers_CellMouseDown;
        dgvCustomers.CellFormatting += dgvCustomers_CellFormatting;
        dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;

        btnSave.Size = new Size(156, 42);
        btnClear.Size = new Size(156, 42);
        flpButtons.Width = 330;
        btnClear.DefaultColor = Color.FromArgb(234, 224, 207);
        btnClear.BorderColor = UIThemeHelper.Slate;
        btnClear.TextColor = UIThemeHelper.Indigo;
        btnClear.HoverTextColor = UIThemeHelper.Indigo;

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

    private string _lastSearch = "";

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        var term = txtSearch.Text.Trim();
        if (term == _lastSearch) return;   // ignore events that didn't change the text
        _lastSearch = term;
        LoadCustomers(term);
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        ResetForm();
    }

    private bool _binding;   // true while the grid is being filled
    private static readonly Font ArchiveFont = new("Segoe UI", 9.5F, FontStyle.Bold);

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
            Email = string.IsNullOrWhiteSpace(c.Email) ? "" : c.Email,
            Address = string.IsNullOrWhiteSpace(c.Address) ? "" : c.Address,
            Joined = c.CreatedAt.ToString("MM/dd/yyyy")
        }).ToList();

        _binding = true;   // don't let the automatic "first row selected" overwrite the form
        try
        {
            dgvCustomers.DataSource = list;
            if (dgvCustomers.Columns["CustomerId"] is { } col)
                col.Visible = false;
            EnsureActionColumn();
            ApplyGridLayout();

            dgvCustomers.ClearSelection();

            // Keep the highlight on the customer currently shown in the form
            if (_editingCustomerId > 0)
            {
                foreach (DataGridViewRow r in dgvCustomers.Rows)
                {
                    if (r.Cells["CustomerId"].Value is int rid && rid == _editingCustomerId)
                    {
                        r.Selected = true;
                        break;
                    }
                }
            }
        }
        finally { _binding = false; }
    }

    private void ApplyGridLayout()
    {
        void Weight(string name, float w)
        {
            if (dgvCustomers.Columns[name] is { } c) c.FillWeight = w;
        }
        Weight("Name", 22);
        Weight("Phone", 24);
        Weight("Email", 32);
        Weight("Address", 28);
        Weight("Joined", 22);

        if (dgvCustomers.Columns["colArchive"] is { } a)
        {
            a.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            a.Width = 96;
        }
    }

    // Mouse-down gives the exact row that was clicked, before any selection logic runs.
    private void dgvCustomers_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left || e.RowIndex < 0) return;
        if (dgvCustomers.Columns[e.ColumnIndex].Name == "colArchive") return;
        LoadCustomerIntoForm(e.RowIndex);
    }

    private void dgvCustomers_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (dgvCustomers.Columns[e.ColumnIndex].Name == "colArchive") return;
        LoadCustomerIntoForm(e.RowIndex);
    }

    // Keyboard navigation. The current cell is only updated just after this event, so read it a moment later.
    private void dgvCustomers_SelectionChanged(object? sender, EventArgs e)
    {
        if (_binding || !IsHandleCreated) return;
        BeginInvoke(new Action(() =>
        {
            if (_binding) return;
            var cell = dgvCustomers.CurrentCell;
            if (cell?.OwningRow != null && cell.OwningRow.Selected &&
                dgvCustomers.Columns[cell.ColumnIndex].Name != "colArchive")
                LoadCustomerIntoForm(cell.RowIndex);
        }));
    }

    private void LoadCustomerIntoForm(int rowIndex)
    {
        try
        {
            if (rowIndex < 0 || rowIndex >= dgvCustomers.Rows.Count) return;
            if (dgvCustomers.Rows[rowIndex].Cells["CustomerId"].Value is not int id) return;

            var c = AppServices.Customers.GetById(id);
            if (c == null) return;

            _selectedCustomer = c;
            _editingCustomerId = c.CustomerId;
            lblFormTitle.Text = $"Edit Customer #{c.CustomerId}";
            btnSave.Text = "Update Info";
            txtFullName.Text = c.FullName;
            txtPhone.Text = c.Phone;
            txtEmail.Text = c.Email ?? "";
            txtAddress.Text = c.Address ?? "";
            lblError.Visible = false;

            // TEMPORARY check: shows which customer was loaded. Delete this line once it works.
            Text = $"Customer Management  -  loaded #{c.CustomerId} {c.FullName}";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Could not load customer");
        }
    }

    // Same soft-red Archive button on every row (alternating row colors were overriding it).
    private void dgvCustomers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || dgvCustomers.Columns[e.ColumnIndex].Name != "colArchive") return;

        var back = Color.FromArgb(250, 232, 235);
        e.CellStyle.BackColor = back;
        e.CellStyle.SelectionBackColor = back;
        e.CellStyle.ForeColor = UIThemeHelper.Danger;
        e.CellStyle.SelectionForeColor = UIThemeHelper.Danger;
        e.CellStyle.Font = ArchiveFont;
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

    private void dgvCustomers_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvCustomers.Columns[e.ColumnIndex].Name != "colArchive") return;
        if (dgvCustomers.Rows[e.RowIndex].Cells["CustomerId"].Value is not int id) return;

        ArchiveCustomer(id);
    }

    private void ArchiveCustomer(int customerId)
    {
        var customer = AppServices.Customers.GetById(customerId);
        if (customer == null) return;

        var confirm = MessageBox.Show(
            $"Are you sure you want to archive customer '{customer.FullName}'?",
            "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        try
        {
            AppServices.Customers.Archive(customerId);
            ResetForm();
            LoadCustomers(txtSearch.Text.Trim());
            MessageBox.Show("Customer archived successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Cannot Archive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void EnsureActionColumn()
    {
        if (!dgvCustomers.Columns.Contains("colArchive"))
        {
            dgvCustomers.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colArchive",
                HeaderText = "Action",
                Text = "Archive",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Visible = !_returnCustomer,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = UIThemeHelper.Danger,
                    ForeColor = Color.White,
                    SelectionBackColor = UIThemeHelper.Danger,
                    SelectionForeColor = Color.White,
                    Padding = new Padding(10, 6, 10, 6)
                }
            });
        }

        dgvCustomers.Columns["colArchive"]!.DisplayIndex = dgvCustomers.Columns.Count - 1;
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
        if (dgvCustomers.Rows.Count > 0)
        {
            try { dgvCustomers.CurrentCell = null; } catch { }
        }
    }

    private bool ValidateForm()
    {
        lblError.Visible = false;
        var name = txtFullName.Text.Trim();
        var phone = txtPhone.Text.Trim();
        var email = txtEmail.Text.Trim();

        if (!InputValidator.IsValidFullName(name, out var nameErr))
        {
            ShowError(nameErr);
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
            if (!InputValidator.IsValidEmail(email, out var emailErr))
            {
                ShowError(emailErr);
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

        if (!string.IsNullOrWhiteSpace(txtAddress.Text) && txtAddress.Text.Trim().Length > 255)
        {
            ShowError("Address cannot exceed 255 characters.");
            txtAddress.Focus();
            return false;
        }

        return true;
    }

    private void ShowError(string msg)
    {
        lblError.Text = $" {msg}";
        lblError.Visible = true;
    }
}
