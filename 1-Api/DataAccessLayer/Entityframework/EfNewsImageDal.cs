using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entityframework
{
	public class EfNewsImageDal : GenericRepository<NewsImage>, INewsImageDal
	{
		public EfNewsImageDal(Context context) : base(context)
		{
		}

	 
	}
}
