using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediumClone.Models
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        Post GetPost(int id);
        List<Post> GetAllPosts();
        void RemovePost(int id);
        void UpdatePost(int id, Post post);
    }
}
