﻿using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Authorization;
using WebPortal.Web.Controllers;

namespace WebPortal.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : WebPortalControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}