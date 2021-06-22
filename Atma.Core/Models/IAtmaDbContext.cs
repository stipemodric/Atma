using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atma.DataAccess
{
    public interface IAtmaDbContext 
    {
        public DbSet<TEntity> ModelSet<TEntity>() where TEntity : class, new();

        Task<int> SaveChangesAsync();

        void SaveChanges();

    }
}
