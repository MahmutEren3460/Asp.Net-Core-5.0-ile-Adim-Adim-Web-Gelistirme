using CoreCVDb.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriteUsers> _userManager;

        public ProfileController(UserManager<WriteUsers> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureURL = values.ImageURL;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.ImageURL = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
