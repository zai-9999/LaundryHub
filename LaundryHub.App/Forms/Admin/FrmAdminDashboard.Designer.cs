using Panel = System.Windows.Forms.Panel;
using ReaLTaiizor.Controls;
using LaundryHub.App.Helpers;

namespace LaundryHub.App.Forms.Admin;

partial class FrmAdminDashboard
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
        pnlMain = new Panel();
        cardOrders = new RoundedCard();
        dgvTodayOrders = new DataGridView();
        pnlTableBar = new Panel();
        lblLiveBadge = new Label();
        lblTableSubtitle = new Label();
        lblTableTitle = new Label();
        flpStats = new FlowLayoutPanel();
        pnlStatOrders = new Panel();
        lblTotalToday = new Label();
        lblOrdersTitle = new Label();
        pnlStripOrders = new Panel();
        pnlStatRevenue = new Panel();
        lblSalesToday = new Label();
        lblRevenueTitle = new Label();
        pnlStripRevenue = new Panel();
        pnlStatPending = new Panel();
        lblPending = new Label();
        lblPendingTitle = new Label();
        pnlStripPending = new Panel();
        pnlStatClaimed = new Panel();
        lblClaimed = new Label();
        lblClaimedTitle = new Label();
        pnlStripClaimed = new Panel();
        pnlMain.SuspendLayout();
        cardOrders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTodayOrders).BeginInit();
        pnlTableBar.SuspendLayout();
        flpStats.SuspendLayout();
        pnlStatOrders.SuspendLayout();
        pnlStatRevenue.SuspendLayout();
        pnlStatPending.SuspendLayout();
        pnlStatClaimed.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(265, 740);
        pnlSidebar.TabIndex = 1;
        // 
        // pnlHeader
        // 
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(265, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(915, 72);
        pnlHeader.TabIndex = 0;
        // 
        // pnlMain
        // 
        pnlMain.BackColor = Color.FromArgb(245, 247, 250);
        pnlMain.Controls.Add(cardOrders);
        pnlMain.Controls.Add(flpStats);
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(265, 72);
        pnlMain.Name = "pnlMain";
        pnlMain.Padding = new Padding(20);
        pnlMain.Size = new Size(915, 668);
        pnlMain.TabIndex = 2;
        // 
        // cardOrders
        // 
        cardOrders.BackColor = Color.Transparent;
        cardOrders.BorderColor = Color.FromArgb(226, 230, 240);
        cardOrders.Controls.Add(dgvTodayOrders);
        cardOrders.Controls.Add(pnlTableBar);
        cardOrders.Dock = DockStyle.Fill;
        cardOrders.FillColor = Color.White;
        cardOrders.Location = new Point(20, 134);
        cardOrders.Name = "cardOrders";
        cardOrders.Padding = new Padding(16, 12, 16, 14);
        cardOrders.Radius = 14;
        cardOrders.Shadow = true;
        cardOrders.Size = new Size(900, 514);
        cardOrders.TabIndex = 1;
        // 
        // dgvTodayOrders
        // 
        dgvTodayOrders.AllowUserToAddRows = false;
        dgvTodayOrders.AllowUserToDeleteRows = false;
        dgvTodayOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTodayOrders.BackgroundColor = Color.White;
        dgvTodayOrders.BorderStyle = BorderStyle.None;
        dgvTodayOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTodayOrders.Dock = DockStyle.Fill;
        dgvTodayOrders.GridColor = Color.FromArgb(234, 224, 207);
        dgvTodayOrders.Location = new Point(16, 60);
        dgvTodayOrders.Name = "dgvTodayOrders";
        dgvTodayOrders.ReadOnly = true;
        dgvTodayOrders.RowHeadersVisible = false;
        dgvTodayOrders.RowHeadersWidth = 51;
        dgvTodayOrders.RowTemplate.Height = 38;
        dgvTodayOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTodayOrders.Size = new Size(868, 440);
        dgvTodayOrders.TabIndex = 0;
        dgvTodayOrders.CellDoubleClick += dgvTodayOrders_CellDoubleClick;
        // 
        // pnlTableBar
        // 
        pnlTableBar.BackColor = Color.White;
        pnlTableBar.Controls.Add(lblLiveBadge);
        pnlTableBar.Controls.Add(lblTableSubtitle);
        pnlTableBar.Controls.Add(lblTableTitle);
        pnlTableBar.Dock = DockStyle.Top;
        pnlTableBar.Location = new Point(16, 12);
        pnlTableBar.Name = "pnlTableBar";
        pnlTableBar.Size = new Size(868, 48);
        pnlTableBar.TabIndex = 1;
        // 
        // lblLiveBadge
        // 
        lblLiveBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblLiveBadge.BackColor = Color.FromArgb(228, 246, 235);
        lblLiveBadge.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblLiveBadge.ForeColor = Color.FromArgb(22, 163, 74);
        lblLiveBadge.Location = new Point(768, 8);
        lblLiveBadge.Name = "lblLiveBadge";
        lblLiveBadge.Size = new Size(100, 26);
        lblLiveBadge.TabIndex = 2;
        lblLiveBadge.Text = "● Live Activity";
        lblLiveBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTableSubtitle
        // 
        lblTableSubtitle.Dock = DockStyle.Top;
        lblTableSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblTableSubtitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblTableSubtitle.Location = new Point(0, 24);
        lblTableSubtitle.Name = "lblTableSubtitle";
        lblTableSubtitle.Size = new Size(868, 20);
        lblTableSubtitle.TabIndex = 1;
        lblTableSubtitle.Text = "Double-click any order row to open complete details & status management";
        lblTableSubtitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblTableTitle
        // 
        lblTableTitle.Dock = DockStyle.Top;
        lblTableTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTableTitle.ForeColor = Color.FromArgb(17, 24, 68);
        lblTableTitle.Location = new Point(0, 0);
        lblTableTitle.Name = "lblTableTitle";
        lblTableTitle.Size = new Size(868, 24);
        lblTableTitle.TabIndex = 0;
        lblTableTitle.Text = "Today's Laundry Orders";
        lblTableTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // flpStats
        // 
        flpStats.Controls.Add(pnlStatOrders);
        flpStats.Controls.Add(pnlStatRevenue);
        flpStats.Controls.Add(pnlStatPending);
        flpStats.Controls.Add(pnlStatClaimed);
        flpStats.Dock = DockStyle.Top;
        flpStats.Location = new Point(20, 20);
        flpStats.Name = "flpStats";
        flpStats.Size = new Size(900, 114);
        flpStats.TabIndex = 0;
        // 
        // pnlStatOrders
        // 
        pnlStatOrders.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatOrders.Controls.Add(lblTotalToday);
        pnlStatOrders.Controls.Add(lblOrdersTitle);
        pnlStatOrders.Controls.Add(pnlStripOrders);
        pnlStatOrders.Location = new Point(0, 0);
        pnlStatOrders.Margin = new Padding(0, 0, 14, 0);
        pnlStatOrders.Name = "pnlStatOrders";
        pnlStatOrders.Padding = new Padding(14, 10, 14, 10);
        pnlStatOrders.Size = new Size(205, 85);
        pnlStatOrders.TabIndex = 0;
        // 
        // lblTotalToday
        // 
        lblTotalToday.Dock = DockStyle.Fill;
        lblTotalToday.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTotalToday.ForeColor = Color.FromArgb(75, 86, 148);
        lblTotalToday.Location = new Point(18, 28);
        lblTotalToday.Name = "lblTotalToday";
        lblTotalToday.Size = new Size(173, 47);
        lblTotalToday.TabIndex = 2;
        lblTotalToday.Text = "0";
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.Dock = DockStyle.Top;
        lblOrdersTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblOrdersTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblOrdersTitle.Location = new Point(18, 10);
        lblOrdersTitle.Name = "lblOrdersTitle";
        lblOrdersTitle.Size = new Size(173, 18);
        lblOrdersTitle.TabIndex = 1;
        lblOrdersTitle.Text = "Today's Total Orders";
        // 
        // pnlStripOrders
        // 
        pnlStripOrders.BackColor = Color.FromArgb(75, 86, 148);
        pnlStripOrders.Dock = DockStyle.Left;
        pnlStripOrders.Location = new Point(14, 10);
        pnlStripOrders.Name = "pnlStripOrders";
        pnlStripOrders.Size = new Size(4, 65);
        pnlStripOrders.TabIndex = 0;
        // 
        // pnlStatRevenue
        // 
        pnlStatRevenue.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatRevenue.Controls.Add(lblSalesToday);
        pnlStatRevenue.Controls.Add(lblRevenueTitle);
        pnlStatRevenue.Controls.Add(pnlStripRevenue);
        pnlStatRevenue.Location = new Point(219, 0);
        pnlStatRevenue.Margin = new Padding(0, 0, 14, 0);
        pnlStatRevenue.Name = "pnlStatRevenue";
        pnlStatRevenue.Padding = new Padding(14, 10, 14, 10);
        pnlStatRevenue.Size = new Size(205, 85);
        pnlStatRevenue.TabIndex = 1;
        // 
        // lblSalesToday
        // 
        lblSalesToday.Dock = DockStyle.Fill;
        lblSalesToday.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblSalesToday.ForeColor = Color.FromArgb(75, 86, 148);
        lblSalesToday.Location = new Point(18, 28);
        lblSalesToday.Name = "lblSalesToday";
        lblSalesToday.Size = new Size(173, 47);
        lblSalesToday.TabIndex = 2;
        lblSalesToday.Text = "₱0.00";
        // 
        // lblRevenueTitle
        // 
        lblRevenueTitle.Dock = DockStyle.Top;
        lblRevenueTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblRevenueTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblRevenueTitle.Location = new Point(18, 10);
        lblRevenueTitle.Name = "lblRevenueTitle";
        lblRevenueTitle.Size = new Size(173, 18);
        lblRevenueTitle.TabIndex = 1;
        lblRevenueTitle.Text = "Today's Revenue";
        // 
        // pnlStripRevenue
        // 
        pnlStripRevenue.BackColor = Color.FromArgb(114, 136, 174);
        pnlStripRevenue.Dock = DockStyle.Left;
        pnlStripRevenue.Location = new Point(14, 10);
        pnlStripRevenue.Name = "pnlStripRevenue";
        pnlStripRevenue.Size = new Size(4, 65);
        pnlStripRevenue.TabIndex = 0;
        // 
        // pnlStatPending
        // 
        pnlStatPending.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatPending.Controls.Add(lblPending);
        pnlStatPending.Controls.Add(lblPendingTitle);
        pnlStatPending.Controls.Add(pnlStripPending);
        pnlStatPending.Location = new Point(438, 0);
        pnlStatPending.Margin = new Padding(0, 0, 14, 0);
        pnlStatPending.Name = "pnlStatPending";
        pnlStatPending.Padding = new Padding(14, 10, 14, 10);
        pnlStatPending.Size = new Size(205, 85);
        pnlStatPending.TabIndex = 2;
        // 
        // lblPending
        // 
        lblPending.Dock = DockStyle.Fill;
        lblPending.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblPending.ForeColor = Color.FromArgb(75, 86, 148);
        lblPending.Location = new Point(18, 28);
        lblPending.Name = "lblPending";
        lblPending.Size = new Size(173, 47);
        lblPending.TabIndex = 2;
        lblPending.Text = "0";
        // 
        // lblPendingTitle
        // 
        lblPendingTitle.Dock = DockStyle.Top;
        lblPendingTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblPendingTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblPendingTitle.Location = new Point(18, 10);
        lblPendingTitle.Name = "lblPendingTitle";
        lblPendingTitle.Size = new Size(173, 18);
        lblPendingTitle.TabIndex = 1;
        lblPendingTitle.Text = "Pending in Progress";
        // 
        // pnlStripPending
        // 
        pnlStripPending.BackColor = Color.FromArgb(234, 224, 207);
        pnlStripPending.Dock = DockStyle.Left;
        pnlStripPending.Location = new Point(14, 10);
        pnlStripPending.Name = "pnlStripPending";
        pnlStripPending.Size = new Size(4, 65);
        pnlStripPending.TabIndex = 0;
        // 
        // pnlStatClaimed
        // 
        pnlStatClaimed.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatClaimed.Controls.Add(lblClaimed);
        pnlStatClaimed.Controls.Add(lblClaimedTitle);
        pnlStatClaimed.Controls.Add(pnlStripClaimed);
        pnlStatClaimed.Location = new Point(657, 0);
        pnlStatClaimed.Margin = new Padding(0, 0, 14, 0);
        pnlStatClaimed.Name = "pnlStatClaimed";
        pnlStatClaimed.Padding = new Padding(14, 10, 14, 10);
        pnlStatClaimed.Size = new Size(205, 85);
        pnlStatClaimed.TabIndex = 3;
        // 
        // lblClaimed
        // 
        lblClaimed.Dock = DockStyle.Fill;
        lblClaimed.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblClaimed.ForeColor = Color.FromArgb(75, 86, 148);
        lblClaimed.Location = new Point(18, 28);
        lblClaimed.Name = "lblClaimed";
        lblClaimed.Size = new Size(173, 47);
        lblClaimed.TabIndex = 2;
        lblClaimed.Text = "0";
        // 
        // lblClaimedTitle
        // 
        lblClaimedTitle.Dock = DockStyle.Top;
        lblClaimedTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblClaimedTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblClaimedTitle.Location = new Point(18, 10);
        lblClaimedTitle.Name = "lblClaimedTitle";
        lblClaimedTitle.Size = new Size(173, 18);
        lblClaimedTitle.TabIndex = 1;
        lblClaimedTitle.Text = "Claimed Today";
        // 
        // pnlStripClaimed
        // 
        pnlStripClaimed.BackColor = Color.FromArgb(114, 136, 174);
        pnlStripClaimed.Dock = DockStyle.Left;
        pnlStripClaimed.Location = new Point(14, 10);
        pnlStripClaimed.Name = "pnlStripClaimed";
        pnlStripClaimed.Size = new Size(4, 65);
        pnlStripClaimed.TabIndex = 0;
        // 
        // FrmAdminDashboard
        // 
        AutoScaleDimensions = new SizeF(9F, 21F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1180, 740);
        Controls.Add(pnlMain);
        Controls.Add(pnlHeader);
        Controls.Add(pnlSidebar);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.FromArgb(17, 24, 68);
        Name = "FrmAdminDashboard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Owner & Administrator Dashboard";
        pnlMain.ResumeLayout(false);
        cardOrders.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvTodayOrders).EndInit();
        pnlTableBar.ResumeLayout(false);
        flpStats.ResumeLayout(false);
        pnlStatOrders.ResumeLayout(false);
        pnlStatRevenue.ResumeLayout(false);
        pnlStatPending.ResumeLayout(false);
        pnlStatClaimed.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ModernSidebar pnlSidebar;
    private ModernHeaderBar pnlHeader;
    private Panel pnlMain;
    private RoundedCard cardOrders;
    private Panel pnlTableBar;
    private Label lblTableTitle;
    private Label lblTableSubtitle;
    private Label lblLiveBadge;
    private DataGridView dgvTodayOrders;
    private FlowLayoutPanel flpStats;
    private Panel pnlStatOrders;
    private Panel pnlStripOrders;
    private Label lblOrdersTitle;
    private Label lblTotalToday;
    private Panel pnlStatRevenue;
    private Panel pnlStripRevenue;
    private Label lblRevenueTitle;
    private Label lblSalesToday;
    private Panel pnlStatPending;
    private Panel pnlStripPending;
    private Label lblPendingTitle;
    private Label lblPending;
    private Panel pnlStatClaimed;
    private Panel pnlStripClaimed;
    private Label lblClaimedTitle;
    private Label lblClaimed;
}
