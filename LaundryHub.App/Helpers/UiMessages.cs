namespace LaundryHub.App.Helpers;

/// <summary>
/// Drop-in replacement for MessageBox.Show that shows the themed AlertDialog.
///
/// It takes the same arguments and returns the same results (DialogResult.OK, Yes or No),
/// so existing code only needs "MessageBox.Show(" changed to "UiMessages.Show(".
///
/// The alert type (success, info, warning, error, question) is taken from the MessageBoxIcon.
/// An "Information" icon is shown as a green Success alert when the title or text sounds like
/// a success message ("Success", "Order Claimed", "...successfully..."), otherwise as Info.
/// </summary>
public static class UiMessages
{
    public static DialogResult Show(string text)
        => Show(text, "Notice", MessageBoxButtons.OK, MessageBoxIcon.None);

    public static DialogResult Show(string text, string caption)
        => Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None);

    public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        => Show(text, caption, buttons, MessageBoxIcon.None);

    public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        try
        {
            var kind = KindFor(text, caption, icon);

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    switch (kind)
                    {
                        case AlertKind.Success: AlertDialog.Success(text, caption); break;
                        case AlertKind.Warning: AlertDialog.Warning(text, caption); break;
                        case AlertKind.Error: AlertDialog.Error(text, caption); break;
                        default: AlertDialog.Info(text, caption); break;
                    }
                    return DialogResult.OK;

                case MessageBoxButtons.YesNo:
                    return AlertDialog.Confirm(text, caption, "Yes", "No", kind)
                        ? DialogResult.Yes
                        : DialogResult.No;
            }
        }
        catch (Exception)
        {
            // If the themed dialog cannot be shown for any reason, fall back to the plain Windows one.
        }

        // Button sets AlertDialog does not support (for example Retry/Cancel) use the Windows dialog.
        return System.Windows.Forms.MessageBox.Show(text, caption, buttons, icon);
    }

    private static AlertKind KindFor(string text, string caption, MessageBoxIcon icon)
    {
        string c = (caption ?? "").ToLowerInvariant();
        string t = (text ?? "").ToLowerInvariant();

        switch (icon)
        {
            case MessageBoxIcon.Error:        // same value as Stop and Hand
                return AlertKind.Error;
            case MessageBoxIcon.Warning:      // same value as Exclamation
                return AlertKind.Warning;
            case MessageBoxIcon.Question:
                return AlertKind.Question;
            case MessageBoxIcon.Information:  // same value as Asterisk
                return LooksLikeSuccess(c, t) ? AlertKind.Success : AlertKind.Info;
        }

        // No icon was given, so guess from the words.
        if (c.Contains("error") || c.Contains("fail") ||
            t.StartsWith("failed") || t.StartsWith("could not") || t.StartsWith("unable"))
            return AlertKind.Error;

        if (c.Contains("warning") || c.Contains("invalid") || c.Contains("required"))
            return AlertKind.Warning;

        return LooksLikeSuccess(c, t) ? AlertKind.Success : AlertKind.Info;
    }

    private static bool LooksLikeSuccess(string lowerCaption, string lowerText)
    {
        string[] captionWords = { "success", "complete", "claimed", "updated", "sent" };

        foreach (var word in captionWords)
        {
            if (lowerCaption.Contains(word)) return true;
        }

        return lowerText.Contains("success");
    }
}