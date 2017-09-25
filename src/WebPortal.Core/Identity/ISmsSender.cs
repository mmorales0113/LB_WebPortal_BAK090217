using System.Threading.Tasks;

namespace WebPortal.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}