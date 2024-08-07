using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_CV.ViewComponents.Feature
{
    public class FeatureList:ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values=featureManager.TGetbyid();
            return View(values);
        }
    }
}
