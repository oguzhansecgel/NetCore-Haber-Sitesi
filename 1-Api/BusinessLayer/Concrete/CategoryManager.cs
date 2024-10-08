﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}


		public Category TGetByID(int id)
		{
			return _categoryDal.GetByID(id);
		}

		public List<Category> TGetListAll()
		{
			return _categoryDal.GetListAll();
		}

		public void TAdd(Category entity)
		{
			_categoryDal.Add(entity);
		}

		public void TDelete(Category entity)
		{
			_categoryDal.Delete(entity);
		}

		public void TUpdate(Category entity)
		{
			_categoryDal.Update(entity);
		}
	}
}
