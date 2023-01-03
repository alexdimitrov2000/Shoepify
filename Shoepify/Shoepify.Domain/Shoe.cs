using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Domain
{
    public class Shoe
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int Size { get; set; }

        public decimal Price { get; set; }
    }
}
