// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingCartController.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the ShoppingCartController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
// ReSharper disable All
namespace CS.Controllers
{
    /* 
     * TODO
     * Wire up for Shopping Cart Sessions
     * Add Shopping Cart to the database if logged in
     * Redirect to Shopping Cart Home/Index Page after adding to cart
     * Create a continue shopping link
     * Have next and previous arrows for moving along the workflow of selecting shipping address & Billing address and payment information
     * Final order confirmation page and allow for printing of order confirmation.
     */
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Data;
    using Infrastructure;
    using Models.OrderViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : Controller
    {
        private readonly CandiContext _context;

        private List<CartItem> CartItems { get; set; }


        public ShoppingCartController(CandiContext candiContext)
        {
            _context = candiContext;
        }


        [HttpPost]
        public virtual async Task<IActionResult> AddItemToCart(int id, int quantity = 1)
        {
            await UpdateCartItems(id, quantity);
            return RedirectToAction("Index", "Products");
        }

        public virtual async Task<IActionResult> RemoveItemFromCart(int id)
        {

            await UpdateCartItems(id,0,"remove");
            return RedirectToAction("Index");
        }

        public virtual async Task<IActionResult> Clear()
        {
           await UpdateCartItems(0,0,"clear");
            return RedirectToAction("Index", "Products");
        }

        public virtual async Task<IActionResult> Index()
        {
            return  View(Globals.GetCart(HttpContext.Session).CartItems??new List<CartItem>());
        }

        [HttpPost]
        public virtual async Task<IActionResult> UpdateTotal(int id, string quantity)
        {
            await UpdateCartItems(id, (int) double.Parse(quantity),"update");
            return RedirectToAction("Index");
        }

        private async Task UpdateCartItems(int productId, int quantity, string action="")
        {

            var product = _context.Products.FirstOrDefault(p => p.ID == productId);
            var cart = Globals.GetCart(HttpContext.Session);
            CartItems = (List<CartItem>)(cart.CartItems ?? new List<CartItem>());
            var cartItem = CartItems.Where(p => p.Item.ID == productId).FirstOrDefault();

            if (product != null)
            {
                if (cartItem == null)
                {
                    CartItems.Add(
                        (cartItem = new CartItem
                             {
                                 Item = product,
                                 Quantity = quantity,
                                 UnitPrice = product.UnitPrice,
                                 Price = product.UnitPrice * 1,
                                 Coupon = "",
                                 DiscountPrice = 0
                             }));
                }
                else
                {
                    cartItem.Quantity = action.Length>1?quantity:cartItem.Quantity+quantity;
                }

                if (cartItem.Quantity == 0)
                {
                    CartItems.Remove(cartItem);
                }

                cart.CartItems = CartItems;

                if (action=="clear") cart.CartItems.Clear();

                Globals.SaveCart(HttpContext.Session, cart);
            }

        }
    }
}
