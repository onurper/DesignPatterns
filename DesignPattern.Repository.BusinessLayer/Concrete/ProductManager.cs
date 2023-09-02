using DesignPattern.Repository.BusinessLayer.Abstract;
using DesignPattern.Repository.DataAccessLayer.Abstract;
using DesignPattern.Repository.EntityLayer.Concrete;
using System.Collections.Generic;

namespace DesignPattern.Repository.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void Delete(Product t)
        {
            productDal.Delete(t);
        }

        public Product GetById(int id)
        {
            return productDal.GetById(id);
        }

        public List<Product> GetList()
        {
            return productDal.GetList();
        }

        public void Insert(Product t)
        {
            productDal.Insert(t);
        }

        public List<Product> ProductListWithCategory()
        {
            return productDal.ProductListWithCategory();
        }

        public void Update(Product t)
        {
            productDal.Update(t);
        }
    }
}