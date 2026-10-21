using System.Drawing;

namespace LaundryHub.App.Helpers;

public static class AppFonts
{
    public static Font Make(float size, FontStyle style = FontStyle.Regular)
    {
        return new Font("Segoe UI", size, style, GraphicsUnit.Point);
    }
}
