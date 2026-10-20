using System.Drawing.Drawing2D;
using ReaLTaiizor.Controls;

namespace LaundryHub.App.Helpers;

/// <summary>
/// A modern header bar matching the Validah reference style:
/// - Page Title + Subtitle/Breadcrumb badge on the left
/// - Optional Search input in center/right
/// - User profile chip with circular avatar, name, and role on the far right
/// </summary>
public class ModernHeaderBar : System.Windows.Forms.Panel
{
    private readonly Label _lblTitle;
    private readonly Label _lblSubtitle;
    private readonly System.Windows.Forms.Panel _pnlUserProfile;
    private readonly Label _lblAvatar;
    private readonly Label _lblName;
    private readonly Label _lblRole;
    private readonly HopeTextBox _txtSearch;
    private readonly HopeButton _btnAction;

    public ModernHeaderBar()
    {
        SetStyle(ControlStyles.UserPaint
               | ControlStyles.AllPaintingInWmPaint
               | ControlStyles.OptimizedDoubleBuffer
               | ControlStyles.ResizeRedraw, true);

        Dock = DockStyle.Top;
        Height = 72;
        BackColor = Color.White;
        Padding = new Padding(24, 12, 24, 12);

        // ── Right-side User Profile ──
        _pnlUserProfile = new System.Windows.Forms.Panel
        {
            Dock = DockStyle.Right,
            Width = 200,
            BackColor = Color.Transparent
        };

        _lblAvatar = new Label
        {
            Size = new Size(40, 40),
            Location = new Point(0, 4),
            BackColor = UIThemeHelper.Navy,
            ForeColor = UIThemeHelper.Sand,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "AD"
        };
        _lblAvatar.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = new GraphicsPath();
            path.AddEllipse(0, 0, _lblAvatar.Width - 1, _lblAvatar.Height - 1);
            _lblAvatar.Region = new Region(path);
        };

        _lblName = new Label
        {
            Location = new Point(48, 6),
            Size = new Size(150, 18),
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            TextAlign = ContentAlignment.MiddleLeft,
            Text = "Administrator"
        };

        _lblRole = new Label
        {
            Location = new Point(48, 24),
            Size = new Size(150, 16),
            Font = new Font("Segoe UI", 8F),
            ForeColor = UIThemeHelper.TextMuted,
            TextAlign = ContentAlignment.MiddleLeft,
            Text = "System Admin"
        };

        _pnlUserProfile.Controls.Add(_lblName);
        _pnlUserProfile.Controls.Add(_lblRole);
        _pnlUserProfile.Controls.Add(_lblAvatar);

        // ── Action Button (e.g. Logout / Refresh) ──
        _btnAction = new HopeButton
        {
            Dock = DockStyle.Right,
            Width = 92,
            Height = 36,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary,
            PrimaryColor = UIThemeHelper.Danger,
            BorderColor = UIThemeHelper.Danger,
            TextColor = Color.White,
            HoverTextColor = Color.White,
            Text = "🚪 Logout",
            Cursor = Cursors.Hand,
            Margin = new Padding(0, 6, 16, 6)
        };

        // ── Search Box ──
        _txtSearch = new HopeTextBox
        {
            Dock = DockStyle.Right,
            Width = 240,
            Font = new Font("Segoe UI", 9.5F),
            BaseColor = Color.FromArgb(248, 249, 252),
            BorderColorA = UIThemeHelper.Indigo,
            BorderColorB = Color.FromArgb(220, 224, 235),
            ForeColor = UIThemeHelper.Navy,
            Hint = "Search Order # or Name..."
        };

        // Spacer between search and user profile
        var spacerRight = new System.Windows.Forms.Panel
        {
            Dock = DockStyle.Right,
            Width = 16,
            BackColor = Color.Transparent
        };

        var spacerSearch = new System.Windows.Forms.Panel
        {
            Dock = DockStyle.Right,
            Width = 16,
            BackColor = Color.Transparent
        };

        // ── Left Side: Title & Subtitle ──
        var pnlTitles = new System.Windows.Forms.Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        _lblTitle = new Label
        {
            Dock = DockStyle.Top,
            Height = 28,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Text = "Platform Overview & Analytics",
            TextAlign = ContentAlignment.MiddleLeft
        };

        _lblSubtitle = new Label
        {
            Dock = DockStyle.Top,
            Height = 20,
            Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Indigo,
            Text = "REAL-TIME LAUNDRY WORKFLOW, PERFORMANCE & REVENUE MONITORING",
            TextAlign = ContentAlignment.MiddleLeft
        };

        pnlTitles.Controls.Add(_lblSubtitle);
        pnlTitles.Controls.Add(_lblTitle);

        // Add controls in right-to-left dock order
        Controls.Add(pnlTitles);
        Controls.Add(spacerSearch);
        Controls.Add(_txtSearch);
        Controls.Add(spacerRight);
        Controls.Add(_btnAction);
        Controls.Add(_pnlUserProfile);
    }

    public string Title
    {
        get => _lblTitle.Text;
        set => _lblTitle.Text = value;
    }

    public string Subtitle
    {
        get => _lblSubtitle.Text;
        set => _lblSubtitle.Text = value;
    }

    public string UserName
    {
        get => _lblName.Text;
        set
        {
            _lblName.Text = value;
            UpdateAvatar(value);
        }
    }

    public string UserRole
    {
        get => _lblRole.Text;
        set => _lblRole.Text = value;
    }

    public HopeTextBox SearchBox => _txtSearch;
    public HopeButton ActionButton => _btnAction;

    private void UpdateAvatar(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _lblAvatar.Text = "U";
            return;
        }

        var parts = name.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 2)
            _lblAvatar.Text = $"{char.ToUpper(parts[0][0])}{char.ToUpper(parts[1][0])}";
        else if (parts.Length == 1 && parts[0].Length >= 2)
            _lblAvatar.Text = $"{char.ToUpper(parts[0][0])}{char.ToUpper(parts[0][1])}";
        else
            _lblAvatar.Text = char.ToUpper(name[0]).ToString();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw a subtle bottom border line
        using var pen = new Pen(Color.FromArgb(230, 233, 242), 1f);
        e.Graphics.DrawLine(pen, 0, Height - 1, Width, Height - 1);
    }
}
