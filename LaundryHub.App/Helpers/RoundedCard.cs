using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace LaundryHub.App.Helpers;

/// <summary>
/// A panel with anti-aliased rounded corners, a hairline border and an optional soft
/// shadow. It paints everything inside its own bounds (no Region clipping), so edges
/// stay smooth and nothing needs recalculating on resize.
/// </summary>
public class RoundedCard : System.Windows.Forms.Panel
{
    private int _radius = 14;
    private bool _shadow = true;
    private Color _fillColor = Color.White;
    private Color _borderColor = Color.FromArgb(222, 217, 206);

    public RoundedCard()
    {
        SetStyle(ControlStyles.UserPaint
               | ControlStyles.AllPaintingInWmPaint
               | ControlStyles.OptimizedDoubleBuffer
               | ControlStyles.ResizeRedraw
               | ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
    }

    [Category("Appearance"), DefaultValue(14)]
    public int Radius
    {
        get => _radius;
        set { _radius = Math.Max(0, value); Invalidate(); }
    }

    [Category("Appearance"), DefaultValue(true)]
    public bool Shadow
    {
        get => _shadow;
        set { _shadow = value; Invalidate(); }
    }

    [Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color FillColor
    {
        get => _fillColor;
        set { _fillColor = value; Invalidate(); }
    }

    [Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color BorderColor
    {
        get => _borderColor;
        set { _borderColor = value; Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        int bottomSpace = _shadow ? 5 : 1;
        var rect = new Rectangle(0, 0, Width - 1, Height - bottomSpace);

        if (rect.Width >= 4 && rect.Height >= 4)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_shadow)
            {
                for (int i = 4; i >= 1; i--)
                {
                    var r = new Rectangle(rect.X + 1, rect.Y + i, rect.Width - 2, rect.Height);
                    using var shadowPath = RoundedPath(r, _radius);
                    using var shadowBrush = new SolidBrush(Color.FromArgb(10, 17, 24, 68));
                    g.FillPath(shadowBrush, shadowPath);
                }
            }

            using var path = RoundedPath(rect, _radius);
            using var fill = new SolidBrush(_fillColor);
            g.FillPath(fill, path);

            if (_borderColor.A > 0)
            {
                using var pen = new Pen(_borderColor, 1f);
                g.DrawPath(pen, path);
            }
        }

        base.OnPaint(e);
    }

    private static GraphicsPath RoundedPath(Rectangle r, int radius)
    {
        var path = new GraphicsPath();
        int d = Math.Min(radius * 2, Math.Min(r.Width, r.Height));
        if (d <= 0)
        {
            path.AddRectangle(r);
            return path;
        }

        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}
