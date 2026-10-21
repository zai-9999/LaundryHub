using System.Collections.Concurrent;

namespace LaundryHub.App.Helpers;

/// <summary>
/// Simple in-memory throttling service for UI actions (login, guest lookup, password reset).
/// Not distributed; resets when app restarts. Thread-safe.
/// </summary>
public static class ThrottleService
{
    private static readonly ConcurrentDictionary<string, List<DateTime>> _attempts = new();
    private static readonly ConcurrentDictionary<string, DateTime> _blockedUntil = new();

    private static TimeSpan DefaultWindow() => TimeSpan.FromMinutes(15);
    private static TimeSpan DefaultLockout() => TimeSpan.FromMinutes(15);

    public static bool IsAllowed(string key, int limit = 5, TimeSpan? window = null, TimeSpan? lockout = null)
    {
        window ??= DefaultWindow();
        lockout ??= DefaultLockout();

        if (_blockedUntil.TryGetValue(key, out var blocked) && blocked > DateTime.UtcNow)
            return false;

        if (!_attempts.TryGetValue(key, out var list)) return true;

        var cutoff = DateTime.UtcNow - window.Value;
        list.RemoveAll(d => d < cutoff);
        return list.Count < limit;
    }

    public static void RegisterAttempt(string key, int limit = 5, TimeSpan? window = null, TimeSpan? lockout = null)
    {
        window ??= DefaultWindow();
        lockout ??= DefaultLockout();

        var list = _attempts.GetOrAdd(key, _ => new List<DateTime>());
        lock (list)
        {
            var cutoff = DateTime.UtcNow - window.Value;
            list.RemoveAll(d => d < cutoff);
            list.Add(DateTime.UtcNow);
            if (list.Count >= limit)
            {
                _blockedUntil[key] = DateTime.UtcNow + lockout.Value;
            }
        }
    }

    public static void Reset(string key)
    {
        _attempts.TryRemove(key, out _);
        _blockedUntil.TryRemove(key, out _);
    }

    public static TimeSpan GetRemainingLockout(string key)
    {
        if (_blockedUntil.TryGetValue(key, out var until))
        {
            var rem = until - DateTime.UtcNow;
            return rem > TimeSpan.Zero ? rem : TimeSpan.Zero;
        }
        return TimeSpan.Zero;
    }
}
