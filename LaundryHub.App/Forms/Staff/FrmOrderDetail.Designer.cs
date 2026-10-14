using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

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
        btnClose = new HopeButton();
        lblStatusBadge = new Label();
        lblOrderNumber = new Label();
        pnlContainer = new Panel();
        pnlRightWrapper = new Panel();
        pnlRightCard = new Panel();
        btnResendEmail = new HopeButton();
        btnPrintQr = new HopeButton();
        picQrCode = new PictureBox();
        lblQrTitle = new Label();
        pnlLeftCard = new Panel();
        flpActions = new FlowLayoutPanel();
        btnAdvanceStatus = new HopeButton();
        btnClaimOrder = new HopeButton();
        btnCancelOrder = new HopeButton();
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
        pnlHeader.BackColor = Color.FromArgb(102, 163, 191);
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
        btnClose.BorderColor = Color.FromArgb(102, 163, 191);
        btnClose.ButtonType = HopeButtonType.Default;
        btnClose.Cursor = Cursors.Hand;
        btnClose.DangerColor = Color.FromArgb(245, 108, 108);
        btnClose.DefaultColor = Color.FromArgb(200, 223, 219);
        btnClose.Font = new Font("Segoe UI", 9F);
        btnClose.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnClose.InfoColor = Color.FromArgb(144, 147, 153);
        btnClose.Location = new Point(716, 18);
        btnClose.Name = "btnClose";
        btnClose.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnClose.Size = new Size(80, 34);
        btnClose.SuccessColor = Color.FromArgb(103, 194, 58);
        btnClose.TabIndex = 2;
        btnClose.Text = "✕ Close";
        btnClose.TextColor = Color.FromArgb(51, 104, 160);
        btnClose.WarningColor = Color.FromArgb(230, 162, 60);
        btnClose.Click += btnClose_Click;
        // 
        // lblStatusBadge
        // 
        lblStatusBadge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblStatusBadge.ForeColor = Color.White;
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
        lblOrderNumber.ForeColor = Color.FromArgb(242, 239, 231);
        lblOrderNumber.Location = new Point(24, 18);
        lblOrderNumber.Name = "lblOrderNumber";
        lblOrderNumber.Size = new Size(295, 37);
        lblOrderNumber.TabIndex = 0;
        lblOrderNumber.Text = "\U0001f9fe LH-20261011-001";
        // 
        // pnlContainer
        // 
        pnlContainer.BackColor = Color.FromArgb(242, 239, 231);
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
        pnlRightCard.BackColor = Color.White;
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
        btnResendEmail.BorderColor = Color.FromArgb(102, 163, 191);
        btnResendEmail.ButtonType = HopeButtonType.Default;
        btnResendEmail.Cursor = Cursors.Hand;
        btnResendEmail.DangerColor = Color.FromArgb(245, 108, 108);
        btnResendEmail.DefaultColor = Color.FromArgb(200, 223, 219);
        btnResendEmail.Font = new Font("Segoe UI", 9F);
        btnResendEmail.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnResendEmail.InfoColor = Color.FromArgb(144, 147, 153);
        btnResendEmail.Location = new Point(37, 320);
        btnResendEmail.Name = "btnResendEmail";
        btnResendEmail.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnResendEmail.Size = new Size(220, 38);
        btnResendEmail.SuccessColor = Color.FromArgb(103, 194, 58);
        btnResendEmail.TabIndex = 3;
        btnResendEmail.Text = "✉ Resend Email Receipt";
        btnResendEmail.TextColor = Color.FromArgb(51, 104, 160);
        btnResendEmail.WarningColor = Color.FromArgb(230, 162, 60);
        btnResendEmail.Click += btnResendEmail_Click;
        // 
        // btnPrintQr
        // 
        btnPrintQr.BorderColor = Color.FromArgb(220, 223, 230);
        btnPrintQr.ButtonType = HopeButtonType.Primary;
        btnPrintQr.Cursor = Cursors.Hand;
        btnPrintQr.DangerColor = Color.FromArgb(245, 108, 108);
        btnPrintQr.DefaultColor = Color.FromArgb(255, 255, 255);
        btnPrintQr.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnPrintQr.HoverTextColor = Color.White;
        btnPrintQr.InfoColor = Color.FromArgb(144, 147, 153);
        btnPrintQr.Location = new Point(37, 270);
        btnPrintQr.Name = "btnPrintQr";
        btnPrintQr.PrimaryColor = Color.FromArgb(51, 104, 160);
        btnPrintQr.Size = new Size(220, 38);
        btnPrintQr.SuccessColor = Color.FromArgb(103, 194, 58);
        btnPrintQr.TabIndex = 2;
        btnPrintQr.Text = "🖨 Print QR Ticket";
        btnPrintQr.TextColor = Color.FromArgb(242, 239, 231);
        btnPrintQr.WarningColor = Color.FromArgb(230, 162, 60);
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
        lblQrTitle.ForeColor = Color.FromArgb(51, 104, 160);
        lblQrTitle.Location = new Point(20, 20);
        lblQrTitle.Name = "lblQrTitle";
        lblQrTitle.Size = new Size(254, 30);
        lblQrTitle.TabIndex = 0;
        lblQrTitle.Text = "QR Code E-Ticket";
        lblQrTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlLeftCard
        // 
        pnlLeftCard.BackColor = Color.White;
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
        flpActions.Location = new Point(20, 431);
        flpActions.Name = "flpActions";
        flpActions.Padding = new Padding(0, 10, 0, 0);
        flpActions.Size = new Size(430, 59);
        flpActions.TabIndex = 2;
        // 
        // btnAdvanceStatus
        // 
        btnAdvanceStatus.BorderColor = Color.FromArgb(220, 223, 230);
        btnAdvanceStatus.ButtonType = HopeButtonType.Primary;
        btnAdvanceStatus.Cursor = Cursors.Hand;
        btnAdvanceStatus.DangerColor = Color.FromArgb(245, 108, 108);
        btnAdvanceStatus.DefaultColor = Color.FromArgb(255, 255, 255);
        btnAdvanceStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAdvanceStatus.HoverTextColor = Color.White;
        btnAdvanceStatus.InfoColor = Color.FromArgb(144, 147, 153);
        btnAdvanceStatus.Location = new Point(3, 13);
        btnAdvanceStatus.Name = "btnAdvanceStatus";
        btnAdvanceStatus.PrimaryColor = Color.FromArgb(51, 104, 160);
        btnAdvanceStatus.Size = new Size(135, 38);
        btnAdvanceStatus.SuccessColor = Color.FromArgb(103, 194, 58);
        btnAdvanceStatus.TabIndex = 0;
        btnAdvanceStatus.Text = "Advance Status";
        btnAdvanceStatus.TextColor = Color.FromArgb(242, 239, 231);
        btnAdvanceStatus.WarningColor = Color.FromArgb(230, 162, 60);
        btnAdvanceStatus.Click += btnAdvanceStatus_Click;
        // 
        // btnClaimOrder
        // 
        btnClaimOrder.BorderColor = Color.FromArgb(220, 223, 230);
        btnClaimOrder.ButtonType = HopeButtonType.Primary;
        btnClaimOrder.Cursor = Cursors.Hand;
        btnClaimOrder.DangerColor = Color.FromArgb(245, 108, 108);
        btnClaimOrder.DefaultColor = Color.FromArgb(255, 255, 255);
        btnClaimOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnClaimOrder.HoverTextColor = Color.White;
        btnClaimOrder.InfoColor = Color.FromArgb(144, 147, 153);
        btnClaimOrder.Location = new Point(144, 13);
        btnClaimOrder.Name = "btnClaimOrder";
        btnClaimOrder.PrimaryColor = Color.FromArgb(102, 163, 191);
        btnClaimOrder.Size = new Size(135, 38);
        btnClaimOrder.SuccessColor = Color.FromArgb(103, 194, 58);
        btnClaimOrder.TabIndex = 1;
        btnClaimOrder.Text = "💰 Claim / Pay";
        btnClaimOrder.TextColor = Color.White;
        btnClaimOrder.WarningColor = Color.FromArgb(230, 162, 60);
        btnClaimOrder.Click += btnClaimOrder_Click;
        // 
        // btnCancelOrder
        // 
        btnCancelOrder.BorderColor = Color.FromArgb(220, 53, 69);
        btnCancelOrder.ButtonType = HopeButtonType.Default;
        btnCancelOrder.Cursor = Cursors.Hand;
        btnCancelOrder.DangerColor = Color.FromArgb(245, 108, 108);
        btnCancelOrder.DefaultColor = Color.FromArgb(200, 223, 219);
        btnCancelOrder.Font = new Font("Segoe UI", 9F);
        btnCancelOrder.HoverTextColor = Color.FromArgb(220, 53, 69);
        btnCancelOrder.InfoColor = Color.FromArgb(144, 147, 153);
        btnCancelOrder.Location = new Point(285, 13);
        btnCancelOrder.Name = "btnCancelOrder";
        btnCancelOrder.PrimaryColor = Color.FromArgb(64, 158, 255);
        btnCancelOrder.Size = new Size(135, 38);
        btnCancelOrder.SuccessColor = Color.FromArgb(103, 194, 58);
        btnCancelOrder.TabIndex = 2;
        btnCancelOrder.Text = "✕ Cancel Order";
        btnCancelOrder.TextColor = Color.FromArgb(220, 53, 69);
        btnCancelOrder.WarningColor = Color.FromArgb(230, 162, 60);
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
        lblHCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHCustomer.ForeColor = Color.FromArgb(51, 104, 160);
        lblHCustomer.Location = new Point(3, 10);
        lblHCustomer.Name = "lblHCustomer";
        lblHCustomer.Size = new Size(124, 53);
        lblHCustomer.TabIndex = 0;
        lblHCustomer.Text = "Customer:";
        lblHCustomer.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblCustomerInfo
        // 
        lblCustomerInfo.Dock = DockStyle.Fill;
        lblCustomerInfo.Font = new Font("Segoe UI", 9.5F);
        lblCustomerInfo.ForeColor = Color.FromArgb(51, 104, 160);
        lblCustomerInfo.Location = new Point(133, 10);
        lblCustomerInfo.Name = "lblCustomerInfo";
        lblCustomerInfo.Size = new Size(294, 53);
        lblCustomerInfo.TabIndex = 1;
        lblCustomerInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHService
        // 
        lblHService.Dock = DockStyle.Fill;
        lblHService.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHService.ForeColor = Color.FromArgb(51, 104, 160);
        lblHService.Location = new Point(3, 63);
        lblHService.Name = "lblHService";
        lblHService.Size = new Size(124, 53);
        lblHService.TabIndex = 2;
        lblHService.Text = "Service Type:";
        lblHService.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblServiceInfo
        // 
        lblServiceInfo.Dock = DockStyle.Fill;
        lblServiceInfo.Font = new Font("Segoe UI", 9.5F);
        lblServiceInfo.ForeColor = Color.FromArgb(51, 104, 160);
        lblServiceInfo.Location = new Point(133, 63);
        lblServiceInfo.Name = "lblServiceInfo";
        lblServiceInfo.Size = new Size(294, 53);
        lblServiceInfo.TabIndex = 3;
        lblServiceInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHWeight
        // 
        lblHWeight.Dock = DockStyle.Fill;
        lblHWeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHWeight.ForeColor = Color.FromArgb(51, 104, 160);
        lblHWeight.Location = new Point(3, 116);
        lblHWeight.Name = "lblHWeight";
        lblHWeight.Size = new Size(124, 53);
        lblHWeight.TabIndex = 4;
        lblHWeight.Text = "Weight:";
        lblHWeight.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblWeightInfo
        // 
        lblWeightInfo.Dock = DockStyle.Fill;
        lblWeightInfo.Font = new Font("Segoe UI", 9.5F);
        lblWeightInfo.ForeColor = Color.FromArgb(51, 104, 160);
        lblWeightInfo.Location = new Point(133, 116);
        lblWeightInfo.Name = "lblWeightInfo";
        lblWeightInfo.Size = new Size(294, 53);
        lblWeightInfo.TabIndex = 5;
        lblWeightInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHTotal
        // 
        lblHTotal.Dock = DockStyle.Fill;
        lblHTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHTotal.ForeColor = Color.FromArgb(51, 104, 160);
        lblHTotal.Location = new Point(3, 169);
        lblHTotal.Name = "lblHTotal";
        lblHTotal.Size = new Size(124, 53);
        lblHTotal.TabIndex = 6;
        lblHTotal.Text = "Total Amount:";
        lblHTotal.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.Dock = DockStyle.Fill;
        lblTotalAmount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.FromArgb(51, 104, 160);
        lblTotalAmount.Location = new Point(133, 169);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(294, 53);
        lblTotalAmount.TabIndex = 7;
        lblTotalAmount.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHPayment
        // 
        lblHPayment.Dock = DockStyle.Fill;
        lblHPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHPayment.ForeColor = Color.FromArgb(51, 104, 160);
        lblHPayment.Location = new Point(3, 222);
        lblHPayment.Name = "lblHPayment";
        lblHPayment.Size = new Size(124, 53);
        lblHPayment.TabIndex = 8;
        lblHPayment.Text = "Payment:";
        lblHPayment.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblPaymentStatus
        // 
        lblPaymentStatus.Dock = DockStyle.Fill;
        lblPaymentStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPaymentStatus.ForeColor = Color.FromArgb(51, 104, 160);
        lblPaymentStatus.Location = new Point(133, 222);
        lblPaymentStatus.Name = "lblPaymentStatus";
        lblPaymentStatus.Size = new Size(294, 53);
        lblPaymentStatus.TabIndex = 9;
        lblPaymentStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHPickup
        // 
        lblHPickup.Dock = DockStyle.Fill;
        lblHPickup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHPickup.ForeColor = Color.FromArgb(51, 104, 160);
        lblHPickup.Location = new Point(3, 275);
        lblHPickup.Name = "lblHPickup";
        lblHPickup.Size = new Size(124, 53);
        lblHPickup.TabIndex = 10;
        lblHPickup.Text = "Target Pickup:";
        lblHPickup.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblPickupDate
        // 
        lblPickupDate.Dock = DockStyle.Fill;
        lblPickupDate.Font = new Font("Segoe UI", 9.5F);
        lblPickupDate.ForeColor = Color.FromArgb(51, 104, 160);
        lblPickupDate.Location = new Point(133, 275);
        lblPickupDate.Name = "lblPickupDate";
        lblPickupDate.Size = new Size(294, 53);
        lblPickupDate.TabIndex = 11;
        lblPickupDate.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHCreated
        // 
        lblHCreated.Dock = DockStyle.Fill;
        lblHCreated.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHCreated.ForeColor = Color.FromArgb(51, 104, 160);
        lblHCreated.Location = new Point(3, 328);
        lblHCreated.Name = "lblHCreated";
        lblHCreated.Size = new Size(124, 53);
        lblHCreated.TabIndex = 12;
        lblHCreated.Text = "Order Date:";
        lblHCreated.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblCreatedDate
        // 
        lblCreatedDate.Dock = DockStyle.Fill;
        lblCreatedDate.Font = new Font("Segoe UI", 9.5F);
        lblCreatedDate.ForeColor = Color.FromArgb(51, 104, 160);
        lblCreatedDate.Location = new Point(133, 328);
        lblCreatedDate.Name = "lblCreatedDate";
        lblCreatedDate.Size = new Size(294, 53);
        lblCreatedDate.TabIndex = 13;
        lblCreatedDate.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblHCancelReason
        // 
        lblHCancelReason.Dock = DockStyle.Fill;
        lblHCancelReason.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHCancelReason.ForeColor = Color.FromArgb(51, 104, 160);
        lblHCancelReason.Location = new Point(3, 381);
        lblHCancelReason.Name = "lblHCancelReason";
        lblHCancelReason.Size = new Size(124, 59);
        lblHCancelReason.TabIndex = 14;
        lblHCancelReason.Text = "Notes/Reason:";
        lblHCancelReason.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblCancelReason
        // 
        lblCancelReason.Dock = DockStyle.Fill;
        lblCancelReason.Font = new Font("Segoe UI", 9.5F);
        lblCancelReason.ForeColor = Color.FromArgb(51, 104, 160);
        lblCancelReason.Location = new Point(133, 381);
        lblCancelReason.Name = "lblCancelReason";
        lblCancelReason.Size = new Size(294, 59);
        lblCancelReason.TabIndex = 15;
        lblCancelReason.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblDetailsTitle
        // 
        lblDetailsTitle.Dock = DockStyle.Top;
        lblDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblDetailsTitle.ForeColor = Color.FromArgb(51, 104, 160);
        lblDetailsTitle.Location = new Point(20, 20);
        lblDetailsTitle.Name = "lblDetailsTitle";
        lblDetailsTitle.Size = new Size(430, 30);
        lblDetailsTitle.TabIndex = 0;
        lblDetailsTitle.Text = "Order & Customer Details";
        // 
        // FrmOrderDetail
        // 
        AutoScaleDimensions = new SizeF(9F, 21F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(242, 239, 231);
        ClientSize = new Size(820, 620);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(51, 104, 160);
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
    private HopeButton btnClose;
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
    private HopeButton btnAdvanceStatus;
    private HopeButton btnClaimOrder;
    private HopeButton btnCancelOrder;
    private Panel pnlRightWrapper;
    private Panel pnlRightCard;
    private Label lblQrTitle;
    private PictureBox picQrCode;
    private HopeButton btnPrintQr;
    private HopeButton btnResendEmail;
}
