using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookApi.Domain;

namespace TweetBookApi.Services
{
    public interface IPostService
    {
        IList<Post> GetPosts();

        Post GetPostById(Guid id);
    }

    public class PostService : IPostService
    {
        private readonly IList<Post> _posts;
        public PostService()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name{i}"
                });
            }
        }
        public Post GetPostById(Guid id)
        {
            return _posts.SingleOrDefault(x => x.Id == id);
        }

        public IList<Post> GetPosts()
        {
            return _posts;
        }
    }
}
