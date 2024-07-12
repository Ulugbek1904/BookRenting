using BookRenting.Models;

namespace BookRenting.Services
{
    internal interface IBookService
    {
        IList<Books> RetrieveBooks(string name = null);

        Books RetrieveBook(int bookId);
        Books AddNewBook(Books book);
        Books ModifyBookData(int BookId, Books book);
        bool RemoveBook(int bookId);
    }
}
