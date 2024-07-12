using BookRenting.Models;

namespace BookRenting.Data
{
    internal interface IBookRepository
    {
        IList<Books> SelectAllBooks();
        Books SelectBookById(int bookId);
        Books InsertBook(Books Book);
        Books UpdateBookData(int bookId, Books Book);
        bool DeleteBookData(int bookId);
    }
}
