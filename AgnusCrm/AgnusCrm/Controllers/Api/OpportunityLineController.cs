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
    [Route("api/OpportunityLine")]
    public class OpportunityLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunityLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OpportunityLine
        [HttpGet]
        [Authorize]
        public IActionResult GetOpportunityLine(string masterid)
        {
            return Json(new { data = _context.OpportunityLine.Include(x => x.activity).Where(x => x.opportunityId.Equals(masterid)).ToList() });
        }

        // POST: api/OpportunityLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostOpportunityLine([FromBody] OpportunityLine opportunityLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (opportunityLine.opportunityLineId == string.Empty)
            {
                opportunityLine.opportunityLineId = Guid.NewGuid().ToString();
                _context.OpportunityLine.Add(opportunityLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(opportunityLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/OpportunityLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult>  DeleteOpportunityLine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opportunityLine = await _context.OpportunityLine.SingleOrDefaultAsync(m => m.opportunityLineId == id);
            if (opportunityLine == null)
            {
                return NotFound();
            }

            _context.OpportunityLine.Remove(opportunityLine);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }


        private bool OpportunityLineExists(string id)
        {
            return _context.OpportunityLine.Any(e => e.opportunityLineId == id);
        }


    }

}
