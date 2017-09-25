using System.Collections.Generic;
using WebPortal.Caching.Dto;

namespace WebPortal.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}