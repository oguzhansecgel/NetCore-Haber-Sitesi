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
	public class NewsImageManager : INewsImageService
	{
		private readonly INewsImageDal _newsImageDal;

		public NewsImageManager(INewsImageDal newsImageDal)
		{
			_newsImageDal = newsImageDal;
		}
		public NewsImage TGetByID(int id)
		{
			return _newsImageDal.GetByID(id);
		}

		public List<NewsImage> TGetListAll()
		{
			return _newsImageDal.GetListAll();
		}

		public void TAdd(NewsImage entity)
		{
			_newsImageDal.Add(entity);
		}

		public void TDelete(NewsImage entity)
		{
			_newsImageDal.Delete(entity);
		}

		public void TUpdate(NewsImage entity)
		{
			_newsImageDal.Update(entity);
		}
	}
}
