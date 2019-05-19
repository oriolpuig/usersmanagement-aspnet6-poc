using System.ComponentModel.DataAnnotations;

namespace UsersManagement.UI.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string RedirectUrl { get; set; }
    }
}