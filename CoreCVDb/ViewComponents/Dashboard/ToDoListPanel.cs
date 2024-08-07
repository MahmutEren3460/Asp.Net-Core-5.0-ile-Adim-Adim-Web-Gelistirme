using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.ViewComponents.Dashboard
{
	public class ToDoListPanel : ViewComponent
	{
		ToDoListManager manager = new ToDoListManager(new EfToDoListDal());
		public IViewComponentResult Invoke()
		{
			var values = manager.TGetbyid().OrderByDescending(x => x.ID).Take(5).ToList();
			return View(values);
		}
	}
}
