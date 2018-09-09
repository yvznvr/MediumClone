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
            return View(repo.GetAllPosts());
        }

    }
}