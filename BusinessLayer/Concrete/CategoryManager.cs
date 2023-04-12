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

        public void AddCategory(Category category)
        {
            _categorDal.Insert(category);

        }

        public void DeleteCategory(Category category)
        {
            _categorDal.Delete(category);

        }

        public Category GetById(int id)
        {
            return _categorDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categorDal.GetAll();
        }

        public void UpdateCategory(Category category)
        {
            _categorDal.Update(category);
        }
    }
}
