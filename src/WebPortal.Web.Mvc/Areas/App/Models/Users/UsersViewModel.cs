using System.Collections.Generic;
using Abp.Application.Services.Dto;
using WebPortal.Security;

namespace WebPortal.Web.Areas.App.Models.Users
{
    public class UsersViewModel
    {
        public string FilterText { get; set; }

        public List<ComboboxItemDto> Permissions { get; set; }

        public List<ComboboxItemDto> Roles { get; set; }
    }
}