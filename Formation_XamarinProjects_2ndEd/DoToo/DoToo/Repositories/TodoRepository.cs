using DoToo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoToo.Repositories
{
    internal class TodoRepository : IRepository<TodoItem>
    {
        public event EventHandler<TodoItem> OnEntityAdded;
        public event EventHandler<TodoItem> OnEntityUpdated;
        public event EventHandler<TodoItem> OnEntityDeleted;

        public Task<TodoItem> Add(TodoItem entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TodoItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> Update(TodoItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
