using System.Collections.Generic;

namespace DesignPattern.Repository.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T t);

        void Update(T t);

        void Delete(T t);

        List<T> GetList();

        T GetById(int id);
    }
}