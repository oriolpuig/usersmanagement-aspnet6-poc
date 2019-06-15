using System;
using System.Web.Http;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.UI.Models.Extensions;
using UsersManagement.UI.Models.Users;

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

        //GET: api/Users/5
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
        public IHttpActionResult Post(UserViewModel newUser)
        {
            try
            {
                return Ok(_userService.CreateUser(newUser.ToUserDto()));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(string id, UserViewModel userToUpdate)
        {
            try
            {
                if (_userService.UpdateUser(id, userToUpdate.ToUserDto()))
                    return Ok();
                else
                    throw new Exception("User not saved.");
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
                if (_userService.DeleteUser(id))
                    return Ok();
                else
                    throw new Exception("User not deleted.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
