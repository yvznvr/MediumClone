using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediumClone.Models
{
    public class PostRepository: IPostRepository
    {
        List<Post> posts = new List<Post>();

        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return posts;
        }

        public Post GetPost(int id)
        {
            Post temp = posts.FirstOrDefault(i => i.id == id);
            return temp;
        }

        public void RemovePost(int id)
        {
            Post temp = posts.FirstOrDefault(i => i.id == id);
            posts.Remove(temp);
        }
    }
}
