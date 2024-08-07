using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Controllers
{
	public class AdminMessageController : Controller
	{
		MessageManager messageManager= new MessageManager(new EfMessageDal());
		public IActionResult Index()
		{
			var values = messageManager.TGetbyid();
			return View(values);
		}
		public IActionResult Delete(int id) 
		{
			var values =messageManager.TGetByID(id);
			messageManager.TDelete(values);
			return RedirectToAction("Index");
		}
		public IActionResult Details(int id) 
		{
			var values = messageManager.TGetByID(id);
			return View(values);
		}
	}
}
