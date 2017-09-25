using Microsoft.Extensions.Configuration;

namespace WebPortal.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
