namespace M2i_APICours.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    public List<T> GetAll();
    public T GetById(int id);
    public bool Add(T entity);
    public bool Remove(int id);
    public bool Update(int id, T entity);
}