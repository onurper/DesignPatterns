using DesignPattern.Repository.EntityLayer.Concrete;
using System.Collections.Generic;

namespace DesignPattern.Repository.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> ProductListWithCategory();
    }
}