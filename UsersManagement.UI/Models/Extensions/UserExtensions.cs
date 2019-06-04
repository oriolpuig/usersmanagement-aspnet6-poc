using System.Security.Principal;
using UsersManagement.Crosscutting.Enums;
using UsersManagement.Crosscutting.Helpers;

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
    }
}