namespace M2i_TodoList.Repositories;

public class BaseRepository
{
    protected DataContext _dataContext;

    public BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
}