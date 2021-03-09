using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
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
    public class PostsController : RestControllerBase
    {
        public PostsController(ILogger<PostsController> logger, IActionDescriptorCollectionProvider provider, IReadPosts blog, IPublishPost publisher, IMapper mapper) : base(provider)
        {
            _logger = logger;
            _blog = blog;
            _publisher = publisher;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(PostsController))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<PostDetailDto>))]
        public IActionResult Get([FromQuery] string id)
        {
            _logger.LogDebug($"Call {nameof(Get)} for id {id}");
            var getPost = _blog.GetPostsById(id);

            if (!getPost.Success || getPost.Result is null)
            {
                return NotFound();
            }

            var response = ApiResponse<PostDetailDto>
                .Create(MapToDetail(getPost.Result));

            response.Add(UrlLink("summaries", nameof(BlogController), null));

            return Ok(response);
        }

        [HttpPut("Publish", Name = nameof(Publish))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<PostDetailDto>))]
        public IActionResult Publish([FromQuery] string id)
        {
            _logger.LogDebug($"Call {nameof(Publish)} for id {id}");
            var getPost = _blog.GetPostsById(id);

            if (!getPost.Success || getPost.Result is null)
            {
                return BadRequest();
            }

            _publisher.Publish(id);

            return Get(id);
        }

        [HttpPut("Unpublish", Name = nameof(Unpublish))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<PostDetailDto>))]
        public IActionResult Unpublish([FromQuery] string id)
        {
            _logger.LogDebug($"Call {nameof(Unpublish)} for id {id}");
            var getPost = _blog.GetPostsById(id);

            if (!getPost.Success || getPost.Result is null)
            {
                return BadRequest();
            }

            _publisher.Unpublish(id);

            return Get(id);
        }

        private readonly IReadPosts _blog;
        private readonly ILogger<PostsController> _logger;
        private readonly IMapper _mapper;
        private readonly IPublishPost _publisher;

        private PostDetailDto MapToDetail(Post post)
        {
            var detail = _mapper.Map<PostDetailDto>(post);

            detail.Add(UrlLink("detail", nameof(PostsController), new { id = post.Id }));

            if (post.State == Post.PostState.Draft)
            {
                detail.Add(UrlLink("publish", nameof(Publish), new { id = post.Id }));
            }

            if (post.State == Post.PostState.Published)
            {
                detail.Add(UrlLink("unpublish", nameof(Unpublish), new { id = post.Id }));
            }

            return detail;
        }
    }
}