// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Controllers
{
    using Infrastructure;

    using Microsoft.AspNetCore.Mvc;

    using Models.OrderViewModels;

    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            HttpContext.Session.Set("Cart", new ShoppingCart());
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Company()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
