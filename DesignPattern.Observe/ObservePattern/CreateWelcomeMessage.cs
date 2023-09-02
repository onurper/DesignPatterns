using DesignPattern.Observe.DAL;
using System;

namespace DesignPattern.Observe.ObservePattern
{
    public class CreateWelcomeMessage : IObserve
    {
        private readonly IServiceProvider serviceProvider;
        private Context context = new Context();

        public CreateWelcomeMessage(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser appUser)
        {
            context.WelcomeMessages.Add(new WelcomeMessage
            {
                Content = "Teşekkürler, kayıt oldunuz",
                NameSurname = appUser.Name
            });
            try
            {
                context.SaveChanges();
            }
            catch (Exception Ex)
            {
            }
        }
    }
}