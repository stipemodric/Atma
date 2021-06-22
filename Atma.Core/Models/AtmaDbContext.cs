using Atma.Core.Entities;
using Atma.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atma.Core.Models
{
    public class AtmaDbContext : DbContext, IAtmaDbContext
    {
        public AtmaDbContext(DbContextOptions<AtmaDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<TEntity> ModelSet<TEntity>() where TEntity : class, new()
        {
            return Set<TEntity>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await base.SaveChangesAsync();
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SalesConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
