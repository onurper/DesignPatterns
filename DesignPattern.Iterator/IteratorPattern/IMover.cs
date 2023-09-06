namespace DesignPattern.Iterator.IteratorPattern
{
    public interface IMover<T> where T : class
    {
        IIterator<T> CreateIterator();
    }
}