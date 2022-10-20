using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTrack.Models;

namespace BugTrack.Controllers
{
    public class BugCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BugCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BugCategories
        public async Task<IActionResult> Index()
        {
              return View(await _context.Categories.ToListAsync());
        }

        // GET: BugCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var bugCategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.BugCategoryId == id);
            if (bugCategory == null)
            {
                return NotFound();
            }

            return View(bugCategory);
        }

        // GET: BugCategories/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if(id==0)
                return View(new BugCategory());
            else
                return View(_context.Categories.Find(id));
        }

        // POST: BugCategories/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("BugCategoryId,Title,Icon,Type")] BugCategory bugCategory)
        {
            if (ModelState.IsValid)
            {
                if(bugCategory.BugCategoryId == 0)
                    _context.Add(bugCategory);
                else 
                    _context.Update(bugCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bugCategory);
        }

        


        // POST: BugCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var bugCategory = await _context.Categories.FindAsync(id);
            if (bugCategory != null)
            {
                _context.Categories.Remove(bugCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
