using AutoMapper;

namespace WebApi.Models.Mappers
{
    public class PostSummaryProfile : Profile
    {
        public PostSummaryProfile()
        {
            CreateMap<Core.Models.Post, PostSummaryDto>()
                .ForMember(_ => _.Author, x => x.MapFrom(_ => _.Author.Name));
        }
    }
}
