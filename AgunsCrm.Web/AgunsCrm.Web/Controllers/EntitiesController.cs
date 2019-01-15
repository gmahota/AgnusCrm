using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgnusCrm.Web.Data;
using AgnusCrm.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgnusCrm.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entities
        public async Task<IActionResult> Index(string entities_SearchString)
        {

            if (!String.IsNullOrEmpty(entities_SearchString))
            {
                    
                var applicationDbContext = _context.Entity.Include(e => e.Coin)
                    .Where(s => (s.code.Contains(entities_SearchString) ||
                    s.name.Contains(entities_SearchString) || 
                    s.contributing_Number.Contains(entities_SearchString) 
                    ))
                ;
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.Entity.Include(e => e.Coin);
                return View(await applicationDbContext.ToListAsync());
            }


            
        }

        // GET: Entities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Entity
                .Include(e => e.Coin)
                .Include(e => e.listContact)
                .ThenInclude(e => e.contact)
                .FirstOrDefaultAsync(m => m.id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Entities/Create
        public IActionResult Create()
        {
            ViewData["coin"] = new SelectList(_context.Coin, "code", "code");
            return View();
        }

        // POST: Entities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,type,code,name,address,locality,contributing_Number,country,telphone,coin")] Entity entity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["coin"] = new SelectList(_context.Coin, "code", "code", entity.coin);
            return View(entity);
        }

        // GET: Entities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Entity.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            ViewData["coin"] = new SelectList(_context.Coin, "code", "code", entity.coin);
            return View(entity);
        }

        // POST: Entities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,type,code,name,address,locality,contributing_Number,country,telphone,coin")] Entity entity)
        {
            if (id != entity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(entity.id))
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
            ViewData["coin"] = new SelectList(_context.Coin, "code", "code", entity.coin);
            return View(entity);
        }

        // GET: Entities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Entity
                .Include(e => e.Coin)
                .FirstOrDefaultAsync(m => m.id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: Entities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.Entity.FindAsync(id);
            _context.Entity.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityExists(int id)
        {
            return _context.Entity.Any(e => e.id == id);
        }
    }
}
