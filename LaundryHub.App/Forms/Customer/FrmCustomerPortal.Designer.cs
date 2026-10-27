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
        pnlSidebar    = new ModernSidebar();
        pnlHeader     = new ModernHeaderBar();
        pnlBody       = new Panel();
        cardGrid      = new RoundedCard();
        dgvOrders     = new DataGridView();
        pnlToolbar    = new Panel();
        lblOrdersTitle = new Label();
        chkActiveOnly  = new CheckBox();
        txtSearch      = new HopeTextBox();
        btnViewTicket  = new HopeButton();
        tlpStats       = new TableLayoutPanel();
        cardActive     = new RoundedCard();
        lblActiveStat  = new Label();
        lblActiveTitle = new Label();
        stripActive    = new Panel();
        cardReady      = new RoundedCard();
        lblReadyStat   = new Label();
        lblReadyTitle  = new Label();
        stripReady     = new Panel();
        cardTotal      = new RoundedCard();
        lblTotalStat   = new Label();
        lblTotalTitle  = new Label();
        stripTotal     = new Panel();
        pnlBody.SuspendLayout();
        cardGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        pnlToolbar.SuspendLayout();
        tlpStats.SuspendLayout();
        cardActive.SuspendLayout();
        cardReady.SuspendLayout();
        cardTotal.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(17, 24, 68);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(240, 720);
        pnlSidebar.TabIndex = 0;
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.White;
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(240, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 12, 24, 12);
        pnlHeader.Size = new Size(940, 72);
        pnlHeader.Subtitle = "REAL-TIME LAUNDRY WORKFLOW, PERFORMANCE & REVENUE MONITORING";
        pnlHeader.TabIndex = 1;
        pnlHeader.Title = "Platform Overview & Analytics";
        pnlHeader.UserName = "Administrator";
        pnlHeader.UserRole = "System Admin";
        // 
        // pnlBody
        // 
        pnlBody.BackColor = Color.FromArgb(245, 247, 250);
        pnlBody.Controls.Add(cardGrid);
        pnlBody.Controls.Add(tlpStats);
        pnlBody.Dock      = DockStyle.Fill;
        pnlBody.Location  = new Point(240, 72);
        pnlBody.Name      = "pnlBody";
        pnlBody.Padding   = new Padding(20, 16, 20, 20);
        pnlBody.Size      = new Size(940, 648);
        pnlBody.TabIndex  = 2;
        // 
        // cardGrid
        // 
        cardGrid.BackColor = Color.Transparent;
        cardGrid.Controls.Add(dgvOrders);
        cardGrid.Controls.Add(pnlToolbar);
        cardGrid.Dock     = DockStyle.Fill;
        cardGrid.Location = new Point(20, 142);
        cardGrid.Margin   = new Padding(0);
        cardGrid.Name     = "cardGrid";
        cardGrid.Padding  = new Padding(0);
        cardGrid.Size     = new Size(900, 486);
        cardGrid.TabIndex = 2;
        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows    = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor       = Color.White;
        dgvOrders.BorderStyle           = BorderStyle.None;
        dgvOrders.ColumnHeadersHeight   = 40;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvOrders.Dock                  = DockStyle.Fill;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.GridColor             = Color.FromArgb(234, 224, 207);
        dgvOrders.Location              = new Point(0, 56);
        dgvOrders.MultiSelect           = false;
        dgvOrders.Name                  = "dgvOrders";
        dgvOrders.ReadOnly              = true;
        dgvOrders.RowHeadersVisible     = false;
        dgvOrders.RowTemplate.Height    = 38;
        dgvOrders.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size                  = new Size(900, 430);
        dgvOrders.TabIndex              = 0;
        dgvOrders.CellDoubleClick      += dgvOrders_CellDoubleClick;
        // 
        // pnlToolbar
        // 
        pnlToolbar.BackColor = Color.White;
        pnlToolbar.Controls.Add(btnViewTicket);
        pnlToolbar.Controls.Add(txtSearch);
        pnlToolbar.Controls.Add(chkActiveOnly);
        pnlToolbar.Controls.Add(lblOrdersTitle);
        pnlToolbar.Dock     = DockStyle.Top;
        pnlToolbar.Location = new Point(0, 0);
        pnlToolbar.Name     = "pnlToolbar";
        pnlToolbar.Padding  = new Padding(16, 0, 16, 0);
        pnlToolbar.Size     = new Size(900, 56);
        pnlToolbar.TabIndex = 1;
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.Anchor    = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
        lblOrdersTitle.AutoSize  = false;
        lblOrdersTitle.Font      = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblOrdersTitle.ForeColor = Color.FromArgb(17, 24, 68);
        lblOrdersTitle.Location  = new Point(16, 12);
        lblOrdersTitle.Margin    = new Padding(0);
        lblOrdersTitle.Name      = "lblOrdersTitle";
        lblOrdersTitle.Size      = new Size(200, 32);
        lblOrdersTitle.TabIndex  = 0;
        lblOrdersTitle.Text      = "My Laundry Orders";
        lblOrdersTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // chkActiveOnly
        // 
        chkActiveOnly.Anchor    = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
        chkActiveOnly.AutoSize  = false;
        chkActiveOnly.Cursor    = Cursors.Hand;
        chkActiveOnly.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
        chkActiveOnly.ForeColor = Color.FromArgb(75, 86, 148);
        chkActiveOnly.Location  = new Point(228, 16);
        chkActiveOnly.Name      = "chkActiveOnly";
        chkActiveOnly.Size      = new Size(180, 24);
        chkActiveOnly.TabIndex  = 1;
        chkActiveOnly.Text      = "Active In-Process Only";
        chkActiveOnly.UseVisualStyleBackColor = true;
        chkActiveOnly.CheckedChanged += chkActiveOnly_CheckedChanged;
        // 
        // txtSearch
        // 
        txtSearch.Anchor       = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        txtSearch.BackColor    = Color.White;
        txtSearch.BaseColor    = Color.FromArgb(248, 249, 252);
        txtSearch.BorderColorA = Color.FromArgb(75, 86, 148);
        txtSearch.BorderColorB = Color.FromArgb(220, 224, 235);
        txtSearch.Font         = new Font("Segoe UI", 9.5F);
        txtSearch.ForeColor    = Color.FromArgb(17, 24, 68);
        txtSearch.Hint         = "Search order #, service, status...";
        txtSearch.Location     = new Point(444, 9);
        txtSearch.Margin       = new Padding(0);
        txtSearch.Name         = "txtSearch";
        txtSearch.Size         = new Size(222, 38);
        txtSearch.TabIndex     = 2;
        txtSearch.TabStop      = false;
        // 
        // tlpStats
        // 
        tlpStats.BackColor   = Color.Transparent;
        tlpStats.ColumnCount = 3;
        tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
        tlpStats.Controls.Add(cardActive, 0, 0);
        tlpStats.Controls.Add(cardReady, 1, 0);
        tlpStats.Controls.Add(cardTotal, 2, 0);
        tlpStats.Dock     = DockStyle.Top;
        tlpStats.Location = new Point(20, 16);
        tlpStats.Margin   = new Padding(0);
        tlpStats.Name     = "tlpStats";
        tlpStats.RowCount = 1;
        tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpStats.Size     = new Size(900, 110);
        tlpStats.TabIndex = 0;
        // 
        // cardActive
        // 
        cardActive.BackColor = Color.Transparent;
        cardActive.Controls.Add(lblActiveStat);
        cardActive.Controls.Add(lblActiveTitle);
        cardActive.Controls.Add(stripActive);
        cardActive.Dock     = DockStyle.Fill;
        cardActive.Location = new Point(0, 0);
        cardActive.Margin   = new Padding(0, 0, 10, 0);
        cardActive.Name     = "cardActive";
        cardActive.Padding  = new Padding(16, 10, 16, 10);
        cardActive.Size     = new Size(290, 110);
        cardActive.TabIndex = 0;
        // 
        // lblActiveStat
        // 
        lblActiveStat.BackColor  = Color.Transparent;
        lblActiveStat.Dock       = DockStyle.Fill;
        lblActiveStat.Font       = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblActiveStat.ForeColor  = Color.FromArgb(17, 24, 68);
        lblActiveStat.Location   = new Point(20, 32);
        lblActiveStat.Name       = "lblActiveStat";
        lblActiveStat.Padding    = new Padding(12, 0, 0, 4);
        lblActiveStat.Size       = new Size(254, 68);
        lblActiveStat.TabIndex   = 0;
        lblActiveStat.Text       = "0";
        lblActiveStat.TextAlign  = ContentAlignment.MiddleLeft;
        // 
        // lblActiveTitle
        // 
        lblActiveTitle.BackColor  = Color.Transparent;
        lblActiveTitle.Dock       = DockStyle.Top;
        lblActiveTitle.Font       = new Font("Segoe UI", 9F);
        lblActiveTitle.ForeColor  = Color.FromArgb(114, 136, 174);
        lblActiveTitle.Location   = new Point(20, 10);
        lblActiveTitle.Name       = "lblActiveTitle";
        lblActiveTitle.Padding    = new Padding(12, 0, 0, 0);
        lblActiveTitle.Size       = new Size(254, 22);
        lblActiveTitle.TabIndex   = 1;
        lblActiveTitle.Text       = "Active In-Process";
        lblActiveTitle.TextAlign  = ContentAlignment.MiddleLeft;
        // 
        // stripActive
        // 
        stripActive.BackColor = Color.FromArgb(75, 86, 148);
        stripActive.Dock      = DockStyle.Left;
        stripActive.Location  = new Point(16, 10);
        stripActive.Name      = "stripActive";
        stripActive.Size      = new Size(4, 90);
        stripActive.TabIndex  = 2;
        // 
        // cardReady
        // 
        cardReady.BackColor = Color.Transparent;
        cardReady.Controls.Add(lblReadyStat);
        cardReady.Controls.Add(lblReadyTitle);
        cardReady.Controls.Add(stripReady);
        cardReady.Dock     = DockStyle.Fill;
        cardReady.Location = new Point(300, 0);
        cardReady.Margin   = new Padding(0, 0, 10, 0);
        cardReady.Name     = "cardReady";
        cardReady.Padding  = new Padding(16, 10, 16, 10);
        cardReady.Size     = new Size(290, 110);
        cardReady.TabIndex = 1;
        // 
        // lblReadyStat
        // 
        lblReadyStat.BackColor  = Color.Transparent;
        lblReadyStat.Dock       = DockStyle.Fill;
        lblReadyStat.Font       = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblReadyStat.ForeColor  = Color.FromArgb(17, 24, 68);
        lblReadyStat.Location   = new Point(20, 32);
        lblReadyStat.Name       = "lblReadyStat";
        lblReadyStat.Padding    = new Padding(12, 0, 0, 4);
        lblReadyStat.Size       = new Size(254, 68);
        lblReadyStat.TabIndex   = 0;
        lblReadyStat.Text       = "0";
        lblReadyStat.TextAlign  = ContentAlignment.MiddleLeft;
        // 
        // lblReadyTitle
        // 
        lblReadyTitle.BackColor  = Color.Transparent;
        lblReadyTitle.Dock       = DockStyle.Top;
        lblReadyTitle.Font       = new Font("Segoe UI", 9F);
        lblReadyTitle.ForeColor  = Color.FromArgb(114, 136, 174);
        lblReadyTitle.Location   = new Point(20, 10);
        lblReadyTitle.Name       = "lblReadyTitle";
        lblReadyTitle.Padding    = new Padding(12, 0, 0, 0);
        lblReadyTitle.Size       = new Size(254, 22);
        lblReadyTitle.TabIndex   = 1;
        lblReadyTitle.Text       = "Ready for Pickup";
        lblReadyTitle.TextAlign  = ContentAlignment.MiddleLeft;
        // 
        // stripReady
        // 
        stripReady.BackColor = Color.FromArgb(22, 163, 74);
        stripReady.Dock      = DockStyle.Left;
        stripReady.Location  = new Point(16, 10);
        stripReady.Name      = "stripReady";
        stripReady.Size      = new Size(4, 90);
        stripReady.TabIndex  = 2;
        // 
        // cardTotal
        // 
        cardTotal.BackColor = Color.Transparent;
        cardTotal.Controls.Add(lblTotalStat);
        cardTotal.Controls.Add(lblTotalTitle);
        cardTotal.Controls.Add(stripTotal);
        cardTotal.Dock     = DockStyle.Fill;
        cardTotal.Location = new Point(600, 0);
        cardTotal.Margin   = new Padding(0);
        cardTotal.Name     = "cardTotal";
        cardTotal.Padding  = new Padding(16, 10, 16, 10);
        cardTotal.Size     = new Size(300, 110);
        cardTotal.TabIndex = 2;
        // 
        // lblTotalStat
        // 
        lblTotalStat.BackColor  = Color.Transparent;
        lblTotalStat.Dock       = DockStyle.Fill;
        lblTotalStat.Font       = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTotalStat.ForeColor  = Color.FromArgb(17, 24, 68);
        lblTotalStat.Location   = new Point(20, 32);
        lblTotalStat.Name       = "lblTotalStat";
        lblTotalStat.Padding    = new Padding(12, 0, 0, 4);
        lblTotalStat.Size       = new Size(264, 68);
        lblTotalStat.TabIndex   = 0;
        lblTotalStat.Text       = "0";
        lblTotalStat.TextAlign  = ContentAlignment.MiddleLeft;
        // 
        // lblTotalTitle
        // 
        lblTotalTitle.BackColor  = Color.Transparent;
        lblTotalTitle.Dock       = DockStyle.Top;
        lblTotalTitle.Font       = new Font("Segoe UI", 9F);
        lblTotalTitle.ForeColor  = Color.FromArgb(114, 136, 174);
        lblTotalTitle.Location   = new Point(20, 10);
        lblTotalTitle.Name       = "lblTotalTitle";
        lblTotalTitle.Padding    = new Padding(12, 0, 0, 0);
        lblTotalTitle.Size       = new Size(264, 22);
        lblTotalTitle.TabIndex   = 1;
        lblTotalTitle.Text       = "Total Laundry Bookings";
        lblTotalTitle.TextAlign  = ContentAlignment.MiddleLeft;
        // 
        // stripTotal
        // 
        stripTotal.BackColor = Color.FromArgb(114, 136, 174);
        stripTotal.Dock      = DockStyle.Left;
        stripTotal.Location  = new Point(16, 10);
        stripTotal.Name      = "stripTotal";
        stripTotal.Size      = new Size(4, 90);
        stripTotal.TabIndex  = 2;
        // 
        // btnViewTicket
        // 
        btnViewTicket.Anchor        = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        btnViewTicket.BorderColor   = Color.FromArgb(75, 86, 148);
        btnViewTicket.ButtonType    = HopeButtonType.Primary;
        btnViewTicket.Cursor        = Cursors.Hand;
        btnViewTicket.DangerColor   = Color.FromArgb(245, 108, 108);
        btnViewTicket.DefaultColor  = Color.White;
        btnViewTicket.Font          = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnViewTicket.HoverTextColor = Color.White;
        btnViewTicket.InfoColor     = Color.FromArgb(144, 147, 153);
        btnViewTicket.Location      = new Point(672, 9);
        btnViewTicket.Margin        = new Padding(0);
        btnViewTicket.Name          = "btnViewTicket";
        btnViewTicket.PrimaryColor  = Color.FromArgb(75, 86, 148);
        btnViewTicket.Size          = new Size(212, 38);
        btnViewTicket.SuccessColor  = Color.FromArgb(103, 194, 58);
        btnViewTicket.TabIndex      = 3;
        btnViewTicket.Text          = "  View E-Ticket / Receipt";
        btnViewTicket.TextColor     = Color.White;
        btnViewTicket.WarningColor  = Color.FromArgb(230, 162, 60);
        btnViewTicket.Click        += BtnViewTicket_Click;
        // 
        // FrmCustomerPortal
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode       = AutoScaleMode.Dpi;
        BackColor           = Color.FromArgb(245, 247, 250);
        ClientSize          = new Size(1180, 720);
        Controls.Add(pnlBody);
        Controls.Add(pnlHeader);
        Controls.Add(pnlSidebar);
        Font               = new Font("Segoe UI", 9.5F);
        ForeColor          = Color.FromArgb(17, 24, 68);
        MinimumSize        = new Size(980, 620);
        Name               = "FrmCustomerPortal";
        StartPosition      = FormStartPosition.CenterScreen;
        Text               = "LaundryHub  Customer Portal";
        pnlBody.ResumeLayout(false);
        cardGrid.ResumeLayout(false);
        pnlToolbar.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        tlpStats.ResumeLayout(false);
        cardActive.ResumeLayout(false);
        cardReady.ResumeLayout(false);
        cardTotal.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ModernSidebar    pnlSidebar;
    private ModernHeaderBar  pnlHeader;
    private Panel            pnlBody;
    private RoundedCard      cardGrid;
    private DataGridView     dgvOrders;
    private Panel            pnlToolbar;
    private Label            lblOrdersTitle;
    private CheckBox         chkActiveOnly;
    private HopeButton       btnViewTicket;
    private HopeTextBox      txtSearch;
    private TableLayoutPanel tlpStats;
    private RoundedCard      cardActive;
    private Panel            stripActive;
    private Label            lblActiveTitle;
    private Label            lblActiveStat;
    private RoundedCard      cardReady;
    private Panel            stripReady;
    private Label            lblReadyTitle;
    private Label            lblReadyStat;
    private RoundedCard      cardTotal;
    private Panel            stripTotal;
    private Label            lblTotalTitle;
    private Label            lblTotalStat;
}
