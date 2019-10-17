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
    public class ActionsController : Controller
    {
        private readonly SoftwareCenterWebAppDbContext _context;

        public ActionsController(SoftwareCenterWebAppDbContext context)
        {
            _context = context;
        }

        // GET: Actions
        public async Task<IActionResult> Index()
        {
            var softwareCenterWebAppDbContext = _context.Actions.Include(a => a.Agreement).Include(a => a.Customer).Include(a => a.Product);
            return View(await softwareCenterWebAppDbContext.ToListAsync());
        }

        // GET: Actions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actions = await _context.Actions
                .Include(a => a.Agreement)
                .Include(a => a.Customer)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actions == null)
            {
                return NotFound();
            }

            return View(actions);
        }

        // GET: Actions/Create
        public IActionResult Create()
        {
            ViewData["AgreementId"] = new SelectList(_context.Agreements, "Id", "Id");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Actions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Responsible,CustomerId,AgreementId,ProductId,Description,Notes,CreatedDate,DoneDate,Priority,Status")] Actions actions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgreementId"] = new SelectList(_context.Agreements, "Id", "Id", actions.AgreementId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", actions.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", actions.ProductId);
            return View(actions);
        }

        // GET: Actions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actions = await _context.Actions.FindAsync(id);
            if (actions == null)
            {
                return NotFound();
            }
            ViewData["AgreementId"] = new SelectList(_context.Agreements, "Id", "Id", actions.AgreementId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", actions.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", actions.ProductId);
            return View(actions);
        }

        // POST: Actions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Responsible,CustomerId,AgreementId,ProductId,Description,Notes,CreatedDate,DoneDate,Priority,Status")] Actions actions)
        {
            if (id != actions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionsExists(actions.Id))
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
            ViewData["AgreementId"] = new SelectList(_context.Agreements, "Id", "Id", actions.AgreementId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", actions.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", actions.ProductId);
            return View(actions);
        }

        // GET: Actions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actions = await _context.Actions
                .Include(a => a.Agreement)
                .Include(a => a.Customer)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actions == null)
            {
                return NotFound();
            }

            return View(actions);
        }

        // POST: Actions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actions = await _context.Actions.FindAsync(id);
            _context.Actions.Remove(actions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActionsExists(int id)
        {
            return _context.Actions.Any(e => e.Id == id);
        }
    }
}
