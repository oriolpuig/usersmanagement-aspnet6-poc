using System.Security.Claims;
using System.Threading.Tasks;

namespace UsersManagement.ServiceLibrary.Common.Contracts
{
    public interface IAuthenticationService
    {
        Task<ClaimsIdentity> LoginAsync(string username, string password);
        Task LogoutAsync(string username);
    }
}
