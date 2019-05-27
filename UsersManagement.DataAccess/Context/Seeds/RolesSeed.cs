using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManagement.ServiceLibrary.Entities;

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
            context.Roles.AddOrUpdate(x => x.Name, new Role
            {
                Name = roleName
            });
        }
    }
}
