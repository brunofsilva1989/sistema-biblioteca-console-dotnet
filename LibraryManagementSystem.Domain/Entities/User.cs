using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class User
    {

        public User()
        {
            
        }

        public int Id { get; set; }
        public int CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
