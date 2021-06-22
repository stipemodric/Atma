using Atma.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atma.DataAccess.ViewModels
{
    public interface IGetViewModel<TEntity> where TEntity: class, IPrimaryKey, new()
    {
        /// <summary>
        /// A method that returns a view model instance from the entity
        /// </summary>
        /// <param name="entity">Specified entity model</param>
        void GetViewModel(TEntity entity);
    }
}
