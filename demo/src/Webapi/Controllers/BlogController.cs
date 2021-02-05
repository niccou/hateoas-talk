using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult Get([FromQuery, Required(AllowEmptyStrings = true)]Author author)
        {
            if (author == new Author())
            {
                return Ok(_mapper.Map<IReadOnlyCollection<PostDto>>(_posts.Posts));
            }

            return Ok(_mapper.Map<IReadOnlyCollection<PostWithStateDto>>(_posts.PostsByAuthor(author)));
        }
    }
}
