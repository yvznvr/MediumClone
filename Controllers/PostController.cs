using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediumClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediumClone.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            if(ModelState.IsValid)
            {
                _postRepository.AddPost(post);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public IActionResult RemovePost(int id)
        {
            try
            {
                _postRepository.RemovePost(id);
            }
            catch(ArgumentNullException e)
            {
                return NotFound("404 Sayfa Bulunamadı");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult UpdatePost(int id)
        {
            var post = _postRepository.GetPost(id);
            if (post == null) return NotFound("404 Sayfa Bulunamadı");
            return View(post);
        }

        [HttpPost]
        public IActionResult UpdatePost(int id, Post post)
        {
            if(ModelState.IsValid)
            {
                _postRepository.UpdatePost(id, post);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}