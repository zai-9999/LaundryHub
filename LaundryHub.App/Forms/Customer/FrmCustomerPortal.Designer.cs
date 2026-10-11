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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlHeader = new Panel();
        lblWelcome = new Label();
        btnProfile = new Button();
        btnLogout = new Button();
        pnlBody = new Panel();
        pnlGridWrap = new Panel();
        dgvOrders = new DataGridView();
        pnlFilterBar = new Panel();
        lblOrdersTitle = new Label();
        chkActiveOnly = new CheckBox();
        btnViewTicket = new Button();
        flpStats = new FlowLayoutPanel();
        pnlStatActive = new Panel();
        lblActiveStat = new Label();
        lblActiveTitle = new Label();
        pnlStripActive = new Panel();
        pnlStatReady = new Panel();
        lblReadyStat = new Label();
        lblReadyTitle = new Label();
        pnlStripReady = new Panel();
        pnlStatTotal = new Panel();
        lblTotalStat = new Label();
        lblTotalTitle = new Label();
        pnlStripTotal = new Panel();
        pnlHeader.SuspendLayout();
        pnlBody.SuspendLayout();
        pnlGridWrap.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        pnlFilterBar.SuspendLayout();
        flpStats.SuspendLayout();
        pnlStatActive.SuspendLayout();
        pnlStatReady.SuspendLayout();
        pnlStatTotal.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
        pnlHeader.Controls.Add(lblWelcome);
        pnlHeader.Controls.Add(btnProfile);
        pnlHeader.Controls.Add(btnLogout);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 0, 24, 0);
        pnlHeader.Size = new Size(1000, 70);
        pnlHeader.TabIndex = 0;
        // 
        // lblWelcome
        // 
        lblWelcome.Dock = DockStyle.Left;
        lblWelcome.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblWelcome.ForeColor = Color.FromArgb(96, 165, 250);
        lblWelcome.Location = new Point(24, 0);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(550, 70);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "🧺 Welcome, Customer!";
        lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnProfile
        // 
        btnProfile.BackColor = Color.FromArgb(51, 65, 85);
        btnProfile.Cursor = Cursors.Hand;
        btnProfile.FlatAppearance.BorderSize = 0;
        btnProfile.FlatStyle = FlatStyle.Flat;
        btnProfile.ForeColor = Color.White;
        btnProfile.Location = new Point(771, 18);
        btnProfile.Name = "btnProfile";
        btnProfile.Size = new Size(110, 34);
        btnProfile.TabIndex = 1;
        btnProfile.Text = "👤 My Profile";
        btnProfile.UseVisualStyleBackColor = false;
        btnProfile.Click += btnProfile_Click;
        // 
        // btnLogout
        // 
        btnLogout.BackColor = Color.FromArgb(153, 27, 27);
        btnLogout.Cursor = Cursors.Hand;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.ForeColor = Color.White;
        btnLogout.Location = new Point(887, 18);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(95, 34);
        btnLogout.TabIndex = 2;
        btnLogout.Text = "🚪 Logout";
        btnLogout.UseVisualStyleBackColor = false;
        btnLogout.Click += btnLogout_Click;
        // 
        // pnlBody
        // 
        pnlBody.Controls.Add(pnlGridWrap);
        pnlBody.Controls.Add(pnlFilterBar);
        pnlBody.Controls.Add(flpStats);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(0, 70);
        pnlBody.Name = "pnlBody";
        pnlBody.Padding = new Padding(24);
        pnlBody.Size = new Size(1000, 610);
        pnlBody.TabIndex = 1;
        // 
        // pnlGridWrap
        // 
        pnlGridWrap.Controls.Add(dgvOrders);
        pnlGridWrap.Dock = DockStyle.Fill;
        pnlGridWrap.Location = new Point(24, 169);
        pnlGridWrap.Name = "pnlGridWrap";
        pnlGridWrap.Padding = new Padding(0, 10, 0, 0);
        pnlGridWrap.Size = new Size(952, 417);
        pnlGridWrap.TabIndex = 2;
        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.BackgroundColor = Color.FromArgb(30, 41, 59);
        dgvOrders.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(148, 163, 184);
        dataGridViewCellStyle1.Padding = new Padding(6);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(37, 99, 235);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
        dgvOrders.Dock = DockStyle.Fill;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.GridColor = Color.FromArgb(51, 65, 85);
        dgvOrders.Location = new Point(0, 10);
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.RowTemplate.Height = 38;
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOrders.Size = new Size(952, 407);
        dgvOrders.TabIndex = 0;
        dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
        // 
        // pnlFilterBar
        // 
        pnlFilterBar.Controls.Add(lblOrdersTitle);
        pnlFilterBar.Controls.Add(chkActiveOnly);
        pnlFilterBar.Controls.Add(btnViewTicket);
        pnlFilterBar.Dock = DockStyle.Top;
        pnlFilterBar.Location = new Point(24, 124);
        pnlFilterBar.Name = "pnlFilterBar";
        pnlFilterBar.Padding = new Padding(0, 8, 0, 0);
        pnlFilterBar.Size = new Size(952, 45);
        pnlFilterBar.TabIndex = 1;
        // 
        // lblOrdersTitle
        // 
        lblOrdersTitle.Dock = DockStyle.Left;
        lblOrdersTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblOrdersTitle.ForeColor = Color.White;
        lblOrdersTitle.Location = new Point(0, 8);
        lblOrdersTitle.Name = "lblOrdersTitle";
        lblOrdersTitle.Size = new Size(200, 37);
        lblOrdersTitle.TabIndex = 0;
        lblOrdersTitle.Text = "My Laundry Orders";
        lblOrdersTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // chkActiveOnly
        // 
        chkActiveOnly.AutoSize = true;
        chkActiveOnly.Dock = DockStyle.Left;
        chkActiveOnly.ForeColor = Color.FromArgb(148, 163, 184);
        chkActiveOnly.Location = new Point(200, 8);
        chkActiveOnly.Name = "chkActiveOnly";
        chkActiveOnly.Padding = new Padding(10, 0, 0, 0);
        chkActiveOnly.Size = new Size(302, 37);
        chkActiveOnly.TabIndex = 1;
        chkActiveOnly.Text = "Show active only (Washing / Drying / Ready)";
        chkActiveOnly.UseVisualStyleBackColor = true;
        chkActiveOnly.CheckedChanged += chkActiveOnly_CheckedChanged;
        // 
        // btnViewTicket
        // 
        btnViewTicket.BackColor = Color.FromArgb(37, 99, 235);
        btnViewTicket.Cursor = Cursors.Hand;
        btnViewTicket.Dock = DockStyle.Right;
        btnViewTicket.FlatAppearance.BorderSize = 0;
        btnViewTicket.FlatStyle = FlatStyle.Flat;
        btnViewTicket.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnViewTicket.ForeColor = Color.White;
        btnViewTicket.Location = new Point(762, 8);
        btnViewTicket.Name = "btnViewTicket";
        btnViewTicket.Size = new Size(190, 37);
        btnViewTicket.TabIndex = 2;
        btnViewTicket.Text = "🎫 View E-Ticket / QR Code";
        btnViewTicket.UseVisualStyleBackColor = false;
        btnViewTicket.Click += btnViewTicket_Click;
        // 
        // flpStats
        // 
        flpStats.Controls.Add(pnlStatActive);
        flpStats.Controls.Add(pnlStatReady);
        flpStats.Controls.Add(pnlStatTotal);
        flpStats.Dock = DockStyle.Top;
        flpStats.Location = new Point(24, 24);
        flpStats.Name = "flpStats";
        flpStats.Size = new Size(952, 100);
        flpStats.TabIndex = 0;
        // 
        // pnlStatActive
        // 
        pnlStatActive.BackColor = Color.FromArgb(30, 41, 59);
        pnlStatActive.Controls.Add(lblActiveStat);
        pnlStatActive.Controls.Add(lblActiveTitle);
        pnlStatActive.Controls.Add(pnlStripActive);
        pnlStatActive.Location = new Point(0, 0);
        pnlStatActive.Margin = new Padding(0, 0, 15, 0);
        pnlStatActive.Name = "pnlStatActive";
        pnlStatActive.Padding = new Padding(16, 12, 16, 12);
        pnlStatActive.Size = new Size(295, 80);
        pnlStatActive.TabIndex = 0;
        // 
        // lblActiveStat
        // 
        lblActiveStat.Dock = DockStyle.Fill;
        lblActiveStat.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblActiveStat.ForeColor = Color.White;
        lblActiveStat.Location = new Point(20, 30);
        lblActiveStat.Name = "lblActiveStat";
        lblActiveStat.Size = new Size(259, 38);
        lblActiveStat.TabIndex = 2;
        lblActiveStat.Text = "0";
        // 
        // lblActiveTitle
        // 
        lblActiveTitle.Dock = DockStyle.Top;
        lblActiveTitle.Font = new Font("Segoe UI", 8.5F);
        lblActiveTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblActiveTitle.Location = new Point(20, 12);
        lblActiveTitle.Name = "lblActiveTitle";
        lblActiveTitle.Size = new Size(259, 18);
        lblActiveTitle.TabIndex = 1;
        lblActiveTitle.Text = "Active In-Process";
        // 
        // pnlStripActive
        // 
        pnlStripActive.BackColor = Color.FromArgb(59, 130, 246);
        pnlStripActive.Dock = DockStyle.Left;
        pnlStripActive.Location = new Point(16, 12);
        pnlStripActive.Name = "pnlStripActive";
        pnlStripActive.Size = new Size(4, 56);
        pnlStripActive.TabIndex = 0;
        // 
        // pnlStatReady
        // 
        pnlStatReady.BackColor = Color.FromArgb(30, 41, 59);
        pnlStatReady.Controls.Add(lblReadyStat);
        pnlStatReady.Controls.Add(lblReadyTitle);
        pnlStatReady.Controls.Add(pnlStripReady);
        pnlStatReady.Location = new Point(310, 0);
        pnlStatReady.Margin = new Padding(0, 0, 15, 0);
        pnlStatReady.Name = "pnlStatReady";
        pnlStatReady.Padding = new Padding(16, 12, 16, 12);
        pnlStatReady.Size = new Size(295, 80);
        pnlStatReady.TabIndex = 1;
        // 
        // lblReadyStat
        // 
        lblReadyStat.Dock = DockStyle.Fill;
        lblReadyStat.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblReadyStat.ForeColor = Color.White;
        lblReadyStat.Location = new Point(20, 30);
        lblReadyStat.Name = "lblReadyStat";
        lblReadyStat.Size = new Size(259, 38);
        lblReadyStat.TabIndex = 2;
        lblReadyStat.Text = "0";
        // 
        // lblReadyTitle
        // 
        lblReadyTitle.Dock = DockStyle.Top;
        lblReadyTitle.Font = new Font("Segoe UI", 8.5F);
        lblReadyTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblReadyTitle.Location = new Point(20, 12);
        lblReadyTitle.Name = "lblReadyTitle";
        lblReadyTitle.Size = new Size(259, 18);
        lblReadyTitle.TabIndex = 1;
        lblReadyTitle.Text = "Ready for Pickup";
        // 
        // pnlStripReady
        // 
        pnlStripReady.BackColor = Color.FromArgb(16, 185, 129);
        pnlStripReady.Dock = DockStyle.Left;
        pnlStripReady.Location = new Point(16, 12);
        pnlStripReady.Name = "pnlStripReady";
        pnlStripReady.Size = new Size(4, 56);
        pnlStripReady.TabIndex = 0;
        // 
        // pnlStatTotal
        // 
        pnlStatTotal.BackColor = Color.FromArgb(30, 41, 59);
        pnlStatTotal.Controls.Add(lblTotalStat);
        pnlStatTotal.Controls.Add(lblTotalTitle);
        pnlStatTotal.Controls.Add(pnlStripTotal);
        pnlStatTotal.Location = new Point(620, 0);
        pnlStatTotal.Margin = new Padding(0, 0, 15, 0);
        pnlStatTotal.Name = "pnlStatTotal";
        pnlStatTotal.Padding = new Padding(16, 12, 16, 12);
        pnlStatTotal.Size = new Size(295, 80);
        pnlStatTotal.TabIndex = 2;
        // 
        // lblTotalStat
        // 
        lblTotalStat.Dock = DockStyle.Fill;
        lblTotalStat.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTotalStat.ForeColor = Color.White;
        lblTotalStat.Location = new Point(20, 30);
        lblTotalStat.Name = "lblTotalStat";
        lblTotalStat.Size = new Size(259, 38);
        lblTotalStat.TabIndex = 2;
        lblTotalStat.Text = "0";
        // 
        // lblTotalTitle
        // 
        lblTotalTitle.Dock = DockStyle.Top;
        lblTotalTitle.Font = new Font("Segoe UI", 8.5F);
        lblTotalTitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblTotalTitle.Location = new Point(20, 12);
        lblTotalTitle.Name = "lblTotalTitle";
        lblTotalTitle.Size = new Size(259, 18);
        lblTotalTitle.TabIndex = 1;
        lblTotalTitle.Text = "Total Orders";
        // 
        // pnlStripTotal
        // 
        pnlStripTotal.BackColor = Color.FromArgb(139, 92, 246);
        pnlStripTotal.Dock = DockStyle.Left;
        pnlStripTotal.Location = new Point(16, 12);
        pnlStripTotal.Name = "pnlStripTotal";
        pnlStripTotal.Size = new Size(4, 56);
        pnlStripTotal.TabIndex = 0;
        // 
        // FrmCustomerPortal
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(1000, 680);
        Controls.Add(pnlBody);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9.5F);
        ForeColor = Color.White;
        Name = "FrmCustomerPortal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaundryHub – Customer Portal";
        pnlHeader.ResumeLayout(false);
        pnlBody.ResumeLayout(false);
        pnlGridWrap.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        pnlFilterBar.ResumeLayout(false);
        pnlFilterBar.PerformLayout();
        flpStats.ResumeLayout(false);
        pnlStatActive.ResumeLayout(false);
        pnlStatReady.ResumeLayout(false);
        pnlStatTotal.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblWelcome;
    private Button btnProfile;
    private Button btnLogout;
    private Panel pnlBody;
    private FlowLayoutPanel flpStats;
    private Panel pnlStatActive;
    private Panel pnlStripActive;
    private Label lblActiveTitle;
    private Label lblActiveStat;
    private Panel pnlStatReady;
    private Panel pnlStripReady;
    private Label lblReadyTitle;
    private Label lblReadyStat;
    private Panel pnlStatTotal;
    private Panel pnlStripTotal;
    private Label lblTotalTitle;
    private Label lblTotalStat;
    private Panel pnlFilterBar;
    private Label lblOrdersTitle;
    private CheckBox chkActiveOnly;
    private Button btnViewTicket;
    private Panel pnlGridWrap;
    private DataGridView dgvOrders;
}
