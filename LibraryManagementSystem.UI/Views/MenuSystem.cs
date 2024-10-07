using LibraryManagementSystem.Business.Services;
using LibraryManagementSystem.DataAccess.Context;

namespace LibraryManagementSystem.ConsoleApp.Views
{
    public class MenuSystem
    {
        /// <summary>
        /// Function to show the logo
        /// </summary>
        public static void Logo()
        {
            Console.WriteLine(@"L̲I̲B̲R̲A̲R̲Y̲ M̲A̲N̲A̲G̲E̲M̲E̲N̲T̲ S̲Y̲S̲T̲E̲M̲" + "\n");
        }

        /// <summary>
        /// Menu function that is called in Program
        /// </summary>
        public static void Menu()
        {
            LibraryDb dbContext = new LibraryDb();

            Bookservice srvBook = new Bookservice(dbContext);
            Userservice usrService = new Userservice();

            bool keepRunning = true;
            while (true)
            {
                Logo();
                Console.WriteLine("##############################################");
                Console.WriteLine("Enter 1: Register book (CREATE)");
                Console.WriteLine("Enter 2: Consult book registered (READ)");
                Console.WriteLine("Enter 3: Consult all books (READ ALL)");
                Console.WriteLine("Enter 4: Change book (UPDATE)");
                Console.WriteLine("Enter 5: Remove book (DELETE)");
                Console.WriteLine("Enter 6: Register user");
                Console.WriteLine("Enter 7: Register loan");
                Console.WriteLine("Enter 8: Return book");
                Console.WriteLine("Enter 9: EXIT");
                Console.WriteLine("##############################################\n");
                Console.WriteLine($"Create by: Bruno Silva: {DateTime.Now}");

                Console.Write("\nEnter your option: ");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the title of the Book: ");
                        string title = Console.ReadLine()!;
                        Console.Write("Enter the author of the Book: ");
                        string autor = Console.ReadLine()!;
                        Console.Write("Enter the ISBN of the Book: ");
                        string isbn = Console.ReadLine()!;
                        Console.Write("Enter the year of publication: ");
                        int yearPublication = int.Parse(Console.ReadLine()!);

                        srvBook.RegisterBook(title, autor, isbn, yearPublication);                        
                        break;
                    case 2:
                        Console.Write("Enter the name of the Book or Author: ");
                        string searchTerm = Console.ReadLine()!;

                        srvBook.ConsultBookRegistered(searchTerm);                        
                        break;
                    case 3:
                        srvBook.ConsultAllBooks();
                        Console.Clear();                        
                        break;
                    case 4:
                        srvBook.ChangeBook();
                        break;
                    case 5:
                        srvBook.RemoveBook();
                        break;
                    case 6:
                        usrService.RegisterUser();
                        break;
                    case 7:
                        srvBook.RegisterLoan();
                        break;
                    case 8:
                        srvBook.ReturnBook();
                        break;
                    case 9:
                        Exit();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid Option!");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                        Menu();
                        break;
                }
            }                                   
        }

        public static void Exit()
        {
            Console.WriteLine("System being shut down!!!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
