using DesignPattern.Repository.DataAccessLayer.Abstract;
using DesignPattern.Repository.DataAccessLayer.Concrete;
using DesignPattern.Repository.DataAccessLayer.Repositories;
using DesignPattern.Repository.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Repository.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly Context _context;

        public EfProductDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Product> ProductListWithCategory()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }
    }
}