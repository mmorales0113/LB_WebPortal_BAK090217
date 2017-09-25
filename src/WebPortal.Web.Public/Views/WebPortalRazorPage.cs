using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace WebPortal.Web.Public.Views
{
    public abstract class WebPortalRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected WebPortalRazorPage()
        {
            LocalizationSourceName = WebPortalConsts.LocalizationSourceName;
        }
    }
}
