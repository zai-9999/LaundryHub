using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using LaundryHub.Core.Models;

namespace LaundryHub.App.Helpers
{
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
                message.Subject = $"Your order {order.OrderNumber} is ready for pickup";
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

        // Minimal stubs to avoid build/parser issues during debugging.
        public static void SendReceiptAsync(Order order, Customer customer)
        {
            // no-op: email sending temporarily disabled
        }

        public static void SendPasswordReset(User user, string temporaryPassword)
        {
            // no-op: email sending temporarily disabled
        }
    }
}
