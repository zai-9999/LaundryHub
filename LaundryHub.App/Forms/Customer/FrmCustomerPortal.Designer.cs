using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;
using LaundryHub.App.Helpers;

namespace LaundryHub.App.Forms.Customer;

partial class FrmCustomerPortal
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
        pnlSidebar = new ModernSidebar();
        pnlHeader = new ModernHeaderBar();
        pnlBody = new Panel();
        cardGrid = new RoundedCard();
        dgvOrders = new DataGridView();
        tlpToolbar = new TableLayoutPanel();
        lblOrdersTitle = new Label();
        chkActiveOnly = new CheckBox();
        btnViewTicket = new HopeButton();
        tlpStats = new TableLayoutPanel();
        cardActive = new RoundedCard();
        lblActiveStat = new Label();
        lblActiveTitle = new Label();
        stripActive = new Panel();
        cardReady = new RoundedCard();
        lblReadyStat = new Label();
        lblReadyTitle = new Label();
        stripReady = new Panel();
        cardTotal = new RoundedCard();
        lblTotalStat = new Label();
        lblTotalTitle = new Label();
        stripTotal = new Panel();
        pnlBody.SuspendLayout();
        cardGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        tlpToolbar.SuspendLayout();
        tlpStats.SuspendLayout();
        cardActive.SuspendLayout();
        cardReady.SuspendLayout();
        cardTotal.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(240, 720);
        pnlSidebar.TabIndex = 0;
        // 
        // pnlHeader
        // 
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(240, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(940, 72);
        pnlHeader.TabIndex = 1;
        // 
        // pnlBody
        // 
        pnlBody.BackColor = Color.FromArgb(245, 247, 250);
        pnlBody.Controls.Add(cardGrid);
        pnlBody.Controls.Add(tlpStats);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(240, 72);
        pnlBody.Name = "pnlBody";
        pnlBody.Padding = new Padding(20);
        pnlBody.Size = new Size(940, 648);
        pnlBody.TabIndex = 2;
        // 
        // cardGrid
        // 
        cardGrid.BackColor = Color.Transparent;
        cardGrid.BorderColor = Color.FromArgb(226, 230, 240);
        cardGrid.Controls.Add(dgvOrders);
        cardGrid.Controls.Add(tlpToolbar);
        cardGrid.Dock = DockStyle.Fill;
        cardGrid.FillColor = Color.White;
        cardGrid.Location = new Point(20, 134);
        cardGrid.Margin = new Padding(0);
        cardGrid.Name = "cardGrid";
        cardGrid.Padding = new Padding(16, 12, 16, 14);
        cardGrid.Radius = 14;
        cardGrid.Shadow = true;
        cardGrid.Size = new Size(900, 494);
        cardGrid.TabIndex = 2;
        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor = Color.White;
        dgvOrders.BorderStyle = BorderStyle.None;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.GridColor = Color.FromArgb(234, 224, 207);
        dgvOrders.Location = new Point(16, 62);
        dgvOrders.MultiSelect = false;
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(868, 418);
        dgvOrders.TabIndex = 0;
        dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
        // 
        // tlpToolbar
        // 
        tlpToolbar.BackColor = Color.White;
        tlpToolbar.ColumnCount = 3;
        tlpToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
        tlpToolbar.Controls.Add(lblOrdersTitle, 0, 0);
        tlpToolbar.Controls.Add(chkActiveOnly, 1, 0);
        tlpToolbar.Controls.Add(btnViewTicket, 2, 0);
        tlpToolbar.Dock = DockStyle.Top;
        tlpToolbar.Location = new Point(16, 12);
        tlpToolbar.Name = "tlpToolbar";
        tlpToolbar.RowCount = 1;
        tlpToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpToolbar.Size = new Size(868, 50);
        tlpToolbar.TabIndex = 1;
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.Anchor = AnchorStyles.Left;
        lblOrdersTitle.AutoSize = true;
        lblOrdersTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblOrdersTitle.ForeColor = Color.FromArgb(17, 24, 68);
        lblOrdersTitle.Location = new Point(0, 14);
        lblOrdersTitle.Margin = new Padding(0);
        lblOrdersTitle.Name = "lblOrdersTitle";
        lblOrdersTitle.Size = new Size(188, 21);
        lblOrdersTitle.TabIndex = 0;
        lblOrdersTitle.Text = "My Laundry Orders";
        // 
        // chkActiveOnly
        // 
        chkActiveOnly.Anchor = AnchorStyles.Left;
        chkActiveOnly.AutoSize = true;
        chkActiveOnly.Cursor = Cursors.Hand;
        chkActiveOnly.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        chkActiveOnly.ForeColor = Color.FromArgb(75, 86, 148);
        chkActiveOnly.Location = new Point(327, 15);
        chkActiveOnly.Name = "chkActiveOnly";
        chkActiveOnly.Size = new Size(160, 19);
        chkActiveOnly.TabIndex = 1;
        chkActiveOnly.Text = "Active In-Process Only";
        chkActiveOnly.UseVisualStyleBackColor = true;
        chkActiveOnly.CheckedChanged += chkActiveOnly_CheckedChanged;
        // 
        // btnViewTicket
        // 
        btnViewTicket.Anchor = AnchorStyles.Right;
        btnViewTicket.ButtonType = HopeButtonType.Primary;
        btnViewTicket.PrimaryColor = Color.FromArgb(75, 86, 148);
        btnViewTicket.BorderColor = Color.FromArgb(75, 86, 148);
        btnViewTicket.TextColor = Color.White;
        btnViewTicket.HoverTextColor = Color.White;
        btnViewTicket.Cursor = Cursors.Hand;
        btnViewTicket.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnViewTicket.Location = new Point(658, 6);
        btnViewTicket.Margin = new Padding(0);
        btnViewTicket.Name = "btnViewTicket";
        btnViewTicket.Size = new Size(210, 38);
        btnViewTicket.TabIndex = 2;
        btnViewTicket.Text = " View E-Ticket / Receipt";
        btnViewTicket.Click += BtnViewTicket_Click;
        // 
        // tlpStats
        // 
        tlpStats.BackColor = Color.Transparent;
        tlpStats.ColumnCount = 3;
        tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
        tlpStats.Controls.Add(cardActive, 0, 0);
        tlpStats.Controls.Add(cardReady, 1, 0);
        tlpStats.Controls.Add(cardTotal, 2, 0);
        tlpStats.Dock = DockStyle.Top;
        tlpStats.Location = new Point(20, 20);
        tlpStats.Margin = new Padding(0);
        tlpStats.Name = "tlpStats";
        tlpStats.RowCount = 1;
        tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpStats.Size = new Size(900, 114);
        tlpStats.TabIndex = 0;
        // 
        // cardActive
        // 
        cardActive.BackColor = Color.Transparent;
        cardActive.BorderColor = Color.FromArgb(226, 230, 240);
        cardActive.Controls.Add(lblActiveStat);
        cardActive.Controls.Add(lblActiveTitle);
        cardActive.Controls.Add(stripActive);
        cardActive.Dock = DockStyle.Fill;
        cardActive.FillColor = Color.White;
        cardActive.Location = new Point(0, 0);
        cardActive.Margin = new Padding(0, 0, 14, 0);
        cardActive.Name = "cardActive";
        cardActive.Padding = new Padding(16, 12, 16, 14);
        cardActive.Radius = 14;
        cardActive.Shadow = true;
        cardActive.Size = new Size(285, 114);
        cardActive.TabIndex = 0;
        // 
        // lblActiveStat
        // 
        lblActiveStat.BackColor = Color.Transparent;
        lblActiveStat.Dock = DockStyle.Fill;
        lblActiveStat.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblActiveStat.ForeColor = Color.FromArgb(17, 24, 68);
        lblActiveStat.Location = new Point(20, 32);
        lblActiveStat.Name = "lblActiveStat";
        lblActiveStat.Padding = new Padding(10, 0, 0, 0);
        lblActiveStat.Size = new Size(249, 68);
        lblActiveStat.TabIndex = 0;
        lblActiveStat.Text = "0";
        lblActiveStat.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblActiveTitle
        // 
        lblActiveTitle.BackColor = Color.Transparent;
        lblActiveTitle.Dock = DockStyle.Top;
        lblActiveTitle.Font = new Font("Segoe UI", 9.5F);
        lblActiveTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblActiveTitle.Location = new Point(20, 12);
        lblActiveTitle.Name = "lblActiveTitle";
        lblActiveTitle.Padding = new Padding(10, 0, 0, 0);
        lblActiveTitle.Size = new Size(249, 20);
        lblActiveTitle.TabIndex = 1;
        lblActiveTitle.Text = "Active In-Process";
        lblActiveTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // stripActive
        // 
        stripActive.BackColor = Color.FromArgb(75, 86, 148);
        stripActive.Dock = DockStyle.Left;
        stripActive.Location = new Point(16, 12);
        stripActive.Name = "stripActive";
        stripActive.Size = new Size(4, 88);
        stripActive.TabIndex = 2;
        // 
        // cardReady
        // 
        cardReady.BackColor = Color.Transparent;
        cardReady.BorderColor = Color.FromArgb(226, 230, 240);
        cardReady.Controls.Add(lblReadyStat);
        cardReady.Controls.Add(lblReadyTitle);
        cardReady.Controls.Add(stripReady);
        cardReady.Dock = DockStyle.Fill;
        cardReady.FillColor = Color.White;
        cardReady.Location = new Point(299, 0);
        cardReady.Margin = new Padding(0, 0, 14, 0);
        cardReady.Name = "cardReady";
        cardReady.Padding = new Padding(16, 12, 16, 14);
        cardReady.Radius = 14;
        cardReady.Shadow = true;
        cardReady.Size = new Size(285, 114);
        cardReady.TabIndex = 1;
        // 
        // lblReadyStat
        // 
        lblReadyStat.BackColor = Color.Transparent;
        lblReadyStat.Dock = DockStyle.Fill;
        lblReadyStat.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblReadyStat.ForeColor = Color.FromArgb(17, 24, 68);
        lblReadyStat.Location = new Point(20, 32);
        lblReadyStat.Name = "lblReadyStat";
        lblReadyStat.Padding = new Padding(10, 0, 0, 0);
        lblReadyStat.Size = new Size(249, 68);
        lblReadyStat.TabIndex = 0;
        lblReadyStat.Text = "0";
        lblReadyStat.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblReadyTitle
        // 
        lblReadyTitle.BackColor = Color.Transparent;
        lblReadyTitle.Dock = DockStyle.Top;
        lblReadyTitle.Font = new Font("Segoe UI", 9.5F);
        lblReadyTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblReadyTitle.Location = new Point(20, 12);
        lblReadyTitle.Name = "lblReadyTitle";
        lblReadyTitle.Padding = new Padding(10, 0, 0, 0);
        lblReadyTitle.Size = new Size(249, 20);
        lblReadyTitle.TabIndex = 1;
        lblReadyTitle.Text = "Ready for Pickup";
        lblReadyTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // stripReady
        // 
        stripReady.BackColor = Color.FromArgb(22, 163, 74);
        stripReady.Dock = DockStyle.Left;
        stripReady.Location = new Point(16, 12);
        stripReady.Name = "stripReady";
        stripReady.Size = new Size(4, 88);
        stripReady.TabIndex = 2;
        // 
        // cardTotal
        // 
        cardTotal.BackColor = Color.Transparent;
        cardTotal.BorderColor = Color.FromArgb(226, 230, 240);
        cardTotal.Controls.Add(lblTotalStat);
        cardTotal.Controls.Add(lblTotalTitle);
        cardTotal.Controls.Add(stripTotal);
        cardTotal.Dock = DockStyle.Fill;
        cardTotal.FillColor = Color.White;
        cardTotal.Location = new Point(598, 0);
        cardTotal.Margin = new Padding(0);
        cardTotal.Name = "cardTotal";
        cardTotal.Padding = new Padding(16, 12, 16, 14);
        cardTotal.Radius = 14;
        cardTotal.Shadow = true;
        cardTotal.Size = new Size(302, 114);
        cardTotal.TabIndex = 2;
        // 
        // lblTotalStat
        // 
        lblTotalStat.BackColor = Color.Transparent;
        lblTotalStat.Dock = DockStyle.Fill;
        lblTotalStat.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTotalStat.ForeColor = Color.FromArgb(17, 24, 68);
        lblTotalStat.Location = new Point(20, 32);
        lblTotalStat.Name = "lblTotalStat";
        lblTotalStat.Padding = new Padding(10, 0, 0, 0);
        lblTotalStat.Size = new Size(266, 68);
        lblTotalStat.TabIndex = 0;
        lblTotalStat.Text = "0";
        lblTotalStat.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblTotalTitle
        // 
        lblTotalTitle.BackColor = Color.Transparent;
        lblTotalTitle.Dock = DockStyle.Top;
        lblTotalTitle.Font = new Font("Segoe UI", 9.5F);
        lblTotalTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblTotalTitle.Location = new Point(20, 12);
        lblTotalTitle.Name = "lblTotalTitle";
        lblTotalTitle.Padding = new Padding(10, 0, 0, 0);
        lblTotalTitle.Size = new Size(266, 20);
        lblTotalTitle.TabIndex = 1;
        lblTotalTitle.Text = "Total Laundry Bookings";
        lblTotalTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // stripTotal
        // 
        stripTotal.BackColor = Color.FromArgb(114, 136, 174);
        stripTotal.Dock = DockStyle.Left;
        stripTotal.Location = new Point(16, 12);
        stripTotal.Name = "stripTotal";
        stripTotal.Size = new Size(4, 88);
        stripTotal.TabIndex = 2;
        // 
        // FrmCustomerPortal
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1180, 720);
        Controls.Add(pnlBody);
        Controls.Add(pnlHeader);
        Controls.Add(pnlSidebar);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(17, 24, 68);
        MinimumSize = new Size(980, 620);
        Name = "FrmCustomerPortal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub  Customer Portal";
        pnlBody.ResumeLayout(false);
        cardGrid.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        tlpToolbar.ResumeLayout(false);
        tlpToolbar.PerformLayout();
        tlpStats.ResumeLayout(false);
        cardActive.ResumeLayout(false);
        cardReady.ResumeLayout(false);
        cardTotal.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ModernSidebar pnlSidebar;
    private ModernHeaderBar pnlHeader;
    private Panel pnlBody;
    private RoundedCard cardGrid;
    private DataGridView dgvOrders;
    private TableLayoutPanel tlpToolbar;
    private Label lblOrdersTitle;
    private CheckBox chkActiveOnly;
    private HopeButton btnViewTicket;
    private TableLayoutPanel tlpStats;
    private RoundedCard cardActive;
    private Panel stripActive;
    private Label lblActiveTitle;
    private Label lblActiveStat;
    private RoundedCard cardReady;
    private Panel stripReady;
    private Label lblReadyTitle;
    private Label lblReadyStat;
    private RoundedCard cardTotal;
    private Panel stripTotal;
    private Label lblTotalTitle;
    private Label lblTotalStat;
}
