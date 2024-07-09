using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using projectuniversity;

namespace Project_University.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<User> userList = _context.Users.ToList();
            return View(userList);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(User obj)
        {

            if (ModelState.IsValid)
            {
                _context.Users.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "User Created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //_context.categories.Find(id);
            User? user = _context.Users.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }
        [HttpPost]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "User Updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //_context.categories.Find(id);
            Customer? customer = _context.Customers.Find(id);
            if (customer != null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Customer? customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
