using EFNet5.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNet5.Data
{
    public abstract class AuditableFootballLEagueDbContext : DbContext
    {
        // Dans le but d'obtenir des informations sur qui et quand les modification / additions sont faites,
        // il faut créer la méthode nous servant à sauvegarder pour modifier à la volée les infos en se basant sur la méthode de DbContext

        public async Task<int> SaveChangesAsync(string username)
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var auditableObject = (BaseDomainObject)entry.Entity;
                auditableObject.ModifiedDate = DateTime.Now;
                auditableObject.ModifiedBy = username;
                if (entry.State == EntityState.Added)
                {
                    auditableObject.CreatedDate = DateTime.Now;
                    auditableObject.CreatedBy = username;
                }

            }

            return await base.SaveChangesAsync();
        }
    }
}
