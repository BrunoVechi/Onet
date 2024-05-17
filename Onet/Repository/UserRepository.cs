using Mobile.Models;
using SQLite;

namespace Onet.Repository
{
    public class UserRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public UserRepository()
        {
            _database = new SQLiteAsyncConnection(DbConfig.DatabasePath, DbConfig.Flags);
            _database.CreateTableAsync<User>().Wait();
        }

        public async Task<User> GetUserAsync(int id) => await _database.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();

        public async Task<User> GetUserAsync(string Email) => await _database.Table<User>().Where(u => u.Email == Email).FirstOrDefaultAsync();

        public async Task<bool> DeleteUserAsync(User user) => (await _database.DeleteAsync(user)) > 0;

        public async Task<bool> SaveUserAsync(User user)
        {
            if (user.Id != 0)
                return (await _database.UpdateAsync(user)) > 0;

            else
                return (await _database.InsertAsync(user)) > 0;
        }
    }
}