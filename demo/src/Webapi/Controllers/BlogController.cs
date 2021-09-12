using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using WebApi.Controllers.Shared;
using WebApi.Core.Blog;
using WebApi.Core.Models;
using WebApi.Models;
using WebApi.Models.Shared;

namespace WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
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

        [MapToApiVersion("1")]
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

            response.Add(UrlLink("summaries", nameof(BlogController)));

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

                dynamic postId = new ExpandoObject();
                postId.id = post.Id;

                summary.Add(UrlLink("detail", nameof(PostsController), postId));
                if (post.State == Post.PostState.Draft)
                {
                    summary.Add(UrlLink("publish", nameof(PostsController.Publish), postId));
                }
                if (post.State == Post.PostState.Published)
                {
                    summary.Add(UrlLink("unpublish", nameof(PostsController.Unpublish), postId));
                }

                yield return summary;
            }
        }
    }
}
