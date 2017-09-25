using Abp.AutoMapper;
using WebPortal.Editions;
using WebPortal.MultiTenancy.Payments.Dto;

namespace WebPortal.Web.Areas.App.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}