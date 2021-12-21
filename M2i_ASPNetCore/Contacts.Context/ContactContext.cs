using Contacts.Classes;
using Microsoft.EntityFrameworkCore;
using System;

namespace Contacts.Context
{
    public class ContactContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=M2i_Contacts;");
        }

        private static ContactContext instance;

        public static ContactContext Instance { 
            get 
            { 
                if (instance == null) instance = new ContactContext();
                return instance; 
            } 
            
            set { instance = value; } }

        public DbSet<Contact> Contacts { get; set; }
    }
}
