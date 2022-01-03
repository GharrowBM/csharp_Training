using M2i_APICours.Classes;
using M2i_APICours.Repositories.Interfaces;

namespace M2i_APICours.Repositories;

public class ContactRepository : BaseRepository, IRepository<Contact>
{
    public ContactRepository(DataContext dataContext) : base(dataContext)
    {
    }
    
    public List<Contact> GetAll()
    {
        return _dataContext.Contacts.ToList();
    }

    public Contact GetById(int id)
    {
        return _dataContext.Contacts.FirstOrDefault(c => c.Id == id);
    }

    public bool Add(Contact entity)
    {
        _dataContext.Contacts.Add(entity);
        return _dataContext.SaveChanges() > 0;
    }

    public bool Remove(int id)
    {
        _dataContext.Contacts.Remove(_dataContext.Contacts.Find(id));
        return _dataContext.SaveChanges() > 0;
    }

    public bool Update(int id, Contact entity)
    {
        Contact c = _dataContext.Contacts.Find(id);

        if (c != null)
        {
            c.Firstname = entity.Firstname;
            c.Lastname = entity.Lastname;
            c.PhoneNumber = entity.PhoneNumber;
            c.Email = entity.Email;

            _dataContext.Update(c);
        }
        
        return _dataContext.SaveChanges() > 0;
    }
}