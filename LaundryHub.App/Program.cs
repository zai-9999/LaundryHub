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

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => ErrorHandler.Show(e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
        {
            if (e.ExceptionObject is Exception fatal) ErrorHandler.Log(fatal, "fatal error");
            MessageBox.Show(
                "LaundryHub hit a serious problem and has to close.\n\nDetails were saved to the error log.",
                "LaundryHub",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        };
        TaskScheduler.UnobservedTaskException += (_, e) =>
        {
            ErrorHandler.Log(e.Exception, "background task");
            e.SetObserved();
        };

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
                    " Make sure PostgreSQL is running.\n" +
                    " Make sure the 'laundryhub' database exists (run Scripts/schema.sql).\n" +
                    " Check the connection string in appsettings.json.\n\n" +
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