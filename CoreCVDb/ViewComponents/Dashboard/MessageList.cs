using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        MessageManager messageManager=new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            var values = messageManager.TGetbyid().OrderByDescending(x => x.MessageID).Take(4).ToList();
            return View(values);
        }
    }
}
