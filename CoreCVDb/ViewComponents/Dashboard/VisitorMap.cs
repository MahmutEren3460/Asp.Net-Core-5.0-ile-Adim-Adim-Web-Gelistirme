using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.ViewComponents.Dashboard
{
	public class VisitorMap : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
