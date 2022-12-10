using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models.DTOs.Requests
{
    public class RegistRequest
    {
        [Required]
       // [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
       /* [RegularExpression("/(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8}/g",
         ErrorMessage = "Password must meet requirements")]*/
        public string Password { get; set; }

       /* [RegularExpression("/(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8}/g",
             ErrorMessage = "Password must meet requirements")]*/
        [Compare("Password", ErrorMessage = "Confirm password not match !")]
        public string ConfirmPassWord { get; set; }
    }
}
