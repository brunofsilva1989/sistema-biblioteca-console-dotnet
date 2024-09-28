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
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime Emprestimo { get; set; }

    }
}
