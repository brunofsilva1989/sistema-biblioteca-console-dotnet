namespace LibraryManagementSystem.Domain.Entities
{
    public class Book
    {

        public Book(string title, string author, string isbn, int yearPublication)
        {               
            Title = title;
            Author = author;
            ISBN = isbn;
            YearPublication = yearPublication;
        }

        public Book()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublication { get; set; }
    }
}
