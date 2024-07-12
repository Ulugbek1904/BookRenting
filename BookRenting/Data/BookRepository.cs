using BookRenting.Models;

namespace BookRenting.Data
{
    internal class BookRepository : IBookRepository
    {
        Dictionary<int, Books> books;
        public BookRepository()
        {
            this.books = new Dictionary<int, Books>();
        }

        public IList<Books> SelectAllBooks() =>
            books.Values.ToList();

        public Books SelectBookById(int bookId)
        {
            if (!books.ContainsKey(bookId))
                throw new KeyNotFoundException("book was not found!");
            return books[bookId];

        }

        public Books InsertBook(Books Book)
        {
            if (books.ContainsKey(Book.BookId))
                throw new ArgumentException("book with this key already exists");
            books.Add(Book.BookId, Book);
            return Book;
        }

        public Books UpdateBookData(int bookId, Books Book)
        {
            if (!books.ContainsKey(bookId))
                throw new ArgumentException("book with this key does not exist");
            else
            {
                var existedBook = books[bookId];
                if(Book.Name != null)
                    existedBook.BookId = bookId;
                    existedBook.Version = Book.Version;
                    existedBook.Author = Book.Author;
                    existedBook.PublishedAt = Book.PublishedAt;
                    existedBook.Name = Book.Name;
                return existedBook;
            }
        }

        public bool DeleteBookData(int bookId)
        {
            if (!books.ContainsKey(bookId))
                throw new ArgumentException("book with th Id does not found");
            books.Remove(bookId);
            return books.Remove(bookId);
        }            
    }
}
