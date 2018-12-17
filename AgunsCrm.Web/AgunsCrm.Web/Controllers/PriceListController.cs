using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgnusCrm.Web.Data;
using AgnusCrm.Web.Models;
using AgnusCrm.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AgnusCrm.Web.Controllers
{
    [Authorize]
    [Route("ListaPrecos")]
    public class PriceListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public PriceListController(ApplicationDbContext context, 
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
            _context = context;
            _emailSender = emailSender;
            _logger = logger;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        // GET: View_PriceList
        public async Task<IActionResult> Index(string searchString)
        {

            ViewData["PriceType"] = "PVP1";

            await _emailSender.SendEmailAsync("guimaraesmahota@gmail.com","OLA","Ola");

            if (!String.IsNullOrEmpty(searchString))
            {
                var priceList = _context.Product
                    .Include(p => p.Brand)
                    .Include(p => p.Family)
                    .Include(p => p.SubFamily)
                    .Include(p=> p.ProductPrice)
                    .Where(s => (s.code.Contains(searchString) ||
                    s.desc.Contains(searchString)) && s.stock > 0);

                return View(await priceList.ToListAsync());

            }
            else
            {
                var priceList = _context.Product
                    .Include(p => p.Brand)
                    .Include(p => p.Family)
                    .Include(p => p.SubFamily)
                    .Include(p => p.ProductPrice)
                    .Where(s => s.stock > 0);

                return View(await priceList.ToListAsync());
            }

            
        }

        // GET: View_PriceList/Details/5
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

        // GET: View_PriceList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: View_PriceList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("artigo,marca,marca_Desc,familia,familia_Desc,subFamilia,subFamilia_Desc,desc_Artigo,preco")] View_PriceList view_PriceList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(view_PriceList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view_PriceList);
        }

        // GET: View_PriceList/Edit/5
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

        // POST: View_PriceList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("artigo,marca,marca_Desc,familia,familia_Desc,subFamilia,subFamilia_Desc,desc_Artigo,preco")] View_PriceList view_PriceList)
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

        // GET: View_PriceList/Delete/5
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

        // POST: View_PriceList/Delete/5
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
