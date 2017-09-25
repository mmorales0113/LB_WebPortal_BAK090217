using Abp.Domain.Services;

namespace WebPortal
{
    public abstract class WebPortalDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected WebPortalDomainServiceBase()
        {
            LocalizationSourceName = WebPortalConsts.LocalizationSourceName;
        }
    }
}
