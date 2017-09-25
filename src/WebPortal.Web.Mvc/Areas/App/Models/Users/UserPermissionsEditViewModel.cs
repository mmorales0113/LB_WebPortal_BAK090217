using Abp.AutoMapper;
using WebPortal.Authorization.Users;
using WebPortal.Authorization.Users.Dto;
using WebPortal.Web.Areas.App.Models.Common;

namespace WebPortal.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}