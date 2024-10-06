using LibraryManagementSystem.DataAccess.Context;
using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Método para registrar um livro
        /// </summary>
        /// <param name="title">Título do Livro</param>
        /// <param name="author">Autor do Livro</param>
        /// <param name="isbn">Número que identifica o livro internacionalmente</param>
        /// <param name="yearPublication">Ano da publicação</param>
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

            Console.WriteLine("Dados Gravados com sucesso!");
            Console.Clear();
        }


        /// <summary>
        /// Método para consultar um livro a partir de um termo.
        /// </summary>
        /// <param name="searchTerm">Termo para busca no dicionário</param>
        public void ConsultBookRegistered(string searchTerm)
        {
            // Busca o termo digitado no método, e busca se tem ou o titulo do livro 
            // ou o Autor ignorando se é maiusculo ou minusculo
            var searchBooks = _dbContext.Books.Values
                .Where(book => book.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                            || book.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (searchBooks.Any())
            {
                Console.WriteLine("Livros encontrados:");
                foreach (var book in searchBooks)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Titulo: {book.Title}, Author: {book.Author}, Ano: {book.YearPublication}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Nenhum livro encontrado");
            }

            Thread.Sleep(5000);
            Console.Clear();
        }


        /// <summary>
        /// Método para retornar todos os Books
        /// </summary>
        public void ConsultAllBooks()
        {
            var consultAllBooks = _dbContext.Books.Values;


            if (consultAllBooks.Any())
            {
                Console.WriteLine("Todos os Livros:");
                foreach (var book in consultAllBooks)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Titulo: {book.Title}, Author: {book.Author}, Ano: {book.YearPublication}");
                    Console.ResetColor();
                }
            }else
            { 
                Console.WriteLine("Nenhum Livro encontrado"); 
            }

            Thread.Sleep(8000);
            Console.WriteLine("Digite qualquer tecla para voltar!");
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
