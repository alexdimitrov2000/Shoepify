namespace Shoepify.Domain
{
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
