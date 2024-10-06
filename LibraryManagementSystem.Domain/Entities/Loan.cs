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

    }
}
