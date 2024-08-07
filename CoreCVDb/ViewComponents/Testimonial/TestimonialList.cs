using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_CV.ViewComponents.Testimonial
{
    public class TestimonialList:ViewComponent
    {
        TestimonialManager TestimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values = TestimonialManager.TGetbyid();
            return View(values);
        }
    }
}
