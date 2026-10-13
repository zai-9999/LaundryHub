using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ReaLTaiizor;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;
using Panel = ReaLTaiizor.Controls.Panel;

namespace LaundryHub.App.Helpers;

public static class UIThemeHelper
{
    public static readonly Color PrimaryDeepOcean = Color.FromArgb(37, 78, 122);
    public static readonly Color PrimaryTealAccent = Color.FromArgb(102, 163, 191);

    public static readonly Color CardCream = Color.FromArgb(255, 252, 247);
    public static readonly Color CardMint = Color.FromArgb(210, 232, 228);
    public static readonly Color CardWhite = Color.White;

    public const int LoginFormWidth = 1100;
    public const int LoginFormHeight = 800;
    public const int LoginWindowRadius = 20;
    public const int LoginCardRadius = 40;
    public const int LoginButtonRadius = 16;
    public const int LoginFieldWidth = 320;
    public const int LoginButtonHeight = 53;

    /// <summary>
    /// Paints a smooth diagonal linear gradient across the control background.
    /// </summary>
    public static void PaintGradientBackground(Control control, PaintEventArgs e)
    {
        if (control.ClientRectangle.Width <= 0 || control.ClientRectangle.Height <= 0) return;

        using var brush = new LinearGradientBrush(
            control.ClientRectangle,
            PrimaryDeepOcean,
            PrimaryTealAccent,
            LinearGradientMode.ForwardDiagonal);

        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        e.Graphics.FillRectangle(brush, control.ClientRectangle);
    }

    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    private const int DwmwaWindowCornerPreference = 33;
    private const int DwmwcpRound = 2;

