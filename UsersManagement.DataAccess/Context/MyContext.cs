using Microsoft.AspNet.Identity.EntityFramework;

namespace UsersManagement.DataAccess.Context
{
    public class MyContext : IdentityDbContext<IdentityUser>
    {
        public MyContext()
            : base("DefaultConnection")
        {

        }
    }
}
