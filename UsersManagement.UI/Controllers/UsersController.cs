using System;
using System.Web.Http;
using UsersManagement.ServiceLibrary.Common.Contracts;

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
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Users
        public IHttpActionResult Post([FromBody]string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
