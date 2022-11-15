namespace Ef_Core_31.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BithDate { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
