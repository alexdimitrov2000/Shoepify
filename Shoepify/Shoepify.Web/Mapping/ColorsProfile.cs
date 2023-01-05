using AutoMapper;
using Shoepify.Domain;
using Shoepify.Web.Areas.Administration.Models.Colors;

namespace Shoepify.Web.Mapping
{
    public class ColorsProfile : Profile
    {
        public ColorsProfile()
        {
            CreateMap<ColorCreateInputModel, Color>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name));
        }
    }
}
