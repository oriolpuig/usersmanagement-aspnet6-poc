using System;
using System.Collections.Generic;

namespace UsersManagement.ServiceLibrary.Common.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
