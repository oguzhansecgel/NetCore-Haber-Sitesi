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
	public class NewsManager : INewsService
	{
		private readonly INewsDal _newsDal;

		public NewsManager(INewsDal newsDal)
		{
			_newsDal = newsDal;
		}

		public News TGetByID(int id)
		{
			return _newsDal.GetByID(id);
		}

		public List<News> TGetListAll()
		{
			return _newsDal.GetListAll();
		}
 
		public void TAdd(News entity)
		{
			_newsDal.Add(entity);
		}

		public void TDelete(News entity)
		{
			_newsDal.Delete(entity);
		}

		public void TUpdate(News entity)
		{
			_newsDal.Update(entity);
		}
	}
}
