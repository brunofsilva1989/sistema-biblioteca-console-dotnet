using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime Loans { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public LoanStatus Status { get; set; }

    }

    /// <summary>
    /// Enum de Status do Empréstimo
    /// </summary>
    public enum LoanStatus
    {
        Active,
        Returned,
        Overdue
    }
}
