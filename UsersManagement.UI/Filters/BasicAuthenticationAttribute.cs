using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using UsersManagement.ServiceLibrary.Common.Contracts;

namespace UsersManagement.UI.Filters
{
    public static class ServiceLocator
    {
        public static IAuthenticationService AuthenticationService { get; set; }
    }

    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public string BasicRealm { get; set; }

        public BasicAuthenticationAttribute()
            : this(ServiceLocator.AuthenticationService)
        {
        }

        public BasicAuthenticationAttribute(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        public IAuthenticationService AuthenticationService { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                var arrUserNameandPassword = decodeauthToken.Split(':');

                if (IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(arrUserNameandPassword[0]), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        public bool IsAuthorizedUser(string username, string password)
        {
            var dbUser = this.AuthenticationService.Login(username, password);
            if (dbUser != null)
                return true;
            else
                return false;
        }
    }
}