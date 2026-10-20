using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Utils;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Helpers;

public static class EmailHelper
{
    /// <summary>
    /// Sends a digital receipt email to the customer in a background thread.
    /// </summary>
    public static void SendReceiptAsync(Order order, Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Email)) return;

        Task.Run(() =>
        {
            try
            {
                SendReceipt(order, customer);
            }
            catch (Exception ex)
            {
                // Log silently; email failure should not break the app
                System.Diagnostics.Debug.WriteLine($"Email send failed: {ex.Message}");
            }
        });
    }

    private static void SendReceipt(Order order, Customer customer)
    {
        var cfg       = AppServices.Configuration;
        var smtpHost  = cfg["Email:SmtpHost"]!;
        var smtpPort  = int.Parse(cfg["Email:SmtpPort"]!);
        var sender    = cfg["Email:SenderEmail"]!;
        var senderName = cfg["Email:SenderName"]!;
        var appPwd    = cfg["Email:AppPassword"];
        if (string.IsNullOrWhiteSpace(appPwd) || appPwd.Equals("SET_IN_ENV", StringComparison.OrdinalIgnoreCase))
        {
            System.Diagnostics.Debug.WriteLine("Email:AppPassword is not configured or still SET_IN_ENV. Skipping receipt email.");
            return;
        }
        var shopName  = AppServices.ShopName;

        var message   = new MimeMessage();
        message.From.Add(new MailboxAddress(senderName, sender));
        message.To.Add(new MailboxAddress(customer.FullName, customer.Email!));
        message.Subject = $"[{shopName}] Order Receipt – {order.OrderNumber}";

        // Attach QR code image
        var qrPath    = QrCodeHelper.SaveToTempFile(order.OrderNumber);
        var builder   = new BodyBuilder();
        var qrImage   = builder.LinkedResources.Add(qrPath);
        qrImage.ContentId = MimeUtils.GenerateMessageId();

        builder.HtmlBody = $@"
<html><body style='font-family:Arial,sans-serif;color:#333;max-width:520px;margin:auto'>
  <div style='background:#1e40af;padding:24px;border-radius:8px 8px 0 0;text-align:center'>
    <h1 style='color:#fff;margin:0'>{shopName}</h1>
    <p style='color:#bfdbfe;margin:4px 0'>Digital Receipt</p>
  </div>
  <div style='padding:24px;border:1px solid #e5e7eb;border-top:none;border-radius:0 0 8px 8px'>
    <p>Hi <strong>{customer.FullName}</strong>,</p>
    <p>Thank you for choosing {shopName}! Here is your order summary:</p>
    <table style='width:100%;border-collapse:collapse;margin:16px 0'>
      <tr><td style='padding:8px;background:#f3f4f6;width:140px'><strong>Order #</strong></td>
          <td style='padding:8px'>{order.OrderNumber}</td></tr>
      <tr><td style='padding:8px;background:#f3f4f6'><strong>Service</strong></td>
          <td style='padding:8px'>{order.ServiceName}</td></tr>
      <tr><td style='padding:8px;background:#f3f4f6'><strong>Weight</strong></td>
          <td style='padding:8px'>{order.WeightKg} kg</td></tr>
      <tr><td style='padding:8px;background:#f3f4f6'><strong>Total</strong></td>
          <td style='padding:8px;font-size:18px;color:#1e40af'><strong>₱{order.TotalAmount:N2}</strong></td></tr>
      <tr><td style='padding:8px;background:#f3f4f6'><strong>Pickup Date</strong></td>
          <td style='padding:8px'>{order.PickupDate:MMMM dd, yyyy}</td></tr>
      <tr><td style='padding:8px;background:#f3f4f6'><strong>Status</strong></td>
          <td style='padding:8px'>{order.Status}</td></tr>
    </table>
    <p style='text-align:center'><strong>Your QR E-Ticket:</strong><br/>
      <img src='cid:{qrImage.ContentId}' style='margin-top:8px;border:4px solid #e5e7eb;border-radius:4px'/></p>
    <p style='color:#6b7280;font-size:12px;text-align:center'>
      Present this QR code when claiming your laundry.<br/>
      For inquiries, visit our shop or call us directly.
    </p>
  </div>
</body></html>";

        message.Body = builder.ToMessageBody();

        using var client = new SmtpClient();
        client.Connect(smtpHost, smtpPort, SecureSocketOptions.StartTls);
        client.Authenticate(sender, appPwd);
        client.Send(message);
        client.Disconnect(true);
    }
}
