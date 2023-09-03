using DesignPattern.UnitOfWork.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.UnitOfWork.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Process> Processes { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}