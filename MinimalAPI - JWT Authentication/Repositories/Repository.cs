using Microsoft.EntityFrameworkCore;
using MinimalAPI___JWT_Authentication.Data;
using MinimalAPI___JWT_Authentication.Entities;

namespace MinimalAPI___JWT_Authentication.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _database;
        public Repository(AppDbContext database)
        {
            _database = database;
        }
        public async Task<bool> AddUserAsync(User user)
        {
            var databaseUser = await GetUserAsync(user.UserName);
            if (databaseUser is not null)
            {
                return false;
            }
            await _database.Users.AddAsync(user);
            return true;
        }
        public async Task<bool> DeleteUserAsync(string? userName)
        {
            var databaseUser = await GetUserAsync(userName);
            if (databaseUser is null)
            {
                return false;
            }
            _database.Users.Remove(databaseUser);
            return true;
        }
        public async Task<User?> GetUserAsync(string? userName)
        {
            return await _database.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }
        public async Task<User?> GetUserAsync(string? userName, string? password)
        {
            var databaseUser = await GetUserAsync(userName);
            if (databaseUser is null)
            {
                return databaseUser;
            }
            return databaseUser.Password == password ? databaseUser : null;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _database.Users.ToListAsync();
        }
        public async Task<bool?> UpdateUserAsync(string? userName, User updatedUser)
        {
            if(userName != updatedUser.UserName)
            {
                return false;
            }
            var databaseUser = await GetUserAsync(userName);
            if (databaseUser is null)
            {
                return false;
            }
            databaseUser.UserName = updatedUser.UserName;
            databaseUser.Password = updatedUser.Password;
            return true;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync() > 0;
        }
    }
}
