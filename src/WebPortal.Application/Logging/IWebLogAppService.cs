using Abp.Application.Services;
using WebPortal.Dto;
using WebPortal.Logging.Dto;

namespace WebPortal.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
