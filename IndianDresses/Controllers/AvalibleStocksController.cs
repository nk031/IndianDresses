using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndianDresses.Data;
using IndianDresses.Models;
using Microsoft.AspNetCore.Authorization;

namespace IndianDresses.Controllers
{
    public class AvalibleStocksController : Controller
    {
        private readonly IndianDressesContext _context;

        public AvalibleStocksController(IndianDressesContext context)
        {
            _context = context;
        }

        // GET: AvalibleStocks
        public async Task<IActionResult> Index()
        {
            return View(await _context.AvalibleStock.ToListAsync());
        }

        // GET: AvalibleStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalibleStock = await _context.AvalibleStock
                .FirstOrDefaultAsync(m => m.StockID == id);
            if (avalibleStock == null)
            {
                return NotFound();
            }

            return View(avalibleStock);
        }
        [Authorize]
        // GET: AvalibleStocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AvalibleStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockID,Category,Price,AvalibleSize")] AvalibleStock avalibleStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avalibleStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avalibleStock);
        }
        [Authorize]
        // GET: AvalibleStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalibleStock = await _context.AvalibleStock.FindAsync(id);
            if (avalibleStock == null)
            {
                return NotFound();
            }
            return View(avalibleStock);
        }

        // POST: AvalibleStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockID,Category,Price,AvalibleSize")] AvalibleStock avalibleStock)
        {
            if (id != avalibleStock.StockID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avalibleStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvalibleStockExists(avalibleStock.StockID))
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
            return View(avalibleStock);
        }
        [Authorize]
        // GET: AvalibleStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalibleStock = await _context.AvalibleStock
                .FirstOrDefaultAsync(m => m.StockID == id);
            if (avalibleStock == null)
            {
                return NotFound();
            }

            return View(avalibleStock);
        }
        [Authorize]
        // POST: AvalibleStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avalibleStock = await _context.AvalibleStock.FindAsync(id);
            _context.AvalibleStock.Remove(avalibleStock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvalibleStockExists(int id)
        {
            return _context.AvalibleStock.Any(e => e.StockID == id);
        }
    }
}
