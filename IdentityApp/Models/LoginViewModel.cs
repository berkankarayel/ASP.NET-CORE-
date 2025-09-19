using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-posta gerekli")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gerekli")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
