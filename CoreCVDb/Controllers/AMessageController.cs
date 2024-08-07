using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Controllers
{
    public class AMessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = messageManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = messageManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AMessageDetails(int id)
        {
            var values = messageManager.TGetByID(id);
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var values = messageManager.TGetByID(id);
            messageManager.TDelete(values);
            if (values.SenderName != null)

            {

                return RedirectToAction("SenderMessageList");

            }
            return RedirectToAction("ReceiverMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageAdd()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageAdd(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			Context c = new Context();
			var usernamesurname = c.Users.Where(x => x.Email == p.Recevier).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
			p.RecevierName = usernamesurname;
			messageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
