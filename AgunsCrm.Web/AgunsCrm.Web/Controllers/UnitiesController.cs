using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using AgnusCrm.Web.Models;
using AgnusCrm.Web.Data;

namespace AgnusCrm.Controllers
{
    public class UnitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Unities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unity.ToListAsync());
        }

        // GET: Unities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unity = await _context.Unity
                .FirstOrDefaultAsync(m => m.code == id);
            if (unity == null)
            {
                return NotFound();
            }

            return View(unity);
        }

        // GET: Unities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("code,desc,round")] Unity unity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unity);
        }

        // GET: Unities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unity = await _context.Unity.FindAsync(id);
            if (unity == null)
            {
                return NotFound();
            }
            return View(unity);
        }

        // POST: Unities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("code,desc,round")] Unity unity)
        {
            if (id != unity.code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnityExists(unity.code))
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
            return View(unity);
        }

        // GET: Unities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unity = await _context.Unity
                .FirstOrDefaultAsync(m => m.code == id);
            if (unity == null)
            {
                return NotFound();
            }

            return View(unity);
        }

        // POST: Unities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var unity = await _context.Unity.FindAsync(id);
            _context.Unity.Remove(unity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnityExists(string id)
        {
            return _context.Unity.Any(e => e.code == id);
        }
    }
}
