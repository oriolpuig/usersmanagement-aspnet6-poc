using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UsersManagement.ServiceLibrary.Common.Contracts;

namespace UsersManagement.ServiceLibrary.Implementations
{
    public class UserService : IUserService
    {
        public IEnumerable<IdentityUser> GetAllUsers()
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            return userManager.Users;
        }
    }
}
