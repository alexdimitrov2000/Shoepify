using System.ComponentModel.DataAnnotations;

namespace Shoepify.Web.Areas.Administration.Models.Categories
{
    public class CategoryCreateInputModel
    {
        [Required]
        public string? Name { get; set; }
    }
}
