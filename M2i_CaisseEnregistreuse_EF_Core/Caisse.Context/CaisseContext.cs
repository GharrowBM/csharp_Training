using Caisse.Classes;
using Microsoft.EntityFrameworkCore;

namespace Caisse.Context
{
    public class CaisseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SecretConnection.ConnectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}