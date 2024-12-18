using MinimalAPI___JWT_Authentication.Entities;

namespace MinimalAPI___JWT_Authentication.Repositories
{
    public interface IRepository
    {
        Task<bool> AddUserAsync(User user);
        Task<bool> DeleteUserAsync(string? userName);
        Task<User?> GetUserAsync(string? userName);
        Task<User?> GetUserAsync(string? userName, string? password);
        Task<IEnumerable<User>> GetUsers();
        Task<bool?> UpdateUserAsync(string? userName, User updatedUser);
        Task<bool> SaveChangesAsync();
    }
}
