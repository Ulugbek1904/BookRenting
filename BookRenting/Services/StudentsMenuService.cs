using BookRenting.Models;
using System.Threading.Channels;

namespace BookRenting.Services
{
    public class StudentsMenuService : IStudentsMenuService
    {
        public ILibrariantServices studentService;
        public StudentsMenuService()
        {
            this.studentService =
                new LibrariantService();
        }
        public void LoadStudentsMenu()
        {
            Console.Clear();    
            bool continuProg = true;
            while (continuProg)
            {
                string menu = "" +
                    "1. Student's list\n" +
                    "2. Add new student \n" +
                    "3. Edit student data\n" +
                    "4. Delete student\n" +
                    "5. Back";
                Console.WriteLine("====== Student's Menu ======");
                Console.WriteLine(menu);

                Console.Write("\n\nChoose a menu  ");
                int.TryParse(Console.ReadLine(), out int option);
                Console.WriteLine(Environment.NewLine);

                switch (option)
                {
                    case 1:
                        DisplayStudents();
                        break;
                    case 2:
                        AddStudent();
                        break;
                    case 3:
                        EditStudentDate();
                        break;
                    case 4:
                        RemoveStudent();
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

        public void DisplayStudents()
        {
            var students = this.studentService.RetrieveLibrariants();
            for (int index = 0; index < students.Count; index++)
            {
                Console.WriteLine($"{index + 1}. UseerId : " +
                    $"{students[index].UserId}," +
                    $" Name : {students[index].Name}, " +
                    $"Job : {students[index].Type}, " +
                    $"Gender : {students[index].Gender}, " +
                    $"Birthday : {students[index].Birthday}\n");
            }
        }

        public void AddStudent()
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
            Console.Write("Give unique Id for new Student : ");
            int studentId = int.Parse(Console.ReadLine());

            User newUser = new User()
            {
                UserId = studentId,
                Name = name,
                Gender = gender,
                Birthday = DateTime.Parse(birthday),
                Type = UserType.Student,
            };

            var students = this.studentService.AddLibrariant(newUser);
            Console.WriteLine("New student was added succesfully.\n");
        }

        public void EditStudentDate()
        {
            DisplayStudents();
            Console.Write("Enter the StudentId you want to edit : ");
            int.TryParse(Console.ReadLine(), out int studentId);

            var students = this.studentService.RetrieveLibrariants();
            for (int index = 0; index < students.Count; index++)
            {
                if (students[index].UserId != studentId)
                {
                    Console.WriteLine("student with the key does not exist. Try again!\n");
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
                        Console.WriteLine("Invalid datetime entered.");
                    }

                    User newUser = new User()
                    {
                        UserId = studentId,
                        Name = name,
                        Gender = gender,
                        Birthday = birthday,
                        Type = UserType.Student,
                    };
                    var editLibrariants = this.studentService.ModifyLibrariant(studentId, newUser);
                    Console.WriteLine("Student data was succesfully editted.");
                }
            }
        }
        public void RemoveStudent()
        {
            DisplayStudents();
            Console.Write("Enter the student's Id you want to delete : ");
            int.TryParse(Console.ReadLine(), out int studentId);

            var students = this.studentService.RetrieveLibrariants();
            for (int index = 0; index < students.Count; index++)
            {
                if (students[index].UserId != studentId)
                {
                    Console.WriteLine("student's data with this key does not exist. Try again!\n");
                    return;
                }
                else
                {
                    var editStudents = this.studentService.RemoveLibrariant(studentId);
                    Console.WriteLine("student's data was succesfully deleted.");
                }
            }
        }
    }
}
