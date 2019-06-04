using System.Web.Mvc;

namespace UsersManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}