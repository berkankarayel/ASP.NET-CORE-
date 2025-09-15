using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using System.Linq;   // FirstOrDefault, Where gibi LINQ metotları için
using Microsoft.AspNetCore.Mvc.Rendering;
namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {
        // Ürünleri listeleme + kategoriye göre filtreleme
        public IActionResult Index(int? id)
        {
            var products = Repository.Products;

            if (id.HasValue && id > 0)
            {
                products = products.Where(p => p.CategoryId == id).ToList();
            }

            var viewModel = new ProductViewModel
            {
                Products = products,
                Categories = Repository.Categories,
                SelectedCategory = id
            };

            return View(viewModel);
        }


        // Ürün detaylarını gösterme
        public IActionResult Details(int id)
        {
            var product = Repository.Products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        // Kategori listesini sağlama

        public IActionResult Categories()
        {
            var categories = Repository.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateProductViewModel
            {
                Product = new Product(),
                Categories = new SelectList(Repository.Categories, "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
public IActionResult Create(CreateProductViewModel model, IFormFile imageFile)
{
    if (ModelState.IsValid)
    {
        // Eğer resim seçildiyse kaydet
        if (imageFile != null && imageFile.Length > 0)
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            // Ürün resim yolunu ayarla
            model.Product.Image = "/img/" + fileName;
        }

        // Yeni ürün Id’si ata
        model.Product.Id = Repository.Products.Max(p => p.Id) + 1;

        // Repository’ye ekle
        Repository.Products.Add(model.Product);

        return RedirectToAction("Index");
    }

    // Eğer valid değilse kategorileri tekrar yükle
    model.Categories = new SelectList(Repository.Categories, "Id", "Name");
    return View(model);
}


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = Repository.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // Eğer ürün bulunamazsa 404 döner
            }

            var viewModel = new CreateProductViewModel
            {
                Product = product,
                Categories = new SelectList(Repository.Categories, "Id", "Name", product.CategoryId)
            };

            return View(viewModel);
        }

        [HttpPost]
public IActionResult Edit(int id, CreateProductViewModel model)
{
    if (ModelState.IsValid)
    {
        var product = Repository.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        // Güncelleme işlemi
        product.Name = model.Product.Name;
        product.Price = model.Product.Price;
        product.CategoryId = model.Product.CategoryId;
        product.IsActive = model.Product.IsActive;
        product.Image = model.Product.Image;
        

        return RedirectToAction("Index");
    }

    // Validasyon başarısızsa form tekrar gösterilsin
    model.Categories = new SelectList(Repository.Categories, "Id", "Name", model.Product.CategoryId);
    return View(model);
}
            

    }
}
