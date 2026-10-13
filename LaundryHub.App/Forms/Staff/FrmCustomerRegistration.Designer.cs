using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using Button = System.Windows.Forms.Button;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Staff;

partial class FrmCustomerRegistration
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlHeader = new Panel();
        lblTitle = new Label();
        btnClose = new HopeButton();
        pnlContainer = new Panel();
        pnlRight = new Panel();
        pnlGridContainer = new Panel();
        dgvCustomers = new DataGridView();
        pnlSearchBar = new Panel();
        txtSearch = new HopeTextBox();
        lblSearchIcon = new Label();
        btnArchive = new HopeButton();
        pnlLeftCard = new Panel();
        flpForm = new FlowLayoutPanel();
        lblFullName = new Label();
        txtFullName = new HopeTextBox();
        lblPhone = new Label();
        txtPhone = new HopeTextBox();
        lblEmail = new Label();
        txtEmail = new HopeTextBox();
        lblAddress = new Label();
        txtAddress = new HopeTextBox();
        lblError = new Label();
        flpButtons = new FlowLayoutPanel();
        btnSave = new HopeButton();
        btnClear = new HopeButton();
        btnSelect = new HopeButton();
        lblFormTitle = new Label();
        pnlHeader.SuspendLayout();
        pnlContainer.SuspendLayout();
        pnlRight.SuspendLayout();
        pnlGridContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
        pnlSearchBar.SuspendLayout();
        pnlLeftCard.SuspendLayout();
        flpForm.SuspendLayout();
        flpButtons.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(51, 104, 160);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(btnClose);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 0, 24, 0);
        pnlHeader.Size = new Size(1000, 65);
        pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.FromArgb(37, 78, 122);
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(242, 239, 231);
        lblTitle.Location = new Point(24, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(500, 65);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Customer Directory & Registration";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnClose
        // 
        btnClose.ButtonType = HopeButtonType.Primary;
        btnClose.PrimaryColor = Color.FromArgb(102, 163, 191);
        btnClose.BorderColor = Color.FromArgb(200, 223, 219);
        btnClose.TextColor = Color.White;
        btnClose.HoverTextColor = Color.White;
        btnClose.Cursor = Cursors.Hand;
        btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnClose.Location = new Point(886, 16);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(90, 34);
        btnClose.TabIndex = 1;
        btnClose.Text = "✕ Close";
        btnClose.Click += btnClose_Click;
        // 
        // pnlContainer
        // 
        pnlContainer.BackColor = Color.FromArgb(240, 244, 248);
        pnlContainer.Controls.Add(pnlRight);
        pnlContainer.Controls.Add(pnlLeftCard);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 65);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(20);
        pnlContainer.Size = new Size(1000, 575);
        pnlContainer.TabIndex = 1;
        // 
        // pnlRight
        // 
        pnlRight.BackColor = Color.FromArgb(240, 244, 248);
        pnlRight.Controls.Add(pnlGridContainer);
        pnlRight.Controls.Add(pnlSearchBar);
        pnlRight.Dock = DockStyle.Fill;
        pnlRight.Location = new Point(400, 20);
        pnlRight.Name = "pnlRight";
        pnlRight.Padding = new Padding(16, 0, 0, 0);
        pnlRight.Size = new Size(580, 535);
        pnlRight.TabIndex = 1;
        // 
        // pnlGridContainer
        // 
        pnlGridContainer.Controls.Add(dgvCustomers);
        pnlGridContainer.Dock = DockStyle.Fill;
        pnlGridContainer.Location = new Point(16, 48);
        pnlGridContainer.Name = "pnlGridContainer";
        pnlGridContainer.Padding = new Padding(0, 10, 0, 0);
        pnlGridContainer.Size = new Size(564, 487);
        pnlGridContainer.TabIndex = 1;
        // 
        // dgvCustomers
        // 
        dgvCustomers.AllowUserToAddRows = false;
        dgvCustomers.AllowUserToDeleteRows = false;
        dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCustomers.BackgroundColor = Color.White;
        dgvCustomers.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(242, 239, 231);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(242, 239, 231);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(200, 223, 219);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvCustomers.DefaultCellStyle = dataGridViewCellStyle2;
        dgvCustomers.Dock = DockStyle.Fill;
        dgvCustomers.EnableHeadersVisualStyles = false;
        dgvCustomers.GridColor = Color.FromArgb(200, 223, 219);
        dgvCustomers.Location = new Point(0, 10);
        dgvCustomers.Name = "dgvCustomers";
        dgvCustomers.ReadOnly = true;
        dgvCustomers.RowHeadersVisible = false;
        dgvCustomers.RowTemplate.Height = 36;
        dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCustomers.Size = new Size(564, 477);
        dgvCustomers.TabIndex = 0;
        dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;
        dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
        // 
        // pnlSearchBar
        // 
        pnlSearchBar.BackColor = Color.FromArgb(240, 244, 248);
        pnlSearchBar.Controls.Add(txtSearch);
        pnlSearchBar.Controls.Add(lblSearchIcon);
        pnlSearchBar.Controls.Add(btnArchive);
        pnlSearchBar.Dock = DockStyle.Top;
        pnlSearchBar.Location = new Point(16, 0);
        pnlSearchBar.Name = "pnlSearchBar";
        pnlSearchBar.Padding = new Padding(0, 4, 0, 4);
        pnlSearchBar.Size = new Size(564, 48);
        pnlSearchBar.TabIndex = 0;
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.White;
        txtSearch.BaseColor = Color.White;
        txtSearch.BorderColorA = Color.FromArgb(102, 163, 191);
        txtSearch.BorderColorB = Color.FromArgb(200, 223, 219);
        txtSearch.Dock = DockStyle.Fill;
        txtSearch.Font = new Font("Segoe UI", 9.5F);
        txtSearch.ForeColor = Color.FromArgb(51, 104, 160);
        txtSearch.Hint = "Search by name or phone number...";
        txtSearch.Location = new Point(36, 4);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(420, 36);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // lblSearchIcon
        // 
        lblSearchIcon.Dock = DockStyle.Left;
        lblSearchIcon.Font = new Font("Segoe UI Emoji", 11F);
        lblSearchIcon.ForeColor = Color.FromArgb(102, 163, 191);
        lblSearchIcon.Location = new Point(0, 4);
        lblSearchIcon.Name = "lblSearchIcon";
        lblSearchIcon.Size = new Size(36, 40);
        lblSearchIcon.TabIndex = 0;
        lblSearchIcon.Text = "";
        lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnArchive
        // 
        btnArchive.ButtonType = HopeButtonType.Default;
        btnArchive.DefaultColor = Color.FromArgb(200, 223, 219);
        btnArchive.BorderColor = Color.FromArgb(102, 163, 191);
        btnArchive.TextColor = Color.FromArgb(51, 104, 160);
        btnArchive.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnArchive.Cursor = Cursors.Hand;
        btnArchive.Dock = DockStyle.Right;
        btnArchive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnArchive.Location = new Point(456, 4);
        btnArchive.Name = "btnArchive";
        btnArchive.Size = new Size(108, 40);
        btnArchive.TabIndex = 2;
        btnArchive.Text = "🗑 Archive";
        btnArchive.Click += btnArchive_Click;
        // 
        // pnlLeftCard
        // 
        pnlLeftCard.BackColor = Color.White;
        pnlLeftCard.Controls.Add(flpForm);
        pnlLeftCard.Controls.Add(lblFormTitle);
        pnlLeftCard.Dock = DockStyle.Left;
        pnlLeftCard.Location = new Point(20, 20);
        pnlLeftCard.Name = "pnlLeftCard";
        pnlLeftCard.Padding = new Padding(20);
        pnlLeftCard.Size = new Size(380, 535);
        pnlLeftCard.TabIndex = 0;
        // 
        // flpForm
        // 
        flpForm.AutoScroll = true;
        flpForm.BackColor = Color.White;
        flpForm.Controls.Add(lblFullName);
        flpForm.Controls.Add(txtFullName);
        flpForm.Controls.Add(lblPhone);
        flpForm.Controls.Add(txtPhone);
        flpForm.Controls.Add(lblEmail);
        flpForm.Controls.Add(txtEmail);
        flpForm.Controls.Add(lblAddress);
        flpForm.Controls.Add(txtAddress);
        flpForm.Controls.Add(lblError);
        flpForm.Controls.Add(flpButtons);
        flpForm.Dock = DockStyle.Fill;
        flpForm.FlowDirection = FlowDirection.TopDown;
        flpForm.Location = new Point(20, 55);
        flpForm.Name = "flpForm";
        flpForm.Padding = new Padding(0, 10, 0, 0);
        flpForm.Size = new Size(340, 460);
        flpForm.TabIndex = 1;
        flpForm.WrapContents = false;
        // 
        // lblFullName
        // 
        lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFullName.ForeColor = Color.FromArgb(51, 104, 160);
        lblFullName.Location = new Point(0, 14);
        lblFullName.Margin = new Padding(0, 4, 0, 2);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(320, 18);
        lblFullName.TabIndex = 0;
        lblFullName.Text = "Full Name *";
        // 
        // txtFullName
        // 
        txtFullName.BackColor = Color.White;
        txtFullName.BaseColor = Color.White;
        txtFullName.BorderColorA = Color.FromArgb(102, 163, 191);
        txtFullName.BorderColorB = Color.FromArgb(200, 223, 219);
        txtFullName.Font = new Font("Segoe UI", 9.5F);
        txtFullName.ForeColor = Color.FromArgb(51, 104, 160);
        txtFullName.Hint = "Enter full name";
        txtFullName.Location = new Point(0, 36);
        txtFullName.Margin = new Padding(0, 2, 0, 4);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(320, 34);
        txtFullName.TabIndex = 1;
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPhone.ForeColor = Color.FromArgb(51, 104, 160);
        lblPhone.Location = new Point(0, 76);
        lblPhone.Margin = new Padding(0, 4, 0, 2);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(320, 18);
        lblPhone.TabIndex = 2;
        lblPhone.Text = "Phone Number * (e.g. 09171234567)";
        // 
        // txtPhone
        // 
        txtPhone.BackColor = Color.White;
        txtPhone.BaseColor = Color.White;
        txtPhone.BorderColorA = Color.FromArgb(102, 163, 191);
        txtPhone.BorderColorB = Color.FromArgb(200, 223, 219);
        txtPhone.Font = new Font("Segoe UI", 9.5F);
        txtPhone.ForeColor = Color.FromArgb(51, 104, 160);
        txtPhone.Hint = "09XXXXXXXXX";
        txtPhone.Location = new Point(0, 98);
        txtPhone.Margin = new Padding(0, 2, 0, 4);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(320, 34);
        txtPhone.TabIndex = 3;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEmail.ForeColor = Color.FromArgb(51, 104, 160);
        lblEmail.Location = new Point(0, 138);
        lblEmail.Margin = new Padding(0, 4, 0, 2);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(320, 18);
        lblEmail.TabIndex = 4;
        lblEmail.Text = "Email Address (Optional)";
        // 
        // txtEmail
        // 
        txtEmail.BackColor = Color.White;
        txtEmail.BaseColor = Color.White;
        txtEmail.BorderColorA = Color.FromArgb(102, 163, 191);
        txtEmail.BorderColorB = Color.FromArgb(200, 223, 219);
        txtEmail.Font = new Font("Segoe UI", 9.5F);
        txtEmail.ForeColor = Color.FromArgb(51, 104, 160);
        txtEmail.Hint = "email@example.com";
        txtEmail.Location = new Point(0, 160);
        txtEmail.Margin = new Padding(0, 2, 0, 4);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(320, 34);
        txtEmail.TabIndex = 5;
        // 
        // lblAddress
        // 
        lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblAddress.ForeColor = Color.FromArgb(51, 104, 160);
        lblAddress.Location = new Point(0, 200);
        lblAddress.Margin = new Padding(0, 4, 0, 2);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(320, 18);
        lblAddress.TabIndex = 6;
        lblAddress.Text = "Complete Address (Optional)";
        // 
        // txtAddress
        // 
        txtAddress.BackColor = Color.White;
        txtAddress.BaseColor = Color.White;
        txtAddress.BorderColorA = Color.FromArgb(102, 163, 191);
        txtAddress.BorderColorB = Color.FromArgb(200, 223, 219);
        txtAddress.Font = new Font("Segoe UI", 9.5F);
        txtAddress.ForeColor = Color.FromArgb(51, 104, 160);
        txtAddress.Hint = "House No., Street, City";
        txtAddress.Location = new Point(0, 222);
        txtAddress.Margin = new Padding(0, 2, 0, 4);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(320, 34);
        txtAddress.TabIndex = 7;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 9F);
        lblError.ForeColor = Color.FromArgb(200, 50, 50);
        lblError.Location = new Point(0, 262);
        lblError.Name = "lblError";
        lblError.Size = new Size(320, 30);
        lblError.TabIndex = 8;
        lblError.Visible = false;
        // 
        // flpButtons
        // 
        flpButtons.Controls.Add(btnSave);
        flpButtons.Controls.Add(btnClear);
        flpButtons.Controls.Add(btnSelect);
        flpButtons.Location = new Point(0, 296);
        flpButtons.Name = "flpButtons";
        flpButtons.Size = new Size(320, 130);
        flpButtons.TabIndex = 9;
        // 
        // btnSave
        // 
        btnSave.ButtonType = HopeButtonType.Primary;
        btnSave.PrimaryColor = Color.FromArgb(51, 104, 160);
        btnSave.TextColor = Color.FromArgb(242, 239, 231);
        btnSave.HoverTextColor = Color.White;
        btnSave.Cursor = Cursors.Hand;
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.Location = new Point(3, 3);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(150, 40);
        btnSave.TabIndex = 0;
        btnSave.Text = "Save Customer";
        btnSave.Click += btnSave_Click;
        // 
        // btnClear
        // 
        btnClear.ButtonType = HopeButtonType.Default;
        btnClear.DefaultColor = Color.FromArgb(200, 223, 219);
        btnClear.BorderColor = Color.FromArgb(102, 163, 191);
        btnClear.TextColor = Color.FromArgb(51, 104, 160);
        btnClear.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnClear.Cursor = Cursors.Hand;
        btnClear.Font = new Font("Segoe UI", 9.5F);
        btnClear.Location = new Point(159, 3);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(150, 40);
        btnClear.TabIndex = 1;
        btnClear.Text = "↺ Clear";
        btnClear.Click += btnClear_Click;
        // 
        // btnSelect
        // 
        btnSelect.ButtonType = HopeButtonType.Primary;
        btnSelect.PrimaryColor = Color.FromArgb(102, 163, 191);
        btnSelect.TextColor = Color.White;
        btnSelect.HoverTextColor = Color.White;
        btnSelect.Cursor = Cursors.Hand;
        btnSelect.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSelect.Location = new Point(3, 49);
        btnSelect.Margin = new Padding(3, 6, 3, 3);
        btnSelect.Name = "btnSelect";
        btnSelect.Size = new Size(306, 40);
        btnSelect.TabIndex = 2;
        btnSelect.Text = "Select for Current Order";
        btnSelect.Visible = false;
        btnSelect.Click += btnSelect_Click;
        // 
        // lblFormTitle
        // 
        lblFormTitle.Dock = DockStyle.Top;
        lblFormTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblFormTitle.ForeColor = Color.FromArgb(51, 104, 160);
        lblFormTitle.Location = new Point(20, 20);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(340, 35);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "New Customer";
        // 
        // FrmCustomerRegistration
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(242, 239, 231);
        ClientSize = new Size(1000, 640);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(51, 104, 160);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmCustomerRegistration";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Customer Management";
        pnlHeader.ResumeLayout(false);
        pnlContainer.ResumeLayout(false);
        pnlRight.ResumeLayout(false);
        pnlGridContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
        pnlSearchBar.ResumeLayout(false);
        pnlLeftCard.ResumeLayout(false);
        flpForm.ResumeLayout(false);
        flpButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblTitle;
    private HopeButton btnClose;
    private Panel pnlContainer;
    private Panel pnlLeftCard;
    private Label lblFormTitle;
    private FlowLayoutPanel flpForm;
    private Label lblFullName;
    private HopeTextBox txtFullName;
    private Label lblPhone;
    private HopeTextBox txtPhone;
    private Label lblEmail;
    private HopeTextBox txtEmail;
    private Label lblAddress;
    private HopeTextBox txtAddress;
    private Label lblError;
    private FlowLayoutPanel flpButtons;
    private HopeButton btnSave;
    private HopeButton btnClear;
    private HopeButton btnSelect;
    private Panel pnlRight;
    private Panel pnlSearchBar;
    private Label lblSearchIcon;
    private HopeTextBox txtSearch;
    private HopeButton btnArchive;
    private Panel pnlGridContainer;
    private DataGridView dgvCustomers;
}
