using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgnusCrm.Web.Data;
using AgnusCrm.Web.Models;

namespace AgnusCrm.Web.Controllers
{
    public class Contact_EntityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Contact_EntityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contact_Entity
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contact_Entity.Include(c => c.contact).Include(c => c.entity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contact_Entity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Entity = await _context.Contact_Entity
                .Include(c => c.contact)
                .Include(c => c.entity)
                .FirstOrDefaultAsync(m => m.id == id);
            if (contact_Entity == null)
            {
                return NotFound();
            }

            return View(contact_Entity);
        }

        // GET: Contact_Entity/Create
        public IActionResult Create()
        {
            ViewData["contactId"] = new SelectList(_context.Contact, "id", "id");
            ViewData["entityId"] = new SelectList(_context.Entity, "id", "id");
            return View();
        }

        // POST: Contact_Entity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,contactId,entityId,type,name,value")] Contact_Entity contact_Entity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact_Entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["contactId"] = new SelectList(_context.Contact, "id", "id", contact_Entity.contactId);
            ViewData["entityId"] = new SelectList(_context.Entity, "id", "id", contact_Entity.entityId);
            return View(contact_Entity);
        }

        // GET: Contact_Entity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Entity = await _context.Contact_Entity.FindAsync(id);
            if (contact_Entity == null)
            {
                return NotFound();
            }
            ViewData["contactId"] = new SelectList(_context.Contact, "id", "id", contact_Entity.contactId);
            ViewData["entityId"] = new SelectList(_context.Entity, "id", "id", contact_Entity.entityId);
            return View(contact_Entity);
        }

        // POST: Contact_Entity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,contactId,entityId,type,name,value")] Contact_Entity contact_Entity)
        {
            if (id != contact_Entity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact_Entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Contact_EntityExists(contact_Entity.id))
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
            ViewData["contactId"] = new SelectList(_context.Contact, "id", "id", contact_Entity.contactId);
            ViewData["entityId"] = new SelectList(_context.Entity, "id", "id", contact_Entity.entityId);
            return View(contact_Entity);
        }

        // GET: Contact_Entity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Entity = await _context.Contact_Entity
                .Include(c => c.contact)
                .Include(c => c.entity)
                .FirstOrDefaultAsync(m => m.id == id);
            if (contact_Entity == null)
            {
                return NotFound();
            }

            return View(contact_Entity);
        }

        // POST: Contact_Entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact_Entity = await _context.Contact_Entity.FindAsync(id);
            _context.Contact_Entity.Remove(contact_Entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Contact_EntityExists(int id)
        {
            return _context.Contact_Entity.Any(e => e.id == id);
        }
    }
}
