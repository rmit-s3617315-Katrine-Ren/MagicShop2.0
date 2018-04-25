using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicWebStore.Models
{
    public class StoreInventory
    {

        [Key, ForeignKey("Store"), Display(Name = "Store ID")]
        public int StoreID { get; set; }
        public Store Store { get; set; }

        [Key, ForeignKey("Product"), Display(Name = "Product ID")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Display(Name = "Stock Level")]
        public int StockLevel { get; set; }
    }
}