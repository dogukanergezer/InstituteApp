using System.ComponentModel.DataAnnotations;

namespace InstituteApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
