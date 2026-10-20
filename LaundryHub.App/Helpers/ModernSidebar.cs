using System.Drawing.Drawing2D;

namespace LaundryHub.App.Helpers;

/// <summary>
/// A modern sidebar panel that paints a smooth Navy gradient background,
/// hosts a branding area at the top and a scrollable navigation panel below.
/// </summary>
public class ModernSidebar : System.Windows.Forms.Panel
{
    private readonly Label _brandLabel;
    private readonly Label _brandSubtitle;
    private readonly FlowLayoutPanel _navFlow;

    public ModernSidebar()
    {
        SetStyle(ControlStyles.UserPaint
               | ControlStyles.AllPaintingInWmPaint
               | ControlStyles.OptimizedDoubleBuffer
               | ControlStyles.ResizeRedraw, true);

        Width = 250;
        Dock = DockStyle.Left;
        BackColor = UIThemeHelper.Navy;

        // Branding area
        var pnlBrand = new System.Windows.Forms.Panel
        {
            Dock = DockStyle.Top,
            Height = 80,
            BackColor = Color.Transparent,
            Padding = new Padding(20, 16, 20, 0)
        };

        _brandLabel = new Label
        {
            Text = "🧺 LaundryHub",
            Dock = DockStyle.Top,
            Height = 32,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Sand,
            BackColor = Color.Transparent,
            TextAlign = ContentAlignment.MiddleLeft
        };

        _brandSubtitle = new Label
        {
            Text = "MANAGEMENT SYSTEM",
            Dock = DockStyle.Top,
            Height = 20,
            Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(140, 155, 190),
            BackColor = Color.Transparent,
            Padding = new Padding(2, 0, 0, 0),
            TextAlign = ContentAlignment.TopLeft
        };

        pnlBrand.Controls.Add(_brandSubtitle);
        pnlBrand.Controls.Add(_brandLabel);

        // Separator
        var sep = new System.Windows.Forms.Panel
        {
            Dock = DockStyle.Top,
            Height = 1,
            BackColor = Color.FromArgb(40, 255, 255, 255)
        };

        // Navigation flow
        _navFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 8, 0, 8)
        };

        // Add in reverse dock order: Fill first, then Top items
        Controls.Add(_navFlow);
        Controls.Add(sep);
        Controls.Add(pnlBrand);
    }

    public Label BrandLabel => _brandLabel;
    public Label BrandSubtitle => _brandSubtitle;
    public FlowLayoutPanel NavFlow => _navFlow;

    /// <summary>Adds a section header to the nav flow.</summary>
    public NavSection AddSection(string title)
    {
        var section = new NavSection { Text = title.ToUpperInvariant(), Width = Width - 10 };
        _navFlow.Controls.Add(section);
        return section;
    }

    /// <summary>Adds a navigation button to the nav flow.</summary>
    public NavButton AddNavButton(string icon, string caption, EventHandler? onClick = null)
    {
        var btn = new NavButton
        {
            Icon = icon,
            Caption = caption,
            Width = Width - 10,
            Height = 42
        };
        if (onClick != null)
            btn.NavClick += onClick;
        _navFlow.Controls.Add(btn);
        return btn;
    }

    /// <summary>Sets the specified button as active and deactivates all others.</summary>
    public void SetActive(NavButton? activeButton)
    {
        foreach (Control c in _navFlow.Controls)
        {
            if (c is NavButton nb)
                nb.IsActive = nb == activeButton;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        var bounds = ClientRectangle;
        if (bounds.Width <= 0 || bounds.Height <= 0) return;

        // Paint a subtle vertical gradient from Navy to slightly lighter Navy
        using var brush = new LinearGradientBrush(
            bounds,
            UIThemeHelper.Navy,
            Color.FromArgb(25, 35, 80),
            LinearGradientMode.Vertical);
        g.FillRectangle(brush, bounds);

        base.OnPaint(e);
    }
}
