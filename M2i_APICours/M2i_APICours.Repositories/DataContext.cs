using M2i_APICours.Classes;
using Microsoft.EntityFrameworkCore;

namespace M2i_APICours.Repositories;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=M2i_APICours;");
    }
    
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Offer> Offers { get; set; }
}