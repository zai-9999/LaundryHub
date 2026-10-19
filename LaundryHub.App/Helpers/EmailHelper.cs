using LaundryHub.Core.Models;

namespace LaundryHub.App.Helpers
{
    public static class EmailHelper
    {
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
