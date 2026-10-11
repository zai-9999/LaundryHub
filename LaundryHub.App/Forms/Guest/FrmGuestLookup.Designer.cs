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
        btnBack = new Button();
        btnLookup = new Button();
        lblError = new Label();
        txtPhoneLast4 = new TextBox();
        lblPhone = new Label();
        txtOrderNumber = new TextBox();
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
        pnlCard.BackColor = Color.FromArgb(30, 41, 59);
        pnlCard.Controls.Add(pnlResult);
        pnlCard.Controls.Add(btnBack);
        pnlCard.Controls.Add(btnLookup);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(txtPhoneLast4);
        pnlCard.Controls.Add(lblPhone);
        pnlCard.Controls.Add(txtOrderNumber);
        pnlCard.Controls.Add(lblOrder);
        pnlCard.Controls.Add(lblSub);
        pnlCard.Controls.Add(lblTitle);
        pnlCard.Controls.Add(lblIcon);
        pnlCard.Location = new Point(45, 30);
        pnlCard.Name = "pnlCard";
        pnlCard.Padding = new Padding(30);
        pnlCard.Size = new Size(580, 620);
        pnlCard.TabIndex = 0;
        pnlCard.Paint += pnlCard_Paint;
        // 
        // pnlResult
        // 
        pnlResult.BackColor = Color.FromArgb(15, 23, 42);
        pnlResult.Controls.Add(tlpGrid);
        pnlResult.Controls.Add(pnlStep3);
        pnlResult.Controls.Add(pnlStep2);
        pnlResult.Controls.Add(pnlStep1);
        pnlResult.Controls.Add(pnlStep0);
        pnlResult.Controls.Add(lblTimelineHeader);
        pnlResult.Location = new Point(30, 340);
        pnlResult.Name = "pnlResult";
        pnlResult.Padding = new Padding(15);
        pnlResult.Size = new Size(520, 255);
        pnlResult.TabIndex = 10;
        pnlResult.Visible = false;
        pnlResult.Paint += pnlResult_Paint;
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
        lblHOrder.Font = new Font("Segoe UI", 9F);
        lblHOrder.ForeColor = Color.FromArgb(148, 163, 184);
        lblHOrder.Text = "Order #:";
        lblHOrder.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultOrder
        // 
        lblResultOrder.Dock = DockStyle.Fill;
        lblResultOrder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultOrder.ForeColor = Color.White;
        lblResultOrder.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHCustomer
        // 
        lblHCustomer.Dock = DockStyle.Fill;
        lblHCustomer.Font = new Font("Segoe UI", 9F);
        lblHCustomer.ForeColor = Color.FromArgb(148, 163, 184);
        lblHCustomer.Text = "Customer:";
        lblHCustomer.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultCustomer
        // 
        lblResultCustomer.Dock = DockStyle.Fill;
        lblResultCustomer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultCustomer.ForeColor = Color.White;
        lblResultCustomer.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHService
        // 
        lblHService.Dock = DockStyle.Fill;
        lblHService.Font = new Font("Segoe UI", 9F);
        lblHService.ForeColor = Color.FromArgb(148, 163, 184);
        lblHService.Text = "Service:";
        lblHService.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultService
        // 
        lblResultService.Dock = DockStyle.Fill;
        lblResultService.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultService.ForeColor = Color.White;
        lblResultService.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHAmount
        // 
        lblHAmount.Dock = DockStyle.Fill;
        lblHAmount.Font = new Font("Segoe UI", 9F);
        lblHAmount.ForeColor = Color.FromArgb(148, 163, 184);
        lblHAmount.Text = "Amount:";
        lblHAmount.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultTotal
        // 
        lblResultTotal.Dock = DockStyle.Fill;
        lblResultTotal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultTotal.ForeColor = Color.White;
        lblResultTotal.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHPayment
        // 
        lblHPayment.Dock = DockStyle.Fill;
        lblHPayment.Font = new Font("Segoe UI", 9F);
        lblHPayment.ForeColor = Color.FromArgb(148, 163, 184);
        lblHPayment.Text = "Payment:";
        lblHPayment.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultPayment
        // 
        lblResultPayment.Dock = DockStyle.Fill;
        lblResultPayment.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultPayment.ForeColor = Color.White;
        lblResultPayment.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHPickup
        // 
        lblHPickup.Dock = DockStyle.Fill;
        lblHPickup.Font = new Font("Segoe UI", 9F);
        lblHPickup.ForeColor = Color.FromArgb(148, 163, 184);
        lblHPickup.Text = "Pickup Date:";
        lblHPickup.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblResultPickup
        // 
        lblResultPickup.Dock = DockStyle.Fill;
        lblResultPickup.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblResultPickup.ForeColor = Color.White;
        lblResultPickup.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlStep3
        // 
        pnlStep3.BackColor = Color.FromArgb(30, 41, 59);
        pnlStep3.Controls.Add(lblStep3);
        pnlStep3.Location = new Point(384, 35);
        pnlStep3.Name = "pnlStep3";
        pnlStep3.Size = new Size(118, 36);
        pnlStep3.TabIndex = 4;
        // 
        // lblStep3
        // 
        lblStep3.Dock = DockStyle.Fill;
        lblStep3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStep3.ForeColor = Color.FromArgb(148, 163, 184);
        lblStep3.Location = new Point(0, 0);
        lblStep3.Name = "lblStep3";
        lblStep3.Size = new Size(118, 36);
        lblStep3.TabIndex = 0;
        lblStep3.Text = "📦 Claimed";
        lblStep3.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlStep2
        // 
        pnlStep2.BackColor = Color.FromArgb(30, 41, 59);
        pnlStep2.Controls.Add(lblStep2);
        pnlStep2.Location = new Point(261, 35);
        pnlStep2.Name = "pnlStep2";
        pnlStep2.Size = new Size(118, 36);
        pnlStep2.TabIndex = 3;
        // 
        // lblStep2
        // 
        lblStep2.Dock = DockStyle.Fill;
        lblStep2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStep2.ForeColor = Color.FromArgb(148, 163, 184);
        lblStep2.Location = new Point(0, 0);
        lblStep2.Name = "lblStep2";
        lblStep2.Size = new Size(118, 36);
        lblStep2.TabIndex = 0;
        lblStep2.Text = "✨ Ready";
        lblStep2.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlStep1
        // 
        pnlStep1.BackColor = Color.FromArgb(30, 41, 59);
        pnlStep1.Controls.Add(lblStep1);
        pnlStep1.Location = new Point(138, 35);
        pnlStep1.Name = "pnlStep1";
        pnlStep1.Size = new Size(118, 36);
        pnlStep1.TabIndex = 2;
        // 
        // lblStep1
        // 
        lblStep1.Dock = DockStyle.Fill;
        lblStep1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStep1.ForeColor = Color.FromArgb(148, 163, 184);
        lblStep1.Location = new Point(0, 0);
        lblStep1.Name = "lblStep1";
        lblStep1.Size = new Size(118, 36);
        lblStep1.TabIndex = 0;
        lblStep1.Text = "🌀 Drying";
        lblStep1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlStep0
        // 
        pnlStep0.BackColor = Color.FromArgb(30, 41, 59);
        pnlStep0.Controls.Add(lblStep0);
        pnlStep0.Location = new Point(15, 35);
        pnlStep0.Name = "pnlStep0";
        pnlStep0.Size = new Size(118, 36);
        pnlStep0.TabIndex = 1;
        // 
        // lblStep0
        // 
        lblStep0.Dock = DockStyle.Fill;
        lblStep0.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStep0.ForeColor = Color.FromArgb(148, 163, 184);
        lblStep0.Location = new Point(0, 0);
        lblStep0.Name = "lblStep0";
        lblStep0.Size = new Size(118, 36);
        lblStep0.TabIndex = 0;
        lblStep0.Text = "🧺 Washing";
        lblStep0.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTimelineHeader
        // 
        lblTimelineHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTimelineHeader.ForeColor = Color.FromArgb(148, 163, 184);
        lblTimelineHeader.Location = new Point(15, 10);
        lblTimelineHeader.Name = "lblTimelineHeader";
        lblTimelineHeader.Size = new Size(490, 20);
        lblTimelineHeader.TabIndex = 0;
        lblTimelineHeader.Text = "Order Progress Timeline";
        // 
        // btnBack
        // 
        btnBack.BackColor = Color.FromArgb(51, 65, 85);
        btnBack.Cursor = Cursors.Hand;
        btnBack.FlatAppearance.BorderSize = 0;
        btnBack.FlatStyle = FlatStyle.Flat;
        btnBack.ForeColor = Color.White;
        btnBack.Location = new Point(265, 285);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(205, 38);
        btnBack.TabIndex = 9;
        btnBack.Text = "← Back to Login";
        btnBack.UseVisualStyleBackColor = false;
        btnBack.Click += btnBack_Click;
        // 
        // btnLookup
        // 
        btnLookup.BackColor = Color.FromArgb(37, 99, 235);
        btnLookup.Cursor = Cursors.Hand;
        btnLookup.FlatAppearance.BorderSize = 0;
        btnLookup.FlatStyle = FlatStyle.Flat;
        btnLookup.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        btnLookup.ForeColor = Color.White;
        btnLookup.Location = new Point(50, 285);
        btnLookup.Name = "btnLookup";
        btnLookup.Size = new Size(205, 38);
        btnLookup.TabIndex = 8;
        btnLookup.Text = "🚀 Check Status";
        btnLookup.UseVisualStyleBackColor = false;
        btnLookup.Click += btnLookup_Click;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = Color.FromArgb(248, 113, 113);
        lblError.Location = new Point(50, 260);
        lblError.Name = "lblError";
        lblError.Size = new Size(420, 22);
        lblError.TabIndex = 7;
        lblError.Visible = false;
        // 
        // txtPhoneLast4
        // 
        txtPhoneLast4.BackColor = Color.FromArgb(15, 23, 42);
        txtPhoneLast4.BorderStyle = BorderStyle.FixedSingle;
        txtPhoneLast4.Font = new Font("Segoe UI", 11F);
        txtPhoneLast4.ForeColor = Color.White;
        txtPhoneLast4.Location = new Point(50, 223);
        txtPhoneLast4.MaxLength = 4;
        txtPhoneLast4.Name = "txtPhoneLast4";
        txtPhoneLast4.PlaceholderText = "e.g. 4567";
        txtPhoneLast4.Size = new Size(420, 27);
        txtPhoneLast4.TabIndex = 6;
        // 
        // lblPhone
        // 
        lblPhone.Font = new Font("Segoe UI", 9F);
        lblPhone.ForeColor = Color.FromArgb(148, 163, 184);
        lblPhone.Location = new Point(50, 200);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(420, 20);
        lblPhone.TabIndex = 5;
        lblPhone.Text = "Last 4 Digits of Phone Number:";
        // 
        // txtOrderNumber
        // 
        txtOrderNumber.BackColor = Color.FromArgb(15, 23, 42);
        txtOrderNumber.BorderStyle = BorderStyle.FixedSingle;
        txtOrderNumber.Font = new Font("Segoe UI", 11F);
        txtOrderNumber.ForeColor = Color.White;
        txtOrderNumber.Location = new Point(50, 158);
        txtOrderNumber.Name = "txtOrderNumber";
        txtOrderNumber.PlaceholderText = "LH-YYYYMMDD-XXX";
        txtOrderNumber.Size = new Size(420, 27);
        txtOrderNumber.TabIndex = 4;
        // 
        // lblOrder
        // 
        lblOrder.Font = new Font("Segoe UI", 9F);
        lblOrder.ForeColor = Color.FromArgb(148, 163, 184);
        lblOrder.Location = new Point(50, 135);
        lblOrder.Name = "lblOrder";
        lblOrder.Size = new Size(420, 20);
        lblOrder.TabIndex = 3;
        lblOrder.Text = "Order Number (e.g. LH-20261011-001):";
        // 
        // lblSub
        // 
        lblSub.Font = new Font("Segoe UI", 8.5F);
        lblSub.ForeColor = Color.FromArgb(148, 163, 184);
        lblSub.Location = new Point(30, 102);
        lblSub.Name = "lblSub";
        lblSub.Size = new Size(520, 20);
        lblSub.TabIndex = 2;
        lblSub.Text = "Enter your Order Number and the last 4 digits of your phone number";
        lblSub.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(96, 165, 250);
        lblTitle.Location = new Point(30, 70);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(520, 32);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "Track Your Laundry Order";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblIcon
        // 
        lblIcon.Font = new Font("Segoe UI Emoji", 28F);
        lblIcon.Location = new Point(30, 20);
        lblIcon.Name = "lblIcon";
        lblIcon.Size = new Size(520, 45);
        lblIcon.TabIndex = 0;
        lblIcon.Text = "🔍";
        lblIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FrmGuestLookup
        // 
        AcceptButton = btnLookup;
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(680, 680);
        Controls.Add(pnlCard);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FrmGuestLookup";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Guest Order Tracking";
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
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
    private TextBox txtOrderNumber;
    private Label lblPhone;
    private TextBox txtPhoneLast4;
    private Label lblError;
    private Button btnLookup;
    private Button btnBack;
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
}
