using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Domain
{
    public class CartItem
    {
        public int ShoeId { get; set; }

        public string? ShoeName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string? ImageURL { get; set; }

        public decimal Total => this.Quantity * this.Price;

        public CartItem() { }

        public CartItem(Shoe shoe)
        {
            this.ShoeId = shoe.Id;
            this.ShoeName = $"{shoe.Brand} {shoe.Model}";
            this.Quantity = 1;
            this.Price = shoe.Price;
            this.ImageURL = shoe.ImageURL;
        }
    }
}
