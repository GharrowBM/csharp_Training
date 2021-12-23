using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Classes;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=Test_RiderTest;");
    }
    
    public DbSet<Person> Persons { get; set; }
}