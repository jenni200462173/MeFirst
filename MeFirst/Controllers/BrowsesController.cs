using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeFirst.Data;
using MeFirst.Models;

namespace MeFirst.Controllers
{
    public class BrowsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrowsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Browses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Browses.ToListAsync());
        }

        // GET: Browses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var browse = await _context.Browses
                .FirstOrDefaultAsync(m => m.BrosweId == id);
            if (browse == null)
            {
                return NotFound();
            }

            return View(browse);
        }

        // GET: Browses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Browses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrosweId,User")] Browse browse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(browse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(browse);
        }

        // GET: Browses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var browse = await _context.Browses.FindAsync(id);
            if (browse == null)
            {
                return NotFound();
            }
            return View(browse);
        }

        // POST: Browses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BrosweId,User")] Browse browse)
        {
            if (id != browse.BrosweId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(browse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrowseExists(browse.BrosweId))
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
            return View(browse);
        }

        // GET: Browses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var browse = await _context.Browses
                .FirstOrDefaultAsync(m => m.BrosweId == id);
            if (browse == null)
            {
                return NotFound();
            }

            return View(browse);
        }

        // POST: Browses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var browse = await _context.Browses.FindAsync(id);
            _context.Browses.Remove(browse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrowseExists(string id)
        {
            return _context.Browses.Any(e => e.BrosweId == id);
        }
    }
}
