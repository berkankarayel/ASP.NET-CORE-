using EntityFramework.Data;
using EntityFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    public class KurslarController : Controller
    {
        private readonly AppDbContext _context;

        public KurslarController(AppDbContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult Index()
        {
            var kurslar = _context.Kurslar
                .Include(k => k.Ogretmen) // Öğretmen bilgisini de getir
                .ToList();

            return View(kurslar);
        }

        // GET: Create form
        public IActionResult Create()
        {
            DoldurOgretmenler();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kurs kurs)
        {
    if (!ModelState.IsValid)
    {
        Console.WriteLine("❌ ModelState hatalı");
        foreach (var kvp in ModelState)
        {
            foreach (var error in kvp.Value.Errors)
            {
                Console.WriteLine($"Key: {kvp.Key} - Error: {error.ErrorMessage}");
            }
        }
    }
    else
    {
        Console.WriteLine("✅ ModelState valid, Kurs kaydediliyor...");
    }

    if (ModelState.IsValid)
    {
        _context.Kurslar.Add(kurs);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    DoldurOgretmenler(kurs.OgretmenId);
    return View(kurs);
}


        // GET: Edit form
        public IActionResult Edit(int id)
        {
            var kurs = _context.Kurslar.Find(id);
            if (kurs == null) return NotFound();

            DoldurOgretmenler(kurs.OgretmenId);
            return View(kurs);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                _context.Kurslar.Update(kurs);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            DoldurOgretmenler(kurs.OgretmenId);
            return View(kurs);
        }

        // GET: Delete confirm
        public IActionResult Delete(int id)
        {
            var kurs = _context.Kurslar
                .Include(k => k.Ogretmen)
                .FirstOrDefault(k => k.KursId == id);

            if (kurs == null) return NotFound();

            return View(kurs);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kurs = _context.Kurslar.Find(id);
            if (kurs == null) return NotFound();

            _context.Kurslar.Remove(kurs);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // 🔹 Yardımcı metot
        private void DoldurOgretmenler(int? seciliId = null)
        {
            ViewBag.Ogretmenler = new SelectList(
                _context.Ogretmenler
                    .Select(o => new
                    {
                        o.OgretmenId,
                        AdSoyad = o.Ad + " " + o.Soyad
                    }),
                "OgretmenId",
                "AdSoyad",
                seciliId
            );
        }
    }
}
