using LibraryManagementSystem.DataAccess.Context;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Business.Services
{
    public class Userservice
    {
        private readonly LibraryDb _dbContext;

        public Userservice()
        {

        }

        public Userservice(LibraryDb dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        public void RegisterUser(string nome, string cpf, string email)
        {

            //validação de cpf já existe na base
            if (_dbContext.Users.Values.Any(x => x.CPF == cpf))
            {
                Console.WriteLine("CPF already registered!");
                Thread.Sleep(2000);                
                Console.Clear();
                return;
            }
        
            User user = new User
            {                
                Name = nome,
                CPF = cpf,
                Email = email                
            };

            _dbContext.AddNewUser(user);
            
            Console.WriteLine("User registered successfully!");
            System.Console.WriteLine("Total de usuários no sistema: " + _dbContext.Users.Count);
            Thread.Sleep(1000);
            Console.Clear();
        }

        /// <summary>
        /// Visualizar Usuários
        /// </summary>
        public void ViewUsers()
        {

            System.Console.WriteLine("Total de usuários no sistema: " + _dbContext.Users.Count);

            if (_dbContext.Users.Count == 0)
            {
                Console.WriteLine("No users found!");
            }
            else
            {
                foreach (var user in _dbContext.Users.Values)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, CPF: {user.CPF}, E-mail: {user.Email}");
                    Console.ResetColor();
                }
            }
            
            Console.WriteLine("Enter any key to go backs!");
            Console.ReadKey();
        }
    }
}
