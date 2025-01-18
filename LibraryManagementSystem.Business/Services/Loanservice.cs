using LibraryManagementSystem.DataAccess.Context;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Business.Services
{
    public class Loanservice
    {

        private readonly LibraryDb _dbContext;

        public Loanservice(LibraryDb dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public int Id { get; set; }
        public string CPF { get; set; }
        public string Title { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Registro de empréstimo
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="title"></param>
        public void RegisterLoan(string cpf, int id)
        {            
            Loan newLoan = new Loan
            {
                IdUser = _dbContext.Users.Values.FirstOrDefault(x => x.CPF == cpf).Id,
                IdBook = _dbContext.Books.Values.FirstOrDefault(x => x.Id == id).Id,
                LoanDate = DateTime.Now,                
                ReturnDate = DateTime.Now.AddDays(3),
                Status = LoanStatus.Active
            };

            _dbContext.AddNewLoan(newLoan);

            Console.WriteLine("Loan registered successfully!");
            System.Console.WriteLine("Total loans in the system: " + _dbContext.Loans.Count);
            System.Console.WriteLine($"User: {_dbContext.Users.Values.FirstOrDefault(x => x.CPF == cpf).Name}");
            System.Console.WriteLine($"Book: {_dbContext.Books.Values.FirstOrDefault(x => x.Id == id).Title}");
            System.Console.WriteLine("Return Date: " + newLoan.ReturnDate);
            System.Console.WriteLine("Loan Date: " + newLoan.LoanDate);
            System.Console.WriteLine("Loan Status: " + newLoan.Status);
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Loan Return Record
        /// </summary>
        public void ReturnBook(int idLoan)
        {
            if(_dbContext.Loans.ContainsKey(idLoan))
            {
                Loan loan = _dbContext.Loans[idLoan];
                loan.Status = LoanStatus.Returned;
                _dbContext.ReturnLoan(idLoan);
                Console.WriteLine("Loan returned successfully!");
                Thread.Sleep(3000);
            }else
            {
                Console.WriteLine("Loan not found!");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// List Active Loans
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Loan> GetActiveLoans()
        {
            return new List<Loan>();
        }
    }
}
