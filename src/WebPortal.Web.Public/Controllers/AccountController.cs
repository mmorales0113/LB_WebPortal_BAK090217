using System;
using System.Threading.Tasks;
using Abp;
using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Timing;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Authorization.Users;
using WebPortal.Identity;
using WebPortal.MultiTenancy;
using WebPortal.Url;
using WebPortal.Web.Controllers;


namespace WebPortal.Web.Public.Controllers
{
    public class AccountController : WebPortalControllerBase
    {
        private readonly UserManager _userManager;
        private readonly SignInManager _signInManager;
        private readonly IWebUrlService _webUrlService;
        private readonly TenantManager _tenantManager;

        public AccountController(
            UserManager userManager,
            SignInManager signInManager,
            IWebUrlService webUrlService, 
            TenantManager tenantManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webUrlService = webUrlService;
            _tenantManager = tenantManager;
        }

        public async Task<ActionResult> Login(string accessToken, string userId, string tenantId = "", string returlUrl = "")
        {
            var targetTenantId = string.IsNullOrEmpty(tenantId) ? null : (int?)Convert.ToInt32(Base64Decode(tenantId));
            CurrentUnitOfWork.SetTenantId(targetTenantId);
            if (userId == null)
            {
                string link = string.Format("{0}{1}?ss={2}&returnUrl={3}", "localhost:62114/", "account/login", "true", "localhost:45776/Account/Login");
                return Redirect(link);
            }

            var targetUserId = Convert.ToInt64(Base64Decode(userId));
                var user = _userManager.GetUser(new UserIdentifier(targetTenantId, targetUserId));
           

            if (!user.SignInToken.Equals(accessToken) || !(user.SignInTokenExpireTimeUtc >= Clock.Now.ToUniversalTime()))
            {
                return RedirectToAction("Index", "Members");
            }

            CurrentUnitOfWork.SetTenantId(targetTenantId);
            await _signInManager.SignInAsync(user, false);

            if (!string.IsNullOrEmpty(returlUrl))
            {
                return Redirect(returlUrl);
            }
            string action = "HealthPlan";
            string control = "Members";
            return RedirectToAction(action, control);
        }

        public async Task<ActionResult> Logout()
        {
            var tenancyName = "";
            if (AbpSession.TenantId.HasValue)
            {
                var tenant = await _tenantManager.GetByIdAsync(AbpSession.GetTenantId());
                tenancyName = tenant.TenancyName;
            }

            var websiteAddress = _webUrlService.GetSiteRootAddress(tenancyName);
            var serverAddress = _webUrlService.GetServerRootAddress(tenancyName);

            await _signInManager.SignOutAsync();
            return Redirect(serverAddress.EnsureEndsWith('/') + "account/logout?returnUrl=" + websiteAddress);
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}