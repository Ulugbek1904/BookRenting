namespace BookRenting.Services
{
    public interface IBookMenuService
    {
        void LoadBookMenu();
        void DisplayAllBooks();

        void SearchBook();
    }
}
