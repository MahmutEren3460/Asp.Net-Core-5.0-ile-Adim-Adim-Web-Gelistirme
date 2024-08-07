using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreCVDb.Controllers
{
    public class WriterUsersController : Controller
    {
        WriterUserManager manager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(manager.TGetbyid());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddUser(WriteUsers p)
        {
            manager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
