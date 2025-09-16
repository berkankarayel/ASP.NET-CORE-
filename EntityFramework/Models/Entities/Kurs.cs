using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntityFramework.Models.Entities
{
    public class Kurs
    {
        public int KursId { get; set; }   // Primary Key

        [Required(ErrorMessage = "Başlık zorunludur")]
        public string Baslik { get; set; }

        // 🔹 1 Öğretmen - n Kurs ilişkisi (Her kursun tek öğretmeni olur)
        [Required(ErrorMessage = "Öğretmen seçiniz")]
        public int OgretmenId { get; set; }

        [ValidateNever]  // ✅ Model binding sırasında Ogretmen zorunlu olmasın
        public Ogretmen Ogretmen { get; set; }

        // 🔹 n-n ilişki (Bir kursa birçok öğrenci katılabilir)
        [ValidateNever]
        public ICollection<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();
    }
}
