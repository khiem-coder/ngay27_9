using System.ComponentModel.DataAnnotations;

namespace GETandPUT.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Username")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}