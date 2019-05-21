using System;
using System.Threading.Tasks;
using UsersManagement.Common.Repositories;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.ServiceLibrary.Common.Dtos;
using UsersManagement.ServiceLibrary.Common.Extensions;

namespace UsersManagement.ServiceLibrary.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException($"{nameof(_userRepository)} is null");
        }

        public async Task<UserDto> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null) return null;
            if (user.Password == password) {
                return user.ToUserDto();
            }
            return null;
        }

        public Task LogoutAsync(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}
