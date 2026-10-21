using ReaLTaiizor.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LaundryHub.App.Helpers;

public static class InputValidator
{
    public const int MinPasswordLength = 6;
    public const int MaxPasswordLength = 100;

    public const string PhoneError =
        "Phone number must be 7 to 15 digits (numbers only, optional leading +).";

    private static readonly Regex PhonePattern = new(@"^\+?[0-9]{7,15}$", RegexOptions.Compiled);
    private static readonly Regex EmailPattern = new(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+$", RegexOptions.Compiled);
    private static readonly Regex UsernamePattern = new(@"^[a-zA-Z0-9._-]{3,30}$", RegexOptions.Compiled);
    private static readonly Regex NamePattern = new(@"^[a-zA-Z\u00C0-\u024F\s\.\-']{2,100}$", RegexOptions.Compiled);

    public static bool IsValidPhone(string? phone) =>
        !string.IsNullOrWhiteSpace(phone) && PhonePattern.IsMatch(phone.Trim());

    public static bool IsValidEmail(string? email) =>
        IsValidEmail(email, out _);

    public static bool IsValidEmail(string? email, out string error)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            error = "Email address is required.";
            return false;
        }

        var trimmed = email.Trim();
        if (trimmed.Length > 100)
        {
            error = "Email address cannot exceed 100 characters.";
            return false;
        }

        if (!EmailPattern.IsMatch(trimmed))
        {
            error = "Please enter a valid email address (e.g. name@example.com).";
            return false;
        }

