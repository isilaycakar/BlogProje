using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
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
        ICategoryDal _categorDal;
        public CategoryManager(ICategoryDal categorDal) //constructer metodu!!
        {
            _categorDal = categorDal;
        }

        public Category TGetById(int id)
        {
            return _categorDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categorDal.GetAll();
        }

        public void TAdd(Category t)
        {
            _categorDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categorDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categorDal.Update(t);
        }
    }
}
