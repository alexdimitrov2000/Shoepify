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

            CreateMap<Shoe, ShoeDetailsViewModel>()
                .ForMember(dest => dest.Category, src => src.MapFrom(x => x.Category.Name))
                .ForMember(dest => dest.Colors, src => src.MapFrom(x => x.Colors.Select(c => c.Color.Hex)))
                .ForMember(dest => dest.Sizes, src => src.MapFrom(x => x.Sizes.Select(s => s.Size.SizeEU)));
        }
    }
}
