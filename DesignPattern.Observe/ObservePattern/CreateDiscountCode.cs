using DesignPattern.Observe.DAL;
using System;

namespace DesignPattern.Observe.ObservePattern
{
    public class CreateDiscountCode : IObserve
    {
        private Context context = new Context();
        private readonly IServiceProvider serviceProvider;

        public CreateDiscountCode(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser appUser)
        {
            context.Discounts.Add(new Discount
            {
                Amout = 32,
                DiscountCode = "Test",
                Status = true
            });
            context.SaveChanges();
        }
    }
}