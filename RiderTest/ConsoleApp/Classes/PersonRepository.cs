using ConsoleApp.Interfaces;

namespace ConsoleApp.Classes;

public class PersonRepository : BaseRepository, IRepository<Person>
{
    public PersonRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public Person Get(int id)
    {
        return _dataContext.Persons.FirstOrDefault(p => p.Id == id);
    }

    public List<Person> GetAll()
    {
        return _dataContext.Persons.ToList();
    }

    public List<Person> Search(Func<Person, bool> predicate)
    {
        return _dataContext.Persons.Where(p => predicate(p)).ToList();
    }

    public bool Save(Person entity)
    {
        _dataContext.Persons.Add(entity);
        return _dataContext.SaveChanges() > 0;
    }
}