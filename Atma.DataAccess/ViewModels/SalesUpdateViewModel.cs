using Atma.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atma.DataAccess.ViewModels
{
    public class SalesUpdateViewModel : IUpdateViewModel<Sales>
    {
        public string ArticleNumber { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime Date { get; set; }
        public int NumberSold { get; set; }

        public decimal? Revenue { get; set; }

        public void CopyToEntity(Sales entity)
        {
            entity.ArticleNumber = ArticleNumber;
            entity.SalesPrice = SalesPrice;
            entity.Date = Date;
            entity.NumberSold = NumberSold;
            entity.Revenue = Revenue;
        }
    }
}
