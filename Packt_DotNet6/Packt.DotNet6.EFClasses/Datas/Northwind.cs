using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.DotNet6.EFClasses.Datas
{
    public class Northwind : DbContext
    {
        // Ces propriétés servent à mapper les tables dans la BdD
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Exemple de l'utilisation de l'API Fluent d'EF Core à la place des annotations des propriétés dans les classes
            // Pour limiter la longueur d'un nom de catégorie à 15
            modelBuilder.Entity<Category>()
              .Property(category => category.CategoryName)
              .IsRequired() // NOT NULL
              .HasMaxLength(15);

            // Filtre global pour retirer les produits abandonnés
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);

            // EF Core 3.0 ne supportait la valeur de type decimal lors de l'utilisation de SQLite. On le convertissait donc en double
            if (ProjectConstants.DatabaseProvider == "SQLite")
            {
                // Addition du support pour combler le manque du type Decimal dans SQLite
                modelBuilder.Entity<Product>()
                  .Property(product => product.Cost)
                  .HasConversion<double>();
            }
        }
    }
}
