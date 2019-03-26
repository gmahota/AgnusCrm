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
    public class CoinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Coins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coin.ToListAsync());
        }

        // GET: Coins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coin
                .FirstOrDefaultAsync(m => m.code == id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // GET: Coins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("code,desc,Symbol,decimalPlaces,logo")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coin);
        }

        // GET: Coins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coin.FindAsync(id);
            if (coin == null)
            {
                return NotFound();
            }
            return View(coin);
        }

        // POST: Coins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("code,desc,Symbol,decimalPlaces,logo")] Coin coin)
        {
            if (id != coin.code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoinExists(coin.code))
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
            return View(coin);
        }

        // GET: Coins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coin
                .FirstOrDefaultAsync(m => m.code == id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // POST: Coins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var coin = await _context.Coin.FindAsync(id);
            _context.Coin.Remove(coin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoinExists(string id)
        {
            return _context.Coin.Any(e => e.code == id);
        }
    }
}
