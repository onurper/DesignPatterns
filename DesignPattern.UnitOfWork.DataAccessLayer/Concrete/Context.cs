using DesignPattern.UnitOfWork.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.UnitOfWork.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=DesignPattern_UNITOFWORK;User Id=postgres; Password=123456aA");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Process> Processes { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}