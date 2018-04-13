using System.Collections;
using System.Collections.Generic;

public class Library: IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.Books = books;
    }

    public IReadOnlyList<Book> Books { get; private set; }

    public IEnumerator<Book> GetEnumerator()
    {
        return this.Books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex = 0;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current { get; }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
        
        object IEnumerator.Current
        {
            get { return this.books[this.currentIndex]; }
        }

        public void Dispose() {}
    }
}

