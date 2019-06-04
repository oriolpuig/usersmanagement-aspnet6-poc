using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace UsersManagement.DataAccess.Context.Seeds
{
    public static class RolesSeed
    {
        public static void Seed(MyContext context)
        {
            AddNewRole(context, "Admin");
            AddNewRole(context, "PAGE_1");
            AddNewRole(context, "PAGE_2");
            AddNewRole(context, "PAGE_3");
        }

        private static void AddNewRole(MyContext context, string roleName)
        {
            if (!context.Roles.Any(r => r.Name == roleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = roleName };
                manager.Create(role);
            }
        }
    }
}
