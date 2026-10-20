using System.Collections.Concurrent;

namespace LaundryHub.App.Helpers;

/// <summary>
/// Simple in-memory cache for dashboard data to reduce database queries.
/// Items expire after a configurable duration (default 30 seconds).
/// </summary>
public static class DataCache
{
    private static readonly ConcurrentDictionary<string, CacheItem> _cache = new();
    private static readonly TimeSpan _defaultExpiration = TimeSpan.FromSeconds(30);

    private class CacheItem
    {
        public object? Data { get; set; }
        public DateTime Expiration { get; set; }
    }

    /// <summary>
    /// Gets a cached item or creates it using the provided factory function.
    /// </summary>
    public static T GetOrAdd<T>(string key, Func<T> factory, TimeSpan? expiration = null)
    {
        var exp = expiration ?? _defaultExpiration;
        var now = DateTime.UtcNow;

        // Check if item exists and is not expired
        if (_cache.TryGetValue(key, out var item) && item.Expiration > now)
        {
            return (T)item.Data!;
        }

        // Create new item
        var data = factory();
        _cache[key] = new CacheItem
        {
            Data = data,
            Expiration = now.Add(exp)
        };

        return data;
    }

    /// <summary>
    /// Gets a cached item or creates it asynchronously using the provided factory function.
    /// </summary>
    public static async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null)
    {
        var exp = expiration ?? _defaultExpiration;
        var now = DateTime.UtcNow;

        // Check if item exists and is not expired
        if (_cache.TryGetValue(key, out var item) && item.Expiration > now)
        {
            return (T)item.Data!;
        }

        // Create new item
        var data = await factory();
        _cache[key] = new CacheItem
        {
            Data = data,
            Expiration = now.Add(exp)
        };

        return data;
    }

    /// <summary>
    /// Invalidates a specific cache entry.
    /// </summary>
    public static void Invalidate(string key)
    {
        _cache.TryRemove(key, out _);
    }

    /// <summary>
    /// Invalidates all cache entries matching a prefix.
    /// </summary>
    public static void InvalidatePrefix(string prefix)
    {
        var keysToRemove = _cache.Keys.Where(k => k.StartsWith(prefix)).ToList();
        foreach (var key in keysToRemove)
        {
            _cache.TryRemove(key, out _);
        }
    }

    /// <summary>
    /// Clears all cached items.
    /// </summary>
    public static void Clear()
    {
        _cache.Clear();
    }

    /// <summary>
    /// Removes expired items from the cache.
    /// </summary>
    public static void CleanupExpired()
    {
        var now = DateTime.UtcNow;
        var expiredKeys = _cache.Where(kvp => kvp.Value.Expiration <= now)
                               .Select(kvp => kvp.Key)
                               .ToList();

        foreach (var key in expiredKeys)
        {
            _cache.TryRemove(key, out _);
        }
    }
}
