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
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimizeBox = true;
        MinimumSize = new Size(460, 260);
        Size = new Size(460, 260);
        BackColor = UIThemeHelper.Navy;

        pnlCard = new Panel
        {
            BackColor = UIThemeHelper.CardWhite,
            Location = new Point(40, 30),
            Size = new Size(380, 170)
        };
        pnlCard.Paint += PnlCard_Paint;

        lblTitle = new Label
        {
            Text = "Password Reset",
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Location = new Point(20, 16),
            AutoSize = true
        };

        lblSubtitle = new Label
        {
            Text = "Enter your username or email to receive a temporary password.",
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = UIThemeHelper.TextMuted,
            Location = new Point(20, 44),
            Size = new Size(340, 28)
        };

        txtUserOrEmail = new TextBox
        {
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("Segoe UI", 11F),
            ForeColor = UIThemeHelper.Navy,
            Location = new Point(20, 78),
            Size = new Size(340, 27)
        };

        lblError = new Label
        {
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = UIThemeHelper.Danger,
            Location = new Point(20, 108),
            Size = new Size(340, 18),
            Visible = false
        };

        btnSend = new Button
        {
            Text = "Send",
            BackColor = UIThemeHelper.Indigo,
            FlatStyle = FlatStyle.Flat,
            ForeColor = Color.White,
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
            Location = new Point(20, 128),
            Size = new Size(160, 30)
        };
        btnSend.FlatAppearance.BorderSize = 0;

        btnCancel = new Button
        {
            Text = "Cancel",
            FlatStyle = FlatStyle.Flat,
            ForeColor = UIThemeHelper.Indigo,
            Font = new Font("Segoe UI", 8.5F),
            Location = new Point(200, 128),
            Size = new Size(160, 30)
        };
        btnCancel.FlatAppearance.BorderColor = UIThemeHelper.BorderSoft;

        btnSend.Click += BtnSend_Click;
        btnCancel.Click += (_, _) => Close();

        pnlCard.Controls.Add(lblTitle);
        pnlCard.Controls.Add(lblSubtitle);
        pnlCard.Controls.Add(txtUserOrEmail);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(btnSend);
        pnlCard.Controls.Add(btnCancel);

        Controls.Add(pnlCard);

        // Keep card sized to form on resize
        SizeChanged += (_, _) =>
        {
            pnlCard.Size = new Size(ClientSize.Width - 80, ClientSize.Height - 60);
            pnlCard.Location = new Point(40, 30);
        };
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
