using DesignPattern.Repository.EntityLayer.Concrete;
using System.Collections.Generic;

namespace DesignPattern.Repository.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> ProductListWithCategory();
    }
}