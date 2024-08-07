using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreCVDb.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager manager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(manager.TGetbyid());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            manager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetById(int ExprerienceID)
        {
            var v = manager.TGetByID(ExprerienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var v = manager.TGetByID(id);
            manager.TDelete(v);
            return NoContent();
        }
    }
}
