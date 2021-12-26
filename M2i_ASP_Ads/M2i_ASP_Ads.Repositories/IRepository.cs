using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace M2i_ASP_Ads.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        List<T> Search(Expression<Func<T, bool>> expression);
        T SerchOne(Expression<Func<T, bool>> expression);
        bool Save(T entity);
    }
}
