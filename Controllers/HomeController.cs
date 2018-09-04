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
        public IActionResult Index()
        {
            PostRepository repo = new PostRepository();
            var obj = new Post
            {
                id = 1,
                title = "İlk Blog Başlığı",
                content = "İlk blog içeriği"
            };
            repo.AddPost(obj);
            var obj2 = new Post
            {
                id = 2,
                title = "İkinci Blog Başlığı",
                content = "İkinci blog içeriği"
            };
            repo.AddPost(obj2);
            var obj3 = repo.GetPost(1);
            ViewData["secilenNesne"] = obj3;

            return View(repo.GetAllPosts());
        }

    }
}