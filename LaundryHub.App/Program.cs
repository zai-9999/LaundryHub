using LaundryHub.App.Forms.Auth;
using LaundryHub.App.Helpers;

namespace LaundryHub.App;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        try
        {
            AppServices.Initialize();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to load configuration or services:\n{ex.Message}\n\nPlease check appsettings.json.",
                "LaundryHub Startup Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        // Check the database before showing the login screen.
        while (true)
        {
            try
            {
                AppServices.TestConnection();
                break;
            }
            catch (Exception ex)
            {
                var result = MessageBox.Show(
                    "LaundryHub can't reach its database.\n\n" +
                    "• Make sure PostgreSQL is running.\n" +
                    "• Make sure the 'laundryhub' database exists (run Scripts/schema.sql).\n" +
                    "• Check the connection string in appsettings.json.\n\n" +
                    $"Details: {ex.Message}",
                    "LaundryHub - Database Unavailable",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Cancel) return;
            }
        }

        Application.Run(new FrmLogin());
    }    
}