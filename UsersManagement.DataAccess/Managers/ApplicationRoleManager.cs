using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace UsersManagement.DataAccess.Managers
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole> store, IdentityFactoryOptions<ApplicationUserManager> options)
            : base(store)
        {
        }
    }
}
