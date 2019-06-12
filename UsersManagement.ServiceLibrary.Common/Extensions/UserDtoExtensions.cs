using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UsersManagement.ServiceLibrary.Common.Dtos;

namespace UsersManagement.ServiceLibrary.Common.Extensions
{
    public static class UserDtoExtensions
    {
        public static IdentityUser ToEntity(this UserDto source)
        {
            if (source == null) return null;
            var passwordHasher = new PasswordHasher();
            return new IdentityUser
            {
                UserName = source.Username,
                PasswordHash = passwordHasher.HashPassword(source.Password)
            };
        }

        public static UserDto ToUserDto(this IdentityUser source)
        {
            UserDto result = null;
            if (source != null)
            {
                result = new UserDto
                {
                    Id = source.Id,
                    Username = source.UserName,
                    Password = source.PasswordHash,
                };
            }
            return result;
        }
    }
}
