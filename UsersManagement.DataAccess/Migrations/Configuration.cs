using System.Data.Entity.Migrations;
using UsersManagement.DataAccess.Context;
using UsersManagement.DataAccess.Context.Seeds;

namespace UsersManagement.DataAccess.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyContext context)
        {
            RolesSeed.Seed(context);
            UsersSeed.Seed(context);
        }
    }
}
