﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFirst.Controllers
{
    public class ShopController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
