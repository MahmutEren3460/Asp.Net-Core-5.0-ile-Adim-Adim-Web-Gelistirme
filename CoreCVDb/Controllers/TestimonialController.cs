using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var values =testimonialManager.TGetbyid(); 
            return View(values);
        }
        public IActionResult DeleteTestimonail(int id)
        {
            var values = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
		public IActionResult AddTestimonail()
		{
			return View();
		}
        [HttpPost]
		public IActionResult AddTestimonail(Testimonial p)
		{
            testimonialManager.TAdd(p);
			return RedirectToAction("Index");
		}

		[HttpGet]
        public IActionResult EditTestimonail(int id)
        {

            var values = testimonialManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTestimonail(Testimonial testimonial)
        {
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
    }
}
