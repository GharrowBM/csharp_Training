namespace M2i_APICours.Classes;

public class Offer
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

    public decimal Price
    {
        get => price;
        set => price = value;
    }

    private int id;
    private string title;
    private string description;
    private decimal price;

    public Offer()
    {
        
    }
}