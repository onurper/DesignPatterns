using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context _context = new Context();

            if (req.Amount <= 250000)
            {
                CustomerProcess customer = new CustomerProcess
                {
                    Amount = req.Amount,
                    EmployeeName = req.EmployeeName,
                    Description = req.Description,
                    Name = "Müdür - Anka - Onaylandı",
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
                    Description = "Müdür limiti aşılmıştır",
                    Name = "Müdür - Anka",
                };
                _context.Add(customer);
                _context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}