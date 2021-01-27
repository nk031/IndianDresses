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
    public class OnlineSalesController : Controller
    {
        private readonly IndianDressesContext _context;

        public OnlineSalesController(IndianDressesContext context)
        {
            _context = context;
        }

        // GET: OnlineSales
        public async Task<IActionResult> Index()
        {
            var indianDressesContext = _context.OnlineSale.Include(o => o.Client).Include(o => o.Stock);
            return View(await indianDressesContext.ToListAsync());
        }

        // GET: OnlineSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineSale = await _context.OnlineSale
                .Include(o => o.Client)
                .Include(o => o.Stock)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (onlineSale == null)
            {
                return NotFound();
            }

            return View(onlineSale);
        }
        [Authorize]

        // GET: OnlineSales/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.RegularClient, "ClientID", "ClientName");
            ViewData["StockID"] = new SelectList(_context.AvalibleStock, "StockID", "Category");
            return View();
        }

        // POST: OnlineSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClientID,StockID")] OnlineSale onlineSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onlineSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.RegularClient, "ClientID", "ClientID", onlineSale.ClientID);
            ViewData["StockID"] = new SelectList(_context.AvalibleStock, "StockID", "StockID", onlineSale.StockID);
            return View(onlineSale);
        }
        [Authorize]
        // GET: OnlineSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineSale = await _context.OnlineSale.FindAsync(id);
            if (onlineSale == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.RegularClient, "ClientID", "ClientID", onlineSale.ClientID);
            ViewData["StockID"] = new SelectList(_context.AvalibleStock, "StockID", "StockID", onlineSale.StockID);
            return View(onlineSale);
        }

        // POST: OnlineSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClientID,StockID")] OnlineSale onlineSale)
        {
            if (id != onlineSale.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onlineSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlineSaleExists(onlineSale.ID))
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
            ViewData["ClientID"] = new SelectList(_context.RegularClient, "ClientID", "ClientName", onlineSale.ClientID);
            ViewData["StockID"] = new SelectList(_context.AvalibleStock, "StockID", "Category", onlineSale.StockID);
            return View(onlineSale);
        }
        [Authorize]
        // GET: OnlineSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineSale = await _context.OnlineSale
                .Include(o => o.Client)
                .Include(o => o.Stock)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (onlineSale == null)
            {
                return NotFound();
            }

            return View(onlineSale);
        }

        // POST: OnlineSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var onlineSale = await _context.OnlineSale.FindAsync(id);
            _context.OnlineSale.Remove(onlineSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlineSaleExists(int id)
        {
            return _context.OnlineSale.Any(e => e.ID == id);
        }
    }
}
