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
	public class AppUserManager : IAppUserService
	{
		private readonly IAppUserDal _appUserDal;

		public AppUserManager(IAppUserDal appUserDal)
		{
			_appUserDal = appUserDal;
		}
		public AppUser TGetByID(int id)
		{
			return _appUserDal.GetByID(id);
		}

		public List<AppUser> TGetListAll()
		{
			return _appUserDal.GetListAll();
		}

		public void TAdd(AppUser entity)
		{
			 _appUserDal.Add(entity);
		}

		public void TDelete(AppUser entity)
		{
			_appUserDal.Delete(entity);
		}

	
		public void TUpdate(AppUser entity)
		{
			_appUserDal.Update(entity);
		}
	}
}
