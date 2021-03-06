using System;
using Abp.AutoMapper;

namespace WebPortal.MultiTenancy.HostDashboard.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class RecentTenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}