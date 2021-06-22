using Atma.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Atma.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Atma.DataAccess.ViewModels;

namespace Atma.DataAccess
{
    public abstract class AuxiliaryRepository<TAddViewModel, TGetViewModel, TUpdateViewModel,
        TEntity> : IAuxiliaryRepository<TAddViewModel, TGetViewModel, TUpdateViewModel>
        where TEntity : class, IPrimaryKey, ISoftDelete, ICreateDate, new()
        where TAddViewModel: IAddViewModel<TEntity>
        where TGetViewModel: IGetViewModel<TEntity>
        where TUpdateViewModel: IUpdateViewModel<TEntity>
    {
        protected IAtmaDbContext DbContext { get; }
        public AuxiliaryRepository()
        {

        }
        public AuxiliaryRepository(IAtmaDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Method that returns a DbSet of template entity
        /// </summary>
        /// <returns>Returns IQueryable of TEntity</returns>
        protected virtual IQueryable<TEntity> Fetch()
        {
            try
            {
                return DbContext.ModelSet<TEntity>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> SoftDelete(int id)
        {
            try
            {
                var entity = Fetch().SingleOrDefault(x => x.Id == id);

                if (entity == null)
                {
                    throw new NullReferenceException($"Entity {entity.GetType()} with id {id} doesn't exist in database!");
                }

                entity.IsDeleted = true;
                DbContext.ModelSet<TEntity>().Update(entity);
                return await DbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public virtual async Task<int> Add(TAddViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("ViewModel");

            try
            {
                var entity = viewModel.ToEntity();
                
                entity.CreateDate = DateTime.Now;

                DbContext.ModelSet<TEntity>().Add(entity);

                var result = await DbContext.SaveChangesAsync();

                return entity.Id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<int> Update(int id, TUpdateViewModel viewModel)
        {
            try
            {
                var entity = await DbContext.ModelSet<TEntity>()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                    throw new ArgumentNullException("Entity");

                viewModel.CopyToEntity(entity);

                DbContext.ModelSet<TEntity>().Update(entity);
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
