using DesignPattern.Repository.DataAccessLayer.Abstract;
using DesignPattern.Repository.DataAccessLayer.Concrete;
using DesignPattern.Repository.DataAccessLayer.Repositories;
using DesignPattern.Repository.EntityLayer.Concrete;

namespace DesignPattern.Repository.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(Context context) : base(context)
        {
        }
    }
}