// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductController.cs" company="CandiSyrup">
//   VirtualHeights
// </copyright>
// <summary>
//   Defines the ProductController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Controllers
{
    using System.Collections.Generic;

    using CS.Models;
    using CS.Models.ProductViewModels;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;

    public class ProductController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;

        private UserManager<ApplicationUser> _userManager;



        public ProductController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["UserName"] = this._userManager.GetUserName(this.HttpContext.User);
            var p = new List<Product>
                        {
                            new Product
                                {
                                    CategoryId = 1,
                                    ID = 1,
                                    ImageName = "~/images/Blanc.jpg",
                                    IsActive = true,
                                    Name = "Blanc",
                                    QuantityPerUnit = "100 per box",
                                    ReOrderLevel = 50,
                                    UnitPrice = 100M,
                                    UnitsInOrder = 20,
                                    UnitsInStock = 80,
                                },
                            new Product
                                {
                                    CategoryId = 1,
                                    ID = 2,
                                    ImageName = "~/images/BrunFonce.jpg",
                                    IsActive = true,
                                    Name = "Brun Fonce",
                                    QuantityPerUnit = "100 per box",
                                    ReOrderLevel = 50,
                                    UnitPrice = 100M,
                                    UnitsInOrder = 20,
                                    UnitsInStock = 80,
                                },
                            new Product
                                {
                                    CategoryId = 1,
                                    ID = 3,
                                    ImageName = "~/images/BrunLeger.jpg",
                                    IsActive = true,
                                    Name = "Brun Leger",
                                    QuantityPerUnit = "100 per box",
                                    ReOrderLevel = 50,
                                    UnitPrice = 100M,
                                    UnitsInOrder = 20,
                                    UnitsInStock = 80,
                                },
                            new Product
                                {
                                    CategoryId = 1,
                                    ID = 4,
                                    ImageName = "~/images/d-180.jpg",
                                    IsActive = true,
                                    Name = "D-180",
                                    QuantityPerUnit = "100 per box",
                                    ReOrderLevel = 50,
                                    UnitPrice = 100M,
                                    UnitsInOrder = 20,
                                    UnitsInStock = 80,
                                },
                            new Product
                                {
                                    CategoryId = 1,
                                    ID = 5,
                                    ImageName = "~/images/d-90.jpg",
                                    IsActive = true,
                                    Name = "D-90",
                                    QuantityPerUnit = "100 per box",
                                    ReOrderLevel = 50,
                                    UnitPrice = 100M,
                                    UnitsInOrder = 20,
                                    UnitsInStock = 80,
                                },
                            new Product
                                {
                                    CategoryId = 1,
                                    ID = 6,
                                    ImageName = "~/images/d-45.jpg",
                                    IsActive = true,
                                    Name = "D-45",
                                    QuantityPerUnit = "100 per box",
                                    ReOrderLevel = 50,
                                    UnitPrice = 100M,
                                    UnitsInOrder = 20,
                                    UnitsInStock = 80,
                                },
                            new Product
                                {
                                    CategoryId = 1,
                                    ID = 7,
                                    ImageName = "~/images/golden.jpg",
                                    IsActive = true,
                                    Name = "Golden",
                                    QuantityPerUnit = "100 per box",
                                    ReOrderLevel = 50,
                                    UnitPrice = 100M,
                                    UnitsInOrder = 20,
                                    UnitsInStock = 80,
                                },
                            new Product
                                {
                                    CategoryId = 1,
                                    ID = 8,
                                    ImageName = "~/images/simplicity.jpg",
                                    IsActive = true,
                                    Name = "Simplicity",
                                    QuantityPerUnit = "100 per box",
                                    ReOrderLevel = 50,
                                    UnitPrice = 100M,
                                    UnitsInOrder = 20,
                                    UnitsInStock = 80,
                                },
                        };

            return this.View("Products", p);
        }

    }
}