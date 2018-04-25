using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagicWebStore.Models
{
    public class StockRequest
    {
        public int StockRequestID { get; set; }

        [Key, ForeignKey("Store"), Display(Name = "StoreID")]
        public int StoreID { get; set; }
        public Store Store { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
