using ReaLTaiizor.Controls;
using System.Text.RegularExpressions;

namespace LaundryHub.App.Helpers;

public static class InputValidator
{
    public const int MinPasswordLength = 6;   
    public const string PhoneError =
        "Phone number must be 7 to 15 digits (numbers only).";

    private static readonly Regex PhonePattern = new(@"^\+?[0-9]{7,15}$", RegexOptions.Compiled);

    public static bool IsValidPhone(string? phone) =>
        !string.IsNullOrWhiteSpace(phone) && PhonePattern.IsMatch(phone.Trim());

    public static bool IsValidPassword(string? password, out string error)
    {
        if (string.IsNullOrEmpty(password) || password.Length < MinPasswordLength)
        {
            error = $"Password must be at least {MinPasswordLength} characters.";
            return false;
        }
        error = string.Empty;
        return true;
    }

    /// <summary>Standard WinForms TextBox overload.</summary>
    public static void RestrictToPhoneInput(TextBox box)
    {
        box.MaxLength = 16;
        box.KeyPress += (_, e) =>
        {
            if (char.IsControl(e.KeyChar) || e.KeyChar is >= '0' and <= '9') return;
            if (e.KeyChar == '+' && box.SelectionStart == 0 && !box.Text.Contains('+')) return;
            e.Handled = true;
        };
    }

    /// <summary>ReaLTaiizor HopeTextBox overload.</summary>
    public static void RestrictToPhoneInput(HopeTextBox box)
    {
        box.MaxLength = 16;
        box.KeyPress += (_, e) =>
        {
            if (char.IsControl(e.KeyChar) || e.KeyChar is >= '0' and <= '9') return;
            if (e.KeyChar == '+' && box.SelectionStart == 0 && !box.Text.Contains('+')) return;
            e.Handled = true;
        };
    }
}