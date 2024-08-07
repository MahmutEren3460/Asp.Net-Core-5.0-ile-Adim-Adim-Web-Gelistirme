using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.ViewComponents.Portfolio
{
	public class PortfolioList:ViewComponent
	{
		PortfolioManager portfolioManager=new PortfolioManager(new EfPortfolioDal());
		public IViewComponentResult Invoke()
		{
			var values=portfolioManager.TGetbyid();
			return View(values);
		}
	}
}
