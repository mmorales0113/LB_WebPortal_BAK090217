using System.Threading.Tasks;
using Abp.Application.Services;
using WebPortal.Configuration.Host.Dto;

namespace WebPortal.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
