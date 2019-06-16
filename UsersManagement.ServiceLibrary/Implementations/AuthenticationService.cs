using Microsoft.AspNet.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using UsersManagement.Common.Repositories;
using UsersManagement.DataAccess.Managers;
using UsersManagement.ServiceLibrary.Common.Contracts;

namespace UsersManagement.ServiceLibrary.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationUserManager _applicationUserManager;

        public AuthenticationService(ApplicationUserManager applicationUserManager, IUserRepository userRepository)
        {
            _applicationUserManager = applicationUserManager ?? throw new ArgumentNullException($"{nameof(_applicationUserManager)} is null");
        }

        public async Task<ClaimsIdentity> LoginAsync(string username, string password)
        {
            var user = await _applicationUserManager.FindAsync(username, password);
            var userIdentity = await _applicationUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
