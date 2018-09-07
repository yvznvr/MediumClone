using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediumClone.Models
{
    public class PostRepository: IPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddPost(Post post)
        {
            _appDbContext.posts.Add(post);
            _appDbContext.SaveChanges();
        }

        public List<Post> GetAllPosts()
        {
            return _appDbContext.posts.ToList<Post>();
        }

        public Post GetPost(int id)
        {
            Post temp = _appDbContext.posts.FirstOrDefault(i => i.id == id);
            return temp;
        }

        public void RemovePost(int id)
        {
            Post temp = _appDbContext.posts.FirstOrDefault(i => i.id == id);
            _appDbContext.posts.Remove(temp);
            _appDbContext.SaveChanges();
        }

        public void UpdatePost(int id, Post post)
        {
            var temp = GetPost(id);
            temp.title = post.title;
            temp.content = post.content;
            _appDbContext.Update(temp);
            _appDbContext.SaveChanges();
        }
    }
}
