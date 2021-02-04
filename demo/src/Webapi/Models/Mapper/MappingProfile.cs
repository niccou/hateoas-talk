using AutoMapper;
using WebApi.Core.Models;

namespace WebApi.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(_ => _.Author, x => x.MapFrom(_ => _.Author.Name));
        }
    }
}
