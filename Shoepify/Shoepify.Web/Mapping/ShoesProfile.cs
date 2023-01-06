using AutoMapper;
using Shoepify.Domain;
using Shoepify.Web.Areas.Administration.Models.Shoes;
using Shoepify.Web.Models.Shoes;

namespace Shoepify.Web.Mapping
{
    public class ShoesProfile : Profile
    {
        public ShoesProfile()
        {
            CreateMap<ShoeCreateInputModel, Shoe>()
                .ForMember(dest => dest.Model, src => src.MapFrom(x => x.BrandModel));

            CreateMap<Shoe, ShoeViewModel>()
                .ForMember(dest => dest.Colors, src => src.MapFrom(x => x.Colors.Count));
        }
    }
}
