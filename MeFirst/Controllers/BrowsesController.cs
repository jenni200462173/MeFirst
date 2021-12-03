using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeFirst.Data;
using MeFirst.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace MeFirst.Controllers
{
    // make authenticated users only able to acess
    [Authorize]
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
        [AllowAnonymous]// the only method that is public. 
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
        private static string UploadPhoto(IFormFile User)
        {
            // get temp location of upload file
            var filePath = Path.GetTempFileName();

            // create a unique name for the image

            var fileName = Guid.NewGuid() + "-" + User.FileName;
            //setting the destenation folder dynamically to make it work on any system.
            var uploadPath = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\img\\communityuploads" + fileName;

            // onwards we want to excute the file save
            using(var stream = new FileStream(uploadPath, FileMode.Create))
            {
                User.CopyTo(stream);
            }
            // send the unique uploaded file name back so that we can save it to the db
            return fileName;
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
        public async Task<IActionResult> Create([Bind("BrosweId")] Browse browse,IFormFile User)
        {
            if (ModelState.IsValid)
            {
                // upoad photo if any
                if (User != null)
                {
                    var fileName = UploadPhoto(User);
                    browse.Photo = fileName;
                }
   
                _context.Add(browse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["BrosweId"] = new SelectList(_context.Browses, "BrosweId", "User", browse.BrosweId);
           
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
