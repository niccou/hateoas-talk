using AutoMapper;

namespace WebApi.Models.Mappers
{
    public class PostDetailProfile : Profile
    {
        public PostDetailProfile()
        {
            CreateMap<Core.Models.Post, PostDetailDto>()
                .IncludeBase<Core.Models.Post, PostSummaryDto>()
                .ForMember(_ => _.State, x => x.MapFrom(_ => _.State.ToString()));
        }
    }
}
