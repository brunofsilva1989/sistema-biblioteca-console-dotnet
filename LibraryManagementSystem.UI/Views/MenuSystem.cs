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
            Console.WriteLine(@"
██╗░░░░░██╗██████╗░██████╗░░█████╗░██████╗░██╗░░░██╗  ░██████╗██╗░░░██╗░██████╗████████╗███████╗███╗░░░███╗
██║░░░░░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗░██╔╝  ██╔════╝╚██╗░██╔╝██╔════╝╚══██╔══╝██╔════╝████╗░████║
██║░░░░░██║██████╦╝██████╔╝███████║██████╔╝░╚████╔╝░  ╚█████╗░░╚████╔╝░╚█████╗░░░░██║░░░█████╗░░██╔████╔██║
██║░░░░░██║██╔══██╗██╔══██╗██╔══██║██╔══██╗░░╚██╔╝░░  ░╚═══██╗░░╚██╔╝░░░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║
███████╗██║██████╦╝██║░░██║██║░░██║██║░░██║░░░██║░░░  ██████╔╝░░░██║░░░██████╔╝░░░██║░░░███████╗██║░╚═╝░██║
╚══════╝╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░  ╚═════╝░░░░╚═╝░░░╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝" + "\n");
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
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║           MAIN MENU            ║");
                Console.WriteLine("╚════════════════════════════════╝");
                Console.WriteLine("Enter 1: Add a new book");
                Console.WriteLine("Enter 2: View book details");
                Console.WriteLine("Enter 3: List all books");
                Console.WriteLine("Enter 4: Edit book details");
                Console.WriteLine("Enter 5: Delete a book");
                Console.WriteLine("Enter 6: Register new user");
                Console.WriteLine("Enter 7: Register a loan");
                Console.WriteLine("Enter 8: Return a book");
                Console.WriteLine("Enter 9: EXIT");
                Console.WriteLine("────────────────────────────────\n");
                Console.WriteLine($"Create by: Bruno Silva - {DateTime.Now}");

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

                        srvBook.CreateBook(title, autor, isbn, yearPublication);                        
                        break;
                    case 2:
                        Console.Write("Enter the name of the Book or Author: ");
                        string searchTerm = Console.ReadLine()!;

                        srvBook.ViewBookRegistered(searchTerm);                        
                        break;
                    case 3:
                        srvBook.ListAllBooks();
                        Console.Clear();                        
                        break;
                    case 4:
                        Console.Write("Enter the book ID to edit: ");
                        int editId = int.Parse(Console.ReadLine()!);
                        srvBook.EditBook(editId);
                        break;
                    case 5:
                        Console.Write("Enter the book ID to delete: ");
                        int delById = int.Parse(Console.ReadLine()!);
                        srvBook.DeleteBook(delById);
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
