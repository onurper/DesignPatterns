using System.Collections.Generic;

namespace DesignPattern.UnitOfWork.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T t);

        void Delete(T t);

        void Update(T t);

        List<T> GetList();

        T GetById(int id);

        void MultiUpdate(List<T> t);
    }
}