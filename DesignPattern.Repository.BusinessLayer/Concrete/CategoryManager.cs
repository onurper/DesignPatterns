using DesignPattern.Repository.BusinessLayer.Abstract;
using DesignPattern.Repository.DataAccessLayer.Abstract;
using DesignPattern.Repository.EntityLayer.Concrete;
using System.Collections.Generic;

namespace DesignPattern.Repository.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void Delete(Category t)
        {
            categoryDal.Delete(t);
        }

        public Category GetById(int id)
        {
            return categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return categoryDal.GetList();
        }

        public void Insert(Category t)
        {
            categoryDal.Insert(t);
        }

        public void Update(Category t)
        {
            categoryDal.Update(t);
        }
    }
}