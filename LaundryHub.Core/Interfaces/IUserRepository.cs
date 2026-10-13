using LaundryHub.Core.Models;

namespace LaundryHub.Core.Interfaces;

public interface IUserRepository
{
    User? GetByUsername(string username);
    User? GetById(int userId);
    IEnumerable<User> GetAllStaff();
    void Add(User user);
    void Update(User user);
    void SetActive(int userId, bool isActive);
    bool UsernameExists(string username, int excludeUserId = 0);
    bool EmailExists(string email, int excludeUserId = 0);
}
