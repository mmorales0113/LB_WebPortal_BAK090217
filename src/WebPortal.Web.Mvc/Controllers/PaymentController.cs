using System;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Editions;
using WebPortal.MultiTenancy;
using WebPortal.MultiTenancy.Dto;
using WebPortal.MultiTenancy.Payments;
using WebPortal.MultiTenancy.Payments.Cache;
using WebPortal.MultiTenancy.Payments.Dto;
using WebPortal.Web.Models.Payment;

namespace WebPortal.Web.Controllers
{
    public class PaymentController : WebPortalControllerBase
    {
        private readonly IPaymentAppService _paymentAppService;
        private readonly ITenantRegistrationAppService _tenantRegistrationAppService;
        private readonly IPaymentCache _paymentCache;

        public PaymentController(IPaymentAppService paymentAppService,
            ITenantRegistrationAppService tenantRegistrationAppService,
            IPaymentCache paymentCache)
        {
            _paymentAppService = paymentAppService;
            _tenantRegistrationAppService = tenantRegistrationAppService;
            _paymentCache = paymentCache;
        }

        public async Task<IActionResult> Buy(int editionId, EditionPaymentType editionPaymentType, int? subscriptionStartType) //subscriptionStartType is used as int instead of SubscriptionStartType because MVC can not bind nullable enums
        {
            var edition = await _tenantRegistrationAppService.GetEdition(editionId);

            var model = new PaymentViewModel
            {
                Edition = edition,
                EditionPaymentType = editionPaymentType
            };

            if (subscriptionStartType.HasValue)
            {
                model.SubscriptionStartType = (SubscriptionStartType)subscriptionStartType.Value;
            }

            return View("Index", model);
        }

        public async Task<IActionResult> Upgrade(int upgradeEditionId, EditionPaymentType editionPaymentType)
        {
            return await UpgradeOrExtend(upgradeEditionId, editionPaymentType);
        }

        public async Task<IActionResult> Extend(int upgradeEditionId, EditionPaymentType editionPaymentType)
        {
            return await UpgradeOrExtend(upgradeEditionId, editionPaymentType);
        }

        [HttpPost]
        public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentModel model)
        {
            var createPaymentResult = await _paymentAppService.CreatePayment(new CreatePaymentDto
            {
                PaymentPeriodType = model.PaymentPeriodType,
                EditionId = model.EditionId,
                EditionPaymentType = model.EditionPaymentType,
                SubscriptionPaymentGatewayType = model.Gateway
            });

            return createPaymentResult;
        }

        [HttpPost]
        public async Task<ActionResult> ExecutePayment(int editionId, PaymentPeriodType paymentPeriodType, SubscriptionPaymentGatewayType? gateway = null)
        {
            Check.NotNull(gateway, nameof(gateway));

            var edition = await _tenantRegistrationAppService.GetEdition(editionId);
            if (edition.IsFree)
            {
                throw new Exception("Can not execute payment for free editions!");
            }
            
            var paymentId = await ExecutePaymentAsync(editionId, paymentPeriodType, gateway.Value);
            return RedirectToAction("Register", "TenantRegistration", new
            {
                editionId = editionId,
                subscriptionStartType = SubscriptionStartType.Paid,
                gateway = gateway,
                paymentId = paymentId
            });
        }

        private async Task<string> ExecutePaymentAsync(int editionId, PaymentPeriodType paymentPeriodType, SubscriptionPaymentGatewayType gateway)
        {
            var data = Request.Form.ToDictionary(q => q.Key, q => string.Join(",", q.Value));

            var result = await _paymentAppService.ExecutePayment(new ExecutePaymentDto
            {
                EditionId = editionId,
                EditionPaymentType = EditionPaymentType.NewRegistration,
                Gateway = gateway,
                AdditionalData = data
            });

            var paymentId = result.GetId();
            _paymentCache.AddCacheItem(new PaymentCacheItem(gateway, paymentPeriodType, paymentId));

            return paymentId;
        }

        private async Task<IActionResult> UpgradeOrExtend(int upgradeEditionId, EditionPaymentType editionPaymentType)
        {
            var paymentInfo = await _paymentAppService.GetPaymentInfo(new PaymentInfoInput { UpgradeEditionId = upgradeEditionId });
            var edition = await _tenantRegistrationAppService.GetEdition(upgradeEditionId);

            var model = new PaymentViewModel
            {
                Edition = edition,
                AdditionalPrice = paymentInfo.AdditionalPrice,
                EditionPaymentType = editionPaymentType
            };

            return View("Index", model);
        }
    }
}