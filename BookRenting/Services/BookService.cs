using BookRenting.Data;
using BookRenting.Models;

namespace BookRenting.Services
{
    internal class BookService : IBookService
    {
        IBookRepository bookRepository;
        public BookService()
        {
            this.bookRepository = new BookRepository();
        }

        public IList<Books> RetrieveBooks(string name = null)
        {
            var books = this.bookRepository.SelectAllBooks();
            if (!string.IsNullOrEmpty(name))
            {
                var filtresBooks = new List<Books>();
                foreach (var book in books)
                    if (book.Name.Contains(name))
                        filtresBooks.Add(book);
                    return filtresBooks;
            }
            return books;
        }

        public Books RetrieveBook(int bookId)
        {
            Books book = null;

            try
            {
                book =
                    this.bookRepository.SelectBookById(bookId);
            }
            catch (KeyNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return book;
        }

        public Books AddNewBook(Books book)
        {
            Books newBook = null;
            try
            {
                newBook = this.bookRepository.InsertBook(book);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return newBook;
        }

        public Books ModifyBookData(int BookId, Books book)
        {
            Books modifiedBook = null;
            try
            {
                modifiedBook = this.bookRepository.UpdateBookData(BookId, book);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return modifiedBook;
        }

        public bool RemoveBook(int bookId)
        {
            try
            {
                bool isRemoved = this.bookRepository.DeleteBookData(bookId);
                return true;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return false;
        }
    }
}
