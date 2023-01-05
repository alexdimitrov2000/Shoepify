using System.ComponentModel.DataAnnotations;

namespace Shoepify.Web.Areas.Administration.Models.Sizes
{
    public class SizeCreateInputModel
    {
        [Required]
        [Display(Name = "Size in cm")]
        public double SizeInCm { get; set; }

        [Required]
        [Display(Name = "Size EU")]
        public double SizeEU { get; set; }

        [Required]
        [Display(Name = "Size US")]
        public double SizeUS { get; set; }
    }
}
