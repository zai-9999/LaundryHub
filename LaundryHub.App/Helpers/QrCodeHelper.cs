using QRCoder;

namespace LaundryHub.App.Helpers;

public static class QrCodeHelper
{
    /// <summary>
    /// Generates a QR code bitmap for the given order number.
    /// </summary>
    public static Bitmap GenerateQrCode(string orderNumber, int pixelsPerModule = 8)
    {
        using var qrGenerator  = new QRCodeGenerator();
        using var qrCodeData   = qrGenerator.CreateQrCode(orderNumber, QRCodeGenerator.ECCLevel.Q);
        using var qrCode       = new QRCode(qrCodeData);
        return qrCode.GetGraphic(pixelsPerModule);
    }

    public static Bitmap GenerateImage(string orderNumber, int pixelsPerModule = 8)
        => GenerateQrCode(orderNumber, pixelsPerModule);

    /// <summary>
    /// Saves the QR code as a PNG to a temp file and returns the path.
    /// </summary>
    public static string SaveToTempFile(string orderNumber)
    {
        var bmp  = GenerateQrCode(orderNumber);
        var path = Path.Combine(Path.GetTempPath(), $"QR_{orderNumber}.png");
        bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        return path;
    }
}
