using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.ViewComponents.SocialMedia
{

   
    public class SocialMediaList:ViewComponent
    {
		SocialMediaManager social = new SocialMediaManager(new EfSocialMediaDal());
		public IViewComponentResult Invoke()
        {
            var values = social.TGetbyid().Where(s => s.Status==true).ToList(); 
            return View(values);
        }

    }
}
