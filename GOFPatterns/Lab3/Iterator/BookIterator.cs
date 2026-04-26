using System;
using System.Collections.Generic;

namespace Lab2.Iterator
{
    public class BookIterator : IIterator<Book>
    {
        private readonly IList<Book> _books;
        private int _index;

        public BookIterator(IList<Book> books)
        {
            _books = books;
            _index = 0;
        }

        public bool HasNext()
        {
            return _index < _books.Count;
        }

        public Book Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more items.");
            }

            var current = _books[_index];
            _index++;
            return current;
        }
    }
}
