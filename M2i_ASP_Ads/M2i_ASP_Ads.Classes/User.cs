namespace M2iASP_Ads.Classes;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public virtual List<Offer> Favorites { get; set; }
}