using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Utils;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Helpers;

public static class EmailHelper
{
    public static async Task<bool> SendReadyForPickupAsync(Order order, Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Email))
            return false;

        var configuration = AppServices.Configuration;
        var host = configuration["Email:SmtpHost"];
        var senderEmail = configuration["Email:SenderEmail"];
        var appPassword = configuration["Email:AppPassword"];

        if (string.IsNullOrWhiteSpace(host) ||
            string.IsNullOrWhiteSpace(senderEmail) ||
            string.IsNullOrWhiteSpace(appPassword) ||
            !int.TryParse(configuration["Email:SmtpPort"], out var port))
        {
            return false;
        }

        try
        {
            var shopName = configuration["App:ShopName"] ?? "LaundryHub";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(configuration["Email:SenderName"] ?? shopName, senderEmail));
            message.To.Add(MailboxAddress.Parse(customer.Email));
            message.Subject = $"[{shopName}] Your order {order.OrderNumber} is ready for pickup";
            message.Body = new BodyBuilder
            {
                TextBody = $"Hello {customer.FullName},\n\nYour order {order.OrderNumber} is ready for pickup at {shopName}.\n\nThank you for choosing {shopName}.",
                HtmlBody = $"<p>Hello {System.Net.WebUtility.HtmlEncode(customer.FullName)},</p>" +
                           $"<p>Your order <strong>{System.Net.WebUtility.HtmlEncode(order.OrderNumber)}</strong> is ready for pickup at {System.Net.WebUtility.HtmlEncode(shopName)}.</p>" +
                           $"<p>Thank you for choosing {System.Net.WebUtility.HtmlEncode(shopName)}.</p>"
            }.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(host, port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(senderEmail, appPassword);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
            return true;
        }
        catch
        {
            return false;
        }
    }

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
                System.Diagnostics.Debug.WriteLine($"Failed to send receipt email: {ex.Message}");
            }
        });
    }

    private static void SendReceipt(Order order, Customer customer)
    {
        var cfg       = AppServices.Configuration;
        var smtpHost  = cfg["Email:SmtpHost"]!;
        var smtpPort  = int.Parse(cfg["Email:SmtpPort"]!);
        var sender    = cfg["Email:SenderEmail"]!;
        var senderName = cfg["Email:SenderName"] ?? "LaundryHub";
        var appPwd    = cfg["Email:AppPassword"];
        if (string.IsNullOrWhiteSpace(appPwd) || appPwd.Equals("SET_IN_ENV", StringComparison.OrdinalIgnoreCase))
        {
            System.Diagnostics.Debug.WriteLine("Email:AppPassword is not configured. Skipping receipt email.");
            return;
        }
        var shopName  = AppServices.ShopName;

        var message   = new MimeMessage();
        message.From.Add(new MailboxAddress(senderName, sender));
        message.To.Add(new MailboxAddress(customer.FullName, customer.Email!));
        message.Subject = $"[{shopName}] Order Receipt  {order.OrderNumber}";

        var builder   = new BodyBuilder();

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
          <td style='padding:8px;font-size:18px;color:#1e40af'><strong>{order.TotalAmount:N2}</strong></td></tr>
      <tr><td style='padding:8px;background:#f3f4f6'><strong>Pickup Date</strong></td>
          <td style='padding:8px'>{order.PickupDate:MMMM dd, yyyy}</td></tr>
      <tr><td style='padding:8px;background:#f3f4f6'><strong>Status</strong></td>
          <td style='padding:8px'>{order.Status}</td></tr>
    </table>
    <p style='color:#6b7280;font-size:12px;text-align:center'>
      Present your order number <strong>{order.OrderNumber}</strong> when claiming your laundry.<br/>
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

    public static void SendPasswordReset(User user, string temporaryPassword)
    {
        if (string.IsNullOrWhiteSpace(user.Email)) return;

        Task.Run(() =>
        {
            try
            {
                var cfg = AppServices.Configuration;
                var host = cfg["Email:SmtpHost"];
                var senderEmail = cfg["Email:SenderEmail"];
                var appPassword = cfg["Email:AppPassword"];
                if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(senderEmail) || string.IsNullOrWhiteSpace(appPassword) ||
                    !int.TryParse(cfg["Email:SmtpPort"], out var port))
                {
                    return;
                }

                var shopName = cfg["App:ShopName"] ?? "LaundryHub";
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(cfg["Email:SenderName"] ?? shopName, senderEmail));
                message.To.Add(MailboxAddress.Parse(user.Email));
                message.Subject = $"[{shopName}] Temporary Password Reset";
                message.Body = new BodyBuilder
                {
                    TextBody = $"Hello {user.FullName},\n\nYour temporary password is: {temporaryPassword}\n\nPlease log in and update your password immediately.",
                    HtmlBody = $"<p>Hello <strong>{System.Net.WebUtility.HtmlEncode(user.FullName)}</strong>,</p>" +
                               $"<p>Your temporary password is: <code style='font-size:16px;background:#f3f4f6;padding:4px 8px;border-radius:4px;'>{System.Net.WebUtility.HtmlEncode(temporaryPassword)}</code></p>" +
                               $"<p>Please log in and update your password immediately.</p>"
                }.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(host, port, SecureSocketOptions.StartTls);
                smtp.Authenticate(senderEmail, appPassword);
                smtp.Send(message);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to send password reset email: {ex.Message}");
            }
        });
    }
}
