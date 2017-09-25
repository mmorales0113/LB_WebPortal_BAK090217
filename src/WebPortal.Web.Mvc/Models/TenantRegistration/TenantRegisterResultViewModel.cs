﻿using Abp.AutoMapper;
using WebPortal.MultiTenancy.Dto;

namespace WebPortal.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}