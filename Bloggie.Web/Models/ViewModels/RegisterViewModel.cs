using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }    

        [Required] 
        [EmailAddress]
        public string Email { get; set; }

        [Required] //server-side validations, it's always better to use server side validations, because client side validations can be turned off easily
        [MinLength(6, ErrorMessage = "password has to be at least 6 characters")] //we can also customize our error message
        public string Password { get; set; } 
    }
}
