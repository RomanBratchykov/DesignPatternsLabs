using System.Collections.Generic;

namespace Lab2.Iterator
{
    public class BookCollection
    {
        private readonly List<Book> _books = new List<Book>();

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public IIterator<Book> CreateIterator()
        {
            return new BookIterator(_books);
        }
    }
}
