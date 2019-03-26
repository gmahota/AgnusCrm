using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AgnusCrm.Data;
using AgnusCrm.Models.Crm;

namespace AgnusCrm.Controllers.Api
{

    [Produces("application/json")]
    [Route("api/LeadLine")]
    public class LeadLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LeadLine
        [HttpGet]
        [Authorize]
        public IActionResult GetLeadLine(string masterid)
        {
            return Json(new { data = _context.LeadLine.Include(x => x.activity).Where(x => x.leadId.Equals(masterid)).ToList() });
        }

        // POST: api/LeadLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostLeadLine([FromBody] LeadLine leadLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (leadLine.leadLineId == string.Empty)
            {
                leadLine.leadLineId = Guid.NewGuid().ToString();
                _context.LeadLine.Add(leadLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(leadLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/LeadLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult>  DeleteLeadLine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leadLine = await _context.LeadLine.SingleOrDefaultAsync(m => m.leadLineId == id);
            if (leadLine == null)
            {
                return NotFound();
            }

            _context.LeadLine.Remove(leadLine);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }


        private bool LeadLineExists(string id)
        {
            return _context.LeadLine.Any(e => e.leadLineId == id);
        }


    }

}
