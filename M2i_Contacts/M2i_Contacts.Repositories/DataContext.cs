using M2i_Contacts.Classes;
using Microsoft.EntityFrameworkCore;

namespace M2i_Contacts.Repositories;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=M2i_API_Contacts;");
    }
    
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Avatar> Avatars { get; set; }
}