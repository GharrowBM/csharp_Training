namespace M2i_TodoList.Classes;

public class Todo
{
    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Title
    {
        get => title;
        set => title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Description
    {
        get => description;
        set => description = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime AddedAt
    {
        get => addedAt;
        set => addedAt = value;
    }

    private int id;
    private string title;
    private string description;
    private DateTime addedAt;

    public Todo()
    {
        
    }
}