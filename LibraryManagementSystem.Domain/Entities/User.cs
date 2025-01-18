namespace LibraryManagementSystem.Domain.Entities
{
    public class User
    {
        private static int lastGenericId = 1;

        public User() { }

        public User(string name, string cpf, string email)
        {
            Id = GenericGenerateId();
            Name = name;
            CPF = cpf;            
            Email = email;
        }
               
        public int Id { get; private set; } 
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int GenericGenerateId()
        {
            lastGenericId++;
            return lastGenericId;
        }
    }
}
