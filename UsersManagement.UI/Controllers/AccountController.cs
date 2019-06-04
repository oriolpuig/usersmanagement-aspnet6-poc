using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.UI.Models.Account;

namespace UsersManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException($"{nameof(_authenticationService)} is null");
        }

        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { RedirectUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var currentUser = await _authenticationService.LoginAsync(model.Username, model.Password);
                if (currentUser != null)
                {
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false, ExpiresUtc = DateTimeOffset.Now.AddMinutes(5) }, currentUser);
                }
                else
                {
                    ModelState.AddModelError("Error", "Invalid credentials");
                    return View(model);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error", error);
                return View(model);
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(Url.Content(returnUrl));
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<ActionResult> Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}