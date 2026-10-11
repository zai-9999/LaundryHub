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

        Application.Run(new FrmLogin());
    }    
}