using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Controllers
{

	public class SocialMediaController : Controller
	{
		SocialMediaManager social =new SocialMediaManager(new EfSocialMediaDal());
		public IActionResult Index()
		{
			var values = social.TGetbyid();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddSocialMedia()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddSocialMedia(SocialMedia p)
		{
			p.Status = true;
			social.TAdd(p);
			return RedirectToAction("Index");
		}
		//public IActionResult DeleteSocialMedia(int id)
		//{
		//	var values = social.TGetByID(id);
		//	social.TDelete(values);
		//	return RedirectToAction("Index");
		//}
		[HttpGet]
		public IActionResult EditSocialMedia(int id)
		{
			var values = social.TGetByID(id);
			return View(values);

		}
		[HttpPost]
		public IActionResult EditSocialMedia(SocialMedia p)
		{
            p.Status = true;
            social.TUpdate(p);
			return RedirectToAction("Index");
		}
        public IActionResult Aktif(int id)
		{
            var values = social.TGetByID(id);
			values.Status = true;
			social.TUpdate(values);
            return RedirectToAction("Index");
        }
        public IActionResult Pasif(int id)
        {
            var values = social.TGetByID(id);
            values.Status = false;
            social.TUpdate(values);
            return RedirectToAction("Index");
        }

    }
}
