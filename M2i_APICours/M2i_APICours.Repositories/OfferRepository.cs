using M2i_APICours.Classes;
using M2i_APICours.Repositories.Interfaces;

namespace M2i_APICours.Repositories;

public class OfferRepository : BaseRepository, IRepository<Offer>
{
    public OfferRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public List<Offer> GetAll()
    {
        return _dataContext.Offers.ToList();
    }

    public Offer GetById(int id)
    {
        return _dataContext.Offers.FirstOrDefault(o => o.Id == id);
    }

    public bool Add(Offer entity)
    {
        _dataContext.Offers.Add(entity);
        return _dataContext.SaveChanges() > 0;
    }

    public bool Remove(int id)
    {
        _dataContext.Offers.Remove(_dataContext.Offers.Find(id));
        return _dataContext.SaveChanges() > 0;
    }

    public bool Update(int id, Offer entity)
    {
        Offer o = _dataContext.Offers.Find(id);

        if (o != null)
        {
            o.Title = entity.Title;
            o.Description = entity.Description;
            o.Price = entity.Price;

            _dataContext.Offers.Update(o);
        }

        return _dataContext.SaveChanges() > 0;
    }
}