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
    public class OurEmployeesController : Controller
    {
        private readonly IndianDressesContext _context;

        public OurEmployeesController(IndianDressesContext context)
        {
            _context = context;
        }

        // GET: OurEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.OurEmployee.ToListAsync());
        }

        // GET: OurEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourEmployee = await _context.OurEmployee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (ourEmployee == null)
            {
                return NotFound();
            }

            return View(ourEmployee);
        }
        [Authorize]
        // GET: OurEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OurEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeName,Address,MobileNumber,ShiftStart,ShiftFinish")] OurEmployee ourEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ourEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourEmployee);
        }

        // GET: OurEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourEmployee = await _context.OurEmployee.FindAsync(id);
            if (ourEmployee == null)
            {
                return NotFound();
            }
            return View(ourEmployee);
        }

        // POST: OurEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,EmployeeName,Address,MobileNumber,ShiftStart,ShiftFinish")] OurEmployee ourEmployee)
        {
            if (id != ourEmployee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurEmployeeExists(ourEmployee.EmployeeID))
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
            return View(ourEmployee);
        }

        // GET: OurEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourEmployee = await _context.OurEmployee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (ourEmployee == null)
            {
                return NotFound();
            }

            return View(ourEmployee);
        }
        [Authorize]

        // POST: OurEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ourEmployee = await _context.OurEmployee.FindAsync(id);
            _context.OurEmployee.Remove(ourEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurEmployeeExists(int id)
        {
            return _context.OurEmployee.Any(e => e.EmployeeID == id);
        }
    }
}
