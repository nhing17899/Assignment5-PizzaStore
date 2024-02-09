using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreDatabase.Data;
using StoreDatabase.Entities;

namespace Assignment5_PizzaStore.Controllers
{
    public class OrderLineItemsController : Controller
    {
        private readonly StoreContext _context;

        public OrderLineItemsController(StoreContext context)
        {
            _context = context;
        }

        // GET: OrderLineItems
        public async Task<IActionResult> Index()
        {
              return _context.OrderLineItems != null ? 
                          View(await _context.OrderLineItems.ToListAsync()) :
                          Problem("Entity set 'StoreContext.OrderLineItems'  is null.");
        }

        // GET: OrderLineItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderLineItems == null)
            {
                return NotFound();
            }

            var orderLineItem = await _context.OrderLineItems
                .FirstOrDefaultAsync(m => m.OrderLineItemId == id);
            if (orderLineItem == null)
            {
                return NotFound();
            }

            return View(orderLineItem);
        }

        // GET: OrderLineItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderLineItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderLineItemId,OrderId,ProductId,Quantity,Price")] OrderLineItem orderLineItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderLineItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderLineItem);
        }

        // GET: OrderLineItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderLineItems == null)
            {
                return NotFound();
            }

            var orderLineItem = await _context.OrderLineItems.FindAsync(id);
            if (orderLineItem == null)
            {
                return NotFound();
            }
            return View(orderLineItem);
        }

        // POST: OrderLineItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderLineItemId,OrderId,ProductId,Quantity,Price")] OrderLineItem orderLineItem)
        {
            if (id != orderLineItem.OrderLineItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderLineItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderLineItemExists(orderLineItem.OrderLineItemId))
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
            return View(orderLineItem);
        }

        // GET: OrderLineItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderLineItems == null)
            {
                return NotFound();
            }

            var orderLineItem = await _context.OrderLineItems
                .FirstOrDefaultAsync(m => m.OrderLineItemId == id);
            if (orderLineItem == null)
            {
                return NotFound();
            }

            return View(orderLineItem);
        }

        // POST: OrderLineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderLineItems == null)
            {
                return Problem("Entity set 'StoreContext.OrderLineItems'  is null.");
            }
            var orderLineItem = await _context.OrderLineItems.FindAsync(id);
            if (orderLineItem != null)
            {
                _context.OrderLineItems.Remove(orderLineItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderLineItemExists(int id)
        {
          return (_context.OrderLineItems?.Any(e => e.OrderLineItemId == id)).GetValueOrDefault();
        }
    }
}
