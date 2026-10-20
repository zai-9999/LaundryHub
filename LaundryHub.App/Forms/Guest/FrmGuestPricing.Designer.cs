using Panel = System.Windows.Forms.Panel;
using Button = System.Windows.Forms.Button;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Guest;

partial class FrmGuestPricing
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
        pnlBody = new Panel();
        pnlCalculator = new Panel();
        lblCalcTitle = new Label();
        lblServiceSelect = new Label();
        cmbService = new ComboBox();
        lblWeightInput = new Label();
        txtWeight = new TextBox();
        lblEstimatedTotal = new Label();
        lblEstimateValue = new Label();
        lblCalcNote = new Label();
        dgvPricing = new DataGridView();
        pnlBanner = new Panel();
        lblBannerText = new Label();
        btnRegister = new HopeButton();
        btnClose = new HopeButton();
        pnlHeader.SuspendLayout();
        pnlBody.SuspendLayout();
        pnlCalculator.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPricing).BeginInit();
        pnlBanner.SuspendLayout();
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
        pnlHeader.Size = new Size(680, 75);
        pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(20, 12);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(270, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Laundry Rates & Pricing";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9F);
        lblSubtitle.ForeColor = Color.FromArgb(234, 224, 207);
        lblSubtitle.Location = new Point(22, 44);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(330, 20);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Standard transparent pricing for all laundry needs";
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
        btnCloseTop.Location = new Point(630, 15);
        btnCloseTop.Name = "btnCloseTop";
        btnCloseTop.Size = new Size(35, 35);
        btnCloseTop.TabIndex = 2;
        btnCloseTop.Text = "✕";
        btnCloseTop.UseVisualStyleBackColor = false;
        btnCloseTop.Click += btnClose_Click;
        // 
        // pnlBody
        // 
        pnlBody.BackColor = Color.White;
        pnlBody.Controls.Add(dgvPricing);
        pnlBody.Controls.Add(pnlCalculator);
        pnlBody.Controls.Add(pnlBanner);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(0, 75);
        pnlBody.Name = "pnlBody";
        pnlBody.Padding = new Padding(24);
        pnlBody.Size = new Size(680, 565);
        pnlBody.TabIndex = 1;
        // 
        // dgvPricing
        // 
        dgvPricing.AllowUserToAddRows = false;
        dgvPricing.AllowUserToDeleteRows = false;
        dgvPricing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPricing.BackgroundColor = Color.White;
        dgvPricing.BorderStyle = BorderStyle.None;
        dgvPricing.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPricing.Dock = DockStyle.Fill;
        dgvPricing.Location = new Point(24, 24);
        dgvPricing.Name = "dgvPricing";
        dgvPricing.ReadOnly = true;
        dgvPricing.RowHeadersVisible = false;
        dgvPricing.RowTemplate.Height = 36;
        dgvPricing.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPricing.Size = new Size(632, 220);
        dgvPricing.TabIndex = 0;
        // 
        // pnlCalculator
        // 
        pnlCalculator.BackColor = Color.FromArgb(248, 245, 239);
        pnlCalculator.BorderStyle = BorderStyle.FixedSingle;
        pnlCalculator.Controls.Add(lblCalcTitle);
        pnlCalculator.Controls.Add(lblServiceSelect);
        pnlCalculator.Controls.Add(cmbService);
        pnlCalculator.Controls.Add(lblWeightInput);
        pnlCalculator.Controls.Add(txtWeight);
        pnlCalculator.Controls.Add(lblEstimatedTotal);
        pnlCalculator.Controls.Add(lblEstimateValue);
        pnlCalculator.Controls.Add(lblCalcNote);
        pnlCalculator.Dock = DockStyle.Bottom;
        pnlCalculator.Location = new Point(24, 254);
        pnlCalculator.Name = "pnlCalculator";
        pnlCalculator.Padding = new Padding(16);
        pnlCalculator.Size = new Size(632, 175);
        pnlCalculator.TabIndex = 1;
        // 
        // lblCalcTitle
        // 
        lblCalcTitle.AutoSize = true;
        lblCalcTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblCalcTitle.ForeColor = Color.FromArgb(17, 24, 68);
        lblCalcTitle.Location = new Point(14, 12);
        lblCalcTitle.Name = "lblCalcTitle";
        lblCalcTitle.Size = new Size(205, 25);
        lblCalcTitle.TabIndex = 0;
        lblCalcTitle.Text = "💡 Quick Price Calculator";
        // 
        // lblServiceSelect
        // 
        lblServiceSelect.AutoSize = true;
        lblServiceSelect.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblServiceSelect.ForeColor = Color.FromArgb(75, 86, 148);
        lblServiceSelect.Location = new Point(16, 48);
        lblServiceSelect.Name = "lblServiceSelect";
        lblServiceSelect.Size = new Size(61, 20);
        lblServiceSelect.TabIndex = 1;
        lblServiceSelect.Text = "Service:";
        // 
        // cmbService
        // 
        cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbService.Font = new Font("Segoe UI", 9.5F);
        cmbService.FormattingEnabled = true;
        cmbService.Location = new Point(16, 72);
        cmbService.Name = "cmbService";
        cmbService.Size = new Size(220, 29);
        cmbService.TabIndex = 2;
        cmbService.SelectedIndexChanged += cmbService_SelectedIndexChanged;
        // 
        // lblWeightInput
        // 
        lblWeightInput.AutoSize = true;
        lblWeightInput.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblWeightInput.ForeColor = Color.FromArgb(75, 86, 148);
        lblWeightInput.Location = new Point(255, 48);
        lblWeightInput.Name = "lblWeightInput";
        lblWeightInput.Size = new Size(130, 20);
        lblWeightInput.TabIndex = 3;
        lblWeightInput.Text = "Weight Load (kg):";
        // 
        // txtWeight
        // 
        txtWeight.Font = new Font("Segoe UI", 9.5F);
        txtWeight.Location = new Point(255, 72);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(130, 29);
        txtWeight.TabIndex = 4;
        txtWeight.Text = "5.0";
        txtWeight.TextChanged += txtWeight_TextChanged;
        // 
        // lblEstimatedTotal
        // 
        lblEstimatedTotal.AutoSize = true;
        lblEstimatedTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEstimatedTotal.ForeColor = Color.FromArgb(75, 86, 148);
        lblEstimatedTotal.Location = new Point(415, 48);
        lblEstimatedTotal.Name = "lblEstimatedTotal";
        lblEstimatedTotal.Size = new Size(120, 20);
        lblEstimatedTotal.TabIndex = 5;
        lblEstimatedTotal.Text = "Estimated Total:";
        // 
        // lblEstimateValue
        // 
        lblEstimateValue.AutoSize = true;
        lblEstimateValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblEstimateValue.ForeColor = Color.FromArgb(74, 160, 120);
        lblEstimateValue.Location = new Point(415, 68);
        lblEstimateValue.Name = "lblEstimateValue";
        lblEstimateValue.Size = new Size(92, 37);
        lblEstimateValue.TabIndex = 6;
        lblEstimateValue.Text = "₱0.00";
        // 
        // lblCalcNote
        // 
        lblCalcNote.AutoSize = true;
        lblCalcNote.Font = new Font("Segoe UI", 8.5F);
        lblCalcNote.ForeColor = Color.FromArgb(100, 116, 139);
        lblCalcNote.Location = new Point(16, 120);
        lblCalcNote.Name = "lblCalcNote";
        lblCalcNote.Size = new Size(480, 20);
        lblCalcNote.TabIndex = 7;
        lblCalcNote.Text = "* Orders below the minimum weight threshold are billed at minimum weight.";
        // 
        // pnlBanner
        // 
        pnlBanner.BackColor = Color.FromArgb(248, 245, 239);
        pnlBanner.Controls.Add(lblBannerText);
        pnlBanner.Controls.Add(btnRegister);
        pnlBanner.Controls.Add(btnClose);
        pnlBanner.Dock = DockStyle.Bottom;
        pnlBanner.Location = new Point(24, 429);
        pnlBanner.Name = "pnlBanner";
        pnlBanner.Padding = new Padding(12);
        pnlBanner.Size = new Size(632, 112);
        pnlBanner.TabIndex = 2;
        // 
        // lblBannerText
        // 
        lblBannerText.Font = new Font("Segoe UI", 9F);
        lblBannerText.ForeColor = Color.FromArgb(17, 24, 68);
        lblBannerText.Location = new Point(14, 10);
        lblBannerText.Name = "lblBannerText";
        lblBannerText.Size = new Size(604, 42);
        lblBannerText.TabIndex = 0;
        lblBannerText.Text = "Guests can view pricing and track existing tickets. To place an order, schedule a pickup, or receive digital QR tickets, please create a customer account!";
        // 
        // btnRegister
        // 
        btnRegister.BorderColor = Color.FromArgb(75, 86, 148);
        btnRegister.ButtonType = HopeButtonType.Primary;
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnRegister.HoverTextColor = Color.White;
        btnRegister.Location = new Point(14, 60);
        btnRegister.Name = "btnRegister";
        btnRegister.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnRegister.Size = new Size(230, 40);
        btnRegister.TabIndex = 1;
        btnRegister.Text = "Register Account to Order";
        btnRegister.TextColor = Color.White;
        btnRegister.Click += btnRegister_Click;
        // 
        // btnClose
        // 
        btnClose.BorderColor = Color.FromArgb(114, 136, 174);
        btnClose.ButtonType = HopeButtonType.Default;
        btnClose.Cursor = Cursors.Hand;
        btnClose.DefaultColor = Color.FromArgb(246, 242, 234);
        btnClose.Font = new Font("Segoe UI", 9.5F);
        btnClose.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnClose.Location = new Point(255, 60);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(130, 40);
        btnClose.TabIndex = 2;
        btnClose.Text = "Close";
        btnClose.TextColor = Color.FromArgb(75, 86, 148);
        btnClose.Click += btnClose_Click;
        // 
        // FrmGuestPricing
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(680, 640);
        Controls.Add(pnlBody);
        Controls.Add(pnlHeader);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmGuestPricing";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub – Pricing & Services";
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlBody.ResumeLayout(false);
        pnlCalculator.ResumeLayout(false);
        pnlCalculator.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPricing).EndInit();
        pnlBanner.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblTitle;
    private Label lblSubtitle;
    private Button btnCloseTop;
    private Panel pnlBody;
    private DataGridView dgvPricing;
    private Panel pnlCalculator;
    private Label lblCalcTitle;
    private Label lblServiceSelect;
    private ComboBox cmbService;
    private Label lblWeightInput;
    private TextBox txtWeight;
    private Label lblEstimatedTotal;
    private Label lblEstimateValue;
    private Label lblCalcNote;
    private Panel pnlBanner;
    private Label lblBannerText;
    private HopeButton btnRegister;
    private HopeButton btnClose;
}
