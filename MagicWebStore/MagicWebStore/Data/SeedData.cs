using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MagicWebStore.Models;

namespace MagicWebStore.Data
{
    public static class SeedData
    {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new MagicWebStoreContext(
                    serviceProvider.GetRequiredService<DbContextOptions<MagicWebStoreContext>>()))
                {
                    // Look for any products.
                    if (context.Product.Any())
                    {
                        return; // DB has been seeded.
                    }

                    var products = new[]
                    {
                    new Product
                    {
                        Name = "Rabbit",
                        Price = 10.0M
                    },
                    new Product
                    {
                        Name = "Hat",
                        Price = 30.0M
                    },
                    new Product
                    {
                        Name = "Svengali Deck",
                        Price = 25.0M
                    },
                    new Product
                    {
                        Name = "Floating Hankerchief",
                        Price = 12.0M
                    },
                    new Product
                    {
                        Name = "Wand",
                        Price = 58.0M
                    },
                    new Product
                    {
                        Name = "Broomstick",
                        Price = 68.0M
                    },
                    new Product
                    {
                        Name = "Bang Gun",
                        Price = 48.0M
                    },
                    new Product
                    {
                        Name = "Cloak of Invisibility",
                        Price = 320.0M
                    },
                    new Product
                    {
                        Name = "Elder Wand",
                        Price = 118.0M
                    },
                    new Product
                    {
                        Name = "Resurrection Stone",
                        Price = 666.0M
                    }
                };

                    context.Product.AddRange(products);

                    var i = 0;
                    context.OwnerInventory.AddRange(
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 20
                        },
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 50
                        },
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 100
                        },
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 150
                        },
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 40
                        },
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 10
                        },
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 5
                        },
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 0
                        },
                        new OwnerInventory
                        {
                            Product = products[i++],
                            StockLevel = 0
                        },
                        new OwnerInventory
                        {
                            Product = products[i],
                            StockLevel = 0
                        }
                    );

                    i = 0;
                    var stores = new[]
                    {
                    new Store
                    {
                        Name = "Melbourne CBD",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 15
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 10
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 1
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 1
                            },
                            new StoreInventory
                            {
                                Product = products[i],
                                StockLevel = 1
                            },
                        }
                    },
                    new Store
                    {
                        Name = "North Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[0],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "East Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[1],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "South Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[2],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "West Melbourne"
                    }
                };

                    context.Store.AddRange(stores);

                    context.SaveChanges();
                }
            }
        }
}
