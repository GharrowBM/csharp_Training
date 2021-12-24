using M2iASP_Ads.Classes;
using System.Linq.Expressions;

namespace M2i_ASP_Ads.Repositories;

public class UserRepository : BaseRepository, IRepository<User>
{
    public UserRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public User Get(int id)
    {
        return _dataContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> GetAll()
    {
        return _dataContext.Users.ToList();
    }

    public List<User> Search(Expression<Func<User, bool>> expression)
    {
        return _dataContext.Users.Where(expression).ToList();
    }

    public bool Save(User entity)
    {
        _dataContext.Users.Add(entity);
        return _dataContext.SaveChanges() > 0;

    }
}