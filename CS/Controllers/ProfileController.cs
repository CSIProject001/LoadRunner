// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileController.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the ProfileController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CS.Controllers
{
    using System.Collections.Generic;

    using Models.DBModels;
    using Models.ProfileViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var address = new Address
            {
                Category = ProfileEnumerations.AddressCategories[0],
                City = "San Diego",
                Country = "USA",
                ID = 1,
                Line1 = "New Rochelle Way",
                State = "CA",
                Zip = "92127"
            };
            var address2 = new Address
            {
                Category = ProfileEnumerations.AddressCategories[1],
                City = "Irvine",
                Country = "USA",
                ID = 2,
                Line1 = "423 Contessa",
                State = "CA",
                Zip = "92620"
            };
            var address3 = new Address
            {
                Category = ProfileEnumerations.AddressCategories[2],
                City = "Irvine",
                Country = "USA",
                ID = 3,
                Line1 = "423 Contessa",
                State = "CA",
                Zip = "92620"
            };
            var address4= new Address
            {
                Category = ProfileEnumerations.AddressCategories[4],
                City = "Irvine",
                Country = "USA",
                ID = 4,
                Line1 = "423 Contessa",
                State = "CA",
                Zip = "92620"
            };
            var p1 = new Phone
                         {
                             Category = ProfileEnumerations.PhoneCategories[0],
                             ID = 1,
                             PhoneNumber = "609-273-8175"
                         };
            var p2 = new Phone
            {
                Category = ProfileEnumerations.PhoneCategories[1],
                ID = 1,
                PhoneNumber = "609-716-8918"
            };
            var p3 = new Phone
            {
                Category = ProfileEnumerations.PhoneCategories[2],
                ID = 1,
                PhoneNumber = "609-123-2345"
            };
            var p4 = new Phone
            {
                Category = ProfileEnumerations.PhoneCategories[3],
                ID = 1,
                PhoneNumber = "609-456-7890"
            };
            var c = new CustomerViewModel
                        {
                            FirstName = "Mani", LastName = "Aiyer", Addresses = new List<Address> { address, address2, address3, address4 },
                            Phones = new List<Phone> { p1, p2, p3, p4 }
                        };
            
            return View(c);
        }

        [HttpPost]
        public IActionResult Update(CustomerViewModel c)
        {
            return View();
        }
    }
}
