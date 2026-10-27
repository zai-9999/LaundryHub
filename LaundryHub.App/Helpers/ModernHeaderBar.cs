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

        //  Right-side Container Panel 
        // Avoids DockStyle.Right height stretching on individual controls
        var pnlRight = new System.Windows.Forms.Panel
        {
            Dock = DockStyle.Right,
            Width = 460,
            BackColor = Color.Transparent
        };

        //  Right-side User Profile 
        _pnlUserProfile = new System.Windows.Forms.Panel
        {
            Location = new Point(260, 4),
            Size = new Size(196, 40),
            BackColor = Color.Transparent
        };

        _lblAvatar = new Label
        {
            Size = new Size(40, 40),
            Location = new Point(0, 0),
            BackColor = Color.Transparent,
            ForeColor = UIThemeHelper.Sand,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "AD"
        };
        _lblAvatar.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            using var brush = new SolidBrush(UIThemeHelper.Navy);
            e.Graphics.FillEllipse(brush, 0, 0, _lblAvatar.Width - 1, _lblAvatar.Height - 1);
            TextRenderer.DrawText(e.Graphics, _lblAvatar.Text, _lblAvatar.Font,
                new Rectangle(0, 0, _lblAvatar.Width, _lblAvatar.Height),
                UIThemeHelper.Sand,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        };

        _lblName = new Label
        {
            Location = new Point(48, 3),
            Size = new Size(146, 18),
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            TextAlign = ContentAlignment.MiddleLeft,
            Text = "Administrator",
            UseMnemonic = false
        };

        _lblRole = new Label
        {
            Location = new Point(48, 21),
            Size = new Size(146, 16),
            Font = new Font("Segoe UI", 8F),
            ForeColor = UIThemeHelper.TextMuted,
            TextAlign = ContentAlignment.MiddleLeft,
            Text = "System Admin",
            UseMnemonic = false
        };

        _pnlUserProfile.Controls.Add(_lblName);
        _pnlUserProfile.Controls.Add(_lblRole);
        _pnlUserProfile.Controls.Add(_lblAvatar);

        //  Search Box 
        _txtSearch = new HopeTextBox
        {
            Location = new Point(0, 6),
            Size = new Size(244, 36),
            Font = new Font("Segoe UI", 9.5F),
            BaseColor = Color.FromArgb(248, 249, 252),
            BorderColorA = UIThemeHelper.Indigo,
            BorderColorB = Color.FromArgb(220, 224, 235),
            ForeColor = UIThemeHelper.Navy,
            Hint = "Search Order # or Name..."
        };

        pnlRight.Controls.Add(_pnlUserProfile);
        pnlRight.Controls.Add(_txtSearch);

        //  Left Side: Title & Subtitle 
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
            TextAlign = ContentAlignment.MiddleLeft,
            UseMnemonic = false
        };

        _lblSubtitle = new Label
        {
            Dock = DockStyle.Top,
            Height = 20,
            Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Indigo,
            Text = "REAL-TIME LAUNDRY WORKFLOW, PERFORMANCE & REVENUE MONITORING",
            TextAlign = ContentAlignment.MiddleLeft,
            UseMnemonic = false
        };

        pnlTitles.Controls.Add(_lblSubtitle);
        pnlTitles.Controls.Add(_lblTitle);

        // Add controls in dock order: Fill first, then Right container
        Controls.Add(pnlTitles);
        Controls.Add(pnlRight);
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
