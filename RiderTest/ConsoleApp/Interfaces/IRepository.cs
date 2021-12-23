namespace ConsoleApp.Interfaces;

public interface IRepository<T> where T : class
{
    public T Get(int id);
    public List<T> GetAll();
    public List<T> Search(Func<T, bool> predicate);
    public bool Save(T entity);
}