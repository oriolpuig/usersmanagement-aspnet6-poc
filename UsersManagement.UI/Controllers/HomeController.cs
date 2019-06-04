using System.Web.Mvc;
using UsersManagement.UI.Models.Extensions;

namespace UsersManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsAdmin()) return RedirectToAction("Admin");
            else if (User.IsPage1()) return RedirectToAction("Page_1");
            else if (User.IsPage2()) return RedirectToAction("Page_2");
            else if (User.IsPage3()) return RedirectToAction("Page_3");

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "PAGE_1")]
        public ActionResult Page_1()
        {
            return View();
        }

        [Authorize(Roles = "PAGE_2")]
        public ActionResult Page_2()
        {
            return View();
        }

        [Authorize(Roles = "PAGE_3")]
        public ActionResult Page_3()
        {
            return View();
        }
    }
}