using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UsersManagement.DataAccess.Managers
{
    public class ApplicationUserManager : UserManager<IdentityUser>
    {
        public ApplicationUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
        }
    }
}
