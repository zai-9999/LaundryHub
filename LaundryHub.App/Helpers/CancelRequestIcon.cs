using System.Drawing.Drawing2D;

namespace LaundryHub.App.Helpers;

/// <summary>
/// Draws the "calendar with an X" glyph used to flag an order that has an active
/// (pending) customer cancellation request. Vector-drawn so it stays crisp at any DPI.
/// </summary>
public static class CancelRequestIcon
{
    public static void Draw(Graphics g, Rectangle bounds, Color color, float stroke = 1.8f)
    {
        var oldSmoothing = g.SmoothingMode;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        using var pen = new Pen(color, stroke)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round,
            LineJoin = LineJoin.Round
        };

        float s = Math.Min(bounds.Width, bounds.Height);
        float x = bounds.X + (bounds.Width - s) / 2f;
        float y = bounds.Y + (bounds.Height - s) / 2f;

        // Calendar body
        var body = new RectangleF(x + s * 0.08f, y + s * 0.16f, s * 0.84f, s * 0.76f);
        using (var path = RoundedRect(body, s * 0.14f))
            g.DrawPath(pen, path);

        // Header divider
        float divY = body.Y + body.Height * 0.24f;
        g.DrawLine(pen, body.X, divY, body.Right, divY);

        // Binder rings
        float ringTop = y;
        float ringBottom = body.Y + s * 0.10f;
        g.DrawLine(pen, x + s * 0.30f, ringTop, x + s * 0.30f, ringBottom);
        g.DrawLine(pen, x + s * 0.70f, ringTop, x + s * 0.70f, ringBottom);

        // The X, centred in the lower part of the body
        float cx = body.X + body.Width / 2f;
        float cy = divY + (body.Bottom - divY) / 2f;
        float r = s * 0.14f;
        using (var xPen = new Pen(color, stroke * 1.15f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
        {
            g.DrawLine(xPen, cx - r, cy - r, cx + r, cy + r);
            g.DrawLine(xPen, cx - r, cy + r, cx + r, cy - r);
        }

        g.SmoothingMode = oldSmoothing;
    }

    private static GraphicsPath RoundedRect(RectangleF r, float radius)
    {
        float d = radius * 2f;
        var path = new GraphicsPath();
        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}
