using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace UsersManagement.ServiceLibrary.Common.Contracts
{
    public interface IUserService
    {
        IEnumerable<IdentityUser> GetAllUsers();
    }
}
