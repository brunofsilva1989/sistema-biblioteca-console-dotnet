using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.DataAccess.Context
{
    public class LibraryDb
    {
        private static int lastId = 3; 
        private static int lastGenericId = 0;
        
        public Dictionary<int, User> Users = new Dictionary<int, User>();
        
        public Dictionary<int, Book> Books = new Dictionary<int, Book>();
                
        public Dictionary<int, Loan> Loans = new Dictionary<int, Loan>();

        public LibraryDb()
        {
            Users = new Dictionary<int, User>();            
            Books = new Dictionary<int, Book>();
            Loans = new Dictionary<int, Loan>();

            AddSampleBook();            
        }

        /// <summary>
        /// Books Add
        /// </summary>
        public void AddSampleBook()
        {
            Books.Add(1, new Book {Id = 1, Title = "Harry Potter e a Pedra Filosofal", Author = "J.K. Rowling", ISBN = "8532511015", YearPublication = 1997 });
            Books.Add(2, new Book {Id = 2, Title = "O Senhor dos Anéis: A Sociedade do Anel", Author = "J.R.R. Tolkien", ISBN = "8533613400", YearPublication = 1954 });
            Books.Add(3, new Book {Id = 3, Title = "O Código Da Vinci", Author = "Dan Brown", ISBN = "8501068956", YearPublication = 2003 });
        }

        /// <summary>
        /// Book Add
        /// </summary>
        /// <param name="newBook"></param>
        public void AddNewBook(Book newBook)
        {
            int newId = GenerateId();
            newBook.Id = newId;
            Books.Add(newId, newBook);
            Console.WriteLine("Book Add!");
        }

        /// <summary>
        /// New Loan
        /// </summary>
        public void AddNewLoan(Loan newLoan)
        {
            //cadastrar novo emprestimo
            int newIdLoan = GenericGenerateId();
            newLoan.Id = newIdLoan;
            Loans.Add(newIdLoan,newLoan);
            System.Console.WriteLine("Loan Add!");
        }

        public void ReturnLoan(int id)
        {
            Loans.Remove(id);
            Console.WriteLine("Successfully returned Loan!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Add new user
        /// </summary>
        public void AddNewUser(User newUser)
        {           
            Users.Add(newUser.Id, newUser);
            Console.WriteLine("User Add!");
        }

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBook(int id)
        {
            Books.Remove(id);
            Console.WriteLine("Successfully deleted Book!");
            Thread.Sleep(3000);
        }
        
        /// <summary>
        /// Função para gerar Id's
        /// </summary>
        /// <returns></returns>
        public int GenerateId()
        {
            lastId++;
            return lastId;
        }

        public int GenericGenerateId()
        {
            lastGenericId++;
            return lastGenericId;
        }

    }
}
