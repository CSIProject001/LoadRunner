// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingCartController.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the ShoppingCartController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CS.Data;
    using CS.Models.OrderViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ShoppingCartController : Controller
    {
        private readonly CandiContext _context;

        public ShoppingCartController(CandiContext context)
        {
            _context = context;    
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carts.ToListAsync());
        }

        // GET: ShoppingCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.Carts.SingleOrDefaultAsync(m => m.ID == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Coupon,DiscountPrice,Price,Quantity,UnitPrice")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingCart);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.Carts.SingleOrDefaultAsync(m => m.ID == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Coupon,DiscountPrice,Price,Quantity,UnitPrice")] ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartExists(shoppingCart.ID))
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
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.Carts.SingleOrDefaultAsync(m => m.ID == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingCart = await _context.Carts.SingleOrDefaultAsync(m => m.ID == id);
            _context.Carts.Remove(shoppingCart);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShoppingCartExists(int id)
        {
            return _context.Carts.Any(e => e.ID == id);
        }
    }
}
