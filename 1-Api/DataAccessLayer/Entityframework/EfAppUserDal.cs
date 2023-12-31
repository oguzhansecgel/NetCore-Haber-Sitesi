﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entityframework
{
	public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
	{
		public EfAppUserDal(Context context) : base(context)
		{
		}
	}
}
