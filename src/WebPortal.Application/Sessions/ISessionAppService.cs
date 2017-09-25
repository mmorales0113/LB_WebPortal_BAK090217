using System.Threading.Tasks;
using Abp.Application.Services;
using WebPortal.Sessions.Dto;

namespace WebPortal.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
