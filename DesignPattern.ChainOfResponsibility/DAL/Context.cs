using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=oper;initial catalog=DesignPattern_1;integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
