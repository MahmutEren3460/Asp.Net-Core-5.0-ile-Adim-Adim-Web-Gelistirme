using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreCVDb.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Moderator")]
    public class DashboardController : Controller
	{
		public IActionResult Index()
		{
            return View();
		}
	}
}
