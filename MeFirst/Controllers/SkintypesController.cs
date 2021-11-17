using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeFirst.Models;
namespace MeFirst.Controllers
{
    public class SkintypesController : Controller
    {
        public IActionResult Index()
        {
            //use the category model to generate a list of 3 skin types
            var skinTypes = new List<SkinType>();
            
            for (var i = 1; i <4; i++)
            {
                skinTypes.Add(new SkinType {SkinTypeId = i, Remedy = "skinType" + i.ToString() });
            }

            // pass the skin type list for display
            return View(skinTypes);
        }

        // adding skin care types pages
        // method to check for where user clicks
        public IActionResult Browse( string skintypes)
        {
            // if skintype is missing 
           // if (skintypes== null)
          //  {
            //    return RedirectToAction("Index");
         //   }
            // store the input parameter using Viewbag
            ViewBag.skintypes = skintypes;

            return View();
;        }
    }
}
