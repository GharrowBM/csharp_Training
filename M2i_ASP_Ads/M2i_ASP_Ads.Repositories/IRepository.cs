using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2i_ASP_Ads.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        List<T> Search(Func<T, bool> predicate);
        bool Save(T entity);
    }
}
