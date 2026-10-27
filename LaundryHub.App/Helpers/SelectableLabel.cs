using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace LaundryHub.App.Helpers;

/// Looks like a Label, but the text can be selected and copied (Ctrl+C / right-click).
public class SelectableLabel : Panel
{
    private sealed class InnerBox : TextBox
    {
        public override Color ForeColor { get => base.ForeColor; set { } } // ignore ApplyTheme
        public void SetFore(Color c) => base.ForeColor = c;
    }

    private readonly InnerBox _tb = new()
    {
        ReadOnly = true, BorderStyle = BorderStyle.None, Multiline = true,
        WordWrap = true, ScrollBars = ScrollBars.None, TabStop = false, Cursor = Cursors.IBeam
    };

    public SelectableLabel()
    {
        Controls.Add(_tb);
        _tb.SetFore(UIThemeHelper.Indigo);
        _tb.DoubleClick += (s, e) => OnDoubleClick(e);
    }

    [AllowNull]
    public override string Text { get => _tb.Text; set { _tb.Text = value ?? ""; Relayout(); } }

    public override Color ForeColor { get => _tb.ForeColor; set { _tb.SetFore(value); base.ForeColor = value; } }

    [Browsable(false)]
    public ContentAlignment TextAlign { get; set; } = ContentAlignment.MiddleLeft;

    protected override void OnFontChanged(EventArgs e) { base.OnFontChanged(e); _tb.Font = Font; Relayout(); }
    protected override void OnResize(EventArgs e) { base.OnResize(e); Relayout(); }
    protected override void OnParentChanged(EventArgs e) { base.OnParentChanged(e); SyncBack(); }
    protected override void OnParentBackColorChanged(EventArgs e) { base.OnParentBackColorChanged(e); SyncBack(); }

    private void SyncBack() => _tb.BackColor = Parent?.BackColor ?? Color.White;

    private void Relayout()
    {
        if (Width <= 0 || Height <= 0) return;
        var h = TextRenderer.MeasureText(string.IsNullOrEmpty(_tb.Text) ? " " : _tb.Text, _tb.Font,
            new Size(Width, 0), TextFormatFlags.WordBreak | TextFormatFlags.NoPadding).Height + 2;
        h = Math.Min(h, Height);
        _tb.SetBounds(0, (Height - h) / 2, Width, h);
    }
}
