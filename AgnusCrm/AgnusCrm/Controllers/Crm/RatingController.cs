using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

using AgnusCrm.Data;
using AgnusCrm.Models.Crm;

namespace AgnusCrm.Controllers.Crm
{


    [Authorize(Roles = "Rating")]
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RatingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rating
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rating.ToListAsync());
        }

        // GET: Rating/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                        .SingleOrDefaultAsync(m => m.ratingId == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }


        // GET: Rating/Create
        public IActionResult Create()
        {
            Rating rating = new Rating();
            rating.colorHex = "#00a65a";
            return View(rating);
        }




        // POST: Rating/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ratingId,ratingName,description,colorHex,createdAt")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Rating/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating.SingleOrDefaultAsync(m => m.ratingId == id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // POST: Rating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ratingId,ratingName,description,colorHex,createdAt")] Rating rating)
        {
            if (id != rating.ratingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.ratingId))
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
            return View(rating);
        }

        // GET: Rating/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                    .SingleOrDefaultAsync(m => m.ratingId == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }




        // POST: Rating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rating = await _context.Rating.SingleOrDefaultAsync(m => m.ratingId == id);

            try
            {
                _context.Rating.Remove(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return RedirectToAction(nameof(Delete), new { id = rating.ratingId });
            }

            
        }

        private bool RatingExists(string id)
        {
            return _context.Rating.Any(e => e.ratingId == id);
        }

    }
}





namespace AgnusCrm.MVC
{
    public static partial class Pages
    {
        public static class Rating
        {
            public const string Controller = "Rating";
            public const string Action = "Index";
            public const string Role = "Rating";
            public const string Url = "/Rating/Index";
            public const string Name = "Rating";
        }
    }
}
namespace AgnusCrm.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Rating")]
        public bool RatingRole { get; set; } = false;
    }
}



