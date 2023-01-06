using AutoMapper;
using Shoepify.Domain;
using Shoepify.Web.Areas.Administration.Models.Categories;

namespace Shoepify.Web.Mapping
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CategoryCreateInputModel, Category>();
        }
    }
}
