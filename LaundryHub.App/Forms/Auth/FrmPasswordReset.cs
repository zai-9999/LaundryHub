using System.Security.Cryptography;
using System.Text;
using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Auth;

public class FrmPasswordReset : Form
{
    private Panel pnlCard;
    private Label lblTitle;
    private Label lblSubtitle;
    private TextBox txtUserOrEmail;
    private Label lblError;
    private Button btnSend;
    private Button btnCancel;

    public FrmPasswordReset()
    {
        Text = "Password Reset";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(480, 340);
        BackColor = UIThemeHelper.Navy;

        pnlCard = new Panel
        {
            BackColor = Color.White,
            Location = new Point(20, 20),
            Size = new Size(440, 300)
        };

        lblTitle = new Label
        {
            Text = "Reset your password",
            Font = AppFonts.Make(17F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Indigo,
            Location = new Point(30, 26),
            AutoSize = true
        };

        lblSubtitle = new Label
        {
            Text = "Enter your username or email and we'll send a temporary password to your registered email.",
            Font = AppFonts.Make(10F),
            ForeColor = UIThemeHelper.TextMuted,
            Location = new Point(30, 64),
            Size = new Size(380, 44)
        };

        txtUserOrEmail = new TextBox
        {
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Font = AppFonts.Make(12F),
            ForeColor = UIThemeHelper.Indigo,
            Location = new Point(30, 116),
            Size = new Size(380, 32),
            PlaceholderText = "Username or email"
        };

        lblError = new Label
        {
            Font = AppFonts.Make(9.5F),
            ForeColor = UIThemeHelper.Danger,
            Location = new Point(30, 156),
            Size = new Size(380, 22),
            Visible = false
        };

        btnSend = new Button
        {
            Text = "Send Temporary Password",
            BackColor = UIThemeHelper.Indigo,
            FlatStyle = FlatStyle.Flat,
            ForeColor = Color.White,
            Font = AppFonts.Make(10F, FontStyle.Bold),
            Cursor = Cursors.Hand,
            Location = new Point(30, 196),
            Size = new Size(210, 46)
        };
        btnSend.FlatAppearance.BorderSize = 0;
        btnSend.FlatAppearance.MouseOverBackColor = UIThemeHelper.Navy;

        btnCancel = new Button
        {
            Text = "Cancel",
            BackColor = UIThemeHelper.Sand,
            FlatStyle = FlatStyle.Flat,
            ForeColor = UIThemeHelper.Indigo,
            Font = AppFonts.Make(10F, FontStyle.Bold),
            Cursor = Cursors.Hand,
            Location = new Point(256, 196),
            Size = new Size(154, 46)
        };
        btnCancel.FlatAppearance.BorderSize = 0;

        btnSend.Click += BtnSend_Click;
        btnCancel.Click += (_, _) => Close();

        pnlCard.Controls.Add(lblTitle);
        pnlCard.Controls.Add(lblSubtitle);
        pnlCard.Controls.Add(txtUserOrEmail);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(btnSend);
        pnlCard.Controls.Add(btnCancel);
        Controls.Add(pnlCard);

        UIThemeHelper.ApplyRoundedRegion(pnlCard, 24);
        UIThemeHelper.ApplyRoundedRegion(btnSend, 12);
        UIThemeHelper.ApplyRoundedRegion(btnCancel, 12);

        AcceptButton = btnSend;
        CancelButton = btnCancel;
    }

    private void BtnSend_Click(object? sender, EventArgs e)
    {
        lblError.Visible = false;
        var input = txtUserOrEmail.Text.Trim();
        if (string.IsNullOrWhiteSpace(input))
        {
            ShowError("Please Enter Username or Email.");
            return;
        }

        var key = $"pwdreset:{input}";
        var limit = 3;
        var window = TimeSpan.FromHours(1);
        var lockout = TimeSpan.FromHours(1);

        if (!ThrottleService.IsAllowed(key, limit, window, lockout))
        {
            var rem = ThrottleService.GetRemainingLockout(key);
            ShowError($"Too many reset attempts. Try again in {Math.Ceiling(rem.TotalMinutes)} minutes.");
            return;
        }

        User? user = null;
        if (AppServices.Users.UsernameExists(input))
            user = AppServices.Users.GetByUsername(input);
        else if (AppServices.Users.EmailExists(input))
            user = AppServices.Users.GetByEmail(input);

        if (user == null)
        {
            ThrottleService.RegisterAttempt(key, limit, window, lockout);
            MessageBox.Show("If an account exists for the provided information, a temporary password will be sent to the registered email.",
                "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            return;
        }

        var temp = GenerateTempPassword(10);
        var hash = BCrypt.Net.BCrypt.HashPassword(temp);
        AppServices.Users.SetPasswordHash(user.UserId, hash);
        EmailHelper.SendPasswordReset(user, temp);
        ThrottleService.Reset(key);

        MessageBox.Show("If an account exists for the provided information, a temporary password will be sent to the registered email.",
            "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Close();
    }

    private void ShowError(string msg)
    {
        lblError.Text = msg;
        lblError.Visible = true;
    }

    private static string GenerateTempPassword(int length)
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
        var data = new byte[length];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(data);
        var sb = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            var idx = data[i] % chars.Length;
            sb.Append(chars[idx]);
        }
        return sb.ToString();
    }

    private void PnlCard_Paint(object? sender, PaintEventArgs e)
    {
        UIThemeHelper.PaintRoundedSolidCard(pnlCard, e, UIThemeHelper.CardWhite, UIThemeHelper.LoginCardRadius);
    }
}
