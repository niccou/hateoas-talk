using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Core.Blog;
using WebApi.Core.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IReadPosts _posts;
        private readonly IMapper _mapper;

        public BlogController(IReadPosts posts, IMapper mapper)
        {
            _posts = posts;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IReadOnlyCollection<PostDto>>(_posts.Posts));
        }
    }
}
