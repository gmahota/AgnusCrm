using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgnusCrm.Models;
using Microsoft.AspNetCore.Authorization;
using AgnusCrm.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgnusCrm.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            ViewData["Family"] = new SelectList(_context.Family, "code", "description");
            ViewData["SubFamily"] = new SelectList(_context.SubFamily, "code", "description");
            ViewData["Brand"] = new SelectList(_context.Brand, "code", "description");
            
            DashboardViewModel dashboard = new DashboardViewModel();

            dashboard.doctors_count = 10;// db.Doctors.Count();
            dashboard.nurses_count = 30; //db.Nurses.Count();
            dashboard.patients_count = 20; //db.Patients.Count();

            return View(dashboard);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
