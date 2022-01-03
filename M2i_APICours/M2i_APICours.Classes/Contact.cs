namespace M2i_APICours.Classes;

public class Contact
{
    private int id;
    private string firstname;
    private string lastname;
    private string email;
    private string phoneNumber;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Firstname
    {
        get => firstname;
        set => firstname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Lastname
    {
        get => lastname;
        set => lastname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Email
    {
        get => email;
        set => email = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string PhoneNumber
    {
        get => phoneNumber;
        set => phoneNumber = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public Contact()
    {
        
    }
}