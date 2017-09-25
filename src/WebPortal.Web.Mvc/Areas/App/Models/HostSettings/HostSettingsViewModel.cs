using System.Collections.Generic;
using Abp.Application.Services.Dto;
using WebPortal.Configuration.Host.Dto;
using WebPortal.Editions.Dto;

namespace WebPortal.Web.Areas.App.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}