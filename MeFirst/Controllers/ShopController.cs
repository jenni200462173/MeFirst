using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeFirst.Data;
using MeFirst.Models;


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
            // passing where users can shop from brands  
            var Products = _context.Products.OrderBy(c => c.SkinTypeID).ToList();
            return View(Products);
        }

        // getting the shoByProdcuts// ****Working sorta, just not showing what user clicked on***
        public IActionResult ShopBySkinType(int id)
        {
            var products = _context.Products
                .Where(p => p.ProductsId == id)
                .OrderBy(p =>p.Name)
                .ToList();
            return View(products);
        }

        // POST: /Shop/AddtoCart
        [HttpPost]
        public IActionResult AddToCart(int ProductsId)
        {
            // getting the product price
            var product = _context.Products.Find(ProductsId);
            var price = product.Price;
            // determine who the user is and their indvidual carts
            // save to CartItems table in db
            // redirect to the cart Page so user can see their full cart


        }

    }
}

