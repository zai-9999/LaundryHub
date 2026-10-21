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
        // Form
        Text = "Password Reset";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Width = 460;
        Height = 260;
        BackColor = Color.FromArgb(15, 23, 42);

        // Card panel (matches app UI)
        pnlCard = new Panel
        {
            BackColor = Color.FromArgb(30, 41, 59),
            Location = new Point(40, 30),
            Size = new Size(380, 170)
        };
        pnlCard.Paint += PnlCard_Paint;

        lblTitle = new Label
        {
            Text = "Password Reset",
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
            ForeColor = Color.White,
            Location = new Point(20, 16),
            AutoSize = true
        };

        lblSubtitle = new Label
        {
            Text = "Enter your username or email to receive a temporary password.",
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = Color.FromArgb(148, 163, 184),
            Location = new Point(20, 44),
            Size = new Size(340, 28)
        };

        txtUserOrEmail = new TextBox
        {
            BackColor = Color.FromArgb(15, 23, 42),
            BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("Segoe UI", 11F),
            ForeColor = Color.White,
            Location = new Point(20, 78),
            Size = new Size(340, 27)
        };

        lblError = new Label
        {
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = Color.FromArgb(248, 113, 113),
            Location = new Point(20, 108),
            Size = new Size(340, 18),
            Visible = false
        };

        btnSend = new Button
        {
            Text = "Send",
            BackColor = Color.FromArgb(37, 99, 235),
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
            ForeColor = Color.FromArgb(96, 165, 250),
            Font = new Font("Segoe UI", 8.5F),
            Location = new Point(200, 128),
            Size = new Size(160, 30)
        };
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);

        btnSend.Click += BtnSend_Click;
        btnCancel.Click += (_, _) => Close();

        pnlCard.Controls.Add(lblTitle);
        pnlCard.Controls.Add(lblSubtitle);
        pnlCard.Controls.Add(txtUserOrEmail);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(btnSend);
        pnlCard.Controls.Add(btnCancel);

        Controls.Add(pnlCard);
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
            // Para di halata kung may account o wala
            MessageBox.Show("If an account exists for the provided information, a temporary password will be sent to the registered email.",
                "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            return;
        }

        // generate ng temp password to update
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
        var g = e.Graphics;
        using var pen = new Pen(Color.FromArgb(59, 130, 246), 1);
        g.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
    }
}
