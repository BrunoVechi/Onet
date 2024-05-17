using Onet.Models;
using SQLite;

namespace Onet.Repository
{
    public class JobRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public JobRepository()
        {
            _database = new SQLiteAsyncConnection(DbConfig.DatabasePath, DbConfig.Flags);
            _database.CreateTableAsync<Job>().Wait();
        }

        public async Task<List<Job>> GetJobsAsync(int userId) => await _database.Table<Job>().Where(t => t.UserId == userId).ToListAsync();

        public async Task<Job> GetJobAsync(int id) => await _database.Table<Job>().Where(t => t.Id == id).FirstOrDefaultAsync();

        public async Task<bool> DeleteJobAsync(Job todo) => (await _database.DeleteAsync(todo)) > 0;

        public async Task<bool> SaveJobAsync(Job todo)
        {
            if (todo.Id != 0)
                return (await _database.UpdateAsync(todo)) > 0;

            else
                return (await _database.InsertAsync(todo)) > 0;

        }
    }
}
