using System;
using System.Web.Http;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.ServiceLibrary.Common.Dtos;
using UsersManagement.UI.Models.Extensions;

namespace UsersManagement.UI.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService ?? throw new ArgumentNullException($"{nameof(_userService)} is null");
        }

        // GET: api/Users
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_userService.GetAllUsers().ToUserListViewModel());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Users/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                return Ok(_userService.GetUser(id).ToUserViewModel());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Users
        public IHttpActionResult Post(UserDto newUser)
        {
            try
            {
                return Ok(_userService.CreateUser(newUser));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(string id, UserDto userToUpdate)
        {
            try
            {
                return Ok(_userService.UpdateUser(id, userToUpdate));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Users/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                return Ok(_userService.DeleteUser(id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
