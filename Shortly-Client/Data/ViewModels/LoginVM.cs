using Shortly_Client.Helpers.Validators;
using System.ComponentModel.DataAnnotations;

namespace Shortly_Client.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email address is required")]
        [CustomEmailValidator(ErrorMessage = "Email address is not valid(Custom)")]

        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long")] 
        public string Password { get; set; }
    }
}
