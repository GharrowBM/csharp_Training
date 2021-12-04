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

        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }

    }
}
