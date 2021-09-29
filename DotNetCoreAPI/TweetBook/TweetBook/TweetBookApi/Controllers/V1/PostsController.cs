using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookApi.Contracts.V1;
using TweetBookApi.Contracts.V1.Requests;
using TweetBookApi.Contracts.V1.Responses;
using TweetBookApi.Domain;

namespace TweetBookApi.Controllers.V1
{
    public class PostsController : Controller
    {
        public PostsController()
        {
           
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid id)
        {
            var post = _posts.SingleOrDefault(x => x.Id == id);

            if (post == null) return NotFound();
            
            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] PostRequest postRequest)
        {
            var post = new Post { Id = postRequest.Id };
            if (post.Id != Guid.Empty)
            {
                post.Id = Guid.NewGuid();
            }
            _posts.Add(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("id", post.Id.ToString());
            var response = new PostResponse { Id = post.Id };
            return Created(locationUrl, response);
        }
    }
}
