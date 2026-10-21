using System.Drawing;

namespace LaundryHub.App.Helpers;

public static class AppFonts
{
    public static Font Make(float size, FontStyle style)
    {
        return new Font("Segoe UI", size, style, GraphicsUnit.Pixel);
    }
}
