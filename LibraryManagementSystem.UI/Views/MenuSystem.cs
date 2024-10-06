using LibraryManagementSystem.Business.Services;
using LibraryManagementSystem.DataAccess.Context;

namespace LibraryManagementSystem.ConsoleApp.Views
{
    public class MenuSystem
    {
        public static void Logo()
        {
            Console.WriteLine(@"L̲I̲B̲R̲A̲R̲Y̲ M̲A̲N̲A̲G̲E̲M̲E̲N̲T̲ S̲Y̲S̲T̲E̲M̲" + "\n");
        }

        /// <summary>
        /// Função de Menu que é chamanada na Program
        /// </summary>
        public static void Menu()
        {

            Logo();
            Console.WriteLine("##############################################");
            Console.WriteLine("Digite 1: Register book (CREATE)");
            Console.WriteLine("Digite 2: Consult book registered (READ)");
            Console.WriteLine("Digite 3: Consult all books (READ ALL)");
            Console.WriteLine("Digite 4: Change book (UPDATE)");
            Console.WriteLine("Digite 5: Remove book (DELETE)");
            Console.WriteLine("Digite 6: Register user");
            Console.WriteLine("Digite 7: Register loan");
            Console.WriteLine("Digite 8: Return book");
            Console.WriteLine("##############################################\n");

            Console.Write("\nDigite a sua opção:");
            int choice = Convert.ToInt32(Console.ReadLine());

            LibraryDb dbContext = new LibraryDb();
            Bookservice srvBook = new Bookservice(dbContext);
            Userservice usrService = new Userservice();

            switch (choice)
            {
                case 1:
                    Console.Write("Digite o título do Livro: ");
                    string title = Console.ReadLine()!;
                    Console.Write("Digite o autor do Livro: ");
                    string autor = Console.ReadLine()!;
                    Console.Write("Digite o ISBN do Livro: ");
                    string isbn = Console.ReadLine()!;
                    Console.Write("Digite o ano de publicação: ");
                    int yearPublication = int.Parse(Console.ReadLine()!);

                    srvBook.RegisterBook(title, autor, isbn, yearPublication);
                    Menu();
                    break;
                case 2:
                    Console.Write("Digite o nome do Livro ou Author: ");
                    string searchTerm = Console.ReadLine()!;

                    srvBook.ConsultBookRegistered(searchTerm);
                    Menu();
                    break;
                case 3:
                    srvBook.ConsultAllBooks();
                    Console.Clear();
                    Menu();
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

            Console.WriteLine("Create by: Bruno Silva: \n" + DateTime.Now);
            Console.ReadKey();
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }



    }
}
