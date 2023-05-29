using AutoMapper;

namespace RectangleService.Api.Helper
{
    /// <summary>
    /// MapperProfile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperProfile"/> class.
        /// </summary>
        public MapperProfile() 
        {
            CreateMap<Infrastructure.Entities.Rectangle, Core.Models.Rectangle>();
        }
    }
}
