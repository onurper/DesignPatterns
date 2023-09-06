namespace DesignPattern.Iterator.IteratorPattern
{
    public class VisitRouteMover : IMover<VisitRoute>
    {
        public List<VisitRoute> visitRoutes = new();

        public void AddVisitRoute(VisitRoute visitRoute)
        {
            visitRoutes.Add(visitRoute);
        }

        public int VisitRoutCount
        {
            get
            {
                return visitRoutes.Count;
            }
        }

        public IIterator<VisitRoute> CreateIterator()
        {
            return new VisitRouteIterator(this);
        }
    }
}