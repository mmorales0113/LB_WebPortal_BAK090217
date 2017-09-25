using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebPortal.Authentication.TwoFactor.Google;
using WebPortal.Authorization.Roles;
using WebPortal.Authorization.Users;
using WebPortal.MultiTenancy;

namespace WebPortal.Identity
{
    public static class IdentityRegistrar
    {
        private const string CookiePrefix = "Identity.WebPortal";

        public static void Register(IServiceCollection services, string cookiePostFix)
        {
            services.AddLogging();

            services.AddAbpIdentity<Tenant, User, Role>(options =>
                {
                    options.Cookies.ApplicationCookie.CookieName = CookiePrefix + "." + cookiePostFix;

                    options.Cookies.ExternalCookie.CookieName = CookiePrefix + ".External." + cookiePostFix;
                    options.Cookies.ExternalCookie.CookieName = CookiePrefix + ".TwoFactorRememberMe." + cookiePostFix;
                    options.Cookies.ExternalCookie.CookieName = CookiePrefix + ".TwoFactorUserId." + cookiePostFix;

                    options.Tokens.ProviderMap[GoogleAuthenticatorProvider.Name] = new TokenProviderDescriptor(typeof(GoogleAuthenticatorProvider));
                })
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddDefaultTokenProviders();
        }
    }
}
