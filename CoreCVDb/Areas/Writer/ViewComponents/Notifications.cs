using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Areas.Writer.ViewComponents
{
	public class Notifications:ViewComponent
	{
		AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
		public IViewComponentResult Invoke()
		{
			var values= announcementManager.TGetbyid().OrderByDescending(x=>x.ID).Take(3).ToList();
			return View(values);
		}
	}
}
