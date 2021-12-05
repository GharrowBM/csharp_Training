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
    public class CoachSeedConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            // Il est possible de mettre ici des Data Annotations pour rendre le DbContext plus propre

            builder.Property(m => m.Name).HasMaxLength(50);
            builder.HasIndex(m => new { m.Name, m.TeamId }).IsUnique();

            builder.HasData(new Team()
                {
                    Id = 20,
                    Name = "Columbus Bears",
                    LeagueId = 22

                },
                new Team
                {
                    Id = 21,
                    Name = "Doggo's Fangs",
                    LeagueId = 21
                });


        }
    }
}
