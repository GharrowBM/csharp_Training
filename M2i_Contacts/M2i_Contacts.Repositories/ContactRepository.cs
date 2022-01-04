using System.Linq.Expressions;
using M2i_Contacts.Classes;
using M2i_Contacts.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace M2i_Contacts.Repositories;

public class ContactRepository : BaseRepository, IRepository<Contact>
{
    public ContactRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public Contact Get(int id)
    {
        return _dataContext.Contacts.Include(c => c.Avatar).FirstOrDefault(c => c.Id == id);
    }

    public List<Contact> GetAll()
    {
        return _dataContext.Contacts.Include(c => c.Avatar).ToList();
    }

    public Contact Search(Expression<Func<Contact, bool>> searchMethod)
    {
        return _dataContext.Contacts.Include(c => c.Avatar).FirstOrDefault(searchMethod);
    }

    public List<Contact> SearchAll(Expression<Func<Contact, bool>> searchMethod)
    {
        return _dataContext.Contacts.Include(c => c.Avatar).Where(searchMethod).ToList();
    }

    public bool Add(Contact entity)
    {
        
        
        _dataContext.Contacts.Add(entity);
        return _dataContext.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        _dataContext.Contacts.Remove(_dataContext.Contacts.Find(id));
        return _dataContext.SaveChanges() > 0;
    }

    public bool Update(int id, Contact entity)
    {
        Contact c = Get(id);

        if (c != null)
        {
            c.Avatar = entity.Avatar;
            c.Email = entity.Email;
            c.Firstname = entity.Firstname;
            c.Lastname = entity.Lastname;

            _dataContext.Contacts.Update(c);
        }

        return _dataContext.SaveChanges() > 0;
    }
}