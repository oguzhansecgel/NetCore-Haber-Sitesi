using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entityframework
{
	public class EfNewsDal : GenericRepository<News>, INewsDal
	{
		public EfNewsDal(Context context) : base(context)
		{
		}

		public List<News> GetProductsWithCategory()
		{
			var context = new Context();
			var values = context.Newses.Include(x => x.Category).ToList();
			return values;

		}
	}
}
