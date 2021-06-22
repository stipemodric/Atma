using Atma.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atma.DataAccess.ViewModels
{
    public interface IAddViewModel<TEntity> where TEntity: class, IPrimaryKey, new()
    {
        /// <summary>
        /// A method that converts AddViewModel to entity
        /// </summary>
        /// <returns>TEntity instance</returns>
        TEntity ToEntity();
    }
}
