using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediumClone.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace MediumClone.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login obj)
        {
            if(ModelState.IsValid)
            {
                // Girilen kullanıcı adına sahip kullanıcı varse user değişkenine atıyoruz
                var user = await _userManager.FindByNameAsync(obj.username);

                // eğer kullanıcı varsa if içerisine giriyoruz
                if(user != null)
                {
                    // kullanıcı girişi yapıyoruz
                    var result = await _signInManager.PasswordSignInAsync(user, obj.password, false, false);

                    // eğer giriş ilemi başarılıysa anasayfaya yönlendiriyoruz
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                // böyle bir kullanıcı yoksa geriye hata döndürüyoruz
                // ilk parametre key ikinci parametre value
                ModelState.AddModelError("", "Kullanıcı Bulunamadı.");
                return View(obj);
            }
            return View(obj);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Login obj)
        {
            if(ModelState.IsValid)
            {
                // yeni bir kullanıcı nesnesi oluşturuyoruz
                var user = new IdentityUser()
                { UserName = obj.username };
                // oluşturulan kullanıcıyı parola(hash) ile birlikte kayıt ediyoruz
                var result = await _userManager.CreateAsync(user, obj.password);

                // kayıt işlemi başarılı ise Login sayfasına yönlendiriyoruz
                if(result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                return View(obj);
            }
            return View(obj);
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}