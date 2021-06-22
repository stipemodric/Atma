using Atma.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atma.Core.Entities
{
    public class Sales: IPrimaryKey, ISoftDelete, ICreateDate
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string ArticleNumber { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime Date { get; set; }
        public int NumberSold { get; set; }

        public decimal? Revenue { get; set; }
        #region System properties
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        #endregion
    }
}
