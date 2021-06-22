using Atma.Core.Entities;
using Atma.DataAccess.Repositories;
using Atma.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atma.DataAccess
{
    public interface ISalesRepository : IAuxiliaryRepository<SalesAddViewModel, SalesGetViewModel, SalesUpdateViewModel>
    {
        Task<ICollection<SalesGetViewModel>> GetSoldArticles();
        Task<ICollection<SalesGetViewModel>> GetRevenue();
        Task<ICollection<SalesGetViewModel>> GetStats();
    }
}
