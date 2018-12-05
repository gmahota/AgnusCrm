using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgnusCrm.Web.Controllers
{
    public class ApprovalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}