    /// <summary>
    /// Rounds the OS window corners (Windows 11) and clips the form to a rounded rectangle.
    /// </summary>
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
        catch
        {
            // Older Windows versions ignore this attribute.
        }
    }

    /// <summary>
    /// Same window size, rounded chrome, white card, and centered card for auth screens.
    /// </summary>
    public static void StyleAuthForm(Form form, System.Windows.Forms.Panel card, params Control[] buttons)
    {
        form.ClientSize = new Size(LoginFormWidth, LoginFormHeight);
        form.FormBorderStyle = FormBorderStyle.FixedSingle;
        form.MaximizeBox = false;
        form.StartPosition = FormStartPosition.CenterScreen;

        ApplyRoundedWindow(form, LoginWindowRadius);
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

    /// <summary>
    /// First button is the primary action; the rest use the same secondary style.
    /// </summary>
    public static void StyleLoginButtons(params Control[] buttons)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] is not HopeButton button) continue;

            button.Size = new Size(LoginFieldWidth, LoginButtonHeight);
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.BorderColor = Color.FromArgb(102, 163, 191);

            if (i == 0)
            {
                button.ButtonType = HopeButtonType.Primary;
                button.PrimaryColor = Color.FromArgb(51, 104, 160);
                button.TextColor = Color.White;
                button.HoverTextColor = Color.White;
            }
            else
            {
                button.ButtonType = HopeButtonType.Default;
                button.DefaultColor = Color.FromArgb(200, 223, 219);
                button.TextColor = Color.FromArgb(51, 104, 160);
                button.HoverTextColor = Color.FromArgb(51, 104, 160);
            }
        }
    }

    public static void CenterCardOnForm(Form form, Control card)
    {
        int width = form.ClientSize.Width;
        int height = form.ClientSize.Height;
        if (width <= 0 || height <= 0) return;

        card.Left = Math.Max(24, (width - card.Width) / 2);
        card.Top = Math.Max(24, (height - card.Height) / 2);
    }

    // ── Shared palette / metrics for the standard (non-auth) screens ──────────
    public const int ContentCardRadius = 16;
    public const int HeaderBarHeight = 70;

    /// <summary>Gradient (diagonal deep-ocean → teal) painted behind a top header bar.</summary>
    public static void PaintGradientHeaderBar(Control bar, PaintEventArgs e)
        => PaintGradientBackground(bar, e);

    /// <summary>
    /// Applies the login design language to a standard dashboard / dialog shell:
    /// rounded window chrome + the signature gradient backdrop. Pass the main
    /// white card (if any) so it keeps rounded corners on resize.
    /// </summary>
    public static void StyleStandardForm(Form form, params Control[] contentCards)
    {
        form.StartPosition = FormStartPosition.CenterScreen;
        ApplyRoundedWindow(form, LoginWindowRadius);

        if (contentCards.Length > 0)
        {
            foreach (var card in contentCards)
            {
                card.BackColor = CardWhite;
                ApplyRoundedRegion(card, ContentCardRadius);
                card.SizeChanged += (_, _) => ApplyRoundedRegion(card, ContentCardRadius);
            }
        }
    }

    /// <summary>
    /// Applies the shared grid theme used across the login-styled app:
    /// deep-blue header with cream text, white rows, mint selection highlight.
    /// </summary>
    public static void StyleDataGridView(DataGridView dgv, int headerHeight = 40)
    {
        dgv.BackgroundColor = CardWhite;
        dgv.BorderStyle = BorderStyle.None;
        dgv.EnableHeadersVisualStyles = false;
        dgv.RowHeadersVisible = false;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgv.ColumnHeadersHeight = headerHeight;

        var header = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = PrimaryDeepOcean,
            ForeColor = CardCream,
            SelectionBackColor = PrimaryDeepOcean,
            SelectionForeColor = CardCream,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            Padding = new Padding(8),
            WrapMode = DataGridViewTriState.True
        };
        dgv.ColumnHeadersDefaultCellStyle = header;

        var cell = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = CardWhite,
            ForeColor = Color.FromArgb(51, 104, 160),
            SelectionBackColor = CardMint,
            SelectionForeColor = PrimaryDeepOcean,
            Font = new Font("Segoe UI", 9.5F),
            Padding = new Padding(6),
            WrapMode = DataGridViewTriState.False
        };
        dgv.DefaultCellStyle = cell;

        dgv.GridColor = CardMint;
        dgv.RowTemplate.Height = 36;
        dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Color.FromArgb(248, 250, 252),
            ForeColor = Color.FromArgb(51, 104, 160),
            SelectionBackColor = CardMint,
            SelectionForeColor = PrimaryDeepOcean,
            Font = new Font("Segoe UI", 9.5F),
            Padding = new Padding(6)
        };
    }

    public static void CenterLoginFields(System.Windows.Forms.Panel card, params Control[] fields)
    {
        int cardW = card.Width;
        int fieldW = LoginFieldWidth;
        int x = Math.Max(0, (cardW - fieldW) / 2);

        foreach (var control in fields)
        {
            bool stretchFull = control is Label label
                && !label.AutoSize
                && (label.TextAlign is ContentAlignment.MiddleCenter or ContentAlignment.TopCenter or ContentAlignment.BottomCenter);

            if (stretchFull)
            {
                control.SetBounds(0, control.Top, cardW, control.Height);
            }
            else if (control is Label { AutoSize: true })
            {
                control.Left = x;
            }
            else
            {
                control.SetBounds(x, control.Top, fieldW, control.Height);
            }
        }
    }

    /// <summary>
    /// Clips buttons to a rounder rectangle and keeps the clip on resize.
    /// </summary>
    public static void ApplyRoundedButtons(int radius, params Control[] buttons)
    {
        foreach (var button in buttons)
        {
            ApplyRoundedRegion(button, radius);
            button.SizeChanged += (_, _) => ApplyRoundedRegion(button, radius);
        }
    }

    /// <summary>
    /// Clips the control to a rounded rectangle. Safe to call from SizeChanged.
    /// </summary>
    public static void ApplyRoundedRegion(Control control, int radius = 28)
    {
        if (control.Width <= 0 || control.Height <= 0) return;

        var bounds = new Rectangle(0, 0, control.Width, control.Height);
        var path = CreateRoundedRectangle(bounds, radius);
        var previous = control.Region;
        // Region keeps the GraphicsPath; disposing the path would flatten the corners.
        control.Region = new Region(path);
        previous?.Dispose();
    }

    /// <summary>
    /// Fills the control with a solid color, clipped to the rounded region.
    /// </summary>
    public static void PaintRoundedSolidCard(Control control, PaintEventArgs e, Color color, int radius = 28)
    {
        var bounds = control.ClientRectangle;
        if (bounds.Width <= 0 || bounds.Height <= 0) return;

        using var path = CreateRoundedRectangle(bounds, radius);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var brush = new SolidBrush(color);
        e.Graphics.FillPath(brush, path);
    }

    /// <summary>
    /// Fills the control with a cream-to-mint gradient, clipped to the rounded region.
    /// </summary>
    public static void PaintRoundedGradientCard(Control control, PaintEventArgs e, int radius = 28)
    {
        var bounds = control.ClientRectangle;
        if (bounds.Width <= 0 || bounds.Height <= 0) return;

        using var path = CreateRoundedRectangle(bounds, radius);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var brush = new LinearGradientBrush(
            bounds,
            CardCream,
            CardMint,
            LinearGradientMode.ForwardDiagonal);
        e.Graphics.FillPath(brush, path);
    }

    /// <summary>
    /// Makes layout container panels transparent so the form's gradient backdrop
    /// shows through (used by the standard screens to float white cards on gradient).
    /// </summary>
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
}
