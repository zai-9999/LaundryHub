using Panel = System.Windows.Forms.Panel;
using ReaLTaiizor.Controls;
using LaundryHub.App.Helpers;

namespace LaundryHub.App.Forms.Staff;

partial class FrmStaffDashboard
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
        pnlContent = new Panel();
        cardOrders = new RoundedCard();
        dgvOrders = new DataGridView();
        pnlTableBar = new Panel();
        lblLiveBadge = new Label();
        lblTableSubtitle = new Label();
        lblTableTitle = new Label();
        flpCards = new FlowLayoutPanel();
        pnlStatPending = new Panel();
        lblPending = new Label();
        lblPendingTitle = new Label();
        pnlStatTotal = new Panel();
        lblTotal = new Label();
        lblTotalTitle = new Label();
        pnlStatClaimed = new Panel();
        lblClaimed = new Label();
        lblClaimedTitle = new Label();
        pnlStatSales = new Panel();
        lblSales = new Label();
        lblSalesTitle = new Label();
        pnlContent.SuspendLayout();
        cardOrders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        pnlTableBar.SuspendLayout();
        flpCards.SuspendLayout();
        pnlStatPending.SuspendLayout();
        pnlStatTotal.SuspendLayout();
        pnlStatClaimed.SuspendLayout();
        pnlStatSales.SuspendLayout();
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
        // pnlContent
        // 
        pnlContent.BackColor = Color.FromArgb(245, 247, 250);
        pnlContent.Controls.Add(cardOrders);
        pnlContent.Controls.Add(flpCards);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(240, 72);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(20);
        pnlContent.Size = new Size(940, 648);
        pnlContent.TabIndex = 2;
        // 
        // cardOrders
        // 
        cardOrders.BackColor = Color.Transparent;
        cardOrders.BorderColor = Color.FromArgb(226, 230, 240);
        cardOrders.Controls.Add(dgvOrders);
        cardOrders.Controls.Add(pnlTableBar);
        cardOrders.Dock = DockStyle.Fill;
        cardOrders.FillColor = Color.White;
        cardOrders.Location = new Point(20, 134);
        cardOrders.Name = "cardOrders";
        cardOrders.Padding = new Padding(16, 12, 16, 14);
        cardOrders.Radius = 14;
        cardOrders.Shadow = true;
        cardOrders.Size = new Size(900, 494);
        cardOrders.TabIndex = 2;
        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor = Color.White;
        dgvOrders.BorderStyle = BorderStyle.None;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.GridColor = Color.FromArgb(234, 224, 207);
        dgvOrders.Location = new Point(16, 60);
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.RowHeadersWidth = 51;
        dgvOrders.RowTemplate.Height = 38;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(868, 420);
        dgvOrders.TabIndex = 0;
        dgvOrders.CellFormatting += DgvOrders_CellFormatting;
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
        lblLiveBadge.Text = "● Active Queue";
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
        lblTableSubtitle.Text = "Track customer orders through washing, drying, and pickup stages";
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
        lblTableTitle.Text = "Recent Orders Queue";
        lblTableTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // flpCards
        // 
        flpCards.Controls.Add(pnlStatPending);
        flpCards.Controls.Add(pnlStatTotal);
        flpCards.Controls.Add(pnlStatClaimed);
        flpCards.Controls.Add(pnlStatSales);
        flpCards.Dock = DockStyle.Top;
        flpCards.Location = new Point(20, 20);
        flpCards.Name = "flpCards";
        flpCards.Size = new Size(900, 114);
        flpCards.TabIndex = 1;
        // 
        // pnlStatPending
        // 
        pnlStatPending.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatPending.Controls.Add(lblPending);
        pnlStatPending.Controls.Add(lblPendingTitle);
        pnlStatPending.Location = new Point(0, 0);
        pnlStatPending.Margin = new Padding(0, 0, 12, 0);
        pnlStatPending.Name = "pnlStatPending";
        pnlStatPending.Size = new Size(185, 90);
        pnlStatPending.TabIndex = 0;
        // 
        // lblPending
        // 
        lblPending.AutoSize = true;
        lblPending.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblPending.ForeColor = Color.FromArgb(75, 86, 148);
        lblPending.Location = new Point(12, 30);
        lblPending.Name = "lblPending";
        lblPending.Size = new Size(33, 37);
        lblPending.TabIndex = 1;
        lblPending.Text = "0";
        // 
        // lblPendingTitle
        // 
        lblPendingTitle.AutoSize = true;
        lblPendingTitle.Font = new Font("Segoe UI", 8.5F);
        lblPendingTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblPendingTitle.Location = new Point(12, 10);
        lblPendingTitle.Name = "lblPendingTitle";
        lblPendingTitle.Size = new Size(51, 15);
        lblPendingTitle.TabIndex = 0;
        lblPendingTitle.Text = "Pending";
        // 
        // pnlStatTotal
        // 
        pnlStatTotal.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatTotal.Controls.Add(lblTotal);
        pnlStatTotal.Controls.Add(lblTotalTitle);
        pnlStatTotal.Location = new Point(197, 0);
        pnlStatTotal.Margin = new Padding(0, 0, 12, 0);
        pnlStatTotal.Name = "pnlStatTotal";
        pnlStatTotal.Size = new Size(185, 90);
        pnlStatTotal.TabIndex = 1;
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(75, 86, 148);
        lblTotal.Location = new Point(12, 30);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(33, 37);
        lblTotal.TabIndex = 1;
        lblTotal.Text = "0";
        // 
        // lblTotalTitle
        // 
        lblTotalTitle.AutoSize = true;
        lblTotalTitle.Font = new Font("Segoe UI", 8.5F);
        lblTotalTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblTotalTitle.Location = new Point(12, 10);
        lblTotalTitle.Name = "lblTotalTitle";
        lblTotalTitle.Size = new Size(67, 15);
        lblTotalTitle.TabIndex = 0;
        lblTotalTitle.Text = "Total Today";
        // 
        // pnlStatClaimed
        // 
        pnlStatClaimed.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatClaimed.Controls.Add(lblClaimed);
        pnlStatClaimed.Controls.Add(lblClaimedTitle);
        pnlStatClaimed.Location = new Point(394, 0);
        pnlStatClaimed.Margin = new Padding(0, 0, 12, 0);
        pnlStatClaimed.Name = "pnlStatClaimed";
        pnlStatClaimed.Size = new Size(185, 90);
        pnlStatClaimed.TabIndex = 2;
        // 
        // lblClaimed
        // 
        lblClaimed.AutoSize = true;
        lblClaimed.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblClaimed.ForeColor = Color.FromArgb(75, 86, 148);
        lblClaimed.Location = new Point(12, 30);
        lblClaimed.Name = "lblClaimed";
        lblClaimed.Size = new Size(33, 37);
        lblClaimed.TabIndex = 1;
        lblClaimed.Text = "0";
        // 
        // lblClaimedTitle
        // 
        lblClaimedTitle.AutoSize = true;
        lblClaimedTitle.Font = new Font("Segoe UI", 8.5F);
        lblClaimedTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblClaimedTitle.Location = new Point(12, 10);
        lblClaimedTitle.Name = "lblClaimedTitle";
        lblClaimedTitle.Size = new Size(51, 15);
        lblClaimedTitle.TabIndex = 0;
        lblClaimedTitle.Text = "Claimed";
        // 
        // pnlStatSales
        // 
        pnlStatSales.BackColor = Color.FromArgb(248, 245, 239);
        pnlStatSales.Controls.Add(lblSales);
        pnlStatSales.Controls.Add(lblSalesTitle);
        pnlStatSales.Location = new Point(591, 0);
        pnlStatSales.Margin = new Padding(0, 0, 12, 0);
        pnlStatSales.Name = "pnlStatSales";
        pnlStatSales.Size = new Size(185, 90);
        pnlStatSales.TabIndex = 3;
        // 
        // lblSales
        // 
        lblSales.AutoSize = true;
        lblSales.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblSales.ForeColor = Color.FromArgb(75, 86, 148);
        lblSales.Location = new Point(12, 34);
        lblSales.Name = "lblSales";
        lblSales.Size = new Size(65, 30);
        lblSales.TabIndex = 1;
        lblSales.Text = "₱0.00";
        // 
        // lblSalesTitle
        // 
        lblSalesTitle.AutoSize = true;
        lblSalesTitle.Font = new Font("Segoe UI", 8.5F);
        lblSalesTitle.ForeColor = Color.FromArgb(114, 136, 174);
        lblSalesTitle.Location = new Point(12, 10);
        lblSalesTitle.Name = "lblSalesTitle";
        lblSalesTitle.Size = new Size(74, 15);
        lblSalesTitle.TabIndex = 0;
        lblSalesTitle.Text = "Today's Sales";
        // 
        // FrmStaffDashboard
        // 
        AutoScaleDimensions = new SizeF(9F, 21F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1180, 720);
        Controls.Add(pnlContent);
        Controls.Add(pnlHeader);
        Controls.Add(pnlSidebar);
        Font = new Font("Segoe UI", 9.5F);
        MinimumSize = new Size(980, 600);
        Name = "FrmStaffDashboard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Staff Dashboard";
        pnlContent.ResumeLayout(false);
        cardOrders.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        pnlTableBar.ResumeLayout(false);
        flpCards.ResumeLayout(false);
        pnlStatPending.ResumeLayout(false);
        pnlStatPending.PerformLayout();
        pnlStatTotal.ResumeLayout(false);
        pnlStatTotal.PerformLayout();
        pnlStatClaimed.ResumeLayout(false);
        pnlStatClaimed.PerformLayout();
        pnlStatSales.ResumeLayout(false);
        pnlStatSales.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ModernSidebar pnlSidebar;
    private ModernHeaderBar pnlHeader;
    private Panel pnlContent;
    private RoundedCard cardOrders;
    private Panel pnlTableBar;
    private Label lblTableTitle;
    private Label lblTableSubtitle;
    private Label lblLiveBadge;
    private DataGridView dgvOrders;
    private FlowLayoutPanel flpCards;
    private Panel pnlStatPending;
    private Label lblPendingTitle;
    private Label lblPending;
    private Panel pnlStatTotal;
    private Label lblTotalTitle;
    private Label lblTotal;
    private Panel pnlStatClaimed;
    private Label lblClaimedTitle;
    private Label lblClaimed;
    private Panel pnlStatSales;
    private Label lblSalesTitle;
    private Label lblSales;
}
