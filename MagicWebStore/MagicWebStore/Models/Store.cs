using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicWebStore.Models
{
    public class Store
    {
        [Key, Display(Name = "StoreID")]
        public int StoreID { get; set; }
        public string Name { get; set; }

        //public ICollection<StoreInventory> StoreInventory { get; } = new List<StoreInventory>();
    }
}
