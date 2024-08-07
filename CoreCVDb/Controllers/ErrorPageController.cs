using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Error404()
        {
            return View();
        }
    }
}
