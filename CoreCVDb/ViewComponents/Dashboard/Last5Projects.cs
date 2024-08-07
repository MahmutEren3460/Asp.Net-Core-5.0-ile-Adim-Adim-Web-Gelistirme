using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.ViewComponents.Dashboard
{
    public class Last5Projects : ViewComponent
    {
        PortfolioManager manager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values=manager.TGetbyid().OrderByDescending(x=>x.PortfolioID).Take(5).ToList();
            return View(values);
        }
    }
}
