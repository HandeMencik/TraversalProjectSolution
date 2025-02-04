using System.ComponentModel.DataAnnotations;

namespace TraversalReservationProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Email Adresinizi Giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrenizi tekrar giriniz.")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil.")]
        public string ConfirmPassword { get; set; }
    }
}
