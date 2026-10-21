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
        cmbService = new ComboBox();
        lblWeightPrompt = new Label();
        txtWeight = new HopeTextBox();
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
        lblSecCustomer.Location = new Point(30, 56);
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
        txtSearch.Location = new Point(30, 94);
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
        btnNewCustomer.Location = new Point(375, 94);
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
        lblSelectedCustomer.Location = new Point(30, 134);
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
        lstCustomers.Location = new Point(30, 130);
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
        lblSecService.Location = new Point(30, 162);
        lblSecService.Name = "lblSecService";
        lblSecService.Size = new Size(117, 15);
        lblSecService.TabIndex = 7;
        lblSecService.Text = " Service & Weight";
        // 
        // lblServicePrompt
        // 
        lblServicePrompt.AutoSize = true;
        lblServicePrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblServicePrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblServicePrompt.Location = new Point(30, 184);
        lblServicePrompt.Name = "lblServicePrompt";
        lblServicePrompt.Size = new Size(76, 15);
        lblServicePrompt.TabIndex = 8;
        lblServicePrompt.Text = "Service Type:";
        // 
        // cmbService
        // 
        cmbService.BackColor = Color.White;
        cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbService.Font = new Font("Segoe UI", 10F);
        cmbService.ForeColor = Color.FromArgb(75, 86, 148);
        cmbService.FormattingEnabled = true;
        cmbService.Location = new Point(30, 202);
        cmbService.Name = "cmbService";
        cmbService.Size = new Size(440, 25);
        cmbService.TabIndex = 9;
        cmbService.SelectedIndexChanged += cmbService_SelectedIndexChanged;
        // 
        // lblWeightPrompt
        // 
        lblWeightPrompt.AutoSize = true;
        lblWeightPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblWeightPrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblWeightPrompt.Location = new Point(30, 238);
        lblWeightPrompt.Name = "lblWeightPrompt";
        lblWeightPrompt.Size = new Size(75, 15);
        lblWeightPrompt.TabIndex = 10;
        lblWeightPrompt.Text = "Weight (kg):";
        // 
        // txtWeight
        // 
        txtWeight.BackColor = Color.White;
        txtWeight.BaseColor = Color.FromArgb(246, 242, 234);
        txtWeight.BorderColorA = Color.FromArgb(75, 86, 148);
        txtWeight.BorderColorB = Color.FromArgb(190, 196, 220);
        txtWeight.Font = new Font("Segoe UI", 9.5F);
        txtWeight.ForeColor = Color.FromArgb(75, 86, 148);
        txtWeight.Hint = "e.g. 5.5";
        txtWeight.Location = new Point(30, 256);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(440, 34);
        txtWeight.TabIndex = 11;
        txtWeight.TextChanged += txtWeight_TextChanged;
        // 
        // pnlPriceBox
        // 
        pnlPriceBox.BackColor = Color.FromArgb(248, 245, 239);
        pnlPriceBox.Controls.Add(lblPriceBreakdown);
        pnlPriceBox.Controls.Add(lblPrice);
        pnlPriceBox.Location = new Point(30, 300);
        pnlPriceBox.Name = "pnlPriceBox";
        pnlPriceBox.Size = new Size(440, 80);
        pnlPriceBox.TabIndex = 12;
        pnlPriceBox.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 440, 80, 8));
        // 
        // lblPriceBreakdown
        // 
        lblPriceBreakdown.Font = new Font("Segoe UI", 8F);
        lblPriceBreakdown.ForeColor = Color.FromArgb(114, 136, 174);
        lblPriceBreakdown.Location = new Point(12, 47);
        lblPriceBreakdown.Name = "lblPriceBreakdown";
        lblPriceBreakdown.Size = new Size(420, 20);
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
        lblSecPickup.Location = new Point(30, 382);
        lblSecPickup.Name = "lblSecPickup";
        lblSecPickup.Size = new Size(86, 15);
        lblSecPickup.TabIndex = 13;
        lblSecPickup.Text = " Pickup Date";
        // 
        // lblPickupPrompt
        // 
        lblPickupPrompt.AutoSize = true;
        lblPickupPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPickupPrompt.ForeColor = Color.FromArgb(75, 86, 148);
        lblPickupPrompt.Location = new Point(30, 404);
        lblPickupPrompt.Name = "lblPickupPrompt";
        lblPickupPrompt.Size = new Size(125, 15);
        lblPickupPrompt.TabIndex = 14;
        lblPickupPrompt.Text = "Expected pickup date:";
        // 
        // dtpPickup
        // 
        dtpPickup.Font = new Font("Segoe UI", 10F);
        dtpPickup.Location = new Point(30, 422);
        dtpPickup.Name = "dtpPickup";
        dtpPickup.Size = new Size(440, 25);
        dtpPickup.TabIndex = 15;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(184, 72, 88);
        lblError.Location = new Point(30, 455);
        lblError.Name = "lblError";
        lblError.Size = new Size(440, 18);
        lblError.TabIndex = 16;
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
        btnSave.Location = new Point(30, 480);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(440, 42);
        btnSave.TabIndex = 17;
        btnSave.Text = "Save Order & Generate QR Ticket";
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
        btnCancel.Location = new Point(30, 528);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(440, 34);
        btnCancel.TabIndex = 18;
        btnCancel.Text = "Cancel";
        btnCancel.Click += btnCancel_Click;
        // 
        // FrmNewOrder
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(246, 242, 234);
        ClientSize = new Size(520, 585);
        Controls.Add(lstCustomers);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(lblError);
        Controls.Add(dtpPickup);
        Controls.Add(lblPickupPrompt);
        Controls.Add(lblSecPickup);
        Controls.Add(pnlPriceBox);
        Controls.Add(txtWeight);
        Controls.Add(lblWeightPrompt);
        Controls.Add(cmbService);
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
    private ComboBox cmbService;
    private Label lblWeightPrompt;
    private HopeTextBox txtWeight;
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
