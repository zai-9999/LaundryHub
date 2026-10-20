using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;
using Panel = ReaLTaiizor.Controls.Panel;

namespace LaundryHub.App.Helpers;

public static class UIThemeHelper
{
    // #111844 Navy  #4B5694 Indigo  #7288AE Slate  #EAE0CF Sand
    public static readonly Color Navy        = Color.FromArgb(17, 24, 68);
    public static readonly Color Indigo      = Color.FromArgb(75, 86, 148);
    public static readonly Color Slate       = Color.FromArgb(114, 136, 174);
    public static readonly Color Sand        = Color.FromArgb(234, 224, 207);

    public static readonly Color SandLight   = Color.FromArgb(246, 242, 234);
    public static readonly Color Surface     = Color.FromArgb(248, 245, 239);
    public static readonly Color Tint        = Color.FromArgb(226, 230, 242);
    public static readonly Color Border      = Color.FromArgb(222, 217, 206);
    public static readonly Color BorderSoft  = Color.FromArgb(190, 196, 220);
    public static readonly Color TextMuted   = Color.FromArgb(110, 120, 160);

    public static readonly Color Success     = Color.FromArgb(74, 160, 120);
    public static readonly Color Warning     = Color.FromArgb(214, 160, 80);
    public static readonly Color Danger      = Color.FromArgb(184, 72, 88);
    public static readonly Color Neutral     = Color.FromArgb(130, 138, 165);

    // old names, so existing code still compiles
    public static readonly Color PrimaryDeepOcean = Navy;
    public static readonly Color PrimaryTealAccent = Slate;
    public static readonly Color CardCream   = Color.FromArgb(250, 246, 238);
    public static readonly Color CardMint    = Tint;
    public static readonly Color CardWhite   = Color.White;

    public const int LoginFormWidth = 1100;
    public const int LoginFormHeight = 800;
    public const int LoginWindowRadius = 20;
    public const int LoginCardRadius = 40;
    public const int LoginButtonRadius = 16;
    public const int LoginFieldWidth = 320;
    public const int LoginButtonHeight = 53;

    public static void PaintGradientBackground(Control control, PaintEventArgs e)
    {
        if (control.ClientRectangle.Width <= 0 || control.ClientRectangle.Height <= 0) return;

        using var brush = new LinearGradientBrush(
            control.ClientRectangle, Navy, Slate, LinearGradientMode.ForwardDiagonal)
        {
            InterpolationColors = new ColorBlend
            {
                Colors = new[] { Navy, Indigo, Slate },
                Positions = new[] { 0f, 0.55f, 1f }
            }
        };
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        e.Graphics.FillRectangle(brush, control.ClientRectangle);
    }

    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    private const int DwmwaWindowCornerPreference = 33;
    private const int DwmwcpRound = 2;

    public static void ApplyRoundedWindow(Form form, int radius = 20)
    {
        void Apply()
        {
            ApplyRoundedRegion(form, radius);
            TrySetSystemRoundCorners(form);
        }

        if (form.IsHandleCreated)
            Apply();
        else
            form.HandleCreated += (_, _) => Apply();

        form.SizeChanged += (_, _) => ApplyRoundedRegion(form, radius);
    }

    private static void TrySetSystemRoundCorners(Form form)
    {
        if (!form.IsHandleCreated) return;
        try
        {
            int preference = DwmwcpRound;
            DwmSetWindowAttribute(form.Handle, DwmwaWindowCornerPreference, ref preference, sizeof(int));
        }
        catch { }
    }

    public static void StyleAuthForm(Form form, System.Windows.Forms.Panel card, params Control[] buttons)
    {
        form.ClientSize = new Size(LoginFormWidth, LoginFormHeight);
        form.FormBorderStyle = FormBorderStyle.FixedSingle;
        form.MaximizeBox = false;
        form.StartPosition = FormStartPosition.CenterScreen;

        ApplyRoundedWindow(form, LoginWindowRadius);
        form.BackColor = Navy;
        ApplyTheme(form);
        card.BackColor = CardWhite;
        ApplyRoundedRegion(card, LoginCardRadius);
        CenterCardOnForm(form, card);

        form.Resize += (_, _) =>
        {
            CenterCardOnForm(form, card);
            ApplyRoundedRegion(card, LoginCardRadius);
        };

        if (buttons.Length > 0)
        {
            StyleLoginButtons(buttons);
            ApplyRoundedButtons(LoginButtonRadius, buttons);
        }
    }

