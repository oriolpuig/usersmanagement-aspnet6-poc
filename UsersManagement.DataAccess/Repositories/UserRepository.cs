using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using UsersManagement.Common.Repositories;

namespace UsersManagement.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {

        public async Task<IdentityUser> GetByUsernameAsync(string email)
        {
            return new IdentityUser { UserName = email, PasswordHash = "12345" };
        }
    }
}
