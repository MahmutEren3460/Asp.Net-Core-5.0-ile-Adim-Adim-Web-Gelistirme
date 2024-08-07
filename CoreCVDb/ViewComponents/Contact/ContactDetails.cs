using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_CV.ViewComponents.Contact
{
    public class ContactDetails:ViewComponent
    {
		ContactManager contactManager=new ContactManager(new EfContactDal());
		public IViewComponentResult Invoke()
		{
			var values = contactManager.TGetbyid();
			return View(values);
		}
	}
}
