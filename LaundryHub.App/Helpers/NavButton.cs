using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace LaundryHub.App.Helpers;

/// <summary>
/// A modern flat sidebar navigation button with:
/// - Left accent bar when active
/// - Icon (emoji) + text layout
/// - Hover highlight
/// - Optional notification badge
/// </summary>
public class NavButton : System.Windows.Forms.Panel
{
    private bool _isActive;
    private bool _isHovered;
    private string _icon = "";
    private string _caption = "";
    private int _badgeCount;
    private Color _activeAccent = UIThemeHelper.Sand;

    public NavButton()
    {
        SetStyle(ControlStyles.UserPaint
               | ControlStyles.AllPaintingInWmPaint
               | ControlStyles.OptimizedDoubleBuffer
               | ControlStyles.ResizeRedraw, true);
        Height = 44;
        Cursor = Cursors.Hand;
        Padding = new Padding(0);
        Margin = new Padding(0);
    }

    [Category("Appearance")]
    public string Icon
    {
        get => _icon;
        set { _icon = value ?? ""; Invalidate(); }
    }

    [Category("Appearance")]
    public string Caption
    {
        get => _caption;
        set { _caption = value ?? ""; Invalidate(); }
    }

    [Category("Appearance"), DefaultValue(false)]
    public bool IsActive
    {
        get => _isActive;
        set { _isActive = value; Invalidate(); }
    }

    [Category("Appearance"), DefaultValue(0)]
    public int BadgeCount
    {
        get => _badgeCount;
        set { _badgeCount = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color ActiveAccent
    {
        get => _activeAccent;
        set { _activeAccent = value; Invalidate(); }
    }

    public event EventHandler? NavClick;

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _isHovered = true;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _isHovered = false;
        Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        NavClick?.Invoke(this, e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        var bounds = ClientRectangle;

        // Background
        if (_isActive)
        {
            using var activeBrush = new SolidBrush(Color.FromArgb(30, 255, 255, 255));
            g.FillRectangle(activeBrush, bounds);
        }
        else if (_isHovered)
        {
            using var hoverBrush = new SolidBrush(Color.FromArgb(18, 255, 255, 255));
            g.FillRectangle(hoverBrush, bounds);
        }

        // Active accent bar (left edge)
        if (_isActive)
        {
            using var accentBrush = new SolidBrush(_activeAccent);
            g.FillRectangle(accentBrush, 0, 4, 4, bounds.Height - 8);
        }

        // Icon
        int textX = 20;
        if (!string.IsNullOrEmpty(_icon))
        {
            using var iconFont = new Font("Segoe UI Emoji", 11F);
            var iconSize = TextRenderer.MeasureText(g, _icon, iconFont, Size.Empty, TextFormatFlags.NoPadding);
            var iconRect = new Rectangle(20, (bounds.Height - iconSize.Height) / 2, iconSize.Width, iconSize.Height);
            TextRenderer.DrawText(g, _icon, iconFont, iconRect, Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            textX = iconRect.Right + 12;
        }

        // Caption text
        if (!string.IsNullOrEmpty(_caption))
        {
            var textColor = _isActive ? Color.White : Color.FromArgb(200, 210, 230);
            using var textFont = new Font("Segoe UI", 9.5F, _isActive ? FontStyle.Bold : FontStyle.Regular);
            var textRect = new Rectangle(textX, 0, bounds.Width - textX - 14, bounds.Height);
            TextRenderer.DrawText(g, _caption, textFont, textRect, textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        // Badge
        if (_badgeCount > 0)
        {
            var badgeText = _badgeCount > 99 ? "99+" : _badgeCount.ToString();
            using var badgeFont = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            var badgeSize = TextRenderer.MeasureText(g, badgeText, badgeFont, Size.Empty, TextFormatFlags.NoPadding);
            int bw = Math.Max(badgeSize.Width + 10, 22);
            int bh = 18;
            int bx = bounds.Width - bw - 12;
            int by = (bounds.Height - bh) / 2;

            var badgeRect = new Rectangle(bx, by, bw, bh);
            using var badgePath = UIThemeHelper.CreateRoundedRectangle(badgeRect, bh / 2);
            using var badgeFill = new SolidBrush(UIThemeHelper.Danger);
            g.FillPath(badgeFill, badgePath);
            TextRenderer.DrawText(g, badgeText, badgeFont, badgeRect, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }

        base.OnPaint(e);
    }
}

/// <summary>
/// A small uppercase section label for the sidebar ("GENERAL", "OPERATIONS", etc.)
/// </summary>
public class NavSection : Label
{
    public NavSection()
    {
        AutoSize = false;
        Height = 32;
        Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        ForeColor = Color.FromArgb(140, 155, 190);
        TextAlign = ContentAlignment.BottomLeft;
        Padding = new Padding(20, 0, 0, 4);
        Margin = new Padding(0, 8, 0, 0);
        BackColor = Color.Transparent;
    }
}
