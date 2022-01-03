using System.Linq.Expressions;
using M2i_TodoList.Classes;

namespace M2i_TodoList.Repositories;

public class TodoRepository : BaseRepository, IRepository<Todo>
{
    public TodoRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public List<Todo> GetAll()
    {
        return _dataContext.Todos.ToList();
    }

    public Todo Get(int id)
    {
        return _dataContext.Todos.FirstOrDefault(t => t.Id == id);
    }

    public Todo Search(Expression<Func<Todo, bool>> method)
    {
        return _dataContext.Todos.FirstOrDefault(method);
    }

    public bool Add(Todo entity)
    {
        _dataContext.Todos.Add(entity);
        return _dataContext.SaveChanges() > 0;
    }

    public bool Remove(int id)
    {
        _dataContext.Todos.Remove(_dataContext.Todos.Find(id));
        return _dataContext.SaveChanges() > 0;
    }

    public bool Update(int id, Todo entity)
    {
        Todo t = Get(id);

        if (t != null)
        {
            t.Title = entity.Title;
            t.Description = entity.Description;
            t.AddedAt = entity.AddedAt;

            _dataContext.Todos.Update(t);
        }

        return _dataContext.SaveChanges() > 0;
    }
}