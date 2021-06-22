using Atma.Core.Entities;
using Atma.Core.Models;
using Atma.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atma.DataAccess
{
    public class SalesRepository : AuxiliaryRepository<SalesAddViewModel, SalesGetViewModel, SalesUpdateViewModel,
        Sales>, ISalesRepository
    {
        public SalesRepository(IAtmaDbContext dbContext) : base(dbContext)
        {
        }

        // total revenue per day
        public async Task<ICollection<SalesGetViewModel>> GetRevenue()
        {
            try
            {
                return await
                    (from items in Fetch() group items by new { 
                        items.Id,
                        items.Date, 
                        items.ArticleNumber, 
                        items.NumberSold,
                        items.SalesPrice,
                        items.Revenue} into g
                     select new SalesGetViewModel
                     {
                         Id = g.Key.Id,
                         ArticleNumber = g.Key.ArticleNumber,
                         NumberSold = g.Key.NumberSold,
                         Date = g.Key.Date,
                         SalesPrice = g.Key.SalesPrice,
                         Revenue = g.Key.Revenue
                     }).ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // number of sold articles per day
        public async Task<ICollection<SalesGetViewModel>> GetSoldArticles()
        {
            try
            {
                var items = Fetch();

                //var sumOfAllItemsSold = items.Sum(x => x.NumberSold);

                //var numberOfItems = items.Count();

                return await (from item in items
                              group item by new { item.Date, item.NumberSold } into g
                              select new SalesGetViewModel
                              {
                                  NumberSold = g.Key.NumberSold,
                                  Date = g.Key.Date
                              }).ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // revenue grouped by articles
        public async Task<ICollection<SalesGetViewModel>> GetStats()
        {
            try
            {
                //return await
                //    (from items in Fetch()
                //     group items.SalesPrice * items.NumberSold by items.ArticleNumber into g
                //     select new { ArticleNumber = g.Key, Revenue = g.ToList() }).Select(x => (Sales)x);

                return await (from item in Fetch() group item by new
                {
                    item.ArticleNumber,
                    item.Revenue
                } 
                into g
                select new SalesGetViewModel
                {
                    ArticleNumber = g.Key.ArticleNumber,
                    Revenue = g.Key.Revenue
                }).ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return null;
            }

        public async override Task<int> SoftDelete(int id)
        {
            return await base.SoftDelete(id);
        }

        public async override Task<int> Add(SalesAddViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("ViewModel");

            try
            {
                var entity = viewModel.ToEntity();

                entity.CreateDate = DateTime.Now;

                entity.Revenue = entity.NumberSold * entity.SalesPrice;

                DbContext.ModelSet<Sales>().Add(entity);

                var result = await DbContext.SaveChangesAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
