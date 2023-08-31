using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context _context = new Context();

            if (req.Amount <= 400000)
            {
                CustomerProcess customer = new CustomerProcess
                {
                    Amount = req.Amount,
                    EmployeeName = req.EmployeeName,
                    Description = req.Description,
                    Name = "Bölge müdürü - Dilek - Onaylandı",
                };
                _context.Add(customer);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customer = new CustomerProcess
                {
                    Amount = req.Amount,
                    EmployeeName = req.EmployeeName,
                    Description = "Bölge müdürü limiti aşılmıştır",
                    Name = "Bölge müdürü - Dilek",
                };
                _context.Add(customer);
                _context.SaveChanges();
            }
        }
    }
}