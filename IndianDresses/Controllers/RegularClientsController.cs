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
    public class RegularClientsController : Controller
    {
        private readonly IndianDressesContext _context;

        public RegularClientsController(IndianDressesContext context)
        {
            _context = context;
        }

        // GET: RegularClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegularClient.ToListAsync());
        }

        // GET: RegularClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularClient = await _context.RegularClient
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (regularClient == null)
            {
                return NotFound();
            }

            return View(regularClient);
        }
        [Authorize]
        // GET: RegularClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegularClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,ClientName,ClientEmail,Mobile,Purpose,ArriveDate")] RegularClient regularClient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regularClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regularClient);
        }

        // GET: RegularClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularClient = await _context.RegularClient.FindAsync(id);
            if (regularClient == null)
            {
                return NotFound();
            }
            return View(regularClient);
        }

        // POST: RegularClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,ClientName,ClientEmail,Mobile,Purpose,ArriveDate")] RegularClient regularClient)
        {
            if (id != regularClient.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regularClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegularClientExists(regularClient.ClientID))
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
            return View(regularClient);
        }
        [Authorize]
        // GET: RegularClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularClient = await _context.RegularClient
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (regularClient == null)
            {
                return NotFound();
            }

            return View(regularClient);
        }

        // POST: RegularClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regularClient = await _context.RegularClient.FindAsync(id);
            _context.RegularClient.Remove(regularClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegularClientExists(int id)
        {
            return _context.RegularClient.Any(e => e.ClientID == id);
        }
    }
}
