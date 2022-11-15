namespace Ef_Core_31.Models
{
    public class UserBook
    {
        public int UserBookId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
