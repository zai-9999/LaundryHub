using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Staff;

partial class FrmNewOrder
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
        lblFormTitle = new Label();
        lblSecCustomer = new Label();
        lblSearchPrompt = new Label();
        txtSearch = new HopeTextBox();
        btnNewCustomer = new HopeButton();
        lblSelectedCustomer = new Label();
        lstCustomers = new ListBox();
        lblSecService = new Label();
        lblServicePrompt = new Label();
        lblCategoryPrompt = new Label();
        cmbCategory = new ComboBox();
        cmbService = new ComboBox();
        lblWeightPrompt = new Label();
        lblLoadsPrompt = new Label();
        cmbLoadSize = new ComboBox();
        nudLoads = new NumericUpDown();
        pnlPriceBox = new Panel();
        lblPriceBreakdown = new Label();
        lblPrice = new Label();
        lblSecPickup = new Label();
        lblPickupPrompt = new Label();
        dtpPickup = new DateTimePicker();
        lblError = new Label();
        btnSave = new HopeButton();
        btnCancel = new HopeButton();
        pnlPriceBox.SuspendLayout();
        SuspendLayout();
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblFormTitle.ForeColor = Color.FromArgb(75, 86, 148);
        lblFormTitle.Location = new Point(30, 18);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(130, 30);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "New Order";
        // 
        // lblSecCustomer
        // 
        lblSecCustomer.AutoSize = true;
        lblSecCustomer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        lblSecCustomer.ForeColor = Color.FromArgb(114, 136, 174);
        lblSecCustomer.Location = new Point(30, 52);
        lblSecCustomer.Name = "lblSecCustomer";
        lblSecCustomer.Size = new Size(74, 15);
        lblSecCustomer.TabIndex = 1;
        lblSecCustomer.Text = " Customer";
        // 
        // lblSearchPrompt
        // 
        lblSearchPrompt.AutoSize = true;
        lblSearchPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblSearchPrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblSearchPrompt.Location = new Point(30, 76);
        lblSearchPrompt.Name = "lblSearchPrompt";
        lblSearchPrompt.Size = new Size(140, 15);
        lblSearchPrompt.TabIndex = 2;
        lblSearchPrompt.Text = "Search by name or phone:";
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.White;
        txtSearch.BaseColor = Color.White;
        txtSearch.BorderColorA = Color.FromArgb(75, 86, 148);
        txtSearch.BorderColorB = Color.FromArgb(190, 196, 220);
        txtSearch.Font = new Font("Segoe UI", 9.5F);
        txtSearch.ForeColor = Color.FromArgb(75, 86, 148);
        txtSearch.Hint = "Search by name or phone...";
        txtSearch.Location = new Point(30, 100);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(335, 34);
        txtSearch.TabIndex = 3;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // btnNewCustomer
        // 
        btnNewCustomer.ButtonType = HopeButtonType.Default;
        btnNewCustomer.DefaultColor = Color.FromArgb(234, 224, 207);
        btnNewCustomer.BorderColor = Color.FromArgb(114, 136, 174);
        btnNewCustomer.TextColor = Color.FromArgb(75, 86, 148);
        btnNewCustomer.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnNewCustomer.Cursor = Cursors.Hand;
        btnNewCustomer.Font = new Font("Segoe UI", 9F);
        btnNewCustomer.Location = new Point(375, 100);
        btnNewCustomer.Name = "btnNewCustomer";
        btnNewCustomer.Size = new Size(95, 34);
        btnNewCustomer.TabIndex = 4;
        btnNewCustomer.Text = "+ New";
        btnNewCustomer.Click += btnNewCustomer_Click;
        // 
        // lblSelectedCustomer
        // 
        lblSelectedCustomer.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        lblSelectedCustomer.ForeColor = Color.FromArgb(74, 160, 120);
        lblSelectedCustomer.Location = new Point(30, 140);
        lblSelectedCustomer.Name = "lblSelectedCustomer";
        lblSelectedCustomer.Size = new Size(440, 20);
        lblSelectedCustomer.TabIndex = 5;
        lblSelectedCustomer.Text = "No customer selected";
        // 
        // lstCustomers
        // 
        lstCustomers.BackColor = Color.White;
        lstCustomers.BorderStyle = BorderStyle.FixedSingle;
        lstCustomers.Font = new Font("Segoe UI", 9F);
        lstCustomers.ForeColor = Color.FromArgb(75, 86, 148);
        lstCustomers.ItemHeight = 15;
        lstCustomers.Location = new Point(30, 136);
        lstCustomers.Name = "lstCustomers";
        lstCustomers.Size = new Size(440, 92);
        lstCustomers.TabIndex = 6;
        lstCustomers.Visible = false;
        lstCustomers.SelectedIndexChanged += lstCustomers_SelectedIndexChanged;
        // 
        // lblSecService
        // 
        lblSecService.AutoSize = true;
        lblSecService.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        lblSecService.ForeColor = Color.FromArgb(114, 136, 174);
        lblSecService.Location = new Point(30, 170);
        lblSecService.Name = "lblSecService";
        lblSecService.Size = new Size(117, 15);
        lblSecService.TabIndex = 7;
        lblSecService.Text = "Laundry Category & Service";
        // 
        // lblCategoryPrompt
        // 
        lblCategoryPrompt.AutoSize = true;
        lblCategoryPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCategoryPrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblCategoryPrompt.Location = new Point(30, 194);
        lblCategoryPrompt.Name = "lblCategoryPrompt";
        lblCategoryPrompt.Size = new Size(105, 15);
        lblCategoryPrompt.TabIndex = 8;
        lblCategoryPrompt.Text = "Laundry Category:";
        // 
        // cmbCategory
        // 
        cmbCategory.BackColor = Color.White;
        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategory.Font = new Font("Segoe UI", 10F);
        cmbCategory.ForeColor = Color.FromArgb(75, 86, 148);
        cmbCategory.FormattingEnabled = true;
        cmbCategory.Location = new Point(30, 218);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new Size(440, 25);
        cmbCategory.TabIndex = 9;
        cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
        // 
        // lblServicePrompt
        // 
        lblServicePrompt.AutoSize = true;
        lblServicePrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblServicePrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblServicePrompt.Location = new Point(30, 252);
        lblServicePrompt.Name = "lblServicePrompt";
        lblServicePrompt.Size = new Size(76, 15);
        lblServicePrompt.TabIndex = 10;
        lblServicePrompt.Text = "Service Type:";
        // 
        // cmbService
        // 
        cmbService.BackColor = Color.White;
        cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbService.Font = new Font("Segoe UI", 10F);
        cmbService.ForeColor = Color.FromArgb(75, 86, 148);
        cmbService.FormattingEnabled = true;
        cmbService.Location = new Point(30, 276);
        cmbService.Name = "cmbService";
        cmbService.Size = new Size(440, 25);
        cmbService.TabIndex = 11;
        cmbService.SelectedIndexChanged += cmbService_SelectedIndexChanged;
        // 
        // lblWeightPrompt
        // 
        lblWeightPrompt.AutoSize = true;
        lblWeightPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblWeightPrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblWeightPrompt.Location = new Point(30, 292);
        lblWeightPrompt.Name = "lblWeightPrompt";
        lblWeightPrompt.Size = new Size(75, 15);
        lblWeightPrompt.TabIndex = 12;
        lblWeightPrompt.Text = "Load Size:";
        // 
        // lblLoadsPrompt
        // 
        lblLoadsPrompt.AutoSize = true;
        lblLoadsPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblLoadsPrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblLoadsPrompt.Location = new Point(380, 292);
        lblLoadsPrompt.Name = "lblLoadsPrompt";
        lblLoadsPrompt.Size = new Size(75, 15);
        lblLoadsPrompt.TabIndex = 15;
        lblLoadsPrompt.Text = "No. of Loads:";
        // 
        // 
        // cmbLoadSize
        // 
        cmbLoadSize.BackColor = Color.White;
        cmbLoadSize.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbLoadSize.Font = new Font("Segoe UI", 10F);
        cmbLoadSize.ForeColor = Color.FromArgb(75, 86, 148);
        cmbLoadSize.FormattingEnabled = true;
        cmbLoadSize.Location = new Point(30, 314);
        cmbLoadSize.Name = "cmbLoadSize";
        cmbLoadSize.Size = new Size(340, 25);
        cmbLoadSize.TabIndex = 13;
        cmbLoadSize.SelectedIndexChanged += cmbLoadSize_SelectedIndexChanged;
        // 
        // nudLoads
        // 
        nudLoads.Font = new Font("Segoe UI", 10F);
        nudLoads.ForeColor = Color.FromArgb(75, 86, 148);
        nudLoads.Location = new Point(380, 314);
        nudLoads.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
        nudLoads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudLoads.Name = "nudLoads";
        nudLoads.Size = new Size(90, 25);
        nudLoads.TabIndex = 14;
        nudLoads.Value = new decimal(new int[] { 1, 0, 0, 0 });
        nudLoads.ValueChanged += nudLoads_ValueChanged;
        // 
        // pnlPriceBox
        // 
        pnlPriceBox.BackColor = Color.FromArgb(248, 245, 239);
        pnlPriceBox.Controls.Add(lblPriceBreakdown);
        pnlPriceBox.Controls.Add(lblPrice);
        pnlPriceBox.Location = new Point(30, 376);
        pnlPriceBox.Name = "pnlPriceBox";
        pnlPriceBox.Size = new Size(440, 80);
        pnlPriceBox.TabIndex = 14;
        pnlPriceBox.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 440, 80, 8));
        // 
        // lblPriceBreakdown
        // 
        lblPriceBreakdown.Font = new Font("Segoe UI", 8F);
        lblPriceBreakdown.ForeColor = Color.FromArgb(114, 136, 174);
        lblPriceBreakdown.Location = new Point(12, 52);
        lblPriceBreakdown.Name = "lblPriceBreakdown";
        lblPriceBreakdown.Size = new Size(420, 25);
        lblPriceBreakdown.TabIndex = 1;
        lblPriceBreakdown.Text = "Select a service and enter weight to compute.";
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblPrice.ForeColor = Color.FromArgb(75, 86, 148);
        lblPrice.Location = new Point(12, 5);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(106, 45);
        lblPrice.TabIndex = 0;
        lblPrice.Text = "0.00";
        // 
        // lblSecPickup
        // 
        lblSecPickup.AutoSize = true;
        lblSecPickup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        lblSecPickup.ForeColor = Color.FromArgb(114, 136, 174);
        lblSecPickup.Location = new Point(30, 464);
        lblSecPickup.Name = "lblSecPickup";
        lblSecPickup.Size = new Size(86, 15);
        lblSecPickup.TabIndex = 15;
        lblSecPickup.Text = " Pickup Date";
        // 
        // lblPickupPrompt
        // 
        lblPickupPrompt.AutoSize = true;
        lblPickupPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPickupPrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblPickupPrompt.Location = new Point(30, 488);
        lblPickupPrompt.Name = "lblPickupPrompt";
        lblPickupPrompt.Size = new Size(125, 15);
        lblPickupPrompt.TabIndex = 16;
        lblPickupPrompt.Text = "Expected pickup date:";
        // 
        // dtpPickup
        // 
        dtpPickup.Font = new Font("Segoe UI", 10F);
        dtpPickup.Location = new Point(30, 512);
        dtpPickup.Name = "dtpPickup";
        dtpPickup.Size = new Size(440, 25);
        dtpPickup.TabIndex = 17;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(184, 72, 88);
        lblError.Location = new Point(30, 544);
        lblError.Name = "lblError";
        lblError.Size = new Size(440, 18);
        lblError.TabIndex = 18;
        lblError.Visible = false;
        // 
        // btnSave
        // 
        btnSave.ButtonType = HopeButtonType.Primary;
        btnSave.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnSave.TextColor = Color.FromArgb(246, 242, 234);
        btnSave.HoverTextColor = Color.White;
        btnSave.Cursor = Cursors.Hand;
        btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSave.Location = new Point(30, 566);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(440, 42);
        btnSave.TabIndex = 19;
        btnSave.Text = "Save Order & View Invoice";
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.ButtonType = HopeButtonType.Default;
        btnCancel.DefaultColor = Color.FromArgb(234, 224, 207);
        btnCancel.BorderColor = Color.FromArgb(114, 136, 174);
        btnCancel.TextColor = Color.FromArgb(75, 86, 148);
        btnCancel.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.Font = new Font("Segoe UI", 9F);
        btnCancel.Location = new Point(30, 614);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(440, 34);
        btnCancel.TabIndex = 20;
        btnCancel.Text = "Cancel";
        btnCancel.Click += btnCancel_Click;
        // 
        // FrmNewOrder
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(246, 242, 234);
        ClientSize = new Size(520, 645);
        Controls.Add(lstCustomers);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(lblError);
        Controls.Add(dtpPickup);
        Controls.Add(lblPickupPrompt);
        Controls.Add(lblSecPickup);
        Controls.Add(pnlPriceBox);
        Controls.Add(lblLoadsPrompt);
        Controls.Add(nudLoads);
        Controls.Add(cmbLoadSize);
        Controls.Add(lblWeightPrompt);
        Controls.Add(cmbService);
        Controls.Add(cmbCategory);
        Controls.Add(lblCategoryPrompt);
        Controls.Add(lblServicePrompt);
        Controls.Add(lblSecService);
        Controls.Add(lblSelectedCustomer);
        Controls.Add(btnNewCustomer);
        Controls.Add(txtSearch);
        Controls.Add(lblSearchPrompt);
        Controls.Add(lblSecCustomer);
        Controls.Add(lblFormTitle);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(75, 86, 148);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmNewOrder";
        StartPosition = FormStartPosition.CenterParent;
        Text = "New Laundry Order";
        pnlPriceBox.ResumeLayout(false);
        pnlPriceBox.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblFormTitle;
    private Label lblSecCustomer;
    private Label lblSearchPrompt;
    private HopeTextBox txtSearch;
    private HopeButton btnNewCustomer;
    private Label lblSelectedCustomer;
    private ListBox lstCustomers;
    private Label lblSecService;
    private Label lblServicePrompt;
    private Label lblCategoryPrompt;
    private ComboBox cmbCategory;
    private ComboBox cmbService;
    private Label lblWeightPrompt;
    private ComboBox cmbLoadSize;
    private NumericUpDown nudLoads;
    private Label lblLoadsPrompt;
    private Panel pnlPriceBox;
    private Label lblPrice;
    private Label lblPriceBreakdown;
    private Label lblSecPickup;
    private Label lblPickupPrompt;
    private DateTimePicker dtpPickup;
    private Label lblError;
    private HopeButton btnSave;
    private HopeButton btnCancel;
}
