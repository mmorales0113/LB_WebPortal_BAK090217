using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Web.Controllers
{
    public class HomeController : WebPortalControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
