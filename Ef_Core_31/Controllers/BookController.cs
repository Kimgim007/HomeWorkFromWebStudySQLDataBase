using Ef_Core_31.Models;
using Ef_Core_31.MyDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Ef_Core_31.Controllers
{
    public class BookController:Controller
    {
        [HttpGet]
        public async Task<IActionResult> AddBook()
        {

            AuthorController authorController = new AuthorController();

            var authors = await authorController.GetAuthors();
            var authorsSelectListItem = authors.Select(q => new SelectListItem() { Text = $"{q.FirstName} {q.LastName}", Value = q.AuthorId.ToString() });

            var book = new Book()
            {
               AuthorList = authorsSelectListItem.ToList()
            };
            return View(book);

        }
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            using (var db = new DatabaseContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<List<Book>> GetBooks()
        {
            List<Book> Book = new List<Book>();
            using (var db = new DatabaseContext())
            {
                Book = db.Books.ToList();

            }
            return Book;
        }
        public async Task<Book> GetBook(int id)
        {
            Book Book = new Book();
            using (var db = new DatabaseContext())
            {
                Book = db.Books.First(q => q.BookId == id);

            }
            return Book;
        }

    }
}
