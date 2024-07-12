using BookRenting.Models;
using System;

namespace BookRenting.Services
{
    internal class BookMenuService : IBookMenuService
    {
        IBookService bookService;
        public BookMenuService()
        {
            this.bookService = 
                new BookService();
        }
        public void LoadBookMenu()
        {
            Console.Clear();
            bool continuProg = true;
            while (continuProg)
            {
                string menu = "" +
                    "1. Books list\n" +
                    "2. Search book\n" +
                    "3. Add new book \n" +
                    "4. Edit book data\n" +
                    "5. Delete book\n" +
                    "6. Back";
                Console.WriteLine("" +
                    "====== Book Menu ======");
                Console.WriteLine(menu);

                Console.Write("\n\nChoose a menu  ");
                int.TryParse(Console.ReadLine(),
                    out int option);
                Console.WriteLine(Environment.NewLine);

                switch (option)
                {
                    case 1:
                        DisplayAllBooks();
                        Console.WriteLine
                            (Environment.NewLine);
                        break;
                    case 2:
                        SearchBook();
                        Console.WriteLine
                            (Environment.NewLine);
                        break;
                    case 3:
                        AddNewBook();
                        Console.WriteLine
                            (Environment.NewLine);
                        break;
                    case 4:
                        EditBookData();
                        Console.WriteLine
                            (Environment.NewLine);
                        break;
                    case 5:
                        Deletebook();
                        Console.WriteLine
                            (Environment.NewLine);
                        break;
                    case 6:
                        continuProg = false;
                        break;
                    default:
                        Console.WriteLine("choose one!");
                        break;
                }
            }
        }
        public  void DisplayAllBooks()
        {
            var books = this.
                bookService.RetrieveBooks();

            for (int index = 0; index < 
                books.Count; index++)
            {
                Console.WriteLine($"{index + 1}." +
                    $" Book Id : {books[index].BookId}, " +
                    $"Book name : {books[index].Name}, " +
                    $"Author : {books[index].Author}, " +
                    $"Publish at {books[index].PublishedAt}, " +
                    $"Version : {books[index].Version}");
            }
        }

        public void SearchBook()
        {
            Console.Write("Enter the book " +
                "Id you want to find: ");
            if (!int.TryParse(Console.ReadLine(), 
                out int bookId))
            {
                Console.WriteLine("Invalid book Id.");
                return;
            }

            var book = this.bookService.RetrieveBook(bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine(
                        $" Book Id : {book.BookId}, " +
                        $"Book name : {book.Name}, " +
                        $"Author : {book.Author}, " +
                        $"Published at : {book.PublishedAt}, " +
                        $"Version : {book.Version}");
            }
        }


        public void AddNewBook()
        {
            try
            {

                Console.Write("Enter name : ");
                string name = Console.ReadLine();


                Console.Write("Enter Author name:");
                string authorName = 
                    Console.ReadLine();

                Console.Write("Enter when this book published (dd/mm/yyyy): ");
                DateOnly publishAt = 
                    DateOnly.Parse(Console.ReadLine());

                Console.Write("Give unique Id for new book : ");
                int bookId = int.Parse
                    (Console.ReadLine());

                Console.Write("Enter version : ");
                int version = int.Parse
                    (Console.ReadLine());

                Books newBook = new Books()
                {
                    BookId = bookId,
                    Name = name,
                    Author = authorName,
                    PublishedAt = publishAt,
                    Version = version,
                };

                var book = this.bookService.AddNewBook(newBook);
                Console.WriteLine("New book was added succesfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EditBookData()
        {
            DisplayAllBooks();
            Console.Write("Enter the " +
                "book Id you want to edit : ");
            int.TryParse(Console.ReadLine(),
                out int bookId);

            var books = this.
                bookService.RetrieveBooks();
            for (int index = 0; index < books.Count; index++)
            {
                if (books[index].BookId != bookId)
                {
                    Console.WriteLine("book with this key does not exist. Try again!\n");
                    return;
                }
                else
                {
                    Console.Write("Enter name : ");
                    string name = Console.ReadLine();


                    Console.Write("Enter Author name :");
                    string authorName =
                        Console.ReadLine();

                    Console.Write("Enter when this book published (dd/mm/yyyy): ");
                    DateOnly publishAt =
                        DateOnly.Parse(Console.ReadLine());

                    Console.Write("Enter version : ");
                    int version = int.Parse
                        (Console.ReadLine());

                    Books newBook= new Books()
                    {
                        BookId = bookId,
                        Name = name,
                        Author = authorName,
                        PublishedAt = publishAt,
                        Version = version,
                    };
                    var editedbook = this.bookService.ModifyBookData(bookId, newBook);
                    Console.WriteLine("book data were succesfully editted.");
                }
            }
        }

        public void Deletebook()
        {
            DisplayAllBooks();
            Console.Write("Enter the book" +
                " Id you want to delete : ");
            int.TryParse(Console.ReadLine(),
                out int bookID);

            var books = this.
                bookService.RetrieveBooks();
            for (int index = 0; index < books.Count; index++)
            {
                if (books[index].BookId != bookID)
                {
                    Console.WriteLine("book with this key does not exist. Try again!\n");
                    return;
                }
                else
                {
                    var editedbookData= this.bookService.RemoveBook(bookID);
                    Console.WriteLine("book data were succesfully deleted.");
                }
            }
        }
    }
}
