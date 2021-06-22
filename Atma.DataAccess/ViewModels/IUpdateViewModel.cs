using Atma.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atma.DataAccess.ViewModels
{
    public interface IUpdateViewModel<TEntity> where TEntity: class, IPrimaryKey, new()
    {
        /// <summary>
        /// A method that copies view model contents to the entity
        /// </summary>
        /// <param name="entity">Specified model entity</param>
        void CopyToEntity(TEntity entity);
    }
}
