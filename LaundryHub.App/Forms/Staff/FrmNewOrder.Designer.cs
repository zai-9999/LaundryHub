using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using FlowLayoutPanel = System.Windows.Forms.FlowLayoutPanel;
using NumericUpDown = System.Windows.Forms.NumericUpDown;
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
        var indigo = Color.FromArgb(75, 86, 148);
        var slate = Color.FromArgb(114, 136, 174);

        pnlCard = new Panel();
        flowMain = new FlowLayoutPanel();
        lblFormTitle = new Label();
        lblSecCustomer = new Label();
        pnlSearchRow = new Panel();
        txtSearch = new HopeTextBox();
        btnNewCustomer = new HopeButton();
        lblSelectedCustomer = new Label();
        lstCustomers = new ListBox();
        lblSecCategory = new Label();
        flowCategory = new FlowLayoutPanel();
        lblSecService = new Label();
        flowService = new FlowLayoutPanel();
        lblSecSize = new Label();
        flowSize = new FlowLayoutPanel();
        pnlQtyPickup = new Panel();
        lblQtyPrompt = new Label();
        nudLoads = new NumericUpDown();
        lblPickupPrompt = new Label();
        dtpPickup = new DateTimePicker();
        pnlPriceBox = new Panel();
        lblPriceBreakdown = new Label();
        lblPrice = new Label();
        lblError = new Label();
        btnSave = new HopeButton();
        btnCancel = new HopeButton();
        pnlCard.SuspendLayout();
        flowMain.SuspendLayout();
        pnlSearchRow.SuspendLayout();
        pnlQtyPickup.SuspendLayout();
        pnlPriceBox.SuspendLayout();
        SuspendLayout();
        //
        // pnlCard (white rounded card that holds everything)
        //
        pnlCard.BackColor = Color.White;
        pnlCard.Controls.Add(lstCustomers);
        pnlCard.Controls.Add(flowMain);
        pnlCard.Location = new Point(24, 24);
        pnlCard.Name = "pnlCard";
        pnlCard.Size = new Size(500, 700);
        //
        // flowMain (stacks every section top-to-bottom so nothing overlaps)
        //
        flowMain.AutoSize = true;
        flowMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flowMain.BackColor = Color.White;
        flowMain.FlowDirection = FlowDirection.TopDown;
        flowMain.WrapContents = false;
        flowMain.Location = new Point(30, 22);
        flowMain.Name = "flowMain";
        flowMain.Controls.Add(lblFormTitle);
        flowMain.Controls.Add(lblSecCustomer);
        flowMain.Controls.Add(pnlSearchRow);
        flowMain.Controls.Add(lblSelectedCustomer);
        flowMain.Controls.Add(lblSecCategory);
        flowMain.Controls.Add(flowCategory);
        flowMain.Controls.Add(lblSecService);
        flowMain.Controls.Add(flowService);
        flowMain.Controls.Add(lblSecSize);
        flowMain.Controls.Add(flowSize);
        flowMain.Controls.Add(pnlQtyPickup);
        flowMain.Controls.Add(pnlPriceBox);
        flowMain.Controls.Add(lblError);
        flowMain.Controls.Add(btnSave);
        flowMain.Controls.Add(btnCancel);
        //
        // lblFormTitle
        //
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblFormTitle.ForeColor = indigo;
        lblFormTitle.Margin = new Padding(0, 0, 0, 8);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Text = "New Order";
        //
        // lblSecCustomer
        //
        lblSecCustomer.AutoSize = true;
        lblSecCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSecCustomer.ForeColor = indigo;
        lblSecCustomer.Margin = new Padding(0, 0, 0, 4);
        lblSecCustomer.Name = "lblSecCustomer";
        lblSecCustomer.Text = "Customer";
        //
        // pnlSearchRow
        //
        pnlSearchRow.BackColor = Color.White;
        pnlSearchRow.Controls.Add(txtSearch);
        pnlSearchRow.Controls.Add(btnNewCustomer);
        pnlSearchRow.Margin = new Padding(0, 0, 0, 2);
        pnlSearchRow.Name = "pnlSearchRow";
        pnlSearchRow.Size = new Size(440, 38);
        //
        // txtSearch
        //
        txtSearch.BackColor = Color.White;
        txtSearch.BaseColor = Color.White;
        txtSearch.BorderColorA = indigo;
        txtSearch.BorderColorB = Color.FromArgb(190, 196, 220);
        txtSearch.Font = new Font("Segoe UI", 9.5F);
        txtSearch.ForeColor = indigo;
        txtSearch.Hint = "Search by name or phone...";
        txtSearch.Location = new Point(0, 2);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(335, 34);
        txtSearch.TabIndex = 0;
        txtSearch.TextChanged += txtSearch_TextChanged;
        //
        // btnNewCustomer
        //
        btnNewCustomer.ButtonType = HopeButtonType.Default;
        btnNewCustomer.DefaultColor = Color.FromArgb(234, 224, 207);
        btnNewCustomer.BorderColor = slate;
        btnNewCustomer.TextColor = indigo;
        btnNewCustomer.HoverTextColor = indigo;
        btnNewCustomer.Cursor = Cursors.Hand;
        btnNewCustomer.Font = new Font("Segoe UI", 9F);
        btnNewCustomer.Location = new Point(345, 2);
        btnNewCustomer.Name = "btnNewCustomer";
        btnNewCustomer.Size = new Size(95, 34);
        btnNewCustomer.TabIndex = 1;
        btnNewCustomer.Text = "+ New";
        btnNewCustomer.Click += btnNewCustomer_Click;
        //
        // lblSelectedCustomer
        //
        lblSelectedCustomer.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        lblSelectedCustomer.ForeColor = Color.FromArgb(74, 160, 120);
        lblSelectedCustomer.Margin = new Padding(0, 0, 0, 10);
        lblSelectedCustomer.Name = "lblSelectedCustomer";
        lblSelectedCustomer.Size = new Size(440, 24);
        lblSelectedCustomer.Text = "No customer selected";
        lblSelectedCustomer.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lstCustomers (floats over the card under the search box)
        //
        lstCustomers.BackColor = Color.White;
        lstCustomers.BorderStyle = BorderStyle.FixedSingle;
        lstCustomers.Font = new Font("Segoe UI", 9F);
        lstCustomers.ForeColor = indigo;
        lstCustomers.Name = "lstCustomers";
        lstCustomers.Size = new Size(440, 92);
        lstCustomers.Visible = false;
        lstCustomers.SelectedIndexChanged += lstCustomers_SelectedIndexChanged;
        //
        // lblSecCategory
        //
        lblSecCategory.AutoSize = true;
        lblSecCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSecCategory.ForeColor = indigo;
        lblSecCategory.Margin = new Padding(0, 0, 0, 4);
        lblSecCategory.Name = "lblSecCategory";
        lblSecCategory.Text = "Laundry Category";
        //
        // flowCategory
        //
        ConfigureChipFlow(flowCategory, "flowCategory");
        //
        // lblSecService
        //
        lblSecService.AutoSize = true;
        lblSecService.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSecService.ForeColor = indigo;
        lblSecService.Margin = new Padding(0, 0, 0, 4);
        lblSecService.Name = "lblSecService";
        lblSecService.Text = "Service Type";
        //
        // flowService
        //
        ConfigureChipFlow(flowService, "flowService");
        //
        // lblSecSize
        //
        lblSecSize.AutoSize = true;
        lblSecSize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSecSize.ForeColor = indigo;
        lblSecSize.Margin = new Padding(0, 0, 0, 4);
        lblSecSize.Name = "lblSecSize";
        lblSecSize.Text = "Load Size  (weight is set automatically)";
        //
        // flowSize
        //
        ConfigureChipFlow(flowSize, "flowSize");
        flowSize.Margin = new Padding(0, 0, 0, 10);
        //
        // pnlQtyPickup (two columns: number of loads | pickup date)
        //
        pnlQtyPickup.BackColor = Color.White;
        pnlQtyPickup.Controls.Add(lblQtyPrompt);
        pnlQtyPickup.Controls.Add(nudLoads);
        pnlQtyPickup.Controls.Add(lblPickupPrompt);
        pnlQtyPickup.Controls.Add(dtpPickup);
        pnlQtyPickup.Margin = new Padding(0, 0, 0, 10);
        pnlQtyPickup.Name = "pnlQtyPickup";
        pnlQtyPickup.Size = new Size(440, 62);
        //
        // lblQtyPrompt
        //
        lblQtyPrompt.AutoSize = true;
        lblQtyPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblQtyPrompt.ForeColor = indigo;
        lblQtyPrompt.Location = new Point(0, 0);
        lblQtyPrompt.Name = "lblQtyPrompt";
        lblQtyPrompt.Text = "No. of Loads";
        //
        // nudLoads
        //
        nudLoads.Font = new Font("Segoe UI", 10F);
        nudLoads.ForeColor = indigo;
        nudLoads.Location = new Point(0, 26);
        nudLoads.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
        nudLoads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudLoads.Name = "nudLoads";
        nudLoads.Size = new Size(200, 29);
        nudLoads.TabIndex = 2;
        nudLoads.Value = new decimal(new int[] { 1, 0, 0, 0 });
        nudLoads.ValueChanged += nudLoads_ValueChanged;
        //
        // lblPickupPrompt
        //
        lblPickupPrompt.AutoSize = true;
        lblPickupPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPickupPrompt.ForeColor = indigo;
        lblPickupPrompt.Location = new Point(220, 0);
        lblPickupPrompt.Name = "lblPickupPrompt";
        lblPickupPrompt.Text = "Pickup Date";
        //
        // dtpPickup
        //
        dtpPickup.Font = new Font("Segoe UI", 10F);
        dtpPickup.Format = DateTimePickerFormat.Custom;
        dtpPickup.CustomFormat = "ddd, MMM d, yyyy";
        dtpPickup.Location = new Point(220, 26);
        dtpPickup.Name = "dtpPickup";
        dtpPickup.Size = new Size(220, 29);
        dtpPickup.TabIndex = 3;
        //
        // pnlPriceBox (rounded + bordered by UIThemeHelper)
        //
        pnlPriceBox.BackColor = Color.FromArgb(248, 245, 239);
        pnlPriceBox.Controls.Add(lblPriceBreakdown);
        pnlPriceBox.Controls.Add(lblPrice);
        pnlPriceBox.Margin = new Padding(0, 0, 0, 8);
        pnlPriceBox.Name = "pnlPriceBox";
        pnlPriceBox.Size = new Size(440, 84);
        //
        // lblPriceBreakdown
        //
        lblPriceBreakdown.Font = new Font("Segoe UI", 8F);
        lblPriceBreakdown.ForeColor = slate;
        lblPriceBreakdown.Location = new Point(14, 52);
        lblPriceBreakdown.Name = "lblPriceBreakdown";
        lblPriceBreakdown.Size = new Size(412, 24);
        lblPriceBreakdown.Text = "Select a service and load size to compute.";
        //
        // lblPrice
        //
        lblPrice.AutoSize = true;
        lblPrice.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblPrice.ForeColor = indigo;
        lblPrice.Location = new Point(12, 4);
        lblPrice.Name = "lblPrice";
        lblPrice.Text = "0.00";
        //
        // lblError
        //
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(184, 72, 88);
        lblError.Margin = new Padding(0, 0, 0, 6);
        lblError.Name = "lblError";
        lblError.Size = new Size(440, 22);
        lblError.Visible = false;
        //
        // btnSave
        //
        btnSave.ButtonType = HopeButtonType.Primary;
        btnSave.PrimaryColor = indigo;
        btnSave.TextColor = Color.FromArgb(246, 242, 234);
        btnSave.HoverTextColor = Color.White;
        btnSave.Cursor = Cursors.Hand;
        btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSave.Margin = new Padding(0, 0, 0, 8);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(440, 44);
        btnSave.Text = "Create Order";
        btnSave.Click += btnSave_Click;
        //
        // btnCancel
        //
        btnCancel.ButtonType = HopeButtonType.Default;
        btnCancel.DefaultColor = Color.FromArgb(234, 224, 207);
        btnCancel.BorderColor = slate;
        btnCancel.TextColor = indigo;
        btnCancel.HoverTextColor = indigo;
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.Font = new Font("Segoe UI", 9F);
        btnCancel.Margin = new Padding(0);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(440, 36);
        btnCancel.Text = "Cancel";
        btnCancel.Click += btnCancel_Click;
        //
        // FrmNewOrder
        //
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(246, 242, 234);
        ClientSize = new Size(548, 748);
        Controls.Add(pnlCard);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = indigo;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmNewOrder";
        StartPosition = FormStartPosition.CenterParent;
        Text = "New Laundry Order";
        pnlPriceBox.ResumeLayout(false);
        pnlPriceBox.PerformLayout();
        pnlQtyPickup.ResumeLayout(false);
        pnlQtyPickup.PerformLayout();
        pnlSearchRow.ResumeLayout(false);
        flowMain.ResumeLayout(false);
        flowMain.PerformLayout();
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ResumeLayout(false);
    }

    // Shared setup for the wrapping rows of selectable chips / cards.
    private static void ConfigureChipFlow(FlowLayoutPanel flow, string name)
    {
        flow.AutoSize = true;
        flow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flow.BackColor = Color.White;
        flow.FlowDirection = FlowDirection.LeftToRight;
        flow.WrapContents = true;
        flow.Margin = new Padding(0, 0, 0, 4);
        flow.MinimumSize = new Size(440, 0);
        flow.MaximumSize = new Size(440, 0);
        flow.Name = name;
    }

    #endregion

    private Panel pnlCard;
    private FlowLayoutPanel flowMain;
    private Label lblFormTitle;
    private Label lblSecCustomer;
    private Panel pnlSearchRow;
    private HopeTextBox txtSearch;
    private HopeButton btnNewCustomer;
    private Label lblSelectedCustomer;
    private ListBox lstCustomers;
    private Label lblSecCategory;
    private FlowLayoutPanel flowCategory;
    private Label lblSecService;
    private FlowLayoutPanel flowService;
    private Label lblSecSize;
    private FlowLayoutPanel flowSize;
    private Panel pnlQtyPickup;
    private Label lblQtyPrompt;
    private NumericUpDown nudLoads;
    private Label lblPickupPrompt;
    private DateTimePicker dtpPickup;
    private Panel pnlPriceBox;
    private Label lblPrice;
    private Label lblPriceBreakdown;
    private Label lblError;
    private HopeButton btnSave;
    private HopeButton btnCancel;
}
