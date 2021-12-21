using Banque.Classes;
using Microsoft.EntityFrameworkCore;
using System;

namespace Banque.Context
{
    public class BankContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=M2i_ASPBank;");
        }

        private static BankContext instance;

        public static BankContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new BankContext();
                return instance;
            }
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}
