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
using AgnusCrm.Models.Invent;

namespace AgnusCrm.Controllers.Invent
{
    [Authorize(Roles = "Stock")]
    public class StockController : Controller
    {
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
        public static class Stock
        {
            public const string Controller = "Stock";
            public const string Action = "Index";
            public const string Role = "Stock";
            public const string Url = "/Stock/Index";
            public const string Name = "Stock";
        }
    }
}
namespace AgnusCrm.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Stock")]
        public bool StockRole { get; set; } = false;
    }
}



