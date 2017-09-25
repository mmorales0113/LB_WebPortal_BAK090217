using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Web.Areas.App.Models.Layout;
using WebPortal.Web.Session;
using WebPortal.Web.Views;

namespace WebPortal.Web.Areas.App.Views.Shared.Components.AppFooter
{
    public class AppFooterViewComponent : WebPortalViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppFooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
