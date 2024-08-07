using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;

namespace CoreCVDb.Areas.Writer.Controllers
{
	
	
	[Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class DashboardWriterController : Controller
    {
        private readonly UserManager<WriteUsers> _userManager;

        public DashboardWriterController(UserManager<WriteUsers> userManager)
        {
            _userManager = userManager;
        }

        public async Task <IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v=values.Name+" "+values.Surname;
            // Weather API
            string api= "4640a85ae294ff72468476a13b5fdefd";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v6=document.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            ViewBag.v7=document.Descendants("city").ElementAt(0).Attribute("name").Value;
			//statics
			Context c=new Context();
            ViewBag.v1 = c.WriterMessages.Where(x=>x.Recevier == values.Email).Count(); 
            ViewBag.v2=c.Announcements.Count();
            ViewBag.v3= c.WriterMessages.Where(x => x.Sender == values.Email).Count();
            ViewBag.v4=c.Skills.Count();
            return View();
        }
    }
}
//https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=4640a85ae294ff72468476a13b5fdefd