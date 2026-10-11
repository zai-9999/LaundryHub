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
        txtSearch = new TextBox();
        btnNewCustomer = new Button();
        lblSelectedCustomer = new Label();
        lstCustomers = new ListBox();
        lblSecService = new Label();
        lblServicePrompt = new Label();
        cmbService = new ComboBox();
        lblWeightPrompt = new Label();
        txtWeight = new TextBox();
        pnlPriceBox = new Panel();
        lblPriceBreakdown = new Label();
        lblPrice = new Label();
        lblSecPickup = new Label();
        lblPickupPrompt = new Label();
        dtpPickup = new DateTimePicker();
        lblError = new Label();
        btnSave = new Button();
        btnCancel = new Button();
        pnlPriceBox.SuspendLayout();
        SuspendLayout();
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblFormTitle.ForeColor = Color.White;
        lblFormTitle.Location = new Point(30, 18);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(128, 30);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "New Order";
        // 
        // lblSecCustomer
        // 
        lblSecCustomer.AutoSize = true;
        lblSecCustomer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        lblSecCustomer.ForeColor = Color.FromArgb(96, 165, 250);
        lblSecCustomer.Location = new Point(30, 58);
        lblSecCustomer.Name = "lblSecCustomer";
        lblSecCustomer.Size = new Size(74, 15);
        lblSecCustomer.TabIndex = 1;
        lblSecCustomer.Text = "── Customer";
        // 
        // lblSearchPrompt
        // 
        lblSearchPrompt.AutoSize = true;
        lblSearchPrompt.Font = new Font("Segoe UI", 8.5F);
        lblSearchPrompt.ForeColor = Color.FromArgb(148, 163, 184);
        lblSearchPrompt.Location = new Point(30, 80);
        lblSearchPrompt.Name = "lblSearchPrompt";
        lblSearchPrompt.Size = new Size(134, 15);
        lblSearchPrompt.TabIndex = 2;
        lblSearchPrompt.Text = "Search by name or phone:";
        // 
        // txtSearch
        // 
        txtSearch.BackColor = Color.FromArgb(30, 41, 59);
        txtSearch.BorderStyle = BorderStyle.FixedSingle;
        txtSearch.Font = new Font("Segoe UI", 10F);
        txtSearch.ForeColor = Color.White;
        txtSearch.Location = new Point(30, 98);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(340, 25);
        txtSearch.TabIndex = 3;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // btnNewCustomer
        // 
        btnNewCustomer.BackColor = Color.FromArgb(15, 118, 110);
        btnNewCustomer.Cursor = Cursors.Hand;
        btnNewCustomer.FlatAppearance.BorderSize = 0;
        btnNewCustomer.FlatStyle = FlatStyle.Flat;
        btnNewCustomer.Font = new Font("Segoe UI", 8.5F);
        btnNewCustomer.ForeColor = Color.White;
        btnNewCustomer.Location = new Point(378, 98);
        btnNewCustomer.Name = "btnNewCustomer";
        btnNewCustomer.Size = new Size(92, 25);
        btnNewCustomer.TabIndex = 4;
        btnNewCustomer.Text = "+ New";
        btnNewCustomer.UseVisualStyleBackColor = false;
        btnNewCustomer.Click += btnNewCustomer_Click;
        // 
        // lblSelectedCustomer
        // 
        lblSelectedCustomer.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        lblSelectedCustomer.ForeColor = Color.FromArgb(100, 116, 139);
        lblSelectedCustomer.Location = new Point(30, 132);
        lblSelectedCustomer.Name = "lblSelectedCustomer";
        lblSelectedCustomer.Size = new Size(440, 20);
        lblSelectedCustomer.TabIndex = 5;
        lblSelectedCustomer.Text = "No customer selected";
        // 
        // lstCustomers
        // 
        lstCustomers.BackColor = Color.FromArgb(30, 41, 59);
        lstCustomers.BorderStyle = BorderStyle.FixedSingle;
        lstCustomers.Font = new Font("Segoe UI", 9F);
        lstCustomers.ForeColor = Color.White;
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
        lblSecService.ForeColor = Color.FromArgb(96, 165, 250);
        lblSecService.Location = new Point(30, 165);
        lblSecService.Name = "lblSecService";
        lblSecService.Size = new Size(117, 15);
        lblSecService.TabIndex = 7;
        lblSecService.Text = "── Service & Weight";
        // 
        // lblServicePrompt
        // 
        lblServicePrompt.AutoSize = true;
        lblServicePrompt.Font = new Font("Segoe UI", 8.5F);
        lblServicePrompt.ForeColor = Color.FromArgb(148, 163, 184);
        lblServicePrompt.Location = new Point(30, 187);
        lblServicePrompt.Name = "lblServicePrompt";
        lblServicePrompt.Size = new Size(74, 15);
        lblServicePrompt.TabIndex = 8;
        lblServicePrompt.Text = "Service Type:";
        // 
        // cmbService
        // 
        cmbService.BackColor = Color.FromArgb(30, 41, 59);
        cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbService.FlatStyle = FlatStyle.Flat;
        cmbService.Font = new Font("Segoe UI", 10F);
        cmbService.ForeColor = Color.White;
        cmbService.FormattingEnabled = true;
        cmbService.Location = new Point(30, 205);
        cmbService.Name = "cmbService";
        cmbService.Size = new Size(440, 25);
        cmbService.TabIndex = 9;
        cmbService.SelectedIndexChanged += cmbService_SelectedIndexChanged;
        // 
        // lblWeightPrompt
        // 
        lblWeightPrompt.AutoSize = true;
        lblWeightPrompt.Font = new Font("Segoe UI", 8.5F);
        lblWeightPrompt.ForeColor = Color.FromArgb(148, 163, 184);
        lblWeightPrompt.Location = new Point(30, 245);
        lblWeightPrompt.Name = "lblWeightPrompt";
        lblWeightPrompt.Size = new Size(73, 15);
        lblWeightPrompt.TabIndex = 10;
        lblWeightPrompt.Text = "Weight (kg):";
        // 
        // txtWeight
        // 
        txtWeight.BackColor = Color.FromArgb(30, 41, 59);
        txtWeight.BorderStyle = BorderStyle.FixedSingle;
        txtWeight.Font = new Font("Segoe UI", 10F);
        txtWeight.ForeColor = Color.White;
        txtWeight.Location = new Point(30, 263);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(440, 25);
        txtWeight.TabIndex = 11;
        txtWeight.TextChanged += txtWeight_TextChanged;
        // 
        // pnlPriceBox
        // 
        pnlPriceBox.BackColor = Color.FromArgb(30, 41, 59);
        pnlPriceBox.Controls.Add(lblPriceBreakdown);
        pnlPriceBox.Controls.Add(lblPrice);
        pnlPriceBox.Location = new Point(30, 303);
        pnlPriceBox.Name = "pnlPriceBox";
        pnlPriceBox.Size = new Size(440, 70);
        pnlPriceBox.TabIndex = 12;
        // 
        // lblPriceBreakdown
        // 
        lblPriceBreakdown.Font = new Font("Segoe UI", 8F);
        lblPriceBreakdown.ForeColor = Color.FromArgb(100, 116, 139);
        lblPriceBreakdown.Location = new Point(12, 45);
        lblPriceBreakdown.Name = "lblPriceBreakdown";
        lblPriceBreakdown.Size = new Size(420, 20);
        lblPriceBreakdown.TabIndex = 1;
        lblPriceBreakdown.Text = "Select a service and enter weight to compute.";
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblPrice.ForeColor = Color.FromArgb(52, 211, 153);
        lblPrice.Location = new Point(12, 5);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(106, 45);
        lblPrice.TabIndex = 0;
        lblPrice.Text = "₱0.00";
        // 
        // lblSecPickup
        // 
        lblSecPickup.AutoSize = true;
        lblSecPickup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        lblSecPickup.ForeColor = Color.FromArgb(96, 165, 250);
        lblSecPickup.Location = new Point(30, 382);
        lblSecPickup.Name = "lblSecPickup";
        lblSecPickup.Size = new Size(86, 15);
        lblSecPickup.TabIndex = 13;
        lblSecPickup.Text = "── Pickup Date";
        // 
        // lblPickupPrompt
        // 
        lblPickupPrompt.AutoSize = true;
        lblPickupPrompt.Font = new Font("Segoe UI", 8.5F);
        lblPickupPrompt.ForeColor = Color.FromArgb(148, 163, 184);
        lblPickupPrompt.Location = new Point(30, 404);
        lblPickupPrompt.Name = "lblPickupPrompt";
        lblPickupPrompt.Size = new Size(120, 15);
        lblPickupPrompt.TabIndex = 14;
        lblPickupPrompt.Text = "Expected pickup date:";
        // 
        // dtpPickup
        // 
        dtpPickup.CalendarMonthBackground = Color.FromArgb(30, 41, 59);
        dtpPickup.Font = new Font("Segoe UI", 10F);
        dtpPickup.Location = new Point(30, 422);
        dtpPickup.Name = "dtpPickup";
        dtpPickup.Size = new Size(440, 25);
        dtpPickup.TabIndex = 15;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(248, 113, 113);
        lblError.Location = new Point(30, 458);
        lblError.Name = "lblError";
        lblError.Size = new Size(440, 18);
        lblError.TabIndex = 16;
        lblError.Visible = false;
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.Cursor = Cursors.Hand;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(30, 485);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(440, 44);
        btnSave.TabIndex = 17;
        btnSave.Text = "💾  Save Order & Generate QR Ticket";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = Color.Transparent;
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI", 9F);
        btnCancel.ForeColor = Color.FromArgb(100, 116, 139);
        btnCancel.Location = new Point(30, 538);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(440, 32);
        btnCancel.TabIndex = 18;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;
        // 
        // FrmNewOrder
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(520, 595);
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
        ForeColor = Color.White;
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
    private TextBox txtSearch;
    private Button btnNewCustomer;
    private Label lblSelectedCustomer;
    private ListBox lstCustomers;
    private Label lblSecService;
    private Label lblServicePrompt;
    private ComboBox cmbService;
    private Label lblWeightPrompt;
    private TextBox txtWeight;
    private Panel pnlPriceBox;
    private Label lblPrice;
    private Label lblPriceBreakdown;
    private Label lblSecPickup;
    private Label lblPickupPrompt;
    private DateTimePicker dtpPickup;
    private Label lblError;
    private Button btnSave;
    private Button btnCancel;
}
