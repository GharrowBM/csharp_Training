using System.Linq.Expressions;

namespace M2i_TodoList.Repositories;

public interface IRepository<T> where T : class
{
    public List<T> GetAll();
    public T Get(int id);
    public T Search(Expression<Func<T, bool>> method);
    public bool Add(T entity);
    public bool Remove(int id);
    public bool Update(int id, T entity);
}