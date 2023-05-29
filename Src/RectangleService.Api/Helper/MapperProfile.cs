using AutoMapper;

namespace RectangleService.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Infrastructure.Entities.Rectangle, Core.Models.Rectangle>();
        }
    }
}
