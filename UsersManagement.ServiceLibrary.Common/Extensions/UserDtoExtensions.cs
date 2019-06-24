using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
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

        public static UserDto ToUserDto(this IdentityUser source, IEnumerable<IdentityRole> roles)
        {
            UserDto result = null;
            if (source != null)
            {
                result = new UserDto
                {
                    Id = source.Id,
                    Username = source.UserName,
                    Password = source.PasswordHash,
                    Roles = source.Roles.Select(r => roles.FirstOrDefault(ir => ir.Id == r.RoleId).Name).ToList()
                };
            }
            return result;
        }


        public static IEnumerable<UserDto> ToUserListDto(this IEnumerable<IdentityUser> source, IEnumerable<IdentityRole> roles)
        {
            if (source == null) return new List<UserDto>();
            return source.Select(u => u.ToUserDto(roles));
        }
    }
}
