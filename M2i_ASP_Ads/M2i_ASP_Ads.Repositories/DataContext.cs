using M2iASP_Ads.Classes;
using Microsoft.EntityFrameworkCore;

namespace M2i_ASP_Ads.Repositories;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=M2i_ASP_Ads;");
    }
    
    public DbSet<Offer> Offers { get; set; } 
    public DbSet<User> Users { get; set; }


}