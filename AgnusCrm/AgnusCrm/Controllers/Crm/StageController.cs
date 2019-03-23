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


    [Authorize(Roles = "Stage")]
    public class StageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stage.ToListAsync());
        }

        // GET: Stage/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage
                        .SingleOrDefaultAsync(m => m.stageId == id);
            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }


        // GET: Stage/Create
        public IActionResult Create()
        {
            Stage stage = new Stage();
            stage.colorHex = "#00a65a";
            return View(stage);
        }




        // POST: Stage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("stageId,stageName,description,colorHex,createdAt")] Stage stage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stage);
        }

        // GET: Stage/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage.SingleOrDefaultAsync(m => m.stageId == id);
            if (stage == null)
            {
                return NotFound();
            }
            return View(stage);
        }

        // POST: Stage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("stageId,stageName,description,colorHex,createdAt")] Stage stage)
        {
            if (id != stage.stageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageExists(stage.stageId))
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
            return View(stage);
        }

        // GET: Stage/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage
                    .SingleOrDefaultAsync(m => m.stageId == id);
            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }




        // POST: Stage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stage = await _context.Stage.SingleOrDefaultAsync(m => m.stageId == id);

            try
            {
                _context.Stage.Remove(stage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return RedirectToAction(nameof(Delete), new { id = stage.stageId });
            }

            
        }

        private bool StageExists(string id)
        {
            return _context.Stage.Any(e => e.stageId == id);
        }

    }
}





namespace AgnusCrm.MVC
{
    public static partial class Pages
    {
        public static class Stage
        {
            public const string Controller = "Stage";
            public const string Action = "Index";
            public const string Role = "Stage";
            public const string Url = "/Stage/Index";
            public const string Name = "Stage";
        }
    }
}
namespace AgnusCrm.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Stage")]
        public bool StageRole { get; set; } = false;
    }
}



