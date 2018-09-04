using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediumClone.Models;


namespace MediumClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository repo;

        public HomeController(IPostRepository postRepository)
        {
            repo = postRepository;
        }
        public IActionResult Index()
        {
            var obj = new Post
            {
                title = "İlk Blog Başlığı",
                content = "İlk blog içeriği"
            };
            repo.AddPost(obj);
            var obj2 = new Post
            {
                title = "İkinci Blog Başlığı",
                content = "İkinci blog içeriği"
            };
            repo.AddPost(obj2);
            var obj3 = repo.GetPost(16);
            ViewData["secilenNesne"] = obj3;

            return View(repo.GetAllPosts());
        }

    }
}