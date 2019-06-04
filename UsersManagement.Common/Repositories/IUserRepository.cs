using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace UsersManagement.Common.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser> GetByUsernameAsync(string email);
    }
}
