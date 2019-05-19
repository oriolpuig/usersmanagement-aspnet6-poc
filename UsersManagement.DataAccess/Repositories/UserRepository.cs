using System;
using System.Threading.Tasks;
using UsersManagement.Common.Repositories;
using UsersManagement.ServiceLibrary.Entities;

namespace UsersManagement.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        public async Task<User> GetByUsernameAsync(string email)
        {
            return new User { Username = email, Password = "12345", Id = Guid.NewGuid()};
        }
    }
}
