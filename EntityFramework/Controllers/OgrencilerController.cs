using EntityFramework.Data;
using EntityFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace EntityFramework.Controllers
{
    public class OgrencilerController : Controller
    {
        // dependency injection ile DbContext alıyoruz
        private readonly AppDbContext _context;
        // Constructor
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

        // GET: Edit formu
        public IActionResult Edit(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        // POST: Güncelleme işlemi
        [HttpPost]
        public IActionResult Edit(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Ogrenciler.Update(ogrenci);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ogrenci);


        }
   
       // GET: Silme onay sayfası
        public IActionResult Delete(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        // POST: Silme işlemi
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            _context.Ogrenciler.Remove(ogrenci);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Öğrenciyi kursa kaydetme formu (GET)
        public IActionResult KursaKaydet(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci == null) return NotFound();

            ViewBag.Kurslar = new SelectList(_context.Kurslar, "KursId", "Baslik");

            return View(new KursaKaydetViewModel
            {
                OgrenciId = ogrenci.OgrenciId
            });
        }

        // Kursa kaydetme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KursaKaydet(KursaKaydetViewModel model)
        {
            var ogrenci = _context.Ogrenciler
                .Include(o => o.Kurslar)
                .FirstOrDefault(o => o.OgrenciId == model.OgrenciId);

            if (ogrenci == null) return NotFound();

            var kurs = _context.Kurslar.Find(model.KursId);
            if (kurs == null) return NotFound();

            // Eğer zaten kayıtlı değilse ekle
            if (!ogrenci.Kurslar.Any(k => k.KursId == kurs.KursId))
            {
                ogrenci.Kurslar.Add(kurs);
                _context.SaveChanges();
            }

            return RedirectToAction("Details", new { id = ogrenci.OgrenciId });
        }

        // Öğrenci Detay
        public IActionResult Details(int id)
        {
            var ogrenci = _context.Ogrenciler
                .Include(o => o.Kurslar)
                .FirstOrDefault(o => o.OgrenciId == id);

            if (ogrenci == null) return NotFound();

            return View(ogrenci);
        }
    }
    
}
