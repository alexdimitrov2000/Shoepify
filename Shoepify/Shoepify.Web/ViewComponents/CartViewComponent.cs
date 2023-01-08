using Microsoft.AspNetCore.Mvc;
using Shoepify.Domain;
using Shoepify.Infrastructure.Extensions;
using Shoepify.Web.Models.Cart;
using System.Collections.Generic;

namespace Shoepify.Web.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem>? cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartViewModel? cartVM;

            if (cart == null || cart.Count == 0)
            {
                cartVM = null;
            }
            else
            {
                cartVM = new CartViewModel()
                {
                    NumberOfItems = cart.Sum(i => i.Quantity),
                    TotalPrice = cart.Sum(i => i.Quantity * i.Price)
                };
            }

            return View(cartVM);
        }
    }
}
