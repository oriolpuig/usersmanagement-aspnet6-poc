using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManagement.ServiceLibrary.Common.Dtos;

namespace UsersManagement.ServiceLibrary.Common.Contracts
{
    public interface IAuthenticationService
    {
        Task<UserDto> LoginAsync(string username, string password);
        Task LogoutAsync(string username);
    }
}
