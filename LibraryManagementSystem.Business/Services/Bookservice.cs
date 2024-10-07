using LibraryManagementSystem.DataAccess.Context;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Business.Services
{
    public class Bookservice
    {

        private readonly LibraryDb _dbContext;

        public Bookservice(LibraryDb dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Method for registering a book
        /// </summary>
        /// <param name="title">Book Title</param>
        /// <param name="author">Book Author</param>
        /// <param name="isbn">Number that identifies the book internationally</param>
        /// <param name="yearPublication">Year of publication</param>
        public void RegisterBook(string title, string author, string isbn, int yearPublication)
        {

            Guid bookid = Guid.NewGuid();

            Book newBook = new Book
            {
                Id = bookid,
                Title = title,
                Author = author,
                ISBN = isbn,
                YearPublication = yearPublication
            };

            _dbContext.Books[bookid] = newBook;
            
            Console.WriteLine("Data saved successfully!");
            Thread.Sleep(1000);
            Console.Clear();
        }


        /// <summary>
        /// Método para consultar um livro a partir de um termo.
        /// </summary>
        /// <param name="searchTerm">Termo para busca no dicionário</param>
        public void ConsultBookRegistered(string searchTerm)
        {
            bool keepRunning = true;
            // Busca o termo digitado no método, e busca se tem ou o titulo do livro 
            // ou o Autor ignorando se é maiusculo ou minusculo                                   
            while (keepRunning) 
            {
                var searchBooks = _dbContext.Books.Values
             .Where(book => book.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                         || book.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                if (searchBooks.Any())
                {
                    Console.WriteLine("Books found:");
                    foreach (var book in searchBooks)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Titulo: {book.Title}, Author: {book.Author}, Ano: {book.YearPublication}");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("No books found");
                }
               
                Console.WriteLine("\nWant to search for another book? (Y/N): ");
                string response = Console.ReadLine()?.Trim().ToLower();

                if(response == "n")
                {
                    keepRunning = false;
                }else if(response == "y")
                {
                    Console.WriteLine("Enter the name of the Book or Author: ");
                    searchTerm = Console.ReadLine()!;
                }
                else
                {
                    Console.WriteLine("Invalid Option. Returning to the menu");
                    keepRunning = false;
                }
            }            
            Console.Clear();
        }


        /// <summary>
        /// Method to return all Books
        /// </summary>
        public void ConsultAllBooks()
        {
            if(_dbContext.Books.Count == 0)
            {
                Console.WriteLine("No books found");
            }
            else
            {
                foreach (var book in _dbContext.Books.Values)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Titulo: {book.Title}, Author: {book.Author}, Ano: {book.YearPublication}");
                    Console.ResetColor();
                }
            }

            Thread.Sleep(5000);
            Console.WriteLine("Enter any key to go backs!");
            Console.ReadKey();            
        }

        public void ChangeBook()
        {

        }

        public void RemoveBook()
        {

        }

        public void RegisterLoan()
        {

        }

        public void ReturnBook()
        {

        }
    }
}
