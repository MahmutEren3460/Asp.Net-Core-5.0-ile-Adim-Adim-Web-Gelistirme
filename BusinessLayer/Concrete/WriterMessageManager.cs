using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WriterMessageManager : IWriterMessageService
	{
		IWriterMessageDal _writerMessage;

		public WriterMessageManager(IWriterMessageDal writerMessage)
		{
			_writerMessage = writerMessage;
		}

		public List<WriterMessage> GetListReceiverMessage(string p)
		{
			return _writerMessage.GetbyFilter(x => x.Recevier == p);
		}

		public List<WriterMessage> GetListSenderMessage(string p)
		{
			return _writerMessage.GetbyFilter(x => x.Sender == p);
		}

		public void TAdd(WriterMessage t)
		{
			_writerMessage.Insert(t);
		}

		public void TDelete(WriterMessage t)
		{
			_writerMessage.Delete(t);
		}

		public WriterMessage TGetByID(int id)
		{
			return _writerMessage.GetByID(id);
		}

		public List<WriterMessage> TGetbyid()
		{
			throw new NotImplementedException();
		}

		public List<WriterMessage> TGetListbyFilter()
		{
			throw new NotImplementedException();
		}

		//public List<WriterMessage> TGetListbyFilter(string p)
		//{
		//	return _writerMessage.GetbyFilter(x => x.Recevier == p);
		//}

		public void TUpdate(WriterMessage t)
		{
			throw new NotImplementedException();
		}
	}
}
