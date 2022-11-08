namespace Ef_Core_31.Models
{
    public class Books
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        
        public int AuthorId { get; set; }
        public Authors Author { get; set; }

        public DateTime Year { get; set; }

        public ICollection<Books> UserBooks { get; set; }
    }
}
