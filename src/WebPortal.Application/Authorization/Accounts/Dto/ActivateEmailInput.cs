﻿using System.ComponentModel.DataAnnotations;

namespace WebPortal.Authorization.Accounts.Dto
{
    public class ActivateEmailInput
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public string ConfirmationCode { get; set; }
    }
}