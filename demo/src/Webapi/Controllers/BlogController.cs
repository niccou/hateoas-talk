using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApi.Controllers.Shared;
using WebApi.Core.Blog;
using WebApi.Core.Models;
using WebApi.Models;
using WebApi.Models.Shared;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : RestControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IReadPosts _blog;
        private readonly IMapper _mapper;

        public BlogController(ILogger<BlogController> logger, IActionDescriptorCollectionProvider provider, IReadPosts blog, IMapper mapper)
            : base(provider)
        {
            _logger = logger;
            _blog = blog;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(BlogController))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ICollection<PostSummaryDto>>))]
        public IActionResult Get()
        {
            var getBlog = _blog.GetPosts();

            if (!getBlog.Success)
            {
                _logger.LogWarning($"{nameof(IReadPosts)}.{nameof(IReadPosts.GetPosts)} failed !!!!");
                return NoContent();
            }

            var response = ApiResponse<ICollection<PostSummaryDto>>
                .Create(MapToSummaries(getBlog.Result).ToList());

            response.Add(UrlLink("summaries", nameof(BlogController), null));

            return Ok(response);
        }

        private IEnumerable<PostSummaryDto> MapToSummaries(IReadOnlyCollection<Post>? posts)
        {
            if (posts is null)
            {
                yield break;
            }

            foreach (var post in posts)
            {
                var summary = _mapper.Map<PostSummaryDto>(post);
                summary.Add(UrlLink("detail", nameof(PostsController), new { id = post.Id }));
                if (post.State == Post.PostState.Draft)
                {
                    summary.Add(UrlLink("publish", nameof(PostsController.Publish), new { id = post.Id }));
                }
                if (post.State == Post.PostState.Published)
                {
                    summary.Add(UrlLink("unpublish", nameof(PostsController.Unpublish), new { id = post.Id }));
                }

                yield return summary;
            }
        }
    }
}
