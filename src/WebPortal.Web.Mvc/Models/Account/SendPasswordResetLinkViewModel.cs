using System.ComponentModel.DataAnnotations;

namespace WebPortal.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}