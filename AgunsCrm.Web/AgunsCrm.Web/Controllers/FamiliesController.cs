using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgnusCrm.Web.Data;
using AgnusCrm.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace AgnusCrm.Web.Controllers
{
    public class FamiliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamiliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Families
        public async Task<IActionResult> Index()
        {
            return View(await _context.Family.ToListAsync());
        }

        // GET: Families/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var family = await _context.Family
                .FirstOrDefaultAsync(m => m.code == id);
            if (family == null)
            {
                return NotFound();
            }

            return View(family);
        }

        // GET: Families/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Families/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("code,description")] Family family)
        {
            if (ModelState.IsValid)
            {
                _context.Add(family);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(family);
        }

        // GET: Families/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var family = await _context.Family.FindAsync(id);
            if (family == null)
            {
                return NotFound();
            }
            return View(family);
        }

        // POST: Families/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("code,description")] Family family)
        {
            if (id != family.code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(family);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamilyExists(family.code))
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
            return View(family);
        }

        // GET: Families/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var family = await _context.Family
                .FirstOrDefaultAsync(m => m.code == id);
            if (family == null)
            {
                return NotFound();
            }

            return View(family);
        }

        // POST: Families/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var family = await _context.Family.FindAsync(id);
            _context.Family.Remove(family);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamilyExists(string id)
        {
            return _context.Family.Any(e => e.code == id);
        }
    }
}
