using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "password has to be at least 6 characters")]
        public string Password { get; set; }

        //[Required]
        public string? ReturnUrl { get; set; }
    }
}
