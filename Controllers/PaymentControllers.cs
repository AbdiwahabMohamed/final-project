using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Project_University;

namespace Project_University.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Payment> paymentList = _context.Payments.ToList();
            return View(paymentList);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Payment obj)
        {

            if (ModelState.IsValid)
            {
                _context.Payments.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Payment Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //_context.categories.Find(id);
            Payment? payment = _context.Payments.FirstOrDefault(c => c.Id == id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);

        }
        [HttpPost]
        public IActionResult Edit(Payment obj)
        {
            if (ModelState.IsValid)
            {
                _context.Payments.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Payment Updated successfully";
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
            Payment? payment = _context.Payments.Find(id);
            if (payment != null)
            {
                return NotFound();
            }
            return View(payment);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Payment? payment = _context.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            _context.SaveChanges();
            TempData["success"] = "payment Deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
