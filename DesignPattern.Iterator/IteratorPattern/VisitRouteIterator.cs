namespace DesignPattern.Iterator.IteratorPattern
{
    public class VisitRouteIterator : IIterator<VisitRoute>
    {
        private VisitRouteMover _visitRouteMover;
        private int currentIndex = 0;

        public VisitRouteIterator(VisitRouteMover visitRouteMover)
        {
            _visitRouteMover = visitRouteMover;
        }

        public VisitRoute CurrentItem { get; set; }

        public bool NextLocation()
        {
            if (currentIndex < _visitRouteMover.VisitRoutCount)
            {
                CurrentItem = _visitRouteMover.visitRoutes[currentIndex++];
                return true;
            }
            return false;
        }
    }
}