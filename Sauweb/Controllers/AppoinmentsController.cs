using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SauWeb.Models;
using Sauweb.Data;
using Microsoft.AspNetCore.Authorization;

namespace Sauweb.Controllers
{
    [Authorize]
    public class AppoinmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppoinmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appoinments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appoinments.Include(a => a.Doctor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appoinments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appoinments == null)
            {
                return NotFound();
            }

            var appoinment = await _context.Appoinments
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(m => m.AppomentId == id);
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        // GET: Appoinments/Create
      
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoktorId", "DoctorName");
            return View();
        }

        // POST: Appoinments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        

        public async Task<IActionResult> Create([Bind("AppomentId,DoctorId,Day,Time,Full")] Appoinment appoinment)
        {
           
                _context.Add(appoinment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: Appoinments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appoinments == null)
            {
                return NotFound();
            }

            var appoinment = await _context.Appoinments.FindAsync(id);
            if (appoinment == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoktorId", "DoctorName", appoinment.DoctorId);
            return View(appoinment);
        }

        // POST: Appoinments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppomentId,DoctorId,Day,Time,Full")] Appoinment appoinment)
        {
            if (id != appoinment.AppomentId)
            {
                return NotFound();
            }

            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoktorId", "DoctorName", appoinment.DoctorId);

            try
                {
                    _context.Update(appoinment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppoinmentExists(appoinment.AppomentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(appoinment);
        }

        // GET: Appoinments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appoinments == null)
            {
                return NotFound();
            }

            var appoinment = await _context.Appoinments
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(m => m.AppomentId == id);
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        // POST: Appoinments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appoinments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Appoinments'  is null.");
            }
            var appoinment = await _context.Appoinments.FindAsync(id);
            if (appoinment != null)
            {
                _context.Appoinments.Remove(appoinment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppoinmentExists(int id)
        {
          return (_context.Appoinments?.Any(e => e.AppomentId == id)).GetValueOrDefault();
        }
    }
}
