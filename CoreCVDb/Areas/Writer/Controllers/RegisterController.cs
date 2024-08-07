using CoreCVDb.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CoreCVDb.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriteUsers> _userManager;

        public RegisterController(UserManager<WriteUsers> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            WriteUsers w = new WriteUsers()
            {
                Name = p.Name,
                Surname = p.SurName,
                Email = p.Mail,
                UserName = p.UserName,
                ImageURL = p.ImageURL
            };
            if (p.ConfirmPassword == p.Password)
            {
                var result = await _userManager.CreateAsync(w, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
// 123456aA*
