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
    public class IssuesController : Controller
    {
        private readonly SoftwareCenterWebAppDbContext _context;

        public IssuesController(SoftwareCenterWebAppDbContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            var softwareCenterWebAppDbContext = _context.Issues.Include(i => i.Agreement).Include(i => i.Customer).Include(i => i.Product).Include(i => i.User);
            return View(await softwareCenterWebAppDbContext.ToListAsync());
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issues = await _context.Issues
                .Include(i => i.Agreement)
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issues == null)
            {
                return NotFound();
            }

            return View(issues);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            ViewData["AgreementId"] = new SelectList(_context.Agreements, "Id", "Id");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CustomerId,AgreementId,ProductId,Description,Notes,Remedy,CreatedDate,CloseDate,Priority,Status,UserId")] Issues issues)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issues);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgreementId"] = new SelectList(_context.Agreements, "Id", "Id", issues.AgreementId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", issues.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", issues.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", issues.UserId);
            return View(issues);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issues = await _context.Issues.FindAsync(id);
            if (issues == null)
            {
                return NotFound();
            }
            ViewData["AgreementId"] = new SelectList(_context.Agreements, "Id", "Title", issues.AgreementId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", issues.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title", issues.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", issues.UserId);
            return View(issues);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CustomerId,AgreementId,ProductId,Description,Notes,Remedy,CreatedDate,CloseDate,Priority,Status,UserId")] Issues issues)
        {
            if (id != issues.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issues);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssuesExists(issues.Id))
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
            ViewData["AgreementId"] = new SelectList(_context.Agreements, "Id", "Title", issues.AgreementId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", issues.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title", issues.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", issues.UserId);
            return View(issues);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issues = await _context.Issues
                .Include(i => i.Agreement)
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issues == null)
            {
                return NotFound();
            }

            return View(issues);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issues = await _context.Issues.FindAsync(id);
            _context.Issues.Remove(issues);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssuesExists(int id)
        {
            return _context.Issues.Any(e => e.Id == id);
        }
    }
}
