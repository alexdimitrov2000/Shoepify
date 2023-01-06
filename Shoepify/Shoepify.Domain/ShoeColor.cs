using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Domain
{
    public class ShoeColor
    {
        public int ShoeId { get; set; }
        
        public virtual Shoe? Shoe { get; set; }

        public int ColorId { get; set; }
        
        public virtual Color? Color { get; set; }
    }
}
