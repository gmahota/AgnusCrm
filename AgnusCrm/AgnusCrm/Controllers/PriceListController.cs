using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgnusCrm.Data;
using AgnusCrm.Models;
using Microsoft.AspNetCore.Http;
using AgnusCrm.Models.PriceList;

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
            var searchString = "camera";
            ViewData["PriceType"] = "PVP1";

            ViewData["Family"] = new SelectList(_context.Family, "code", "description");
            ViewData["SubFamily"] = new SelectList(_context.SubFamily, "code", "description");
            ViewData["Brand"] = new SelectList(_context.Brand, "code", "description");


            if (!String.IsNullOrEmpty(searchString))
            {
                var priceList = _context.Product
                    //.Include(p => p.Brand)
                    //.Include(p => p.Family)
                    //.Include(p => p.SubFamily)
                    //.Include(p => p.ProductPrice)
                    .Where(s => (s.productCode.Contains(searchString) ||
                    s.description.Contains(searchString)) );

                return View(await priceList.ToListAsync());

            }
            else
            {
                var priceList = _context.Product;
                    //.Include(p => p.Brand)
                    //.Include(p => p.Family)
                    //.Include(p => p.SubFamily)
                    //.Include(p => p.ProductPrice)
                    //.Where(s => s.stock > 0)

                return View(await priceList.ToListAsync());
            }

        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString,
            [Bind("listBrand,listFamily,listSubFamily")] ViewSearchPriceList price,
            IFormCollection form)
        {

            ViewData["PriceType"] = "PVP1";

            ViewData["Family"] = new SelectList(_context.Family, "code", "description");
            ViewData["SubFamily"] = new SelectList(_context.SubFamily, "code", "description");
            ViewData["Brand"] = new SelectList(_context.Brand, "code", "description");

            string filtroBrand = "";
            string filtroFamily = "";
            string filtroSubFamily = "";

            if (price.listBrand != null)
            {
                filtroBrand = "";

                foreach (var item in price.listBrand)
                {
                    filtroBrand += filtroBrand.Length == 0 ? "'" + item + "'" : ",'" + item + "'";
                }

                filtroBrand = "and B.code in (" + filtroBrand + ") ";
            }

            if (price.listFamily != null)
            {
                filtroFamily = "";

                foreach (var item in price.listFamily)
                {
                    filtroFamily += filtroFamily.Length == 0 ? "'" + item + "'" : ",'" + item + "'";
                }

                filtroFamily = "and F.code in (" + filtroFamily + ") ";
            }

            if (price.listSubFamily != null)
            {
                filtroSubFamily = "";

                foreach (var item in price.listSubFamily)
                {
                    filtroSubFamily += filtroSubFamily.Length == 0 ? "'" + item + "'" : ",'" + item + "'";
                }

                filtroSubFamily = "and SF.Code in (" + filtroSubFamily + ") ";
            }

            string sql = string.Format( @"select P.id, isnull(b.description,'') as brand_desc, isnull(f.description,'') as family_desc, 
	            isnull(sf.description,'') as subFamily_desc, p.[desc],p.stock,pp.pvp1 as price, CONVERT(Bit,0) as encomenda
                from dbo.Product P
                inner join dbo.Family F on F.code = p.familycode {0}
                inner join dbo.SubFamily SF on SF.id = p.subFamilyCode {1}
                inner join dbo.Brand B on B.code = p.brandCode {2}
                inner join dbo.ProductPrice pp on pp.product = p.id
                where p.stock > 0"
                , filtroFamily,filtroSubFamily,filtroBrand
            );

            var priceList = _context.ViewPriceList.FromSql(sql);

            return View(await priceList.ToListAsync());
            
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
