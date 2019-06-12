using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using UsersManagement.ServiceLibrary.Common.Dtos;

namespace UsersManagement.ServiceLibrary.Common.Contracts
{
    public interface IUserService
    {
        IEnumerable<IdentityUser> GetAllUsers();
        IdentityUser GetUser(string id);
        IdentityUser CreateUser(UserDto newUser);
        bool UpdateUser(string id, UserDto userToUpdate);
        bool DeleteUser(string id);
    }
}
