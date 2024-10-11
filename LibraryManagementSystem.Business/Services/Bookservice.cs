using LibraryManagementSystem.DataAccess.Context;
using LibraryManagementSystem.Domain.Entities;
using System.Collections.Concurrent;

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
        public void CreateBook(string title, string author, string isbn, int yearPublication)
        {
           
            Book newBook = new Book
            {               
                Title = title,
                Author = author,
                ISBN = isbn,
                YearPublication = yearPublication
            };

            _dbContext.AddNewBook(newBook);
            
            Console.WriteLine("Data saved successfully!");
            Thread.Sleep(1000);
            Console.Clear();
        }

        /// <summary>
        /// Method to consult a book using a term.
        /// </summary>
        /// <param name="searchTerm">Termo para busca no dicionário</param>
        public void ViewBookRegistered(string searchTerm)
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
        public void ListAllBooks()
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
                    Console.WriteLine($"Id: {book.Id},Titulo: {book.Title}, Author: {book.Author}, Ano: {book.YearPublication}");
                    Console.ResetColor();
                }
            }

            Thread.Sleep(5000);
            Console.WriteLine("Enter any key to go backs!");
            Console.ReadKey();            
        }

        /// <summary>
        /// Edit a book
        /// </summary>
        /// <param name="id"></param>
        public void EditBook(int id)
        {
            if (_dbContext.Books.ContainsKey(id))
            {
                Book bookToEdit = _dbContext.Books[id];

                Console.WriteLine($"Editando o livro: {bookToEdit.Title}");
                                
                Console.Write($"Edit title (press Enter to keep '{bookToEdit.Title}'): ");
                string newTitle = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(newTitle))
                    bookToEdit.Title = newTitle;

                Console.Write($"Edit author (press Enter to keep '{bookToEdit.Author}'): ");
                string newAuthor = Console.ReadLine()!;
                if(!string.IsNullOrWhiteSpace(newAuthor))
                    bookToEdit.Author = newAuthor;

                Console.Write($"Edit ISBN (press Enter to keep '{bookToEdit.ISBN}'): ");
                string newISBN = Console.ReadLine()!;
                if(!string.IsNullOrWhiteSpace(newISBN))
                    bookToEdit.ISBN = newISBN;

                Console.Write($"Edit year of publication (press Enter to keep '{bookToEdit.YearPublication}'): ");
                string yearInput = Console.ReadLine()!;
                if(int.TryParse(yearInput, out int newYear))
                    bookToEdit.YearPublication = newYear;

                Console.WriteLine("Book updated successfully!");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Book not Found!");
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBook(int id)
        {
            //Deletando um registro do dicionario
            if (_dbContext.Books.ContainsKey(id))
            {
                _dbContext.DeleteBook(id);                                
            }
            else
            {
                Console.WriteLine("Id não encontrado");
            }
                                 
        }    
    }
}
