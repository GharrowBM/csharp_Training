using M2i_TodoList.Classes;
using Microsoft.EntityFrameworkCore;

namespace M2i_TodoList.Repositories;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=M2i_TodoAPI;");
    }

    public DbSet<Todo> Todos { get; set; }
}