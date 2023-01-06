using AutoMapper;
using Shoepify.Domain;
using Shoepify.Web.Areas.Administration.Models.Shoes;

namespace Shoepify.Web.Mapping
{
    public class ShoesProfile : Profile
    {
        public ShoesProfile()
        {
            CreateMap<ShoeCreateInputModel, Shoe>()
                .ForMember(dest => dest.Model, src => src.MapFrom(x => x.BrandModel));
        }
    }
}
