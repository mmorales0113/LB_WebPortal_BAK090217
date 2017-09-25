using System.Threading.Tasks;
using Abp.Application.Services;
using WebPortal.Editions.Dto;
using WebPortal.MultiTenancy.Dto;

namespace WebPortal.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}