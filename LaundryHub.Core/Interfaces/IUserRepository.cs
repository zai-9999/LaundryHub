using LaundryHub.Core.Models;

namespace LaundryHub.Core.Interfaces;

public interface IUserRepository
{
    User? GetByUsername(string username);
    User? GetByEmail(string email);
    User? GetById(int userId);
    IEnumerable<User> GetAllStaff(bool includeArchived = false);
    void Add(User user);
    void Update(User user);
    void SetActive(int userId, bool isActive);
    void Archive(int userId);
    void Restore(int userId);
    bool UsernameExists(string username, int excludeUserId = 0);
    bool EmailExists(string email, int excludeUserId = 0);
    void SetPasswordHash(int userId, string passwordHash);
}
