// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomersController.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the CustomersController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CS.Models;
using Microsoft.AspNetCore.Identity;

namespace CS.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Data;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Models.DBModels;

    [Authorize]
    public class CustomersController : Controller
    {
        private readonly CandiContext context;

        private UserManager<ApplicationUser> UserManager { get; set; }

        public CustomersController(CandiContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.UserManager = userManager;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            
            return View(await context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var customer = await this.context.Customers.SingleOrDefaultAsync(m => m.UserId == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DOB,FirstName,LastName,Organization,UserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                this.context.Add(customer);
                await this.context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }


        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await this.context.Customers.SingleOrDefaultAsync(m => m.UserId == id);
            if (customer == null)
            {
                return NotFound();
            }
            if (customer.Phones == null)
            {
                customer.Phones = new List<Phone>();
            }
            if (customer.Addresses == null)
            {
                customer.Addresses= new List<Address>();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DOB,FirstName,LastName,Organization,UserId")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(customer);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await this.context.Customers.SingleOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await this.context.Customers.SingleOrDefaultAsync(m => m.ID == id);
            this.context.Customers.Remove(customer);
            await this.context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomerExists(int id)
        {
            return this.context.Customers.Any(e => e.ID == id);
        }
    }
}
