﻿using Abp.AspNetCore.Mvc.ViewComponents;

namespace WebPortal.Web.Views
{
    public abstract class WebPortalViewComponent : AbpViewComponent
    {
        protected WebPortalViewComponent()
        {
            LocalizationSourceName = WebPortalConsts.LocalizationSourceName;
        }
    }
}