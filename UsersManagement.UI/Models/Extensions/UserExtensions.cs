using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using UsersManagement.Crosscutting.Enums;
using UsersManagement.Crosscutting.Helpers;
using UsersManagement.ServiceLibrary.Common.Dtos;
using UsersManagement.UI.Models.Users;

namespace UsersManagement.UI.Models.Extensions
{
    public static class UserExtensions
    {
        public static bool IsAdmin(this IPrincipal source)
        {
            return source.IsInRole(RolesEnum.Admin.GetDescription());
        }

        public static bool IsPage1(this IPrincipal source)
        {
            return source.IsInRole(RolesEnum.PAGE_1.GetDescription());
        }

        public static bool IsPage2(this IPrincipal source)
        {
            return source.IsInRole(RolesEnum.PAGE_2.GetDescription());
        }

        public static bool IsPage3(this IPrincipal source)
        {
            return source.IsInRole(RolesEnum.PAGE_3.GetDescription());
        }

        public static UserDto ToUserDto(this UserViewModel source)
        {
            if (source == null) return null;
            return new UserDto
            {
                Id = source.Id,
                Username = source.Username,
                Password = source.Password,
                Roles = source.Roles
            };
        }

        public static UserViewModel ToUserViewModel(this UserDto source)
        {
            if (source == null) return null;
            return new UserViewModel
            {
                Id = source.Id,
                Username = source.Username,
                Password = source.Password,
                Roles = source.Roles
            };
        }

        public static IEnumerable<UserViewModel> ToUserListViewModel(this IEnumerable<UserDto> source)
        {
            if (source == null) return new List<UserViewModel>();
            return source.Select(u => u.ToUserViewModel());
        }
    }
}