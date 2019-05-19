using System.Threading.Tasks;
using UsersManagement.ServiceLibrary.Entities;

namespace UsersManagement.Common.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string email);
    }
}
