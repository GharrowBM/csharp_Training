namespace M2i_Contacts.Classes;

public class Avatar
{
    public int Id
    {
        get => id;
        set => id = value;
    }

    public string FilePath
    {
        get => filePath;
        set => filePath = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Contact Contact
    {
        get => contact;
        set => contact = value ?? throw new ArgumentNullException(nameof(value));
    }

    private int id;
    private string filePath;
    private Contact contact;
}