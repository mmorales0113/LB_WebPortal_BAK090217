using System.Collections.Generic;
using Abp.Application.Services.Dto;
using WebPortal.Configuration.Tenants.Dto;

namespace WebPortal.Web.Areas.App.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}