using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager _portfoliomanager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            
            
            var values=_portfoliomanager.TGetbyid();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            
			return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
			PortfolioValidator rules = new PortfolioValidator();
            ValidationResult result = rules.Validate(portfolio);
            if (result.IsValid)
            {
                _portfoliomanager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
			return View();
		}
        public IActionResult DeletePortfolio(int id)
        {
            var values = _portfoliomanager.TGetByID(id);
            _portfoliomanager.TDelete(values);
			return RedirectToAction("Index");
		}
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            
            var values = _portfoliomanager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results=validations.Validate(portfolio);   
            if (results.IsValid) { 
                _portfoliomanager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
