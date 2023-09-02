using DesignPattern.Observe.DAL;
using System;

namespace DesignPattern.Observe.ObservePattern
{
    public class CreateMagazineAnnocuncement : IObserve
    {
        private Context context = new Context();
        private readonly IServiceProvider serviceProvider;

        public CreateMagazineAnnocuncement(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser appUser)
        {
            context.UserProcesses.Add(new UserProcess
            {
                NameSurname = appUser.Name,
                Content = "Bilim Dergisi Mart Sayısı",
                Magazine = "Bilim Dergisi"
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