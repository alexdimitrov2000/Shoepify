namespace Shoepify.Domain
{
    public class Size
    {
        public int Id { get; set; }

        public double SizeInCm { get; set; }

        public double SizeEU { get; set; }

        public double SizeUS { get; set; }

        public virtual ICollection<ShoeSize> Shoes { get; set; } = new List<ShoeSize>();
    }
}
