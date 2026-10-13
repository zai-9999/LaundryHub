using Panel = System.Windows.Forms.Panel;
using CheckBox = System.Windows.Forms.CheckBox;
using Button = System.Windows.Forms.Button;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlSidebar = new Panel();
        btnLogout = new HopeButton();
        btnRefresh = new Button();
        btnCustomers = new Button();
        btnOrders = new Button();
        btnNewOrder = new HopeButton();
        lblUser = new Label();
        lblAppName = new Label();
        pnlContent = new Panel();
        dgvOrders = new DataGridView();
        lblRecent = new Label();
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
        lblDashboard = new Label();
        pnlSidebar.SuspendLayout();
        pnlContent.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        flpCards.SuspendLayout();
        pnlStatPending.SuspendLayout();
        pnlStatTotal.SuspendLayout();
        pnlStatClaimed.SuspendLayout();
        pnlStatSales.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(51, 104, 160);
        pnlSidebar.Controls.Add(btnLogout);
        pnlSidebar.Controls.Add(btnRefresh);
        pnlSidebar.Controls.Add(btnCustomers);
        pnlSidebar.Controls.Add(btnOrders);
        pnlSidebar.Controls.Add(btnNewOrder);
        pnlSidebar.Controls.Add(lblUser);
        pnlSidebar.Controls.Add(lblAppName);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(220, 680);
        pnlSidebar.TabIndex = 0;
        // 
        // btnLogout
        // 
        btnLogout.ButtonType = HopeButtonType.Default;
        btnLogout.DefaultColor = Color.FromArgb(200, 223, 219);
        btnLogout.BorderColor = Color.FromArgb(102, 163, 191);
        btnLogout.TextColor = Color.FromArgb(51, 104, 160);
        btnLogout.HoverTextColor = Color.FromArgb(51, 104, 160);
        btnLogout.Cursor = Cursors.Hand;
        btnLogout.Dock = DockStyle.Top;
        btnLogout.Font = new Font("Segoe UI", 9.5F);
        btnLogout.Location = new Point(0, 290);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(220, 44);
        btnLogout.TabIndex = 6;
        btnLogout.Text = "Logout";
        btnLogout.Click += btnLogout_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.BackColor = Color.FromArgb(37, 78, 122);
        btnRefresh.Cursor = Cursors.Hand;
        btnRefresh.Dock = DockStyle.Top;
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 104, 160);
        btnRefresh.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 55, 90);
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Segoe UI", 9.5F);
        btnRefresh.ForeColor = Color.FromArgb(242, 239, 231);
        btnRefresh.Location = new Point(0, 246);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Padding = new Padding(16, 0, 0, 0);
        btnRefresh.Size = new Size(220, 44);
        btnRefresh.TabIndex = 5;
        btnRefresh.Text = "🔄  Refresh";
        btnRefresh.TextAlign = ContentAlignment.MiddleLeft;
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // btnCustomers
        // 
        btnCustomers.BackColor = Color.FromArgb(37, 78, 122);
        btnCustomers.Cursor = Cursors.Hand;
        btnCustomers.Dock = DockStyle.Top;
        btnCustomers.FlatAppearance.BorderSize = 0;
        btnCustomers.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 104, 160);
        btnCustomers.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 55, 90);
        btnCustomers.FlatStyle = FlatStyle.Flat;
        btnCustomers.Font = new Font("Segoe UI", 9.5F);
        btnCustomers.ForeColor = Color.FromArgb(242, 239, 231);
        btnCustomers.Location = new Point(0, 202);
        btnCustomers.Name = "btnCustomers";
        btnCustomers.Padding = new Padding(16, 0, 0, 0);
        btnCustomers.Size = new Size(220, 44);
        btnCustomers.TabIndex = 4;
        btnCustomers.Text = "👤  Customers";
        btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
        btnCustomers.UseVisualStyleBackColor = false;
        btnCustomers.Click += btnCustomers_Click;
        // 
        // btnOrders
        // 
        btnOrders.BackColor = Color.FromArgb(37, 78, 122);
        btnOrders.Cursor = Cursors.Hand;
        btnOrders.Dock = DockStyle.Top;
        btnOrders.FlatAppearance.BorderSize = 0;
        btnOrders.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 104, 160);
        btnOrders.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 55, 90);
        btnOrders.FlatStyle = FlatStyle.Flat;
        btnOrders.Font = new Font("Segoe UI", 9.5F);
        btnOrders.ForeColor = Color.FromArgb(242, 239, 231);
        btnOrders.Location = new Point(0, 158);
        btnOrders.Name = "btnOrders";
        btnOrders.Padding = new Padding(16, 0, 0, 0);
        btnOrders.Size = new Size(220, 44);
        btnOrders.TabIndex = 3;
        btnOrders.Text = "📋  View Orders";
        btnOrders.TextAlign = ContentAlignment.MiddleLeft;
        btnOrders.UseVisualStyleBackColor = false;
        btnOrders.Click += btnOrders_Click;
        // 
        // btnNewOrder
        // 
        btnNewOrder.ButtonType = HopeButtonType.Primary;
        btnNewOrder.PrimaryColor = Color.FromArgb(102, 163, 191);
        btnNewOrder.TextColor = Color.White;
        btnNewOrder.HoverTextColor = Color.White;
        btnNewOrder.Cursor = Cursors.Hand;
        btnNewOrder.Dock = DockStyle.Top;
        btnNewOrder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnNewOrder.Location = new Point(0, 110);
        btnNewOrder.Name = "btnNewOrder";
        btnNewOrder.Size = new Size(220, 48);
        btnNewOrder.TabIndex = 2;
        btnNewOrder.Text = "New Order";
        btnNewOrder.Click += btnNewOrder_Click;
        // 
        // lblUser
        // 
        lblUser.Dock = DockStyle.Top;
        lblUser.Font = new Font("Segoe UI", 8.5F);
        lblUser.ForeColor = Color.FromArgb(200, 223, 219);
        lblUser.Location = new Point(0, 60);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(220, 50);
        lblUser.TabIndex = 1;
        lblUser.Text = "Staff User";
        lblUser.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblAppName
        // 
        lblAppName.Dock = DockStyle.Top;
        lblAppName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblAppName.ForeColor = Color.FromArgb(242, 239, 231);
        lblAppName.Location = new Point(0, 0);
        lblAppName.Name = "lblAppName";
        lblAppName.Padding = new Padding(12, 16, 0, 0);
        lblAppName.Size = new Size(220, 60);
        lblAppName.TabIndex = 0;
        lblAppName.Text = "LaundryHub";
        lblAppName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlContent
        // 
        pnlContent.BackColor = Color.White;
        pnlContent.Controls.Add(dgvOrders);
        pnlContent.Controls.Add(lblRecent);
        pnlContent.Controls.Add(flpCards);
        pnlContent.Controls.Add(lblDashboard);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(220, 0);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(20);
        pnlContent.Size = new Size(880, 680);
        pnlContent.TabIndex = 1;
        pnlContent.Paint += pnlContent_Paint;
        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor = Color.White;
        dgvOrders.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(200, 223, 219);
        dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(200, 223, 219);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvOrders.ColumnHeadersHeight = 34;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 104, 160);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(102, 163, 191);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.GridColor = Color.FromArgb(200, 223, 219);
        dgvOrders.Location = new Point(20, 200);
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(840, 460);
        dgvOrders.TabIndex = 3;
        dgvOrders.CellFormatting += DgvOrders_CellFormatting;
        // 
        // lblRecent
        // 
        lblRecent.Dock = DockStyle.Top;
        lblRecent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblRecent.ForeColor = Color.FromArgb(51, 104, 160);
        lblRecent.Location = new Point(20, 170);
        lblRecent.Name = "lblRecent";
        lblRecent.Size = new Size(840, 30);
        lblRecent.TabIndex = 2;
        lblRecent.Text = "Recent Orders";
        lblRecent.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // flpCards
        // 
        flpCards.Controls.Add(pnlStatPending);
        flpCards.Controls.Add(pnlStatTotal);
        flpCards.Controls.Add(pnlStatClaimed);
        flpCards.Controls.Add(pnlStatSales);
        flpCards.Dock = DockStyle.Top;
        flpCards.Location = new Point(20, 60);
        flpCards.Name = "flpCards";
        flpCards.Padding = new Padding(0, 8, 0, 8);
        flpCards.Size = new Size(840, 110);
        flpCards.TabIndex = 1;
        // 
        // pnlStatPending
        // 
        pnlStatPending.BackColor = Color.FromArgb(245, 248, 252);
        pnlStatPending.Controls.Add(lblPending);
        pnlStatPending.Controls.Add(lblPendingTitle);
        pnlStatPending.Location = new Point(0, 8);
        pnlStatPending.Margin = new Padding(0, 0, 12, 0);
        pnlStatPending.Name = "pnlStatPending";
        pnlStatPending.Size = new Size(185, 90);
        pnlStatPending.TabIndex = 0;
        pnlStatPending.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 185, 90, 10));
        // 
        // lblPending
        // 
        lblPending.AutoSize = true;
        lblPending.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblPending.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblPendingTitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblPendingTitle.Location = new Point(12, 10);
        lblPendingTitle.Name = "lblPendingTitle";
        lblPendingTitle.Size = new Size(51, 15);
        lblPendingTitle.TabIndex = 0;
        lblPendingTitle.Text = "Pending";
        // 
        // pnlStatTotal
        // 
        pnlStatTotal.BackColor = Color.FromArgb(245, 248, 252);
        pnlStatTotal.Controls.Add(lblTotal);
        pnlStatTotal.Controls.Add(lblTotalTitle);
        pnlStatTotal.Location = new Point(197, 8);
        pnlStatTotal.Margin = new Padding(0, 0, 12, 0);
        pnlStatTotal.Name = "pnlStatTotal";
        pnlStatTotal.Size = new Size(185, 90);
        pnlStatTotal.TabIndex = 1;
        pnlStatTotal.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 185, 90, 10));
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblTotalTitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblTotalTitle.Location = new Point(12, 10);
        lblTotalTitle.Name = "lblTotalTitle";
        lblTotalTitle.Size = new Size(67, 15);
        lblTotalTitle.TabIndex = 0;
        lblTotalTitle.Text = "Total Today";
        // 
        // pnlStatClaimed
        // 
        pnlStatClaimed.BackColor = Color.FromArgb(245, 248, 252);
        pnlStatClaimed.Controls.Add(lblClaimed);
        pnlStatClaimed.Controls.Add(lblClaimedTitle);
        pnlStatClaimed.Location = new Point(394, 8);
        pnlStatClaimed.Margin = new Padding(0, 0, 12, 0);
        pnlStatClaimed.Name = "pnlStatClaimed";
        pnlStatClaimed.Size = new Size(185, 90);
        pnlStatClaimed.TabIndex = 2;
        pnlStatClaimed.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 185, 90, 10));
        // 
        // lblClaimed
        // 
        lblClaimed.AutoSize = true;
        lblClaimed.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblClaimed.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblClaimedTitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblClaimedTitle.Location = new Point(12, 10);
        lblClaimedTitle.Name = "lblClaimedTitle";
        lblClaimedTitle.Size = new Size(51, 15);
        lblClaimedTitle.TabIndex = 0;
        lblClaimedTitle.Text = "Claimed";
        // 
        // pnlStatSales
        // 
        pnlStatSales.BackColor = Color.FromArgb(245, 248, 252);
        pnlStatSales.Controls.Add(lblSales);
        pnlStatSales.Controls.Add(lblSalesTitle);
        pnlStatSales.Location = new Point(591, 8);
        pnlStatSales.Margin = new Padding(0, 0, 12, 0);
        pnlStatSales.Name = "pnlStatSales";
        pnlStatSales.Size = new Size(185, 90);
        pnlStatSales.TabIndex = 3;
        pnlStatSales.Region = new Region(RoundRectangle.CreateRoundRect(0, 0, 185, 90, 10));
        // 
        // lblSales
        // 
        lblSales.AutoSize = true;
        lblSales.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblSales.ForeColor = Color.FromArgb(51, 104, 160);
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
        lblSalesTitle.ForeColor = Color.FromArgb(102, 163, 191);
        lblSalesTitle.Location = new Point(12, 10);
        lblSalesTitle.Name = "lblSalesTitle";
        lblSalesTitle.Size = new Size(74, 15);
        lblSalesTitle.TabIndex = 0;
        lblSalesTitle.Text = "Today's Sales";
        // 
        // lblDashboard
        // 
        lblDashboard.Dock = DockStyle.Top;
        lblDashboard.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblDashboard.ForeColor = Color.FromArgb(51, 104, 160);
        lblDashboard.Location = new Point(20, 20);
        lblDashboard.Name = "lblDashboard";
        lblDashboard.Size = new Size(840, 40);
        lblDashboard.TabIndex = 0;
        lblDashboard.Text = "Dashboard";
        // 
        // FrmStaffDashboard
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(102, 163, 191);
        ClientSize = new Size(1100, 680);
        Controls.Add(pnlContent);
        Controls.Add(pnlSidebar);
        Font = new Font("Segoe UI", 9.5F);
        MinimumSize = new Size(900, 580);
        Name = "FrmStaffDashboard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Staff Dashboard";
        pnlSidebar.ResumeLayout(false);
        pnlContent.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
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

    private Panel pnlSidebar;
    private Label lblAppName;
    private Label lblUser;
    private HopeButton btnNewOrder;
    private Button btnOrders;
    private Button btnCustomers;
    private Button btnRefresh;
    private HopeButton btnLogout;
    private Panel pnlContent;
    private Label lblDashboard;
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
    private Label lblRecent;
    private DataGridView dgvOrders;
}
