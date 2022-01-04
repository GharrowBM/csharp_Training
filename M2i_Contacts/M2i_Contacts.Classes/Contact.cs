using System.ComponentModel.DataAnnotations.Schema;

namespace M2i_Contacts.Classes;

public class Contact
{
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

    public Avatar Avatar
    {
        get => avatar;
        set => avatar = value ?? throw new ArgumentNullException(nameof(value));
    }

    [ForeignKey("AvatarId")]
    public int AvatarId
    {
        get => avatarId;
        set => avatarId = value;
    }

    private int id;
    private string firstname;
    private string lastname;
    private string phone;
    private string email;
    private Avatar avatar;
    private int avatarId;
}