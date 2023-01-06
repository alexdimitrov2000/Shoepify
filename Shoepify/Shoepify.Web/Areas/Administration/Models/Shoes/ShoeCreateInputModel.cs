using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shoepify.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shoepify.Web.Areas.Administration.Models.Shoes
{
    public class ShoeCreateInputModel
    {
        [Required]
        public string? Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string? BrandModel { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string? ImageURL { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public ICollection<int>? ShoeSizes { get; set; }

        public ICollection<int>? ShoeColors { get; set; }
    }
}
