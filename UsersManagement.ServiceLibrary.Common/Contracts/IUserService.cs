using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using UsersManagement.ServiceLibrary.Common.Dtos;

namespace UsersManagement.ServiceLibrary.Common.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUser(string id);
        UserDto CreateUser(UserDto newUser);
        bool UpdateUser(string id, UserDto userToUpdate);
        bool DeleteUser(string id);
    }
}
