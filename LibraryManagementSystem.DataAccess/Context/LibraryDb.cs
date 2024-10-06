using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.DataAccess.Context
{
    public class LibraryDb
    {
        // Dicionario de Users
        public Dictionary<string, User> Users = new Dictionary<string, User>();

        // Dicionario de Books
        public Dictionary<Guid, Book> Books = new Dictionary<Guid, Book>();
        

        // Dicionario de Loans
        public Dictionary<int, Loan> Loans = new Dictionary<int, Loan>();

        public LibraryDb()
        {
            Users = new Dictionary<string, User>();            
            Books = new Dictionary<Guid, Book>();
            Loans = new Dictionary<int, Loan>();

            AddSampleBook();
        }

        public void AddSampleBook()
        {
            Books.Add(Guid.NewGuid(), new Book { Title = "Harry Potter e a Pedra Filosofal", Author = "J.K. Rowling", ISBN = "8532511015", YearPublication = 1997 });
            Books.Add(Guid.NewGuid(), new Book { Title = "O Senhor dos Anéis: A Sociedade do Anel", Author = "J.R.R. Tolkien", ISBN = "8533613400", YearPublication = 1954 });
            Books.Add(Guid.NewGuid(), new Book { Title = "O Código Da Vinci", Author = "Dan Brown", ISBN = "8501068956", YearPublication = 2003 });
        }



    }
}
