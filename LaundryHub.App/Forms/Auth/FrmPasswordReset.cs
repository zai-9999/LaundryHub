using System.Security.Cryptography;
using System.Text;
using ReaLTaiizor.Controls;
using LaundryHub.App.Helpers;
using LaundryHub.Core.Models;
using Button = System.Windows.Forms.Button;
using Panel = System.Windows.Forms.Panel;

namespace LaundryHub.App.Forms.Auth;

public class FrmPasswordReset : Form
{
    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblInputLabel;
    private HopeTextBox txtUserOrEmail;
    private Label lblError;
    private Button btnSend;
    private Button btnCancel;

    public FrmPasswordReset()
    {
        Text = "Reset Password";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(460, 285);
        BackColor = Color.White;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        Font = AppFonts.Make(9.5F);

        // Top accent line
        var pnlAccent = new Panel
        {
            Dock = DockStyle.Top,
            Height = 4,
            BackColor = UIThemeHelper.Indigo
        };
        Controls.Add(pnlAccent);

        lblTitle = new Label
        {
            Text = "Reset your password",
            Font = AppFonts.Make(15F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Navy,
            Location = new Point(28, 24),
            AutoSize = true
        };

        lblSubtitle = new Label
        {
            Text = "Enter your username or email address and we'll send a temporary password to your registered email.",
            Font = AppFonts.Make(9.5F),
            ForeColor = UIThemeHelper.Slate,
            Location = new Point(28, 58),
            Size = new Size(404, 44)
        };

        lblInputLabel = new Label
        {
            Text = "USERNAME OR EMAIL",
            Font = AppFonts.Make(8F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Indigo,
            Location = new Point(28, 114),
            AutoSize = true
        };

        txtUserOrEmail = new HopeTextBox
        {
            Location = new Point(28, 136),
            Size = new Size(404, 38),
            Hint = "Username or email address",
            BaseColor = Color.FromArgb(248, 250, 252),
            BorderColorA = UIThemeHelper.Indigo,
            BorderColorB = Color.FromArgb(203, 213, 225),
            Font = AppFonts.Make(10F),
            ForeColor = UIThemeHelper.Navy
        };
        lblError = new Label
        {
            Font = AppFonts.Make(8.5F, FontStyle.Bold),
            ForeColor = UIThemeHelper.Danger,
            Location = new Point(28, 180),
            Size = new Size(404, 20),
            Visible = false
        };

        txtUserOrEmail.TextChanged += (_, _) => lblError.Visible = false;

        btnSend = new Button
        {
            Text = "Send Temporary Password",
            BackColor = UIThemeHelper.Indigo,
            FlatStyle = FlatStyle.Flat,
            ForeColor = Color.White,
            Font = AppFonts.Make(9.5F, FontStyle.Bold),
            Cursor = Cursors.Hand,
            Location = new Point(28, 214),
            Size = new Size(244, 42)
        };
        btnSend.FlatAppearance.BorderSize = 0;
        btnSend.FlatAppearance.MouseOverBackColor = UIThemeHelper.Navy;
        btnSend.Click += BtnSend_Click;

        btnCancel = new Button
        {
            Text = "Cancel",
            BackColor = Color.FromArgb(241, 245, 249),
            FlatStyle = FlatStyle.Flat,
            ForeColor = UIThemeHelper.Navy,
            Font = AppFonts.Make(9.5F, FontStyle.Bold),
            Cursor = Cursors.Hand,
            Location = new Point(284, 214),
            Size = new Size(148, 42)
        };
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240);
        btnCancel.Click += (_, _) => Close();

        Controls.Add(lblTitle);
        Controls.Add(lblSubtitle);
        Controls.Add(lblInputLabel);
        Controls.Add(txtUserOrEmail);
        Controls.Add(lblError);
        Controls.Add(btnSend);
        Controls.Add(btnCancel);

        UIThemeHelper.ApplyRoundedRegion(btnSend, 10);
        UIThemeHelper.ApplyRoundedRegion(btnCancel, 10);

        AcceptButton = btnSend;
        CancelButton = btnCancel;
    }

    private void BtnSend_Click(object? sender, EventArgs e)
    {
        lblError.Visible = false;
        var input = txtUserOrEmail.Text.Trim();
        if (string.IsNullOrWhiteSpace(input))
        {
            ShowError("Please enter your username or email address.");
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
}
