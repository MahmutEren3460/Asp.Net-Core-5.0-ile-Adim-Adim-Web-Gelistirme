using System.ComponentModel.DataAnnotations;

namespace CoreCVDb.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen Resim URL Giriniz")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Şifre ile uyumlu değil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail { get; set; }
    }
}
