using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
