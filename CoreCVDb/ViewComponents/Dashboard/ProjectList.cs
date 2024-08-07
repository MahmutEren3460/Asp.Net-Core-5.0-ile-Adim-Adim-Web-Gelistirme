using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.ViewComponents.Dashboard
{
    public class ProjectList:ViewComponent
    {
        PortfolioManager manager=new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values=manager.TGetbyid();
            return View(values);
        }
    }
}
