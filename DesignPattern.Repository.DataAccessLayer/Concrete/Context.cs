using DesignPattern.Repository.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Repository.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}