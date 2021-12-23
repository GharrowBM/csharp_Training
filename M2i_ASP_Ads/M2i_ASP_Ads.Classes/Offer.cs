namespace M2iASP_Ads.Classes;

public class Offer
{
    private int id;
    private string title;
    private decimal price;
    private string description;
    private List<AdImage> images;

    public int Id { get => id; set => id = value; }
    public string Title { get => title; set => title = value; }
    public decimal Price { get => price; set => price = value; }
    public string Description { get => description; set => description = value; }
    public virtual List<AdImage> Images { get => images; set => images = value; }

    public Offer()
    {
        Images = new List<AdImage>();
    }
}