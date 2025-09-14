using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using System.Linq;   // FirstOrDefault, Where gibi LINQ metotları için

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
            return View();
        }

       [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Repository.Products.Max(p => p.Id) + 1;
                Repository.Products.Add(model);
                return RedirectToAction("Index");
            }

            // valid değilse aynı formu hata mesajlarıyla göster
            return View(model);
        }
    }
}
