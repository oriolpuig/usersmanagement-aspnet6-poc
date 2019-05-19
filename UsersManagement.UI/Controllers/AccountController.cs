using System.Web.Mvc;
using UsersManagement.UI.Models.Account;

namespace UsersManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { RedirectUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(Url.Content(returnUrl));
            }
            return RedirectToAction("Index", "Home");
        }
    }
}