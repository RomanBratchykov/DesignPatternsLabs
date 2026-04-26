namespace Lab2.Iterator
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }
}
