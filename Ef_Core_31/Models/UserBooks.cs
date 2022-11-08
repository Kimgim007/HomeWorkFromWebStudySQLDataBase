namespace Ef_Core_31.Models
{
    public class UserBooks
    {
        public int UserBookId { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public int BookId { get; set; }
        public Books Book { get; set; }

    }
}
