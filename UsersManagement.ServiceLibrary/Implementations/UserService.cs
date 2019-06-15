using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.ServiceLibrary.Common.Dtos;
using UsersManagement.ServiceLibrary.Common.Extensions;

namespace UsersManagement.ServiceLibrary.Implementations
{
    public class UserService : IUserService
    {
        public IEnumerable<UserDto> GetAllUsers()
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            return userManager.Users.ToUserListDto(roleManager.Roles);
        }

        public UserDto GetUser(string id)
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.FindById(id);
            return user.ToUserDto(roleManager.Roles);
        }

        public IdentityUser CreateUser(UserDto newUser)
        {
            var newUserIdentity = newUser.ToEntity();
            if (newUserIdentity == null) throw new System.Exception("Error saving user.");
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            userManager.Create(newUserIdentity);
            return userManager.FindByName(newUserIdentity.UserName);
        }

        public bool UpdateUser(string id, UserDto userToUpdate)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var currentIdentityUser = userManager.FindById(id);
            if (currentIdentityUser == null) throw new System.Exception("User not found on DB.");
            currentIdentityUser.UserName = userToUpdate.Username;
            var passwordHasher = new PasswordHasher();
            var isSamePassword = passwordHasher.VerifyHashedPassword(currentIdentityUser.PasswordHash, userToUpdate.Password);
            if (isSamePassword == PasswordVerificationResult.Failed)
            {
                currentIdentityUser.PasswordHash = passwordHasher.HashPassword(userToUpdate.Password);
            }
            var result = userManager.Update(currentIdentityUser);
            return result.Succeeded;
        }

        public bool DeleteUser(string id)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var currentIdentityUser = userManager.FindById(id);
            var result = userManager.Delete(currentIdentityUser);
            return result.Succeeded;
        }
    }
}
