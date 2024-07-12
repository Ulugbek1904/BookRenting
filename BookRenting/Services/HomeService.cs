namespace BookRenting.Services
{
    public class HomeService : IHomeService
    {
        public IStudentsMenuService studentsMenuService;
        public ILibrariantMenuService librariantMenuServices;
        public IBookMenuService bookMenuService;
        public HomeService()
        {
            this.studentsMenuService = new StudentsMenuService();
            this.librariantMenuServices = new LibrariantMenuService();
            this.bookMenuService = new BookMenuService();
        }

        public void LoadExistedMenus()
        {
            bool continuProg = true;

            while (continuProg)
            {
                string menu = "" +
                    "1. Librariants\n" +
                    "2. Students \n" +
                    "3. Books \n" +
                    "4. Rent \n" +
                    "5. Exit";
                Console.WriteLine("====== Menu ======");
                Console.WriteLine(menu);

                Console.Write("\n\nChoose a menu  ");
                int.TryParse(Console.ReadLine(), out int option);
                Console.WriteLine(Environment.NewLine);


                switch (option)
                {
                    case 1:
                        librariantMenuServices.LoadMenu();
                        break;
                    case 2:
                        studentsMenuService.LoadStudentsMenu();
                        break;
                    case 3:
                        bookMenuService.LoadBookMenu();
                        break;
                    case 4:
                        LoadRentMenu();
                        break;
                    case 5:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("choose one!");
                        break;
                }
            }
        }

        private void LoadRentMenu()
        {
            bool continuProg = true;
            while (continuProg)
            {
                string menu = "" +
                    "1. Librariants list\n" +
                    "2. Add new librariant \n" +
                    "3. Delete librariant\n" +
                    "4. Exit";
                Console.WriteLine("====== Librariant's Menu ======");
                Console.WriteLine(menu);

                Console.Write("\n\nChoose a menu  ");
                int.TryParse(Console.ReadLine(), out int option);
                Console.WriteLine(Environment.NewLine);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("list");
                        break;
                    case 2:
                        Console.WriteLine("Add");
                        break;
                    case 3:
                        Console.WriteLine("delete");
                        break;
                    case 4:
                        continuProg = false;
                        break;
                    default:
                        Console.WriteLine("choose one!");
                        break;
                }
            }
        }
        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
