using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AgnusCrm.Models;

namespace AgnusCrm.Controllers.Crm
{
    [Authorize(Roles = "Dashboard")]
    public class DashboardController : Controller
    {
        private readonly ILogger _logger;

        public DashboardController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

namespace AgnusCrm.MVC
{
    public static partial class Pages
    {
        public static class Dashboard
        {
            public const string Controller = "Dashboard";
            public const string Action = "Index";
            public const string Role = "Dashboard";
            public const string Url = "/Dashboard/Index";
            public const string Name = "Dashboard";
        }
    }
}
namespace AgnusCrm.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Dashboard")]
        public bool DashboardRole { get; set; } = false;
    }
}