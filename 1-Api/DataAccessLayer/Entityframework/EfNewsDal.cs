using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entityframework
{
	public class EfNewsDal : GenericRepository<News>, INewsDal
	{
		public EfNewsDal(Context context) : base(context)
		{
		}

		 
	}
}
