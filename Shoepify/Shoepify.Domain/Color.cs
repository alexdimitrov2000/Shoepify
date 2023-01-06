using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Domain
{
    public class Color
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Hex { get; set; }

        public virtual ICollection<ShoeColor> Shoes { get; set; } = new List<ShoeColor>();
    }
}
