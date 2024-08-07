using CoreCVDb.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<WriteUsers> _signInManager;

        public LoginController(SignInManager<WriteUsers> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result=await _signInManager.PasswordSignInAsync(p.UserName, p.Password,true,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","DashboardWriter");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre yanlış");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
