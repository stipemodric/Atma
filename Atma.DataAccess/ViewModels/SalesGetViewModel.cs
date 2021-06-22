using Atma.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atma.DataAccess.ViewModels
{
    public class SalesGetViewModel : IGetViewModel<Sales>
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime Date { get; set; }
        public int NumberSold { get; set; }

        public decimal? Revenue { get; set; }

        #region SystemProperties
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
        public SalesGetViewModel()
        {

        }

        public void GetViewModel(Sales entity)
        {
            Id = entity.Id;
            ArticleNumber = entity.ArticleNumber;
            SalesPrice = entity.SalesPrice;
            Date = entity.Date;
            NumberSold = entity.NumberSold;
            Revenue = entity.Revenue;
            CreateDate = entity.CreateDate;
            IsDeleted = entity.IsDeleted;
        }
    }
}
