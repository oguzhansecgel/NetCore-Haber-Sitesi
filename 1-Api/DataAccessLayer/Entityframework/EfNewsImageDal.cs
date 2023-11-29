using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.Entityframework
{
	public class EfNewsImageDal : GenericRepository<NewsImage>, INewsImageDal
	{
		public EfNewsImageDal(Context context) : base(context)
		{
		}
	}
}
