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
    public class WriterUserManager :IGenericService<WriteUsers>
    {
        IWriterUserDal _writerUser;

        public WriterUserManager(IWriterUserDal writerUser)
        {
            _writerUser = writerUser;
        }

        public void TAdd(WriteUsers t)
        {
            _writerUser.Insert(t);
        }

        public void TDelete(WriteUsers t)
        {
            _writerUser.Delete(t);
        }

        public List<WriteUsers> TGetbyid()
        {
            return _writerUser.GetList();
        }

        public WriteUsers TGetByID(int id)
        {
            return _writerUser.GetByID(id);
        }

        public List<WriteUsers> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriteUsers t)
        {
            _writerUser.Update(t);
        }
    }
}
