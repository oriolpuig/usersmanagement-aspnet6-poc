using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using UsersManagement.Common.Repositories;
using UsersManagement.ServiceLibrary.Common.Contracts;

namespace UsersManagement.ServiceLibrary.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException($"{nameof(_userRepository)} is null");
        }

        public ClaimsIdentity Login(string username, string password)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(username, password);
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public async Task<ClaimsIdentity> LoginAsync(string username, string password)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = await userManager.FindAsync(username, password);
            var userIdentity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public Task LogoutAsync(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}
