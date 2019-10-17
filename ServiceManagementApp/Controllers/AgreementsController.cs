using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceManagementApp.Models;

namespace ServiceManagementApp.Controllers
{
    public class AgreementsController : Controller
    {
        private readonly SoftwareCenterWebAppDbContext _context;

        public AgreementsController(SoftwareCenterWebAppDbContext context)
        {
            _context = context;
        }

        // GET: Agreements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agreements.ToListAsync());
        }

        // GET: Agreements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreements = await _context.Agreements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agreements == null)
            {
                return NotFound();
            }

            return View(agreements);
        }

        // GET: Agreements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agreements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Agreements agreements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agreements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agreements);
        }

        // GET: Agreements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreements = await _context.Agreements.FindAsync(id);
            if (agreements == null)
            {
                return NotFound();
            }
            return View(agreements);
        }

        // POST: Agreements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Agreements agreements)
        {
            if (id != agreements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agreements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgreementsExists(agreements.Id))
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
            return View(agreements);
        }

        // GET: Agreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreements = await _context.Agreements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agreements == null)
            {
                return NotFound();
            }

            return View(agreements);
        }

        // POST: Agreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agreements = await _context.Agreements.FindAsync(id);
            _context.Agreements.Remove(agreements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgreementsExists(int id)
        {
            return _context.Agreements.Any(e => e.Id == id);
        }
    }
}
