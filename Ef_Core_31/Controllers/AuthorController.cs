using Ef_Core_31.Models;
using Ef_Core_31.MyDbContext;
using Microsoft.AspNetCore.Mvc;

namespace Ef_Core_31.Controllers
{
    public class AuthorController: Controller
    {
        public AuthorController() {}

        [HttpGet]
        public async Task<IActionResult> AddAuthor()
        {
            var Author = new Author();
            return View(Author);

        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            using (var db = new DatabaseContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<List<Author>> GetAuthors()
        {
            List<Author> Author = new List<Author>();
            using (var db = new DatabaseContext())
            {
                Author =  db.Authors.ToList();
               
            }
            return Author;
        }

    }
}
