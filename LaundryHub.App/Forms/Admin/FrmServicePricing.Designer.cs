using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using Button = System.Windows.Forms.Button;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Forms.Admin;

partial class FrmServicePricing
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlHeader = new Panel();
        btnClose = new HopeButton();
        lblTitle = new Label();
        pnlContainer = new Panel();
        pnlRight = new Panel();
        pnlGridWrap = new Panel();
        dgvServices = new DataGridView();
        pnlToolBar = new Panel();
        btnToggleActive = new HopeButton();
        lblGridTitle = new Label();
        pnlLeftCard = new Panel();
        flpForm = new FlowLayoutPanel();
        lblServiceName = new Label();
        txtServiceName = new HopeTextBox();
        lblPricePerKilo = new Label();
        txtPricePerKilo = new HopeTextBox();
        lblMinWeight = new Label();
        txtMinWeight = new HopeTextBox();
        chkActive = new CheckBox();
        lblError = new Label();
        flpButtons = new FlowLayoutPanel();
        btnSave = new HopeButton();
        btnClear = new HopeButton();
        lblFormTitle = new Label();
        pnlHeader.SuspendLayout();
        pnlContainer.SuspendLayout();
        pnlRight.SuspendLayout();
        pnlGridWrap.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
        pnlToolBar.SuspendLayout();
        pnlLeftCard.SuspendLayout();
        flpForm.SuspendLayout();
        flpButtons.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(75, 86, 148);
        pnlHeader.Controls.Add(btnClose);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 0, 24, 0);
        pnlHeader.Size = new Size(880, 65);
        pnlHeader.TabIndex = 0;
        // 
        // btnClose
        // 
        btnClose.ButtonType = HopeButtonType.Default;
        btnClose.DefaultColor = Color.FromArgb(114, 136, 174);
        btnClose.BorderColor = Color.FromArgb(234, 224, 207);
        btnClose.TextColor = Color.FromArgb(246, 242, 234);
        btnClose.HoverTextColor = Color.White;
        btnClose.Cursor = Cursors.Hand;
        btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnClose.Location = new Point(766, 16);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(90, 34);
        btnClose.TabIndex = 1;
        btnClose.Text = "✕ Close";
        btnClose.Click += btnClose_Click;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(246, 242, 234);
        lblTitle.Location = new Point(24, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(420, 65);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Service Types & Price Rates";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlContainer
        // 
        pnlContainer.BackColor = Color.FromArgb(246, 242, 234);
        pnlContainer.Controls.Add(pnlRight);
        pnlContainer.Controls.Add(pnlLeftCard);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 65);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(20);
        pnlContainer.Size = new Size(880, 495);
        pnlContainer.TabIndex = 1;
        // 
        // pnlRight
        // 
        pnlRight.BackColor = Color.Transparent;
        pnlRight.Controls.Add(pnlGridWrap);
        pnlRight.Controls.Add(pnlToolBar);
        pnlRight.Dock = DockStyle.Fill;
        pnlRight.Location = new Point(360, 20);
        pnlRight.Name = "pnlRight";
        pnlRight.Padding = new Padding(16, 0, 0, 0);
        pnlRight.Size = new Size(500, 455);
        pnlRight.TabIndex = 1;
        // 
        // pnlGridWrap
        // 
        pnlGridWrap.Controls.Add(dgvServices);
        pnlGridWrap.Dock = DockStyle.Fill;
        pnlGridWrap.Location = new Point(16, 44);
        pnlGridWrap.Name = "pnlGridWrap";
        pnlGridWrap.Padding = new Padding(0, 10, 0, 0);
        pnlGridWrap.Size = new Size(484, 411);
        pnlGridWrap.TabIndex = 1;
        // 
        // dgvServices
        // 
        dgvServices.AllowUserToAddRows = false;
        dgvServices.AllowUserToDeleteRows = false;
        dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvServices.BackgroundColor = Color.White;
        dgvServices.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(75, 86, 148);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(246, 242, 234);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(75, 86, 148);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(246, 242, 234);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(75, 86, 148);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(234, 224, 207);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(75, 86, 148);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvServices.DefaultCellStyle = dataGridViewCellStyle2;
        dgvServices.Dock = DockStyle.Fill;
        dgvServices.EnableHeadersVisualStyles = false;
        dgvServices.GridColor = Color.FromArgb(234, 224, 207);
        dgvServices.Location = new Point(0, 10);
        dgvServices.Name = "dgvServices";
        dgvServices.ReadOnly = true;
        dgvServices.RowHeadersVisible = false;
        dgvServices.RowTemplate.Height = 36;
        dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvServices.Size = new Size(484, 401);
        dgvServices.TabIndex = 0;
        dgvServices.SelectionChanged += dgvServices_SelectionChanged;
        // 
        // pnlToolBar
        // 
        pnlToolBar.BackColor = Color.Transparent;
        pnlToolBar.Controls.Add(lblGridTitle);
        pnlToolBar.Dock = DockStyle.Top;
        pnlToolBar.Location = new Point(16, 0);
        pnlToolBar.Name = "pnlToolBar";
        pnlToolBar.Padding = new Padding(0, 4, 0, 4);
        pnlToolBar.Size = new Size(484, 44);
        pnlToolBar.TabIndex = 0;
        // 
        // btnToggleActive
        // 
        btnToggleActive.ButtonType = HopeButtonType.Default;
        btnToggleActive.DefaultColor = Color.FromArgb(234, 224, 207);
        btnToggleActive.BorderColor = Color.FromArgb(114, 136, 174);
        btnToggleActive.TextColor = Color.FromArgb(75, 86, 148);
        btnToggleActive.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnToggleActive.Cursor = Cursors.Hand;
        btnToggleActive.Dock = DockStyle.Right;
        btnToggleActive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnToggleActive.Location = new Point(290, 4);
        btnToggleActive.Name = "btnToggleActive";
        btnToggleActive.Size = new Size(194, 36);
        btnToggleActive.TabIndex = 1;
        btnToggleActive.Text = "Toggle Active/Disabled";
        btnToggleActive.Click += btnToggleActive_Click;
        // 
        // lblGridTitle
        // 
        lblGridTitle.Dock = DockStyle.Left;
        lblGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblGridTitle.ForeColor = Color.FromArgb(75, 86, 148);
        lblGridTitle.Location = new Point(0, 4);
        lblGridTitle.Name = "lblGridTitle";
        lblGridTitle.Size = new Size(200, 36);
        lblGridTitle.TabIndex = 0;
        lblGridTitle.Text = "Available Services List";
        lblGridTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlLeftCard
        // 
        pnlLeftCard.BackColor = Color.White;
        pnlLeftCard.Controls.Add(flpForm);
        pnlLeftCard.Controls.Add(lblFormTitle);
        pnlLeftCard.Dock = DockStyle.Left;
        pnlLeftCard.Location = new Point(20, 20);
        pnlLeftCard.Name = "pnlLeftCard";
        pnlLeftCard.Padding = new Padding(20);
        pnlLeftCard.Size = new Size(340, 455);
        pnlLeftCard.TabIndex = 0;
        // 
        // flpForm
        // 
        flpForm.AutoScroll = true;
        flpForm.BackColor = Color.Transparent;
        flpForm.Controls.Add(lblServiceName);
        flpForm.Controls.Add(txtServiceName);
        flpForm.Controls.Add(lblPricePerKilo);
        flpForm.Controls.Add(txtPricePerKilo);
        flpForm.Controls.Add(lblMinWeight);
        flpForm.Controls.Add(txtMinWeight);
        flpForm.Controls.Add(lblError);
        flpForm.Controls.Add(flpButtons);
        flpForm.Dock = DockStyle.Fill;
        flpForm.FlowDirection = FlowDirection.TopDown;
        flpForm.Location = new Point(20, 55);
        flpForm.Name = "flpForm";
        flpForm.Size = new Size(300, 380);
        flpForm.TabIndex = 1;
        flpForm.WrapContents = false;
        // 
        // lblServiceName
        // 
        lblServiceName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblServiceName.ForeColor = Color.FromArgb(75, 86, 148);
        lblServiceName.Location = new Point(0, 4);
        lblServiceName.Margin = new Padding(0, 4, 0, 2);
        lblServiceName.Name = "lblServiceName";
        lblServiceName.Size = new Size(290, 18);
        lblServiceName.TabIndex = 0;
        lblServiceName.Text = "Service Name * (e.g. Wash & Dry)";
        // 
        // txtServiceName
        // 
        txtServiceName.BackColor = Color.White;
        txtServiceName.BaseColor = Color.White;
        txtServiceName.BorderColorA = Color.FromArgb(75, 86, 148);
        txtServiceName.BorderColorB = Color.FromArgb(190, 196, 220);
        txtServiceName.Font = new Font("Segoe UI", 9.5F);
        txtServiceName.ForeColor = Color.FromArgb(75, 86, 148);
        txtServiceName.Hint = "Enter service name";
        txtServiceName.Location = new Point(0, 26);
        txtServiceName.Margin = new Padding(0, 2, 0, 4);
        txtServiceName.Name = "txtServiceName";
        txtServiceName.Size = new Size(290, 34);
        txtServiceName.TabIndex = 1;
        // 
        // lblPricePerKilo
        // 
        lblPricePerKilo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPricePerKilo.ForeColor = Color.FromArgb(75, 86, 148);
        lblPricePerKilo.Location = new Point(0, 66);
        lblPricePerKilo.Margin = new Padding(0, 4, 0, 2);
        lblPricePerKilo.Name = "lblPricePerKilo";
        lblPricePerKilo.Size = new Size(290, 18);
        lblPricePerKilo.TabIndex = 2;
        lblPricePerKilo.Text = "Price Per Kilo (₱) *";
        // 
        // txtPricePerKilo
        // 
        txtPricePerKilo.BackColor = Color.White;
        txtPricePerKilo.BaseColor = Color.White;
        txtPricePerKilo.BorderColorA = Color.FromArgb(75, 86, 148);
        txtPricePerKilo.BorderColorB = Color.FromArgb(190, 196, 220);
        txtPricePerKilo.Font = new Font("Segoe UI", 9.5F);
        txtPricePerKilo.ForeColor = Color.FromArgb(75, 86, 148);
        txtPricePerKilo.Hint = "0.00";
        txtPricePerKilo.Location = new Point(0, 88);
        txtPricePerKilo.Margin = new Padding(0, 2, 0, 4);
        txtPricePerKilo.Name = "txtPricePerKilo";
        txtPricePerKilo.Size = new Size(290, 34);
        txtPricePerKilo.TabIndex = 3;
        // 
        // lblMinWeight
        // 
        lblMinWeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblMinWeight.ForeColor = Color.FromArgb(75, 86, 148);
        lblMinWeight.Location = new Point(0, 128);
        lblMinWeight.Margin = new Padding(0, 4, 0, 2);
        lblMinWeight.Name = "lblMinWeight";
        lblMinWeight.Size = new Size(290, 18);
        lblMinWeight.TabIndex = 4;
        lblMinWeight.Text = "Minimum Weight (kg) *";
        // 
        // txtMinWeight
        // 
        txtMinWeight.BackColor = Color.White;
        txtMinWeight.BaseColor = Color.White;
        txtMinWeight.BorderColorA = Color.FromArgb(75, 86, 148);
        txtMinWeight.BorderColorB = Color.FromArgb(190, 196, 220);
        txtMinWeight.Font = new Font("Segoe UI", 9.5F);
        txtMinWeight.ForeColor = Color.FromArgb(75, 86, 148);
        txtMinWeight.Hint = "1.0";
        txtMinWeight.Location = new Point(0, 150);
        txtMinWeight.Margin = new Padding(0, 2, 0, 4);
        txtMinWeight.Name = "txtMinWeight";
        txtMinWeight.Size = new Size(290, 34);
        txtMinWeight.TabIndex = 5;
        // 
        // chkActive
        // 
        chkActive.Checked = true;
        chkActive.CheckState = CheckState.Checked;
        chkActive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        chkActive.ForeColor = Color.FromArgb(75, 86, 148);
        chkActive.Location = new Point(0, 190);
        chkActive.Name = "chkActive";
        chkActive.Padding = new Padding(0, 4, 0, 4);
        chkActive.Size = new Size(290, 30);
        chkActive.TabIndex = 6;
        chkActive.Text = "Active Service";
        chkActive.UseVisualStyleBackColor = true;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 9F);
        lblError.ForeColor = Color.FromArgb(184, 72, 88);
        lblError.Location = new Point(0, 224);
        lblError.Name = "lblError";
        lblError.Size = new Size(290, 28);
        lblError.TabIndex = 7;
        lblError.Visible = false;
        // 
        // flpButtons
        // 
        flpButtons.Controls.Add(btnSave);
        flpButtons.Controls.Add(btnClear);
        flpButtons.Location = new Point(0, 256);
        flpButtons.Name = "flpButtons";
        flpButtons.Size = new Size(290, 60);
        flpButtons.TabIndex = 8;
        // 
        // btnSave
        // 
        btnSave.ButtonType = HopeButtonType.Primary;
        btnSave.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnSave.TextColor = Color.FromArgb(246, 242, 234);
        btnSave.HoverTextColor = Color.White;
        btnSave.Cursor = Cursors.Hand;
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.Location = new Point(3, 3);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(135, 40);
        btnSave.TabIndex = 0;
        btnSave.Text = "Save Service";
        btnSave.Click += btnSave_Click;
        // 
        // btnClear
        // 
        btnClear.ButtonType = HopeButtonType.Default;
        btnClear.DefaultColor = Color.FromArgb(234, 224, 207);
        btnClear.BorderColor = Color.FromArgb(114, 136, 174);
        btnClear.TextColor = Color.FromArgb(75, 86, 148);
        btnClear.HoverTextColor = Color.FromArgb(75, 86, 148);
        btnClear.Cursor = Cursors.Hand;
        btnClear.Font = new Font("Segoe UI", 9.5F);
        btnClear.Location = new Point(144, 3);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(135, 40);
        btnClear.TabIndex = 1;
        btnClear.Text = "↺ Clear";
        btnClear.Click += btnClear_Click;
        // 
        // lblFormTitle
        // 
        lblFormTitle.Dock = DockStyle.Top;
        lblFormTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblFormTitle.ForeColor = Color.FromArgb(75, 86, 148);
        lblFormTitle.Location = new Point(20, 20);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(300, 35);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "New Service Type";
        // 
        // FrmServicePricing
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(246, 242, 234);
        ClientSize = new Size(880, 560);
        Controls.Add(pnlContainer);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(75, 86, 148);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FrmServicePricing";
        StartPosition = FormStartPosition.CenterParent;
        Text = "LaundryHub – Service Types & Pricing Management";
        pnlHeader.ResumeLayout(false);
        pnlContainer.ResumeLayout(false);
        pnlRight.ResumeLayout(false);
        pnlGridWrap.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
        pnlToolBar.ResumeLayout(false);
        pnlLeftCard.ResumeLayout(false);
        flpForm.ResumeLayout(false);
        flpForm.PerformLayout();
        flpButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblTitle;
    private HopeButton btnClose;
    private Panel pnlContainer;
    private Panel pnlLeftCard;
    private Label lblFormTitle;
    private FlowLayoutPanel flpForm;
    private Label lblServiceName;
    private HopeTextBox txtServiceName;
    private Label lblPricePerKilo;
    private HopeTextBox txtPricePerKilo;
    private Label lblMinWeight;
    private HopeTextBox txtMinWeight;
    private CheckBox chkActive;
    private Label lblError;
    private FlowLayoutPanel flpButtons;
    private HopeButton btnSave;
    private HopeButton btnClear;
    private Panel pnlRight;
    private Panel pnlToolBar;
    private Label lblGridTitle;
    private HopeButton btnToggleActive;
    private Panel pnlGridWrap;
    private DataGridView dgvServices;
}
