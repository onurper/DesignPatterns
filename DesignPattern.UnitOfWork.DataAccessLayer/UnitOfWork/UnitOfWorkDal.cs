using DesignPattern.UnitOfWork.DataAccessLayer.Concrete;

namespace DesignPattern.UnitOfWork.DataAccessLayer.UnitOfWork
{
    public class UnitOfWorkDal : IUnitOfWorkDal
    {
        private readonly Context context;

        public UnitOfWorkDal(Context context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}