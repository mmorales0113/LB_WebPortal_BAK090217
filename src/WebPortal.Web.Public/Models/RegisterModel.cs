using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.Extensions;
using WebPortal.Authorization.Users;
using WebPortal.Security;
using WebPortal.Validation;

namespace WebPortal.Web.Public.Models
{
    public class RegisterModel
    {
        [Required(AllowEmptyStrings = false)]
        public string EmployerName { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public string EmployerEmail { get; set; }

    }
}