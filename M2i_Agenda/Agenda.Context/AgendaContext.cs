using Agenda.Classes;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Context
{
    public class AgendaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=M2i_Agenda_EFCore;");
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}