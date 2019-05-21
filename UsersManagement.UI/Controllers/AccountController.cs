using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using UsersManagement.Crosscutting.Enums;
using UsersManagement.Crosscutting.Helpers;
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
                    Session["Username"] = currentUser.Username;
                    Session["Role"] = RolesEnum.Admin.GetDescription();
                    Session.Timeout = 5;
                }
            }
            catch (Exception error)
            {
                throw;
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(Url.Content(returnUrl));
            }
            return RedirectToAction("Index", "Home");
        }
    }
}