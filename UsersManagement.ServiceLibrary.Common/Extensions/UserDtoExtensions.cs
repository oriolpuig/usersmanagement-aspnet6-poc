using UsersManagement.ServiceLibrary.Common.Dtos;
using UsersManagement.ServiceLibrary.Entities;

namespace UsersManagement.ServiceLibrary.Common.Extensions
{
    public static class UserDtoExtensions
    {
        public static UserDto ToUserDto(this User source) {
            UserDto result = null;
            if (source != null) {
                result = new UserDto
                {
                    Id = source.Id,
                    Username = source.Username,
                    Password = source.Password
                };
            }
            return result;
        }
    }
}
