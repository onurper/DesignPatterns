using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context _context = new Context();

            if (req.Amount <= 100000)
            {
                CustomerProcess customer = new CustomerProcess
                {
                    Amount = req.Amount,
                    EmployeeName = req.EmployeeName,
                    Description = req.Description,
                    Name = "Veznedar - Onur - Onaylandı",
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
                    Description = "Veznedar limiti aşılmıştır",
                    Name = "Veznedar - Onur",
                };
                _context.Add(customer);
                _context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }

    }
}
