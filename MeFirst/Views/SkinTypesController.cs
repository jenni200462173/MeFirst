using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeFirst.Data;
using MeFirst.Models;

namespace MeFirst.Views
{
    public class SkinTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkinTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkinTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SkinTypes.ToListAsync());
        }

        // GET: SkinTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skinType = await _context.SkinTypes
                .FirstOrDefaultAsync(m => m.SkyinTypeId == id);
            if (skinType == null)
            {
                return NotFound();
            }

            return View(skinType);
        }

        // GET: SkinTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkinTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkyinTypeId,Dry,Aging,Oily,Combination,TreatmentsID")] SkinType skinType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skinType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skinType);
        }

        // GET: SkinTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skinType = await _context.SkinTypes.FindAsync(id);
            if (skinType == null)
            {
                return NotFound();
            }
            return View(skinType);
        }

        // POST: SkinTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkyinTypeId,Dry,Aging,Oily,Combination,TreatmentsID")] SkinType skinType)
        {
            if (id != skinType.SkyinTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skinType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkinTypeExists(skinType.SkyinTypeId))
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
            return View(skinType);
        }

        // GET: SkinTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skinType = await _context.SkinTypes
                .FirstOrDefaultAsync(m => m.SkyinTypeId == id);
            if (skinType == null)
            {
                return NotFound();
            }

            return View(skinType);
        }

        // POST: SkinTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skinType = await _context.SkinTypes.FindAsync(id);
            _context.SkinTypes.Remove(skinType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkinTypeExists(int id)
        {
            return _context.SkinTypes.Any(e => e.SkyinTypeId == id);
        }
    }
}
