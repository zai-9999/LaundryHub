using System.Security.Cryptography;
using System.Text;
using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Forms.Auth;

public class FrmPasswordReset : Form
{
    private TextBox txtUserOrEmail = new() { Width = 260 };
    private Button btnSend = new() { Text = "Send", Width = 80 };
    private Button btnCancel = new() { Text = "Cancel", Width = 80 };
    private Label lblInfo = new() { AutoSize = true };
    private Label lblError = new() { ForeColor = Color.FromArgb(248,113,113), AutoSize = true, Visible = false };

    public FrmPasswordReset()
    {
        Text = "Password Reset";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        Width = 360;
        Height = 200;

        lblInfo.Text = "Enter Username or Email:";
        lblInfo.Location = new Point(12, 18);

        txtUserOrEmail.Location = new Point(12, 42);

        lblError.Location = new Point(12, 72);

        btnSend.Location = new Point(12, 100);
        btnCancel.Location = new Point(100, 100);

        btnSend.Click += BtnSend_Click;
        btnCancel.Click += (_, _) => Close();

        Controls.Add(lblInfo);
        Controls.Add(txtUserOrEmail);
        Controls.Add(lblError);
        Controls.Add(btnSend);
        Controls.Add(btnCancel);
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
}
