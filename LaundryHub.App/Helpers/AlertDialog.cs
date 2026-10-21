using System.Drawing.Drawing2D;

namespace LaundryHub.App.Helpers;

public enum AlertKind
{
    Success,
    Info,
    Warning,
    Error,
    Question
}


public static class AlertDialog
{
    public static void Success(string message, string title = "Success", IWin32Window? owner = null)
        => ShowOk(AlertKind.Success, title, message, owner);

    public static void Info(string message, string title = "Notice", IWin32Window? owner = null)
        => ShowOk(AlertKind.Info, title, message, owner);

    public static void Warning(string message, string title = "Please check", IWin32Window? owner = null)
        => ShowOk(AlertKind.Warning, title, message, owner);

    public static void Error(string message, string title = "Something went wrong", IWin32Window? owner = null)
        => ShowOk(AlertKind.Error, title, message, owner);

    public static bool Confirm(
        string message,
        string title = "Please confirm",
        string yesText = "Yes",
        string noText = "No",
        AlertKind kind = AlertKind.Question,
        IWin32Window? owner = null)
    {
        using var dlg = new AlertForm(kind, title, message, yesText, noText);
        return dlg.ShowDialog(ResolveOwner(owner)) == DialogResult.Yes;
    }

    private static void ShowOk(AlertKind kind, string title, string message, IWin32Window? owner)
    {
        using var dlg = new AlertForm(kind, title, message, "OK", null);
        dlg.ShowDialog(ResolveOwner(owner));
    }

    private static IWin32Window? ResolveOwner(IWin32Window? owner)
    {
        if (owner != null) return owner;
        if (Form.ActiveForm != null) return Form.ActiveForm;
        return Application.OpenForms.Cast<Form>().LastOrDefault(f => f.Visible && !f.IsDisposed);
    }

}

internal sealed class AlertForm : Form
{
    private readonly AlertKind _kind;
    private readonly Color _accent;
    private readonly Font _titleFont = new("Segoe UI Semibold", 12F);
    private readonly Font _bodyFont = new("Segoe UI", 10F);
    private readonly Font _buttonFont = new("Segoe UI Semibold", 9.5F);
    private readonly Font _glyphFont = new("Segoe UI", 18F, FontStyle.Bold);
    private Rectangle _iconRect;

