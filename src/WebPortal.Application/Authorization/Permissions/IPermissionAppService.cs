using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WebPortal.Authorization.Permissions.Dto;

namespace WebPortal.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
