using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCVDb.Areas.Writer.Controllers
{
	[Area("Writer")]
	[Route("Writer/Message")]
	public class MessageController : Controller
	{ 
		WriterMessageManager manager=new WriterMessageManager(new EfWriterMessageDal());

		private readonly UserManager<WriteUsers> _usermanager;

		public MessageController(UserManager<WriteUsers> usermanager)
		{
			_usermanager = usermanager;
		}
		[Route("")]
		[Route("ReceiverMessage")]
		public async Task <IActionResult> ReceiverMessage(string p)
		{
			var values = await _usermanager.FindByNameAsync(User.Identity.Name);
			p = values.Email;
			var messageList=manager.GetListReceiverMessage(p);
			return View(messageList);
		}
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
		{
			var values = await _usermanager.FindByNameAsync(User.Identity.Name);
			p = values.Email;
			var messageList = manager.GetListSenderMessage(p);
			return View(messageList);
		}
		[HttpGet]
		[Route("MessageDetails/{id}")]
		public IActionResult MessageDetails(int id)
		{
			WriterMessage writerMessage = manager.TGetByID(id);
			return View(writerMessage);
		}
		[HttpGet]
		[Route("ReceiverMessageDetails/{id}")]
		public IActionResult ReceiverMessageDetails(int id)
		{
			WriterMessage writerMessage = manager.TGetByID(id);
			return View(writerMessage);
		}
		[HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
		{
			return View();
		}
		[HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task <IActionResult> SendMessage(WriterMessage p)
		{
			var values = await _usermanager.FindByNameAsync(User.Identity.Name);
			string mail=values.Email;
			string name=values.Name+" "+values.Surname;
			p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			p.Sender = mail;
			p.SenderName= name;
			Context c = new Context();
			var usernamesurname=c.Users.Where(x => x.Email == p.Recevier).Select(y => y.Name+" "+y.Surname).FirstOrDefault();
			p.RecevierName = usernamesurname;
			manager.TAdd(p);
			return RedirectToAction("SenderMessage");
		}
	}
}
