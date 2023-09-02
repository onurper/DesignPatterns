using DesignPattern.Observe.DAL;
using System.Collections.Generic;

namespace DesignPattern.Observe.ObservePattern
{
    public class ObserveObject
    {
        private readonly List<IObserve> observes;

        public ObserveObject()
        {
            this.observes = new List<IObserve>();
        }

        public void RegisterObserve(IObserve observe)
        {
            observes.Add(observe);
        }

        public void RemoveObserver(IObserve observe)
        {
            observes.Remove(observe);
        }

        public void NotifyObserve(AppUser appUser)
        {
            foreach (var item in observes)
            {
                item.CreateNewUser(appUser);
            }
        }
    }
}