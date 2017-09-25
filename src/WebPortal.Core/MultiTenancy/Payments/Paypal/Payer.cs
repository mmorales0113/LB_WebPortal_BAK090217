using Newtonsoft.Json;

namespace WebPortal.MultiTenancy.Payments.Paypal
{
    public class Payer
    {
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
    }
}