using BookRenting.Models;

namespace BookRenting.Services
{
    public class LibrariantMenuService : ILibrariantMenuService
    {
        public ILibrariantServices librariantServices;

        public LibrariantMenuService()
        {
            this.librariantServices =
                new LibrariantService();
        }
        public void LoadMenu()
        {
            Console.Clear();
            bool continuProg = true;
            while (continuProg)
            {
                string menu = "" +
                    "1. Librariants' list\n" +
                    "2. Add new librariant \n" +
                    "3. Edit librariant\n" +
                    "4. Delete librariant\n" +
                    "5. Back";
                Console.WriteLine("====== Librariant's Menu ======");
                Console.WriteLine(menu);

                Console.Write("\n\nChoose an option : ");
                int.TryParse(Console.ReadLine(), out int option);
                Console.WriteLine(Environment.NewLine);

                switch (option)
                {
                    case 1:
                        DisplayLibrariants();
                        break;
                    case 2:
                        AddLibrariant();
                        break;
                    case 3:
                        EditLibrariant();
                        break;
                    case 4:
                        DeleteLibrariant();
                        break;
                    case 5:
                        Console.Clear();
                        continuProg = false;
                        break;
                    default:
                        Console.WriteLine("choose one!");
                        break;
                }
            }
        }
        public void DisplayLibrariants()
        {
            var librariants = this.librariantServices.RetrieveLibrariants();
            for (int index = 0; index < librariants.Count; index++)
            {
                Console.WriteLine($"{index + 1}. UseerId : " +
                    $"{librariants[index].UserId}," +
                    $" Name : {librariants[index].Name}, " +
                    $"Job : {librariants[index].Type}, " +
                    $"Gender : {librariants[index].Gender}, " +
                    $"Birthday : {librariants[index].Birthday}\n");
            }
        }
        public void AddLibrariant()
        {
            Console.Write("Enter name : ");
            string name = Console.ReadLine();

            
            Console.Write("Enter Gender male or female :");
            string userInput = Console.ReadLine();

            if (Enum.TryParse(userInput, true, out Gender gender))
            {                
            }
            else
            {
                Console.WriteLine("Invalid gender entered.");
            }

            Console.Write("Enter Birthday e.g(mm/dd/yy hh : mm : ss) : ");
            string birthday = Console.ReadLine();
            Console.Write("Give unique Id for new librariant : ");
            int librariantId = int.Parse(Console.ReadLine());

            User newUser = new User()
            {
                UserId = librariantId,
                Name = name,
                Gender = gender,
                Birthday = DateTime.Parse(birthday),
                Type = UserType.Librariant,
            };

            var librariants = this.librariantServices.AddLibrariant(newUser);
            Console.WriteLine("New librariant was added succesfully.\n");
        }
        public void EditLibrariant()
        {
            DisplayLibrariants();
            Console.Write("Enter the LibrariantId you want to edit : ");
            int.TryParse(Console.ReadLine(),out  int librariantId);

            var librariants = this.librariantServices.RetrieveLibrariants();
            for (int index = 0; index < librariants.Count; index++)
            {
                if (librariants[index].UserId != librariantId)
                {
                    Console.WriteLine("librariant with this key does not exist. Try again!\n");
                    return;
                }
                else
                {
                    Console.Write("Enter name : ");
                    string name = Console.ReadLine();


                    Console.Write("Enter Gender( male or female) : ");
                    string userInput = Console.ReadLine();

                    if (Enum.TryParse(userInput, true, out Gender gender))
                    { }
                    else
                    {
                        Console.WriteLine("Invalid gender entered.");
                    }

                    Console.Write("Enter Birthday e.g(mm/dd/yy hh : mm : ss) : ");
                    string birthdayInput = Console.ReadLine();

                    if (DateTime.TryParse(birthdayInput, out DateTime birthday))
                    { }
                    else
                    {
                        Console.WriteLine("Invalid dateTime entered.");
                    }

                    User newUser = new User()
                    {
                        UserId = librariantId,
                        Name = name,
                        Gender = gender,
                        Birthday = birthday,
                        Type = UserType.Librariant,
                    };
                    var editLibrariants = this.librariantServices.ModifyLibrariant(librariantId, newUser);
                    Console.WriteLine("librariant was succesfully editted.");
                }
            }
        }
        public void DeleteLibrariant()
        {
            DisplayLibrariants();
            Console.Write("Enter the LibrariantId you want to delete : ");
            int.TryParse(Console.ReadLine(), out int librariantId);

            var librariants = this.librariantServices.RetrieveLibrariants();
            for (int index = 0; index < librariants.Count; index++)
            {
                if (librariants[index].UserId != librariantId)
                {
                    Console.WriteLine("librariant with this key does not exist. Try again!\n");
                    return;
                }
                else
                {
                    var editLibrariants = this.librariantServices.RemoveLibrariant(librariantId);
                    Console.WriteLine("librariant was succesfully deleted.");
                }
            }
        }
    }
}
