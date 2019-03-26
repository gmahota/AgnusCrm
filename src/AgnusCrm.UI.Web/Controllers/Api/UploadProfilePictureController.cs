using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgnusCrm.Data;
using AgnusCrm.Models;
using AgnusCrm.Services;

namespace AgnusCrm.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/UploadProfilePicture")]
    [Authorize]
    public class UploadProfilePictureController : Controller
    {
        private readonly IAgnusCrmService _AgnusCrmService;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UploadProfilePictureController(IAgnusCrmService AgnusCrmService,
            IHostingEnvironment env,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _AgnusCrmService = AgnusCrmService;
            _env = env;
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        [RequestSizeLimit(5000000)]
        public async Task<IActionResult> PostUploadProfilePicture(List<IFormFile> files)
        {
            try
            {
                var fileName = await _AgnusCrmService.UploadFile(files, _env);
                //try to update the user profile pict
                ApplicationUser appUser = await _userManager.GetUserAsync(User);
                appUser.profilePictureUrl = "/uploads/" + fileName;
                _context.Update(appUser);
                _context.SaveChanges();
                return Ok(fileName);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }


        }
    }
}