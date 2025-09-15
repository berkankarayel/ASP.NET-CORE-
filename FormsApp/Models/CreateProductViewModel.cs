using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Models
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; } = new Product();
        public SelectList Categories { get; set; } = new SelectList(new List<Category>(), "Id", "Name");
    }
}
