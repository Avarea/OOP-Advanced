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
}

