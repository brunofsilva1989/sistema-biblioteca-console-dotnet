using LibraryManagementSystem.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Services
{
    public class Userservice
    {
        private readonly LibraryDb _dbContext;

        public Userservice(LibraryDb dbContext)
        {
            _dbContext = dbContext;
        }

        public Userservice()
        {
            
        }

        public void RegisterUser()
        {

        }
    }
}
