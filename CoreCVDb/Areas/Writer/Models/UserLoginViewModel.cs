using System.ComponentModel.DataAnnotations;

namespace CoreCVDb.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adını giriniz...!")]
        public string UserName { get; set;}
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz...!")]
        public string Password { get; set;}
    }
}
