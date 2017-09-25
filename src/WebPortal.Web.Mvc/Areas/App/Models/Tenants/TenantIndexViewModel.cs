using System.Collections.Generic;
using WebPortal.Editions.Dto;

namespace WebPortal.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}