        error = string.Empty;
        return true;
    }

    public static bool IsValidUsername(string? username, out string error)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            error = "Username is required.";
            return false;
        }

        var trimmed = username.Trim();
        if (trimmed.Length < 3 || trimmed.Length > 30)
        {
            error = "Username must be between 3 and 30 characters.";
            return false;
        }

        if (!UsernamePattern.IsMatch(trimmed))
        {
            error = "Username may only contain letters, numbers, underscores (_), hyphens (-), or dots (.).";
            return false;
        }

        error = string.Empty;
        return true;
    }

    public static bool IsValidFullName(string? name, out string error)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            error = "Full name is required.";
            return false;
        }

        var trimmed = name.Trim();
        if (trimmed.Length < 2)
        {
            error = "Full name must be at least 2 characters.";
            return false;
        }

        if (trimmed.Length > 100)
        {
            error = "Full name cannot exceed 100 characters.";
            return false;
        }

        if (!NamePattern.IsMatch(trimmed))
        {
            error = "Full name contains invalid characters. Please use letters, spaces, hyphens, and periods only.";
            return false;
        }

        error = string.Empty;
        return true;
    }

    public static bool IsValidPassword(string? password, out string error)
    {
        if (string.IsNullOrEmpty(password))
        {
            error = "Password is required.";
            return false;
        }

        if (password.Length < MinPasswordLength)
        {
            error = $"Password must be at least {MinPasswordLength} characters.";
            return false;
        }

        if (password.Length > MaxPasswordLength)
        {
            error = $"Password cannot exceed {MaxPasswordLength} characters.";
            return false;
        }

        error = string.Empty;
        return true;
    }

    public static bool IsValidWeight(string? weightText, out decimal weight, out string error, decimal min = 0.1m, decimal max = 200m)
    {
        weight = 0m;
        if (string.IsNullOrWhiteSpace(weightText))
        {
            error = "Weight (kg) is required.";
            return false;
        }

        var cleaned = weightText.Trim().Replace(',', '.');
        if (!decimal.TryParse(cleaned, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out weight))
        {
            error = "Please enter a valid numeric weight (e.g. 5.5).";
            return false;
        }

        weight = Math.Round(weight, 2, MidpointRounding.AwayFromZero);

        if (weight < min)
        {
            error = $"Weight must be at least {min:F1} kg.";
            return false;
        }

        if (weight > max)
        {
            error = $"Weight cannot exceed {max:F1} kg.";
            return false;
        }

        error = string.Empty;
        return true;
    }

    public static bool IsValidPrice(string? priceText, out decimal price, out string error, string fieldName = "Price", decimal min = 0.01m, decimal max = 100000m)
    {
        price = 0m;
        if (string.IsNullOrWhiteSpace(priceText))
        {
            error = $"{fieldName} is required.";
            return false;
        }

        var cleaned = priceText.Trim().Replace(',', '.');
        if (!decimal.TryParse(cleaned, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out price))
        {
            error = $"Please enter a valid amount for {fieldName}.";
            return false;
        }

        price = Math.Round(price, 2, MidpointRounding.AwayFromZero);

        if (price < min)
        {
            error = $"{fieldName} must be at least {min:N2}.";
            return false;
        }

        if (price > max)
        {
            error = $"{fieldName} cannot exceed {max:N2}.";
            return false;
        }

        error = string.Empty;
        return true;
    }

    /// <summary>Standard WinForms TextBox overload for phone numbers.</summary>
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

    /// <summary>ReaLTaiizor HopeTextBox overload for phone numbers.</summary>
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

    /// <summary>Restricts a TextBox to decimal numbers with up to maxDecimalPlaces.</summary>
    public static void RestrictToDecimalInput(TextBox box, int maxDecimalPlaces = 2)
    {
        box.KeyPress += (_, e) =>
        {
            if (char.IsControl(e.KeyChar)) return;

            // Allow decimal point (dot or comma)
            if (e.KeyChar is '.' or ',')
            {
                // Disallow if already contains a decimal separator or at start
                if (box.Text.Contains('.') || box.Text.Contains(',') || box.SelectionStart == 0)
                {
                    e.Handled = true;
                }
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Check decimal place limit if separator already typed
                int dotIdx = box.Text.IndexOfAny(new[] { '.', ',' });
                if (dotIdx >= 0 && box.SelectionStart > dotIdx && box.SelectionLength == 0)
                {
                    string decimals = box.Text.Substring(dotIdx + 1);
                    if (decimals.Length >= maxDecimalPlaces)
                    {
                        e.Handled = true;
                    }
                }
                return;
            }

            e.Handled = true;
        };
    }

    /// <summary>Restricts a HopeTextBox to decimal numbers with up to maxDecimalPlaces.</summary>
    public static void RestrictToDecimalInput(HopeTextBox box, int maxDecimalPlaces = 2)
    {
        box.KeyPress += (_, e) =>
        {
            if (char.IsControl(e.KeyChar)) return;

            // Allow decimal point (dot or comma)
            if (e.KeyChar is '.' or ',')
            {
                // Disallow if already contains a decimal separator or at start
                if (box.Text.Contains('.') || box.Text.Contains(',') || box.SelectionStart == 0)
                {
                    e.Handled = true;
                }
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Check decimal place limit if separator already typed
                int dotIdx = box.Text.IndexOfAny(new[] { '.', ',' });
                if (dotIdx >= 0 && box.SelectionStart > dotIdx && box.SelectionLength == 0)
                {
                    string decimals = box.Text.Substring(dotIdx + 1);
                    if (decimals.Length >= maxDecimalPlaces)
                    {
                        e.Handled = true;
                    }
                }
                return;
            }

            e.Handled = true;
        };
    }

    /// <summary>Restricts a TextBox to digits only, with optional max length.</summary>
    public static void RestrictToDigitsOnly(TextBox box, int maxLength = 0)
    {
        if (maxLength > 0) box.MaxLength = maxLength;
        box.KeyPress += (_, e) =>
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            e.Handled = true;
        };
    }

    /// <summary>Restricts a HopeTextBox to digits only, with optional max length.</summary>
    public static void RestrictToDigitsOnly(HopeTextBox box, int maxLength = 0)
    {
        if (maxLength > 0) box.MaxLength = maxLength;
        box.KeyPress += (_, e) =>
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            e.Handled = true;
        };
    }

    /// <summary>Restricts a TextBox to alphanumeric, dots, hyphens, and underscores.</summary>
    public static void RestrictToUsernameInput(TextBox box, int maxLength = 30)
    {
        if (maxLength > 0) box.MaxLength = maxLength;
        box.KeyPress += (_, e) =>
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar is '.' or '_' or '-') return;
            e.Handled = true;
        };
    }

    /// <summary>Restricts a HopeTextBox to alphanumeric, dots, hyphens, and underscores.</summary>
    public static void RestrictToUsernameInput(HopeTextBox box, int maxLength = 30)
    {
        if (maxLength > 0) box.MaxLength = maxLength;
        box.KeyPress += (_, e) =>
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar is '.' or '_' or '-') return;
            e.Handled = true;
        };
    }
}