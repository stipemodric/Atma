using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atma.DataAccess.Repositories
{        
    public interface IAuxiliaryRepository<IAddViewModel, IGetViewModel, IUpdateViewModel>
    {
        Task<int> Add(IAddViewModel viewModel);
        Task<int> Update(int id, IUpdateViewModel viewModel);
        Task<int> SoftDelete(int id);

    }
}
