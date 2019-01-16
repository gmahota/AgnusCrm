﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgnusCrm.Data;
using AgnusCrm.Models;

namespace AgnusCrm.Controllers
{
    public class PriceListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PriceListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PriceList
        public async Task<IActionResult> Index()
        {
            return View(await _context.View_PriceList.ToListAsync());
        }

        // GET: PriceList/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var view_PriceList = await _context.View_PriceList
                .FirstOrDefaultAsync(m => m.artigo == id);
            if (view_PriceList == null)
            {
                return NotFound();
            }

            return View(view_PriceList);
        }

        // GET: PriceList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PriceList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("artigo,marca,marca_Desc,familia,familia_Desc,subFamilia,subFamilia_Desc,artigo_Desc,preco,stock")] View_PriceList view_PriceList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(view_PriceList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view_PriceList);
        }

        // GET: PriceList/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var view_PriceList = await _context.View_PriceList.FindAsync(id);
            if (view_PriceList == null)
            {
                return NotFound();
            }
            return View(view_PriceList);
        }

        // POST: PriceList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("artigo,marca,marca_Desc,familia,familia_Desc,subFamilia,subFamilia_Desc,artigo_Desc,preco,stock")] View_PriceList view_PriceList)
        {
            if (id != view_PriceList.artigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(view_PriceList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!View_PriceListExists(view_PriceList.artigo))
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
            return View(view_PriceList);
        }

        // GET: PriceList/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var view_PriceList = await _context.View_PriceList
                .FirstOrDefaultAsync(m => m.artigo == id);
            if (view_PriceList == null)
            {
                return NotFound();
            }

            return View(view_PriceList);
        }

        // POST: PriceList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var view_PriceList = await _context.View_PriceList.FindAsync(id);
            _context.View_PriceList.Remove(view_PriceList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool View_PriceListExists(string id)
        {
            return _context.View_PriceList.Any(e => e.artigo == id);
        }
    }
}
