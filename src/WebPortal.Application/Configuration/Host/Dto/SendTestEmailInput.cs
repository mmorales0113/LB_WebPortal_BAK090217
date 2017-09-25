using System.ComponentModel.DataAnnotations;
using WebPortal.Authorization.Users;

namespace WebPortal.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}