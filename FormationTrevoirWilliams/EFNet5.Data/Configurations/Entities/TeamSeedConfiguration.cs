using EFNet5.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNet5.Data.Configurations.Entities
{
    internal class TeamSeedConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(50);
            builder.HasIndex(m => m.Name).IsUnique();

            builder.HasData(new Team()
             {
                 Id = 20,
                 Name = "Columbus Bears",
                 LeagueId = 21

             },
                new Team
                {
                    Id = 21,
                    Name = "Doggo's Fangs",
                    LeagueId= 21
                    
                });

        }
    }
}
