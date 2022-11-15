using Ef_Core_31.Models;
using Ef_Core_31.MyDbContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ef_Core_31.Controllers
{
    public class UserBookController : Controller
    {
        public async Task<IActionResult> Index()
        {

            UserController userController = new UserController();
            BookController bookController = new BookController();
            AuthorController authorController = new AuthorController(); 

            List<UserBook> UserBook = new List<UserBook>();

            using (var db = new DatabaseContext())
            {
                UserBook = db.UserBooks.ToList();
            }

            var users = await userController.GetUsers();
            var books = await bookController.GetBooks();
            var Author = await authorController.GetAuthors();

            var sort1 = UserBook.Join(users, q => q.UserId, c => c.UserId, (q, c) => new
            {
                BookId = q.BookId,
                FirstName = c.FirstName,
                LastName = c.LastName

            });

            var sort2 = sort1.Join(books, q => q.BookId, c => c.BookId, (q, c) => new
            {
                
                FirstName = q.FirstName,
                LastName = q.LastName,
                BookName = c.Name,
                BooYear = c.Year,
                AuthorId = c.AuthorId

            });
        
            var sort3 = sort2.Join(Author, q => q.AuthorId, c => c.AuthorId, (q, c) => new
            {
                FirstName = q.FirstName,
                LastName = q.LastName,
                BookName = q.BookName,
                BooYear = q.BooYear,
                AuthorFullName = $"{c.FirstName} {c.LastName}"
            });

            var viewUserBookAuthor = new List<ViewUserBookAuthor>()
       

            foreach (var fullInfa in books)
            {
                viewUserBookAuthor.Add(new ViewUserBookAuthor()
                {
                    FirstName = fullInfa.Fir
                });
            }
         

            return View(sort3);
        }





    }
}
