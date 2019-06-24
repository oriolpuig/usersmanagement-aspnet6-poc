using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace UsersManagement.DataAccess.Context.Seeds
{
    public static class UsersSeed
    {
        public static void Seed(MyContext context)
        {
            AddNewUser(context, "Admin", "Admin");
            AddNewUser(context, "PAGE_1", "PAGE_1", "PAGE_1");
            AddNewUser(context, "PAGE_2", "PAGE_2", "PAGE_2");
            AddNewUser(context, "PAGE_3", "PAGE_3", "PAGE_3");
        }

        private static void AddNewUser(MyContext context, string username, string password, string roleName = "Admin")
        {
            if (!context.Users.Any(u => u.UserName == username))
            {
                var passwordHash = new PasswordHasher();
                var store = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(store);
                var user = new IdentityUser { UserName = username, PasswordHash = passwordHash.HashPassword(password) };

                var isUserCreated = manager.Create(user);
                if (isUserCreated.Succeeded)
                {
                    manager.AddToRole(user.Id, roleName);
                }
            }
        }
    }
}