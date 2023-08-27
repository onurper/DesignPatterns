using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context _context = new Context();

            if (req.Amount <= 150000)
            {
                CustomerProcess customer = new CustomerProcess
                {
                    Amount = req.Amount,
                    EmployeeName = req.EmployeeName,
                    Description = req.Description,
                    Name = "Müdür Yardımcısı - Ceren - Onaylandı",
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
                    Description = "Müdür Yardımcısı limiti aşılmıştır",
                    Name = "Müdür Yardımcısı - Ceren",
                };
                _context.Add(customer);
                _context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
