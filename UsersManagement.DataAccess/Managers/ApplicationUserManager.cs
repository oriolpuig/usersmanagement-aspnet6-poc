using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace UsersManagement.DataAccess.Managers
{
    public class ApplicationUserManager : UserManager<IdentityUser>
    {
        public ApplicationUserManager(IUserStore<IdentityUser> store, IdentityFactoryOptions<ApplicationUserManager> options)
            : base(store)
        {
        }
    }
}
