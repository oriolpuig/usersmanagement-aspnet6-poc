using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using UsersManagement.DataAccess.Managers;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.ServiceLibrary.Common.Dtos;
using UsersManagement.ServiceLibrary.Common.Extensions;

namespace UsersManagement.ServiceLibrary.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationRoleManager _applicationRoleManager;

        public UserService(ApplicationUserManager applicationUserManager, ApplicationRoleManager applicationRoleManager)
        {
            _applicationUserManager = applicationUserManager ?? throw new ArgumentNullException($"{nameof(_applicationUserManager)} is null");
            _applicationRoleManager = applicationRoleManager ?? throw new ArgumentNullException($"{nameof(_applicationRoleManager)} is null");
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var roles = _applicationRoleManager.Roles;
            return _applicationUserManager.Users.ToUserListDto(roles);
        }

        public UserDto GetUser(string id)
        {
            var user = _applicationUserManager.FindById(id);
            var roles = _applicationRoleManager.Roles;
            return user.ToUserDto(roles);
        }

        public UserDto GetUserByUsernameAndPassword(string userName, string password)
        {
            var user = _applicationUserManager.Find(userName, password);
            var roles = _applicationRoleManager.Roles;
            return user.ToUserDto(roles);
        }

        public UserDto CreateUser(UserDto newUser)
        {
            var newUserIdentity = newUser.ToEntity();
            if (newUserIdentity == null) throw new System.Exception("Error saving user.");
            var roles = _applicationRoleManager.Roles;

            _applicationUserManager.Create(newUserIdentity);
            newUser.Roles.ForEach(r => _applicationUserManager.AddToRole(newUserIdentity.Id, r));

            return _applicationUserManager.FindByName(newUserIdentity.UserName).ToUserDto(roles);
        }

        public bool UpdateUser(string id, UserDto userToUpdate)
        {
            if (id != userToUpdate.Id) throw new Exception("Wrong user to update");

            var currentIdentityUser = _applicationUserManager.FindById(id);
            if (currentIdentityUser == null) throw new System.Exception("User not found on DB.");

            currentIdentityUser.UserName = userToUpdate.Username;

            var passwordHasher = new PasswordHasher();
            var isSamePassword = passwordHasher.VerifyHashedPassword(currentIdentityUser.PasswordHash, userToUpdate.Password);
            if (isSamePassword != PasswordVerificationResult.Success)
            {
                currentIdentityUser.PasswordHash = passwordHasher.HashPassword(userToUpdate.Password);
            }

            var roles = _applicationRoleManager.Roles;
            var rolesToRemove = currentIdentityUser.Roles.Select(cr => roles.FirstOrDefault(r => r.Id == cr.RoleId).Name);
            _applicationUserManager.RemoveFromRoles(currentIdentityUser.Id, rolesToRemove.ToArray());

            var newRoles = userToUpdate.Roles.Select(cr => roles.FirstOrDefault(r => r.Name == cr).Name);
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
