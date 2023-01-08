using Shoepify.Domain;

namespace Shoepify.Web.Models.Cart
{
    public class CartDetailsViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
