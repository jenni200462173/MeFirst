using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeFirst.Data;


namespace MeFirst.Controllers
{
    public class ShopController : Controller
    {
        // adding a db connection
        private readonly ApplicationDbContext _context;
        // constructor - every instance of this class requires a DbContext object
        public ShopController(ApplicationDbContext context)
        {
            _context = context; // making db connetction public in this class. SO we can use in any method. 
        }
        public IActionResult Index()
        {
            // passing a list of skintypes where users can shop from their skin type. 
            var Products = _context.Products.OrderBy(c => c.SkinTypeID).ToList();
            return View(Products);
        }
    }
}
