using DesignPattern.UnitOfWork.EntityLayer.Concrete;

namespace DesignPattern.UnitOfWork.DataAccessLayer.Abstract
{
    public interface ICustomerDal : IGenericDal<Customer>
    {
    }
}