// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Globals.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the Globals type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Controllers;

    using CS.Data;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Models.OrderViewModels;

    public static class Globals
    {
        public static IActionResult RedirectActionResult(Controller controller, string returnUrl)
        {
            
            if (controller.Url.IsLocalUrl(returnUrl))
            {
                return controller.Redirect(returnUrl);
            }
            else
            {
                return controller.RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public static ShoppingCart GetCart(ISession session)
        {
            var cart = session.Get<ShoppingCart>("Cart") ?? new ShoppingCart();
            return cart;
        }

        public static void SaveCart(ISession session, ShoppingCart cart)
        {

            session.Set("Cart", cart);
        }

        public static List<CartItem> UpdateCartItems(CandiContext ctx, HttpContext current, int productId, int quantity, string action = "")
        {

            var product = ctx.Products.FirstOrDefault(p => p.ID == productId);
            var cart = GetCart(current.Session);
            var cartItems = (List<CartItem>)(cart.CartItems ?? new List<CartItem>());
            var cartItem = cartItems.FirstOrDefault(p => p.Item.ID == productId);

            if (product == null)
            {
                return cartItems;
            }

            if (cartItem == null)
            {
                cartItems.Add(
                    cartItem = new CartItem
                                   {
                                       Item = product,
                                       Quantity = quantity,
                                       UnitPrice = product.UnitPrice,
                                       Price = product.UnitPrice * 1,
                                       Coupon = string.Empty,
                                       DiscountPrice = 0
                                   });
            }
            else
            {
                cartItem.Quantity = action.Length > 1 ? quantity : cartItem.Quantity + quantity;
            }

            if (cartItem.Quantity == 0)
            {
                cartItems.Remove(cartItem);
            }

            cart.CartItems = cartItems;

            if (action == "clear")
            {
                cart.CartItems.Clear();
            }

            SaveCart(current.Session, cart);
            return cartItems;

        }
    }
}
