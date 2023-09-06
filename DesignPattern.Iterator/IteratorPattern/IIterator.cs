namespace DesignPattern.Iterator.IteratorPattern
{
    public interface IIterator<T> where T : class
    {
        T CurrentItem { get; }

        bool NextLocation();
    }
}