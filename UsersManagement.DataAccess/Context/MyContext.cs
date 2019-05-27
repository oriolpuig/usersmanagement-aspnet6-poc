using System.Data.Entity;
using UsersManagement.ServiceLibrary.Entities;

namespace UsersManagement.DataAccess.Context
{
    public class MyContext : DbContext
    {

        public MyContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
