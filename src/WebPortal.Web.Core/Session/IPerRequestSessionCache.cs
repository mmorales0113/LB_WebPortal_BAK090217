using System.Threading.Tasks;
using WebPortal.Sessions.Dto;

namespace WebPortal.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