    public static void StyleLoginButtons(params Control[] buttons)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] is not HopeButton button) continue;

            button.Size = new Size(LoginFieldWidth, LoginButtonHeight);
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.BorderColor = Slate;

            if (i == 0)
            {
                button.ButtonType = HopeButtonType.Primary;
                button.PrimaryColor = Indigo;
                button.TextColor = Color.White;
                button.HoverTextColor = Color.White;
            }
            else
            {
                button.ButtonType = HopeButtonType.Default;
                button.DefaultColor = Sand;
                button.TextColor = Indigo;
                button.HoverTextColor = Navy;
            }
        }
    }

    public static void LoadAuthLogo(PictureBox pictureBox)
    {
        try
        {
            var logoPath = Path.Combine(Application.StartupPath, "Resources", "logo.png");
            if (File.Exists(logoPath))
                pictureBox.Image = Image.FromFile(logoPath);
        }
        catch { }
    }

    public static void CenterCardOnForm(Form form, Control card)
    {
        int width = form.ClientSize.Width;
        int height = form.ClientSize.Height;
        if (width <= 0 || height <= 0) return;

        card.Left = Math.Max(24, (width - card.Width) / 2);
        card.Top = Math.Max(24, (height - card.Height) / 2);
    }

    public const int ContentCardRadius = 16;
    public const int HeaderBarHeight = 70;

    public static void PaintGradientHeaderBar(Control bar, PaintEventArgs e)
    {
        if (bar.ClientRectangle.Width <= 0 || bar.ClientRectangle.Height <= 0) return;
        using var brush = new LinearGradientBrush(
            bar.ClientRectangle, Navy, Indigo, LinearGradientMode.Horizontal);
        e.Graphics.FillRectangle(brush, bar.ClientRectangle);
    }

    public static void StyleStandardForm(Form form, params Control[] contentCards)
    {
        form.StartPosition = FormStartPosition.CenterScreen;
        ApplyRoundedWindow(form, LoginWindowRadius);
        form.BackColor = Navy;
        ApplyTheme(form);

        foreach (var card in contentCards)
        {
            if (card != null)
            {
                card.BackColor = CardWhite;
                ApplyRoundedRegion(card, ContentCardRadius);
            }
        }
    }

    public static void StyleDataGridView(DataGridView dgv, int headerHeight = 42)
    {
        dgv.BackgroundColor = CardWhite;
        dgv.BorderStyle = BorderStyle.None;
        dgv.EnableHeadersVisualStyles = false;
        dgv.RowHeadersVisible = false;
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgv.ColumnHeadersHeight = headerHeight;
        dgv.AllowUserToResizeRows = false;

        dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Navy, ForeColor = Sand,
            SelectionBackColor = Navy, SelectionForeColor = Sand,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            Padding = new Padding(10, 0, 8, 0),
            WrapMode = DataGridViewTriState.True
        };

        var cell = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = CardWhite, ForeColor = Navy,
            SelectionBackColor = Tint, SelectionForeColor = Navy,
            Font = new Font("Segoe UI", 9.5F),
            Padding = new Padding(10, 0, 6, 0),
            WrapMode = DataGridViewTriState.False
        };
        dgv.DefaultCellStyle = cell;
        dgv.GridColor = Border;
        dgv.RowTemplate.Height = 38;
        dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle(cell) { BackColor = Surface };

        dgv.DataBindingComplete += (_, _) =>
        {
            foreach (DataGridViewColumn c in dgv.Columns)
                c.HeaderText = c.HeaderText.Replace('_', ' ');
        };
    }

    private static readonly ConditionalWeakTable<Control, object> Polished = new();

    private static readonly HashSet<string> InfoPanels = new()
    {
        "pnlPriceSummary", "pnlCustomerCard", "pnlCalculator", "pnlBanner",
        "pnlResult", "pnlPriceBox"
    };

    public static void ApplyTheme(Control root)
    {
        ApplyThemeTree(root);

        if (root is Form form)
        {
            // Stop resizable windows from being squashed smaller than their design.
            if (form.FormBorderStyle == FormBorderStyle.Sizable && form.MinimumSize == Size.Empty)
                form.MinimumSize = form.Size;

            // Run once more on Load so this theme wins over constructor code.
            if (Polished.TryAdd(form, new object()))
                form.Load += (_, _) => ApplyThemeTree(form);
        }
    }

    private static void ApplyThemeTree(Control root)
    {
        foreach (Control c in root.Controls)
        {
            ThemeControl(c);
            ApplyThemeTree(c);
        }
    }

    private static void ThemeLayout(Control c)
    {
        string name = c.Name ?? "";

        if (name.StartsWith("pnlStat", StringComparison.Ordinal))
            PolishCard(c, 14, true);          // stat cards on all dashboards
        else if (name.StartsWith("pnlStrip", StringComparison.Ordinal))
            PolishCard(c, 2, false);          // colored accent strips
        else if (InfoPanels.Contains(name))
            PolishCard(c, 12, true);          // price boxes, result panels, banners

        // Admin sidebar buttons: a little taller and easier to click.
        if (c is HopeButton && c.Parent?.Name == "flpNav")
            c.Height = 46;
    }

    private static void PolishCard(Control c, int radius, bool border)
    {
        if (!Polished.TryAdd(c, new object())) return;

        ApplyRoundedRegion(c, radius);
        c.SizeChanged += (_, _) =>
        {
            ApplyRoundedRegion(c, radius);
            c.Invalidate();
        };

        if (border)
        {
            c.Paint += (_, e) =>
            {
                if (c.Width < 4 || c.Height < 4) return;
                using var path = CreateRoundedRectangle(new Rectangle(0, 0, c.Width - 1, c.Height - 1), radius);
                using var pen = new Pen(Border, 1f);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            };
        }
    }

    private static void ThemeControl(Control c)
    {
        ThemeLayout(c);

        switch (c)
        {
            case HopeButton hb:
                hb.Cursor = Cursors.Hand;
                break;

            case HopeTextBox ht:
                ht.BaseColor = Color.White;
                ht.ForeColor = Navy;
                ht.BorderColorA = Indigo;      // focused
                ht.BorderColorB = BorderSoft;  // resting
                break;

            case System.Windows.Forms.Button b:
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseOverBackColor = Tint;
                b.FlatAppearance.MouseDownBackColor = Sand;
                b.Cursor = Cursors.Hand;
                break;

            case System.Windows.Forms.ComboBox cb:
                cb.FlatStyle = FlatStyle.Flat;
                cb.BackColor = Color.White;
                cb.ForeColor = Navy;
                break;

            case System.Windows.Forms.CheckBox chk:
                chk.ForeColor = Indigo;
                chk.Cursor = Cursors.Hand;
                break;

            case System.Windows.Forms.LinkLabel lnk:
                lnk.LinkColor = Indigo;
                lnk.ActiveLinkColor = Navy;
                lnk.VisitedLinkColor = Indigo;
                lnk.LinkBehavior = LinkBehavior.HoverUnderline;
                lnk.Cursor = Cursors.Hand;
                break;

            case System.Windows.Forms.ListBox lb:
                lb.BorderStyle = BorderStyle.None;
                lb.BackColor = Color.White;
                lb.ForeColor = Navy;
                break;

            case System.Windows.Forms.TextBox tb:
                tb.ForeColor = Navy;
                break;

            case System.Windows.Forms.DateTimePicker dtp:
                dtp.CalendarForeColor = Navy;
                dtp.CalendarMonthBackground = Color.White;
                dtp.CalendarTitleBackColor = Navy;
                dtp.CalendarTitleForeColor = Sand;
                dtp.CalendarTrailingForeColor = Slate;
                break;
        }
    }

    public static void CenterLoginFields(System.Windows.Forms.Panel card, params Control[] fields)
    {
        int cardW = card.Width;
        int fieldW = LoginFieldWidth;
        int x = Math.Max(0, (cardW - fieldW) / 2);

        foreach (var control in fields)
        {
            bool stretchFull = control is PictureBox
                || (control is Label label
                    && !label.AutoSize
                    && (label.TextAlign is ContentAlignment.MiddleCenter or ContentAlignment.TopCenter or ContentAlignment.BottomCenter));

            if (stretchFull)
                control.SetBounds(0, control.Top, cardW, control.Height);
            else if (control is Label { AutoSize: true })
                control.Left = x;
            else
                control.SetBounds(x, control.Top, fieldW, control.Height);
        }
    }

    public static void ApplyRoundedButtons(int radius, params Control[] buttons)
    {
        foreach (var button in buttons)
        {
            ApplyRoundedRegion(button, radius);
            button.SizeChanged += (_, _) => ApplyRoundedRegion(button, radius);
        }
    }

    public static void ApplyRoundedRegion(Control control, int radius = 28)
    {
        if (control.Width <= 0 || control.Height <= 0) return;

        var bounds = new Rectangle(0, 0, control.Width, control.Height);
        var path = CreateRoundedRectangle(bounds, radius);
        var previous = control.Region;
        control.Region = new Region(path);
        previous?.Dispose();
    }

    public static void PaintRoundedSolidCard(Control control, PaintEventArgs e, Color color, int radius = 28)
    {
        var bounds = control.ClientRectangle;
        if (bounds.Width <= 0 || bounds.Height <= 0) return;

        using var path = CreateRoundedRectangle(bounds, radius);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var brush = new SolidBrush(color);
        e.Graphics.FillPath(brush, path);
    }

    public static void PaintRoundedGradientCard(Control control, PaintEventArgs e, int radius = 28)
    {
        var bounds = control.ClientRectangle;
        if (bounds.Width <= 0 || bounds.Height <= 0) return;

        using var path = CreateRoundedRectangle(bounds, radius);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var brush = new LinearGradientBrush(bounds, CardCream, CardMint, LinearGradientMode.ForwardDiagonal);
        e.Graphics.FillPath(brush, path);
    }

    public static void MakeTransparent(params Control[] panels)
    {
        foreach (var p in panels)
            p.BackColor = Color.Transparent;
    }

    public static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
    {
        var path = new GraphicsPath();
        int diameter = Math.Max(0, radius * 2);

        if (diameter == 0 || bounds.Width < diameter || bounds.Height < diameter)
        {
            path.AddRectangle(bounds);
            return path;
        }

        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();
        return path;
    }

    public static void SafeInvoke(this Control control, Action action)
    {
        if (control == null || control.IsDisposed) return;
        if (!control.IsHandleCreated)
        {
            try
            {
                // Force window handle creation if on UI thread
                _ = control.Handle;
            }
            catch
            {
                control.HandleCreated += (_, _) => control.SafeInvoke(action);
                return;
            }
        }

        try
        {
            if (control.InvokeRequired)
                control.BeginInvoke(action);
            else
                action();
        }
        catch (ObjectDisposedException) { }
        catch (InvalidOperationException) { }
    }

    // ── Status pills ──────────────────────────────────────────────────────────
    private static readonly Font StatusPillFont = new("Segoe UI Semibold", 8.5F);

    private static bool TryGetPillColors(string status, out Color back, out Color fore)
    {
        switch (status)
        {
            case "Booked":           back = Color.FromArgb(236, 237, 243); fore = Color.FromArgb(92, 99, 137);  return true;
            case "Washing":          back = Color.FromArgb(226, 230, 242); fore = Color.FromArgb(75, 86, 148);  return true;
            case "Drying":           back = Color.FromArgb(224, 232, 244); fore = Color.FromArgb(62, 86, 130);  return true;
            case "Ready for Pickup": back = Color.FromArgb(221, 239, 230); fore = Color.FromArgb(47, 107, 79);  return true;
            case "Claimed":          back = Color.FromArgb(236, 237, 243); fore = Color.FromArgb(92, 99, 137);  return true;
            case "Cancelled":        back = Color.FromArgb(246, 224, 227); fore = Color.FromArgb(150, 50, 66);  return true;
            case "Active":           back = Color.FromArgb(221, 239, 230); fore = Color.FromArgb(47, 107, 79);  return true;
            case "Disabled":         back = Color.FromArgb(236, 237, 243); fore = Color.FromArgb(92, 99, 137);  return true;
            case "Paid":             back = Color.FromArgb(221, 239, 230); fore = Color.FromArgb(47, 107, 79);  return true;
            case "Unpaid":           back = Color.FromArgb(250, 238, 214); fore = Color.FromArgb(146, 96, 22);  return true;
            default:                 back = Color.Empty; fore = Color.Empty; return false;
        }
    }

    /// <summary>Draws the "Status" column as a rounded colored pill.</summary>
    public static void EnableStatusPills(DataGridView dgv)
    {
        dgv.CellPainting += (_, e) =>
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName != "Status" && colName != "Payment") return;

            var text = e.FormattedValue?.ToString() ?? "";
            if (!TryGetPillColors(text, out var back, out var fore)) return;

            // On a selected row the highlight is the same tint as the pill, so use white instead.
            if ((e.State & DataGridViewElementStates.Selected) != 0) back = Color.White;

            var g = e.Graphics;
            if (g == null) return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            var size = TextRenderer.MeasureText(g, text, StatusPillFont, Size.Empty, TextFormatFlags.NoPadding);
            int h = size.Height + 6;
            int w = Math.Min(size.Width + 24, e.CellBounds.Width - 16);
            var pill = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + (e.CellBounds.Height - h) / 2, w, h);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                int d = pill.Height;
                path.AddArc(pill.X, pill.Y, d, d, 90, 180);
                path.AddArc(pill.Right - d, pill.Y, d, d, 270, 180);
                path.CloseFigure();
                using (var brush = new SolidBrush(back))
                    g.FillPath(brush, path);
            }

            TextRenderer.DrawText(g, text, StatusPillFont, pill, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
        };
    }
}
