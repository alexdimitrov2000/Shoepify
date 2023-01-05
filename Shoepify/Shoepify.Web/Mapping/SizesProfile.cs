using AutoMapper;
using Shoepify.Domain;
using Shoepify.Web.Areas.Administration.Models.Sizes;

namespace Shoepify.Web.Mapping
{
    public class SizesProfile : Profile
    {
        public SizesProfile()
        {
            CreateMap<SizeCreateInputModel, Size>();
        }
    }
}
