using Ef_Core_31.Models;
using Ef_Core_31.MyDbContext;
using Microsoft.AspNetCore.Mvc;

namespace Ef_Core_31.Controllers
{
    public class UserController : Controller
    {

        public UserController() {}

        [HttpGet]
        public async Task<IActionResult> AddUser() 
        {
            var user = new User();
            return View(user);

        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            using (var db = new DatabaseContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }


        public async Task<List<User>> GetUsers()
        {
            List<User> User = new List<User>();
            using (var db = new DatabaseContext())
            {
                User = db.Users.ToList();

            }
            return User;
        }

        public async Task<IActionResult> InfoForUsers()
        {
            List<User> User = new List<User>();
            using (var db = new DatabaseContext())
            {
                User = db.Users.ToList();

            }
            return View(User);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookForUser(int id)
        {

            var user = new User();
            return View(user);

        }
        [HttpPost]
        public async Task<IActionResult> GetBookForUser(User user)
        {
            using (var db = new DatabaseContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
