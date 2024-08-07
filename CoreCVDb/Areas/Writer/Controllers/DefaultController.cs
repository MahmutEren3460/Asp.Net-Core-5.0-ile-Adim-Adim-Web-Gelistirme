using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Areas.Writer.Controllers
{
	[Area("Writer")]
	[Authorize]
	public class DefaultController : Controller
	{
		AnnouncementManager manager= new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
		{
			var values=manager.TGetbyid()/*.OrderByDescending(x=>x.ID).ToList()*/;
			return View(values);
		}
		[HttpGet]
		public IActionResult AnnouncementDetails(int id)
		{
			Announcement announcement = manager.TGetByID(id) ;
			return View(announcement);
		}
	}
}
