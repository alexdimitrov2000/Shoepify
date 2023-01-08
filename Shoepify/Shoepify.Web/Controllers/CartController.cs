using Microsoft.AspNetCore.Mvc;
using Shoepify.Domain;
using Shoepify.Infrastructure.Extensions;
using Shoepify.Services.Contracts;
using Shoepify.Web.Models.Cart;

namespace Shoepify.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoesService shoesService;

        public CartController(IShoesService shoesService)
        {
            this.shoesService = shoesService;
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

        public async Task<IActionResult> Add(int id)
        {
            Shoe? shoe = await this.shoesService.GetByIdAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem? cartItem = cart.Where(i => i.ShoeId == shoe?.Id).FirstOrDefault();

            if (cartItem == null && shoe != null)
            {
                cart.Add(new CartItem(shoe));
            }
            else if(cartItem != null)
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            return this.Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Decrease(int id)
        {
            List<CartItem>? cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem? cartItem = cart?.Where(i => i.ShoeId == id).FirstOrDefault();

            if (cartItem?.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart?.RemoveAll(i => i.ShoeId == id);
            }

            if (cart?.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return this.Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Remove(int id)
        {
            List<CartItem>? cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart?.RemoveAll(i => i.ShoeId == id);

            if (cart?.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return this.Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return this.RedirectToAction("All", "Shoes");
        }
    }
}
