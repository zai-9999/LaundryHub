using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Util;

namespace LaundryHub.App.Helpers;

/// <summary>Lays out the login card controls (by name) in one consistent vertical flow.</summary>
public static class AuthLayout
{
    private const int CardWidth = 480;
    private const int FieldWidth = 360;
    private const int TopPad = 36;
    private const int BottomPad = 36;
    private static bool _busy;

    public static void Arrange(System.Windows.Forms.Panel card)
    {
        if (_busy) return;
        _busy = true;
        try
        {
            card.SuspendLayout();
            int x = (CardWidth - FieldWidth) / 2;
            int y = TopPad;

            Control? Find(string name) => card.Controls.Find(name, false).FirstOrDefault();

            void Full(Control? c, int h, int gap)
            {
                if (c == null) return;
                c.SetBounds(0, y, CardWidth, h);
                y += h + gap;
            }

            void Field(Control? c, int h, int gap, int w = FieldWidth)
            {
                if (c == null) return;
                c.SetBounds(x, y, w, h);
                y += h + gap;
            }

            void Caption(Label? l)
            {
                if (l == null) return;
                l.AutoSize = false;
                l.Font = AppFonts.Make(10F, FontStyle.Bold);
                l.ForeColor = UIThemeHelper.Indigo;
                l.TextAlign = ContentAlignment.BottomLeft;
                Field(l, 24, 4);
            }

            void Input(Control? t, int w = FieldWidth)
            {
                if (t == null) return;
                t.Font = AppFonts.Make(11F);
                t.TabStop = true;
                Field(t, 44, 16, w);
                y -= 0;
            }

            void Outlined(Control? b)
            {
                if (b is not HopeButton hb) return;
                hb.ButtonType = HopeButtonType.Default;
                hb.DefaultColor = Color.White;
                hb.BorderColor = UIThemeHelper.Indigo;
                hb.TextColor = UIThemeHelper.Indigo;
                hb.HoverTextColor = UIThemeHelper.Navy;
                hb.Font = AppFonts.Make(10.5F, FontStyle.Bold);
                Field(hb, 46, 10);
                UIThemeHelper.ApplyRoundedRegion(hb, 14);
            }

            void Ghost(Control? b)
            {
                if (b is not HopeButton hb) return;
                hb.ButtonType = HopeButtonType.Default;
                hb.DefaultColor = Color.White;
                hb.BorderColor = Color.White;
                hb.TextColor = UIThemeHelper.Slate;
                hb.HoverTextColor = UIThemeHelper.Indigo;
                hb.Font = AppFonts.Make(10F);
                Field(hb, 38, 2);
                UIThemeHelper.ApplyRoundedRegion(hb, 12);
            }

            // ---- header ----
            if (Find("picLogo") is PictureBox pic && pic.Image != null)
                Full(pic, 64, 4);

            if (Find("lblTitle") is Label title)
            {
                title.Font = AppFonts.Make(26F, FontStyle.Bold);
                title.ForeColor = UIThemeHelper.Indigo;
                title.TextAlign = ContentAlignment.MiddleCenter;
                Full(title, 46, 0);
            }
            if (Find("lblSubtitle") is Label sub)
            {
                sub.Font = AppFonts.Make(10.5F);
                sub.ForeColor = UIThemeHelper.TextMuted;
                sub.TextAlign = ContentAlignment.MiddleCenter;
                Full(sub, 26, 26);
            }

            // ---- fields ----
            Caption(Find("lblUser") as Label);
            Input(Find("txtUsername"));

            Caption(Find("lblPass") as Label);
            var pass = Find("txtPassword");
            var toggle = Find("btnTogglePassword") as System.Windows.Forms.Button;
            int passTop = y;
            Input(pass, FieldWidth - 64);
            if (toggle != null && pass != null)
            {
                toggle.FlatStyle = FlatStyle.Flat;
                toggle.FlatAppearance.BorderSize = 1;
                toggle.FlatAppearance.BorderColor = UIThemeHelper.BorderSoft;
                toggle.BackColor = Color.White;
                toggle.ForeColor = UIThemeHelper.Indigo;
                toggle.Font = AppFonts.Make(9F, FontStyle.Bold);
                toggle.Cursor = Cursors.Hand;
                toggle.TabStop = false;
                toggle.SetBounds(x + FieldWidth - 58, passTop, 58, 44);
                toggle.Text = pass is TextBox or Control ? (IsMasked(pass) ? "Show" : "Hide") : "Show";
            }

            if (Find("lnkForgotPassword") is LinkLabel forgot)
            {
                forgot.Font = AppFonts.Make(9.5F);
                forgot.TextAlign = ContentAlignment.MiddleRight;
                Field(forgot, 24, 4);
            }
            else
            {
                y -= 4;
            }

            if (Find("lblError") is Label err)
            {
                err.Font = AppFonts.Make(9.5F);
                err.TextAlign = ContentAlignment.MiddleCenter;
                Field(err, 24, 8);
            }

            // ---- primary action ----
            if (Find("btnLogin") is HopeButton login)
            {
                login.Font = AppFonts.Make(11F, FontStyle.Bold);
                Field(login, 50, 18);
                UIThemeHelper.ApplyRoundedRegion(login, 14);
            }

            // ---- secondary actions ----
            if (Find("lblSeparator") is Label sep)
            {
                sep.Font = AppFonts.Make(9.5F);
                sep.ForeColor = UIThemeHelper.TextMuted;
                sep.TextAlign = ContentAlignment.MiddleCenter;
                Full(sep, 22, 10);
            }

            Outlined(Find("btnRegister"));
            Outlined(Find("btnSwitchToCustomer"));
            Ghost(Find("btnPricing"));
            Ghost(Find("btnGuestLookup"));
            Ghost(Find("btnSwitchToStaff"));

            // ---- size the card to its content and keep it centred ----
            int height = y + BottomPad;
            if (card.Width != CardWidth || card.Height != height)
                card.Size = new Size(CardWidth, height);
            UIThemeHelper.ApplyRoundedRegion(card, UIThemeHelper.LoginCardRadius);
            if (card.FindForm() is Form f) UIThemeHelper.CenterCardOnForm(f, card);
            card.Invalidate();
        }
        finally
        {
            card.ResumeLayout(true);
            _busy = false;
        }
    }

    private static bool IsMasked(Control c) => c switch
    {
        HopeTextBox h => h.UseSystemPasswordChar || h.PasswordChar != '\0',
        TextBox t => t.UseSystemPasswordChar || t.PasswordChar != '\0',
        _ => true
    };
}
