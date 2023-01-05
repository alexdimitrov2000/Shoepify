using System.ComponentModel.DataAnnotations;

namespace Shoepify.Web.Areas.Administration.Models.Colors
{
    public class ColorCreateInputModel
    {
        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Hex")]
        public string? Hex { get; set; }
    }
}
