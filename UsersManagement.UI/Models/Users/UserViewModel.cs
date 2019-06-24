using System.Collections.Generic;

namespace UsersManagement.UI.Models.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}