using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_CV.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {
        ExperienceManager ExManager = new ExperienceManager(new EfExperienceDal());
        public IViewComponentResult Invoke()
        {
            var values = ExManager.TGetbyid();
            return View(values);
        }
    }
}
