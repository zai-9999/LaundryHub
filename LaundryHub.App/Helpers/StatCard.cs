namespace LaundryHub.App.Helpers;

/// <summary>
/// A rounded dashboard card: colored accent strip, small caption, big value.
/// Use <see cref="ValueLabel"/> to set the number from code.
/// </summary>
public class StatCard : RoundedCard
{
    private readonly Label _caption = new();
    private readonly Label _value = new();
    private readonly Panel _strip = new();

    public StatCard()
    {
        Radius = 14;
        Padding = new Padding(16, 12, 16, 18);

        _strip.Dock = DockStyle.Left;
        _strip.Width = 4;
        _strip.BackColor = UIThemeHelper.Indigo;

        _caption.Dock = DockStyle.Top;
        _caption.Height = 22;
        _caption.Padding = new Padding(12, 0, 0, 0);
        _caption.BackColor = Color.White;
        _caption.ForeColor = UIThemeHelper.TextMuted;
        _caption.Font = new Font("Segoe UI", 9.5F);
        _caption.TextAlign = ContentAlignment.MiddleLeft;
        _caption.AutoEllipsis = true;

        _value.Dock = DockStyle.Fill;
        _value.Padding = new Padding(12, 0, 0, 0);
        _value.BackColor = Color.White;
        _value.ForeColor = UIThemeHelper.Navy;
        _value.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        _value.TextAlign = ContentAlignment.MiddleLeft;
        _value.AutoEllipsis = true;
        _value.Text = "";

        // Fill first, then Top, then Left: WinForms docks in reverse order.
        Controls.Add(_value);
        Controls.Add(_caption);
        Controls.Add(_strip);
    }

    /// <summary>The big number label. Assign text to it as usual: card.ValueLabel.Text = "12".</summary>
    public Label ValueLabel => _value;

    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string Caption
    {
        get => _caption.Text;
        set => _caption.Text = value;
    }

    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public Color AccentColor
    {
        get => _strip.BackColor;
        set => _strip.BackColor = value;
    }
}

public static class StatRow
{
    /// <summary>
    /// Replaces a FlowLayoutPanel of fixed-width stat panels with an equal-width row of
    /// StatCards that fills the available width at any window size. Returns the new cards
    /// in the order given, so you can re-point your existing value labels at them.
    /// </summary>
    public static StatCard[] Replace(FlowLayoutPanel old, params (string Caption, Color Accent)[] items)
    {
        var parent = old.Parent ?? throw new InvalidOperationException("The stat row has no parent.");
        int zIndex = parent.Controls.GetChildIndex(old);

        var table = new TableLayoutPanel
        {
            Dock = old.Dock,
            Height = 114,
            BackColor = Color.Transparent,
            ColumnCount = items.Length,
            RowCount = 1,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var cards = new StatCard[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / items.Length));
            cards[i] = new StatCard
            {
                Caption = items[i].Caption,
                AccentColor = items[i].Accent,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 4, i == items.Length - 1 ? 0 : 14, 6)
            };
            table.Controls.Add(cards[i], i, 0);
        }

        parent.SuspendLayout();
        old.Visible = false;
        foreach (Control child in old.Controls)
            child.Visible = false;
        parent.Controls.Remove(old);
        old.Dispose();
        parent.Controls.Add(table);
        parent.Controls.SetChildIndex(table, zIndex);
        // Ensure sibling DockStyle.Fill controls (e.g. cardOrders) remain in front so they expand to fill
        foreach (Control sibling in parent.Controls)
        {
            if (sibling != table && sibling.Dock == DockStyle.Fill)
                sibling.BringToFront();
        }
        parent.ResumeLayout(true);

        return cards;
    }
}
