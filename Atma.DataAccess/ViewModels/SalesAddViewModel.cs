using Atma.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atma.DataAccess.ViewModels
{
    public class SalesAddViewModel : IAddViewModel<Sales>
    {
        public string ArticleNumber { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime Date { get; set; }
        public int NumberSold { get; set; }

        public decimal? Revenue { get; set; }

        #region SystemProperties
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        public Sales ToEntity()
        {
            return new Sales
            {
                ArticleNumber = ArticleNumber,
                SalesPrice = SalesPrice,
                Date = Date,
                NumberSold = NumberSold,
                Revenue = Revenue
            };
        }
    }
}
