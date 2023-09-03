using DesignPattern.UnitOfWork.BusinessLayer.Abstract;
using DesignPattern.UnitOfWork.DataAccessLayer.Abstract;
using DesignPattern.UnitOfWork.DataAccessLayer.UnitOfWork;
using DesignPattern.UnitOfWork.EntityLayer.Concrete;
using System.Collections.Generic;

namespace DesignPattern.UnitOfWork.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal customerDal;
        private readonly IUnitOfWorkDal unitOfWork;

        public CustomerManager(IUnitOfWorkDal unitOfWork, ICustomerDal customerDal)
        {
            this.unitOfWork = unitOfWork;
            this.customerDal = customerDal;
        }

        public void Delete(Customer t)
        {
            customerDal.Delete(t);
            unitOfWork.Save();
        }

        public Customer GetById(int id)
        {
            return customerDal.GetById(id);
        }

        public List<Customer> GetList()
        {
            return customerDal.GetList();
        }

        public void Insert(Customer t)
        {
            customerDal.Insert(t);
            unitOfWork.Save();
        }

        public void MultiUpdate(List<Customer> t)
        {
            customerDal.MultiUpdate(t);
            unitOfWork.Save();
        }

        public void Update(Customer t)
        {
            customerDal.Update(t);
            unitOfWork.Save();
        }
    }
}