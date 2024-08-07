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
	public class ToDoListManager : IToDoListService
	{
		IToDoListDal _toDoList;

		public ToDoListManager(IToDoListDal toDoList)
		{
			_toDoList = toDoList;
		}

		public void TAdd(ToDoList t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(ToDoList t)
		{
			throw new NotImplementedException();
		}

		public ToDoList TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<ToDoList> TGetbyid()
		{
			return _toDoList.GetList();
		}

		public List<ToDoList> TGetListbyFilter()
		{
			throw new NotImplementedException();
		}

		public void TUpdate(ToDoList t)
		{
			throw new NotImplementedException();
		}
	}
}
