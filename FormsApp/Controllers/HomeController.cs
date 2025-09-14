using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;

namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Repository'deki ürünleri View'e gönderiyoruz
            return View(Repository.Products);
        }
    }
}
