﻿using DesignPattern.UnitOfWork.DataAccessLayer.Abstract;
using DesignPattern.UnitOfWork.DataAccessLayer.Concrete;
using DesignPattern.UnitOfWork.DataAccessLayer.Repositories;
using DesignPattern.UnitOfWork.EntityLayer.Concrete;

namespace DesignPattern.UnitOfWork.DataAccessLayer.EntityFramework
{
    public class EFProcessDal : GenericRepository<Process>, IProcessDal
    {
        public EFProcessDal(Context context) : base(context)
        { }
    }
}