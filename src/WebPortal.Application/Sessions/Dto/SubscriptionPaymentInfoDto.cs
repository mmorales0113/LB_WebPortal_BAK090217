using Abp.AutoMapper;
using WebPortal.MultiTenancy.Payments;

namespace WebPortal.Sessions.Dto
{
    [AutoMapFrom(typeof(SubscriptionPayment))]
    public class SubscriptionPaymentInfoDto
    {
        public decimal Amount { get; set; }
    }
}