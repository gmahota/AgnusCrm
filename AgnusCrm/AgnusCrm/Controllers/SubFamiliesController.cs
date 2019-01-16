using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgnusCrm.Data;
using AgnusCrm.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgnusCrm.Controllers
{
    [Authorize]
    public class SubFamiliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubFamiliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubFamilies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubFamily.Include(s => s.family);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubFamilies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subFamily = await _context.SubFamily
                .Include(s => s.family)
                .FirstOrDefaultAsync(m => m.id == id);
            if (subFamily == null)
            {
                return NotFound();
            }

            return View(subFamily);
        }

        // GET: SubFamilies/Create
        public IActionResult Create()
        {
            ViewData["familyCode"] = new SelectList(_context.Family, "code", "code");
            return View();
        }

        // POST: SubFamilies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,code,description,familyCode")] SubFamily subFamily)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subFamily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["familyCode"] = new SelectList(_context.Family, "code", "code", subFamily.familyCode);
            return View(subFamily);
        }

        // GET: SubFamilies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subFamily = await _context.SubFamily.FindAsync(id);
            if (subFamily == null)
            {
                return NotFound();
            }
            ViewData["familyCode"] = new SelectList(_context.Family, "code", "code", subFamily.familyCode);
            return View(subFamily);
        }

        // POST: SubFamilies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,code,description,familyCode")] SubFamily subFamily)
        {
            if (id != subFamily.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subFamily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubFamilyExists(subFamily.id))
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
            ViewData["familyCode"] = new SelectList(_context.Family, "code", "code", subFamily.familyCode);
            return View(subFamily);
        }

        // GET: SubFamilies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subFamily = await _context.SubFamily
                .Include(s => s.family)
                .FirstOrDefaultAsync(m => m.id == id);
            if (subFamily == null)
            {
                return NotFound();
            }

            return View(subFamily);
        }

        // POST: SubFamilies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subFamily = await _context.SubFamily.FindAsync(id);
            _context.SubFamily.Remove(subFamily);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubFamilyExists(int id)
        {
            return _context.SubFamily.Any(e => e.id == id);
        }
    }
}
