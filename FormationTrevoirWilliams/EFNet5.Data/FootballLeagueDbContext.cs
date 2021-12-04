using EFNet5.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNet5.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SecretConnection.String)
                .LogTo(Console.WriteLine, new [] {DbLoggerCategory.Database.Command.Name}, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Définition des règles pour le Many-to-Many car on utilise une autre convention de nommage que celle prévue par EF Core
            // HomeTeam et AwayTeam

            modelBuilder.Entity<Team>()
                .HasMany(m => m.HomeMatches)
                .WithOne(m => m.HomeTeam)
                .HasForeignKey(m => m.HomeTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasMany(m => m.AwayMatches)
                .WithOne(m => m.AwayTeam)
                .HasForeignKey(m => m.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Dans le cas où il n'y a pas de Clé Primaire, comme pour cette vue, il faut spécifier cela dans le modelBuilder (en plus de spécifier le lien avec le nom de la vue en BdD)
            modelBuilder.Entity<TeamsCoachesLeaguesView>()
                .HasNoKey()
                .ToView("TeamsCoachesLeagues");
        }

        public DbSet<Team> Teams { get; set; }

        // One to Many Relationship 
        public DbSet<League> Leagues { get; set; }
        // Many to Many RelationShips
        public DbSet<Match> Matches { get; set; }
        // One to One Relationship
        public DbSet<Coach> Coaches { get; set; }

        public DbSet<TeamsCoachesLeaguesView> TeamsCoachesLeagues { get; set; }

    }
}
