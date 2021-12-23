namespace ConsoleApp.Classes;

public class Person
{
    private int id;
    private string firstname;
    private string lastname;
    private int age;
    
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

    public int Age
    {
        get => age;
        set => age = value;
    }
}