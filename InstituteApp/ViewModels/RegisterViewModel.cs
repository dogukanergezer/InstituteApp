using System.ComponentModel.DataAnnotations;

namespace InstituteApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email  boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre  boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
