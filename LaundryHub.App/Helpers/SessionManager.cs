using LaundryHub.Core.Models;
using LaundryHub.Core.Enums;

namespace LaundryHub.App.Helpers;

/// <summary>
/// Holds the currently logged-in user for the session.
/// Cleared on logout.
/// </summary>
public static class SessionManager
{
    public static User? CurrentUser { get; private set; }

    public static bool IsLoggedIn => CurrentUser != null;

    public static UserRole? Role =>
        CurrentUser != null && Enum.TryParse<UserRole>(CurrentUser.Role, out var r)
            ? r : null;

    public static bool IsAdmin  => Role == UserRole.Admin;
    public static bool IsStaff  => Role == UserRole.Staff || Role == UserRole.Admin;
    public static bool IsCustomer => Role == UserRole.Customer;

    public static void Login(User user)  => CurrentUser = user;
    public static void Logout()          => CurrentUser = null;
}
