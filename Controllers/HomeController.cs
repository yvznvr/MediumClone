using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediumClone.Models;
using Microsoft.AspNetCore.Identity;

namespace MediumClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository repo;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IPostRepository postRepository, UserManager<IdentityUser> userManager)
        {
            repo = postRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(repo.GetAllPosts());
        }

        [Route("{username}")]
        public async Task<IActionResult> PostsofUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("404 Sayfa Bulunamadı");
            var temp = repo.GetByUser(user);
            return View("Index", temp);
        }

        [Route("{username}/post/{id?}")]
        public IActionResult PostofUser(string username, int id)
        {
            return View(repo.GetPost(id));
        }

    }
}