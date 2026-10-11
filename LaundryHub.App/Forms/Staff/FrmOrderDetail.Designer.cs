namespace LaundryHub.App.Forms.Staff;

partial class FrmOrderDetail
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
        btnClose = new Button();
        lblStatusBadge = new Label();
        lblOrderNumber = new Label();
        pnlContainer = new Panel();
        pnlRightWrapper = new Panel();
        pnlRightCard = new Panel();
        btnResendEmail = new Button();
        btnPrintQr = new Button();
        picQrCode = new PictureBox();
        lblQrTitle = new Label();
        pnlLeftCard = new Panel();
        flpActions = new FlowLayoutPanel();
        btnAdvanceStatus = new Button();
        btnClaimOrder = new Button();
        btnCancelOrder = new Button();
        tlpDetails = new TableLayoutPanel();
        lblHCustomer = new Label();
        lblCustomerInfo = new Label();
        lblHService = new Label();
        lblServiceInfo = new Label();
        lblHWeight = new Label();
        lblWeightInfo = new Label();
        lblHTotal = new Label();
        lblTotalAmount = new Label();
        lblHPayment = new Label();
        lblPaymentStatus = new Label();
        lblHPickup = new Label();
        lblPickupDate = new Label();
        lblHCreated = new Label();
        lblCreatedDate = new Label();
        lblHCancelReason = new Label();
        lblCancelReason = new Label();
        lblDetailsTitle = new Label();
        pnlHeader.SuspendLayout();
        pnlContainer.SuspendLayout();
        pnlRightWrapper.SuspendLayout();
        pnlRightCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picQrCode).BeginInit();
        pnlLeftCard.SuspendLayout();
        flpActions.SuspendLayout();
        tlpDetails.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
        pnlHeader.Controls.Add(btnClose);
        pnlHeader.Controls.Add(lblStatusBadge);
        pnlHeader.Controls.Add(lblOrderNumber);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 0, 24, 0);
        pnlHeader.Size = new Size(820, 70);
        pnlHeader.TabIndex = 0;
        // 
        // btnClose
        // 
        btnClose.BackColor = Color.FromArgb(51, 65, 85);
        btnClose.Cursor = Cursors.Hand;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.ForeColor = Color.White;
        btnClose.Location = new Point(716, 19);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(80, 32);
        btnClose.TabIndex = 2;
        btnClose.Text = "✕ Close";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += btnClose_Click;
        // 
        // lblStatusBadge
        // 
        lblStatusBadge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblStatusBadge.Location = new Point(480, 19);
        lblStatusBadge.Name = "lblStatusBadge";
        lblStatusBadge.Size = new Size(160, 32);
        lblStatusBadge.TabIndex = 1;
        lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblOrderNumber
        // 
        lblOrderNumber.AutoSize = true;
        lblOrderNumber.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblOrderNumber.ForeColor = Color.FromArgb(96, 165, 250);
        lblOrderNumber.Location = new Point(24, 18);
        lblOrderNumber.Name = "lblOrderNumber";
        lblOrderNumber.Size = new Size(198, 30);
        lblOrderNumber.TabIndex = 0;
        lblOrderNumber.Text = "🧾 LH-20261011-001";
        // 
        // pnlContainer
        // 
        pnlContainer.Controls.Add(pnlRightWrapper);
        pnlContainer.Controls.Add(pnlLeftCard);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 70);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(20);
        pnlContainer.Size = new Size(820, 550);
        pnlContainer.TabIndex = 1;
        // 
        // pnlRightWrapper
        // 
        pnlRightWrapper.Controls.Add(pnlRightCard);
        pnlRightWrapper.Dock = DockStyle.Fill;
        pnlRightWrapper.Location = new Point(490, 20);
        pnlRightWrapper.Name = "pnlRightWrapper";
        pnlRightWrapper.Padding = new Padding(16, 0, 0, 0);
        pnlRightWrapper.Size = new Size(310, 510);
        pnlRightWrapper.TabIndex = 1;
        // 
        // pnlRightCard
        // 
        pnlRightCard.BackColor = Color.FromArgb(30, 41, 59);
        pnlRightCard.Controls.Add(btnResendEmail);
        pnlRightCard.Controls.Add(btnPrintQr);
        pnlRightCard.Controls.Add(picQrCode);
        pnlRightCard.Controls.Add(lblQrTitle);
        pnlRightCard.Dock = DockStyle.Fill;
        pnlRightCard.Location = new Point(16, 0);
        pnlRightCard.Name = "pnlRightCard";
        pnlRightCard.Padding = new Padding(20);
        pnlRightCard.Size = new Size(294, 510);
        pnlRightCard.TabIndex = 0;
        // 
        // btnResendEmail
        // 
        btnResendEmail.BackColor = Color.FromArgb(37, 99, 235);
        btnResendEmail.Cursor = Cursors.Hand;
        btnResendEmail.FlatAppearance.BorderSize = 0;
        btnResendEmail.FlatStyle = FlatStyle.Flat;
        btnResendEmail.ForeColor = Color.White;
        btnResendEmail.Location = new Point(37, 320);
        btnResendEmail.Name = "btnResendEmail";
        btnResendEmail.Size = new Size(220, 36);
        btnResendEmail.TabIndex = 3;
        btnResendEmail.Text = "✉ Resend Email Receipt";
        btnResendEmail.UseVisualStyleBackColor = false;
        btnResendEmail.Click += btnResendEmail_Click;
        // 
        // btnPrintQr
        // 
        btnPrintQr.BackColor = Color.FromArgb(51, 65, 85);
        btnPrintQr.Cursor = Cursors.Hand;
        btnPrintQr.FlatAppearance.BorderSize = 0;
        btnPrintQr.FlatStyle = FlatStyle.Flat;
        btnPrintQr.ForeColor = Color.White;
        btnPrintQr.Location = new Point(37, 270);
        btnPrintQr.Name = "btnPrintQr";
        btnPrintQr.Size = new Size(220, 36);
        btnPrintQr.TabIndex = 2;
        btnPrintQr.Text = "🖨 Print QR Ticket";
        btnPrintQr.UseVisualStyleBackColor = false;
        btnPrintQr.Click += btnPrintQr_Click;
        // 
        // picQrCode
        // 
        picQrCode.BackColor = Color.White;
        picQrCode.BorderStyle = BorderStyle.FixedSingle;
        picQrCode.Location = new Point(52, 60);
        picQrCode.Name = "picQrCode";
        picQrCode.Size = new Size(190, 190);
        picQrCode.SizeMode = PictureBoxSizeMode.Zoom;
        picQrCode.TabIndex = 1;
        picQrCode.TabStop = false;
        // 
        // lblQrTitle
        // 
        lblQrTitle.Dock = DockStyle.Top;
        lblQrTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblQrTitle.ForeColor = Color.White;
        lblQrTitle.Location = new Point(20, 20);
        lblQrTitle.Name = "lblQrTitle";
        lblQrTitle.Size = new Size(254, 30);
        lblQrTitle.TabIndex = 0;
        lblQrTitle.Text = "QR Code E-Ticket";
        lblQrTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlLeftCard
        // 
        pnlLeftCard.BackColor = Color.FromArgb(30, 41, 59);
        pnlLeftCard.Controls.Add(flpActions);
        pnlLeftCard.Controls.Add(tlpDetails);
        pnlLeftCard.Controls.Add(lblDetailsTitle);
        pnlLeftCard.Dock = DockStyle.Left;
        pnlLeftCard.Location = new Point(20, 20);
        pnlLeftCard.Name = "pnlLeftCard";
        pnlLeftCard.Padding = new Padding(20);
        pnlLeftCard.Size = new Size(470, 510);
        pnlLeftCard.TabIndex = 0;
        // 
        // flpActions
        // 
        flpActions.Controls.Add(btnAdvanceStatus);
        flpActions.Controls.Add(btnClaimOrder);
        flpActions.Controls.Add(btnCancelOrder);
        flpActions.Dock = DockStyle.Bottom;
        flpActions.Location = new Point(20, 400);
        flpActions.Name = "flpActions";
        flpActions.Padding = new Padding(0, 10, 0, 0);
        flpActions.Size = new Size(430, 90);
        flpActions.TabIndex = 2;
        // 
        // btnAdvanceStatus
        // 
        btnAdvanceStatus.BackColor = Color.FromArgb(37, 99, 235);
        btnAdvanceStatus.Cursor = Cursors.Hand;
        btnAdvanceStatus.FlatAppearance.BorderSize = 0;
        btnAdvanceStatus.FlatStyle = FlatStyle.Flat;
        btnAdvanceStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAdvanceStatus.ForeColor = Color.White;
        btnAdvanceStatus.Location = new Point(3, 13);
        btnAdvanceStatus.Name = "btnAdvanceStatus";
        btnAdvanceStatus.Size = new Size(135, 36);
        btnAdvanceStatus.TabIndex = 0;
        btnAdvanceStatus.Text = "Advance Status";
        btnAdvanceStatus.UseVisualStyleBackColor = false;
        btnAdvanceStatus.Click += btnAdvanceStatus_Click;
        // 
        // btnClaimOrder
        // 
        btnClaimOrder.BackColor = Color.FromArgb(16, 185, 129);
        btnClaimOrder.Cursor = Cursors.Hand;
        btnClaimOrder.FlatAppearance.BorderSize = 0;
        btnClaimOrder.FlatStyle = FlatStyle.Flat;
        btnClaimOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnClaimOrder.ForeColor = Color.White;
        btnClaimOrder.Location = new Point(144, 13);
        btnClaimOrder.Name = "btnClaimOrder";
        btnClaimOrder.Size = new Size(135, 36);
        btnClaimOrder.TabIndex = 1;
        btnClaimOrder.Text = "💰 Claim / Pay";
        btnClaimOrder.UseVisualStyleBackColor = false;
        btnClaimOrder.Click += btnClaimOrder_Click;
        // 
        // btnCancelOrder
        // 
        btnCancelOrder.BackColor = Color.FromArgb(220, 38, 38);
        btnCancelOrder.Cursor = Cursors.Hand;
        btnCancelOrder.FlatAppearance.BorderSize = 0;
        btnCancelOrder.FlatStyle = FlatStyle.Flat;
        btnCancelOrder.Font = new Font("Segoe UI", 9F);
        btnCancelOrder.ForeColor = Color.White;
        btnCancelOrder.Location = new Point(285, 13);
        btnCancelOrder.Name = "btnCancelOrder";
        btnCancelOrder.Size = new Size(135, 36);
        btnCancelOrder.TabIndex = 2;
        btnCancelOrder.Text = "✕ Cancel Order";
        btnCancelOrder.UseVisualStyleBackColor = false;
        btnCancelOrder.Click += btnCancelOrder_Click;
        // 
        // tlpDetails
        // 
        tlpDetails.ColumnCount = 2;
        tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpDetails.Controls.Add(lblHCustomer, 0, 0);
        tlpDetails.Controls.Add(lblCustomerInfo, 1, 0);
        tlpDetails.Controls.Add(lblHService, 0, 1);
        tlpDetails.Controls.Add(lblServiceInfo, 1, 1);
        tlpDetails.Controls.Add(lblHWeight, 0, 2);
        tlpDetails.Controls.Add(lblWeightInfo, 1, 2);
        tlpDetails.Controls.Add(lblHTotal, 0, 3);
        tlpDetails.Controls.Add(lblTotalAmount, 1, 3);
        tlpDetails.Controls.Add(lblHPayment, 0, 4);
        tlpDetails.Controls.Add(lblPaymentStatus, 1, 4);
        tlpDetails.Controls.Add(lblHPickup, 0, 5);
        tlpDetails.Controls.Add(lblPickupDate, 1, 5);
        tlpDetails.Controls.Add(lblHCreated, 0, 6);
        tlpDetails.Controls.Add(lblCreatedDate, 1, 6);
        tlpDetails.Controls.Add(lblHCancelReason, 0, 7);
        tlpDetails.Controls.Add(lblCancelReason, 1, 7);
        tlpDetails.Dock = DockStyle.Fill;
        tlpDetails.Location = new Point(20, 50);
        tlpDetails.Name = "tlpDetails";
        tlpDetails.Padding = new Padding(0, 10, 0, 0);
        tlpDetails.RowCount = 8;
        tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        tlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        tlpDetails.Size = new Size(430, 440);
        tlpDetails.TabIndex = 1;
        // 
        // lblHCustomer
        // 
        lblHCustomer.Dock = DockStyle.Fill;
        lblHCustomer.Font = new Font("Segoe UI", 9F);
        lblHCustomer.ForeColor = Color.FromArgb(148, 163, 184);
        lblHCustomer.Text = "Customer:";
        lblHCustomer.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblCustomerInfo
        // 
        lblCustomerInfo.Dock = DockStyle.Fill;
        lblCustomerInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblCustomerInfo.ForeColor = Color.White;
        lblCustomerInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHService
        // 
        lblHService.Dock = DockStyle.Fill;
        lblHService.Font = new Font("Segoe UI", 9F);
        lblHService.ForeColor = Color.FromArgb(148, 163, 184);
        lblHService.Text = "Service Type:";
        lblHService.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblServiceInfo
        // 
        lblServiceInfo.Dock = DockStyle.Fill;
        lblServiceInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblServiceInfo.ForeColor = Color.White;
        lblServiceInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHWeight
        // 
        lblHWeight.Dock = DockStyle.Fill;
        lblHWeight.Font = new Font("Segoe UI", 9F);
        lblHWeight.ForeColor = Color.FromArgb(148, 163, 184);
        lblHWeight.Text = "Weight:";
        lblHWeight.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblWeightInfo
        // 
        lblWeightInfo.Dock = DockStyle.Fill;
        lblWeightInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblWeightInfo.ForeColor = Color.White;
        lblWeightInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHTotal
        // 
        lblHTotal.Dock = DockStyle.Fill;
        lblHTotal.Font = new Font("Segoe UI", 9F);
        lblHTotal.ForeColor = Color.FromArgb(148, 163, 184);
        lblHTotal.Text = "Total Amount:";
        lblHTotal.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.Dock = DockStyle.Fill;
        lblTotalAmount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.White;
        lblTotalAmount.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHPayment
        // 
        lblHPayment.Dock = DockStyle.Fill;
        lblHPayment.Font = new Font("Segoe UI", 9F);
        lblHPayment.ForeColor = Color.FromArgb(148, 163, 184);
        lblHPayment.Text = "Payment:";
        lblHPayment.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblPaymentStatus
        // 
        lblPaymentStatus.Dock = DockStyle.Fill;
        lblPaymentStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPaymentStatus.ForeColor = Color.White;
        lblPaymentStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHPickup
        // 
        lblHPickup.Dock = DockStyle.Fill;
        lblHPickup.Font = new Font("Segoe UI", 9F);
        lblHPickup.ForeColor = Color.FromArgb(148, 163, 184);
        lblHPickup.Text = "Target Pickup:";
        lblHPickup.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblPickupDate
        // 
        lblPickupDate.Dock = DockStyle.Fill;
        lblPickupDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPickupDate.ForeColor = Color.White;
        lblPickupDate.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHCreated
        // 
        lblHCreated.Dock = DockStyle.Fill;
        lblHCreated.Font = new Font("Segoe UI", 9F);
        lblHCreated.ForeColor = Color.FromArgb(148, 163, 184);
        lblHCreated.Text = "Order Date:";
        lblHCreated.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblCreatedDate
        // 
        lblCreatedDate.Dock = DockStyle.Fill;
        lblCreatedDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblCreatedDate.ForeColor = Color.White;
        lblCreatedDate.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHCancelReason
        // 
        lblHCancelReason.Dock = DockStyle.Fill;
        lblHCancelReason.Font = new Font("Segoe UI", 9F);
        lblHCancelReason.ForeColor = Color.FromArgb(148, 163, 184);
        lblHCancelReason.Text = "Notes/Reason:";
        lblHCancelReason.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblCancelReason
        // 
        lblCancelReason.Dock = DockStyle.Fill;
        lblCancelReason.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblCancelReason.ForeColor = Color.White;
        lblCancelReason.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblDetailsTitle
        // 
        lblDetailsTitle.Dock = DockStyle.Top;
        lblDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblDetailsTitle.ForeColor = Color.White;
        lblDetailsTitle.Location = new Point(20, 20);
        lblDetailsTitle.Name = "lblDetailsTitle";
        lblDetailsTitle.Size = new Size(430, 30);
        lblDetailsTitle.TabIndex = 0;
        lblDetailsTitle.Text = "Order & Customer Details";
        // 
        // FrmOrderDetail
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(820, 620);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmOrderDetail";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Order Details";
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlContainer.ResumeLayout(false);
        pnlRightWrapper.ResumeLayout(false);
        pnlRightCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picQrCode).EndInit();
        pnlLeftCard.ResumeLayout(false);
        flpActions.ResumeLayout(false);
        tlpDetails.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblOrderNumber;
    private Label lblStatusBadge;
    private Button btnClose;
    private Panel pnlContainer;
    private Panel pnlLeftCard;
    private Label lblDetailsTitle;
    private TableLayoutPanel tlpDetails;
    private Label lblHCustomer;
    private Label lblCustomerInfo;
    private Label lblHService;
    private Label lblServiceInfo;
    private Label lblHWeight;
    private Label lblWeightInfo;
    private Label lblHTotal;
    private Label lblTotalAmount;
    private Label lblHPayment;
    private Label lblPaymentStatus;
    private Label lblHPickup;
    private Label lblPickupDate;
    private Label lblHCreated;
    private Label lblCreatedDate;
    private Label lblHCancelReason;
    private Label lblCancelReason;
    private FlowLayoutPanel flpActions;
    private Button btnAdvanceStatus;
    private Button btnClaimOrder;
    private Button btnCancelOrder;
    private Panel pnlRightWrapper;
    private Panel pnlRightCard;
    private Label lblQrTitle;
    private PictureBox picQrCode;
    private Button btnPrintQr;
    private Button btnResendEmail;
}
