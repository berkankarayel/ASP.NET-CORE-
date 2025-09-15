using EntityFramework.Data;
using EntityFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    public class OgrencilerController : Controller
    {
        private readonly AppDbContext _context;

        public OgrencilerController(AppDbContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult Index()
        {
            var ogrenciler = _context.Ogrenciler.ToList();
            return View(ogrenciler);
        }

        // GET: Ekleme formu
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ekleme işlemi
        [HttpPost]
        public IActionResult Create(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Ogrenciler.Add(ogrenci);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ogrenci);
        }
    }
}
