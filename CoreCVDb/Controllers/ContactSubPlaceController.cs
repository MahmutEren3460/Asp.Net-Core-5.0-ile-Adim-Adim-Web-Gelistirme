using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Controllers
{
	public class ContactSubPlaceController : Controller
	{
		ContactManager contactManager = new ContactManager(new EfContactDal());

		[HttpGet]
		public IActionResult Index()
		{

			var values = contactManager.TGetByID(1);
			return View(values);
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contactManager.TUpdate(contact);
			return RedirectToAction("Index");
		}
	}
}
