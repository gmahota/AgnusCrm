﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lte.Controllers
{
    public partial class AdminlteController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Advanced()
        {
            return View();
        }

        public IActionResult Editor()
        {
            return View();
        }
    }
}