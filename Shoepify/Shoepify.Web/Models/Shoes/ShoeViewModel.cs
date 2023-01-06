namespace Shoepify.Web.Models.Shoes
{
    public class ShoeViewModel
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public decimal Price { get; set; }

        public string? ImageURL { get; set; }

        public int Colors { get; set; }
    }
}
