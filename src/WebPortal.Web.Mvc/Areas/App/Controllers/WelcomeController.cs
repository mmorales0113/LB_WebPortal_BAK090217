using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Web.Controllers;

namespace WebPortal.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class WelcomeController : WebPortalControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}