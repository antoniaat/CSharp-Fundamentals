using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    public List<Book> Books { get; set; }

    public Library(params Book[] books)
    {
        this.Books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public bool MoveNext() => ++currentIndex < books.Count;

        public void Reset() => this.currentIndex = -1;

        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }
}