using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MagicWebStore.Models;

namespace MagicWebStore.Models
{
    public class MagicWebStoreContext : DbContext
    {
        public MagicWebStoreContext (DbContextOptions<MagicWebStoreContext> options)
            : base(options)
        { }

        public DbSet<MagicWebStore.Models.Product> Product { get; set; }

        public DbSet<MagicWebStore.Models.OwnerInventory> OwnerInventory { get; set; }

        public DbSet<MagicWebStore.Models.Store> Store { get; set; }

        public DbSet<MagicWebStore.Models.StockRequest> StockRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreInventory>().HasKey(x => new { x.StoreID, x.ProductID });
        }

        public DbSet<MagicWebStore.Models.StoreInventory> StoreInventory { get; set; }
    }
}
