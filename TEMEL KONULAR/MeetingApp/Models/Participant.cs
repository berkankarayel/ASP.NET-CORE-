using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunlu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunlu")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email alanı zorunlu")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Katılım durumunuzu belirtiniz")]
        public bool? WillAttend { get; set; } // bool? = nullable, seçilmezse null olur
    }
}