    public AlertForm(AlertKind kind, string title, string message, string yesText, string? noText)
    {
        _kind = kind;
        _accent = AccentFor(kind);

        AutoScaleMode = AutoScaleMode.None;
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.CenterParent;
        ShowInTaskbar = false;
        ShowIcon = false;
        MinimizeBox = false;
        MaximizeBox = false;
        BackColor = Color.White;
        DoubleBuffered = true;
        Text = title;

        int width = S(440);
        int pad = S(24);
        int accentBar = S(5);
        int iconSize = S(44);
        int textLeft = pad + iconSize + S(16);
        int textWidth = width - textLeft - pad;
        int y = accentBar + pad;

        _iconRect = new Rectangle(pad, y, iconSize, iconSize);


        int titleH = MeasureHeight(title, _titleFont, textWidth) + S(2);
        var lblTitle = new Label
        {
            Text = title,
            Font = _titleFont,
            ForeColor = UIThemeHelper.Navy,
            AutoSize = false,
            UseMnemonic = false,
            Location = new Point(textLeft, y),
            Size = new Size(textWidth, titleH)
        };

        int maxBodyH = S(240);
        int bodyH = MeasureHeight(message, _bodyFont, textWidth) + S(4);
        bool scroll = bodyH > maxBodyH;
        int labelWidth = textWidth;
        if (scroll)
        {
            labelWidth = textWidth - SystemInformation.VerticalScrollBarWidth;
            bodyH = MeasureHeight(message, _bodyFont, labelWidth) + S(4);
        }

        var bodyHost = new Panel
        {
            BackColor = Color.White,
            AutoScroll = scroll,
            Location = new Point(textLeft, y + titleH + S(6)),
            Size = new Size(textWidth, Math.Min(bodyH, maxBodyH))
        };
        var lblBody = new Label
        {
            Text = message,
            Font = _bodyFont,
            ForeColor = UIThemeHelper.Navy,
            AutoSize = false,
            UseMnemonic = false,
            Location = Point.Empty,
            Size = new Size(labelWidth, bodyH)
        };
        bodyHost.Controls.Add(lblBody);


        int contentBottom = Math.Max(bodyHost.Bottom, _iconRect.Bottom);
        int btnTop = contentBottom + pad;
        int btnH = S(36);

        var primary = MakeButton(yesText, filled: true);
        primary.DialogResult = noText == null ? DialogResult.OK : DialogResult.Yes;
        primary.Location = new Point(width - pad - primary.Width, btnTop);

        Button? secondary = null;
        if (noText != null)
        {
            secondary = MakeButton(noText, filled: false);
            secondary.DialogResult = DialogResult.No;
            secondary.Location = new Point(primary.Left - S(10) - secondary.Width, btnTop);
        }

        Controls.Add(lblTitle);
        Controls.Add(bodyHost);
        Controls.Add(primary);
        if (secondary != null) Controls.Add(secondary);

        AcceptButton = primary;
        CancelButton = secondary ?? primary;

        ClientSize = new Size(width, btnTop + btnH + S(20));
    }


    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.ClassStyle |= 0x00020000; 
            return cp;
        }
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        Activate();
        TopMost = true;
        TopMost = false;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        using (var border = new Pen(UIThemeHelper.Border))
            g.DrawRectangle(border, 0, 0, Width - 1, Height - 1);

        using (var bar = new SolidBrush(_accent))
            g.FillRectangle(bar, 0, 0, Width, S(5));

        using (var disc = new SolidBrush(Tint(_accent)))
            g.FillEllipse(disc, _iconRect);

        DrawGlyph(g);
    }

    private void DrawGlyph(Graphics g)
    {
        var r = _iconRect;

        switch (_kind)
        {
            case AlertKind.Success:
                using (var pen = NewGlyphPen())
                {
                    g.DrawLines(pen, new[]
                    {
                        Pt(r, 0.29f, 0.53f),
                        Pt(r, 0.44f, 0.68f),
                        Pt(r, 0.72f, 0.35f)
                    });
                }
                break;

            case AlertKind.Error:
                using (var pen = NewGlyphPen())
                {
                    g.DrawLine(pen, Pt(r, 0.33f, 0.33f), Pt(r, 0.67f, 0.67f));
                    g.DrawLine(pen, Pt(r, 0.67f, 0.33f), Pt(r, 0.33f, 0.67f));
                }
                break;

            default:
                string glyph = _kind == AlertKind.Warning ? "!" : _kind == AlertKind.Info ? "i" : "?";
                TextRenderer.DrawText(g, glyph, _glyphFont, r, _accent,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);
                break;
        }
    }

    private Pen NewGlyphPen() => new(_accent, S(3))
    {
        StartCap = LineCap.Round,
        EndCap = LineCap.Round,
        LineJoin = LineJoin.Round
    };

    private Button MakeButton(string text, bool filled)
    {
        int w = Math.Max(S(100), TextRenderer.MeasureText(text, _buttonFont).Width + S(32));

        var btn = new Button
        {
            Text = text,
            Font = _buttonFont,
            Size = new Size(w, S(36)),
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            UseVisualStyleBackColor = false,
            BackColor = filled ? UIThemeHelper.Indigo : Color.White,
            ForeColor = filled ? Color.White : UIThemeHelper.Navy
        };
        btn.FlatAppearance.BorderSize = filled ? 0 : 1;
        btn.FlatAppearance.BorderColor = UIThemeHelper.BorderSoft;
        return btn;
    }

    private static Color AccentFor(AlertKind kind) => kind switch
    {
        AlertKind.Success => UIThemeHelper.Success,
        AlertKind.Warning => UIThemeHelper.Warning,
        AlertKind.Error => UIThemeHelper.Danger,
        _ => UIThemeHelper.Indigo
    };

    // Mixes the accent color with white to get a soft background for the icon circle.
    private static Color Tint(Color c, double amount = 0.16) => Color.FromArgb(
        255,
        (int)(255 - (255 - c.R) * amount),
        (int)(255 - (255 - c.G) * amount),
        (int)(255 - (255 - c.B) * amount));

    private static PointF Pt(Rectangle r, float fx, float fy) =>
        new(r.X + r.Width * fx, r.Y + r.Height * fy);

    private static int MeasureHeight(string text, Font font, int width) =>
        TextRenderer.MeasureText(text, font, new Size(width, int.MaxValue),
            TextFormatFlags.WordBreak | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix).Height;

    private int S(int value) => (int)Math.Round(value * DeviceDpi / 96.0);

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _titleFont.Dispose();
            _bodyFont.Dispose();
            _buttonFont.Dispose();
            _glyphFont.Dispose();
        }
        base.Dispose(disposing);
    }
}