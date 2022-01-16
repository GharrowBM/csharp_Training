using DoToo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace DoToo.Repositories
{
    internal class TodoRepository : IRepository<TodoItem>
    {
        private SQLiteAsyncConnection _connection;

        public event EventHandler<TodoItem> OnEntityAdded;
        public event EventHandler<TodoItem> OnEntityUpdated;
        public event EventHandler<TodoItem> OnEntityDeleted;

        private async Task CreateConnection()
        {
            if (_connection != null)
            {
                return;
            }

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "TodoItem.db");

            _connection = new SQLiteAsyncConnection(databasePath);
            await _connection.CreateTableAsync<TodoItem>();

            if (await _connection.Table<TodoItem>().CountAsync() == 0)
            {
                await _connection.InsertAsync(new TodoItem()
                {
                    Title = "Welcome to DoToo",
                    Due = DateTime.Now
                });
            }
        }

        public async Task Add(TodoItem entity)
        {
            await CreateConnection();
            await _connection.InsertAsync(entity);
            OnEntityAdded?.Invoke(this, entity);
        }

        public async Task Delete(TodoItem entity)
        {
            await CreateConnection();
            await _connection.DeleteAsync(entity);
            OnEntityDeleted?.Invoke(this, entity);
        }

        public async Task<List<TodoItem>> GetAll()
        {
            await CreateConnection();
            return await _connection.Table<TodoItem>().ToListAsync();
        }

        public async Task Update(TodoItem entity)
        {
            await CreateConnection();
            await _connection.UpdateAsync(entity);
            OnEntityUpdated?.Invoke(this, entity);
        }

        public async Task UpdateOrAdd(TodoItem entity)
        {
            if (entity.Id == 0)
            {
                await Add(entity);
            }
            else
            {
                await Update(entity);
            }
        }
    }
}
