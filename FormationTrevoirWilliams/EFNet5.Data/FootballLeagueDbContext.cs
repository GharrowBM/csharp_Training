using EFNet5.Data.Configurations.Entities;
using EFNet5.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFNet5.Data
{
    public class FootballLeagueDbContext : AuditableFootballLEagueDbContext
    {
        // Sert de base à EF Core pour la gestion de la BdD via les commandes dans la console du Package Manager (Add-Migration, Update-Database, etc... get-help EntityFrameworkCore pour obtenir le "manuel")

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Pour spécifier la connection et l'emplacement de la BdD

            optionsBuilder.UseSqlServer(SecretConnection.String)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();

            #endregion

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Règles dans le cas où l'on ne respecta pas le nommage de base d'EF Core

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

            #endregion

            #region Appliquer des règles spécifiques (par exemple si l'on veut travailler sur une table (ou ici une vue) n'ayant pas de clé primaire

            // Dans le cas où il n'y a pas de Clé Primaire, comme pour cette vue, il faut spécifier cela dans le modelBuilder (en plus de spécifier le lien avec le nom de la vue en BdD)

            modelBuilder.Entity<TeamsCoachesLeaguesView>()
                .HasNoKey()
                .ToView("TeamsCoachesLeagues");

            #endregion

            #region Data Annotations

            // Pour spéficier les valeurs et limiter les données, on peut se servir des méthodes spécifiques ci-dessous avant chaque propriété (ou type anonyme si l'on veut en modifier plusieurs d'un coup)

            //modelBuilder.Entity<Team>().Property(m => m.Name).HasMaxLength(50);
            //modelBuilder.Entity<Team>().HasIndex(m => m.Name).IsUnique();
            //modelBuilder.Entity<Coach>().Property(m => m.Name).HasMaxLength(50);
            //modelBuilder.Entity<Coach>().HasIndex(m => new { m.Name, m.TeamId }).IsUnique();
            //modelBuilder.Entity<League>().Property(m => m.Name).HasMaxLength(50);
            //modelBuilder.Entity<League>().HasIndex(m => m.Name);

            #endregion

            #region Données de base dans la BdD

            //// Dans le cas où l'on veut des données présentes de base à la génération de la BdD, on peut le faire de la sorte
            //// (Attentiion à l'ordre en cas de liens entre les tables, les requêtes SQL ayant lieu dans cet ordre)

            //modelBuilder.Entity<Team>()
            //    .HasData(new Team()
            //    {
            //        Id = 20,
            //        Name = "Columbus Bears",

            //    },
            //    new Team
            //    {
            //        Id = 21,
            //        Name = "Doggo's Fangs"
            //    });

            //modelBuilder.Entity<Coach>()
            //    .HasData(new Coach()
            //    {
            //        Id = 25,
            //        Name = "Coach Griffer",
            //        TeamId = 20,

            //    });

            //// Si l'on a fais au préalable des classes de pré-configuration, on peut également les appeler de la sorte : 

            //modelBuilder.ApplyConfiguration(new LeagueSeedConfiguration());
            //modelBuilder.ApplyConfiguration(new TeamSeedConfiguration());
            //modelBuilder.ApplyConfiguration(new CoachSeedConfiguration());

            #endregion

        }

        #region DbSets

        // On place ici des propriétés de type DbSet dans le but d'avoir les tables dans l'application

        public DbSet<Team> Teams { get; set; }

        // One to Many Relationship 
        public DbSet<League> Leagues { get; set; }
        // Many to Many RelationShips
        public DbSet<Match> Matches { get; set; }
        // One to One Relationship
        public DbSet<Coach> Coaches { get; set; }

        public DbSet<TeamsCoachesLeaguesView> TeamsCoachesLeagues { get; set; }

        #endregion

    }
}
