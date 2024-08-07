using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList :ViewComponent
    {
        WriterMessageManager writer = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var values = writer.GetListReceiverMessage(p).OrderByDescending(x => x.WriterMessageID).Take(3).ToList();
            return View(values);
        }
    }
}
