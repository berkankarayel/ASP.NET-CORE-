using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100000, ErrorMessage = "Fiyat 1 ile 100000 arasında olmalıdır.")]
        public decimal Price { get; set; }

        public string? Image { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Kategori seçilmelidir.")]
        public int CategoryId { get; set; }
    }
}
