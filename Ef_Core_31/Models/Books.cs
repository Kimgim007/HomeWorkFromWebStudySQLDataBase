namespace Ef_Core_31.Models
{
    public class Books
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        
        public int AuthorId { get; set; }
        public Authors Author { get; set; }

        public int Year { get; set; }
    }
}
