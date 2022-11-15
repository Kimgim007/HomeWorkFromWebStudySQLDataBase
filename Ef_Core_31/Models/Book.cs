

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ef_Core_31.Models
{
    public class Book
    {
     
        public int BookId { get; set; }
        public string Name { get; set; }
        
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [NotMapped]
        public List<SelectListItem> AuthorList { get; set; }

        public DateTime Year { get; set; }

        public ICollection<UserBook> UserBooks { get; set; }

     
    }
}
