using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTrack.Models;
using Microsoft.Data.SqlClient;

namespace BugTrack.Controllers
{
    public class TrackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Track
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tracks.Include(t => t.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Track/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateCategories();
            if (id == 0)
                return View(new Track());
            else
                return View(_context.Tracks.Find(id));
        }

        // POST: Track/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TrackId,BugCategoryId,Note,Description,Date")] Track track)
        {
            
                if (ModelState.IsValid)
                {
                    if (track.TrackId == 0)
                        _context.Add(track);
                    else
                        _context.Update(track);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                PopulateCategories();
                return View(track);
            
            
            
        }

        // POST: Track/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tracks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tracks'  is null.");
            }
            var track = await _context.Tracks.FindAsync(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [NonAction]
        public void PopulateCategories()
        {
            var CategoryCollection = _context.Categories.ToList();
            BugCategory DefaultCategory = new BugCategory() { BugCategoryId = 0, Title = "Choose a Bug" };
            CategoryCollection.Insert(0, DefaultCategory);
            ViewBag.Categories = CategoryCollection;
        }
    }
}