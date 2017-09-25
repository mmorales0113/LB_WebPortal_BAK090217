using System.Threading.Tasks;
using Abp.Application.Services;
using WebPortal.Configuration.Tenants.Dto;

namespace WebPortal.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
