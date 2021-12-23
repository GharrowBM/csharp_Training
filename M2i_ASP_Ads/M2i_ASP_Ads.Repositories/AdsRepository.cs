using M2iASP_Ads.Classes;
using Microsoft.EntityFrameworkCore;

namespace M2i_ASP_Ads.Repositories;

public class AdsRepository : BaseRepository, IRepository<Offer>
{
    public AdsRepository(DataContext dataContext) : base(dataContext)
    {

    }

    public Offer Get(int id)
    {
        return _dataContext.Offers.Include(o=>o.Images).FirstOrDefault(o=>o.Id == id);
    }

    public List<Offer> GetAll()
    {
        return _dataContext.Offers.Include(o => o.Images).ToList();
    }

    public bool Save(Offer entity)
    {
        _dataContext.Offers.Add(entity);
        return _dataContext.SaveChanges() > 0;
    }

    public List<Offer> Search(Func<Offer, bool> predicate)
    {
        return _dataContext.Offers.Include(o => o.Images).Where(o => predicate(o)).ToList();
    }
}