using System.Data.Entity.Migrations;
using System.Linq;
using UsersManagement.ServiceLibrary.Entities;

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
            var user = new User { Username = username, Password = password };
            var role = context.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role != null) user.Roles.Add(role);

            context.Users.AddOrUpdate(x => x.Username, user);
        }
    }
}