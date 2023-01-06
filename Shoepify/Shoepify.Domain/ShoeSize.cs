using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Domain
{
    public class ShoeSize
    {
        public int ShoeId { get; set; }
        
        public virtual Shoe? Shoe { get; set; }

        public int SizeId { get; set; }

        public virtual Size? Size { get; set; }
    }
}
