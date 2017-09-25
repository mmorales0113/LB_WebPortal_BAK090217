using Microsoft.AspNetCore.Mvc;
using WebPortal.Web.Controllers;

namespace WebPortal.Web.Public.Controllers
{
    public class AboutController : WebPortalControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}