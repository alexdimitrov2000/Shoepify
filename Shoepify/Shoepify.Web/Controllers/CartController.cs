using Microsoft.AspNetCore.Mvc;
using Shoepify.Data;
using Shoepify.Domain;
using Shoepify.Infrastructure.Extensions;
using Shoepify.Web.Models.Cart;

namespace Shoepify.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoepifyContext context;

        public CartController(ShoepifyContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartDetailsViewModel cartVM = new CartDetailsViewModel()
            {
                CartItems= cart,
                TotalPrice = cart.Sum(i => i.Price * i.Quantity)
            };

            return View(cartVM);
        }
    }
}
