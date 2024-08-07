using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Areas.Writer.ViewComponents
{
	public class Navbar : ViewComponent
	{
		private readonly UserManager<WriteUsers> _userManager;

		public Navbar(UserManager<WriteUsers> userManager)
		{
			_userManager = userManager;
		}

		public async Task <IViewComponentResult> InvokeAsync()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.vPicture = values.ImageURL;
			return View();
		}
	}
}
