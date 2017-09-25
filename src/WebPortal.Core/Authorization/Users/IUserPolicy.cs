using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace WebPortal.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
