﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagicWebStore.Models;

namespace MagicWebStore.Controllers
{
    public class OwnerInventoriesController : Controller
    {
        private readonly MagicWebStoreContext _context;

        public OwnerInventoriesController(MagicWebStoreContext context)
        {
            _context = context;
        }

        // GET: OwnerInventories
        //public async Task<IActionResult> Index()
        //{
        //    var magicWebStoreContext = _context.OwnerInventory.Include(o => o.Product);
        //    return View(await magicWebStoreContext.ToListAsync());
        //}

            //Code from WEEK 7 TUTORIAL
            //[http://localhost:55434/?productName=banggun]
        // Auto-parsed variables coming in from the request - there is a form on the page to send this data.
        public async Task<IActionResult> Index(string productName)
        {
            // Eager loading the Product table - join between OwnerInventory and the Product table.
            var query = _context.OwnerInventory.Include(x => x.Product).Select(x => x);

            if (!string.IsNullOrWhiteSpace(productName))
            {
                // Adding a where to the query to filter the data.
                // Note for the first request productName is null thus the where is not always added.
                query = query.Where(x => x.Product.Name.Contains(productName));

                // Storing the search into ViewBag to populate the textbox with the same value for convenience.
                ViewBag.ProductName = productName;
            }

            // Adding an order by to the query for the Product name.
            query = query.OrderBy(x => x.Product.Name);

            // Passing a List<OwnerInventory> model object to the View.
            return View(await query.ToListAsync());
        }

        // GET: OwnerInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerInventory = await _context.OwnerInventory
                .Include(o => o.Product)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (ownerInventory == null)
            {
                return NotFound();
            }

            return View(ownerInventory);
        }

        // GET: OwnerInventories/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            return View();
        }

        // POST: OwnerInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,StockLevel")] OwnerInventory ownerInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", ownerInventory.ProductID);
            return View(ownerInventory);
        }

        // GET: OwnerInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerInventory = await _context.OwnerInventory.SingleOrDefaultAsync(m => m.ProductID == id);
            if (ownerInventory == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", ownerInventory.ProductID);
            return View(ownerInventory);
        }

        // POST: OwnerInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,StockLevel")] OwnerInventory ownerInventory)
        {
            if (id != ownerInventory.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerInventoryExists(ownerInventory.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", ownerInventory.ProductID);
            return View(ownerInventory);
        }

        // GET: OwnerInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerInventory = await _context.OwnerInventory
                .Include(o => o.Product)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (ownerInventory == null)
            {
                return NotFound();
            }

            return View(ownerInventory);
        }

        // POST: OwnerInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownerInventory = await _context.OwnerInventory.SingleOrDefaultAsync(m => m.ProductID == id);
            _context.OwnerInventory.Remove(ownerInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerInventoryExists(int id)
        {
            return _context.OwnerInventory.Any(e => e.ProductID == id);
        }
    }
}
