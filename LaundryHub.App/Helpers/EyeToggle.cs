using System.Drawing.Drawing2D;

namespace LaundryHub.App.Helpers;

/// <summary>Paints a vector eye (slashed when the password is hidden) on a toggle button.</summary>
public static class EyeToggle
{
    public static void Attach(Button button, Func<bool> isRevealed)
    {
        button.Text = string.Empty;
        button.Cursor = Cursors.Hand;
        button.Paint += (_, e) => Draw(e.Graphics, button.ClientRectangle, isRevealed(), button.ForeColor, button.BackColor);
    }

    private static void Draw(Graphics g, Rectangle r, bool revealed, Color color, Color back)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        float cx = r.Width / 2f, cy = r.Height / 2f;
        float w = Math.Min(r.Width - 12, 26), h = w * 0.56f;

        using var pen = new Pen(color, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        using var outline = new GraphicsPath();
        outline.AddBezier(cx - w / 2, cy, cx - w / 4, cy - h, cx + w / 4, cy - h, cx + w / 2, cy);
        outline.AddBezier(cx + w / 2, cy, cx + w / 4, cy + h, cx - w / 4, cy + h, cx - w / 2, cy);
        g.DrawPath(pen, outline);

        float pr = h * 0.42f;
        using var brush = new SolidBrush(color);
        g.FillEllipse(brush, cx - pr, cy - pr, pr * 2, pr * 2);

        if (!revealed)
        {
            float x1 = cx - w / 2 + 3, y1 = cy + h / 1.6f, x2 = cx + w / 2 - 3, y2 = cy - h / 1.6f;
            using var gap = new Pen(back, 4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawLine(gap, x1, y1, x2, y2);
            g.DrawLine(pen, x1, y1, x2, y2);
        }
    }
}
