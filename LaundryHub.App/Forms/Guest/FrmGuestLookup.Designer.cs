using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Guest;

partial class FrmGuestLookup
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
        pnlCard = new Panel();
        pnlResult = new Panel();
        tlpGrid = new TableLayoutPanel();
        lblHOrder = new Label();
        lblResultOrder = new Label();
        lblHCustomer = new Label();
        lblResultCustomer = new Label();
        lblHService = new Label();
        lblResultService = new Label();
        lblHAmount = new Label();
        lblResultTotal = new Label();
        lblHPayment = new Label();
        lblResultPayment = new Label();
        lblHPickup = new Label();
        lblResultPickup = new Label();
        pnlStep3 = new Panel();
        lblStep3 = new Label();
        pnlStep2 = new Panel();
        lblStep2 = new Label();
        pnlStep1 = new Panel();
        lblStep1 = new Label();
        pnlStep0 = new Panel();
        lblStep0 = new Label();
        lblTimelineHeader = new Label();
        btnBack = new HopeButton();
        btnLookup = new HopeButton();
        lnkPricing = new LinkLabel();
        lblError = new Label();
        txtPhoneLast4 = new HopeTextBox();
        lblPhone = new Label();
        txtOrderNumber = new HopeTextBox();
        lblOrder = new Label();
        lblSub = new Label();
        lblTitle = new Label();
        lblIcon = new Label();
        pnlCard.SuspendLayout();
        pnlResult.SuspendLayout();
        tlpGrid.SuspendLayout();
        pnlStep3.SuspendLayout();
        pnlStep2.SuspendLayout();
        pnlStep1.SuspendLayout();
        pnlStep0.SuspendLayout();
        SuspendLayout();
        // 
        // pnlCard
        // 
        pnlCard.BackColor = Color.White;
        pnlCard.Controls.Add(pnlResult);
        pnlCard.Controls.Add(btnBack);
        pnlCard.Controls.Add(btnLookup);
        pnlCard.Controls.Add(lnkPricing);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(txtPhoneLast4);
        pnlCard.Controls.Add(lblPhone);
        pnlCard.Controls.Add(txtOrderNumber);
        pnlCard.Controls.Add(lblOrder);
        pnlCard.Controls.Add(lblSub);
        pnlCard.Controls.Add(lblTitle);
        pnlCard.Controls.Add(lblIcon);
        pnlCard.Location = new Point(50, 30);
        pnlCard.Name = "pnlCard";
        pnlCard.Padding = new Padding(30);
        pnlCard.Size = new Size(580, 620);
        pnlCard.TabIndex = 0;
        pnlCard.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 580, 620, 40));
        // 
        // pnlResult
        // 
        pnlResult.BackColor = Color.White;
        pnlResult.Controls.Add(tlpGrid);
        pnlResult.Controls.Add(pnlStep3);
        pnlResult.Controls.Add(pnlStep2);
        pnlResult.Controls.Add(pnlStep1);
        pnlResult.Controls.Add(pnlStep0);
        pnlResult.Controls.Add(lblTimelineHeader);
        pnlResult.Location = new Point(30, 365);
        pnlResult.Name = "pnlResult";
        pnlResult.Padding = new Padding(15);
        pnlResult.Size = new Size(520, 255);
        pnlResult.TabIndex = 10;
        pnlResult.Visible = false;
        pnlResult.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 520, 255, 12));
        // 
        // tlpGrid
        // 
        tlpGrid.ColumnCount = 2;
        tlpGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tlpGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpGrid.Controls.Add(lblHOrder, 0, 0);
        tlpGrid.Controls.Add(lblResultOrder, 1, 0);
        tlpGrid.Controls.Add(lblHCustomer, 0, 1);
        tlpGrid.Controls.Add(lblResultCustomer, 1, 1);
        tlpGrid.Controls.Add(lblHService, 0, 2);
        tlpGrid.Controls.Add(lblResultService, 1, 2);
        tlpGrid.Controls.Add(lblHAmount, 0, 3);
        tlpGrid.Controls.Add(lblResultTotal, 1, 3);
        tlpGrid.Controls.Add(lblHPayment, 0, 4);
        tlpGrid.Controls.Add(lblResultPayment, 1, 4);
        tlpGrid.Controls.Add(lblHPickup, 0, 5);
        tlpGrid.Controls.Add(lblResultPickup, 1, 5);
        tlpGrid.Location = new Point(15, 80);
        tlpGrid.Name = "tlpGrid";
        tlpGrid.RowCount = 6;
        tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
        tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
        tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
        tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
        tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
        tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
        tlpGrid.Size = new Size(490, 160);
        tlpGrid.TabIndex = 5;
        // 
        // lblHOrder
        // 
        lblHOrder.Dock = DockStyle.Fill;
        lblHOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHOrder.ForeColor = Color.FromArgb(75, 86, 148);
        lblHOrder.Text = "Order #:";
        lblHOrder.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultOrder
        // 
        lblResultOrder.Dock = DockStyle.Fill;
        lblResultOrder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultOrder.ForeColor = Color.FromArgb(75, 86, 148);
        lblResultOrder.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHCustomer
        // 
        lblHCustomer.Dock = DockStyle.Fill;
        lblHCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHCustomer.ForeColor = Color.FromArgb(75, 86, 148);
        lblHCustomer.Text = "Customer:";
        lblHCustomer.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultCustomer
        // 
        lblResultCustomer.Dock = DockStyle.Fill;
        lblResultCustomer.Font = new Font("Segoe UI", 9.5F);
        lblResultCustomer.ForeColor = Color.FromArgb(75, 86, 148);
        lblResultCustomer.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHService
        // 
        lblHService.Dock = DockStyle.Fill;
        lblHService.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHService.ForeColor = Color.FromArgb(75, 86, 148);
        lblHService.Text = "Service:";
        lblHService.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultService
        // 
        lblResultService.Dock = DockStyle.Fill;
        lblResultService.Font = new Font("Segoe UI", 9.5F);
        lblResultService.ForeColor = Color.FromArgb(75, 86, 148);
        lblResultService.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHAmount
        // 
        lblHAmount.Dock = DockStyle.Fill;
        lblHAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHAmount.ForeColor = Color.FromArgb(75, 86, 148);
        lblHAmount.Text = "Total Amount:";
        lblHAmount.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultTotal
        // 
        lblResultTotal.Dock = DockStyle.Fill;
        lblResultTotal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultTotal.ForeColor = Color.FromArgb(75, 86, 148);
        lblResultTotal.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHPayment
        // 
        lblHPayment.Dock = DockStyle.Fill;
        lblHPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHPayment.ForeColor = Color.FromArgb(75, 86, 148);
        lblHPayment.Text = "Payment:";
        lblHPayment.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultPayment
        // 
        lblResultPayment.Dock = DockStyle.Fill;
        lblResultPayment.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultPayment.ForeColor = Color.FromArgb(75, 86, 148);
        lblResultPayment.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHPickup
        // 
        lblHPickup.Dock = DockStyle.Fill;
        lblHPickup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHPickup.ForeColor = Color.FromArgb(75, 86, 148);
        lblHPickup.Text = "Estimated Pickup:";
        lblHPickup.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultPickup
        // 
        lblResultPickup.Dock = DockStyle.Fill;
        lblResultPickup.Font = new Font("Segoe UI", 9.5F);
        lblResultPickup.ForeColor = Color.FromArgb(75, 86, 148);
        lblResultPickup.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlStep3
        // 
        pnlStep3.BackColor = Color.FromArgb(234, 224, 207);
        pnlStep3.Controls.Add(lblStep3);
        pnlStep3.Location = new Point(384, 35);
        pnlStep3.Name = "pnlStep3";
        pnlStep3.Size = new Size(118, 36);
        pnlStep3.TabIndex = 4;
        pnlStep3.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 118, 36, 6));
        // 
        // lblStep3
        // 
        lblStep3.Dock = DockStyle.Fill;
        lblStep3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStep3.ForeColor = Color.FromArgb(75, 86, 148);
        lblStep3.Location = new Point(0, 0);
        lblStep3.Name = "lblStep3";
        lblStep3.Size = new Size(118, 36);
        lblStep3.TabIndex = 0;
        lblStep3.Text = " Claimed";
        lblStep3.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlStep2
        // 
        pnlStep2.BackColor = Color.FromArgb(234, 224, 207);
        pnlStep2.Controls.Add(lblStep2);
        pnlStep2.Location = new Point(261, 35);
        pnlStep2.Name = "pnlStep2";
        pnlStep2.Size = new Size(118, 36);
        pnlStep2.TabIndex = 3;
        pnlStep2.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 118, 36, 6));
        // 
        // lblStep2
        // 
        lblStep2.Dock = DockStyle.Fill;
        lblStep2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStep2.ForeColor = Color.FromArgb(75, 86, 148);
        lblStep2.Location = new Point(0, 0);
        lblStep2.Name = "lblStep2";
        lblStep2.Size = new Size(118, 36);
        lblStep2.TabIndex = 0;
        lblStep2.Text = " Ready";
        lblStep2.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlStep1
        // 
        pnlStep1.BackColor = Color.FromArgb(234, 224, 207);
        pnlStep1.Controls.Add(lblStep1);
        pnlStep1.Location = new Point(138, 35);
        pnlStep1.Name = "pnlStep1";
        pnlStep1.Size = new Size(118, 36);
        pnlStep1.TabIndex = 2;
        pnlStep1.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 118, 36, 6));
        // 
        // lblStep1
        // 
        lblStep1.Dock = DockStyle.Fill;
        lblStep1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStep1.ForeColor = Color.FromArgb(75, 86, 148);
        lblStep1.Location = new Point(0, 0);
        lblStep1.Name = "lblStep1";
        lblStep1.Size = new Size(118, 36);
        lblStep1.TabIndex = 0;
        lblStep1.Text = " Drying";
        lblStep1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlStep0
        // 
        pnlStep0.BackColor = Color.FromArgb(234, 224, 207);
        pnlStep0.Controls.Add(lblStep0);
        pnlStep0.Location = new Point(15, 35);
        pnlStep0.Name = "pnlStep0";
        pnlStep0.Size = new Size(118, 36);
        pnlStep0.TabIndex = 1;
        pnlStep0.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 118, 36, 6));
        // 
        // lblStep0
        // 
        lblStep0.Dock = DockStyle.Fill;
        lblStep0.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStep0.ForeColor = Color.FromArgb(75, 86, 148);
        lblStep0.Location = new Point(0, 0);
        lblStep0.Name = "lblStep0";
        lblStep0.Size = new Size(118, 36);
        lblStep0.TabIndex = 0;
        lblStep0.Text = "Washing";
        lblStep0.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTimelineHeader
        // 
        lblTimelineHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTimelineHeader.ForeColor = Color.FromArgb(75, 86, 148);
        lblTimelineHeader.Location = new Point(15, 10);
        lblTimelineHeader.Name = "lblTimelineHeader";
        lblTimelineHeader.Size = new Size(490, 20);
        lblTimelineHeader.TabIndex = 0;
        lblTimelineHeader.Text = "Order Progress Timeline";
        // 
        // btnBack
        // 
        btnBack.ButtonType = HopeButtonType.Default;
        btnBack.DefaultColor = Color.FromArgb(234, 224, 207);
        btnBack.BorderColor = Color.FromArgb(114, 136, 174);
        btnBack.TextColor = Color.FromArgb(75, 86, 148);
        btnBack.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnBack.Cursor = Cursors.Hand;
        btnBack.Font = new Font("Segoe UI", 9.5F);
        btnBack.Location = new Point(295, 285);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(175, 40);
        btnBack.TabIndex = 9;
        btnBack.Text = "Back to Login";
        btnBack.Click += btnBack_Click;
        // 
        // btnLookup
        // 
        btnLookup.ButtonType = HopeButtonType.Primary;
        btnLookup.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnLookup.TextColor = Color.FromArgb(246, 242, 234);
        btnLookup.HoverTextColor = Color.White;
        btnLookup.Cursor = Cursors.Hand;
        btnLookup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLookup.Location = new Point(50, 285);
        btnLookup.Name = "btnLookup";
        btnLookup.Size = new Size(230, 40);
        btnLookup.TabIndex = 8;
        btnLookup.Text = "Check Status";
        btnLookup.Click += btnLookup_Click;
        // 
        // lnkPricing
        // 
        lnkPricing.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lnkPricing.LinkColor = Color.FromArgb(75, 86, 148);
        lnkPricing.Location = new Point(50, 332);
        lnkPricing.Name = "lnkPricing";
        lnkPricing.Size = new Size(420, 24);
        lnkPricing.TabIndex = 11;
        lnkPricing.TabStop = true;
        lnkPricing.Text = " View Laundry Services & Pricing";
        lnkPricing.TextAlign = ContentAlignment.MiddleCenter;
        lnkPricing.LinkClicked += lnkPricing_LinkClicked;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(184, 72, 88);
        lblError.Location = new Point(50, 260);
        lblError.Name = "lblError";
        lblError.Size = new Size(420, 22);
        lblError.TabIndex = 7;
        lblError.Visible = false;
        // 
        // txtPhoneLast4
        // 
        txtPhoneLast4.BackColor = Color.White;
        txtPhoneLast4.BaseColor = Color.FromArgb(246, 242, 234);
        txtPhoneLast4.BorderColorA = Color.FromArgb(75, 86, 148);
        txtPhoneLast4.BorderColorB = Color.FromArgb(190, 196, 220);
        txtPhoneLast4.Font = new Font("Segoe UI", 10F);
        txtPhoneLast4.ForeColor = Color.FromArgb(75, 86, 148);
        txtPhoneLast4.Hint = "e.g. 4567";
        txtPhoneLast4.Location = new Point(50, 220);
        txtPhoneLast4.MaxLength = 4;
        txtPhoneLast4.Name = "txtPhoneLast4";
        txtPhoneLast4.Size = new Size(420, 36);
        txtPhoneLast4.TabIndex = 6;
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPhone.ForeColor = Color.FromArgb(75, 86, 148);
        lblPhone.Location = new Point(50, 198);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(420, 20);
        lblPhone.TabIndex = 5;
        lblPhone.Text = "Last 4 Digits of Phone Number:";
        // 
        // txtOrderNumber
        // 
        txtOrderNumber.BackColor = Color.White;
        txtOrderNumber.BaseColor = Color.FromArgb(246, 242, 234);
        txtOrderNumber.BorderColorA = Color.FromArgb(75, 86, 148);
        txtOrderNumber.BorderColorB = Color.FromArgb(190, 196, 220);
        txtOrderNumber.Font = new Font("Segoe UI", 10F);
        txtOrderNumber.ForeColor = Color.FromArgb(75, 86, 148);
        txtOrderNumber.Hint = "LH-YYYYMMDD-XXX";
        txtOrderNumber.Location = new Point(50, 155);
        txtOrderNumber.Name = "txtOrderNumber";
        txtOrderNumber.Size = new Size(420, 36);
        txtOrderNumber.TabIndex = 4;
        // 
        // lblOrder
        // 
        lblOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblOrder.ForeColor = Color.FromArgb(75, 86, 148);
        lblOrder.Location = new Point(50, 132);
        lblOrder.Name = "lblOrder";
        lblOrder.Size = new Size(420, 20);
        lblOrder.TabIndex = 3;
        lblOrder.Text = "Order Number (e.g. LH-20261011-001):";
        // 
        // lblSub
        // 
        lblSub.Font = new Font("Segoe UI", 9F);
        lblSub.ForeColor = Color.FromArgb(114, 136, 174);
        lblSub.Location = new Point(30, 98);
        lblSub.Name = "lblSub";
        lblSub.Size = new Size(520, 22);
        lblSub.TabIndex = 2;
        lblSub.Text = "Enter your Order Number and the last 4 digits of your phone number";
        lblSub.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(75, 86, 148);
        lblTitle.Location = new Point(30, 62);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(520, 32);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "Track Your Laundry Order";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblIcon
        // 
        lblIcon.Font = new Font("Segoe UI Emoji", 28F);
        lblIcon.ForeColor = Color.FromArgb(75, 86, 148);
        lblIcon.Location = new Point(30, 16);
        lblIcon.Name = "lblIcon";
        lblIcon.Size = new Size(520, 45);
        lblIcon.TabIndex = 0;
        lblIcon.Text = "";
        lblIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FrmGuestLookup
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(114, 136, 174);
        ClientSize = new Size(1100, 800);
        Controls.Add(pnlCard);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(75, 86, 148);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        Name = "FrmGuestLookup";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub  Guest Order Tracking";
        pnlCard.ResumeLayout(false);
        pnlResult.ResumeLayout(false);
        tlpGrid.ResumeLayout(false);
        pnlStep3.ResumeLayout(false);
        pnlStep2.ResumeLayout(false);
        pnlStep1.ResumeLayout(false);
        pnlStep0.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlCard;
    private Label lblIcon;
    private Label lblTitle;
    private Label lblSub;
    private Label lblOrder;
    private HopeTextBox txtOrderNumber;
    private Label lblPhone;
    private HopeTextBox txtPhoneLast4;
    private Label lblError;
    private HopeButton btnLookup;
    private HopeButton btnBack;
    private Panel pnlResult;
    private Label lblTimelineHeader;
    private Panel pnlStep0;
    private Label lblStep0;
    private Panel pnlStep1;
    private Label lblStep1;
    private Panel pnlStep2;
    private Label lblStep2;
    private Panel pnlStep3;
    private Label lblStep3;
    private TableLayoutPanel tlpGrid;
    private Label lblHOrder;
    private Label lblResultOrder;
    private Label lblHCustomer;
    private Label lblResultCustomer;
    private Label lblHService;
    private Label lblResultService;
    private Label lblHAmount;
    private Label lblResultTotal;
    private Label lblHPayment;
    private Label lblResultPayment;
    private Label lblHPickup;
    private Label lblResultPickup;
    private LinkLabel lnkPricing;
}

