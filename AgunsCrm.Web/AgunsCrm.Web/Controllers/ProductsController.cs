﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgnusCrm.Web.Data;
using AgnusCrm.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgnusCrm.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.brand).Include(p => p.family).Include(p => p.subFamily);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.brand)
                .Include(p => p.family)
                .Include(p => p.subFamily)
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["brandCode"] = new SelectList(_context.Brand, "code", "code");
            ViewData["familyCode"] = new SelectList(_context.Family, "code", "code");
            ViewData["subFamilyCode"] = new SelectList(_context.SubFamily, "code", "code");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,code,desc,price,familyCode,subFamilyCode,brandCode,notes,stock,status")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["brandCode"] = new SelectList(_context.Brand, "code", "code", product.brandCode);
            ViewData["familyCode"] = new SelectList(_context.Family, "code", "code", product.familyCode);
            ViewData["subFamilyCode"] = new SelectList(_context.SubFamily, "code", "code", product.subFamilyCode);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["brandCode"] = new SelectList(_context.Brand, "code", "code", product.brandCode);
            ViewData["familyCode"] = new SelectList(_context.Family, "code", "code", product.familyCode);
            ViewData["subFamilyCode"] = new SelectList(_context.SubFamily, "code", "code", product.subFamilyCode);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,code,desc,price,familyCode,subFamilyCode,brandCode,notes,stock,status")] Product product)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.id))
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
            ViewData["brandCode"] = new SelectList(_context.Brand, "code", "code", product.brandCode);
            ViewData["familyCode"] = new SelectList(_context.Family, "code", "code", product.familyCode);
            ViewData["subFamilyCode"] = new SelectList(_context.SubFamily, "code", "code", product.subFamilyCode);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.brand)
                .Include(p => p.family)
                .Include(p => p.subFamily)
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.id == id);
        }
    }
}
