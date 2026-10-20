using System.Drawing.Drawing2D;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Helpers;

public enum ButtonRole { Primary, Accent, Success, Danger, Soft, Nav }

public static class ModernUI
{
    // ── Palette ──
    public static readonly Color Navy      = Color.FromArgb(17, 24, 68);
    public static readonly Color Ocean     = Color.FromArgb(75, 86, 148);
    public static readonly Color Teal      = Color.FromArgb(114, 136, 174);
    public static readonly Color DeepTeal  = Color.FromArgb(96, 114, 166);
    public static readonly Color Mint      = Color.FromArgb(234, 224, 207);

    public static readonly Color Ink       = Color.FromArgb(23, 28, 58);
    public static readonly Color Muted     = Color.FromArgb(104, 112, 150);
    public static readonly Color Hairline  = Color.FromArgb(232, 227, 218);
    public static readonly Color Surface   = Color.FromArgb(246, 243, 237);
    public static readonly Color SurfaceHi = Color.FromArgb(251, 249, 245);
    public static readonly Color Selection = Color.FromArgb(214, 220, 238);

    public static readonly Color Success   = Color.FromArgb(22, 163, 74);
    public static readonly Color Warning   = Color.FromArgb(217, 119, 6);
    public static readonly Color Danger    = Color.FromArgb(200, 55, 65);

    public const string FontFamily = "Segoe UI";

    // ── Buttons ──
    public static void StyleButton(HopeButton button, ButtonRole role)
    {
        button.Cursor = Cursors.Hand;

        if (role == ButtonRole.Soft)
        {
            button.ButtonType = HopeButtonType.Default;
            button.DefaultColor = Color.FromArgb(240, 234, 222);
            button.BorderColor = Color.FromArgb(214, 205, 188);
            button.TextColor = Ocean;
            button.HoverTextColor = Navy;
            return;
        }

        button.ButtonType = HopeButtonType.Primary;
        button.TextColor = Color.White;
        button.HoverTextColor = Color.White;
        button.PrimaryColor = role switch
        {
            ButtonRole.Accent  => DeepTeal,
            ButtonRole.Success => Success,
            ButtonRole.Danger  => Danger,
            ButtonRole.Nav     => Color.FromArgb(40, 50, 110),
            _                  => Ocean
        };
    }

    public static void StyleButtons(ButtonRole role, params HopeButton[] buttons)
    {
        foreach (var b in buttons) StyleButton(b, role);
    }

    // ── Status pills ──
    public static (Color Fore, Color Back) StatusColors(string? text)
    {
        switch ((text ?? string.Empty).Trim().ToLowerInvariant())
        {
            case "washing":
                return (Color.FromArgb(75, 86, 148), Color.FromArgb(228, 231, 245));
            case "drying":
                return (Color.FromArgb(60, 100, 140), Color.FromArgb(222, 234, 244));
            case "ready for pickup":
            case "paid":
            case "active":
                return (Color.FromArgb(21, 128, 61), Color.FromArgb(220, 245, 228));
            case "claimed":
                return (Color.FromArgb(71, 85, 105), Color.FromArgb(232, 236, 241));
            case "cancelled":
            case "inactive":
                return (Color.FromArgb(185, 40, 50), Color.FromArgb(252, 226, 228));
            case "unpaid":
            case "pending":
                return (Color.FromArgb(180, 83, 9), Color.FromArgb(254, 240, 214));
            default:
                return (Ocean, Selection);
        }
    }

    public static void PaintPillCell(object? sender, DataGridViewCellPaintingEventArgs e)
    {
        if (sender is not DataGridView grid) return;
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        var name = grid.Columns[e.ColumnIndex].Name;
        if (name != "Status" && name != "Payment") return;

        var text = Convert.ToString(e.FormattedValue) ?? string.Empty;
        if (text.Length == 0) return;

        e.PaintBackground(e.ClipBounds, true);

        var (fore, back) = StatusColors(text);
        using var font = new Font(FontFamily, 8.5F, FontStyle.Bold);
        var textSize = TextRenderer.MeasureText(e.Graphics!, text, font, Size.Empty, TextFormatFlags.NoPadding);

        int height = 24;
        int width = Math.Min(textSize.Width + 24, Math.Max(20, e.CellBounds.Width - 12));
        var pill = new Rectangle(
            e.CellBounds.X + 8,
            e.CellBounds.Y + (e.CellBounds.Height - height) / 2,
            width,
            height);

        var g = e.Graphics!;
        var previous = g.SmoothingMode;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        using (var path = UIThemeHelper.CreateRoundedRectangle(pill, height / 2))
        using (var fill = new SolidBrush(back))
            g.FillPath(fill, path);
        g.SmoothingMode = previous;

        TextRenderer.DrawText(g, text, font, pill, fore,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
            TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);

        e.Handled = true;
    }

    // ── Cards ──
    public static void StyleStatCard(System.Windows.Forms.Panel card, Color accent, int radius = 12)
    {
        card.BackColor = SurfaceHi;
        UIThemeHelper.ApplyRoundedRegion(card, radius);
        card.SizeChanged += (_, _) => UIThemeHelper.ApplyRoundedRegion(card, radius);
        card.Paint += (_, e) =>
        {
            using var brush = new SolidBrush(accent);
            e.Graphics.FillRectangle(brush, 0, 0, 6, card.Height);
        };
    }

    // ── Soap-bubble backdrop ──
    public static void PaintBubbles(Graphics g, Rectangle area)
    {
        if (area.Width < 200 || area.Height < 200) return;

        (float X, float Y, float D, int A)[] bubbles =
        {
            (0.06f, 0.10f, 0.20f, 22),
            (0.14f, 0.78f, 0.12f, 18),
            (0.90f, 0.14f, 0.15f, 20),
            (0.84f, 0.74f, 0.26f, 16),
            (0.50f, 0.95f, 0.10f, 18),
            (0.30f, 0.04f, 0.07f, 22),
            (0.70f, 0.40f, 0.05f, 16)
        };

        int side = Math.Min(area.Width, area.Height);
        var previous = g.SmoothingMode;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        foreach (var b in bubbles)
        {
            int d = (int)(side * b.D);
            var rect = new Rectangle(
                area.X + (int)(area.Width * b.X) - d / 2,
                area.Y + (int)(area.Height * b.Y) - d / 2,
                d, d);

            using var fill = new SolidBrush(Color.FromArgb(b.A, 255, 255, 255));
            using var rim = new Pen(Color.FromArgb(Math.Min(255, b.A + 22), 255, 255, 255), 1.2f);
            g.FillEllipse(fill, rect);
            g.DrawEllipse(rim, rect);

            int hd = Math.Max(4, d / 5);
            var shine = new Rectangle(rect.X + d / 6, rect.Y + d / 6, hd, hd);
            using var shineBrush = new SolidBrush(Color.FromArgb(Math.Min(255, b.A + 30), 255, 255, 255));
            g.FillEllipse(shineBrush, shine);
        }

        g.SmoothingMode = previous;
    }

    // ── Inputs ──
    public static void StyleInput(HopeTextBox box)
    {
        box.BackColor = Color.White;
        box.BaseColor = Color.White;
        box.BorderColorA = Teal;
        box.BorderColorB = Color.FromArgb(214, 205, 188);
        box.ForeColor = Ink;
    }
}
