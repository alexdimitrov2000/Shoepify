using Shoepify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
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

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0.0m;

        public string? ImageURL { get; set; }

        public Gender Gender { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<ShoeSize> Sizes { get; set; } = new List<ShoeSize>();

        public ICollection<ShoeColor> Colors { get; set; } = new List<ShoeColor>();
    }
}
