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
    public class TreatmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreatmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treatments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Treatments.ToListAsync());
        }

        // GET: Treatments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatments = await _context.Treatments
                .FirstOrDefaultAsync(m => m.TreatmentsId == id);
            if (treatments == null)
            {
                return NotFound();
            }

            return View(treatments);
        }

        // GET: Treatments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreatmentsId,Moisturizer,Retinal,Toner,Spf,SkinTypeId")] Treatments treatments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatments);
        }

        // GET: Treatments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatments = await _context.Treatments.FindAsync(id);
            if (treatments == null)
            {
                return NotFound();
            }
            return View(treatments);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreatmentsId,Moisturizer,Retinal,Toner,Spf,SkinTypeId")] Treatments treatments)
        {
            if (id != treatments.TreatmentsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentsExists(treatments.TreatmentsId))
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
            return View(treatments);
        }

        // GET: Treatments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatments = await _context.Treatments
                .FirstOrDefaultAsync(m => m.TreatmentsId == id);
            if (treatments == null)
            {
                return NotFound();
            }

            return View(treatments);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatments = await _context.Treatments.FindAsync(id);
            _context.Treatments.Remove(treatments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentsExists(int id)
        {
            return _context.Treatments.Any(e => e.TreatmentsId == id);
        }
    }
}
