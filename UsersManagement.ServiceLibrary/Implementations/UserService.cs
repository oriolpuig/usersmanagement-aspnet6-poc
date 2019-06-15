using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UsersManagement.DataAccess.Managers;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.ServiceLibrary.Common.Dtos;
using UsersManagement.ServiceLibrary.Common.Extensions;

namespace UsersManagement.ServiceLibrary.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationUserManager _applicationUserManager;

        public UserService(ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager ?? throw new ArgumentNullException($"{nameof(_applicationUserManager)} is null");
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            return _applicationUserManager.Users.ToUserListDto(roleManager.Roles);
        }

        public UserDto GetUser(string id)
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var user = _applicationUserManager.FindById(id);
            return user.ToUserDto(roleManager.Roles);
        }

        public UserDto CreateUser(UserDto newUser)
        {
            var newUserIdentity = newUser.ToEntity();
            if (newUserIdentity == null) throw new System.Exception("Error saving user.");
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            _applicationUserManager.Create(newUserIdentity);
            newUser.Roles.ForEach(r => _applicationUserManager.AddToRole(newUserIdentity.Id, r));

            return _applicationUserManager.FindByName(newUserIdentity.UserName).ToUserDto(roleManager.Roles);
        }

        public bool UpdateUser(string id, UserDto userToUpdate)
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var currentIdentityUser = _applicationUserManager.FindById(id);
            if (currentIdentityUser == null) throw new System.Exception("User not found on DB.");
            currentIdentityUser.UserName = userToUpdate.Username;

            var passwordHasher = new PasswordHasher();
            var isSamePassword = passwordHasher.VerifyHashedPassword(currentIdentityUser.PasswordHash, userToUpdate.Password);
            if (isSamePassword != PasswordVerificationResult.Success)
            {
                currentIdentityUser.PasswordHash = passwordHasher.HashPassword(userToUpdate.Password);
            }

            var roles = currentIdentityUser.Roles.Select(cr => roleManager.Roles.FirstOrDefault(r => r.Id == cr.RoleId).Name);
            _applicationUserManager.RemoveFromRoles(currentIdentityUser.Id, roles.ToArray());
            var newRoles = userToUpdate.Roles.Select(cr => roleManager.Roles.FirstOrDefault(r => r.Name == cr).Name);
            _applicationUserManager.AddToRoles(currentIdentityUser.Id, newRoles.ToArray());

            var result = _applicationUserManager.Update(currentIdentityUser);
            return result.Succeeded;
        }

        public bool DeleteUser(string id)
        {
            var currentIdentityUser = _applicationUserManager.FindById(id);
            var result = _applicationUserManager.Delete(currentIdentityUser);
            return result.Succeeded;
        }
    }
}
