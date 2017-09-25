using System.Collections.Generic;
using WebPortal.Authorization.Users.Dto;

namespace WebPortal.Web.Areas.App.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}