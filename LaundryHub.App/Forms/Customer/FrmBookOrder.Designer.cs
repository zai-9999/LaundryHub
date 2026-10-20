using Panel = System.Windows.Forms.Panel;
using Button = System.Windows.Forms.Button;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Customer;

partial class FrmBookOrder
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
        pnlHeader = new Panel();
        lblTitle = new Label();
        lblSubtitle = new Label();
        btnCloseTop = new Button();
        pnlMainCard = new Panel();
        pnlPriceSummary = new Panel();
        lblPriceTitle = new Label();
        lblPriceRate = new Label();
        lblBillableWeight = new Label();
        lblTotalAmount = new Label();
        btnBookNow = new HopeButton();
        btnCancel = new HopeButton();
        lblError = new Label();
        txtNotes = new TextBox();
        lblNotes = new Label();
        dtpPickup = new DateTimePicker();
        lblPickup = new Label();
        pnlQuickWeight = new FlowLayoutPanel();
        btnWeight4 = new Button();
        btnWeight6 = new Button();
        btnWeight8 = new Button();
        btnWeight10 = new Button();
        txtWeight = new TextBox();
        lblWeight = new Label();
        lblServiceRateBadge = new Label();
        cmbServices = new ComboBox();
        lblService = new Label();
        pnlCustomerCard = new Panel();
        lblCustAddress = new Label();
        lblCustPhone = new Label();
        lblCustName = new Label();
        lblCustInfoTitle = new Label();
        pnlHeader.SuspendLayout();
        pnlMainCard.SuspendLayout();
        pnlPriceSummary.SuspendLayout();
        pnlQuickWeight.SuspendLayout();
        pnlCustomerCard.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(17, 24, 68);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSubtitle);
        pnlHeader.Controls.Add(btnCloseTop);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 12, 24, 12);
        pnlHeader.Size = new Size(620, 75);
        pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(20, 12);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(265, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Book Laundry Service";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9F);
        lblSubtitle.ForeColor = Color.FromArgb(234, 224, 207);
        lblSubtitle.Location = new Point(22, 44);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(335, 20);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Select your service and schedule a pickup or drop-off";
        // 
        // btnCloseTop
        // 
        btnCloseTop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCloseTop.BackColor = Color.Transparent;
        btnCloseTop.Cursor = Cursors.Hand;
        btnCloseTop.FlatAppearance.BorderSize = 0;
        btnCloseTop.FlatStyle = FlatStyle.Flat;
        btnCloseTop.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnCloseTop.ForeColor = Color.White;
        btnCloseTop.Location = new Point(570, 15);
        btnCloseTop.Name = "btnCloseTop";
        btnCloseTop.Size = new Size(35, 35);
        btnCloseTop.TabIndex = 2;
        btnCloseTop.Text = "✕";
        btnCloseTop.UseVisualStyleBackColor = false;
        btnCloseTop.Click += btnCancel_Click;
        // 
        // pnlMainCard
        // 
        pnlMainCard.BackColor = Color.White;
        pnlMainCard.Controls.Add(pnlPriceSummary);
        pnlMainCard.Controls.Add(btnBookNow);
        pnlMainCard.Controls.Add(btnCancel);
        pnlMainCard.Controls.Add(lblError);
        pnlMainCard.Controls.Add(txtNotes);
        pnlMainCard.Controls.Add(lblNotes);
        pnlMainCard.Controls.Add(dtpPickup);
        pnlMainCard.Controls.Add(lblPickup);
        pnlMainCard.Controls.Add(pnlQuickWeight);
        pnlMainCard.Controls.Add(txtWeight);
        pnlMainCard.Controls.Add(lblWeight);
        pnlMainCard.Controls.Add(lblServiceRateBadge);
        pnlMainCard.Controls.Add(cmbServices);
        pnlMainCard.Controls.Add(lblService);
        pnlMainCard.Controls.Add(pnlCustomerCard);
        pnlMainCard.Dock = DockStyle.Fill;
        pnlMainCard.Location = new Point(0, 75);
        pnlMainCard.Name = "pnlMainCard";
        pnlMainCard.Padding = new Padding(24);
        pnlMainCard.Size = new Size(620, 685);
        pnlMainCard.TabIndex = 1;
        // 
        // pnlPriceSummary
        // 
        pnlPriceSummary.BackColor = Color.FromArgb(248, 245, 239);
        pnlPriceSummary.BorderStyle = BorderStyle.FixedSingle;
        pnlPriceSummary.Controls.Add(lblPriceTitle);
        pnlPriceSummary.Controls.Add(lblPriceRate);
        pnlPriceSummary.Controls.Add(lblBillableWeight);
        pnlPriceSummary.Controls.Add(lblTotalAmount);
        pnlPriceSummary.Location = new Point(24, 495);
        pnlPriceSummary.Name = "pnlPriceSummary";
        pnlPriceSummary.Padding = new Padding(14);
        pnlPriceSummary.Size = new Size(572, 85);
        pnlPriceSummary.TabIndex = 10;
        // 
        // lblPriceTitle
        // 
        lblPriceTitle.AutoSize = true;
        lblPriceTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPriceTitle.ForeColor = Color.FromArgb(17, 24, 68);
        lblPriceTitle.Location = new Point(12, 10);
        lblPriceTitle.Name = "lblPriceTitle";
        lblPriceTitle.Size = new Size(130, 21);
        lblPriceTitle.TabIndex = 0;
        lblPriceTitle.Text = "Estimated Total:";
        // 
        // lblPriceRate
        // 
        lblPriceRate.AutoSize = true;
        lblPriceRate.Font = new Font("Segoe UI", 8.5F);
        lblPriceRate.ForeColor = Color.FromArgb(75, 86, 148);
        lblPriceRate.Location = new Point(14, 34);
        lblPriceRate.Name = "lblPriceRate";
        lblPriceRate.Size = new Size(135, 20);
        lblPriceRate.TabIndex = 1;
        lblPriceRate.Text = "Rate: ₱0.00 per kilo";
        // 
        // lblBillableWeight
        // 
        lblBillableWeight.AutoSize = true;
        lblBillableWeight.Font = new Font("Segoe UI", 8.5F);
        lblBillableWeight.ForeColor = Color.FromArgb(75, 86, 148);
        lblBillableWeight.Location = new Point(14, 55);
        lblBillableWeight.Name = "lblBillableWeight";
        lblBillableWeight.Size = new Size(140, 20);
        lblBillableWeight.TabIndex = 2;
        lblBillableWeight.Text = "Billed weight: 0.0 kg";
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTotalAmount.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.FromArgb(74, 160, 120);
        lblTotalAmount.Location = new Point(340, 15);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(215, 50);
        lblTotalAmount.TabIndex = 3;
        lblTotalAmount.Text = "₱0.00";
        lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnBookNow
        // 
        btnBookNow.BorderColor = Color.FromArgb(75, 86, 148);
        btnBookNow.ButtonType = HopeButtonType.Primary;
        btnBookNow.Cursor = Cursors.Hand;
        btnBookNow.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        btnBookNow.HoverTextColor = Color.White;
        btnBookNow.Location = new Point(24, 615);
        btnBookNow.Name = "btnBookNow";
        btnBookNow.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnBookNow.Size = new Size(380, 46);
        btnBookNow.TabIndex = 11;
        btnBookNow.Text = "Confirm & Book Laundry";
        btnBookNow.TextColor = Color.White;
        btnBookNow.Click += btnBookNow_Click;
        // 
        // btnCancel
        // 
        btnCancel.BorderColor = Color.FromArgb(114, 136, 174);
        btnCancel.ButtonType = HopeButtonType.Default;
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.DefaultColor = Color.FromArgb(246, 242, 234);
        btnCancel.Font = new Font("Segoe UI", 10F);
        btnCancel.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnCancel.Location = new Point(415, 615);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(181, 46);
        btnCancel.TabIndex = 12;
        btnCancel.Text = "Cancel";
        btnCancel.TextColor = Color.FromArgb(75, 86, 148);
        btnCancel.Click += btnCancel_Click;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 9F);
        lblError.ForeColor = Color.FromArgb(184, 72, 88);
        lblError.Location = new Point(24, 584);
        lblError.Name = "lblError";
        lblError.Size = new Size(572, 24);
        lblError.TabIndex = 13;
        lblError.TextAlign = ContentAlignment.MiddleLeft;
        lblError.Visible = false;
        // 
        // txtNotes
        // 
        txtNotes.Font = new Font("Segoe UI", 9.5F);
        txtNotes.Location = new Point(24, 430);
        txtNotes.Multiline = true;
        txtNotes.Name = "txtNotes";
        txtNotes.PlaceholderText = "e.g. Delicate fabric, separate colored clothes, mild detergent...";
        txtNotes.Size = new Size(572, 52);
        txtNotes.TabIndex = 9;
        // 
        // lblNotes
        // 
        lblNotes.AutoSize = true;
        lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblNotes.ForeColor = Color.FromArgb(75, 86, 148);
        lblNotes.Location = new Point(24, 405);
        lblNotes.Name = "lblNotes";
        lblNotes.Size = new Size(244, 20);
        lblNotes.TabIndex = 8;
        lblNotes.Text = "Special Instructions / Notes (opt.):";
        // 
        // dtpPickup
        // 
        dtpPickup.Font = new Font("Segoe UI", 10F);
        dtpPickup.Format = DateTimePickerFormat.Short;
        dtpPickup.Location = new Point(24, 360);
        dtpPickup.Name = "dtpPickup";
        dtpPickup.Size = new Size(572, 30);
        dtpPickup.TabIndex = 7;
        // 
        // lblPickup
        // 
        lblPickup.AutoSize = true;
        lblPickup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPickup.ForeColor = Color.FromArgb(75, 86, 148);
        lblPickup.Location = new Point(24, 335);
        lblPickup.Name = "lblPickup";
        lblPickup.Size = new Size(215, 20);
        lblPickup.TabIndex = 6;
        lblPickup.Text = "Target Ready / Pickup Date *:";
        // 
        // pnlQuickWeight
        // 
        pnlQuickWeight.Controls.Add(btnWeight4);
        pnlQuickWeight.Controls.Add(btnWeight6);
        pnlQuickWeight.Controls.Add(btnWeight8);
        pnlQuickWeight.Controls.Add(btnWeight10);
        pnlQuickWeight.Location = new Point(210, 282);
        pnlQuickWeight.Name = "pnlQuickWeight";
        pnlQuickWeight.Size = new Size(386, 42);
        pnlQuickWeight.TabIndex = 5;
        // 
        // btnWeight4
        // 
        btnWeight4.BackColor = Color.FromArgb(248, 245, 239);
        btnWeight4.Cursor = Cursors.Hand;
        btnWeight4.FlatAppearance.BorderColor = Color.FromArgb(234, 224, 207);
        btnWeight4.FlatStyle = FlatStyle.Flat;
        btnWeight4.Font = new Font("Segoe UI", 8.5F);
        btnWeight4.ForeColor = Color.FromArgb(17, 24, 68);
        btnWeight4.Location = new Point(3, 3);
        btnWeight4.Name = "btnWeight4";
        btnWeight4.Size = new Size(80, 32);
        btnWeight4.TabIndex = 0;
        btnWeight4.Text = "4.0 kg";
        btnWeight4.UseVisualStyleBackColor = false;
        btnWeight4.Click += btnQuickWeight_Click;
        // 
        // btnWeight6
        // 
        btnWeight6.BackColor = Color.FromArgb(248, 245, 239);
        btnWeight6.Cursor = Cursors.Hand;
        btnWeight6.FlatAppearance.BorderColor = Color.FromArgb(234, 224, 207);
        btnWeight6.FlatStyle = FlatStyle.Flat;
        btnWeight6.Font = new Font("Segoe UI", 8.5F);
        btnWeight6.ForeColor = Color.FromArgb(17, 24, 68);
        btnWeight6.Location = new Point(89, 3);
        btnWeight6.Name = "btnWeight6";
        btnWeight6.Size = new Size(80, 32);
        btnWeight6.TabIndex = 1;
        btnWeight6.Text = "6.0 kg";
        btnWeight6.UseVisualStyleBackColor = false;
        btnWeight6.Click += btnQuickWeight_Click;
        // 
        // btnWeight8
        // 
        btnWeight8.BackColor = Color.FromArgb(248, 245, 239);
        btnWeight8.Cursor = Cursors.Hand;
        btnWeight8.FlatAppearance.BorderColor = Color.FromArgb(234, 224, 207);
        btnWeight8.FlatStyle = FlatStyle.Flat;
        btnWeight8.Font = new Font("Segoe UI", 8.5F);
        btnWeight8.ForeColor = Color.FromArgb(17, 24, 68);
        btnWeight8.Location = new Point(175, 3);
        btnWeight8.Name = "btnWeight8";
        btnWeight8.Size = new Size(80, 32);
        btnWeight8.TabIndex = 2;
        btnWeight8.Text = "8.0 kg";
        btnWeight8.UseVisualStyleBackColor = false;
        btnWeight8.Click += btnQuickWeight_Click;
        // 
        // btnWeight10
        // 
        btnWeight10.BackColor = Color.FromArgb(248, 245, 239);
        btnWeight10.Cursor = Cursors.Hand;
        btnWeight10.FlatAppearance.BorderColor = Color.FromArgb(234, 224, 207);
        btnWeight10.FlatStyle = FlatStyle.Flat;
        btnWeight10.Font = new Font("Segoe UI", 8.5F);
        btnWeight10.ForeColor = Color.FromArgb(17, 24, 68);
        btnWeight10.Location = new Point(261, 3);
        btnWeight10.Name = "btnWeight10";
        btnWeight10.Size = new Size(80, 32);
        btnWeight10.TabIndex = 3;
        btnWeight10.Text = "10.0 kg";
        btnWeight10.UseVisualStyleBackColor = false;
        btnWeight10.Click += btnQuickWeight_Click;
        // 
        // txtWeight
        // 
        txtWeight.Font = new Font("Segoe UI", 10.5F);
        txtWeight.Location = new Point(24, 285);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(170, 31);
        txtWeight.TabIndex = 4;
        txtWeight.Text = "4.0";
        txtWeight.TextChanged += txtWeight_TextChanged;
        // 
        // lblWeight
        // 
        lblWeight.AutoSize = true;
        lblWeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblWeight.ForeColor = Color.FromArgb(75, 86, 148);
        lblWeight.Location = new Point(24, 260);
        lblWeight.Name = "lblWeight";
        lblWeight.Size = new Size(198, 20);
        lblWeight.TabIndex = 3;
        lblWeight.Text = "Estimated Laundry Weight *:";
        // 
        // lblServiceRateBadge
        // 
        lblServiceRateBadge.AutoSize = true;
        lblServiceRateBadge.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblServiceRateBadge.ForeColor = Color.FromArgb(74, 160, 120);
        lblServiceRateBadge.Location = new Point(24, 228);
        lblServiceRateBadge.Name = "lblServiceRateBadge";
        lblServiceRateBadge.Size = new Size(185, 20);
        lblServiceRateBadge.TabIndex = 2;
        lblServiceRateBadge.Text = "Rate: ₱65.00/kg (Min 4 kg)";
        // 
        // cmbServices
        // 
        cmbServices.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbServices.Font = new Font("Segoe UI", 10.5F);
        cmbServices.FormattingEnabled = true;
        cmbServices.Location = new Point(24, 190);
        cmbServices.Name = "cmbServices";
        cmbServices.Size = new Size(572, 31);
        cmbServices.TabIndex = 1;
        cmbServices.SelectedIndexChanged += cmbServices_SelectedIndexChanged;
        // 
        // lblService
        // 
        lblService.AutoSize = true;
        lblService.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblService.ForeColor = Color.FromArgb(75, 86, 148);
        lblService.Location = new Point(24, 165);
        lblService.Name = "lblService";
        lblService.Size = new Size(167, 20);
        lblService.TabIndex = 0;
        lblService.Text = "Select Laundry Service *:";
        // 
        // pnlCustomerCard
        // 
        pnlCustomerCard.BackColor = Color.FromArgb(248, 245, 239);
        pnlCustomerCard.BorderStyle = BorderStyle.FixedSingle;
        pnlCustomerCard.Controls.Add(lblCustAddress);
        pnlCustomerCard.Controls.Add(lblCustPhone);
        pnlCustomerCard.Controls.Add(lblCustName);
        pnlCustomerCard.Controls.Add(lblCustInfoTitle);
        pnlCustomerCard.Location = new Point(24, 20);
        pnlCustomerCard.Name = "pnlCustomerCard";
        pnlCustomerCard.Padding = new Padding(12);
        pnlCustomerCard.Size = new Size(572, 130);
        pnlCustomerCard.TabIndex = 0;
        // 
        // lblCustAddress
        // 
        lblCustAddress.Font = new Font("Segoe UI", 9F);
        lblCustAddress.ForeColor = Color.FromArgb(75, 86, 148);
        lblCustAddress.Location = new Point(14, 88);
        lblCustAddress.Name = "lblCustAddress";
        lblCustAddress.Size = new Size(540, 28);
        lblCustAddress.TabIndex = 3;
        lblCustAddress.Text = "📍 Address: Not specified";
        // 
        // lblCustPhone
        // 
        lblCustPhone.AutoSize = true;
        lblCustPhone.Font = new Font("Segoe UI", 9F);
        lblCustPhone.ForeColor = Color.FromArgb(75, 86, 148);
        lblCustPhone.Location = new Point(14, 62);
        lblCustPhone.Name = "lblCustPhone";
        lblCustPhone.Size = new Size(116, 20);
        lblCustPhone.TabIndex = 2;
        lblCustPhone.Text = "📞 Phone: —";
        // 
        // lblCustName
        // 
        lblCustName.AutoSize = true;
        lblCustName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblCustName.ForeColor = Color.FromArgb(17, 24, 68);
        lblCustName.Location = new Point(14, 36);
        lblCustName.Name = "lblCustName";
        lblCustName.Size = new Size(147, 21);
        lblCustName.TabIndex = 1;
        lblCustName.Text = "👤 Customer Name";
        // 
        // lblCustInfoTitle
        // 
        lblCustInfoTitle.AutoSize = true;
        lblCustInfoTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCustInfoTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblCustInfoTitle.Location = new Point(12, 10);
        lblCustInfoTitle.Name = "lblCustInfoTitle";
        lblCustInfoTitle.Size = new Size(174, 20);
        lblCustInfoTitle.TabIndex = 0;
        lblCustInfoTitle.Text = "CUSTOMER ACCOUNT";
        // 
        // FrmBookOrder
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(620, 760);
        Controls.Add(pnlMainCard);
        Controls.Add(pnlHeader);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmBookOrder";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub – Book Laundry Service";
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlMainCard.ResumeLayout(false);
        pnlMainCard.PerformLayout();
        pnlPriceSummary.ResumeLayout(false);
        pnlPriceSummary.PerformLayout();
        pnlQuickWeight.ResumeLayout(false);
        pnlCustomerCard.ResumeLayout(false);
        pnlCustomerCard.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblTitle;
    private Label lblSubtitle;
    private Button btnCloseTop;
    private Panel pnlMainCard;
    private Panel pnlCustomerCard;
    private Label lblCustInfoTitle;
    private Label lblCustName;
    private Label lblCustPhone;
    private Label lblCustAddress;
    private Label lblService;
    private ComboBox cmbServices;
    private Label lblServiceRateBadge;
    private Label lblWeight;
    private TextBox txtWeight;
    private FlowLayoutPanel pnlQuickWeight;
    private Button btnWeight4;
    private Button btnWeight6;
    private Button btnWeight8;
    private Button btnWeight10;
    private Label lblPickup;
    private DateTimePicker dtpPickup;
    private Label lblNotes;
    private TextBox txtNotes;
    private Panel pnlPriceSummary;
    private Label lblPriceTitle;
    private Label lblPriceRate;
    private Label lblBillableWeight;
    private Label lblTotalAmount;
    private Label lblError;
    private HopeButton btnBookNow;
    private HopeButton btnCancel;
}
