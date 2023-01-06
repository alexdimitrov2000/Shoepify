using Shoepify.Domain.Enums;

namespace Shoepify.Web.Models.Shoes
{
    public class ShoeDetailsViewModel
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? ImageURL { get; set; }

        public string? Category { get; set; }

        public Gender Gender { get; set; }

        public List<string>? Colors { get; set; }

        public List<double>? Sizes { get; set; }
    }
}
