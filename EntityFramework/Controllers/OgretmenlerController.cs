using EntityFramework.Data;
using EntityFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    public class OgretmenlerController : Controller
    {
        private readonly AppDbContext _context;

        public OgretmenlerController(AppDbContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult Index()
        {
            var ogretmenler = _context.Ogretmenler.ToList();
            return View(ogretmenler);
        }

        // GET: Create form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                _context.Ogretmenler.Add(ogretmen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ogretmen);
        }

        // GET: Edit form
        public IActionResult Edit(int id)
        {
            var ogretmen = _context.Ogretmenler.Find(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            return View(ogretmen);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                _context.Ogretmenler.Update(ogretmen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ogretmen);
        }

        // GET: Delete confirm
        public IActionResult Delete(int id)
        {
            var ogretmen = _context.Ogretmenler.Find(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            return View(ogretmen);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var ogretmen = _context.Ogretmenler.Find(id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            _context.Ogretmenler.Remove(ogretmen);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
