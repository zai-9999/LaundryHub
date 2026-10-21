using System.Diagnostics;
using Npgsql;

namespace LaundryHub.App.Helpers;

public static class ErrorHandler
{
    private static readonly object LogLock = new();
    private static bool _showing;

    public static string LogPath { get; } = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "LaundryHub",
        "error.log");

    public static void Log(Exception ex, string context = "")
    {
        Debug.WriteLine($"[{context}] {ex}");

        try
        {
            lock (LogLock)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogPath)!);
                File.AppendAllText(
                    LogPath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {context}{Environment.NewLine}" +
                    $"{ex}{Environment.NewLine}{Environment.NewLine}");
            }
        }
        catch (Exception)
        {
            
        }
    }

    public static void Show(Exception ex, string action = "complete that action")
    {
        Log(ex, action);

     
        if (_showing) return;
        _showing = true;

        try
        {
            string message = $"Could not {action}.\n\n{FriendlyMessage(ex)}";
            try
            {
                AlertDialog.Error(message);
            }
            catch (Exception)
            {
       
                MessageBox.Show(message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        finally
        {
            _showing = false;
        }
    }


    public static async Task SafeAsync(Func<Task> action, string whatYouWereDoing)
    {
        try
        {
            await action();
        }
        catch (Exception ex)
        {
            Show(ex, whatYouWereDoing);
        }
    }


    public static string FriendlyMessage(Exception ex)
    {
        if (ex is AggregateException agg) ex = agg.GetBaseException();

        var pg = Find<PostgresException>(ex);
        if (pg != null)
        {
            return pg.SqlState switch
            {
                "23505" => "That information is already in use. A record with the same phone number, email, username or order number already exists.",
                "23514" => "One of the values is not allowed. Please check numbers such as the weight and amounts, then try again.",
                "23503" => "This record is linked to other records, so the change can't be made.",
                "23502" => "A required field was left empty. Please fill in all required fields.",
                "22003" => "A number is too large or too small. Please check the weight and amounts.",
                "22001" => "One of the entries is too long. Please shorten it and try again.",
                "42501" => "The database account is not allowed to do this. Please tell your administrator.",
                "28P01" or "28000" => "The database login was rejected. Please check the connection settings.",
                "3D000" => "The LaundryHub database was not found. Please check the connection settings.",
                _ => Generic()
            };
        }

        if (Find<NpgsqlException>(ex) != null ||
            Find<System.Net.Sockets.SocketException>(ex) != null ||
            Find<TimeoutException>(ex) != null)
        {
            return "LaundryHub can't reach the database right now. Please check that PostgreSQL is running and try again.";
        }

        if (ex is InvalidOperationException) return ex.Message;

        return Generic();
    }

    private static string Generic() =>
        "Something unexpected happened. Please try again. If it keeps happening, tell your administrator.\n\n" +
        $"Details were saved to:\n{LogPath}";

    private static T? Find<T>(Exception? ex) where T : Exception
    {
        for (var e = ex; e != null; e = e.InnerException)
        {
            if (e is T match) return match;
        }
        return null;
    }
}